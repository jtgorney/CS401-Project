<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountKeypad
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
        Me.lblEnterType = New System.Windows.Forms.Label()
        Me.cmdEnter = New System.Windows.Forms.Button()
        Me.mtbInput = New System.Windows.Forms.MaskedTextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmd0 = New System.Windows.Forms.Button()
        Me.cmd9 = New System.Windows.Forms.Button()
        Me.cmd2 = New System.Windows.Forms.Button()
        Me.cmd3 = New System.Windows.Forms.Button()
        Me.cmd4 = New System.Windows.Forms.Button()
        Me.cmd5 = New System.Windows.Forms.Button()
        Me.cmd6 = New System.Windows.Forms.Button()
        Me.cmd7 = New System.Windows.Forms.Button()
        Me.cmd8 = New System.Windows.Forms.Button()
        Me.cmd1 = New System.Windows.Forms.Button()
        Me.cmdDot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblEnterType
        '
        Me.lblEnterType.AutoSize = True
        Me.lblEnterType.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterType.Location = New System.Drawing.Point(12, 25)
        Me.lblEnterType.Name = "lblEnterType"
        Me.lblEnterType.Size = New System.Drawing.Size(282, 31)
        Me.lblEnterType.TabIndex = 30
        Me.lblEnterType.Text = "Enter Your Amount To"
        '
        'cmdEnter
        '
        Me.cmdEnter.BackColor = System.Drawing.Color.Green
        Me.cmdEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(423, 367)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(221, 96)
        Me.cmdEnter.TabIndex = 29
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = False
        '
        'mtbInput
        '
        Me.mtbInput.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbInput.Location = New System.Drawing.Point(12, 62)
        Me.mtbInput.Name = "mtbInput"
        Me.mtbInput.ReadOnly = True
        Me.mtbInput.Size = New System.Drawing.Size(379, 47)
        Me.mtbInput.TabIndex = 28
        Me.mtbInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.Yellow
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(423, 250)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(221, 96)
        Me.cmdClear.TabIndex = 27
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.Red
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(423, 131)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(221, 96)
        Me.cmdCancel.TabIndex = 26
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmd0
        '
        Me.cmd0.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd0.Location = New System.Drawing.Point(148, 484)
        Me.cmd0.Name = "cmd0"
        Me.cmd0.Size = New System.Drawing.Size(105, 96)
        Me.cmd0.TabIndex = 25
        Me.cmd0.Tag = "0"
        Me.cmd0.Text = "0"
        Me.cmd0.UseVisualStyleBackColor = True
        '
        'cmd9
        '
        Me.cmd9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd9.Location = New System.Drawing.Point(286, 367)
        Me.cmd9.Name = "cmd9"
        Me.cmd9.Size = New System.Drawing.Size(105, 96)
        Me.cmd9.TabIndex = 24
        Me.cmd9.Tag = "9"
        Me.cmd9.Text = "9"
        Me.cmd9.UseVisualStyleBackColor = True
        '
        'cmd2
        '
        Me.cmd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd2.Location = New System.Drawing.Point(148, 131)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(105, 96)
        Me.cmd2.TabIndex = 23
        Me.cmd2.Tag = "2"
        Me.cmd2.Text = "2"
        Me.cmd2.UseVisualStyleBackColor = True
        '
        'cmd3
        '
        Me.cmd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd3.Location = New System.Drawing.Point(286, 131)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(105, 96)
        Me.cmd3.TabIndex = 22
        Me.cmd3.Tag = "3"
        Me.cmd3.Text = "3"
        Me.cmd3.UseVisualStyleBackColor = True
        '
        'cmd4
        '
        Me.cmd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd4.Location = New System.Drawing.Point(12, 250)
        Me.cmd4.Name = "cmd4"
        Me.cmd4.Size = New System.Drawing.Size(105, 96)
        Me.cmd4.TabIndex = 21
        Me.cmd4.Tag = "4"
        Me.cmd4.Text = "4"
        Me.cmd4.UseVisualStyleBackColor = True
        '
        'cmd5
        '
        Me.cmd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd5.Location = New System.Drawing.Point(148, 250)
        Me.cmd5.Name = "cmd5"
        Me.cmd5.Size = New System.Drawing.Size(105, 96)
        Me.cmd5.TabIndex = 20
        Me.cmd5.Tag = "5"
        Me.cmd5.Text = "5"
        Me.cmd5.UseVisualStyleBackColor = True
        '
        'cmd6
        '
        Me.cmd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd6.Location = New System.Drawing.Point(286, 250)
        Me.cmd6.Name = "cmd6"
        Me.cmd6.Size = New System.Drawing.Size(105, 96)
        Me.cmd6.TabIndex = 19
        Me.cmd6.Tag = "6"
        Me.cmd6.Text = "6"
        Me.cmd6.UseVisualStyleBackColor = True
        '
        'cmd7
        '
        Me.cmd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd7.Location = New System.Drawing.Point(12, 367)
        Me.cmd7.Name = "cmd7"
        Me.cmd7.Size = New System.Drawing.Size(105, 96)
        Me.cmd7.TabIndex = 18
        Me.cmd7.Tag = "7"
        Me.cmd7.Text = "7"
        Me.cmd7.UseVisualStyleBackColor = True
        '
        'cmd8
        '
        Me.cmd8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd8.Location = New System.Drawing.Point(148, 367)
        Me.cmd8.Name = "cmd8"
        Me.cmd8.Size = New System.Drawing.Size(105, 96)
        Me.cmd8.TabIndex = 17
        Me.cmd8.Tag = "8"
        Me.cmd8.Text = "8"
        Me.cmd8.UseVisualStyleBackColor = True
        '
        'cmd1
        '
        Me.cmd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd1.Location = New System.Drawing.Point(12, 131)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(105, 96)
        Me.cmd1.TabIndex = 16
        Me.cmd1.Tag = "1"
        Me.cmd1.Text = "1"
        Me.cmd1.UseVisualStyleBackColor = True
        '
        'cmdDot
        '
        Me.cmdDot.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDot.Location = New System.Drawing.Point(286, 484)
        Me.cmdDot.Name = "cmdDot"
        Me.cmdDot.Size = New System.Drawing.Size(105, 96)
        Me.cmdDot.TabIndex = 31
        Me.cmdDot.Tag = "."
        Me.cmdDot.Text = "."
        Me.cmdDot.UseVisualStyleBackColor = True
        '
        'frmAccountKeypad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(657, 588)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdDot)
        Me.Controls.Add(Me.lblEnterType)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.mtbInput)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmd0)
        Me.Controls.Add(Me.cmd9)
        Me.Controls.Add(Me.cmd2)
        Me.Controls.Add(Me.cmd3)
        Me.Controls.Add(Me.cmd4)
        Me.Controls.Add(Me.cmd5)
        Me.Controls.Add(Me.cmd6)
        Me.Controls.Add(Me.cmd7)
        Me.Controls.Add(Me.cmd8)
        Me.Controls.Add(Me.cmd1)
        Me.Name = "frmAccountKeypad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Keypad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEnterType As System.Windows.Forms.Label
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents mtbInput As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmd0 As System.Windows.Forms.Button
    Friend WithEvents cmd9 As System.Windows.Forms.Button
    Friend WithEvents cmd2 As System.Windows.Forms.Button
    Friend WithEvents cmd3 As System.Windows.Forms.Button
    Friend WithEvents cmd4 As System.Windows.Forms.Button
    Friend WithEvents cmd5 As System.Windows.Forms.Button
    Friend WithEvents cmd6 As System.Windows.Forms.Button
    Friend WithEvents cmd7 As System.Windows.Forms.Button
    Friend WithEvents cmd8 As System.Windows.Forms.Button
    Friend WithEvents cmd1 As System.Windows.Forms.Button
    Friend WithEvents cmdDot As System.Windows.Forms.Button
End Class
