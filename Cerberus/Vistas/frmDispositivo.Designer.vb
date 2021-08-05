<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDispositivo
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtActivacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFirmwareV = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chbEliminarRegs = New System.Windows.Forms.CheckBox()
        Me.esSincronizacionAut = New System.Windows.Forms.CheckBox()
        Me.esGeneral = New System.Windows.Forms.CheckBox()
        Me.cbCocina = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbTipoDisp = New System.Windows.Forms.ComboBox()
        Me.txtDireccion = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdZk = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnExtraerXPeriodo = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDispositivoSeleccion = New System.Windows.Forms.Label()
        Me.btnResetearDispositivo = New System.Windows.Forms.Button()
        Me.btnEliminarEmpleado = New System.Windows.Forms.Button()
        Me.btnExtraccionInfoDisp = New System.Windows.Forms.Button()
        Me.btnAsignacionFechaHora = New System.Windows.Forms.Button()
        Me.btnExtraccionDatosBiom = New System.Windows.Forms.Button()
        Me.btnRegistroEmpleado = New System.Windows.Forms.Button()
        Me.btnExtraccionAsistencias = New System.Windows.Forms.Button()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.btnEliminarEmpleadoDepartamento = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(107, 24)
        Me.btnComentarios.Text = "Comentarios"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(82, 24)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(182, 24)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(385, 123)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 17)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Tipo:"
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(107, 119)
        Me.txtPuerto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(225, 22)
        Me.txtPuerto.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 123)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 17)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Puerto:"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(125, 24)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(77, 24)
        Me.btnEliminar.Text = "Eliminar"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(76, 24)
        Me.bntGuardar.Text = "Guardar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1280, 28)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(66, 24)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(110, 24)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(118, 24)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'esActivo
        '
        Me.esActivo.AutoSize = True
        Me.esActivo.Location = New System.Drawing.Point(389, 194)
        Me.esActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(68, 21)
        Me.esActivo.TabIndex = 42
        Me.esActivo.Text = "Activo"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1280, 26)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(153, 20)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(16, 54)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1248, 419)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1240, 390)
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
        Me.DataGridView1.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1221, 372)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtActivacion)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtFirmwareV)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.chbEliminarRegs)
        Me.TabPage2.Controls.Add(Me.esSincronizacionAut)
        Me.TabPage2.Controls.Add(Me.esGeneral)
        Me.TabPage2.Controls.Add(Me.cbCocina)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.cbTipoDisp)
        Me.TabPage2.Controls.Add(Me.txtDireccion)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtPuerto)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.cbUbicacion)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.txtModelo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtNoSerie)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtIdZk)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtNombre)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1240, 390)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtActivacion
        '
        Me.txtActivacion.Location = New System.Drawing.Point(140, 316)
        Me.txtActivacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActivacion.Name = "txtActivacion"
        Me.txtActivacion.Size = New System.Drawing.Size(760, 22)
        Me.txtActivacion.TabIndex = 57
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 320)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Código Activación:"
        '
        'txtFirmwareV
        '
        Me.txtFirmwareV.Location = New System.Drawing.Point(107, 226)
        Me.txtFirmwareV.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirmwareV.Name = "txtFirmwareV"
        Me.txtFirmwareV.ReadOnly = True
        Me.txtFirmwareV.Size = New System.Drawing.Size(225, 22)
        Me.txtFirmwareV.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 230)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 17)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Firmware V."
        '
        'chbEliminarRegs
        '
        Me.chbEliminarRegs.AutoSize = True
        Me.chbEliminarRegs.Location = New System.Drawing.Point(389, 223)
        Me.chbEliminarRegs.Margin = New System.Windows.Forms.Padding(4)
        Me.chbEliminarRegs.Name = "chbEliminarRegs"
        Me.chbEliminarRegs.Size = New System.Drawing.Size(226, 21)
        Me.chbEliminarRegs.TabIndex = 53
        Me.chbEliminarRegs.Text = "Eliminar Registros al Extraerlos"
        Me.chbEliminarRegs.UseVisualStyleBackColor = True
        '
        'esSincronizacionAut
        '
        Me.esSincronizacionAut.AutoSize = True
        Me.esSincronizacionAut.Location = New System.Drawing.Point(719, 194)
        Me.esSincronizacionAut.Margin = New System.Windows.Forms.Padding(4)
        Me.esSincronizacionAut.Name = "esSincronizacionAut"
        Me.esSincronizacionAut.Size = New System.Drawing.Size(209, 21)
        Me.esSincronizacionAut.TabIndex = 52
        Me.esSincronizacionAut.Text = "Sincroniza Automáticamente"
        Me.esSincronizacionAut.UseVisualStyleBackColor = True
        '
        'esGeneral
        '
        Me.esGeneral.AutoSize = True
        Me.esGeneral.Location = New System.Drawing.Point(495, 193)
        Me.esGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.esGeneral.Name = "esGeneral"
        Me.esGeneral.Size = New System.Drawing.Size(215, 21)
        Me.esGeneral.TabIndex = 51
        Me.esGeneral.Text = "General para todo el Sistema"
        Me.esGeneral.UseVisualStyleBackColor = True
        '
        'cbCocina
        '
        Me.cbCocina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCocina.FormattingEnabled = True
        Me.cbCocina.Items.AddRange(New Object() {"Entrada/Salida", "Comidas"})
        Me.cbCocina.Location = New System.Drawing.Point(471, 154)
        Me.cbCocina.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCocina.Name = "cbCocina"
        Me.cbCocina.Size = New System.Drawing.Size(429, 24)
        Me.cbCocina.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(385, 158)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 17)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Cocina:"
        '
        'cbTipoDisp
        '
        Me.cbTipoDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoDisp.FormattingEnabled = True
        Me.cbTipoDisp.Items.AddRange(New Object() {"Entrada/Salida", "Comidas"})
        Me.cbTipoDisp.Location = New System.Drawing.Point(471, 119)
        Me.cbTipoDisp.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipoDisp.Name = "cbTipoDisp"
        Me.cbTipoDisp.Size = New System.Drawing.Size(429, 24)
        Me.cbTipoDisp.TabIndex = 48
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(107, 52)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(225, 22)
        Me.txtDireccion.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(385, 86)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Ubicacion:"
        '
        'cbUbicacion
        '
        Me.cbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUbicacion.FormattingEnabled = True
        Me.cbUbicacion.Items.AddRange(New Object() {"Usuario", "Administrador"})
        Me.cbUbicacion.Location = New System.Drawing.Point(471, 82)
        Me.cbUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cbUbicacion.Name = "cbUbicacion"
        Me.cbUbicacion.Size = New System.Drawing.Size(429, 24)
        Me.cbUbicacion.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(385, 50)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Sucursal:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(471, 47)
        Me.cbSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(429, 24)
        Me.cbSucursal.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(385, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Empresa:"
        '
        'cbEmpresa
        '
        Me.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpresa.Enabled = False
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(471, 15)
        Me.cbEmpresa.Margin = New System.Windows.Forms.Padding(4)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(429, 24)
        Me.cbEmpresa.TabIndex = 10
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(107, 191)
        Me.txtModelo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(225, 22)
        Me.txtModelo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 194)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Modelo:"
        '
        'txtNoSerie
        '
        Me.txtNoSerie.Location = New System.Drawing.Point(107, 154)
        Me.txtNoSerie.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoSerie.Name = "txtNoSerie"
        Me.txtNoSerie.ReadOnly = True
        Me.txtNoSerie.Size = New System.Drawing.Size(225, 22)
        Me.txtNoSerie.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "# Serie:"
        '
        'txtIdZk
        '
        Me.txtIdZk.Location = New System.Drawing.Point(107, 84)
        Me.txtIdZk.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdZk.Name = "txtIdZk"
        Me.txtIdZk.ReadOnly = True
        Me.txtIdZk.Size = New System.Drawing.Size(225, 22)
        Me.txtIdZk.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ID ZKTeco:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dirección IP:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(107, 15)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(225, 22)
        Me.txtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnEliminarEmpleadoDepartamento)
        Me.TabPage3.Controls.Add(Me.btnExtraerXPeriodo)
        Me.TabPage3.Controls.Add(Me.DataGridView2)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.lblDispositivoSeleccion)
        Me.TabPage3.Controls.Add(Me.btnResetearDispositivo)
        Me.TabPage3.Controls.Add(Me.btnEliminarEmpleado)
        Me.TabPage3.Controls.Add(Me.btnExtraccionInfoDisp)
        Me.TabPage3.Controls.Add(Me.btnAsignacionFechaHora)
        Me.TabPage3.Controls.Add(Me.btnExtraccionDatosBiom)
        Me.TabPage3.Controls.Add(Me.btnRegistroEmpleado)
        Me.TabPage3.Controls.Add(Me.btnExtraccionAsistencias)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1240, 390)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Eventos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnExtraerXPeriodo
        '
        Me.btnExtraerXPeriodo.Location = New System.Drawing.Point(383, 218)
        Me.btnExtraerXPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExtraerXPeriodo.Name = "btnExtraerXPeriodo"
        Me.btnExtraerXPeriodo.Size = New System.Drawing.Size(245, 48)
        Me.btnExtraerXPeriodo.TabIndex = 12
        Me.btnExtraerXPeriodo.Text = "Extraer Asistencias X Periodo"
        Me.btnExtraerXPeriodo.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(681, 68)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(129, 39)
        Me.DataGridView2.TabIndex = 11
        Me.DataGridView2.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(28, 166)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(271, 42)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Registrar Empleados x Cocina Asignada"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(28, 114)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(271, 42)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Registrar Empleados x Departamento"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblDispositivoSeleccion
        '
        Me.lblDispositivoSeleccion.AutoSize = True
        Me.lblDispositivoSeleccion.Location = New System.Drawing.Point(9, 25)
        Me.lblDispositivoSeleccion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDispositivoSeleccion.Name = "lblDispositivoSeleccion"
        Me.lblDispositivoSeleccion.Size = New System.Drawing.Size(213, 17)
        Me.lblDispositivoSeleccion.TabIndex = 7
        Me.lblDispositivoSeleccion.Text = "DISPOSITIVO SELECCIONADO: "
        '
        'btnResetearDispositivo
        '
        Me.btnResetearDispositivo.BackColor = System.Drawing.Color.Crimson
        Me.btnResetearDispositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetearDispositivo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnResetearDispositivo.Location = New System.Drawing.Point(383, 273)
        Me.btnResetearDispositivo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnResetearDispositivo.Name = "btnResetearDispositivo"
        Me.btnResetearDispositivo.Size = New System.Drawing.Size(245, 47)
        Me.btnResetearDispositivo.TabIndex = 6
        Me.btnResetearDispositivo.Text = "Resetear Dispositivo"
        Me.btnResetearDispositivo.UseVisualStyleBackColor = False
        '
        'btnEliminarEmpleado
        '
        Me.btnEliminarEmpleado.Location = New System.Drawing.Point(28, 273)
        Me.btnEliminarEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarEmpleado.Name = "btnEliminarEmpleado"
        Me.btnEliminarEmpleado.Size = New System.Drawing.Size(271, 47)
        Me.btnEliminarEmpleado.TabIndex = 5
        Me.btnEliminarEmpleado.Text = "Eliminar Empleado"
        Me.btnEliminarEmpleado.UseVisualStyleBackColor = True
        '
        'btnExtraccionInfoDisp
        '
        Me.btnExtraccionInfoDisp.Location = New System.Drawing.Point(383, 114)
        Me.btnExtraccionInfoDisp.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExtraccionInfoDisp.Name = "btnExtraccionInfoDisp"
        Me.btnExtraccionInfoDisp.Size = New System.Drawing.Size(245, 42)
        Me.btnExtraccionInfoDisp.TabIndex = 4
        Me.btnExtraccionInfoDisp.Text = "Extraer Información del Dispositivo"
        Me.btnExtraccionInfoDisp.UseVisualStyleBackColor = True
        '
        'btnAsignacionFechaHora
        '
        Me.btnAsignacionFechaHora.Location = New System.Drawing.Point(383, 65)
        Me.btnAsignacionFechaHora.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAsignacionFechaHora.Name = "btnAsignacionFechaHora"
        Me.btnAsignacionFechaHora.Size = New System.Drawing.Size(245, 42)
        Me.btnAsignacionFechaHora.TabIndex = 3
        Me.btnAsignacionFechaHora.Text = "Re-Asignar Hora y Fecha"
        Me.btnAsignacionFechaHora.UseVisualStyleBackColor = True
        '
        'btnExtraccionDatosBiom
        '
        Me.btnExtraccionDatosBiom.Location = New System.Drawing.Point(28, 218)
        Me.btnExtraccionDatosBiom.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExtraccionDatosBiom.Name = "btnExtraccionDatosBiom"
        Me.btnExtraccionDatosBiom.Size = New System.Drawing.Size(271, 48)
        Me.btnExtraccionDatosBiom.TabIndex = 2
        Me.btnExtraccionDatosBiom.Text = "Extraer Huella y Rostro del Empleado"
        Me.btnExtraccionDatosBiom.UseVisualStyleBackColor = True
        '
        'btnRegistroEmpleado
        '
        Me.btnRegistroEmpleado.Location = New System.Drawing.Point(28, 65)
        Me.btnRegistroEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegistroEmpleado.Name = "btnRegistroEmpleado"
        Me.btnRegistroEmpleado.Size = New System.Drawing.Size(271, 42)
        Me.btnRegistroEmpleado.TabIndex = 1
        Me.btnRegistroEmpleado.Text = "Registrar Empleado"
        Me.btnRegistroEmpleado.UseVisualStyleBackColor = True
        '
        'btnExtraccionAsistencias
        '
        Me.btnExtraccionAsistencias.Location = New System.Drawing.Point(383, 164)
        Me.btnExtraccionAsistencias.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExtraccionAsistencias.Name = "btnExtraccionAsistencias"
        Me.btnExtraccionAsistencias.Size = New System.Drawing.Size(245, 48)
        Me.btnExtraccionAsistencias.TabIndex = 0
        Me.btnExtraccionAsistencias.Text = "Extraer Asistencias"
        Me.btnExtraccionAsistencias.UseVisualStyleBackColor = True
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.Checked = True
        Me.cbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActivo.Location = New System.Drawing.Point(16, 31)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(68, 21)
        Me.cbActivo.TabIndex = 6
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'btnEliminarEmpleadoDepartamento
        '
        Me.btnEliminarEmpleadoDepartamento.Location = New System.Drawing.Point(28, 328)
        Me.btnEliminarEmpleadoDepartamento.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarEmpleadoDepartamento.Name = "btnEliminarEmpleadoDepartamento"
        Me.btnEliminarEmpleadoDepartamento.Size = New System.Drawing.Size(271, 47)
        Me.btnEliminarEmpleadoDepartamento.TabIndex = 13
        Me.btnEliminarEmpleadoDepartamento.Text = "Eliminar Empleados X Departamento"
        Me.btnEliminarEmpleadoDepartamento.UseVisualStyleBackColor = True
        '
        'frmDispositivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 504)
        Me.Controls.Add(Me.cbActivo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDispositivo"
        Me.Text = "..:: Mantenimiento Dispositivo ::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPuerto As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents cbUbicacion As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNoSerie As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIdZk As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDireccion As MaskedTextBox
    Friend WithEvents cbTipoDisp As ComboBox
    Friend WithEvents cbCocina As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnResetearDispositivo As Button
    Friend WithEvents btnEliminarEmpleado As Button
    Friend WithEvents btnExtraccionInfoDisp As Button
    Friend WithEvents btnAsignacionFechaHora As Button
    Friend WithEvents btnExtraccionDatosBiom As Button
    Friend WithEvents btnRegistroEmpleado As Button
    Friend WithEvents btnExtraccionAsistencias As Button
    Friend WithEvents esGeneral As CheckBox
    Friend WithEvents esSincronizacionAut As CheckBox
    Friend WithEvents lblDispositivoSeleccion As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents chbEliminarRegs As CheckBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtFirmwareV As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnExtraerXPeriodo As Button
    Friend WithEvents txtActivacion As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbActivo As CheckBox
    Friend WithEvents btnEliminarEmpleadoDepartamento As Button
End Class
