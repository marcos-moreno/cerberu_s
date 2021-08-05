<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPeriodo
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
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarInformeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImpXEmpl = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImpConcentradoPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimirConcentradoAgrupado = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModXEmpl = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModConcentradoPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModConcentradoAgrupado = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cbPeriodoContpaqi = New System.Windows.Forms.ComboBox()
        Me.lblPeriodos = New System.Windows.Forms.Label()
        Me.txtDesface = New System.Windows.Forms.TextBox()
        Me.lblDesface = New System.Windows.Forms.Label()
        Me.btnBuscarAbono = New System.Windows.Forms.Button()
        Me.txtDescripConceptoAbono = New System.Windows.Forms.TextBox()
        Me.txtIDAbono = New System.Windows.Forms.TextBox()
        Me.btnBuscarCargo = New System.Windows.Forms.Button()
        Me.txtDescripConceptoCargo = New System.Windows.Forms.TextBox()
        Me.txtIDCargo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnProcesarIncidencias = New System.Windows.Forms.Button()
        Me.chbSoloPendientes = New System.Windows.Forms.CheckBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnXPeriodo = New System.Windows.Forms.Button()
        Me.btnComidaDuplicados = New System.Windows.Forms.Button()
        Me.btnBuscarDep = New System.Windows.Forms.Button()
        Me.btnProcesarHorasExtras = New System.Windows.Forms.Button()
        Me.txtDescripDep = New System.Windows.Forms.TextBox()
        Me.btnCerrarPeriodo = New System.Windows.Forms.Button()
        Me.txtIDDep = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbVarFormula = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEjercicio = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoPeriodo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.calculaXdep = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
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
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(144, 20)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.btnEliminar.Text = "Eliminar"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(61, 20)
        Me.bntGuardar.Text = "Guardar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.GenerarInformeToolStripMenuItem, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1192, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.btnNuevo.Text = "Nuevo"
        '
        'GenerarInformeToolStripMenuItem
        '
        Me.GenerarInformeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.ModificarToolStripMenuItem})
        Me.GenerarInformeToolStripMenuItem.Name = "GenerarInformeToolStripMenuItem"
        Me.GenerarInformeToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.GenerarInformeToolStripMenuItem.Text = "Informe"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImpXEmpl, Me.btnImpConcentradoPago, Me.btnImprimirConcentradoAgrupado})
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'btnImpXEmpl
        '
        Me.btnImpXEmpl.Name = "btnImpXEmpl"
        Me.btnImpXEmpl.Size = New System.Drawing.Size(173, 22)
        Me.btnImpXEmpl.Text = "X Empleado"
        '
        'btnImpConcentradoPago
        '
        Me.btnImpConcentradoPago.Name = "btnImpConcentradoPago"
        Me.btnImpConcentradoPago.Size = New System.Drawing.Size(173, 22)
        Me.btnImpConcentradoPago.Text = "Concentrado Pago"
        '
        'btnImprimirConcentradoAgrupado
        '
        Me.btnImprimirConcentradoAgrupado.Name = "btnImprimirConcentradoAgrupado"
        Me.btnImprimirConcentradoAgrupado.Size = New System.Drawing.Size(173, 22)
        Me.btnImprimirConcentradoAgrupado.Text = "Total Cocinas"
        Me.btnImprimirConcentradoAgrupado.Visible = False
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnModXEmpl, Me.btnModConcentradoPago, Me.btnModConcentradoAgrupado})
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'btnModXEmpl
        '
        Me.btnModXEmpl.Name = "btnModXEmpl"
        Me.btnModXEmpl.Size = New System.Drawing.Size(169, 22)
        Me.btnModXEmpl.Text = "X Empleado"
        '
        'btnModConcentradoPago
        '
        Me.btnModConcentradoPago.Name = "btnModConcentradoPago"
        Me.btnModConcentradoPago.Size = New System.Drawing.Size(169, 22)
        Me.btnModConcentradoPago.Text = "Concentado Pago"
        '
        'btnModConcentradoAgrupado
        '
        Me.btnModConcentradoAgrupado.Name = "btnModConcentradoAgrupado"
        Me.btnModConcentradoAgrupado.Size = New System.Drawing.Size(169, 22)
        Me.btnModConcentradoAgrupado.Text = "Total Cocinas"
        Me.btnModConcentradoAgrupado.Visible = False
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
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 510)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1192, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(119, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cbPeriodoContpaqi)
        Me.TabPage2.Controls.Add(Me.lblPeriodos)
        Me.TabPage2.Controls.Add(Me.txtDesface)
        Me.TabPage2.Controls.Add(Me.lblDesface)
        Me.TabPage2.Controls.Add(Me.btnBuscarAbono)
        Me.TabPage2.Controls.Add(Me.txtDescripConceptoAbono)
        Me.TabPage2.Controls.Add(Me.txtIDAbono)
        Me.TabPage2.Controls.Add(Me.btnBuscarCargo)
        Me.TabPage2.Controls.Add(Me.txtDescripConceptoCargo)
        Me.TabPage2.Controls.Add(Me.txtIDCargo)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.cbVarFormula)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtEjercicio)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtNoPeriodo)
        Me.TabPage2.Controls.Add(Me.txtNombre)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.DateTimePicker2)
        Me.TabPage2.Controls.Add(Me.DateTimePicker1)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(1160, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbPeriodoContpaqi
        '
        Me.cbPeriodoContpaqi.FormattingEnabled = True
        Me.cbPeriodoContpaqi.Location = New System.Drawing.Point(466, 201)
        Me.cbPeriodoContpaqi.Name = "cbPeriodoContpaqi"
        Me.cbPeriodoContpaqi.Size = New System.Drawing.Size(322, 21)
        Me.cbPeriodoContpaqi.TabIndex = 70
        '
        'lblPeriodos
        '
        Me.lblPeriodos.AutoSize = True
        Me.lblPeriodos.Location = New System.Drawing.Point(340, 201)
        Me.lblPeriodos.Name = "lblPeriodos"
        Me.lblPeriodos.Size = New System.Drawing.Size(103, 13)
        Me.lblPeriodos.TabIndex = 69
        Me.lblPeriodos.Text = "Periodo CONTPAQi:"
        '
        'txtDesface
        '
        Me.txtDesface.Location = New System.Drawing.Point(528, 175)
        Me.txtDesface.Name = "txtDesface"
        Me.txtDesface.Size = New System.Drawing.Size(106, 20)
        Me.txtDesface.TabIndex = 68
        '
        'lblDesface
        '
        Me.lblDesface.AutoSize = True
        Me.lblDesface.Location = New System.Drawing.Point(340, 178)
        Me.lblDesface.Name = "lblDesface"
        Me.lblDesface.Size = New System.Drawing.Size(182, 13)
        Me.lblDesface.TabIndex = 66
        Me.lblDesface.Text = "Dias desface CONTPAQi NOMINAS:"
        '
        'btnBuscarAbono
        '
        Me.btnBuscarAbono.Location = New System.Drawing.Point(793, 95)
        Me.btnBuscarAbono.Name = "btnBuscarAbono"
        Me.btnBuscarAbono.Size = New System.Drawing.Size(43, 23)
        Me.btnBuscarAbono.TabIndex = 65
        Me.btnBuscarAbono.Text = "..."
        Me.btnBuscarAbono.UseVisualStyleBackColor = True
        '
        'txtDescripConceptoAbono
        '
        Me.txtDescripConceptoAbono.Location = New System.Drawing.Point(521, 97)
        Me.txtDescripConceptoAbono.Name = "txtDescripConceptoAbono"
        Me.txtDescripConceptoAbono.ReadOnly = True
        Me.txtDescripConceptoAbono.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripConceptoAbono.TabIndex = 64
        '
        'txtIDAbono
        '
        Me.txtIDAbono.Location = New System.Drawing.Point(464, 97)
        Me.txtIDAbono.Name = "txtIDAbono"
        Me.txtIDAbono.ReadOnly = True
        Me.txtIDAbono.Size = New System.Drawing.Size(51, 20)
        Me.txtIDAbono.TabIndex = 63
        '
        'btnBuscarCargo
        '
        Me.btnBuscarCargo.Location = New System.Drawing.Point(793, 69)
        Me.btnBuscarCargo.Name = "btnBuscarCargo"
        Me.btnBuscarCargo.Size = New System.Drawing.Size(43, 23)
        Me.btnBuscarCargo.TabIndex = 62
        Me.btnBuscarCargo.Text = "..."
        Me.btnBuscarCargo.UseVisualStyleBackColor = True
        '
        'txtDescripConceptoCargo
        '
        Me.txtDescripConceptoCargo.Location = New System.Drawing.Point(521, 71)
        Me.txtDescripConceptoCargo.Name = "txtDescripConceptoCargo"
        Me.txtDescripConceptoCargo.ReadOnly = True
        Me.txtDescripConceptoCargo.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripConceptoCargo.TabIndex = 61
        '
        'txtIDCargo
        '
        Me.txtIDCargo.Location = New System.Drawing.Point(464, 71)
        Me.txtIDCargo.Name = "txtIDCargo"
        Me.txtIDCargo.ReadOnly = True
        Me.txtIDCargo.Size = New System.Drawing.Size(51, 20)
        Me.txtIDCargo.TabIndex = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Controls.Add(Me.calculaXdep)
        Me.GroupBox1.Controls.Add(Me.btnProcesarIncidencias)
        Me.GroupBox1.Controls.Add(Me.chbSoloPendientes)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnXPeriodo)
        Me.GroupBox1.Controls.Add(Me.btnComidaDuplicados)
        Me.GroupBox1.Controls.Add(Me.btnBuscarDep)
        Me.GroupBox1.Controls.Add(Me.btnProcesarHorasExtras)
        Me.GroupBox1.Controls.Add(Me.txtDescripDep)
        Me.GroupBox1.Controls.Add(Me.btnCerrarPeriodo)
        Me.GroupBox1.Controls.Add(Me.txtIDDep)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(17, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1124, 192)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Procesos:"
        '
        'btnProcesarIncidencias
        '
        Me.btnProcesarIncidencias.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnProcesarIncidencias.Location = New System.Drawing.Point(504, 120)
        Me.btnProcesarIncidencias.Name = "btnProcesarIncidencias"
        Me.btnProcesarIncidencias.Size = New System.Drawing.Size(256, 23)
        Me.btnProcesarIncidencias.TabIndex = 77
        Me.btnProcesarIncidencias.Text = "Procesar Incidencias"
        Me.btnProcesarIncidencias.UseVisualStyleBackColor = True
        '
        'chbSoloPendientes
        '
        Me.chbSoloPendientes.AutoSize = True
        Me.chbSoloPendientes.Checked = True
        Me.chbSoloPendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSoloPendientes.Location = New System.Drawing.Point(81, 68)
        Me.chbSoloPendientes.Name = "chbSoloPendientes"
        Me.chbSoloPendientes.Size = New System.Drawing.Size(188, 17)
        Me.chbSoloPendientes.TabIndex = 76
        Me.chbSoloPendientes.Text = "Procesar solo registros Pendientes"
        Me.chbSoloPendientes.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Location = New System.Drawing.Point(402, 36)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(65, 23)
        Me.btnLimpiar.TabIndex = 74
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnXPeriodo
        '
        Me.btnXPeriodo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnXPeriodo.Location = New System.Drawing.Point(504, 91)
        Me.btnXPeriodo.Name = "btnXPeriodo"
        Me.btnXPeriodo.Size = New System.Drawing.Size(256, 23)
        Me.btnXPeriodo.TabIndex = 60
        Me.btnXPeriodo.Text = "Procesar Cuentas  X Periodo"
        Me.btnXPeriodo.UseVisualStyleBackColor = True
        '
        'btnComidaDuplicados
        '
        Me.btnComidaDuplicados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnComidaDuplicados.Location = New System.Drawing.Point(504, 36)
        Me.btnComidaDuplicados.Name = "btnComidaDuplicados"
        Me.btnComidaDuplicados.Size = New System.Drawing.Size(256, 23)
        Me.btnComidaDuplicados.TabIndex = 59
        Me.btnComidaDuplicados.Text = "Eliminar reg duplicados"
        Me.btnComidaDuplicados.UseVisualStyleBackColor = True
        '
        'btnBuscarDep
        '
        Me.btnBuscarDep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarDep.Location = New System.Drawing.Point(353, 36)
        Me.btnBuscarDep.Name = "btnBuscarDep"
        Me.btnBuscarDep.Size = New System.Drawing.Size(43, 23)
        Me.btnBuscarDep.TabIndex = 70
        Me.btnBuscarDep.Text = "..."
        Me.btnBuscarDep.UseVisualStyleBackColor = True
        '
        'btnProcesarHorasExtras
        '
        Me.btnProcesarHorasExtras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarHorasExtras.Location = New System.Drawing.Point(81, 162)
        Me.btnProcesarHorasExtras.Name = "btnProcesarHorasExtras"
        Me.btnProcesarHorasExtras.Size = New System.Drawing.Size(266, 24)
        Me.btnProcesarHorasExtras.TabIndex = 58
        Me.btnProcesarHorasExtras.Text = "Procesar Horas (Extra-Salidas, Entradas, Comidas)"
        Me.btnProcesarHorasExtras.UseVisualStyleBackColor = True
        '
        'txtDescripDep
        '
        Me.txtDescripDep.Location = New System.Drawing.Point(81, 38)
        Me.txtDescripDep.Name = "txtDescripDep"
        Me.txtDescripDep.ReadOnly = True
        Me.txtDescripDep.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripDep.TabIndex = 69
        '
        'btnCerrarPeriodo
        '
        Me.btnCerrarPeriodo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrarPeriodo.Location = New System.Drawing.Point(81, 126)
        Me.btnCerrarPeriodo.Name = "btnCerrarPeriodo"
        Me.btnCerrarPeriodo.Size = New System.Drawing.Size(266, 23)
        Me.btnCerrarPeriodo.TabIndex = 57
        Me.btnCerrarPeriodo.Text = "Cerrar Periodo"
        Me.btnCerrarPeriodo.UseVisualStyleBackColor = True
        '
        'txtIDDep
        '
        Me.txtIDDep.Location = New System.Drawing.Point(24, 38)
        Me.txtIDDep.Name = "txtIDDep"
        Me.txtIDDep.ReadOnly = True
        Me.txtIDDep.Size = New System.Drawing.Size(51, 20)
        Me.txtIDDep.TabIndex = 68
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(78, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Departamento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(340, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Resultado de Formula:"
        '
        'cbVarFormula
        '
        Me.cbVarFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVarFormula.FormattingEnabled = True
        Me.cbVarFormula.Location = New System.Drawing.Point(465, 126)
        Me.cbVarFormula.Name = "cbVarFormula"
        Me.cbVarFormula.Size = New System.Drawing.Size(322, 21)
        Me.cbVarFormula.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(340, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Concepto de Abono:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(340, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Concepto de Cargo:"
        '
        'txtEjercicio
        '
        Me.txtEjercicio.Location = New System.Drawing.Point(108, 123)
        Me.txtEjercicio.Mask = "9999"
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.Size = New System.Drawing.Size(200, 20)
        Me.txtEjercicio.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Ejercicio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "# Periodo:"
        '
        'txtNoPeriodo
        '
        Me.txtNoPeriodo.Location = New System.Drawing.Point(108, 97)
        Me.txtNoPeriodo.Name = "txtNoPeriodo"
        Me.txtNoPeriodo.Size = New System.Drawing.Size(200, 20)
        Me.txtNoPeriodo.TabIndex = 47
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(108, 19)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(200, 20)
        Me.txtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Fecha Final:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Fecha Inicial:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(108, 71)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 44
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(108, 45)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 43
        '
        'esActivo
        '
        Me.esActivo.AutoSize = True
        Me.esActivo.Enabled = False
        Me.esActivo.Location = New System.Drawing.Point(108, 158)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(134, 17)
        Me.esActivo.TabIndex = 42
        Me.esActivo.Text = "Pendiente de Procesar"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(340, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Sucursal:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(465, 45)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(322, 21)
        Me.cbSucursal.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(340, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Empresa:"
        '
        'cbEmpresa
        '
        Me.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpresa.Enabled = False
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(465, 19)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(322, 21)
        Me.cbEmpresa.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage1.Size = New System.Drawing.Size(1160, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1148, 430)
        Me.DataGridView1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1168, 468)
        Me.TabControl1.TabIndex = 6
        '
        'calculaXdep
        '
        Me.calculaXdep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.calculaXdep.Location = New System.Drawing.Point(81, 91)
        Me.calculaXdep.Name = "calculaXdep"
        Me.calculaXdep.Size = New System.Drawing.Size(266, 23)
        Me.calculaXdep.TabIndex = 78
        Me.calculaXdep.Text = "Calcular X dep/emp"
        Me.calculaXdep.UseVisualStyleBackColor = True
        '
        'frmPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 532)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmPeriodo"
        Me.Text = "..:: Mantenimiento a Periodos ::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents GenerarInformeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnImpXEmpl As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnModXEmpl As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnProcesarHorasExtras As Button
    Friend WithEvents btnCerrarPeriodo As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cbVarFormula As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEjercicio As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNoPeriodo As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents btnBuscarAbono As Button
    Friend WithEvents txtDescripConceptoAbono As TextBox
    Friend WithEvents txtIDAbono As TextBox
    Friend WithEvents btnBuscarCargo As Button
    Friend WithEvents txtDescripConceptoCargo As TextBox
    Friend WithEvents txtIDCargo As TextBox
    Friend WithEvents btnComidaDuplicados As Button
    Friend WithEvents btnImpConcentradoPago As ToolStripMenuItem
    Friend WithEvents btnModConcentradoPago As ToolStripMenuItem
    Friend WithEvents btnXPeriodo As Button
    Friend WithEvents btnBuscarDep As Button
    Friend WithEvents txtDescripDep As TextBox
    Friend WithEvents txtIDDep As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents chbSoloPendientes As CheckBox
    Friend WithEvents txtDesface As TextBox
    Friend WithEvents lblDesface As Label
    Friend WithEvents lblPeriodos As Label
    Friend WithEvents cbPeriodoContpaqi As ComboBox
    Friend WithEvents btnProcesarIncidencias As Button
    Friend WithEvents btnImprimirConcentradoAgrupado As ToolStripMenuItem
    Friend WithEvents btnModConcentradoAgrupado As ToolStripMenuItem
    Friend WithEvents calculaXdep As Button
End Class
