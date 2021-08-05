<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRuta
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvRuta = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.RichTextBox()
        Me.GpEstado = New System.Windows.Forms.GroupBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtIdSucDest = New System.Windows.Forms.TextBox()
        Me.btnDestino = New System.Windows.Forms.Button()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtIdSucOrigen = New System.Windows.Forms.TextBox()
        Me.btnOrigen = New System.Windows.Forms.Button()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtCoordenadasDestino = New System.Windows.Forms.TextBox()
        Me.TxtCorrdenadasOrigen = New System.Windows.Forms.TextBox()
        Me.TxtKMRecorridos = New System.Windows.Forms.TextBox()
        Me.TxtNombreRuta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GbEmpleado = New System.Windows.Forms.GroupBox()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.TxtCuenta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Dtpegreso = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Salida = New System.Windows.Forms.Label()
        Me.DtpSalida = New System.Windows.Forms.DateTimePicker()
        Me.TxtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.TxtIdEmpleado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnEmpleado = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GpEstado.SuspendLayout()
        Me.GbEmpleado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnGuardar, Me.BtnEliminar, Me.BtnAdjuntos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1135, 24)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.BtnNuevo.Text = "Nuevo"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.BtnGuardar.Text = "Guardar"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.BtnEliminar.Text = "Eliminar"
        '
        'BtnAdjuntos
        '
        Me.BtnAdjuntos.Name = "BtnAdjuntos"
        Me.BtnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.BtnAdjuntos.Text = "Adjuntos"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1111, 486)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvRuta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1103, 320)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvRuta
        '
        Me.dgvRuta.AllowUserToAddRows = False
        Me.dgvRuta.AllowUserToDeleteRows = False
        Me.dgvRuta.AllowUserToResizeColumns = False
        Me.dgvRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRuta.Location = New System.Drawing.Point(6, 6)
        Me.dgvRuta.MultiSelect = False
        Me.dgvRuta.Name = "dgvRuta"
        Me.dgvRuta.ReadOnly = True
        Me.dgvRuta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRuta.Size = New System.Drawing.Size(1091, 308)
        Me.dgvRuta.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtComentario)
        Me.TabPage2.Controls.Add(Me.GpEstado)
        Me.TabPage2.Controls.Add(Me.GbEmpleado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1103, 460)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(737, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Comentarios: "
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(740, 80)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(354, 181)
        Me.txtComentario.TabIndex = 74
        Me.txtComentario.Text = ""
        '
        'GpEstado
        '
        Me.GpEstado.Controls.Add(Me.txtDestino)
        Me.GpEstado.Controls.Add(Me.txtIdSucDest)
        Me.GpEstado.Controls.Add(Me.btnDestino)
        Me.GpEstado.Controls.Add(Me.txtOrigen)
        Me.GpEstado.Controls.Add(Me.txtIdSucOrigen)
        Me.GpEstado.Controls.Add(Me.btnOrigen)
        Me.GpEstado.Controls.Add(Me.txtEstado)
        Me.GpEstado.Controls.Add(Me.Label16)
        Me.GpEstado.Controls.Add(Me.TxtCoordenadasDestino)
        Me.GpEstado.Controls.Add(Me.TxtCorrdenadasOrigen)
        Me.GpEstado.Controls.Add(Me.TxtKMRecorridos)
        Me.GpEstado.Controls.Add(Me.TxtNombreRuta)
        Me.GpEstado.Controls.Add(Me.Label4)
        Me.GpEstado.Controls.Add(Me.Label5)
        Me.GpEstado.Controls.Add(Me.Label6)
        Me.GpEstado.Controls.Add(Me.Label3)
        Me.GpEstado.Controls.Add(Me.Label2)
        Me.GpEstado.Controls.Add(Me.Label1)
        Me.GpEstado.Location = New System.Drawing.Point(17, 12)
        Me.GpEstado.Name = "GpEstado"
        Me.GpEstado.Size = New System.Drawing.Size(330, 422)
        Me.GpEstado.TabIndex = 73
        Me.GpEstado.TabStop = False
        Me.GpEstado.Text = "Estado"
        '
        'txtDestino
        '
        Me.txtDestino.Enabled = False
        Me.txtDestino.Location = New System.Drawing.Point(84, 204)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(175, 20)
        Me.txtDestino.TabIndex = 106
        '
        'txtIdSucDest
        '
        Me.txtIdSucDest.Enabled = False
        Me.txtIdSucDest.Location = New System.Drawing.Point(36, 202)
        Me.txtIdSucDest.Name = "txtIdSucDest"
        Me.txtIdSucDest.Size = New System.Drawing.Size(42, 20)
        Me.txtIdSucDest.TabIndex = 105
        '
        'btnDestino
        '
        Me.btnDestino.Location = New System.Drawing.Point(265, 201)
        Me.btnDestino.Name = "btnDestino"
        Me.btnDestino.Size = New System.Drawing.Size(32, 23)
        Me.btnDestino.TabIndex = 104
        Me.btnDestino.Text = "..."
        Me.btnDestino.UseVisualStyleBackColor = True
        '
        'txtOrigen
        '
        Me.txtOrigen.Enabled = False
        Me.txtOrigen.Location = New System.Drawing.Point(88, 145)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(171, 20)
        Me.txtOrigen.TabIndex = 103
        '
        'txtIdSucOrigen
        '
        Me.txtIdSucOrigen.Enabled = False
        Me.txtIdSucOrigen.Location = New System.Drawing.Point(36, 146)
        Me.txtIdSucOrigen.Name = "txtIdSucOrigen"
        Me.txtIdSucOrigen.Size = New System.Drawing.Size(42, 20)
        Me.txtIdSucOrigen.TabIndex = 102
        '
        'btnOrigen
        '
        Me.btnOrigen.Location = New System.Drawing.Point(265, 142)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(32, 23)
        Me.btnOrigen.TabIndex = 101
        Me.btnOrigen.Text = "..."
        Me.btnOrigen.UseVisualStyleBackColor = True
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(37, 37)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(260, 20)
        Me.txtEstado.TabIndex = 99
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(34, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(154, 13)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Estado del DOCUMENTO:"
        '
        'TxtCoordenadasDestino
        '
        Me.TxtCoordenadasDestino.Location = New System.Drawing.Point(37, 382)
        Me.TxtCoordenadasDestino.Name = "TxtCoordenadasDestino"
        Me.TxtCoordenadasDestino.Size = New System.Drawing.Size(260, 20)
        Me.TxtCoordenadasDestino.TabIndex = 98
        '
        'TxtCorrdenadasOrigen
        '
        Me.TxtCorrdenadasOrigen.Location = New System.Drawing.Point(37, 316)
        Me.TxtCorrdenadasOrigen.Name = "TxtCorrdenadasOrigen"
        Me.TxtCorrdenadasOrigen.Size = New System.Drawing.Size(260, 20)
        Me.TxtCorrdenadasOrigen.TabIndex = 97
        '
        'TxtKMRecorridos
        '
        Me.TxtKMRecorridos.Location = New System.Drawing.Point(37, 252)
        Me.TxtKMRecorridos.Name = "TxtKMRecorridos"
        Me.TxtKMRecorridos.Size = New System.Drawing.Size(260, 20)
        Me.TxtKMRecorridos.TabIndex = 96
        '
        'TxtNombreRuta
        '
        Me.TxtNombreRuta.Location = New System.Drawing.Point(37, 84)
        Me.TxtNombreRuta.Name = "TxtNombreRuta"
        Me.TxtNombreRuta.Size = New System.Drawing.Size(260, 20)
        Me.TxtNombreRuta.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 353)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 26)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Coordenadas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 26)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Coordenadas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Origen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 236)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Km. Recorridos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Destino"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Origen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Nombre"
        '
        'GbEmpleado
        '
        Me.GbEmpleado.Controls.Add(Me.TxtMonto)
        Me.GbEmpleado.Controls.Add(Me.TxtCuenta)
        Me.GbEmpleado.Controls.Add(Me.Label9)
        Me.GbEmpleado.Controls.Add(Me.Dtpegreso)
        Me.GbEmpleado.Controls.Add(Me.Label8)
        Me.GbEmpleado.Controls.Add(Me.Salida)
        Me.GbEmpleado.Controls.Add(Me.DtpSalida)
        Me.GbEmpleado.Controls.Add(Me.TxtNombreEmpleado)
        Me.GbEmpleado.Controls.Add(Me.TxtIdEmpleado)
        Me.GbEmpleado.Controls.Add(Me.Label7)
        Me.GbEmpleado.Controls.Add(Me.BtnEmpleado)
        Me.GbEmpleado.Location = New System.Drawing.Point(377, 12)
        Me.GbEmpleado.Name = "GbEmpleado"
        Me.GbEmpleado.Size = New System.Drawing.Size(345, 422)
        Me.GbEmpleado.TabIndex = 72
        Me.GbEmpleado.TabStop = False
        Me.GbEmpleado.Text = "Empleado"
        '
        'TxtMonto
        '
        Me.TxtMonto.Enabled = False
        Me.TxtMonto.Location = New System.Drawing.Point(193, 287)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(120, 20)
        Me.TxtMonto.TabIndex = 82
        '
        'TxtCuenta
        '
        Me.TxtCuenta.Enabled = False
        Me.TxtCuenta.Location = New System.Drawing.Point(73, 287)
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.Size = New System.Drawing.Size(114, 20)
        Me.TxtCuenta.TabIndex = 81
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Cuenta"
        '
        'Dtpegreso
        '
        Me.Dtpegreso.Location = New System.Drawing.Point(34, 211)
        Me.Dtpegreso.Name = "Dtpegreso"
        Me.Dtpegreso.Size = New System.Drawing.Size(279, 20)
        Me.Dtpegreso.TabIndex = 79
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Regreso"
        '
        'Salida
        '
        Me.Salida.AutoSize = True
        Me.Salida.Location = New System.Drawing.Point(31, 129)
        Me.Salida.Name = "Salida"
        Me.Salida.Size = New System.Drawing.Size(36, 13)
        Me.Salida.TabIndex = 77
        Me.Salida.Text = "Salida"
        '
        'DtpSalida
        '
        Me.DtpSalida.Location = New System.Drawing.Point(34, 145)
        Me.DtpSalida.Name = "DtpSalida"
        Me.DtpSalida.Size = New System.Drawing.Size(279, 20)
        Me.DtpSalida.TabIndex = 76
        '
        'TxtNombreEmpleado
        '
        Me.TxtNombreEmpleado.Enabled = False
        Me.TxtNombreEmpleado.Location = New System.Drawing.Point(82, 70)
        Me.TxtNombreEmpleado.Name = "TxtNombreEmpleado"
        Me.TxtNombreEmpleado.Size = New System.Drawing.Size(182, 20)
        Me.TxtNombreEmpleado.TabIndex = 75
        '
        'TxtIdEmpleado
        '
        Me.TxtIdEmpleado.Enabled = False
        Me.TxtIdEmpleado.Location = New System.Drawing.Point(34, 70)
        Me.TxtIdEmpleado.Name = "TxtIdEmpleado"
        Me.TxtIdEmpleado.Size = New System.Drawing.Size(42, 20)
        Me.TxtIdEmpleado.TabIndex = 74
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Empleado"
        '
        'BtnEmpleado
        '
        Me.BtnEmpleado.Location = New System.Drawing.Point(281, 68)
        Me.BtnEmpleado.Name = "BtnEmpleado"
        Me.BtnEmpleado.Size = New System.Drawing.Size(32, 23)
        Me.BtnEmpleado.TabIndex = 72
        Me.BtnEmpleado.Text = "..."
        Me.BtnEmpleado.UseVisualStyleBackColor = True
        '
        'FrmRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 526)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmRuta"
        Me.Text = "..:: Rutas Forenas - Pago Extra ::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GpEstado.ResumeLayout(False)
        Me.GpEstado.PerformLayout()
        Me.GbEmpleado.ResumeLayout(False)
        Me.GbEmpleado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BtnNuevo As ToolStripMenuItem
    Friend WithEvents BtnGuardar As ToolStripMenuItem
    Friend WithEvents BtnEliminar As ToolStripMenuItem
    Friend WithEvents BtnAdjuntos As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvRuta As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GpEstado As GroupBox
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents txtIdSucDest As TextBox
    Friend WithEvents btnDestino As Button
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtIdSucOrigen As TextBox
    Friend WithEvents btnOrigen As Button
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtCoordenadasDestino As TextBox
    Friend WithEvents TxtCorrdenadasOrigen As TextBox
    Friend WithEvents TxtKMRecorridos As TextBox
    Friend WithEvents TxtNombreRuta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GbEmpleado As GroupBox
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents TxtCuenta As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Dtpegreso As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Salida As Label
    Friend WithEvents DtpSalida As DateTimePicker
    Friend WithEvents TxtNombreEmpleado As TextBox
    Friend WithEvents TxtIdEmpleado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnEmpleado As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtComentario As RichTextBox
End Class
