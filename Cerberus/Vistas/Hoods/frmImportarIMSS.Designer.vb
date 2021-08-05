<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarIMSS
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRango = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHoja = New System.Windows.Forms.TextBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.cbRegPatronal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.buscarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(236, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Rango:"
        '
        'txtRango
        '
        Me.txtRango.Location = New System.Drawing.Point(284, 75)
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(99, 20)
        Me.txtRango.TabIndex = 84
        Me.txtRango.Text = "A5:S200"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Hoja EXCEL:"
        '
        'txtHoja
        '
        Me.txtHoja.Location = New System.Drawing.Point(125, 75)
        Me.txtHoja.Name = "txtHoja"
        Me.txtHoja.Size = New System.Drawing.Size(99, 20)
        Me.txtHoja.TabIndex = 82
        Me.txtHoja.Text = "Hoja1"
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(447, 146)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 81
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(472, 105)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 23)
        Me.btnBuscar.TabIndex = 80
        Me.btnBuscar.Text = "..."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Archivo:"
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Location = New System.Drawing.Point(68, 107)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.ReadOnly = True
        Me.txtRutaArchivo.Size = New System.Drawing.Size(398, 20)
        Me.txtRutaArchivo.TabIndex = 78
        '
        'cbRegPatronal
        '
        Me.cbRegPatronal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegPatronal.FormattingEnabled = True
        Me.cbRegPatronal.Location = New System.Drawing.Point(129, 45)
        Me.cbRegPatronal.Name = "cbRegPatronal"
        Me.cbRegPatronal.Size = New System.Drawing.Size(337, 21)
        Me.cbRegPatronal.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Registro Patronal:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Periodo / Ejercicio:"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "MM/yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(129, 19)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 90
        '
        'frmImportarIMSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 182)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbRegPatronal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRango)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHoja)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Name = "frmImportarIMSS"
        Me.Text = "Importar Excel IMSS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents txtRango As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHoja As TextBox
    Friend WithEvents btnImportar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRutaArchivo As TextBox
    Friend WithEvents cbRegPatronal As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents buscarArchivo As OpenFileDialog
End Class
