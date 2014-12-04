<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartingScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdWithdraw = New System.Windows.Forms.Button()
        Me.cmdDeposit = New System.Windows.Forms.Button()
        Me.cmdHistory = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdSavings = New System.Windows.Forms.Button()
        Me.cmdChecking = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdWithdraw
        '
        Me.cmdWithdraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWithdraw.Location = New System.Drawing.Point(214, 12)
        Me.cmdWithdraw.Name = "cmdWithdraw"
        Me.cmdWithdraw.Size = New System.Drawing.Size(230, 101)
        Me.cmdWithdraw.TabIndex = 0
        Me.cmdWithdraw.Text = "Withdraw"
        Me.cmdWithdraw.UseVisualStyleBackColor = True
        '
        'cmdDeposit
        '
        Me.cmdDeposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeposit.Location = New System.Drawing.Point(214, 166)
        Me.cmdDeposit.Name = "cmdDeposit"
        Me.cmdDeposit.Size = New System.Drawing.Size(230, 101)
        Me.cmdDeposit.TabIndex = 1
        Me.cmdDeposit.Text = "Deposit"
        Me.cmdDeposit.UseVisualStyleBackColor = True
        '
        'cmdHistory
        '
        Me.cmdHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHistory.Location = New System.Drawing.Point(214, 340)
        Me.cmdHistory.Name = "cmdHistory"
        Me.cmdHistory.Size = New System.Drawing.Size(230, 101)
        Me.cmdHistory.TabIndex = 2
        Me.cmdHistory.Text = "Transaction History"
        Me.cmdHistory.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(214, 495)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(230, 101)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSavings
        '
        Me.cmdSavings.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSavings.Location = New System.Drawing.Point(12, 252)
        Me.cmdSavings.Name = "cmdSavings"
        Me.cmdSavings.Size = New System.Drawing.Size(230, 101)
        Me.cmdSavings.TabIndex = 4
        Me.cmdSavings.Tag = "1"
        Me.cmdSavings.Text = "Savings"
        Me.cmdSavings.UseVisualStyleBackColor = True
        '
        'cmdChecking
        '
        Me.cmdChecking.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChecking.Location = New System.Drawing.Point(416, 252)
        Me.cmdChecking.Name = "cmdChecking"
        Me.cmdChecking.Size = New System.Drawing.Size(230, 101)
        Me.cmdChecking.TabIndex = 5
        Me.cmdChecking.Tag = "2"
        Me.cmdChecking.Text = "Checking"
        Me.cmdChecking.UseVisualStyleBackColor = True
        '
        'frmStartingScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(658, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdChecking)
        Me.Controls.Add(Me.cmdSavings)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdHistory)
        Me.Controls.Add(Me.cmdDeposit)
        Me.Controls.Add(Me.cmdWithdraw)
        Me.Name = "frmStartingScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdWithdraw As System.Windows.Forms.Button
    Friend WithEvents cmdDeposit As System.Windows.Forms.Button
    Friend WithEvents cmdHistory As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSavings As System.Windows.Forms.Button
    Friend WithEvents cmdChecking As System.Windows.Forms.Button
End Class
