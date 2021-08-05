<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasXPeriodo
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrip = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtNumDocumento = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCuentas = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BORRADORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMPLETARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImporEXCEL = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnConcepto = New System.Windows.Forms.Button()
        Me.txtDescripConcepto = New System.Windows.Forms.TextBox()
        Me.txtIDConcepto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPagado = New System.Windows.Forms.TextBox()
        Me.txtRestante = New System.Windows.Forms.TextBox()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.cbTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoPer = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNoPer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaMov = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvDetalleCuenta = New System.Windows.Forms.DataGridView()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetalleCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 92)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Tipo Movimiento:"
        '
        'txtDescrip
        '
        Me.txtDescrip.Location = New System.Drawing.Point(895, 156)
        Me.txtDescrip.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(429, 100)
        Me.txtDescrip.TabIndex = 33
        Me.txtDescrip.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(720, 161)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Descripción:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 25)
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
        Me.cbEmpresa.Location = New System.Drawing.Point(196, 21)
        Me.cbEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(429, 24)
        Me.cbEmpresa.TabIndex = 10
        '
        'txtNumDocumento
        '
        Me.txtNumDocumento.Location = New System.Drawing.Point(895, 54)
        Me.txtNumDocumento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNumDocumento.Name = "txtNumDocumento"
        Me.txtNumDocumento.Size = New System.Drawing.Size(429, 22)
        Me.txtNumDocumento.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(720, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero del Documento:"
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AllowUserToAddRows = False
        Me.dgvCuentas.AllowUserToDeleteRows = False
        Me.dgvCuentas.AllowUserToResizeRows = False
        Me.dgvCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentas.Location = New System.Drawing.Point(8, 7)
        Me.dgvCuentas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvCuentas.MultiSelect = False
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ReadOnly = True
        Me.dgvCuentas.RowHeadersWidth = 51
        Me.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentas.Size = New System.Drawing.Size(1311, 566)
        Me.dgvCuentas.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem, Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente, Me.btnImporEXCEL})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1395, 28)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(66, 24)
        Me.btnNuevo.Text = "Nuevo"
        '
        'bntGuardar
        '
        Me.bntGuardar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BORRADORToolStripMenuItem, Me.COMPLETARToolStripMenuItem})
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(76, 24)
        Me.bntGuardar.Text = "Guardar"
        '
        'BORRADORToolStripMenuItem
        '
        Me.BORRADORToolStripMenuItem.Name = "BORRADORToolStripMenuItem"
        Me.BORRADORToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.BORRADORToolStripMenuItem.Text = "Borrador"
        '
        'COMPLETARToolStripMenuItem
        '
        Me.COMPLETARToolStripMenuItem.Name = "COMPLETARToolStripMenuItem"
        Me.COMPLETARToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.COMPLETARToolStripMenuItem.Text = "Completar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(77, 24)
        Me.btnEliminar.Text = "Eliminar"
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
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(125, 24)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(182, 24)
        Me.btnDetalle.Text = "Detalle de Movimientos"
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
        'btnImporEXCEL
        '
        Me.btnImporEXCEL.Name = "btnImporEXCEL"
        Me.btnImporEXCEL.Size = New System.Drawing.Size(149, 24)
        Me.btnImporEXCEL.Text = "Importación EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 651)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1395, 26)
        Me.StatusStrip1.TabIndex = 12
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
        Me.TabControl1.Location = New System.Drawing.Point(16, 33)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1363, 613)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCuentas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1355, 584)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnConcepto)
        Me.TabPage2.Controls.Add(Me.txtDescripConcepto)
        Me.TabPage2.Controls.Add(Me.txtIDConcepto)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtPagado)
        Me.TabPage2.Controls.Add(Me.txtRestante)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.cbTipoCuenta)
        Me.TabPage2.Controls.Add(Me.txtDescrip)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtMontoPer)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtNoPer)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtNombreEmpleado)
        Me.TabPage2.Controls.Add(Me.txtIDEmpleado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtMontoTotal)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtEstado)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtpFechaMov)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.txtNumDocumento)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1355, 584)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnConcepto
        '
        Me.btnConcepto.Location = New System.Drawing.Point(635, 121)
        Me.btnConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConcepto.Name = "btnConcepto"
        Me.btnConcepto.Size = New System.Drawing.Size(57, 28)
        Me.btnConcepto.TabIndex = 43
        Me.btnConcepto.Text = "..."
        Me.btnConcepto.UseVisualStyleBackColor = True
        '
        'txtDescripConcepto
        '
        Me.txtDescripConcepto.Location = New System.Drawing.Point(272, 123)
        Me.txtDescripConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescripConcepto.Name = "txtDescripConcepto"
        Me.txtDescripConcepto.ReadOnly = True
        Me.txtDescripConcepto.Size = New System.Drawing.Size(353, 22)
        Me.txtDescripConcepto.TabIndex = 42
        '
        'txtIDConcepto
        '
        Me.txtIDConcepto.Location = New System.Drawing.Point(196, 123)
        Me.txtIDConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDConcepto.Name = "txtIDConcepto"
        Me.txtIDConcepto.ReadOnly = True
        Me.txtIDConcepto.Size = New System.Drawing.Size(67, 22)
        Me.txtIDConcepto.TabIndex = 41
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1171, 87)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 17)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Restantes:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(993, 87)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 17)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Pagados:"
        '
        'txtPagado
        '
        Me.txtPagado.Location = New System.Drawing.Point(1071, 84)
        Me.txtPagado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPagado.Name = "txtPagado"
        Me.txtPagado.ReadOnly = True
        Me.txtPagado.Size = New System.Drawing.Size(68, 22)
        Me.txtPagado.TabIndex = 38
        '
        'txtRestante
        '
        Me.txtRestante.Location = New System.Drawing.Point(1256, 84)
        Me.txtRestante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRestante.Name = "txtRestante"
        Me.txtRestante.ReadOnly = True
        Me.txtRestante.Size = New System.Drawing.Size(68, 22)
        Me.txtRestante.TabIndex = 37
        '
        'esActivo
        '
        Me.esActivo.AutoSize = True
        Me.esActivo.Checked = True
        Me.esActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.esActivo.Enabled = False
        Me.esActivo.Location = New System.Drawing.Point(552, 223)
        Me.esActivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(68, 21)
        Me.esActivo.TabIndex = 36
        Me.esActivo.Text = "Activo"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'cbTipoCuenta
        '
        Me.cbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoCuenta.FormattingEnabled = True
        Me.cbTipoCuenta.Items.AddRange(New Object() {"CxC", "CxP"})
        Me.cbTipoCuenta.Location = New System.Drawing.Point(196, 87)
        Me.cbTipoCuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbTipoCuenta.Name = "cbTipoCuenta"
        Me.cbTipoCuenta.Size = New System.Drawing.Size(429, 24)
        Me.cbTipoCuenta.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 17)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Concepto:"
        '
        'txtMontoPer
        '
        Me.txtMontoPer.Location = New System.Drawing.Point(895, 121)
        Me.txtMontoPer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMontoPer.Name = "txtMontoPer"
        Me.txtMontoPer.Size = New System.Drawing.Size(128, 22)
        Me.txtMontoPer.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(720, 124)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 17)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Monto X Periodo:"
        '
        'txtNoPer
        '
        Me.txtNoPer.Location = New System.Drawing.Point(895, 84)
        Me.txtNoPer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNoPer.Name = "txtNoPer"
        Me.txtNoPer.Size = New System.Drawing.Size(68, 22)
        Me.txtNoPer.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(720, 87)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 17)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Num Periodos:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(635, 153)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 28)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(272, 155)
        Me.txtNombreEmpleado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreEmpleado.TabIndex = 29
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(196, 155)
        Me.txtIDEmpleado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(67, 22)
        Me.txtIDEmpleado.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 159)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 17)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Empleado (PIN):"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Location = New System.Drawing.Point(196, 219)
        Me.txtMontoTotal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.Size = New System.Drawing.Size(265, 22)
        Me.txtMontoTotal.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 223)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Total Documento:"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(196, 187)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(265, 22)
        Me.txtEstado.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 191)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Estado del Documento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Sucursal:"
        '
        'dtpFechaMov
        '
        Me.dtpFechaMov.Location = New System.Drawing.Point(895, 17)
        Me.dtpFechaMov.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFechaMov.Name = "dtpFechaMov"
        Me.dtpFechaMov.Size = New System.Drawing.Size(429, 22)
        Me.dtpFechaMov.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(720, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha del Movimiento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvDetalleCuenta)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 265)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1336, 309)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle del Movimiento"
        '
        'dgvDetalleCuenta
        '
        Me.dgvDetalleCuenta.AllowUserToAddRows = False
        Me.dgvDetalleCuenta.AllowUserToDeleteRows = False
        Me.dgvDetalleCuenta.AllowUserToResizeRows = False
        Me.dgvDetalleCuenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetalleCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleCuenta.Location = New System.Drawing.Point(20, 23)
        Me.dgvDetalleCuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvDetalleCuenta.MultiSelect = False
        Me.dgvDetalleCuenta.Name = "dgvDetalleCuenta"
        Me.dgvDetalleCuenta.ReadOnly = True
        Me.dgvDetalleCuenta.RowHeadersWidth = 51
        Me.dgvDetalleCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleCuenta.Size = New System.Drawing.Size(1297, 265)
        Me.dgvDetalleCuenta.TabIndex = 1
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(196, 54)
        Me.cbSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(429, 24)
        Me.cbSucursal.TabIndex = 12
        '
        'frmCuentasXPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1395, 677)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCuentasXPeriodo"
        Me.Text = "..:: Generar Cuentas para descuentos X Periodos ::.."
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDetalleCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents txtDescrip As RichTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents txtNumDocumento As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCuentas As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents BORRADORToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COMPLETARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMontoTotal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaMov As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents txtMontoPer As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNoPer As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cbTipoCuenta As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvDetalleCuenta As DataGridView
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPagado As TextBox
    Friend WithEvents txtRestante As TextBox
    Friend WithEvents btnConcepto As Button
    Friend WithEvents txtDescripConcepto As TextBox
    Friend WithEvents txtIDConcepto As TextBox
    Friend WithEvents btnImporEXCEL As ToolStripMenuItem
End Class
