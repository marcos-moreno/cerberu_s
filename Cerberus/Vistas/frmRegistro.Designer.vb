<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSeleccion2 = New System.Windows.Forms.Label()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.btnITiket = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnITiketMod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFaltasXPeriodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFaltasXPeriodoMod = New System.Windows.Forms.ToolStripMenuItem()
        Me.bteTiempoExtraXPeriodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bteModSem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bteModMes = New System.Windows.Forms.ToolStripMenuItem()
        Me.XAñoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bteModAnio = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardexTiempoExtraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bteModificarCardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRegAnt = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRegSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btePermisos_mg = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.incidenciasDep = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.HorasExtra = New System.Windows.Forms.TabPage()
        Me.txtPerfilCalculo = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbHorasLimiteHorasExtras = New System.Windows.Forms.CheckBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtNumHorasExtras = New System.Windows.Forms.TextBox()
        Me.chbHorasExtrasAutorizadas = New System.Windows.Forms.CheckBox()
        Me.btnActHorasExtras = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dgridCardex = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chbHorasLimiteHorasExtrasEmpleado = New System.Windows.Forms.CheckBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.chbHorasExtrAutEmpleado = New System.Windows.Forms.CheckBox()
        Me.btnActHorasExtrasEmpleado = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtHrsExtDefault = New System.Windows.Forms.TextBox()
        Me.tabRegManua = New System.Windows.Forms.TabPage()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgvEmpleadoCopy = New System.Windows.Forms.DataGridView()
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
        Me.calculosCO = New System.Windows.Forms.TabPage()
        Me.txtCocinaAsig = New System.Windows.Forms.TextBox()
        Me.txtDescuentoXComidas = New System.Windows.Forms.TextBox()
        Me.txtNumComidas = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.calculosES = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dgvExtras = New System.Windows.Forms.DataGridView()
        Me.txtTFN = New System.Windows.Forms.TextBox()
        Me.txtExcedente = New System.Windows.Forms.TextBox()
        Me.txtTE = New System.Windows.Forms.TextBox()
        Me.txtVD = New System.Windows.Forms.TextBox()
        Me.txtTHL = New System.Windows.Forms.TextBox()
        Me.txtSSR = New System.Windows.Forms.TextBox()
        Me.txtSSI = New System.Windows.Forms.TextBox()
        Me.txtPSGS = New System.Windows.Forms.TextBox()
        Me.txtPGS = New System.Windows.Forms.TextBox()
        Me.txtI = New System.Windows.Forms.TextBox()
        Me.txtF = New System.Windows.Forms.TextBox()
        Me.txtDP = New System.Windows.Forms.TextBox()
        Me.txtDF = New System.Windows.Forms.TextBox()
        Me.txtD = New System.Windows.Forms.TextBox()
        Me.txtCHR = New System.Windows.Forms.TextBox()
        Me.txtCHET = New System.Windows.Forms.TextBox()
        Me.txtBJL = New System.Windows.Forms.TextBox()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dgvCalculos = New System.Windows.Forms.DataGridView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabInciCal = New System.Windows.Forms.TabPage()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.dgvIncidenciasCalculadas = New System.Windows.Forms.DataGridView()
        Me.tabReg = New System.Windows.Forms.TabPage()
        Me.cbSemanaRegs = New System.Windows.Forms.ComboBox()
        Me.btnProcesarHorasExtras = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgR1 = New System.Windows.Forms.DataGridView()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.dgR4 = New System.Windows.Forms.DataGridView()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.dgR6 = New System.Windows.Forms.DataGridView()
        Me.lbl6 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.dgR2 = New System.Windows.Forms.DataGridView()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.dgR5 = New System.Windows.Forms.DataGridView()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.dgR7 = New System.Windows.Forms.DataGridView()
        Me.lbl7 = New System.Windows.Forms.Label()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.dgR3 = New System.Windows.Forms.DataGridView()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnAdjuntosIncidencia = New System.Windows.Forms.Button()
        Me.btnEliminarInci = New System.Windows.Forms.Button()
        Me.dgvIncidencia = New System.Windows.Forms.DataGridView()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.dtpFechaIncidencia = New System.Windows.Forms.DateTimePicker()
        Me.cbTipoIncidencia = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnActualizarRegistros = New System.Windows.Forms.Button()
        Me.tabEmpl = New System.Windows.Forms.TabPage()
        Me.dgvEmpleado = New System.Windows.Forms.DataGridView()
        Me.contenTabs = New System.Windows.Forms.TabControl()
        Me.bteInserRegisHO = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MenuStrip1.SuspendLayout()
        Me.HorasExtra.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgridCardex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tabRegManua.SuspendLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.Panel2.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        CType(Me.dgvEmpleadoCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmpleadosADD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.calculosCO.SuspendLayout()
        Me.calculosES.SuspendLayout()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCalculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInciCal.SuspendLayout()
        CType(Me.dgvIncidenciasCalculadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReg.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgR1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.dgR4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgR6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.dgR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        CType(Me.dgR5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgR7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.dgR3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIncidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmpl.SuspendLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contenTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSeleccion2
        '
        Me.lblSeleccion2.AutoSize = True
        Me.lblSeleccion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion2.Location = New System.Drawing.Point(103, 87)
        Me.lblSeleccion2.Name = "lblSeleccion2"
        Me.lblSeleccion2.Size = New System.Drawing.Size(126, 13)
        Me.lblSeleccion2.TabIndex = 36
        Me.lblSeleccion2.Text = "Nada - Seleccionado"
        '
        'cbPeriodo
        '
        Me.cbPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(106, 56)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(332, 21)
        Me.cbPeriodo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Periodo: "
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Enabled = False
        Me.dtpFechaInicial.Location = New System.Drawing.Point(451, 59)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaInicial.TabIndex = 4
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Enabled = False
        Me.dtpFechaFinal.Location = New System.Drawing.Point(678, 59)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaFinal.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(659, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "-"
        '
        'cbDepartamento
        '
        Me.cbDepartamento.BackColor = System.Drawing.Color.White
        Me.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(106, 30)
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(332, 21)
        Me.cbDepartamento.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Departamento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(452, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Buscador: "
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(516, 30)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(277, 20)
        Me.txtFiltro.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(816, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRegInvalidos, Me.btnInformes, Me.btnRegAnt, Me.btnRegSiguiente, Me.btnImportar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1250, 24)
        Me.MenuStrip1.TabIndex = 12
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
        Me.btnInformes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRegistros, Me.btnIIncidencias, Me.btnITiket, Me.btnFaltasXPeriodo, Me.bteTiempoExtraXPeriodo, Me.CardexTiempoExtraToolStripMenuItem})
        Me.btnInformes.Name = "btnInformes"
        Me.btnInformes.Size = New System.Drawing.Size(66, 20)
        Me.btnInformes.Text = "Informes"
        '
        'btnIRegistros
        '
        Me.btnIRegistros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRImprimir, Me.btnIRModificar})
        Me.btnIRegistros.Name = "btnIRegistros"
        Me.btnIRegistros.Size = New System.Drawing.Size(200, 22)
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
        '
        'btnIIncidencias
        '
        Me.btnIIncidencias.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIRDelEmpleado, Me.btnIRDelPeriodo})
        Me.btnIIncidencias.Name = "btnIIncidencias"
        Me.btnIIncidencias.Size = New System.Drawing.Size(200, 22)
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
        '
        'btnITiket
        '
        Me.btnITiket.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnITiketMod})
        Me.btnITiket.Name = "btnITiket"
        Me.btnITiket.Size = New System.Drawing.Size(200, 22)
        Me.btnITiket.Text = "Tiket"
        '
        'btnITiketMod
        '
        Me.btnITiketMod.Name = "btnITiketMod"
        Me.btnITiketMod.Size = New System.Drawing.Size(125, 22)
        Me.btnITiketMod.Text = "Modificar"
        '
        'btnFaltasXPeriodo
        '
        Me.btnFaltasXPeriodo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFaltasXPeriodoMod})
        Me.btnFaltasXPeriodo.Name = "btnFaltasXPeriodo"
        Me.btnFaltasXPeriodo.Size = New System.Drawing.Size(200, 22)
        Me.btnFaltasXPeriodo.Text = "Incidencias por Período"
        '
        'btnFaltasXPeriodoMod
        '
        Me.btnFaltasXPeriodoMod.Name = "btnFaltasXPeriodoMod"
        Me.btnFaltasXPeriodoMod.Size = New System.Drawing.Size(125, 22)
        Me.btnFaltasXPeriodoMod.Text = "Modificar"
        '
        'bteTiempoExtraXPeriodo
        '
        Me.bteTiempoExtraXPeriodo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarToolStripMenuItem, Me.XMesToolStripMenuItem, Me.XAñoToolStripMenuItem})
        Me.bteTiempoExtraXPeriodo.Name = "bteTiempoExtraXPeriodo"
        Me.bteTiempoExtraXPeriodo.Size = New System.Drawing.Size(200, 22)
        Me.bteTiempoExtraXPeriodo.Text = "Tiempo Extra  X Periodo"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bteModSem})
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ModificarToolStripMenuItem.Text = "X Semana"
        '
        'bteModSem
        '
        Me.bteModSem.Name = "bteModSem"
        Me.bteModSem.Size = New System.Drawing.Size(125, 22)
        Me.bteModSem.Text = "Modificar"
        '
        'XMesToolStripMenuItem
        '
        Me.XMesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bteModMes})
        Me.XMesToolStripMenuItem.Name = "XMesToolStripMenuItem"
        Me.XMesToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.XMesToolStripMenuItem.Text = "X mes"
        '
        'bteModMes
        '
        Me.bteModMes.Name = "bteModMes"
        Me.bteModMes.Size = New System.Drawing.Size(125, 22)
        Me.bteModMes.Text = "Modificar"
        '
        'XAñoToolStripMenuItem
        '
        Me.XAñoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bteModAnio})
        Me.XAñoToolStripMenuItem.Name = "XAñoToolStripMenuItem"
        Me.XAñoToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.XAñoToolStripMenuItem.Text = "X año"
        '
        'bteModAnio
        '
        Me.bteModAnio.Name = "bteModAnio"
        Me.bteModAnio.Size = New System.Drawing.Size(125, 22)
        Me.bteModAnio.Text = "Modificar"
        '
        'CardexTiempoExtraToolStripMenuItem
        '
        Me.CardexTiempoExtraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bteModificarCardex})
        Me.CardexTiempoExtraToolStripMenuItem.Name = "CardexTiempoExtraToolStripMenuItem"
        Me.CardexTiempoExtraToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.CardexTiempoExtraToolStripMenuItem.Text = "Cardex Tiempo Extra"
        '
        'bteModificarCardex
        '
        Me.bteModificarCardex.Name = "bteModificarCardex"
        Me.bteModificarCardex.Size = New System.Drawing.Size(125, 22)
        Me.bteModificarCardex.Text = "Modificar"
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
        'btnImportar
        '
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(119, 20)
        Me.btnImportar.Text = "Importar ARCHIVO"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(906, 27)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Limpiar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btePermisos_mg
        '
        Me.btePermisos_mg.Depth = 0
        Me.btePermisos_mg.Location = New System.Drawing.Point(512, 87)
        Me.btePermisos_mg.MouseState = MaterialSkin.MouseState.HOVER
        Me.btePermisos_mg.Name = "btePermisos_mg"
        Me.btePermisos_mg.Primary = True
        Me.btePermisos_mg.Size = New System.Drawing.Size(157, 18)
        Me.btePermisos_mg.TabIndex = 37
        Me.btePermisos_mg.Text = "Permisos"
        Me.btePermisos_mg.UseVisualStyleBackColor = True
        '
        'incidenciasDep
        '
        Me.incidenciasDep.Depth = 0
        Me.incidenciasDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.incidenciasDep.Location = New System.Drawing.Point(678, 87)
        Me.incidenciasDep.MouseState = MaterialSkin.MouseState.HOVER
        Me.incidenciasDep.Name = "incidenciasDep"
        Me.incidenciasDep.Primary = True
        Me.incidenciasDep.Size = New System.Drawing.Size(253, 18)
        Me.incidenciasDep.TabIndex = 38
        Me.incidenciasDep.Text = "Incidencias del Departamento"
        Me.incidenciasDep.UseVisualStyleBackColor = True
        '
        'HorasExtra
        '
        Me.HorasExtra.Controls.Add(Me.txtPerfilCalculo)
        Me.HorasExtra.Controls.Add(Me.GroupBox3)
        Me.HorasExtra.Controls.Add(Me.dgridCardex)
        Me.HorasExtra.Controls.Add(Me.GroupBox2)
        Me.HorasExtra.Location = New System.Drawing.Point(4, 22)
        Me.HorasExtra.Name = "HorasExtra"
        Me.HorasExtra.Padding = New System.Windows.Forms.Padding(3)
        Me.HorasExtra.Size = New System.Drawing.Size(1218, 534)
        Me.HorasExtra.TabIndex = 6
        Me.HorasExtra.Text = "Horas Extra"
        Me.HorasExtra.UseVisualStyleBackColor = True
        '
        'txtPerfilCalculo
        '
        Me.txtPerfilCalculo.AutoSize = True
        Me.txtPerfilCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerfilCalculo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPerfilCalculo.Location = New System.Drawing.Point(14, 463)
        Me.txtPerfilCalculo.Name = "txtPerfilCalculo"
        Me.txtPerfilCalculo.Size = New System.Drawing.Size(102, 13)
        Me.txtPerfilCalculo.TabIndex = 36
        Me.txtPerfilCalculo.Text = "Perfil De Cálculo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chbHorasLimiteHorasExtras)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.txtNumHorasExtras)
        Me.GroupBox3.Controls.Add(Me.chbHorasExtrasAutorizadas)
        Me.GroupBox3.Controls.Add(Me.btnActHorasExtras)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(331, 430)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aplica solo para la semana seleccionada"
        '
        'chbHorasLimiteHorasExtras
        '
        Me.chbHorasLimiteHorasExtras.AutoSize = True
        Me.chbHorasLimiteHorasExtras.Enabled = False
        Me.chbHorasLimiteHorasExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbHorasLimiteHorasExtras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chbHorasLimiteHorasExtras.Location = New System.Drawing.Point(6, 77)
        Me.chbHorasLimiteHorasExtras.Name = "chbHorasLimiteHorasExtras"
        Me.chbHorasLimiteHorasExtras.Size = New System.Drawing.Size(152, 17)
        Me.chbHorasLimiteHorasExtras.TabIndex = 33
        Me.chbHorasLimiteHorasExtras.Text = "Límite de horas extras"
        Me.chbHorasLimiteHorasExtras.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(3, 37)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(301, 13)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "(Al no activar se pagarán todas las hrs. generadas) "
        '
        'txtNumHorasExtras
        '
        Me.txtNumHorasExtras.Enabled = False
        Me.txtNumHorasExtras.Location = New System.Drawing.Point(6, 228)
        Me.txtNumHorasExtras.Name = "txtNumHorasExtras"
        Me.txtNumHorasExtras.Size = New System.Drawing.Size(97, 20)
        Me.txtNumHorasExtras.TabIndex = 31
        '
        'chbHorasExtrasAutorizadas
        '
        Me.chbHorasExtrasAutorizadas.AutoSize = True
        Me.chbHorasExtrasAutorizadas.Location = New System.Drawing.Point(6, 147)
        Me.chbHorasExtrasAutorizadas.Name = "chbHorasExtrasAutorizadas"
        Me.chbHorasExtrasAutorizadas.Size = New System.Drawing.Size(167, 30)
        Me.chbHorasExtrasAutorizadas.TabIndex = 32
        Me.chbHorasExtrasAutorizadas.Text = "Permitir Generar Horas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despues del horario de Salida"
        Me.chbHorasExtrasAutorizadas.UseVisualStyleBackColor = True
        '
        'btnActHorasExtras
        '
        Me.btnActHorasExtras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActHorasExtras.Enabled = False
        Me.btnActHorasExtras.Location = New System.Drawing.Point(6, 300)
        Me.btnActHorasExtras.Name = "btnActHorasExtras"
        Me.btnActHorasExtras.Size = New System.Drawing.Size(264, 29)
        Me.btnActHorasExtras.TabIndex = 34
        Me.btnActHorasExtras.Text = "Actualizar hrs. del empleado en el périodo"
        Me.btnActHorasExtras.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 212)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(130, 13)
        Me.Label33.TabIndex = 30
        Me.Label33.Text = "Limite de Horas (Decimal):"
        '
        'dgridCardex
        '
        Me.dgridCardex.AllowUserToAddRows = False
        Me.dgridCardex.AllowUserToDeleteRows = False
        Me.dgridCardex.AllowUserToResizeRows = False
        Me.dgridCardex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgridCardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgridCardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgridCardex.Location = New System.Drawing.Point(733, 20)
        Me.dgridCardex.MultiSelect = False
        Me.dgridCardex.Name = "dgridCardex"
        Me.dgridCardex.ReadOnly = True
        Me.dgridCardex.RowHeadersVisible = False
        Me.dgridCardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgridCardex.Size = New System.Drawing.Size(479, 430)
        Me.dgridCardex.TabIndex = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chbHorasLimiteHorasExtrasEmpleado)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.chbHorasExtrAutEmpleado)
        Me.GroupBox2.Controls.Add(Me.btnActHorasExtrasEmpleado)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.txtHrsExtDefault)
        Me.GroupBox2.Location = New System.Drawing.Point(350, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(377, 430)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Horas autorizadas default"
        '
        'chbHorasLimiteHorasExtrasEmpleado
        '
        Me.chbHorasLimiteHorasExtrasEmpleado.AutoSize = True
        Me.chbHorasLimiteHorasExtrasEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbHorasLimiteHorasExtrasEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chbHorasLimiteHorasExtrasEmpleado.Location = New System.Drawing.Point(12, 77)
        Me.chbHorasLimiteHorasExtrasEmpleado.Name = "chbHorasLimiteHorasExtrasEmpleado"
        Me.chbHorasLimiteHorasExtrasEmpleado.Size = New System.Drawing.Size(146, 17)
        Me.chbHorasLimiteHorasExtrasEmpleado.TabIndex = 37
        Me.chbHorasLimiteHorasExtrasEmpleado.Text = "Límite de horas extra"
        Me.chbHorasLimiteHorasExtrasEmpleado.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(9, 25)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(348, 13)
        Me.Label38.TabIndex = 39
        Me.Label38.Text = "Las horas asignadas se tomarán por default a cada semana."
        '
        'chbHorasExtrAutEmpleado
        '
        Me.chbHorasExtrAutEmpleado.AutoSize = True
        Me.chbHorasExtrAutEmpleado.Location = New System.Drawing.Point(12, 147)
        Me.chbHorasExtrAutEmpleado.Name = "chbHorasExtrAutEmpleado"
        Me.chbHorasExtrAutEmpleado.Size = New System.Drawing.Size(167, 30)
        Me.chbHorasExtrAutEmpleado.TabIndex = 36
        Me.chbHorasExtrAutEmpleado.Text = "Permitir Generar Horas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despues del horario de Salida"
        Me.chbHorasExtrAutEmpleado.UseVisualStyleBackColor = True
        '
        'btnActHorasExtrasEmpleado
        '
        Me.btnActHorasExtrasEmpleado.Location = New System.Drawing.Point(16, 300)
        Me.btnActHorasExtrasEmpleado.Name = "btnActHorasExtrasEmpleado"
        Me.btnActHorasExtrasEmpleado.Size = New System.Drawing.Size(200, 29)
        Me.btnActHorasExtrasEmpleado.TabIndex = 38
        Me.btnActHorasExtrasEmpleado.Text = "Actualizar hrs. del empleado"
        Me.btnActHorasExtrasEmpleado.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(13, 212)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 13)
        Me.Label37.TabIndex = 36
        Me.Label37.Text = "Horas Autorizadas:"
        '
        'txtHrsExtDefault
        '
        Me.txtHrsExtDefault.Location = New System.Drawing.Point(12, 228)
        Me.txtHrsExtDefault.Name = "txtHrsExtDefault"
        Me.txtHrsExtDefault.Size = New System.Drawing.Size(97, 20)
        Me.txtHrsExtDefault.TabIndex = 37
        '
        'tabRegManua
        '
        Me.tabRegManua.Controls.Add(Me.SplitContainer8)
        Me.tabRegManua.Location = New System.Drawing.Point(4, 22)
        Me.tabRegManua.Name = "tabRegManua"
        Me.tabRegManua.Size = New System.Drawing.Size(1218, 534)
        Me.tabRegManua.TabIndex = 2
        Me.tabRegManua.Text = "Registros Manuales"
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
        Me.SplitContainer8.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer8.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer8.Panel1.Controls.Add(Me.dgvEmpleadoCopy)
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
        Me.SplitContainer8.Size = New System.Drawing.Size(1322, 506)
        Me.SplitContainer8.SplitterDistance = 791
        Me.SplitContainer8.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Empleados"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(673, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Agregar >>"
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.dgvEmpleadoCopy.Location = New System.Drawing.Point(13, 40)
        Me.dgvEmpleadoCopy.MultiSelect = False
        Me.dgvEmpleadoCopy.Name = "dgvEmpleadoCopy"
        Me.dgvEmpleadoCopy.ReadOnly = True
        Me.dgvEmpleadoCopy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleadoCopy.Size = New System.Drawing.Size(761, 453)
        Me.dgvEmpleadoCopy.TabIndex = 3
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
        Me.dgvEmpleadosADD.Location = New System.Drawing.Point(17, 100)
        Me.dgvEmpleadosADD.MultiSelect = False
        Me.dgvEmpleadosADD.Name = "dgvEmpleadosADD"
        Me.dgvEmpleadosADD.ReadOnly = True
        Me.dgvEmpleadosADD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleadosADD.Size = New System.Drawing.Size(495, 393)
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
        'calculosCO
        '
        Me.calculosCO.Controls.Add(Me.txtCocinaAsig)
        Me.calculosCO.Controls.Add(Me.txtDescuentoXComidas)
        Me.calculosCO.Controls.Add(Me.txtNumComidas)
        Me.calculosCO.Controls.Add(Me.Label30)
        Me.calculosCO.Controls.Add(Me.Label29)
        Me.calculosCO.Controls.Add(Me.Label28)
        Me.calculosCO.Location = New System.Drawing.Point(4, 22)
        Me.calculosCO.Name = "calculosCO"
        Me.calculosCO.Size = New System.Drawing.Size(1218, 534)
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
        'txtDescuentoXComidas
        '
        Me.txtDescuentoXComidas.Location = New System.Drawing.Point(165, 96)
        Me.txtDescuentoXComidas.Name = "txtDescuentoXComidas"
        Me.txtDescuentoXComidas.ReadOnly = True
        Me.txtDescuentoXComidas.Size = New System.Drawing.Size(117, 20)
        Me.txtDescuentoXComidas.TabIndex = 47
        '
        'txtNumComidas
        '
        Me.txtNumComidas.Location = New System.Drawing.Point(165, 70)
        Me.txtNumComidas.Name = "txtNumComidas"
        Me.txtNumComidas.ReadOnly = True
        Me.txtNumComidas.Size = New System.Drawing.Size(117, 20)
        Me.txtNumComidas.TabIndex = 45
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
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(29, 99)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(121, 13)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "Descuento X Comida(s):"
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
        'calculosES
        '
        Me.calculosES.Controls.Add(Me.Label36)
        Me.calculosES.Controls.Add(Me.dgvExtras)
        Me.calculosES.Controls.Add(Me.txtTFN)
        Me.calculosES.Controls.Add(Me.txtExcedente)
        Me.calculosES.Controls.Add(Me.txtTE)
        Me.calculosES.Controls.Add(Me.txtVD)
        Me.calculosES.Controls.Add(Me.txtTHL)
        Me.calculosES.Controls.Add(Me.txtSSR)
        Me.calculosES.Controls.Add(Me.txtSSI)
        Me.calculosES.Controls.Add(Me.txtPSGS)
        Me.calculosES.Controls.Add(Me.txtPGS)
        Me.calculosES.Controls.Add(Me.txtI)
        Me.calculosES.Controls.Add(Me.txtF)
        Me.calculosES.Controls.Add(Me.txtDP)
        Me.calculosES.Controls.Add(Me.txtDF)
        Me.calculosES.Controls.Add(Me.txtD)
        Me.calculosES.Controls.Add(Me.txtCHR)
        Me.calculosES.Controls.Add(Me.txtCHET)
        Me.calculosES.Controls.Add(Me.txtBJL)
        Me.calculosES.Controls.Add(Me.txtA)
        Me.calculosES.Controls.Add(Me.Label35)
        Me.calculosES.Controls.Add(Me.Label32)
        Me.calculosES.Controls.Add(Me.Button7)
        Me.calculosES.Controls.Add(Me.dgvCalculos)
        Me.calculosES.Controls.Add(Me.Button5)
        Me.calculosES.Controls.Add(Me.Label27)
        Me.calculosES.Controls.Add(Me.Label26)
        Me.calculosES.Controls.Add(Me.Label25)
        Me.calculosES.Controls.Add(Me.Label24)
        Me.calculosES.Controls.Add(Me.Label23)
        Me.calculosES.Controls.Add(Me.Label22)
        Me.calculosES.Controls.Add(Me.Label21)
        Me.calculosES.Controls.Add(Me.Label20)
        Me.calculosES.Controls.Add(Me.Label19)
        Me.calculosES.Controls.Add(Me.Label18)
        Me.calculosES.Controls.Add(Me.Label17)
        Me.calculosES.Controls.Add(Me.Label16)
        Me.calculosES.Controls.Add(Me.Label15)
        Me.calculosES.Controls.Add(Me.Label13)
        Me.calculosES.Controls.Add(Me.Label12)
        Me.calculosES.Controls.Add(Me.Label11)
        Me.calculosES.Controls.Add(Me.Label10)
        Me.calculosES.Location = New System.Drawing.Point(4, 22)
        Me.calculosES.Name = "calculosES"
        Me.calculosES.Size = New System.Drawing.Size(1218, 534)
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
        Me.dgvExtras.Size = New System.Drawing.Size(551, 272)
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
        'txtExcedente
        '
        Me.txtExcedente.Location = New System.Drawing.Point(733, 86)
        Me.txtExcedente.Name = "txtExcedente"
        Me.txtExcedente.ReadOnly = True
        Me.txtExcedente.Size = New System.Drawing.Size(117, 20)
        Me.txtExcedente.TabIndex = 39
        '
        'txtTE
        '
        Me.txtTE.Location = New System.Drawing.Point(733, 167)
        Me.txtTE.Name = "txtTE"
        Me.txtTE.ReadOnly = True
        Me.txtTE.Size = New System.Drawing.Size(117, 20)
        Me.txtTE.TabIndex = 32
        '
        'txtVD
        '
        Me.txtVD.Location = New System.Drawing.Point(733, 141)
        Me.txtVD.Name = "txtVD"
        Me.txtVD.ReadOnly = True
        Me.txtVD.Size = New System.Drawing.Size(117, 20)
        Me.txtVD.TabIndex = 30
        '
        'txtTHL
        '
        Me.txtTHL.Location = New System.Drawing.Point(733, 112)
        Me.txtTHL.Name = "txtTHL"
        Me.txtTHL.ReadOnly = True
        Me.txtTHL.Size = New System.Drawing.Size(117, 20)
        Me.txtTHL.TabIndex = 28
        '
        'txtSSR
        '
        Me.txtSSR.Location = New System.Drawing.Point(733, 33)
        Me.txtSSR.Name = "txtSSR"
        Me.txtSSR.ReadOnly = True
        Me.txtSSR.Size = New System.Drawing.Size(117, 20)
        Me.txtSSR.TabIndex = 26
        '
        'txtSSI
        '
        Me.txtSSI.Location = New System.Drawing.Point(733, 60)
        Me.txtSSI.Name = "txtSSI"
        Me.txtSSI.ReadOnly = True
        Me.txtSSI.Size = New System.Drawing.Size(117, 20)
        Me.txtSSI.TabIndex = 24
        '
        'txtPSGS
        '
        Me.txtPSGS.Location = New System.Drawing.Point(437, 164)
        Me.txtPSGS.Name = "txtPSGS"
        Me.txtPSGS.ReadOnly = True
        Me.txtPSGS.Size = New System.Drawing.Size(117, 20)
        Me.txtPSGS.TabIndex = 22
        '
        'txtPGS
        '
        Me.txtPGS.Location = New System.Drawing.Point(437, 138)
        Me.txtPGS.Name = "txtPGS"
        Me.txtPGS.ReadOnly = True
        Me.txtPGS.Size = New System.Drawing.Size(117, 20)
        Me.txtPGS.TabIndex = 20
        '
        'txtI
        '
        Me.txtI.Location = New System.Drawing.Point(437, 112)
        Me.txtI.Name = "txtI"
        Me.txtI.ReadOnly = True
        Me.txtI.Size = New System.Drawing.Size(117, 20)
        Me.txtI.TabIndex = 18
        '
        'txtF
        '
        Me.txtF.Location = New System.Drawing.Point(437, 86)
        Me.txtF.Name = "txtF"
        Me.txtF.ReadOnly = True
        Me.txtF.Size = New System.Drawing.Size(117, 20)
        Me.txtF.TabIndex = 16
        '
        'txtDP
        '
        Me.txtDP.Location = New System.Drawing.Point(437, 60)
        Me.txtDP.Name = "txtDP"
        Me.txtDP.ReadOnly = True
        Me.txtDP.Size = New System.Drawing.Size(117, 20)
        Me.txtDP.TabIndex = 14
        '
        'txtDF
        '
        Me.txtDF.Location = New System.Drawing.Point(437, 34)
        Me.txtDF.Name = "txtDF"
        Me.txtDF.ReadOnly = True
        Me.txtDF.Size = New System.Drawing.Size(117, 20)
        Me.txtDF.TabIndex = 12
        '
        'txtD
        '
        Me.txtD.Location = New System.Drawing.Point(147, 138)
        Me.txtD.Name = "txtD"
        Me.txtD.ReadOnly = True
        Me.txtD.Size = New System.Drawing.Size(117, 20)
        Me.txtD.TabIndex = 10
        '
        'txtCHR
        '
        Me.txtCHR.Location = New System.Drawing.Point(147, 112)
        Me.txtCHR.Name = "txtCHR"
        Me.txtCHR.ReadOnly = True
        Me.txtCHR.Size = New System.Drawing.Size(117, 20)
        Me.txtCHR.TabIndex = 8
        '
        'txtCHET
        '
        Me.txtCHET.Location = New System.Drawing.Point(147, 86)
        Me.txtCHET.Name = "txtCHET"
        Me.txtCHET.ReadOnly = True
        Me.txtCHET.Size = New System.Drawing.Size(117, 20)
        Me.txtCHET.TabIndex = 6
        '
        'txtBJL
        '
        Me.txtBJL.Location = New System.Drawing.Point(147, 60)
        Me.txtBJL.Name = "txtBJL"
        Me.txtBJL.ReadOnly = True
        Me.txtBJL.Size = New System.Drawing.Size(117, 20)
        Me.txtBJL.TabIndex = 4
        '
        'txtA
        '
        Me.txtA.Location = New System.Drawing.Point(147, 34)
        Me.txtA.Name = "txtA"
        Me.txtA.ReadOnly = True
        Me.txtA.Size = New System.Drawing.Size(117, 20)
        Me.txtA.TabIndex = 2
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
        Me.dgvCalculos.Size = New System.Drawing.Size(709, 290)
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(589, 170)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Tiempo Extra:"
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
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(589, 115)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Total horas Laboradas:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(589, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Salario Real:"
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
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(293, 167)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(128, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Permiso sin Goce Sueldo:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(293, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(133, 13)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Permiso con Goce Sueldo:"
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(293, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Faltas:"
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(293, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Dia(s) Festivo(s):"
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Costo Hora Real:"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Base Jornada Laboral:"
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
        'tabInciCal
        '
        Me.tabInciCal.Controls.Add(Me.Button9)
        Me.tabInciCal.Controls.Add(Me.dgvIncidenciasCalculadas)
        Me.tabInciCal.Location = New System.Drawing.Point(4, 22)
        Me.tabInciCal.Name = "tabInciCal"
        Me.tabInciCal.Size = New System.Drawing.Size(1218, 534)
        Me.tabInciCal.TabIndex = 5
        Me.tabInciCal.Text = "Incidencias Calculadas"
        Me.tabInciCal.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(12, 10)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(177, 23)
        Me.Button9.TabIndex = 33
        Me.Button9.Text = "Procesar Incidencias"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'dgvIncidenciasCalculadas
        '
        Me.dgvIncidenciasCalculadas.AllowUserToAddRows = False
        Me.dgvIncidenciasCalculadas.AllowUserToDeleteRows = False
        Me.dgvIncidenciasCalculadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIncidenciasCalculadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIncidenciasCalculadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidenciasCalculadas.Location = New System.Drawing.Point(12, 39)
        Me.dgvIncidenciasCalculadas.MultiSelect = False
        Me.dgvIncidenciasCalculadas.Name = "dgvIncidenciasCalculadas"
        Me.dgvIncidenciasCalculadas.ReadOnly = True
        Me.dgvIncidenciasCalculadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIncidenciasCalculadas.Size = New System.Drawing.Size(1275, 478)
        Me.dgvIncidenciasCalculadas.TabIndex = 32
        '
        'tabReg
        '
        Me.tabReg.Controls.Add(Me.bteInserRegisHO)
        Me.tabReg.Controls.Add(Me.cbSemanaRegs)
        Me.tabReg.Controls.Add(Me.btnProcesarHorasExtras)
        Me.tabReg.Controls.Add(Me.Label31)
        Me.tabReg.Controls.Add(Me.SplitContainer1)
        Me.tabReg.Controls.Add(Me.btnActualizarRegistros)
        Me.tabReg.Location = New System.Drawing.Point(4, 22)
        Me.tabReg.Name = "tabReg"
        Me.tabReg.Padding = New System.Windows.Forms.Padding(3)
        Me.tabReg.Size = New System.Drawing.Size(1218, 534)
        Me.tabReg.TabIndex = 1
        Me.tabReg.Text = "Registros"
        Me.tabReg.UseVisualStyleBackColor = True
        '
        'cbSemanaRegs
        '
        Me.cbSemanaRegs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSemanaRegs.FormattingEnabled = True
        Me.cbSemanaRegs.Location = New System.Drawing.Point(488, 11)
        Me.cbSemanaRegs.Name = "cbSemanaRegs"
        Me.cbSemanaRegs.Size = New System.Drawing.Size(271, 21)
        Me.cbSemanaRegs.TabIndex = 13
        '
        'btnProcesarHorasExtras
        '
        Me.btnProcesarHorasExtras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarHorasExtras.Location = New System.Drawing.Point(216, 10)
        Me.btnProcesarHorasExtras.Name = "btnProcesarHorasExtras"
        Me.btnProcesarHorasExtras.Size = New System.Drawing.Size(266, 24)
        Me.btnProcesarHorasExtras.TabIndex = 59
        Me.btnProcesarHorasExtras.Text = "Procesar Horas (Extra-Salidas, Entradas, Comidas)"
        Me.btnProcesarHorasExtras.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(17, 37)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(742, 13)
        Me.Label31.TabIndex = 29
        Me.Label31.Text = "* Si se modifican los registros se debe de volver a correr el calculo de pago, pa" &
    "ra que los cambios monetarios se vean reflejados."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(20, 53)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1217, 475)
        Me.SplitContainer1.SplitterDistance = 386
        Me.SplitContainer1.TabIndex = 28
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgR1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer6)
        Me.SplitContainer2.Size = New System.Drawing.Size(386, 475)
        Me.SplitContainer2.SplitterDistance = 158
        Me.SplitContainer2.TabIndex = 0
        '
        'dgR1
        '
        Me.dgR1.AllowUserToAddRows = False
        Me.dgR1.AllowUserToDeleteRows = False
        Me.dgR1.AllowUserToResizeRows = False
        Me.dgR1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR1.Location = New System.Drawing.Point(20, 24)
        Me.dgR1.MultiSelect = False
        Me.dgR1.Name = "dgR1"
        Me.dgR1.ReadOnly = True
        Me.dgR1.RowHeadersVisible = False
        Me.dgR1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR1.Size = New System.Drawing.Size(349, 127)
        Me.dgR1.TabIndex = 2
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(18, 8)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(36, 13)
        Me.lbl1.TabIndex = 11
        Me.lbl1.Text = "Lunes"
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.dgR4)
        Me.SplitContainer6.Panel1.Controls.Add(Me.lbl4)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.dgR6)
        Me.SplitContainer6.Panel2.Controls.Add(Me.lbl6)
        Me.SplitContainer6.Size = New System.Drawing.Size(386, 313)
        Me.SplitContainer6.SplitterDistance = 154
        Me.SplitContainer6.TabIndex = 0
        '
        'dgR4
        '
        Me.dgR4.AllowUserToAddRows = False
        Me.dgR4.AllowUserToDeleteRows = False
        Me.dgR4.AllowUserToResizeRows = False
        Me.dgR4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR4.Location = New System.Drawing.Point(21, 24)
        Me.dgR4.MultiSelect = False
        Me.dgR4.Name = "dgR4"
        Me.dgR4.ReadOnly = True
        Me.dgR4.RowHeadersVisible = False
        Me.dgR4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR4.Size = New System.Drawing.Size(348, 125)
        Me.dgR4.TabIndex = 6
        '
        'lbl4
        '
        Me.lbl4.AutoSize = True
        Me.lbl4.Location = New System.Drawing.Point(18, 8)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(41, 13)
        Me.lbl4.TabIndex = 12
        Me.lbl4.Text = "Jueves"
        '
        'dgR6
        '
        Me.dgR6.AllowUserToAddRows = False
        Me.dgR6.AllowUserToDeleteRows = False
        Me.dgR6.AllowUserToResizeRows = False
        Me.dgR6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR6.Location = New System.Drawing.Point(21, 18)
        Me.dgR6.MultiSelect = False
        Me.dgR6.Name = "dgR6"
        Me.dgR6.ReadOnly = True
        Me.dgR6.RowHeadersVisible = False
        Me.dgR6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR6.Size = New System.Drawing.Size(348, 132)
        Me.dgR6.TabIndex = 8
        '
        'lbl6
        '
        Me.lbl6.AutoSize = True
        Me.lbl6.Location = New System.Drawing.Point(18, 2)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(44, 13)
        Me.lbl6.TabIndex = 13
        Me.lbl6.Text = "Sabado"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer3.Size = New System.Drawing.Size(827, 475)
        Me.SplitContainer3.SplitterDistance = 372
        Me.SplitContainer3.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.dgR2)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lbl2)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer7)
        Me.SplitContainer4.Size = New System.Drawing.Size(372, 475)
        Me.SplitContainer4.SplitterDistance = 160
        Me.SplitContainer4.TabIndex = 0
        '
        'dgR2
        '
        Me.dgR2.AllowUserToAddRows = False
        Me.dgR2.AllowUserToDeleteRows = False
        Me.dgR2.AllowUserToResizeRows = False
        Me.dgR2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR2.Location = New System.Drawing.Point(13, 24)
        Me.dgR2.MultiSelect = False
        Me.dgR2.Name = "dgR2"
        Me.dgR2.ReadOnly = True
        Me.dgR2.RowHeadersVisible = False
        Me.dgR2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR2.Size = New System.Drawing.Size(348, 130)
        Me.dgR2.TabIndex = 5
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(11, 8)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(39, 13)
        Me.lbl2.TabIndex = 16
        Me.lbl2.Text = "Martes"
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.dgR5)
        Me.SplitContainer7.Panel1.Controls.Add(Me.lbl5)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.dgR7)
        Me.SplitContainer7.Panel2.Controls.Add(Me.lbl7)
        Me.SplitContainer7.Size = New System.Drawing.Size(372, 311)
        Me.SplitContainer7.SplitterDistance = 155
        Me.SplitContainer7.TabIndex = 0
        '
        'dgR5
        '
        Me.dgR5.AllowUserToAddRows = False
        Me.dgR5.AllowUserToDeleteRows = False
        Me.dgR5.AllowUserToResizeRows = False
        Me.dgR5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR5.Location = New System.Drawing.Point(14, 25)
        Me.dgR5.MultiSelect = False
        Me.dgR5.Name = "dgR5"
        Me.dgR5.ReadOnly = True
        Me.dgR5.RowHeadersVisible = False
        Me.dgR5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR5.Size = New System.Drawing.Size(348, 126)
        Me.dgR5.TabIndex = 7
        '
        'lbl5
        '
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(11, 9)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(42, 13)
        Me.lbl5.TabIndex = 15
        Me.lbl5.Text = "Viernes"
        '
        'dgR7
        '
        Me.dgR7.AllowUserToAddRows = False
        Me.dgR7.AllowUserToDeleteRows = False
        Me.dgR7.AllowUserToResizeRows = False
        Me.dgR7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR7.Location = New System.Drawing.Point(13, 19)
        Me.dgR7.MultiSelect = False
        Me.dgR7.Name = "dgR7"
        Me.dgR7.ReadOnly = True
        Me.dgR7.RowHeadersVisible = False
        Me.dgR7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR7.Size = New System.Drawing.Size(348, 127)
        Me.dgR7.TabIndex = 9
        '
        'lbl7
        '
        Me.lbl7.AutoSize = True
        Me.lbl7.Location = New System.Drawing.Point(11, 3)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Size = New System.Drawing.Size(49, 13)
        Me.lbl7.TabIndex = 14
        Me.lbl7.Text = "Domingo"
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.dgR3)
        Me.SplitContainer5.Panel1.Controls.Add(Me.lbl3)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.Button10)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Button8)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnAdjuntosIncidencia)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnEliminarInci)
        Me.SplitContainer5.Panel2.Controls.Add(Me.dgvIncidencia)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnActualizar)
        Me.SplitContainer5.Panel2.Controls.Add(Me.dtpFechaIncidencia)
        Me.SplitContainer5.Panel2.Controls.Add(Me.cbTipoIncidencia)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer5.Size = New System.Drawing.Size(451, 475)
        Me.SplitContainer5.SplitterDistance = 160
        Me.SplitContainer5.TabIndex = 0
        '
        'dgR3
        '
        Me.dgR3.AllowUserToAddRows = False
        Me.dgR3.AllowUserToDeleteRows = False
        Me.dgR3.AllowUserToResizeRows = False
        Me.dgR3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgR3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgR3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgR3.Location = New System.Drawing.Point(12, 24)
        Me.dgR3.MultiSelect = False
        Me.dgR3.Name = "dgR3"
        Me.dgR3.ReadOnly = True
        Me.dgR3.RowHeadersVisible = False
        Me.dgR3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgR3.Size = New System.Drawing.Size(391, 128)
        Me.dgR3.TabIndex = 10
        '
        'lbl3
        '
        Me.lbl3.AutoSize = True
        Me.lbl3.Location = New System.Drawing.Point(9, 8)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(52, 13)
        Me.lbl3.TabIndex = 17
        Me.lbl3.Text = "Miercoles"
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(329, 52)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(80, 23)
        Me.Button10.TabIndex = 38
        Me.Button10.Text = "Regla San."
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Location = New System.Drawing.Point(253, 52)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(70, 23)
        Me.Button8.TabIndex = 37
        Me.Button8.Text = "+ Ver mas"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btnAdjuntosIncidencia
        '
        Me.btnAdjuntosIncidencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjuntosIncidencia.Location = New System.Drawing.Point(167, 52)
        Me.btnAdjuntosIncidencia.Name = "btnAdjuntosIncidencia"
        Me.btnAdjuntosIncidencia.Size = New System.Drawing.Size(80, 23)
        Me.btnAdjuntosIncidencia.TabIndex = 29
        Me.btnAdjuntosIncidencia.Text = "Adjuntos"
        Me.btnAdjuntosIncidencia.UseVisualStyleBackColor = True
        '
        'btnEliminarInci
        '
        Me.btnEliminarInci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarInci.Enabled = False
        Me.btnEliminarInci.Location = New System.Drawing.Point(95, 52)
        Me.btnEliminarInci.Name = "btnEliminarInci"
        Me.btnEliminarInci.Size = New System.Drawing.Size(66, 23)
        Me.btnEliminarInci.TabIndex = 28
        Me.btnEliminarInci.Text = "Eliminar"
        Me.btnEliminarInci.UseVisualStyleBackColor = True
        '
        'dgvIncidencia
        '
        Me.dgvIncidencia.AllowUserToAddRows = False
        Me.dgvIncidencia.AllowUserToDeleteRows = False
        Me.dgvIncidencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIncidencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIncidencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidencia.Location = New System.Drawing.Point(11, 86)
        Me.dgvIncidencia.MultiSelect = False
        Me.dgvIncidencia.Name = "dgvIncidencia"
        Me.dgvIncidencia.ReadOnly = True
        Me.dgvIncidencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIncidencia.Size = New System.Drawing.Size(410, 212)
        Me.dgvIncidencia.TabIndex = 27
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.Location = New System.Drawing.Point(14, 52)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 26
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'dtpFechaIncidencia
        '
        Me.dtpFechaIncidencia.CustomFormat = ""
        Me.dtpFechaIncidencia.Enabled = False
        Me.dtpFechaIncidencia.Location = New System.Drawing.Point(12, 26)
        Me.dtpFechaIncidencia.Name = "dtpFechaIncidencia"
        Me.dtpFechaIncidencia.Size = New System.Drawing.Size(201, 20)
        Me.dtpFechaIncidencia.TabIndex = 23
        '
        'cbTipoIncidencia
        '
        Me.cbTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIncidencia.Enabled = False
        Me.cbTipoIncidencia.FormattingEnabled = True
        Me.cbTipoIncidencia.Location = New System.Drawing.Point(233, 25)
        Me.cbTipoIncidencia.Name = "cbTipoIncidencia"
        Me.cbTipoIncidencia.Size = New System.Drawing.Size(191, 21)
        Me.cbTipoIncidencia.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(230, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Incidencia:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Fecha: "
        '
        'btnActualizarRegistros
        '
        Me.btnActualizarRegistros.Location = New System.Drawing.Point(20, 11)
        Me.btnActualizarRegistros.Name = "btnActualizarRegistros"
        Me.btnActualizarRegistros.Size = New System.Drawing.Size(190, 23)
        Me.btnActualizarRegistros.TabIndex = 13
        Me.btnActualizarRegistros.Text = "Activar / Desactivar Registro"
        Me.btnActualizarRegistros.UseVisualStyleBackColor = True
        '
        'tabEmpl
        '
        Me.tabEmpl.Controls.Add(Me.dgvEmpleado)
        Me.tabEmpl.Location = New System.Drawing.Point(4, 22)
        Me.tabEmpl.Name = "tabEmpl"
        Me.tabEmpl.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmpl.Size = New System.Drawing.Size(1218, 534)
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
        Me.dgvEmpleado.Location = New System.Drawing.Point(6, 6)
        Me.dgvEmpleado.MultiSelect = False
        Me.dgvEmpleado.Name = "dgvEmpleado"
        Me.dgvEmpleado.ReadOnly = True
        Me.dgvEmpleado.RowHeadersVisible = False
        Me.dgvEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleado.Size = New System.Drawing.Size(1206, 522)
        Me.dgvEmpleado.TabIndex = 1
        '
        'contenTabs
        '
        Me.contenTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contenTabs.Controls.Add(Me.tabEmpl)
        Me.contenTabs.Controls.Add(Me.tabReg)
        Me.contenTabs.Controls.Add(Me.HorasExtra)
        Me.contenTabs.Controls.Add(Me.tabInciCal)
        Me.contenTabs.Controls.Add(Me.calculosES)
        Me.contenTabs.Controls.Add(Me.calculosCO)
        Me.contenTabs.Controls.Add(Me.tabRegManua)
        Me.contenTabs.Location = New System.Drawing.Point(12, 109)
        Me.contenTabs.Name = "contenTabs"
        Me.contenTabs.SelectedIndex = 0
        Me.contenTabs.Size = New System.Drawing.Size(1226, 560)
        Me.contenTabs.TabIndex = 0
        '
        'bteInserRegisHO
        '
        Me.bteInserRegisHO.Depth = 0
        Me.bteInserRegisHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteInserRegisHO.Location = New System.Drawing.Point(785, 11)
        Me.bteInserRegisHO.MouseState = MaterialSkin.MouseState.HOVER
        Me.bteInserRegisHO.Name = "bteInserRegisHO"
        Me.bteInserRegisHO.Primary = True
        Me.bteInserRegisHO.Size = New System.Drawing.Size(324, 23)
        Me.bteInserRegisHO.TabIndex = 61
        Me.bteInserRegisHO.Text = "Insertar Registros (Home Office)"
        Me.bteInserRegisHO.UseVisualStyleBackColor = True
        Me.bteInserRegisHO.Visible = False
        '
        'frmRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 681)
        Me.Controls.Add(Me.incidenciasDep)
        Me.Controls.Add(Me.btePermisos_mg)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFechaFinal)
        Me.Controls.Add(Me.dtpFechaInicial)
        Me.Controls.Add(Me.lblSeleccion2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDepartamento)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.contenTabs)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..:: Asistencia ::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.HorasExtra.ResumeLayout(False)
        Me.HorasExtra.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgridCardex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabRegManua.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        Me.SplitContainer8.Panel1.PerformLayout()
        Me.SplitContainer8.Panel2.ResumeLayout(False)
        Me.SplitContainer8.Panel2.PerformLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer8.ResumeLayout(False)
        CType(Me.dgvEmpleadoCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmpleadosADD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.calculosCO.ResumeLayout(False)
        Me.calculosCO.PerformLayout()
        Me.calculosES.ResumeLayout(False)
        Me.calculosES.PerformLayout()
        CType(Me.dgvExtras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCalculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInciCal.ResumeLayout(False)
        CType(Me.dgvIncidenciasCalculadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReg.ResumeLayout(False)
        Me.tabReg.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        CType(Me.dgR4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgR6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.dgR2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel1.PerformLayout()
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.Panel2.PerformLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.ResumeLayout(False)
        CType(Me.dgR5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgR7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        CType(Me.dgR3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIncidencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmpl.ResumeLayout(False)
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contenTabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbDepartamento As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnRegInvalidos As ToolStripMenuItem
    Friend WithEvents btnInformes As ToolStripMenuItem
    Friend WithEvents btnIRegistros As ToolStripMenuItem
    Friend WithEvents btnIRImprimir As ToolStripMenuItem
    Friend WithEvents btnIRModificar As ToolStripMenuItem
    Friend WithEvents lblSeleccion2 As Label
    Friend WithEvents btnRegAnt As ToolStripMenuItem
    Friend WithEvents btnRegSiguiente As ToolStripMenuItem
    Friend WithEvents Button6 As Button
    Friend WithEvents btnIIncidencias As ToolStripMenuItem
    Friend WithEvents btnIRDelEmpleado As ToolStripMenuItem
    Friend WithEvents btnIRDelPeriodo As ToolStripMenuItem
    Friend WithEvents btnIRDPImprimir As ToolStripMenuItem
    Friend WithEvents btnIRDPModificar As ToolStripMenuItem
    Friend WithEvents btnIRDEImprimir As ToolStripMenuItem
    Friend WithEvents btnIRDEModificar As ToolStripMenuItem
    Friend WithEvents btnImportar As ToolStripMenuItem
    Friend WithEvents btnITiket As ToolStripMenuItem
    Friend WithEvents btnITiketMod As ToolStripMenuItem
    Friend WithEvents btnFaltasXPeriodo As ToolStripMenuItem
    Friend WithEvents btnFaltasXPeriodoMod As ToolStripMenuItem
    Friend WithEvents btePermisos_mg As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents bteTiempoExtraXPeriodo As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XMesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XAñoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents bteModSem As ToolStripMenuItem
    Friend WithEvents bteModMes As ToolStripMenuItem
    Friend WithEvents bteModAnio As ToolStripMenuItem
    Friend WithEvents incidenciasDep As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents HorasExtra As TabPage
    Friend WithEvents Label34 As Label
    Friend WithEvents chbHorasExtrasAutorizadas As CheckBox
    Friend WithEvents Label33 As Label
    Friend WithEvents btnActHorasExtras As Button
    Friend WithEvents txtNumHorasExtras As TextBox
    Friend WithEvents tabRegManua As TabPage
    Friend WithEvents SplitContainer8 As SplitContainer
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
    Friend WithEvents calculosCO As TabPage
    Friend WithEvents txtCocinaAsig As TextBox
    Friend WithEvents txtDescuentoXComidas As TextBox
    Friend WithEvents txtNumComidas As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents calculosES As TabPage
    Friend WithEvents Label36 As Label
    Friend WithEvents dgvExtras As DataGridView
    Friend WithEvents txtTFN As TextBox
    Friend WithEvents txtExcedente As TextBox
    Friend WithEvents txtTE As TextBox
    Friend WithEvents txtVD As TextBox
    Friend WithEvents txtTHL As TextBox
    Friend WithEvents txtSSR As TextBox
    Friend WithEvents txtSSI As TextBox
    Friend WithEvents txtPSGS As TextBox
    Friend WithEvents txtPGS As TextBox
    Friend WithEvents txtI As TextBox
    Friend WithEvents txtF As TextBox
    Friend WithEvents txtDP As TextBox
    Friend WithEvents txtDF As TextBox
    Friend WithEvents txtD As TextBox
    Friend WithEvents txtCHR As TextBox
    Friend WithEvents txtCHET As TextBox
    Friend WithEvents txtBJL As TextBox
    Friend WithEvents txtA As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents dgvCalculos As DataGridView
    Friend WithEvents Button5 As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tabInciCal As TabPage
    Friend WithEvents Button9 As Button
    Friend WithEvents dgvIncidenciasCalculadas As DataGridView
    Friend WithEvents tabReg As TabPage
    Friend WithEvents cbSemanaRegs As ComboBox
    Friend WithEvents btnProcesarHorasExtras As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents dgR1 As DataGridView
    Friend WithEvents lbl1 As Label
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents dgR4 As DataGridView
    Friend WithEvents lbl4 As Label
    Friend WithEvents dgR6 As DataGridView
    Friend WithEvents lbl6 As Label
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents dgR2 As DataGridView
    Friend WithEvents lbl2 As Label
    Friend WithEvents SplitContainer7 As SplitContainer
    Friend WithEvents dgR5 As DataGridView
    Friend WithEvents lbl5 As Label
    Friend WithEvents dgR7 As DataGridView
    Friend WithEvents lbl7 As Label
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents dgR3 As DataGridView
    Friend WithEvents lbl3 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents btnAdjuntosIncidencia As Button
    Friend WithEvents btnEliminarInci As Button
    Friend WithEvents dgvIncidencia As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents dtpFechaIncidencia As DateTimePicker
    Friend WithEvents cbTipoIncidencia As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnActualizarRegistros As Button
    Friend WithEvents tabEmpl As TabPage
    Friend WithEvents dgvEmpleado As DataGridView
    Friend WithEvents contenTabs As TabControl
    Friend WithEvents Label37 As Label
    Friend WithEvents txtHrsExtDefault As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label38 As Label
    Friend WithEvents btnActHorasExtrasEmpleado As Button
    Friend WithEvents chbHorasLimiteHorasExtrasEmpleado As CheckBox
    Friend WithEvents chbHorasExtrAutEmpleado As CheckBox
    Friend WithEvents chbHorasLimiteHorasExtras As CheckBox
    Friend WithEvents dgridCardex As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CardexTiempoExtraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents bteModificarCardex As ToolStripMenuItem
    Friend WithEvents txtPerfilCalculo As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents dgvEmpleadoCopy As DataGridView
    Friend WithEvents bteInserRegisHO As MaterialSkin.Controls.MaterialRaisedButton
End Class
