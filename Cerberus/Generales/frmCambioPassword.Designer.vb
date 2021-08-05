<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioPassword
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
        Me.txtPassword = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        Me.txtNewPassword = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.txtRepeatNewPassword = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Depth = 0
        Me.txtPassword.Hint = ""
        Me.txtPassword.Location = New System.Drawing.Point(182, 19)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPassword.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.SelectionLength = 0
        Me.txtPassword.SelectionStart = 0
        Me.txtPassword.Size = New System.Drawing.Size(269, 23)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(26, 19)
        Me.MaterialLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(144, 19)
        Me.MaterialLabel1.TabIndex = 4
        Me.MaterialLabel1.Text = "Contraseña Anterior"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel2.Location = New System.Drawing.Point(26, 67)
        Me.MaterialLabel2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(132, 19)
        Me.MaterialLabel2.TabIndex = 5
        Me.MaterialLabel2.Text = "Nueva Contraseña"
        '
        'MaterialLabel3
        '
        Me.MaterialLabel3.AutoSize = True
        Me.MaterialLabel3.Depth = 0
        Me.MaterialLabel3.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel3.Location = New System.Drawing.Point(26, 118)
        Me.MaterialLabel3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel3.Name = "MaterialLabel3"
        Me.MaterialLabel3.Size = New System.Drawing.Size(132, 19)
        Me.MaterialLabel3.TabIndex = 6
        Me.MaterialLabel3.Text = "Repite Contraseña"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Depth = 0
        Me.txtNewPassword.Hint = ""
        Me.txtNewPassword.Location = New System.Drawing.Point(182, 67)
        Me.txtNewPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtNewPassword.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNewPassword.SelectedText = ""
        Me.txtNewPassword.SelectionLength = 0
        Me.txtNewPassword.SelectionStart = 0
        Me.txtNewPassword.Size = New System.Drawing.Size(269, 23)
        Me.txtNewPassword.TabIndex = 7
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'txtRepeatNewPassword
        '
        Me.txtRepeatNewPassword.Depth = 0
        Me.txtRepeatNewPassword.Hint = ""
        Me.txtRepeatNewPassword.Location = New System.Drawing.Point(182, 115)
        Me.txtRepeatNewPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtRepeatNewPassword.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtRepeatNewPassword.Name = "txtRepeatNewPassword"
        Me.txtRepeatNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRepeatNewPassword.SelectedText = ""
        Me.txtRepeatNewPassword.SelectionLength = 0
        Me.txtRepeatNewPassword.SelectionStart = 0
        Me.txtRepeatNewPassword.Size = New System.Drawing.Size(269, 23)
        Me.txtRepeatNewPassword.TabIndex = 8
        Me.txtRepeatNewPassword.UseSystemPasswordChar = True
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(169, 158)
        Me.MaterialRaisedButton1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(177, 36)
        Me.MaterialRaisedButton1.TabIndex = 9
        Me.MaterialRaisedButton1.Text = "Guardar"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'frmCambioPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 210)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.txtRepeatNewPassword)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.MaterialLabel3)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.txtPassword)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximumSize = New System.Drawing.Size(509, 249)
        Me.MinimumSize = New System.Drawing.Size(509, 249)
        Me.Name = "frmCambioPassword"
        Me.ShowIcon = False
        Me.Text = "Cambiar Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents txtNewPassword As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents txtRepeatNewPassword As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
End Class
