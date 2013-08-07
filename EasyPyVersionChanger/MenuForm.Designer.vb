<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.AddButton = New System.Windows.Forms.Button()
        Me.SystemPathCheckList = New System.Windows.Forms.CheckedListBox()
        Me.PythonCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'AddButton
        '
        Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddButton.Location = New System.Drawing.Point(385, 230)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(75, 23)
        Me.AddButton.TabIndex = 0
        Me.AddButton.Text = "Add"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'SystemPathCheckList
        '
        Me.SystemPathCheckList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SystemPathCheckList.CheckOnClick = True
        Me.SystemPathCheckList.FormattingEnabled = True
        Me.SystemPathCheckList.Location = New System.Drawing.Point(12, 12)
        Me.SystemPathCheckList.Name = "SystemPathCheckList"
        Me.SystemPathCheckList.Size = New System.Drawing.Size(448, 199)
        Me.SystemPathCheckList.TabIndex = 1
        '
        'PythonCheckBox
        '
        Me.PythonCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PythonCheckBox.AutoSize = True
        Me.PythonCheckBox.Checked = True
        Me.PythonCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PythonCheckBox.Location = New System.Drawing.Point(12, 236)
        Me.PythonCheckBox.Name = "PythonCheckBox"
        Me.PythonCheckBox.Size = New System.Drawing.Size(83, 17)
        Me.PythonCheckBox.TabIndex = 2
        Me.PythonCheckBox.Text = "Python Only"
        Me.PythonCheckBox.UseVisualStyleBackColor = True
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 265)
        Me.Controls.Add(Me.PythonCheckBox)
        Me.Controls.Add(Me.SystemPathCheckList)
        Me.Controls.Add(Me.AddButton)
        Me.Name = "MenuForm"
        Me.ShowIcon = False
        Me.Text = "Easy Python Version Switcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SystemPathCheckList As System.Windows.Forms.CheckedListBox
    Friend WithEvents PythonCheckBox As System.Windows.Forms.CheckBox

End Class
