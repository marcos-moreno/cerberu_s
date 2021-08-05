<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarCompras
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.lblEmplCocina = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaMovcompra = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(432, 210)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(212, 35)
        Me.Button3.TabIndex = 49
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(162, 210)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 35)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(162, 106)
        Me.cbEstado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(482, 28)
        Me.cbEstado.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 109)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Estado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Sucursal:"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(162, 67)
        Me.txtDocumento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(482, 26)
        Me.txtDocumento.TabIndex = 43
        '
        'lblEmplCocina
        '
        Me.lblEmplCocina.AutoSize = True
        Me.lblEmplCocina.Location = New System.Drawing.Point(13, 67)
        Me.lblEmplCocina.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmplCocina.Name = "lblEmplCocina"
        Me.lblEmplCocina.Size = New System.Drawing.Size(87, 20)
        Me.lblEmplCocina.TabIndex = 41
        Me.lblEmplCocina.Text = "Documeto:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Items.AddRange(New Object() {"TODOS", "BORRADOR", "PENDIENTE DE AUTORIZAR", "COMPLETO", "CANCELADO"})
        Me.cbSucursal.Location = New System.Drawing.Point(162, 26)
        Me.cbSucursal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(482, 28)
        Me.cbSucursal.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 156)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Fecha:"
        '
        'dtpFechaMovcompra
        '
        Me.dtpFechaMovcompra.Location = New System.Drawing.Point(162, 155)
        Me.dtpFechaMovcompra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaMovcompra.Name = "dtpFechaMovcompra"
        Me.dtpFechaMovcompra.Size = New System.Drawing.Size(482, 26)
        Me.dtpFechaMovcompra.TabIndex = 51
        '
        'frmBuscarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 267)
        Me.Controls.Add(Me.dtpFechaMovcompra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.lblEmplCocina)
        Me.Controls.Add(Me.cbSucursal)
        Me.Name = "frmBuscarCompras"
        Me.Text = "frmBuscarCompras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cbEstado As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents lblEmplCocina As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaMovcompra As DateTimePicker
End Class
