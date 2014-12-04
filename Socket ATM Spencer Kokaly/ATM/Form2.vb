Public Class frmStartingScreen

    'Variable for Savings or Checking
    Public intChoice As Integer

    'Variable for Withdraw or Deposit
    Public blnWithDraw As Boolean

    'Variables for Closing Forms
    Public blnHistory As Boolean = False

    'Account Information
    Public acctInfo As Dictionary(Of String, String) = frmKeypad.strConn.GetAccountInformation()

    'Setting Title and Buttons
    Private Sub frmStartingScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting Title
        Me.Text = "Account ID: " & frmKeypad.intPIN & "      Name: " & acctInfo("name")

        'Setting Up Buttons
        ShowStartingButtons()

    End Sub

    'Closes Screen
    Private Sub emdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        'Hiding Screen and Resetting Keypad
        Me.Hide()
        frmKeypad.Show()
        frmKeypad.Reset()

    End Sub

    'Withdraw Stuff
    Private Sub cmdWithdraw_Click(sender As Object, e As EventArgs) Handles cmdWithdraw.Click

        'Setting Boolean
        blnWithDraw = True

        'Hiding Buttons
        HideStartingButtons()

    End Sub

    'Deposit Stuff
    Private Sub cmdDeposit_Click(sender As Object, e As EventArgs) Handles cmdDeposit.Click

        'Setting Boolean
        blnWithDraw = False

        'Hiding Buttons 
        HideStartingButtons()

    End Sub

    'Transaction History
    Private Sub cmdHistory_Click(sender As Object, e As EventArgs) Handles cmdHistory.Click

        'Setting Boolean and Opening Form
        blnHistory = True
        Me.Hide()
        frmStats.Show()
        frmStats.History()

    End Sub

    'Setting Up Savings Stuff
    Private Sub SavingsOrChecking(sender As Object, e As EventArgs) Handles cmdSavings.Click, cmdChecking.Click

        'Setting Up Choice
        intChoice = CType(sender, Button).Tag

        'Setting Up Forms
        Me.Hide()
        frmAccountKeypad.Show()

    End Sub

    'Hiding Starting Buttons
    Sub HideStartingButtons()

        'Hiding Buttons
        cmdWithdraw.Hide()
        cmdDeposit.Hide()
        cmdExit.Hide()
        cmdHistory.Hide()

        'Showing Buttons
        cmdSavings.Show()
        cmdChecking.Show()

    End Sub

    'Showing Starting Buttons
    Sub ShowStartingButtons()

        'Showing Buttons
        cmdWithdraw.Show()
        cmdDeposit.Show()
        cmdExit.Show()
        cmdHistory.Show()

        'Hiding Buttons
        cmdSavings.Hide()
        cmdChecking.Hide()

    End Sub

End Class