<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargoAbonoPrestamo
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIDPrestamo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImpRecibo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModRecibo = New System.Windows.Forms.ToolStripMenuItem()
        Me.rbtnCargo = New System.Windows.Forms.RadioButton()
        Me.rbtnAbono = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaCargoAbono = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.RichTextBox()
        Me.txtIDConcepto = New System.Windows.Forms.TextBox()
        Me.txtDescripConcepto = New System.Windows.Forms.TextBox()
        Me.btnBuscaConcepto = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Prestamo Num:"
        '
        'txtIDPrestamo
        '
        Me.txtIDPrestamo.Location = New System.Drawing.Point(154, 47)
        Me.txtIDPrestamo.Name = "txtIDPrestamo"
        Me.txtIDPrestamo.ReadOnly = True
        Me.txtIDPrestamo.Size = New System.Drawing.Size(112, 20)
        Me.txtIDPrestamo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(154, 122)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(200, 20)
        Me.txtCantidad.TabIndex = 11
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.CancelarToolStripMenuItem, Me.btnComentarios, Me.btnAdjuntos, Me.btnReportes})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(710, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.btnGuardar.Text = "Guardar"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(87, 20)
        Me.btnComentarios.Text = "Comentarios"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImpRecibo, Me.btnModRecibo})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(65, 20)
        Me.btnReportes.Text = "Reportes"
        '
        'btnImpRecibo
        '
        Me.btnImpRecibo.Name = "btnImpRecibo"
        Me.btnImpRecibo.Size = New System.Drawing.Size(152, 22)
        Me.btnImpRecibo.Text = "Imprimir"
        '
        'btnModRecibo
        '
        Me.btnModRecibo.Name = "btnModRecibo"
        Me.btnModRecibo.Size = New System.Drawing.Size(152, 22)
        Me.btnModRecibo.Text = "Modificar"
        '
        'rbtnCargo
        '
        Me.rbtnCargo.AutoSize = True
        Me.rbtnCargo.Checked = True
        Me.rbtnCargo.Location = New System.Drawing.Point(154, 73)
        Me.rbtnCargo.Name = "rbtnCargo"
        Me.rbtnCargo.Size = New System.Drawing.Size(53, 17)
        Me.rbtnCargo.TabIndex = 14
        Me.rbtnCargo.TabStop = True
        Me.rbtnCargo.Text = "Cargo"
        Me.rbtnCargo.UseVisualStyleBackColor = True
        '
        'rbtnAbono
        '
        Me.rbtnAbono.AutoSize = True
        Me.rbtnAbono.Location = New System.Drawing.Point(154, 96)
        Me.rbtnAbono.Name = "rbtnAbono"
        Me.rbtnAbono.Size = New System.Drawing.Size(56, 17)
        Me.rbtnAbono.TabIndex = 15
        Me.rbtnAbono.Text = "Abono"
        Me.rbtnAbono.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha de Cargo / Abono:"
        '
        'dtpFechaCargoAbono
        '
        Me.dtpFechaCargoAbono.Location = New System.Drawing.Point(154, 174)
        Me.dtpFechaCargoAbono.Name = "dtpFechaCargoAbono"
        Me.dtpFechaCargoAbono.Size = New System.Drawing.Size(259, 20)
        Me.dtpFechaCargoAbono.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Referencia:"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(154, 200)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(200, 20)
        Me.txtReferencia.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(385, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Observaciones:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(487, 73)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(211, 121)
        Me.txtObservaciones.TabIndex = 22
        Me.txtObservaciones.Text = ""
        '
        'txtIDConcepto
        '
        Me.txtIDConcepto.Location = New System.Drawing.Point(154, 148)
        Me.txtIDConcepto.Name = "txtIDConcepto"
        Me.txtIDConcepto.ReadOnly = True
        Me.txtIDConcepto.Size = New System.Drawing.Size(43, 20)
        Me.txtIDConcepto.TabIndex = 23
        '
        'txtDescripConcepto
        '
        Me.txtDescripConcepto.Location = New System.Drawing.Point(203, 148)
        Me.txtDescripConcepto.Name = "txtDescripConcepto"
        Me.txtDescripConcepto.ReadOnly = True
        Me.txtDescripConcepto.Size = New System.Drawing.Size(210, 20)
        Me.txtDescripConcepto.TabIndex = 24
        '
        'btnBuscaConcepto
        '
        Me.btnBuscaConcepto.Location = New System.Drawing.Point(419, 146)
        Me.btnBuscaConcepto.Name = "btnBuscaConcepto"
        Me.btnBuscaConcepto.Size = New System.Drawing.Size(28, 23)
        Me.btnBuscaConcepto.TabIndex = 25
        Me.btnBuscaConcepto.Text = "..."
        Me.btnBuscaConcepto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Concepto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(385, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Estado:"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(487, 43)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(143, 20)
        Me.txtEstado.TabIndex = 27
        '
        'frmCargoAbonoPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 245)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBuscaConcepto)
        Me.Controls.Add(Me.txtDescripConcepto)
        Me.Controls.Add(Me.txtIDConcepto)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFechaCargoAbono)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rbtnAbono)
        Me.Controls.Add(Me.rbtnCargo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIDPrestamo)
        Me.Name = "frmCargoAbonoPrestamo"
        Me.Text = "Cargo / Abono"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents txtIDPrestamo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents btnImpRecibo As ToolStripMenuItem
    Friend WithEvents btnModRecibo As ToolStripMenuItem
    Friend WithEvents rbtnCargo As RadioButton
    Friend WithEvents rbtnAbono As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaCargoAbono As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtObservaciones As RichTextBox
    Friend WithEvents txtIDConcepto As TextBox
    Friend WithEvents txtDescripConcepto As TextBox
    Friend WithEvents btnBuscaConcepto As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents CancelarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEstado As TextBox
End Class
