<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarCuentas
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
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleadoCocina = New System.Windows.Forms.TextBox()
        Me.lblEmplCocina = New System.Windows.Forms.Label()
        Me.txtIDEmpleadoCocina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Items.AddRange(New Object() {"TODOS", "BORRADOR", "PENDIENTE DE AUTORIZAR", "COMPLETO", "CANCELADO"})
        Me.cbEstado.Location = New System.Drawing.Point(155, 21)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(323, 21)
        Me.cbEstado.TabIndex = 0
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Location = New System.Drawing.Point(484, 46)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(43, 23)
        Me.btnEmpleado.TabIndex = 34
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleadoCocina
        '
        Me.txtNombreEmpleadoCocina.Location = New System.Drawing.Point(212, 48)
        Me.txtNombreEmpleadoCocina.Name = "txtNombreEmpleadoCocina"
        Me.txtNombreEmpleadoCocina.ReadOnly = True
        Me.txtNombreEmpleadoCocina.Size = New System.Drawing.Size(266, 20)
        Me.txtNombreEmpleadoCocina.TabIndex = 33
        '
        'lblEmplCocina
        '
        Me.lblEmplCocina.AutoSize = True
        Me.lblEmplCocina.Location = New System.Drawing.Point(24, 51)
        Me.lblEmplCocina.Name = "lblEmplCocina"
        Me.lblEmplCocina.Size = New System.Drawing.Size(84, 13)
        Me.lblEmplCocina.TabIndex = 31
        Me.lblEmplCocina.Text = "Empleado (PIN):"
        '
        'txtIDEmpleadoCocina
        '
        Me.txtIDEmpleadoCocina.Location = New System.Drawing.Point(155, 48)
        Me.txtIDEmpleadoCocina.Name = "txtIDEmpleadoCocina"
        Me.txtIDEmpleadoCocina.ReadOnly = True
        Me.txtIDEmpleadoCocina.Size = New System.Drawing.Size(51, 20)
        Me.txtIDEmpleadoCocina.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Estado:"
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(155, 74)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(323, 21)
        Me.cbPeriodo.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Periodo:"
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(337, 110)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 23)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(190, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 23)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBuscarCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 149)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEmpleado)
        Me.Controls.Add(Me.txtNombreEmpleadoCocina)
        Me.Controls.Add(Me.lblEmplCocina)
        Me.Controls.Add(Me.txtIDEmpleadoCocina)
        Me.Controls.Add(Me.cbEstado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(558, 188)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(558, 188)
        Me.Name = "frmBuscarCuentas"
        Me.Text = "..:: Buscar Cuentas ::.."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbEstado As ComboBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents txtNombreEmpleadoCocina As TextBox
    Friend WithEvents lblEmplCocina As Label
    Friend WithEvents txtIDEmpleadoCocina As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
End Class
