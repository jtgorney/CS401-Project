Public Class frmStats

    'Exiting Form
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        Me.Dispose()

        'Choosing Which Screen To Show
        If frmStartingScreen.blnHistory Then
            frmStartingScreen.blnHistory = False
            frmStartingScreen.Show()
        Else
            frmAccountKeypad.Show()
        End If


    End Sub

    'Prints Invalid Funds
    Sub InvalidFunds()

        PrintHeader()
        lstOutput.Items.Add("Not enough funds to withdraw " & FormatCurrency(frmAccountKeypad.dblWithdraw) & " from " & frmAccountKeypad.strType.ToLower & "!")
        lstOutput.Items.Add("Current funds in " & frmAccountKeypad.strType.ToLower & ": " & FormatCurrency(frmAccountKeypad.dblAvailable) & "!")

    End Sub

    'Prints Withdraw Stats
    Sub Withdraw()

        PrintHeader()
        lstOutput.Items.Add("The amount of " & FormatCurrency(frmAccountKeypad.dblWithdraw) & " was withdrawn from " & frmAccountKeypad.strType.ToLower & "!")
        lstOutput.Items.Add("Old funds in " & frmAccountKeypad.strType.ToLower & ": " & FormatCurrency(frmAccountKeypad.dblAvailable) & "!")
        lstOutput.Items.Add("New funds in " & frmAccountKeypad.strType.ToLower & ": " & FormatCurrency(frmAccountKeypad.dblAvailable - frmAccountKeypad.dblWithdraw) & "!")

    End Sub

    'Prints Deposit Stats
    Sub Deposit()

        PrintHeader()
        lstOutput.Items.Add("The amount of " & FormatCurrency(frmAccountKeypad.dblDeposit) & " was deposited into " & frmAccountKeypad.strType.ToLower & "!")
        lstOutput.Items.Add("Old funds in " & frmAccountKeypad.strType.ToLower & ": " & FormatCurrency(frmAccountKeypad.dblAvailable) & "!")
        lstOutput.Items.Add("New funds in " & frmAccountKeypad.strType.ToLower & ": " & FormatCurrency(frmAccountKeypad.dblAvailable + frmAccountKeypad.dblDeposit) & "!")

    End Sub

    'Printing Deposit Error
    Sub DepositError()

        PrintHeader()
        lstOutput.Items.Add("There was an error when processing your deposit!")
        lstOutput.Items.Add("Please try again!")

    End Sub

    'Printing Withdraw Error
    Sub WithdrawError()

        PrintHeader()
        lstOutput.Items.Add("There was an error when processing your withdraw!")
        lstOutput.Items.Add("Please try again!")

    End Sub

    'Transaction History
    Sub History()

        PrintHeader()
        frmAccountKeypad.GetHistoryInfo()

    End Sub

    'Prints Header of Output
    Sub PrintHeader()

        lstOutput.Items.Clear()
        lstOutput.Items.Add("Account ID: " & frmKeypad.intPIN)
        lstOutput.Items.Add("Name: " & frmStartingScreen.acctInfo("name"))
        lstOutput.Items.Add("Address: " & frmStartingScreen.acctInfo("address"))
        lstOutput.Items.Add("Phone: " & frmStartingScreen.acctInfo("phone"))
        lstOutput.Items.Add("Email: " & frmStartingScreen.acctInfo("email"))
        lstOutput.Items.Add("")

    End Sub

End Class