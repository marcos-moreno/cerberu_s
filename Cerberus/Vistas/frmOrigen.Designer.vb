<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrigen
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtElemento = New System.Windows.Forms.TextBox()
        Me.txtNombreBD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbTipoBD = New System.Windows.Forms.ComboBox()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEsquema = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInstancia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDireccionIP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chbEsActivo = New System.Windows.Forms.CheckBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Elemento:"
        '
        'txtElemento
        '
        Me.txtElemento.Location = New System.Drawing.Point(12, 30)
        Me.txtElemento.Name = "txtElemento"
        Me.txtElemento.ReadOnly = True
        Me.txtElemento.Size = New System.Drawing.Size(201, 20)
        Me.txtElemento.TabIndex = 1
        '
        'txtNombreBD
        '
        Me.txtNombreBD.Location = New System.Drawing.Point(12, 79)
        Me.txtNombreBD.Name = "txtNombreBD"
        Me.txtNombreBD.Size = New System.Drawing.Size(201, 20)
        Me.txtNombreBD.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre DB:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(12, 123)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(201, 20)
        Me.txtUsuario.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Usuario:"
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(12, 167)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(201, 20)
        Me.txtContrasena.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Contraseña:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo BD"
        '
        'cbTipoBD
        '
        Me.cbTipoBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBD.FormattingEnabled = True
        Me.cbTipoBD.Items.AddRange(New Object() {"SQL", "MySQL", "PostgreSQL"})
        Me.cbTipoBD.Location = New System.Drawing.Point(12, 213)
        Me.cbTipoBD.Name = "cbTipoBD"
        Me.cbTipoBD.Size = New System.Drawing.Size(198, 21)
        Me.cbTipoBD.TabIndex = 9
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(260, 78)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(166, 20)
        Me.txtPuerto.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Puerto:"
        '
        'txtEsquema
        '
        Me.txtEsquema.Location = New System.Drawing.Point(260, 122)
        Me.txtEsquema.Name = "txtEsquema"
        Me.txtEsquema.Size = New System.Drawing.Size(166, 20)
        Me.txtEsquema.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(260, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Esquema:"
        '
        'txtInstancia
        '
        Me.txtInstancia.Location = New System.Drawing.Point(260, 166)
        Me.txtInstancia.Name = "txtInstancia"
        Me.txtInstancia.Size = New System.Drawing.Size(166, 20)
        Me.txtInstancia.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(260, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Instancia:"
        '
        'txtDireccionIP
        '
        Me.txtDireccionIP.Location = New System.Drawing.Point(260, 213)
        Me.txtDireccionIP.Name = "txtDireccionIP"
        Me.txtDireccionIP.Size = New System.Drawing.Size(166, 20)
        Me.txtDireccionIP.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Direccion IP:"
        '
        'chbEsActivo
        '
        Me.chbEsActivo.AutoSize = True
        Me.chbEsActivo.Location = New System.Drawing.Point(464, 32)
        Me.chbEsActivo.Name = "chbEsActivo"
        Me.chbEsActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbEsActivo.TabIndex = 18
        Me.chbEsActivo.Text = "Activo"
        Me.chbEsActivo.UseVisualStyleBackColor = True
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(260, 29)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(166, 20)
        Me.txtOrigen.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(260, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Origen:"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(464, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Actualizar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmOrigen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 250)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chbEsActivo)
        Me.Controls.Add(Me.txtDireccionIP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtInstancia)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEsquema)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbTipoBD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombreBD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtElemento)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmOrigen"
        Me.Text = "..:: Origen ::.."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtElemento As TextBox
    Friend WithEvents txtNombreBD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbTipoBD As ComboBox
    Friend WithEvents txtPuerto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEsquema As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInstancia As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDireccionIP As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chbEsActivo As CheckBox
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button1 As Button
End Class
