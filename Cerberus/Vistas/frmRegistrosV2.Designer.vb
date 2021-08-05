<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrosV2
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDepartamento = New System.Windows.Forms.ComboBox()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabEmpl = New System.Windows.Forms.TabPage()
        Me.dgvEmpleado = New System.Windows.Forms.DataGridView()
        Me.tabReg = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.dgvTipoIncidencia = New System.Windows.Forms.DataGridView()
        Me.dgvRegsDia = New System.Windows.Forms.DataGridView()
        Me.dgvPeriodo = New System.Windows.Forms.DataGridView()
        Me.chbHorasLimiteHorasExtras = New System.Windows.Forms.CheckBox()
        Me.btnProcesarHorasExtras = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.chbHorasExtrasAutorizadas = New System.Windows.Forms.CheckBox()
        Me.btnActualizarRegistros = New System.Windows.Forms.Button()
        Me.txtNumHorasExtras = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnActHorasExtras = New System.Windows.Forms.Button()
        Me.calculosES = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dgvExtras = New System.Windows.Forms.DataGridView()
        Me.txtTFN = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtExcedente = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dgvCalculos = New System.Windows.Forms.DataGridView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTE = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtVD = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTHL = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSSR = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtSSI = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPSGS = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPGS = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtI = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtF = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDP = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDF = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtD = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCHR = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCHET = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBJL = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.calculosCO = New System.Windows.Forms.TabPage()
        Me.txtCocinaAsig = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtDescuentoXComidas = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtNumComidas = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tabRegManua = New System.Windows.Forms.TabPage()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.dgvEmpleadoCopy = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.chbConcervar = New System.Windows.Forms.CheckBox()
        Me.cbDispositivo = New System.Windows.Forms.ComboBox()
        Me.dgvEmpleadosADD = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dtpRegManual = New System.Windows.Forms.DateTimePicker()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnRegInvalidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnInformes = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRegistros = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIIncidencias = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDelEmpleado = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDEImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDEModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDelPeriodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDPImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIRDPModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRegAnt = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRegSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntosIncidencia = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSeleccion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabEmpl.SuspendLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReg.SuspendLayout()
        CType(Me.dgvTipoIncidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRegsDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.calculosES.SuspendLayout()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCalculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.calculosCO.SuspendLayout()
        Me.tabRegManua.SuspendLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.Panel2.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        CType(Me.dgvEmpleadoCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmpleadosADD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(901, 29)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 19
        Me.Button6.Text = "Limpiar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(811, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(654, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "-"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(511, 32)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(277, 20)
        Me.txtFiltro.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(447, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Buscador: "
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Location = New System.Drawing.Point(673, 61)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaFinal.TabIndex = 21
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Location = New System.Drawing.Point(446, 61)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaInicial.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Departamento:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Periodo: "
        '
        'cbDepartamento
        '
        Me.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(101, 32)
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(332, 21)
        Me.cbDepartamento.TabIndex = 13
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(101, 58)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(332, 21)
        Me.cbPeriodo.TabIndex = 15
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabEmpl)
        Me.TabControl1.Controls.Add(Me.tabReg)
        Me.TabControl1.Controls.Add(Me.calculosES)
        Me.TabControl1.Controls.Add(Me.calculosCO)
        Me.TabControl1.Controls.Add(Me.tabRegManua)
        Me.TabControl1.Location = New System.Drawing.Point(12, 113)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1427, 486)
        Me.TabControl1.TabIndex = 14
        '
        'tabEmpl
        '
        Me.tabEmpl.Controls.Add(Me.dgvEmpleado)
        Me.tabEmpl.Location = New System.Drawing.Point(4, 22)
        Me.tabEmpl.Name = "tabEmpl"
        Me.tabEmpl.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmpl.Size = New System.Drawing.Size(1232, 460)
        Me.tabEmpl.TabIndex = 0
        Me.tabEmpl.Text = "Empleados"
        Me.tabEmpl.UseVisualStyleBackColor = True
        '
        'dgvEmpleado
        '
        Me.dgvEmpleado.AllowUserToAddRows = False
        Me.dgvEmpleado.AllowUserToDeleteRows = False
        Me.dgvEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleado.Location = New System.Drawing.Point(6, 15)
        Me.dgvEmpleado.MultiSelect = False
        Me.dgvEmpleado.Name = "dgvEmpleado"
        Me.dgvEmpleado.ReadOnly = True
        Me.dgvEmpleado.RowHeadersVisible = False
        Me.dgvEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleado.Size = New System.Drawing.Size(1220, 439)
        Me.dgvEmpleado.TabIndex = 1
        '
        'tabReg
        '
        Me.tabReg.Controls.Add(Me.Label9)
        Me.tabReg.Controls.Add(Me.lbl1)
        Me.tabReg.Controls.Add(Me.dgvTipoIncidencia)
        Me.tabReg.Controls.Add(Me.dgvRegsDia)
        Me.tabReg.Controls.Add(Me.dgvPeriodo)
        Me.tabReg.Controls.Add(Me.chbHorasLimiteHorasExtras)
        Me.tabReg.Controls.Add(Me.btnProcesarHorasExtras)
        Me.tabReg.Controls.Add(Me.Label34)
        Me.tabReg.Controls.Add(Me.chbHorasExtrasAutorizadas)
        Me.tabReg.Controls.Add(Me.btnActualizarRegistros)
        Me.tabReg.Controls.Add(Me.txtNumHorasExtras)
        Me.tabReg.Controls.Add(Me.Label33)
        Me.tabReg.Controls.Add(Me.btnActHorasExtras)
        Me.tabReg.Location = New System.Drawing.Point(4, 22)
        Me.tabReg.Name = "tabReg"
        Me.tabReg.Padding = New System.Windows.Forms.Padding(3)
        Me.tabReg.Size = New System.Drawing.Size(1419, 460)
        Me.tabReg.TabIndex = 1
        Me.tabReg.Text = "Registros"
        Me.tabReg.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(937, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Tipos de Incidencias"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl1.Location = New System.Drawing.Point(7, 40)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(71, 13)
        Me.lbl1.TabIndex = 63
        Me.lbl1.Text = "Sin Asignar"
        '
        'dgvTipoIncidencia
        '
        Me.dgvTipoIncidencia.AllowUserToAddRows = False
        Me.dgvTipoIncidencia.AllowUserToDeleteRows = False
        Me.dgvTipoIncidencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTipoIncidencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTipoIncidencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoIncidencia.Location = New System.Drawing.Point(940, 25)
        Me.dgvTipoIncidencia.MultiSelect = False
        Me.dgvTipoIncidencia.Name = "dgvTipoIncidencia"
        Me.dgvTipoIncidencia.ReadOnly = True
        Me.dgvTipoIncidencia.RowHeadersVisible = False
        Me.dgvTipoIncidencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoIncidencia.Size = New System.Drawing.Size(462, 226)
        Me.dgvTipoIncidencia.TabIndex = 62
        '
        'dgvRegsDia
        '
        Me.dgvRegsDia.AllowUserToAddRows = False
        Me.dgvRegsDia.AllowUserToDeleteRows = False
        Me.dgvRegsDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRegsDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegsDia.Location = New System.Drawing.Point(10, 56)
        Me.dgvRegsDia.MultiSelect = False
        Me.dgvRegsDia.Name = "dgvRegsDia"
        Me.dgvRegsDia.ReadOnly = True
        Me.dgvRegsDia.RowHeadersVisible = False
        Me.dgvRegsDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegsDia.Size = New System.Drawing.Size(567, 195)
        Me.dgvRegsDia.TabIndex = 61
        '
        'dgvPeriodo
        '
        Me.dgvPeriodo.AllowUserToAddRows = False
        Me.dgvPeriodo.AllowUserToDeleteRows = False
        Me.dgvPeriodo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPeriodo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeriodo.Location = New System.Drawing.Point(10, 257)
        Me.dgvPeriodo.MultiSelect = False
        Me.dgvPeriodo.Name = "dgvPeriodo"
        Me.dgvPeriodo.ReadOnly = True
        Me.dgvPeriodo.RowHeadersVisible = False
        Me.dgvPeriodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPeriodo.Size = New System.Drawing.Size(1392, 197)
        Me.dgvPeriodo.TabIndex = 60
        '
        'chbHorasLimiteHorasExtras
        '
        Me.chbHorasLimiteHorasExtras.AutoSize = True
        Me.chbHorasLimiteHorasExtras.Enabled = False
        Me.chbHorasLimiteHorasExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbHorasLimiteHorasExtras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chbHorasLimiteHorasExtras.Location = New System.Drawing.Point(586, 110)
        Me.chbHorasLimiteHorasExtras.Name = "chbHorasLimiteHorasExtras"
        Me.chbHorasLimiteHorasExtras.Size = New System.Drawing.Size(135, 17)
        Me.chbHorasLimiteHorasExtras.TabIndex = 33
        Me.chbHorasLimiteHorasExtras.Text = "Limite Horas Extras"
        Me.chbHorasLimiteHorasExtras.UseVisualStyleBackColor = True
        '
        'btnProcesarHorasExtras
        '
        Me.btnProcesarHorasExtras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarHorasExtras.Location = New System.Drawing.Point(587, 180)
        Me.btnProcesarHorasExtras.Name = "btnProcesarHorasExtras"
        Me.btnProcesarHorasExtras.Size = New System.Drawing.Size(347, 24)
        Me.btnProcesarHorasExtras.TabIndex = 59
        Me.btnProcesarHorasExtras.Text = "Procesar Horas (Extra-Salidas, Entradas, Comidas)"
        Me.btnProcesarHorasExtras.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(584, 87)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(282, 13)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "(Si no se activa se pagara todas las generadas) "
        '
        'chbHorasExtrasAutorizadas
        '
        Me.chbHorasExtrasAutorizadas.AutoSize = True
        Me.chbHorasExtrasAutorizadas.Location = New System.Drawing.Point(771, 103)
        Me.chbHorasExtrasAutorizadas.Name = "chbHorasExtrasAutorizadas"
        Me.chbHorasExtrasAutorizadas.Size = New System.Drawing.Size(167, 30)
        Me.chbHorasExtrasAutorizadas.TabIndex = 32
        Me.chbHorasExtrasAutorizadas.Text = "Permitir Generar Horas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despues del horario de Salida"
        Me.chbHorasExtrasAutorizadas.UseVisualStyleBackColor = True
        '
        'btnActualizarRegistros
        '
        Me.btnActualizarRegistros.Location = New System.Drawing.Point(10, 11)
        Me.btnActualizarRegistros.Name = "btnActualizarRegistros"
        Me.btnActualizarRegistros.Size = New System.Drawing.Size(190, 23)
        Me.btnActualizarRegistros.TabIndex = 13
        Me.btnActualizarRegistros.Text = "Activar / Desactivar Registro"
        Me.btnActualizarRegistros.UseVisualStyleBackColor = True
        '
        'txtNumHorasExtras
        '
        Me.txtNumHorasExtras.Enabled = False
        Me.txtNumHorasExtras.Location = New System.Drawing.Point(719, 138)
        Me.txtNumHorasExtras.Name = "txtNumHorasExtras"
        Me.txtNumHorasExtras.Size = New System.Drawing.Size(97, 20)
        Me.txtNumHorasExtras.TabIndex = 31
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(583, 141)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(130, 13)
        Me.Label33.TabIndex = 30
        Me.Label33.Text = "Limite de Horas (Decimal):"
        '
        'btnActHorasExtras
        '
        Me.btnActHorasExtras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActHorasExtras.Enabled = False
        Me.btnActHorasExtras.Location = New System.Drawing.Point(1042, 136)
        Me.btnActHorasExtras.Name = "btnActHorasExtras"
        Me.btnActHorasExtras.Size = New System.Drawing.Size(79, 23)
        Me.btnActHorasExtras.TabIndex = 34
        Me.btnActHorasExtras.Text = "Actualizar Horas"
        Me.btnActHorasExtras.UseVisualStyleBackColor = True
        '
        'calculosES
        '
        Me.calculosES.Controls.Add(Me.Label36)
        Me.calculosES.Controls.Add(Me.dgvExtras)
        Me.calculosES.Controls.Add(Me.txtTFN)
        Me.calculosES.Controls.Add(Me.Label35)
        Me.calculosES.Controls.Add(Me.txtExcedente)
        Me.calculosES.Controls.Add(Me.Label32)
        Me.calculosES.Controls.Add(Me.Button7)
        Me.calculosES.Controls.Add(Me.dgvCalculos)
        Me.calculosES.Controls.Add(Me.Button5)
        Me.calculosES.Controls.Add(Me.Label27)
        Me.calculosES.Controls.Add(Me.txtTE)
        Me.calculosES.Controls.Add(Me.Label26)
        Me.calculosES.Controls.Add(Me.txtVD)
        Me.calculosES.Controls.Add(Me.Label25)
        Me.calculosES.Controls.Add(Me.txtTHL)
        Me.calculosES.Controls.Add(Me.Label24)
        Me.calculosES.Controls.Add(Me.txtSSR)
        Me.calculosES.Controls.Add(Me.Label23)
        Me.calculosES.Controls.Add(Me.txtSSI)
        Me.calculosES.Controls.Add(Me.Label22)
        Me.calculosES.Controls.Add(Me.txtPSGS)
        Me.calculosES.Controls.Add(Me.Label21)
        Me.calculosES.Controls.Add(Me.txtPGS)
        Me.calculosES.Controls.Add(Me.Label20)
        Me.calculosES.Controls.Add(Me.txtI)
        Me.calculosES.Controls.Add(Me.Label19)
        Me.calculosES.Controls.Add(Me.txtF)
        Me.calculosES.Controls.Add(Me.Label18)
        Me.calculosES.Controls.Add(Me.txtDP)
        Me.calculosES.Controls.Add(Me.Label17)
        Me.calculosES.Controls.Add(Me.txtDF)
        Me.calculosES.Controls.Add(Me.Label16)
        Me.calculosES.Controls.Add(Me.txtD)
        Me.calculosES.Controls.Add(Me.Label15)
        Me.calculosES.Controls.Add(Me.txtCHR)
        Me.calculosES.Controls.Add(Me.Label13)
        Me.calculosES.Controls.Add(Me.txtCHET)
        Me.calculosES.Controls.Add(Me.Label12)
        Me.calculosES.Controls.Add(Me.txtBJL)
        Me.calculosES.Controls.Add(Me.Label11)
        Me.calculosES.Controls.Add(Me.txtA)
        Me.calculosES.Controls.Add(Me.Label10)
        Me.calculosES.Location = New System.Drawing.Point(4, 22)
        Me.calculosES.Name = "calculosES"
        Me.calculosES.Size = New System.Drawing.Size(1232, 460)
        Me.calculosES.TabIndex = 3
        Me.calculosES.Text = "Calculos"
        Me.calculosES.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(734, 232)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(81, 13)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = "Procesos Extra:"
        '
        'dgvExtras
        '
        Me.dgvExtras.AllowUserToAddRows = False
        Me.dgvExtras.AllowUserToDeleteRows = False
        Me.dgvExtras.AllowUserToResizeRows = False
        Me.dgvExtras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExtras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtras.Location = New System.Drawing.Point(733, 250)
        Me.dgvExtras.MultiSelect = False
        Me.dgvExtras.Name = "dgvExtras"
        Me.dgvExtras.ReadOnly = True
        Me.dgvExtras.RowHeadersVisible = False
        Me.dgvExtras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExtras.Size = New System.Drawing.Size(476, 186)
        Me.dgvExtras.TabIndex = 42
        '
        'txtTFN
        '
        Me.txtTFN.Location = New System.Drawing.Point(733, 193)
        Me.txtTFN.Name = "txtTFN"
        Me.txtTFN.ReadOnly = True
        Me.txtTFN.Size = New System.Drawing.Size(117, 20)
        Me.txtTFN.TabIndex = 41
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(589, 196)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(129, 13)
        Me.Label35.TabIndex = 40
        Me.Label35.Text = "Tiempo Fuera de Nomina:"
        '
        'txtExcedente
        '
        Me.txtExcedente.Location = New System.Drawing.Point(733, 86)
        Me.txtExcedente.Name = "txtExcedente"
        Me.txtExcedente.ReadOnly = True
        Me.txtExcedente.Size = New System.Drawing.Size(117, 20)
        Me.txtExcedente.TabIndex = 39
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(589, 89)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(61, 13)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "Excedente:"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Brown
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.Location = New System.Drawing.Point(877, 162)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(258, 29)
        Me.Button7.TabIndex = 37
        Me.Button7.Text = "Procesar BAJA del Empleado"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'dgvCalculos
        '
        Me.dgvCalculos.AllowUserToAddRows = False
        Me.dgvCalculos.AllowUserToDeleteRows = False
        Me.dgvCalculos.AllowUserToResizeRows = False
        Me.dgvCalculos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvCalculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCalculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalculos.Location = New System.Drawing.Point(19, 232)
        Me.dgvCalculos.MultiSelect = False
        Me.dgvCalculos.Name = "dgvCalculos"
        Me.dgvCalculos.ReadOnly = True
        Me.dgvCalculos.RowHeadersVisible = False
        Me.dgvCalculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCalculos.Size = New System.Drawing.Size(709, 204)
        Me.dgvCalculos.TabIndex = 35
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.YellowGreen
        Me.Button5.Location = New System.Drawing.Point(877, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(258, 27)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "Procesar Empleado en Periodo"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 215)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(103, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Resultado Formulas:"
        '
        'txtTE
        '
        Me.txtTE.Location = New System.Drawing.Point(733, 167)
        Me.txtTE.Name = "txtTE"
        Me.txtTE.ReadOnly = True
        Me.txtTE.Size = New System.Drawing.Size(117, 20)
        Me.txtTE.TabIndex = 32
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(589, 170)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Tiempo Extra:"
        '
        'txtVD
        '
        Me.txtVD.Location = New System.Drawing.Point(733, 141)
        Me.txtVD.Name = "txtVD"
        Me.txtVD.ReadOnly = True
        Me.txtVD.Size = New System.Drawing.Size(117, 20)
        Me.txtVD.TabIndex = 30
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(589, 144)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(66, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Vacaciones:"
        '
        'txtTHL
        '
        Me.txtTHL.Location = New System.Drawing.Point(733, 112)
        Me.txtTHL.Name = "txtTHL"
        Me.txtTHL.ReadOnly = True
        Me.txtTHL.Size = New System.Drawing.Size(117, 20)
        Me.txtTHL.TabIndex = 28
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(589, 115)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Total horas Laboradas:"
        '
        'txtSSR
        '
        Me.txtSSR.Location = New System.Drawing.Point(733, 33)
        Me.txtSSR.Name = "txtSSR"
        Me.txtSSR.ReadOnly = True
        Me.txtSSR.Size = New System.Drawing.Size(117, 20)
        Me.txtSSR.TabIndex = 26
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(589, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 13)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Salaraio Real:"
        '
        'txtSSI
        '
        Me.txtSSI.Location = New System.Drawing.Point(733, 60)
        Me.txtSSI.Name = "txtSSI"
        Me.txtSSI.ReadOnly = True
        Me.txtSSI.Size = New System.Drawing.Size(117, 20)
        Me.txtSSI.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(589, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Salario IMSS:"
        '
        'txtPSGS
        '
        Me.txtPSGS.Location = New System.Drawing.Point(437, 164)
        Me.txtPSGS.Name = "txtPSGS"
        Me.txtPSGS.ReadOnly = True
        Me.txtPSGS.Size = New System.Drawing.Size(117, 20)
        Me.txtPSGS.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(293, 167)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(127, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Permiso sin Gose Sueldo:"
        '
        'txtPGS
        '
        Me.txtPGS.Location = New System.Drawing.Point(437, 138)
        Me.txtPGS.Name = "txtPGS"
        Me.txtPGS.ReadOnly = True
        Me.txtPGS.Size = New System.Drawing.Size(117, 20)
        Me.txtPGS.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(293, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(132, 13)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Permiso con Gose Sueldo:"
        '
        'txtI
        '
        Me.txtI.Location = New System.Drawing.Point(437, 112)
        Me.txtI.Name = "txtI"
        Me.txtI.ReadOnly = True
        Me.txtI.Size = New System.Drawing.Size(117, 20)
        Me.txtI.TabIndex = 18
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(293, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 13)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Incapacidad(es):"
        '
        'txtF
        '
        Me.txtF.Location = New System.Drawing.Point(437, 86)
        Me.txtF.Name = "txtF"
        Me.txtF.ReadOnly = True
        Me.txtF.Size = New System.Drawing.Size(117, 20)
        Me.txtF.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(293, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Faltas:"
        '
        'txtDP
        '
        Me.txtDP.Location = New System.Drawing.Point(437, 60)
        Me.txtDP.Name = "txtDP"
        Me.txtDP.ReadOnly = True
        Me.txtDP.Size = New System.Drawing.Size(117, 20)
        Me.txtDP.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(293, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Dias del Periodo:"
        '
        'txtDF
        '
        Me.txtDF.Location = New System.Drawing.Point(437, 34)
        Me.txtDF.Name = "txtDF"
        Me.txtDF.ReadOnly = True
        Me.txtDF.Size = New System.Drawing.Size(117, 20)
        Me.txtDF.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(293, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Dia(s) Festivo(s):"
        '
        'txtD
        '
        Me.txtD.Location = New System.Drawing.Point(147, 138)
        Me.txtD.Name = "txtD"
        Me.txtD.ReadOnly = True
        Me.txtD.Size = New System.Drawing.Size(117, 20)
        Me.txtD.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Destajo:"
        '
        'txtCHR
        '
        Me.txtCHR.Location = New System.Drawing.Point(147, 112)
        Me.txtCHR.Name = "txtCHR"
        Me.txtCHR.ReadOnly = True
        Me.txtCHR.Size = New System.Drawing.Size(117, 20)
        Me.txtCHR.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Costo Hora Real:"
        '
        'txtCHET
        '
        Me.txtCHET.Location = New System.Drawing.Point(147, 86)
        Me.txtCHET.Name = "txtCHET"
        Me.txtCHET.ReadOnly = True
        Me.txtCHET.Size = New System.Drawing.Size(117, 20)
        Me.txtCHET.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Costo Hora Extra Tab.:"
        '
        'txtBJL
        '
        Me.txtBJL.Location = New System.Drawing.Point(147, 60)
        Me.txtBJL.Name = "txtBJL"
        Me.txtBJL.ReadOnly = True
        Me.txtBJL.Size = New System.Drawing.Size(117, 20)
        Me.txtBJL.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Base Jornada Laboral:"
        '
        'txtA
        '
        Me.txtA.Location = New System.Drawing.Point(147, 34)
        Me.txtA.Name = "txtA"
        Me.txtA.ReadOnly = True
        Me.txtA.Size = New System.Drawing.Size(117, 20)
        Me.txtA.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Asistencias:"
        '
        'calculosCO
        '
        Me.calculosCO.Controls.Add(Me.txtCocinaAsig)
        Me.calculosCO.Controls.Add(Me.Label30)
        Me.calculosCO.Controls.Add(Me.txtDescuentoXComidas)
        Me.calculosCO.Controls.Add(Me.Label29)
        Me.calculosCO.Controls.Add(Me.txtNumComidas)
        Me.calculosCO.Controls.Add(Me.Label28)
        Me.calculosCO.Location = New System.Drawing.Point(4, 22)
        Me.calculosCO.Name = "calculosCO"
        Me.calculosCO.Size = New System.Drawing.Size(1232, 460)
        Me.calculosCO.TabIndex = 4
        Me.calculosCO.Text = "Calculos"
        Me.calculosCO.UseVisualStyleBackColor = True
        '
        'txtCocinaAsig
        '
        Me.txtCocinaAsig.Location = New System.Drawing.Point(165, 24)
        Me.txtCocinaAsig.Name = "txtCocinaAsig"
        Me.txtCocinaAsig.ReadOnly = True
        Me.txtCocinaAsig.Size = New System.Drawing.Size(175, 20)
        Me.txtCocinaAsig.TabIndex = 49
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(29, 27)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(90, 13)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "Cocina Asignada:"
        '
        'txtDescuentoXComidas
        '
        Me.txtDescuentoXComidas.Location = New System.Drawing.Point(165, 96)
        Me.txtDescuentoXComidas.Name = "txtDescuentoXComidas"
        Me.txtDescuentoXComidas.ReadOnly = True
        Me.txtDescuentoXComidas.Size = New System.Drawing.Size(117, 20)
        Me.txtDescuentoXComidas.TabIndex = 47
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(29, 99)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(121, 13)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "Descuento X Comida(s):"
        '
        'txtNumComidas
        '
        Me.txtNumComidas.Location = New System.Drawing.Point(165, 70)
        Me.txtNumComidas.Name = "txtNumComidas"
        Me.txtNumComidas.ReadOnly = True
        Me.txtNumComidas.Size = New System.Drawing.Size(117, 20)
        Me.txtNumComidas.TabIndex = 45
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(29, 73)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(99, 13)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Num. de Comida(s):"
        '
        'tabRegManua
        '
        Me.tabRegManua.Controls.Add(Me.SplitContainer8)
        Me.tabRegManua.Location = New System.Drawing.Point(4, 22)
        Me.tabRegManua.Name = "tabRegManua"
        Me.tabRegManua.Size = New System.Drawing.Size(1232, 460)
        Me.tabRegManua.TabIndex = 2
        Me.tabRegManua.Text = "Registros Manuales / Incidencias"
        Me.tabRegManua.UseVisualStyleBackColor = True
        '
        'SplitContainer8
        '
        Me.SplitContainer8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer8.Location = New System.Drawing.Point(13, 14)
        Me.SplitContainer8.Name = "SplitContainer8"
        '
        'SplitContainer8.Panel1
        '
        Me.SplitContainer8.Panel1.Controls.Add(Me.dgvEmpleadoCopy)
        Me.SplitContainer8.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer8.Panel1.Controls.Add(Me.Button3)
        '
        'SplitContainer8.Panel2
        '
        Me.SplitContainer8.Panel2.Controls.Add(Me.chbConcervar)
        Me.SplitContainer8.Panel2.Controls.Add(Me.cbDispositivo)
        Me.SplitContainer8.Panel2.Controls.Add(Me.dgvEmpleadosADD)
        Me.SplitContainer8.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer8.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer8.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer8.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer8.Panel2.Controls.Add(Me.Button4)
        Me.SplitContainer8.Panel2.Controls.Add(Me.dtpRegManual)
        Me.SplitContainer8.Panel2.Controls.Add(Me.txtComentario)
        Me.SplitContainer8.Size = New System.Drawing.Size(1201, 433)
        Me.SplitContainer8.SplitterDistance = 598
        Me.SplitContainer8.TabIndex = 17
        '
        'dgvEmpleadoCopy
        '
        Me.dgvEmpleadoCopy.AllowUserToAddRows = False
        Me.dgvEmpleadoCopy.AllowUserToDeleteRows = False
        Me.dgvEmpleadoCopy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleadoCopy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEmpleadoCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleadoCopy.Location = New System.Drawing.Point(18, 45)
        Me.dgvEmpleadoCopy.MultiSelect = False
        Me.dgvEmpleadoCopy.Name = "dgvEmpleadoCopy"
        Me.dgvEmpleadoCopy.ReadOnly = True
        Me.dgvEmpleadoCopy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleadoCopy.Size = New System.Drawing.Size(565, 375)
        Me.dgvEmpleadoCopy.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Empleados"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(482, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Agregar >>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chbConcervar
        '
        Me.chbConcervar.AutoSize = True
        Me.chbConcervar.Location = New System.Drawing.Point(360, 12)
        Me.chbConcervar.Name = "chbConcervar"
        Me.chbConcervar.Size = New System.Drawing.Size(129, 17)
        Me.chbConcervar.TabIndex = 17
        Me.chbConcervar.Text = "Conservar Empleados"
        Me.chbConcervar.UseVisualStyleBackColor = True
        '
        'cbDispositivo
        '
        Me.cbDispositivo.FormattingEnabled = True
        Me.cbDispositivo.Location = New System.Drawing.Point(104, 63)
        Me.cbDispositivo.Name = "cbDispositivo"
        Me.cbDispositivo.Size = New System.Drawing.Size(239, 21)
        Me.cbDispositivo.TabIndex = 16
        '
        'dgvEmpleadosADD
        '
        Me.dgvEmpleadosADD.AllowUserToAddRows = False
        Me.dgvEmpleadosADD.AllowUserToDeleteRows = False
        Me.dgvEmpleadosADD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleadosADD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEmpleadosADD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleadosADD.Location = New System.Drawing.Point(12, 100)
        Me.dgvEmpleadosADD.MultiSelect = False
        Me.dgvEmpleadosADD.Name = "dgvEmpleadosADD"
        Me.dgvEmpleadosADD.ReadOnly = True
        Me.dgvEmpleadosADD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleadosADD.Size = New System.Drawing.Size(570, 320)
        Me.dgvEmpleadosADD.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha Hora: "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Dispositivo:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Comentario: "
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(441, 61)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Quitar Emp."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'dtpRegManual
        '
        Me.dtpRegManual.CustomFormat = "dddd dd MMMM yyyy   HH:mm:ss"
        Me.dtpRegManual.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRegManual.Location = New System.Drawing.Point(104, 11)
        Me.dtpRegManual.Name = "dtpRegManual"
        Me.dtpRegManual.Size = New System.Drawing.Size(239, 20)
        Me.dtpRegManual.TabIndex = 4
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(104, 37)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(239, 20)
        Me.txtComentario.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRegInvalidos, Me.btnInformes, Me.btnRegAnt, Me.btnRegSiguiente, Me.btnAdjuntosIncidencia, Me.btnImportar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1451, 24)
        Me.MenuStrip1.TabIndex = 25
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnRegInvalidos
        '
        Me.btnRegInvalidos.Name = "btnRegInvalidos"
        Me.btnRegInvalidos.Size = New System.Drawing.Size(136, 20)
        Me.btnRegInvalidos.Text = "Ver Registros Invalidos"
        '
        'btnInformes
        '
        Me.btnInformes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRegistros, Me.btnIIncidencias})
        Me.btnInformes.Name = "btnInformes"
        Me.btnInformes.Size = New System.Drawing.Size(66, 20)
        Me.btnInformes.Text = "Informes"
        '
        'btnIRegistros
        '
        Me.btnIRegistros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRImprimir, Me.btnIRModificar})
        Me.btnIRegistros.Name = "btnIRegistros"
        Me.btnIRegistros.Size = New System.Drawing.Size(133, 22)
        Me.btnIRegistros.Text = "Registros"
        '
        'btnIRImprimir
        '
        Me.btnIRImprimir.Name = "btnIRImprimir"
        Me.btnIRImprimir.Size = New System.Drawing.Size(125, 22)
        Me.btnIRImprimir.Text = "Imprimir"
        '
        'btnIRModificar
        '
        Me.btnIRModificar.Name = "btnIRModificar"
        Me.btnIRModificar.Size = New System.Drawing.Size(125, 22)
        Me.btnIRModificar.Text = "Modificar"
        Me.btnIRModificar.Visible = False
        '
        'btnIIncidencias
        '
        Me.btnIIncidencias.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRDelEmpleado, Me.btnIRDelPeriodo})
        Me.btnIIncidencias.Name = "btnIIncidencias"
        Me.btnIIncidencias.Size = New System.Drawing.Size(133, 22)
        Me.btnIIncidencias.Text = "Incidencias"
        '
        'btnIRDelEmpleado
        '
        Me.btnIRDelEmpleado.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRDEImprimir, Me.btnIRDEModificar})
        Me.btnIRDelEmpleado.Name = "btnIRDelEmpleado"
        Me.btnIRDelEmpleado.Size = New System.Drawing.Size(147, 22)
        Me.btnIRDelEmpleado.Text = "Del Empleado"
        '
        'btnIRDEImprimir
        '
        Me.btnIRDEImprimir.Name = "btnIRDEImprimir"
        Me.btnIRDEImprimir.Size = New System.Drawing.Size(125, 22)
        Me.btnIRDEImprimir.Text = "Imprimir"
        '
        'btnIRDEModificar
        '
        Me.btnIRDEModificar.Name = "btnIRDEModificar"
        Me.btnIRDEModificar.Size = New System.Drawing.Size(125, 22)
        Me.btnIRDEModificar.Text = "Modificar"
        Me.btnIRDEModificar.Visible = False
        '
        'btnIRDelPeriodo
        '
        Me.btnIRDelPeriodo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRDPImprimir, Me.btnIRDPModificar})
        Me.btnIRDelPeriodo.Name = "btnIRDelPeriodo"
        Me.btnIRDelPeriodo.Size = New System.Drawing.Size(147, 22)
        Me.btnIRDelPeriodo.Text = "Del Periodo"
        '
        'btnIRDPImprimir
        '
        Me.btnIRDPImprimir.Name = "btnIRDPImprimir"
        Me.btnIRDPImprimir.Size = New System.Drawing.Size(125, 22)
        Me.btnIRDPImprimir.Text = "Imprimir"
        '
        'btnIRDPModificar
        '
        Me.btnIRDPModificar.Name = "btnIRDPModificar"
        Me.btnIRDPModificar.Size = New System.Drawing.Size(125, 22)
        Me.btnIRDPModificar.Text = "Modificar"
        Me.btnIRDPModificar.Visible = False
        '
        'btnRegAnt
        '
        Me.btnRegAnt.Name = "btnRegAnt"
        Me.btnRegAnt.Size = New System.Drawing.Size(85, 20)
        Me.btnRegAnt.Text = "Reg Anterior"
        '
        'btnRegSiguiente
        '
        Me.btnRegSiguiente.Name = "btnRegSiguiente"
        Me.btnRegSiguiente.Size = New System.Drawing.Size(91, 20)
        Me.btnRegSiguiente.Text = "Reg Siguiente"
        '
        'btnAdjuntosIncidencia
        '
        Me.btnAdjuntosIncidencia.Name = "btnAdjuntosIncidencia"
        Me.btnAdjuntosIncidencia.Size = New System.Drawing.Size(67, 20)
        Me.btnAdjuntosIncidencia.Text = "Adjuntos"
        '
        'btnImportar
        '
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(119, 20)
        Me.btnImportar.Text = "Importar ARCHIVO"
        '
        'lblSeleccion
        '
        Me.lblSeleccion.Location = New System.Drawing.Point(101, 87)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.ReadOnly = True
        Me.lblSeleccion.Size = New System.Drawing.Size(772, 20)
        Me.lblSeleccion.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Empleado:"
        '
        'frmRegistrosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1451, 611)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSeleccion)
        Me.Controls.Add(Me.dtpFechaFinal)
        Me.Controls.Add(Me.dtpFechaInicial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDepartamento)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmRegistrosV2"
        Me.Text = "frmRegistrosV2"
        Me.TabControl1.ResumeLayout(False)
        Me.tabEmpl.ResumeLayout(False)
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReg.ResumeLayout(False)
        Me.tabReg.PerformLayout()
        CType(Me.dgvTipoIncidencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRegsDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.calculosES.ResumeLayout(False)
        Me.calculosES.PerformLayout()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCalculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.calculosCO.ResumeLayout(False)
        Me.calculosCO.PerformLayout()
        Me.tabRegManua.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        Me.SplitContainer8.Panel1.PerformLayout()
        Me.SplitContainer8.Panel2.ResumeLayout(False)
        Me.SplitContainer8.Panel2.PerformLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer8.ResumeLayout(False)
        CType(Me.dgvEmpleadoCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmpleadosADD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button6 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDepartamento As ComboBox
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabEmpl As TabPage
    Friend WithEvents dgvEmpleado As DataGridView
    Friend WithEvents tabReg As TabPage
    Friend WithEvents dgvRegsDia As DataGridView
    Friend WithEvents dgvPeriodo As DataGridView
    Friend WithEvents chbHorasLimiteHorasExtras As CheckBox
    Friend WithEvents btnProcesarHorasExtras As Button
    Friend WithEvents Label34 As Label
    Friend WithEvents lblSeleccion As TextBox
    Friend WithEvents chbHorasExtrasAutorizadas As CheckBox
    Friend WithEvents btnActualizarRegistros As Button
    Friend WithEvents txtNumHorasExtras As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents btnActHorasExtras As Button
    Friend WithEvents calculosES As TabPage
    Friend WithEvents Label36 As Label
    Friend WithEvents dgvExtras As DataGridView
    Friend WithEvents txtTFN As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtExcedente As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents dgvCalculos As DataGridView
    Friend WithEvents Button5 As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents txtTE As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtVD As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTHL As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtSSR As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtSSI As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPSGS As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtPGS As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtI As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtF As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtDP As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDF As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtD As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCHR As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCHET As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBJL As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtA As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents calculosCO As TabPage
    Friend WithEvents txtCocinaAsig As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtDescuentoXComidas As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtNumComidas As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents tabRegManua As TabPage
    Friend WithEvents SplitContainer8 As SplitContainer
    Friend WithEvents dgvEmpleadoCopy As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents chbConcervar As CheckBox
    Friend WithEvents cbDispositivo As ComboBox
    Friend WithEvents dgvEmpleadosADD As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents dtpRegManual As DateTimePicker
    Friend WithEvents txtComentario As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnRegInvalidos As ToolStripMenuItem
    Friend WithEvents btnInformes As ToolStripMenuItem
    Friend WithEvents btnIRegistros As ToolStripMenuItem
    Friend WithEvents btnIRImprimir As ToolStripMenuItem
    Friend WithEvents btnIRModificar As ToolStripMenuItem
    Friend WithEvents btnIIncidencias As ToolStripMenuItem
    Friend WithEvents btnIRDelEmpleado As ToolStripMenuItem
    Friend WithEvents btnIRDEImprimir As ToolStripMenuItem
    Friend WithEvents btnIRDEModificar As ToolStripMenuItem
    Friend WithEvents btnIRDelPeriodo As ToolStripMenuItem
    Friend WithEvents btnIRDPImprimir As ToolStripMenuItem
    Friend WithEvents btnIRDPModificar As ToolStripMenuItem
    Friend WithEvents btnRegAnt As ToolStripMenuItem
    Friend WithEvents btnRegSiguiente As ToolStripMenuItem
    Friend WithEvents btnImportar As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents dgvTipoIncidencia As DataGridView
    Friend WithEvents btnAdjuntosIncidencia As ToolStripMenuItem
    Friend WithEvents lbl1 As Label
    Friend WithEvents Label9 As Label
End Class
