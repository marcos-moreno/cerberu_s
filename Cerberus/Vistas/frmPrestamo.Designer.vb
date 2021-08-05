<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrestamo
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImpRepPrestamo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModRepPrestamo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvPrestamo = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvPagoCobro = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.dtpUltimoProceso = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.cbTipoInteres = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbPeriodoInteres = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInteres = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaPrestamo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInteresAnual = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnSocioEmpl = New System.Windows.Forms.Button()
        Me.txtNombreEmplSocio = New System.Windows.Forms.TextBox()
        Me.rbtnEmpleado = New System.Windows.Forms.RadioButton()
        Me.rbtnSocio = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDEmpSocio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPagoCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnReportes, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1231, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.btnEliminar.Text = "Eliminar"
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
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImpRepPrestamo, Me.btnModRepPrestamo})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(65, 20)
        Me.btnReportes.Text = "Reportes"
        '
        'btnImpRepPrestamo
        '
        Me.btnImpRepPrestamo.Name = "btnImpRepPrestamo"
        Me.btnImpRepPrestamo.Size = New System.Drawing.Size(125, 22)
        Me.btnImpRepPrestamo.Text = "Imprimir"
        '
        'btnModRepPrestamo
        '
        Me.btnModRepPrestamo.Name = "btnModRepPrestamo"
        Me.btnModRepPrestamo.Size = New System.Drawing.Size(125, 22)
        Me.btnModRepPrestamo.Text = "Modificar"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(144, 20)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(88, 20)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(94, 20)
        Me.btnSiguiente.Text = "Reg. Siguiente"
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
        Me.TabControl1.Size = New System.Drawing.Size(1207, 551)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvPrestamo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1199, 525)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvPrestamo
        '
        Me.dgvPrestamo.AllowUserToAddRows = False
        Me.dgvPrestamo.AllowUserToDeleteRows = False
        Me.dgvPrestamo.AllowUserToResizeRows = False
        Me.dgvPrestamo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrestamo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrestamo.Location = New System.Drawing.Point(6, 6)
        Me.dgvPrestamo.MultiSelect = False
        Me.dgvPrestamo.Name = "dgvPrestamo"
        Me.dgvPrestamo.ReadOnly = True
        Me.dgvPrestamo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrestamo.Size = New System.Drawing.Size(1187, 513)
        Me.dgvPrestamo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtEstado)
        Me.TabPage2.Controls.Add(Me.dtpUltimoProceso)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.cbTipoInteres)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.cbPeriodoInteres)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtSaldo)
        Me.TabPage2.Controls.Add(Me.txtObservaciones)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.dtpFechaInteres)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.dtpFechaPrestamo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtInteresAnual)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtCantidad)
        Me.TabPage2.Controls.Add(Me.btnSocioEmpl)
        Me.TabPage2.Controls.Add(Me.txtNombreEmplSocio)
        Me.TabPage2.Controls.Add(Me.rbtnEmpleado)
        Me.TabPage2.Controls.Add(Me.rbtnSocio)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtIDEmpSocio)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1199, 525)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(918, 233)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 26)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Procesar Intereses"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.dgvPagoCobro)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 284)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1156, 223)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cargos / Abonos"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 25)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Nuevo Cargo / Abono"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvPagoCobro
        '
        Me.dgvPagoCobro.AllowUserToAddRows = False
        Me.dgvPagoCobro.AllowUserToDeleteRows = False
        Me.dgvPagoCobro.AllowUserToResizeRows = False
        Me.dgvPagoCobro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPagoCobro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPagoCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPagoCobro.Location = New System.Drawing.Point(19, 56)
        Me.dgvPagoCobro.MultiSelect = False
        Me.dgvPagoCobro.Name = "dgvPagoCobro"
        Me.dgvPagoCobro.ReadOnly = True
        Me.dgvPagoCobro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagoCobro.Size = New System.Drawing.Size(1118, 149)
        Me.dgvPagoCobro.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(573, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Estado Documento:"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(711, 51)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(261, 20)
        Me.txtEstado.TabIndex = 34
        '
        'dtpUltimoProceso
        '
        Me.dtpUltimoProceso.Enabled = False
        Me.dtpUltimoProceso.Location = New System.Drawing.Point(712, 237)
        Me.dtpUltimoProceso.Name = "dtpUltimoProceso"
        Me.dtpUltimoProceso.Size = New System.Drawing.Size(200, 20)
        Me.dtpUltimoProceso.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Sucursal:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(160, 81)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(316, 21)
        Me.cbSucursal.TabIndex = 28
        '
        'cbTipoInteres
        '
        Me.cbTipoInteres.FormattingEnabled = True
        Me.cbTipoInteres.Items.AddRange(New Object() {"Porcentaje", "Cantidad Fija"})
        Me.cbTipoInteres.Location = New System.Drawing.Point(160, 214)
        Me.cbTipoInteres.Name = "cbTipoInteres"
        Me.cbTipoInteres.Size = New System.Drawing.Size(135, 21)
        Me.cbTipoInteres.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 217)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Tipo Interes:"
        '
        'cbPeriodoInteres
        '
        Me.cbPeriodoInteres.FormattingEnabled = True
        Me.cbPeriodoInteres.Items.AddRange(New Object() {"Mensual", "Anual", "Diario"})
        Me.cbPeriodoInteres.Location = New System.Drawing.Point(160, 240)
        Me.cbPeriodoInteres.Name = "cbPeriodoInteres"
        Me.cbPeriodoInteres.Size = New System.Drawing.Size(135, 21)
        Me.cbPeriodoInteres.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 243)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Periodo Interes:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(573, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Ultimo Proceso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(573, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Saldo:"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(711, 211)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(127, 20)
        Me.txtSaldo.TabIndex = 18
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(711, 77)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(362, 96)
        Me.txtObservaciones.TabIndex = 17
        Me.txtObservaciones.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(572, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Observaciones:"
        '
        'dtpFechaInteres
        '
        Me.dtpFechaInteres.Location = New System.Drawing.Point(160, 162)
        Me.dtpFechaInteres.Name = "dtpFechaInteres"
        Me.dtpFechaInteres.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaInteres.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fecha comienza interes:"
        '
        'dtpFechaPrestamo
        '
        Me.dtpFechaPrestamo.Location = New System.Drawing.Point(160, 136)
        Me.dtpFechaPrestamo.Name = "dtpFechaPrestamo"
        Me.dtpFechaPrestamo.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaPrestamo.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Fecha Prestamo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Interes Anual:"
        '
        'txtInteresAnual
        '
        Me.txtInteresAnual.Location = New System.Drawing.Point(160, 188)
        Me.txtInteresAnual.Name = "txtInteresAnual"
        Me.txtInteresAnual.Size = New System.Drawing.Size(135, 20)
        Me.txtInteresAnual.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(160, 109)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(135, 20)
        Me.txtCantidad.TabIndex = 7
        '
        'btnSocioEmpl
        '
        Me.btnSocioEmpl.Location = New System.Drawing.Point(482, 52)
        Me.btnSocioEmpl.Name = "btnSocioEmpl"
        Me.btnSocioEmpl.Size = New System.Drawing.Size(40, 25)
        Me.btnSocioEmpl.TabIndex = 6
        Me.btnSocioEmpl.Text = "..."
        Me.btnSocioEmpl.UseVisualStyleBackColor = True
        '
        'txtNombreEmplSocio
        '
        Me.txtNombreEmplSocio.Location = New System.Drawing.Point(216, 55)
        Me.txtNombreEmplSocio.Name = "txtNombreEmplSocio"
        Me.txtNombreEmplSocio.ReadOnly = True
        Me.txtNombreEmplSocio.Size = New System.Drawing.Size(260, 20)
        Me.txtNombreEmplSocio.TabIndex = 5
        '
        'rbtnEmpleado
        '
        Me.rbtnEmpleado.AutoSize = True
        Me.rbtnEmpleado.Location = New System.Drawing.Point(293, 21)
        Me.rbtnEmpleado.Name = "rbtnEmpleado"
        Me.rbtnEmpleado.Size = New System.Drawing.Size(72, 17)
        Me.rbtnEmpleado.TabIndex = 4
        Me.rbtnEmpleado.Text = "Empleado"
        Me.rbtnEmpleado.UseVisualStyleBackColor = True
        '
        'rbtnSocio
        '
        Me.rbtnSocio.AutoSize = True
        Me.rbtnSocio.Checked = True
        Me.rbtnSocio.Location = New System.Drawing.Point(160, 21)
        Me.rbtnSocio.Name = "rbtnSocio"
        Me.rbtnSocio.Size = New System.Drawing.Size(110, 17)
        Me.rbtnSocio.TabIndex = 3
        Me.rbtnSocio.TabStop = True
        Me.rbtnSocio.Text = "Socio de Negocio"
        Me.rbtnSocio.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Prestamo a:"
        '
        'txtIDEmpSocio
        '
        Me.txtIDEmpSocio.Location = New System.Drawing.Point(160, 55)
        Me.txtIDEmpSocio.Name = "txtIDEmpSocio"
        Me.txtIDEmpSocio.ReadOnly = True
        Me.txtIDEmpSocio.Size = New System.Drawing.Size(50, 20)
        Me.txtIDEmpSocio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Socio / Empleado:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 592)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1231, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'frmPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 614)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmPrestamo"
        Me.Text = "Prestamos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPagoCobro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents btnImpRepPrestamo As ToolStripMenuItem
    Friend WithEvents btnModRepPrestamo As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvPrestamo As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents cbTipoInteres As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbPeriodoInteres As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents txtObservaciones As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaInteres As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFechaPrestamo As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtInteresAnual As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents btnSocioEmpl As Button
    Friend WithEvents txtNombreEmplSocio As TextBox
    Friend WithEvents rbtnEmpleado As RadioButton
    Friend WithEvents rbtnSocio As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIDEmpSocio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents dgvPagoCobro As DataGridView
    Friend WithEvents dtpUltimoProceso As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
