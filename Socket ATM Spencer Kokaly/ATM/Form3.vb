Public Class frmAccountKeypad

    'Public Withdraw Variables
    Public dblWithdraw As Double
    Public strWithdraw As String = Nothing

    'Public Deposit Variables
    Public dblDeposit As Double
    Public strDeposit As String = Nothing

    'Public String For Checking Info
    Public strType As String = Nothing
    Public strInfo As [String]()
    Public strInfo2 As String
    Public dblAvailable As Double

    'Handles the Number Button Clicks
    Private Sub NumberClick(sender As Object, e As EventArgs) Handles cmd0.Click, cmd1.Click, cmd2.Click, cmd3.Click, cmd4.Click, _
                                                                      cmd5.Click, cmd6.Click, cmd7.Click, cmd8.Click, cmd9.Click, cmdDot.Click

        'Determining Whether Withdraw or Deposit
        If frmStartingScreen.blnWithDraw Then

            'Setting String Withdraw
            strWithdraw += CType(sender, Button).Tag
            mtbInput.Text = "$" & strWithdraw

        Else

            'Setting String Deposit
            strDeposit += CType(sender, Button).Tag
            mtbInput.Text = "$" & strDeposit

        End If

    End Sub

    'Clearing the Withdraw and Deposit Amount
    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click

        Reset()

    End Sub

    'Cancels the Request
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Me.Dispose()
        frmStartingScreen.Show()
        frmStartingScreen.ShowStartingButtons()

    End Sub

    'Sending Amount
    Private Sub cmdEnter_Click(sender As Object, e As EventArgs) Handles cmdEnter.Click

        'Getting Account Info
        GetInfo()

        'Determining Whether Withdraw or Deposit
        If frmStartingScreen.blnWithDraw Then

            'Attempting To Withdraw Money
            dblWithdraw = CDbl(strWithdraw)

            'Seeing if Withdraw Can Occur
            If dblWithdraw > dblAvailable Then
                frmStats.Show()
                frmStats.InvalidFunds()
            Else

                'There are Enough Funds so A Withdraw can Occur
                If frmKeypad.strConn.Withdraw(dblWithdraw, frmStartingScreen.intChoice) Then
                    frmStats.Show()
                    frmStats.Withdraw()
                Else
                    frmStats.Show()
                    frmStats.WithdrawError()
                End If

            End If

        Else

            'Attempting To Deposit Money
            dblDeposit = CDbl(strDeposit)

            If frmKeypad.strConn.Deposit(dblDeposit, frmStartingScreen.intChoice) Then
                frmStats.Show()
                frmStats.Deposit()
            Else
                frmStats.Show()
                frmStats.DepositError()
            End If

        End If

        Me.Hide()
        Reset()

    End Sub

    'Setting Label and Form Header Text
    Private Sub frmAccountKeypad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Calling Reset
        Reset()

        'Header Text
        If frmStartingScreen.intChoice = 1 Then
            strType = "SAVINGS"
            Me.Text = "Account ID: " & frmKeypad.intPIN & "      Name: " & frmStartingScreen.acctInfo("name") & " - Savings"
        Else
            strType = "CHECKING"
            Me.Text = "Account ID: " & frmKeypad.intPIN & "      Name: " & frmStartingScreen.acctInfo("name") & " - Checking"
        End If

        'Label Text
        If frmStartingScreen.blnWithDraw Then
            lblEnterType.Text = lblEnterType.Text & " Withdraw"
        Else
            lblEnterType.Text = lblEnterType.Text & " Deposit"
        End If

    End Sub

    'Getting Account Info
    Sub GetInfo()

        'Getting Account Info
        Dim accountArray As ArrayList = frmKeypad.strConn.GetShares()

        'Looping Through Account Info
        For intPos As Integer = 0 To accountArray.Count - 1

            'Getting Data Into String
            strInfo = DirectCast(accountArray(intPos), [String]())

            'Finding The Correct Info Line
            If strInfo(2) = strType Then
                dblAvailable = CDbl(strInfo(1))
                Exit For
            End If

        Next

    End Sub

    'Getting History Info
    Sub GetHistoryInfo()

        'Getting Account Info
        Dim accountArray As ArrayList = frmKeypad.strConn.GetShares()

        'Looping Through Account Info
        For intPos As Integer = 0 To accountArray.Count - 1

            'Getting Data Into String
            strInfo = DirectCast(accountArray(intPos), [String]())

            frmStats.lstOutput.Items.Add("Funds in " & strInfo(2).ToLower & ": " & FormatCurrency(strInfo(1)) & "!")

        Next

        For intSpot As Integer = 1 To 2

            'Getting The History
            accountArray = frmKeypad.strConn.GetTransactionHistory(intSpot)

            frmStats.lstOutput.Items.Add("")

            'Looping Through Account Info
            For intPos As Integer = 0 To accountArray.Count - 1

                'Getting Data Into String
                strInfo2 = DirectCast(accountArray(intPos), String)

                frmStats.lstOutput.Items.Add(strInfo2)

            Next

        Next
    End Sub

    'Resetting Data
    Sub Reset()

        strDeposit = Nothing
        strWithdraw = Nothing
        mtbInput.Clear()

    End Sub

End Class