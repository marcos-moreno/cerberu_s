<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BORRADORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMPLETARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportacionEXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rtbDescripCuenta = New System.Windows.Forms.RichTextBox()
        Me.txtMontoTotal = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtIDProveedor = New System.Windows.Forms.TextBox()
        Me.txtNumDocumento = New System.Windows.Forms.TextBox()
        Me.btnProveedor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaMov = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar2 = New System.Windows.Forms.Button()
        Me.btnGuardar2 = New System.Windows.Forms.Button()
        Me.btnNuevo2 = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvDetalleCompra = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.txtIdUbic = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.txtNombreProd = New System.Windows.Forms.TextBox()
        Me.txtIDProducto = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCompras = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDetalleCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(180, 25)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(75, 29)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem, Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.ImprimirToolStripMenuItem, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente, Me.ImportacionEXCELToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1651, 35)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(76, 29)
        Me.btnNuevo.Text = "Nuevo"
        '
        'bntGuardar
        '
        Me.bntGuardar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BORRADORToolStripMenuItem, Me.COMPLETARToolStripMenuItem})
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(87, 29)
        Me.bntGuardar.Text = "Guardar"
        '
        'BORRADORToolStripMenuItem
        '
        Me.BORRADORToolStripMenuItem.Name = "BORRADORToolStripMenuItem"
        Me.BORRADORToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.BORRADORToolStripMenuItem.Text = "Borrador"
        '
        'COMPLETARToolStripMenuItem
        '
        Me.COMPLETARToolStripMenuItem.Name = "COMPLETARToolStripMenuItem"
        Me.COMPLETARToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.COMPLETARToolStripMenuItem.Text = "Completar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 29)
        Me.btnEliminar.Text = "Eliminar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem1, Me.btnModificar})
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(86, 29)
        Me.ImprimirToolStripMenuItem.Text = "Reporte"
        '
        'ImprimirToolStripMenuItem1
        '
        Me.ImprimirToolStripMenuItem1.Name = "ImprimirToolStripMenuItem1"
        Me.ImprimirToolStripMenuItem1.Size = New System.Drawing.Size(171, 30)
        Me.ImprimirToolStripMenuItem1.Text = "Imprimir"
        '
        'btnModificar
        '
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(171, 30)
        Me.btnModificar.Text = "Modificar"
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(125, 29)
        Me.btnComentarios.Text = "Comentarios"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(96, 29)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(144, 29)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(212, 29)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(127, 29)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(136, 29)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'ImportacionEXCELToolStripMenuItem
        '
        Me.ImportacionEXCELToolStripMenuItem.Name = "ImportacionEXCELToolStripMenuItem"
        Me.ImportacionEXCELToolStripMenuItem.Size = New System.Drawing.Size(174, 29)
        Me.ImportacionEXCELToolStripMenuItem.Text = "Importacion EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 874)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1651, 30)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbAlmacen)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.rtbDescripCuenta)
        Me.TabPage2.Controls.Add(Me.txtMontoTotal)
        Me.TabPage2.Controls.Add(Me.txtNombreProveedor)
        Me.TabPage2.Controls.Add(Me.txtEstado)
        Me.TabPage2.Controls.Add(Me.txtIDProveedor)
        Me.TabPage2.Controls.Add(Me.txtNumDocumento)
        Me.TabPage2.Controls.Add(Me.btnProveedor)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.lblProveedor)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtpFechaMov)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Size = New System.Drawing.Size(1637, 791)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 89)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Almacen:"
        '
        'cbAlmacen
        '
        Me.cbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(220, 85)
        Me.cbAlmacen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(482, 28)
        Me.cbAlmacen.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 235)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 20)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Observación:"
        '
        'rtbDescripCuenta
        '
        Me.rtbDescripCuenta.Location = New System.Drawing.Point(217, 232)
        Me.rtbDescripCuenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rtbDescripCuenta.Name = "rtbDescripCuenta"
        Me.rtbDescripCuenta.Size = New System.Drawing.Size(556, 66)
        Me.rtbDescripCuenta.TabIndex = 31
        Me.rtbDescripCuenta.Text = ""
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Location = New System.Drawing.Point(1006, 151)
        Me.txtMontoTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(298, 26)
        Me.txtMontoTotal.TabIndex = 25
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Location = New System.Drawing.Point(304, 155)
        Me.txtNombreProveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.ReadOnly = True
        Me.txtNombreProveedor.Size = New System.Drawing.Size(397, 26)
        Me.txtNombreProveedor.TabIndex = 29
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(1006, 111)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(298, 26)
        Me.txtEstado.TabIndex = 22
        '
        'txtIDProveedor
        '
        Me.txtIDProveedor.Location = New System.Drawing.Point(217, 155)
        Me.txtIDProveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIDProveedor.Name = "txtIDProveedor"
        Me.txtIDProveedor.ReadOnly = True
        Me.txtIDProveedor.Size = New System.Drawing.Size(74, 26)
        Me.txtIDProveedor.TabIndex = 28
        '
        'txtNumDocumento
        '
        Me.txtNumDocumento.Location = New System.Drawing.Point(1006, 68)
        Me.txtNumDocumento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumDocumento.Name = "txtNumDocumento"
        Me.txtNumDocumento.Size = New System.Drawing.Size(298, 26)
        Me.txtNumDocumento.TabIndex = 1
        '
        'btnProveedor
        '
        Me.btnProveedor.Location = New System.Drawing.Point(720, 151)
        Me.btnProveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProveedor.Name = "btnProveedor"
        Me.btnProveedor.Size = New System.Drawing.Size(64, 35)
        Me.btnProveedor.TabIndex = 30
        Me.btnProveedor.Text = "..."
        Me.btnProveedor.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(810, 155)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Total Documento:"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(23, 158)
        Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(85, 20)
        Me.lblProveedor.TabIndex = 27
        Me.lblProveedor.Text = "Proveedor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(810, 115)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Estado del Documento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Sucursal:"
        '
        'dtpFechaMov
        '
        Me.dtpFechaMov.Location = New System.Drawing.Point(1006, 22)
        Me.dtpFechaMov.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaMov.Name = "dtpFechaMov"
        Me.dtpFechaMov.Size = New System.Drawing.Size(298, 26)
        Me.dtpFechaMov.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(810, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha de la compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnEliminar2)
        Me.GroupBox1.Controls.Add(Me.btnGuardar2)
        Me.GroupBox1.Controls.Add(Me.btnNuevo2)
        Me.GroupBox1.Controls.Add(Me.TabControl2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 326)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1615, 449)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de la compra"
        '
        'btnEliminar2
        '
        Me.btnEliminar2.Enabled = False
        Me.btnEliminar2.Location = New System.Drawing.Point(232, 29)
        Me.btnEliminar2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEliminar2.Name = "btnEliminar2"
        Me.btnEliminar2.Size = New System.Drawing.Size(112, 35)
        Me.btnEliminar2.TabIndex = 33
        Me.btnEliminar2.Text = "Eliminar"
        Me.btnEliminar2.UseVisualStyleBackColor = True
        '
        'btnGuardar2
        '
        Me.btnGuardar2.Enabled = False
        Me.btnGuardar2.Location = New System.Drawing.Point(122, 29)
        Me.btnGuardar2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar2.Name = "btnGuardar2"
        Me.btnGuardar2.Size = New System.Drawing.Size(112, 35)
        Me.btnGuardar2.TabIndex = 32
        Me.btnGuardar2.Text = "Guardar"
        Me.btnGuardar2.UseVisualStyleBackColor = True
        '
        'btnNuevo2
        '
        Me.btnNuevo2.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo2.Enabled = False
        Me.btnNuevo2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo2.Location = New System.Drawing.Point(10, 29)
        Me.btnNuevo2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo2.Name = "btnNuevo2"
        Me.btnNuevo2.Size = New System.Drawing.Size(112, 35)
        Me.btnNuevo2.TabIndex = 31
        Me.btnNuevo2.Text = "Nuevo"
        Me.btnNuevo2.UseVisualStyleBackColor = False
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Enabled = False
        Me.TabControl2.Location = New System.Drawing.Point(6, 74)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1601, 366)
        Me.TabControl2.TabIndex = 30
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvDetalleCompra)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Size = New System.Drawing.Size(1593, 333)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Colección"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvDetalleCompra
        '
        Me.dgvDetalleCompra.AllowUserToAddRows = False
        Me.dgvDetalleCompra.AllowUserToDeleteRows = False
        Me.dgvDetalleCompra.AllowUserToResizeRows = False
        Me.dgvDetalleCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleCompra.Location = New System.Drawing.Point(10, 9)
        Me.dgvDetalleCompra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDetalleCompra.MultiSelect = False
        Me.dgvDetalleCompra.Name = "dgvDetalleCompra"
        Me.dgvDetalleCompra.ReadOnly = True
        Me.dgvDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleCompra.Size = New System.Drawing.Size(1571, 292)
        Me.dgvDetalleCompra.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtUbicacion)
        Me.TabPage4.Controls.Add(Me.txtIdUbic)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txtCantidad)
        Me.TabPage4.Controls.Add(Me.btnProducto)
        Me.TabPage4.Controls.Add(Me.txtNombreProd)
        Me.TabPage4.Controls.Add(Me.txtIDProducto)
        Me.TabPage4.Controls.Add(Me.txtMonto)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage4.Size = New System.Drawing.Size(1593, 333)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Selección"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(207, 140)
        Me.txtUbicacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(397, 26)
        Me.txtUbicacion.TabIndex = 43
        '
        'txtIdUbic
        '
        Me.txtIdUbic.Location = New System.Drawing.Point(125, 142)
        Me.txtIdUbic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIdUbic.Name = "txtIdUbic"
        Me.txtIdUbic.ReadOnly = True
        Me.txtIdUbic.Size = New System.Drawing.Size(74, 26)
        Me.txtIdUbic.TabIndex = 42
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(620, 133)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 35)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 140)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Ubicación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(307, 77)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 20)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(392, 74)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(148, 26)
        Me.txtCantidad.TabIndex = 36
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(620, 25)
        Me.btnProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(64, 35)
        Me.btnProducto.TabIndex = 35
        Me.btnProducto.Text = "..."
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'txtNombreProd
        '
        Me.txtNombreProd.Location = New System.Drawing.Point(212, 28)
        Me.txtNombreProd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNombreProd.Name = "txtNombreProd"
        Me.txtNombreProd.ReadOnly = True
        Me.txtNombreProd.Size = New System.Drawing.Size(397, 26)
        Me.txtNombreProd.TabIndex = 34
        '
        'txtIDProducto
        '
        Me.txtIDProducto.Location = New System.Drawing.Point(126, 28)
        Me.txtIDProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIDProducto.Name = "txtIDProducto"
        Me.txtIDProducto.ReadOnly = True
        Me.txtIDProducto.Size = New System.Drawing.Size(74, 26)
        Me.txtIDProducto.TabIndex = 33
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(124, 74)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(148, 26)
        Me.txtMonto.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 74)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 20)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Monto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 32)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Producto:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(220, 28)
        Me.cbSucursal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(482, 28)
        Me.cbSucursal.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(810, 72)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero del Documento:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCompras)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(1637, 791)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCompras
        '
        Me.dgvCompras.AllowUserToAddRows = False
        Me.dgvCompras.AllowUserToDeleteRows = False
        Me.dgvCompras.AllowUserToResizeRows = False
        Me.dgvCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompras.Location = New System.Drawing.Point(8, 10)
        Me.dgvCompras.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvCompras.MultiSelect = False
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.ReadOnly = True
        Me.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompras.Size = New System.Drawing.Size(1621, 771)
        Me.dgvCompras.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 42)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1645, 824)
        Me.TabControl1.TabIndex = 11
        '
        'frmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1651, 904)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmCompras"
        Me.Text = "..::Compras::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvDetalleCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents BORRADORToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COMPLETARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btnModificar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents ImportacionEXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents rtbDescripCuenta As RichTextBox
    Friend WithEvents txtMontoTotal As TextBox
    Friend WithEvents txtNombreProveedor As TextBox
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents txtIDProveedor As TextBox
    Friend WithEvents txtNumDocumento As TextBox
    Friend WithEvents btnProveedor As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents lblProveedor As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaMov As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnEliminar2 As Button
    Friend WithEvents btnGuardar2 As Button
    Friend WithEvents btnNuevo2 As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvDetalleCompra As DataGridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents btnProducto As Button
    Friend WithEvents txtNombreProd As TextBox
    Friend WithEvents txtIDProducto As TextBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvCompras As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label6 As Label
    Friend WithEvents cbAlmacen As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents txtIdUbic As TextBox
End Class
