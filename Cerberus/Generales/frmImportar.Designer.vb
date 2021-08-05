<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbFormatoImp = New System.Windows.Forms.ComboBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.buscarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHoja = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRango = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Archivo:"
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Location = New System.Drawing.Point(64, 81)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.ReadOnly = True
        Me.txtRutaArchivo.Size = New System.Drawing.Size(398, 20)
        Me.txtRutaArchivo.TabIndex = 2
        '
        'btnBuscar
        '
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.Location = New System.Drawing.Point(468, 78)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "..."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Formato Importación:"
        '
        'cbFormatoImp
        '
        Me.cbFormatoImp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormatoImp.FormattingEnabled = True
        Me.cbFormatoImp.Location = New System.Drawing.Point(130, 15)
        Me.cbFormatoImp.Name = "cbFormatoImp"
        Me.cbFormatoImp.Size = New System.Drawing.Size(332, 21)
        Me.cbFormatoImp.TabIndex = 70
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(443, 119)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 72
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnDetalle
        '
        Me.btnDetalle.Enabled = False
        Me.btnDetalle.Location = New System.Drawing.Point(468, 13)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(50, 23)
        Me.btnDetalle.TabIndex = 73
        Me.btnDetalle.Text = "..."
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Hoja EXCEL:"
        '
        'txtHoja
        '
        Me.txtHoja.Location = New System.Drawing.Point(87, 49)
        Me.txtHoja.Name = "txtHoja"
        Me.txtHoja.Size = New System.Drawing.Size(99, 20)
        Me.txtHoja.TabIndex = 74
        Me.txtHoja.Text = "Hoja1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Rango:"
        '
        'txtRango
        '
        Me.txtRango.Location = New System.Drawing.Point(252, 49)
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(99, 20)
        Me.txtRango.TabIndex = 76
        Me.txtRango.Text = "A1:O4"
        '
        'frmImportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 154)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRango)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHoja)
        Me.Controls.Add(Me.btnDetalle)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbFormatoImp)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Name = "frmImportar"
        Me.Text = "..:: Importación ::.."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRutaArchivo As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cbFormatoImp As ComboBox
    Friend WithEvents btnImportar As Button
    Friend WithEvents buscarArchivo As OpenFileDialog
    Friend WithEvents btnDetalle As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHoja As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRango As TextBox
End Class
