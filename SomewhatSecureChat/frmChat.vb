Imports System.Security.Cryptography
Imports System.Net.Sockets
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Threading


'>>> SomewhatSecureChat, written by capablemonkey (10/5/11)
'
'
'   Features implemented:
'       - Multithreaded (independently threaded listen server)
'       - TCP/IP (wouldn't be much of a 'chat client', now would it?)
'       - Fixed socket problem
'       - Masked PW box
'       - Status bar
'       - Improved error handling
'
'   Bugs & TODO:
'       - unsafe control access (FIXED)
'       - fix tab order
'       - implement focus
'       - secure file transmission
'       - 'chatroom' or multiple clients
'       - Choose encryption scheme
'       - RSA public + private keys, much better than single password
'       - Timestamps
'


Public Class frmChat

    Dim wrapper As Simple3Des

    Private Sub txtMessage_Hotkeys(ByVal sender As System.Object, ByVal key As System.Windows.Forms.KeyEventArgs) Handles txtMessage.KeyUp
        ' Handles keypresses while txtMessage has focus
        If key.KeyCode = Keys.Enter Then
            Call cmdSend_Click()
        End If

    End Sub

    Private Sub frmMane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Somewhat Secure Chat"

        lblTitle.Text = "Somewhat Secure Chat"
        lblSlogan.Text = """Oh well, at least it's better than plaintext..."""
        lblPassword.Text = "Key/Password: "
        lblMessage.Text = "Message: "
        lblDestination.Text = "Destination IP: "
        lblDestinationPort.Text = "Destination Port: "
        lblListeningPort.Text = "Listening Port: "
        lblReceived.Text = "Message Log: "
        txtLog.Text = ""

        cmdListen.Text = "Start Listening"
        cmdSend.Text = "Send Message"
        ToolStriplblStatus.Text = "Ready"

    End Sub

    Function Encode(ByVal plaintext As String, ByVal key As String)
        'encrypts plaintext using wrapper, returns ciphertext
        Dim encryptedtext As String = wrapper.EncryptData(plaintext)
        Return encryptedtext
    End Function

    Function Decode(ByVal encdata As String, ByVal key As String)
        'decrypts ciphertext, returns plaintext
        Dim plainText As String = "FAILED: Bad Password"
        ' DecryptData throws if the wrong password is used.
        Try
            plainText = wrapper.DecryptData(encdata)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The message could not be decrypted with the given password.")
        End Try

        Return plainText
    End Function

    Private Sub cmdSend_Click() Handles cmdSend.Click
        'encrypts and sends data

        'ensure fields are filled correctly
        Try
            ConfirmFields("send")
        Catch
            Exit Sub
        End Try
        Dim key As String = txtPassword.Text
        'check if wrapper already exists
        If wrapper Is Nothing Then
            wrapper = New Simple3Des(key)
        End If

        Dim message As String = txtMessage.Text.Trim()
        If message.EndsWith(vbNewLine) Or message.EndsWith(vbCrLf) Or message.EndsWith(ControlChars.CrLf) Then
            message = message.Remove(message.Length - 1)
        End If

        'check and set IP address
        Dim IP As IPAddress
        Try
            IP = IPAddress.Parse(txtDestination.Text)
        Catch
            MsgBox("Bad IP Address, try again.")
            Exit Sub
        End Try

        'check and set port number
        If Not IsNumeric(txtDestinationPort.Text) Then
            MsgBox("Bad port number")
            Exit Sub
        ElseIf Convert.ToInt32(txtDestinationPort.Text) > 65535 Or Convert.ToInt32(txtDestinationPort.Text) < 1 Then
            MsgBox("Port number must be between 1-65535")
            Exit Sub
        End If
        Dim RPort As Integer = txtDestinationPort.Text

        'encrypt text, store in encrypted
        Dim encrypted As String = Encode(message, key)
        'update toolstrip
        ToolStriplblStatus.Text = "Encrypted message.  Sending ciphertext: " & encrypted

        Dim sendsocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim recipient As New IPEndPoint(IP, RPort)
        Try
            Dim tcpClient As New System.Net.Sockets.TcpClient()
            tcpClient.Connect(IP, RPort)
            Dim networkStream As NetworkStream = tcpClient.GetStream()
            If networkStream.CanWrite And networkStream.CanRead Then
                Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(encrypted)
                networkStream.Write(sendBytes, 0, sendBytes.Length)

            End If
        Catch
            MsgBox("Try again, something went wrong with networking.  Ensure that the IP address and port number you specified is correct and open for incoming connections.")
            Exit Sub
        End Try

        ToolStriplblStatus.Text = "Encrypted message sent."
        txtLog.Text = txtLog.Text & vbNewLine & "You:     " & message
        txtMessage.Text = ""
        txtMessage.Focus()

    End Sub

    Public Sub ConfirmFields(ByVal procedure As String)
        'confirms that fields are completed

        'if sending
        If procedure = "send" Then
            If txtPassword.Text.Length = 0 Then
                Yell("Password")
                Throw New Exception("Badinput")
            ElseIf txtMessage.Text.Length = 0 Then
                Yell("Message")
                Throw New Exception("Badinput")
            ElseIf txtDestinationPort.Text.Length = 0 Then
                Yell("Desination Port")
                Throw New Exception("Badinput")
            ElseIf txtDestination.Text.Length = 0 Then
                Yell("Desination IP")
                Throw New Exception("Badinput")
            End If

            'if receiving data
        ElseIf procedure = "receive" Then
            If txtListeningPort.Text.Length = 0 Then
                Yell("Listening Port")
                Throw New Exception("Badinput")

            ElseIf txtPassword.Text.Length = 0 Then
                Yell("Password")
                Throw New Exception("Badinput")

            End If
        End If
    End Sub

    Public Sub Yell(ByVal complaint As String)
        MsgBox(complaint & " cannot be left blank!  Try again!")
    End Sub

    Private listenThread As Thread

    Private Sub Lissenin()
        'Thread job, listens for messages for eternity, decrypts them, logs them in log textbox.

        Dim key As String = txtPassword.Text
        wrapper = New Simple3Des(key)
        If Not IsNumeric(txtListeningPort.Text) Then
            MsgBox("Bad port number")
            Exit Sub
        ElseIf Convert.ToInt32(txtListeningPort.Text) > 65535 Or Convert.ToInt32(txtListeningPort.Text) < 1 Then
            MsgBox("Port number must be between 1-65535")
            Exit Sub
        End If
        Dim lPort As Integer = txtListeningPort.Text
        Dim clientdata As String
        Dim tcpListener As New TcpListener(lPort)

        tcpListener.Start()

        'listening
        ToolStriplblStatus.Text = "Listening/waiting for message..."
        Do
            Try
                'Accept the pending client connection and return 
                'a TcpClient initialized for communication. 
                Dim tcpClient As TcpClient = tcpListener.AcceptTcpClient()
                'MsgBox("Connection accepted.")
                ' Get the stream
                Dim networkStream As NetworkStream = tcpClient.GetStream()
                ' Read the stream into a byte array
                Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
                ' Return the data received from the client to the console.
                clientdata = Encoding.ASCII.GetString(bytes)

            Catch
                MsgBox("OH NO!  Something went wrong.")
                Exit Sub
            End Try

            Dim exfil As String = clientdata.Trim()
            Dim lastchar As Integer = 0

            exfil = Replace(exfil, Chr(0), "") 'Strip NULL characters from string

            ToolStriplblStatus.Text = "Ciphertext: " & exfil

            clientdata = Decode(exfil, key)
            If clientdata = "FAILED: Bad Password" Then
                'txtLog.Text = 
                SetText(txtLog.Text & vbNewLine & clientdata & " | Ciphertext: " & exfil)
                ToolStriplblStatus.Text = "FAILED to decrypt message"
            Else
                SetText(txtLog.Text & vbNewLine & "Partner: " & clientdata)
                ToolStriplblStatus.Text = "Decrypted message"
            End If

        Loop
    End Sub

    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub SetText(ByVal [text] As String)
        'snippet taken from MSDN, "How to: Make Thread-Safe Calls to Windows Forms Controls" tutorial
        '
        If Me.txtLog.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.txtLog.Text = [text]
        End If
    End Sub

    Private Sub cmdListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListen.Click
        'receives encrypted data and decrypts it

        Try
            ConfirmFields("receive")    'check inputs
        Catch
            Exit Sub                    'exit sub if bad input(s)
        End Try

        'start new listening thread
        listenThread = New Thread(AddressOf Lissenin)
        listenThread.IsBackground = True
        listenThread.Start()

        'disable button to prevent multiple listen threads
        cmdListen.Enabled = False

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Have a chat with your buddy over LAN." & vbNewLine & vbNewLine & "Somewhat Secure Chat, written by capablemonkey; 2012." & vbNewLine & "Data is encrypted via 3DES (Triple DES algorithm)." & vbNewLine & vbNewLine & "Usage: To SEND an encrypted message, type in your message, the recipient's IP address and port number, and type in a password of your choice to encrypt it with.  The recipient will also need this password to decrypt it." & vbNewLine & vbNewLine & "To RECEIEVE messages, type in the same password the other party used to encrypt them, and the port you'd like to listen from.  The other party needs to know this port in order to send a message to you." & vbNewLine & vbNewLine & "Contact: technix1@gmail.com" & vbNewLine & "Blog: capablemonkey.blogspot.com")
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        'allow listener to change password even after launch
        wrapper = New Simple3Des(txtPassword.Text)
    End Sub

    Private Sub lblHelp1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblHelp1.LinkClicked
        MsgBox("This port number you must ask the other party for, it is a number between 1 and 65535 that the recipient chooses to listen on.")
    End Sub

    Private Sub lblHelp2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblHelp2.LinkClicked
        MsgBox("If you don't know what this means, you can choose any number between 1100-65000, but be sure to tell the other party what the number you picked!")
    End Sub



    Private Sub txtLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLog.TextChanged
        txtLog.Select(txtLog.Text.Length - 1, 0)
        txtLog.ScrollToCaret()
    End Sub
End Class

Public NotInheritable Class Simple3Des
    'crypto snippet also from MSDN

    Private TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(
            ByVal key As String,
            ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Public Function EncryptData(
                ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(
ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function


End Class