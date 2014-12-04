'Name: Spencer Kokaly
'Class: CS401
'Program: CS401 Project

Imports BankingConnector
Public Class frmKeypad

    'Public Connection
    Public host As String = "97.84.176.46"
    Public port As Integer = 8080
    Public strConn As BankingConnection = New BankingConnection(host, port)

    'Public PIN (Account) Variables
    Public intPIN As Integer
    Public strPIN As String = Nothing

    'Public Password Variables
    Public intPass As Integer
    Public strPass As String = Nothing
    Public blnGettingPIN As Boolean = True

    'Handles the Number Button Clicks
    Private Sub NumberClick(sender As Object, e As EventArgs) Handles cmd0.Click, cmd1.Click, cmd2.Click, cmd3.Click, cmd4.Click, _
                                                                       cmd5.Click, cmd6.Click, cmd7.Click, cmd8.Click, cmd9.Click

        lblValid.Hide()

        'Determining Whether it is Getting the PIN (Account) or Password
        If blnGettingPIN Then

            'Setting String PIN
            strPIN += CType(sender, Button).Tag
            mtbInput.Text = strPIN

        Else

            'Setting String Pass
            strPass += CType(sender, Button).Tag
            mtbInput.Text = strPass

        End If
    End Sub

    'Handles the Enter Button for PIN (Account) or Password
    Private Sub cmdEnter_Click(sender As Object, e As EventArgs) Handles cmdEnter.Click

        lblValid.Hide()

        'Seeing if PIN or Password is Being Checked
        If blnGettingPIN Then

            'Switching to Get Password
            blnGettingPIN = False
            mtbInput.Clear()

            'Putting String PIN to Int PIN
            intPIN = CInt(strPIN)

            'Switching Label Text
            lblEnterType.Text = "Enter Your PIN Number"

        Else

            'Putting String Pass to Int Pass
            intPass = CInt(strPass)

            'Checking All Info
            strConn.SetBankingInformation(intPIN, intPass)

            'Seeing if Account is Valid
            If strConn.IsValidAccount() Then
                Me.Hide()
                frmStartingScreen.Show()
            Else
                lblValid.Show()
                Reset()
            End If

        End If

    End Sub

    'Clears the Entered PIN and Resets the textbox
    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click

        'Clearing The PIN and Input
        strPIN = Nothing
        strPass = Nothing
        mtbInput.Clear()
        lblValid.Hide()

    End Sub

    'Sees if the Server can be Connected to
    Private Sub frmATM_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Seeing if Server Can be Connected To
        If strConn.IsServerOnline() = False Then

            'Prompting That Server can't be Connected To and Closes Program
            MessageBox.Show("Server can't be connected to!", "Can't Connect To Server!")
            Me.Dispose()

        Else

            'Showing Form
            Me.Show()

            'Hiding Label
            lblValid.Hide()

        End If

    End Sub

    'Disposes Keypad
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Me.Dispose()

    End Sub

    'Resets PIN (Account) and Password
    Sub Reset()

        'Resetting Variables
        strPIN = Nothing
        strPass = Nothing
        blnGettingPIN = True
        lblEnterType.Text = "Enter Your Account Number"
        mtbInput.Clear()

    End Sub

End Class