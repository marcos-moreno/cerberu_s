<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlVacaciones
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbConcepto = New System.Windows.Forms.RichTextBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.lblEmplCocina = New System.Windows.Forms.Label()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.txtDiasMovimiento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasActuales = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Concepto:"
        '
        'rtbConcepto
        '
        Me.rtbConcepto.Location = New System.Drawing.Point(121, 71)
        Me.rtbConcepto.Name = "rtbConcepto"
        Me.rtbConcepto.Size = New System.Drawing.Size(305, 50)
        Me.rtbConcepto.TabIndex = 4
        Me.rtbConcepto.Text = ""
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Location = New System.Drawing.Point(470, 17)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(43, 23)
        Me.btnEmpleado.TabIndex = 34
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(178, 19)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(280, 20)
        Me.txtNombreEmpleado.TabIndex = 33
        '
        'lblEmplCocina
        '
        Me.lblEmplCocina.AutoSize = True
        Me.lblEmplCocina.Location = New System.Drawing.Point(12, 22)
        Me.lblEmplCocina.Name = "lblEmplCocina"
        Me.lblEmplCocina.Size = New System.Drawing.Size(84, 13)
        Me.lblEmplCocina.TabIndex = 31
        Me.lblEmplCocina.Text = "Empleado (PIN):"
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(121, 19)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(51, 20)
        Me.txtIDEmpleado.TabIndex = 32
        '
        'txtDiasMovimiento
        '
        Me.txtDiasMovimiento.Location = New System.Drawing.Point(374, 45)
        Me.txtDiasMovimiento.Name = "txtDiasMovimiento"
        Me.txtDiasMovimiento.Size = New System.Drawing.Size(136, 20)
        Me.txtDiasMovimiento.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(270, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Número de Días:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(438, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(438, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Dias Disponibles:"
        '
        'txtDiasActuales
        '
        Me.txtDiasActuales.Location = New System.Drawing.Point(121, 45)
        Me.txtDiasActuales.Name = "txtDiasActuales"
        Me.txtDiasActuales.ReadOnly = True
        Me.txtDiasActuales.Size = New System.Drawing.Size(143, 20)
        Me.txtDiasActuales.TabIndex = 39
        '
        'frmControlVacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 138)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDiasActuales)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDiasMovimiento)
        Me.Controls.Add(Me.btnEmpleado)
        Me.Controls.Add(Me.txtNombreEmpleado)
        Me.Controls.Add(Me.lblEmplCocina)
        Me.Controls.Add(Me.txtIDEmpleado)
        Me.Controls.Add(Me.rtbConcepto)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmControlVacaciones"
        Me.Text = "..:: Entrada de Vacaciones ::.."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents rtbConcepto As RichTextBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents lblEmplCocina As Label
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents txtDiasMovimiento As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDiasActuales As TextBox
End Class
