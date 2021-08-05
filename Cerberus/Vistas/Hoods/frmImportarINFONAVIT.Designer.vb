<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarINFONAVIT
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbRegPatronal = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRango = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHoja = New System.Windows.Forms.TextBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.buscarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "MM/yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(123, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 102
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Periodo / Ejercicio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Registro Patronal:"
        '
        'cbRegPatronal
        '
        Me.cbRegPatronal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegPatronal.FormattingEnabled = True
        Me.cbRegPatronal.Location = New System.Drawing.Point(123, 38)
        Me.cbRegPatronal.Name = "cbRegPatronal"
        Me.cbRegPatronal.Size = New System.Drawing.Size(337, 21)
        Me.cbRegPatronal.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Rango:"
        '
        'txtRango
        '
        Me.txtRango.Location = New System.Drawing.Point(278, 68)
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(99, 20)
        Me.txtRango.TabIndex = 97
        Me.txtRango.Text = "A5:R200"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Hoja EXCEL:"
        '
        'txtHoja
        '
        Me.txtHoja.Location = New System.Drawing.Point(119, 68)
        Me.txtHoja.Name = "txtHoja"
        Me.txtHoja.Size = New System.Drawing.Size(99, 20)
        Me.txtHoja.TabIndex = 95
        Me.txtHoja.Text = "Hoja2"
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(441, 139)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 94
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(466, 98)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 23)
        Me.btnBuscar.TabIndex = 93
        Me.btnBuscar.Text = "..."
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Archivo:"
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Location = New System.Drawing.Point(62, 100)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.ReadOnly = True
        Me.txtRutaArchivo.Size = New System.Drawing.Size(398, 20)
        Me.txtRutaArchivo.TabIndex = 91
        '
        'frmImportarINFONAVIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 177)
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
        Me.Name = "frmImportarINFONAVIT"
        Me.Text = "frmImportarINFONAVIT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbRegPatronal As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRango As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHoja As TextBox
    Friend WithEvents btnImportar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRutaArchivo As TextBox
    Friend WithEvents buscarArchivo As OpenFileDialog
End Class
