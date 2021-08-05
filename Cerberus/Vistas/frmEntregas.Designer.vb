<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntregas
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
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbDetalle = New System.Windows.Forms.TabPage()
        Me.tbDetalleE = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.tbDetalleEntrega = New System.Windows.Forms.TabPage()
        Me.txtIDUbicacion = New System.Windows.Forms.TextBox()
        Me.txtNombreUbic = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.txtNombreProd = New System.Windows.Forms.TextBox()
        Me.txtIDProducto = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TbEmpleado = New System.Windows.Forms.TabPage()
        Me.dgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.TbSelectEntrega = New System.Windows.Forms.TabPage()
        Me.txtDescripcionEntrega = New System.Windows.Forms.RichTextBox()
        Me.txtNombreEntrega = New System.Windows.Forms.TextBox()
        Me.DTPEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TbEntregas = New System.Windows.Forms.TabPage()
        Me.dgvEntrega = New System.Windows.Forms.DataGridView()
        Me.TbGeneral = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tbDetalle.SuspendLayout()
        Me.tbDetalleE.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDetalleEntrega.SuspendLayout()
        Me.TbEmpleado.SuspendLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbSelectEntrega.SuspendLayout()
        Me.TbEntregas.SuspendLayout()
        CType(Me.dgvEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(66, 24)
        Me.btnNuevo.Text = "Nuevo"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(76, 24)
        Me.bntGuardar.Text = "Guardar"
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
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem1, Me.ModificarToolStripMenuItem})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(82, 24)
        Me.btnReportes.Text = "Reportes"
        '
        'ImprimirToolStripMenuItem1
        '
        Me.ImprimirToolStripMenuItem1.Name = "ImprimirToolStripMenuItem1"
        Me.ImprimirToolStripMenuItem1.Size = New System.Drawing.Size(224, 26)
        Me.ImprimirToolStripMenuItem1.Text = "Imprimir"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
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
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnReportes, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1619, 28)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(118, 24)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 588)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1619, 26)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(153, 20)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'tbDetalle
        '
        Me.tbDetalle.Controls.Add(Me.tbDetalleE)
        Me.tbDetalle.Location = New System.Drawing.Point(4, 25)
        Me.tbDetalle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbDetalle.Size = New System.Drawing.Size(1599, 527)
        Me.tbDetalle.TabIndex = 3
        Me.tbDetalle.Text = "DetalleEntrega"
        Me.tbDetalle.UseVisualStyleBackColor = True
        '
        'tbDetalleE
        '
        Me.tbDetalleE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDetalleE.Controls.Add(Me.TabPage3)
        Me.tbDetalleE.Controls.Add(Me.tbDetalleEntrega)
        Me.tbDetalleE.Location = New System.Drawing.Point(2, 4)
        Me.tbDetalleE.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDetalleE.Name = "tbDetalleE"
        Me.tbDetalleE.SelectedIndex = 0
        Me.tbDetalleE.Size = New System.Drawing.Size(1597, 522)
        Me.tbDetalleE.TabIndex = 74
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvDetalles)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1589, 493)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Colección"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvDetalles
        '
        Me.dgvDetalles.AllowUserToAddRows = False
        Me.dgvDetalles.AllowUserToDeleteRows = False
        Me.dgvDetalles.AllowUserToResizeRows = False
        Me.dgvDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Location = New System.Drawing.Point(8, 7)
        Me.dgvDetalles.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDetalles.MultiSelect = False
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.ReadOnly = True
        Me.dgvDetalles.RowHeadersWidth = 51
        Me.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalles.Size = New System.Drawing.Size(1571, 469)
        Me.dgvDetalles.TabIndex = 0
        '
        'tbDetalleEntrega
        '
        Me.tbDetalleEntrega.Controls.Add(Me.txtIDUbicacion)
        Me.tbDetalleEntrega.Controls.Add(Me.txtNombreUbic)
        Me.tbDetalleEntrega.Controls.Add(Me.Label2)
        Me.tbDetalleEntrega.Controls.Add(Me.Label1)
        Me.tbDetalleEntrega.Controls.Add(Me.btnEmpleado)
        Me.tbDetalleEntrega.Controls.Add(Me.txtNombreEmpleado)
        Me.tbDetalleEntrega.Controls.Add(Me.txtIDEmpleado)
        Me.tbDetalleEntrega.Controls.Add(Me.btnProducto)
        Me.tbDetalleEntrega.Controls.Add(Me.txtNombreProd)
        Me.tbDetalleEntrega.Controls.Add(Me.txtIDProducto)
        Me.tbDetalleEntrega.Controls.Add(Me.txtTotal)
        Me.tbDetalleEntrega.Controls.Add(Me.txtPrecio)
        Me.tbDetalleEntrega.Controls.Add(Me.txtDescuento)
        Me.tbDetalleEntrega.Controls.Add(Me.Label16)
        Me.tbDetalleEntrega.Controls.Add(Me.Label15)
        Me.tbDetalleEntrega.Controls.Add(Me.Label14)
        Me.tbDetalleEntrega.Controls.Add(Me.Label12)
        Me.tbDetalleEntrega.Controls.Add(Me.Label3)
        Me.tbDetalleEntrega.Controls.Add(Me.txtCantidad)
        Me.tbDetalleEntrega.Controls.Add(Me.Label8)
        Me.tbDetalleEntrega.Location = New System.Drawing.Point(4, 25)
        Me.tbDetalleEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDetalleEntrega.Name = "tbDetalleEntrega"
        Me.tbDetalleEntrega.Padding = New System.Windows.Forms.Padding(4)
        Me.tbDetalleEntrega.Size = New System.Drawing.Size(1589, 493)
        Me.tbDetalleEntrega.TabIndex = 1
        Me.tbDetalleEntrega.Text = "Selección"
        Me.tbDetalleEntrega.UseVisualStyleBackColor = True
        '
        'txtIDUbicacion
        '
        Me.txtIDUbicacion.Location = New System.Drawing.Point(122, 66)
        Me.txtIDUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDUbicacion.Name = "txtIDUbicacion"
        Me.txtIDUbicacion.ReadOnly = True
        Me.txtIDUbicacion.Size = New System.Drawing.Size(66, 22)
        Me.txtIDUbicacion.TabIndex = 64
        '
        'txtNombreUbic
        '
        Me.txtNombreUbic.Location = New System.Drawing.Point(200, 66)
        Me.txtNombreUbic.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreUbic.Name = "txtNombreUbic"
        Me.txtNombreUbic.ReadOnly = True
        Me.txtNombreUbic.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreUbic.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Ubicación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(463, 159)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 17)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "%"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Location = New System.Drawing.Point(561, 104)
        Me.btnEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(57, 28)
        Me.btnEmpleado.TabIndex = 60
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(201, 107)
        Me.txtNombreEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreEmpleado.TabIndex = 59
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(123, 107)
        Me.txtIDEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(66, 22)
        Me.txtIDEmpleado.TabIndex = 58
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(562, 25)
        Me.btnProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(57, 28)
        Me.btnProducto.TabIndex = 57
        Me.btnProducto.Text = "..."
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'txtNombreProd
        '
        Me.txtNombreProd.Location = New System.Drawing.Point(199, 27)
        Me.txtNombreProd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreProd.Name = "txtNombreProd"
        Me.txtNombreProd.ReadOnly = True
        Me.txtNombreProd.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreProd.TabIndex = 56
        '
        'txtIDProducto
        '
        Me.txtIDProducto.Location = New System.Drawing.Point(123, 27)
        Me.txtIDProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDProducto.Name = "txtIDProducto"
        Me.txtIDProducto.ReadOnly = True
        Me.txtIDProducto.Size = New System.Drawing.Size(66, 22)
        Me.txtIDProducto.TabIndex = 55
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(380, 209)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(157, 22)
        Me.txtTotal.TabIndex = 53
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(123, 206)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(144, 22)
        Me.txtPrecio.TabIndex = 52
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(380, 157)
        Me.txtDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(77, 22)
        Me.txtDescuento.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(285, 159)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Desuento:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(28, 211)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 17)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Precio:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(316, 211)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Total:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 157)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 17)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 112)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Empleado:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(123, 157)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(144, 22)
        Me.txtCantidad.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 16)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 34)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Producto " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Compuesto:"
        '
        'TbEmpleado
        '
        Me.TbEmpleado.Controls.Add(Me.dgvEmpleados)
        Me.TbEmpleado.Location = New System.Drawing.Point(4, 25)
        Me.TbEmpleado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TbEmpleado.Name = "TbEmpleado"
        Me.TbEmpleado.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TbEmpleado.Size = New System.Drawing.Size(1599, 527)
        Me.TbEmpleado.TabIndex = 2
        Me.TbEmpleado.Text = "Empleados"
        Me.TbEmpleado.UseVisualStyleBackColor = True
        '
        'dgvEmpleados
        '
        Me.dgvEmpleados.AllowUserToAddRows = False
        Me.dgvEmpleados.AllowUserToDeleteRows = False
        Me.dgvEmpleados.AllowUserToResizeRows = False
        Me.dgvEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleados.Location = New System.Drawing.Point(10, 8)
        Me.dgvEmpleados.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvEmpleados.MultiSelect = False
        Me.dgvEmpleados.Name = "dgvEmpleados"
        Me.dgvEmpleados.ReadOnly = True
        Me.dgvEmpleados.RowHeadersWidth = 51
        Me.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleados.Size = New System.Drawing.Size(1580, 514)
        Me.dgvEmpleados.TabIndex = 1
        '
        'TbSelectEntrega
        '
        Me.TbSelectEntrega.Controls.Add(Me.txtDescripcionEntrega)
        Me.TbSelectEntrega.Controls.Add(Me.txtNombreEntrega)
        Me.TbSelectEntrega.Controls.Add(Me.DTPEntrega)
        Me.TbSelectEntrega.Controls.Add(Me.Label9)
        Me.TbSelectEntrega.Controls.Add(Me.Label10)
        Me.TbSelectEntrega.Controls.Add(Me.Label11)
        Me.TbSelectEntrega.Location = New System.Drawing.Point(4, 25)
        Me.TbSelectEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.TbSelectEntrega.Name = "TbSelectEntrega"
        Me.TbSelectEntrega.Padding = New System.Windows.Forms.Padding(4)
        Me.TbSelectEntrega.Size = New System.Drawing.Size(1599, 527)
        Me.TbSelectEntrega.TabIndex = 1
        Me.TbSelectEntrega.Text = "Selección Entrega"
        Me.TbSelectEntrega.UseVisualStyleBackColor = True
        '
        'txtDescripcionEntrega
        '
        Me.txtDescripcionEntrega.Location = New System.Drawing.Point(158, 109)
        Me.txtDescripcionEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescripcionEntrega.Name = "txtDescripcionEntrega"
        Me.txtDescripcionEntrega.Size = New System.Drawing.Size(570, 77)
        Me.txtDescripcionEntrega.TabIndex = 72
        Me.txtDescripcionEntrega.Text = ""
        '
        'txtNombreEntrega
        '
        Me.txtNombreEntrega.Location = New System.Drawing.Point(160, 63)
        Me.txtNombreEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreEntrega.Name = "txtNombreEntrega"
        Me.txtNombreEntrega.Size = New System.Drawing.Size(568, 22)
        Me.txtNombreEntrega.TabIndex = 66
        '
        'DTPEntrega
        '
        Me.DTPEntrega.Location = New System.Drawing.Point(158, 17)
        Me.DTPEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.DTPEntrega.Name = "DTPEntrega"
        Me.DTPEntrega.Size = New System.Drawing.Size(484, 22)
        Me.DTPEntrega.TabIndex = 70
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 68)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 17)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Nombre:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 22)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 17)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Fecha:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 130)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 17)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Descripción:"
        '
        'TbEntregas
        '
        Me.TbEntregas.Controls.Add(Me.dgvEntrega)
        Me.TbEntregas.Location = New System.Drawing.Point(4, 25)
        Me.TbEntregas.Margin = New System.Windows.Forms.Padding(4)
        Me.TbEntregas.Name = "TbEntregas"
        Me.TbEntregas.Padding = New System.Windows.Forms.Padding(4)
        Me.TbEntregas.Size = New System.Drawing.Size(1599, 527)
        Me.TbEntregas.TabIndex = 0
        Me.TbEntregas.Text = "Entregas"
        Me.TbEntregas.UseVisualStyleBackColor = True
        '
        'dgvEntrega
        '
        Me.dgvEntrega.AllowUserToAddRows = False
        Me.dgvEntrega.AllowUserToDeleteRows = False
        Me.dgvEntrega.AllowUserToResizeRows = False
        Me.dgvEntrega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEntrega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntrega.Location = New System.Drawing.Point(8, 7)
        Me.dgvEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvEntrega.MultiSelect = False
        Me.dgvEntrega.Name = "dgvEntrega"
        Me.dgvEntrega.ReadOnly = True
        Me.dgvEntrega.RowHeadersWidth = 51
        Me.dgvEntrega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEntrega.Size = New System.Drawing.Size(1580, 514)
        Me.dgvEntrega.TabIndex = 0
        '
        'TbGeneral
        '
        Me.TbGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbGeneral.Controls.Add(Me.TbEntregas)
        Me.TbGeneral.Controls.Add(Me.TbSelectEntrega)
        Me.TbGeneral.Controls.Add(Me.TbEmpleado)
        Me.TbGeneral.Controls.Add(Me.tbDetalle)
        Me.TbGeneral.Location = New System.Drawing.Point(12, 30)
        Me.TbGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.SelectedIndex = 0
        Me.TbGeneral.Size = New System.Drawing.Size(1607, 556)
        Me.TbGeneral.TabIndex = 6
        '
        'frmEntregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1619, 614)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TbGeneral)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmEntregas"
        Me.Text = "frmEntregas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbDetalle.ResumeLayout(False)
        Me.tbDetalleE.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDetalleEntrega.ResumeLayout(False)
        Me.tbDetalleEntrega.PerformLayout()
        Me.TbEmpleado.ResumeLayout(False)
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbSelectEntrega.ResumeLayout(False)
        Me.TbSelectEntrega.PerformLayout()
        Me.TbEntregas.ResumeLayout(False)
        CType(Me.dgvEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents tbDetalle As TabPage
    Friend WithEvents tbDetalleE As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvDetalles As DataGridView
    Friend WithEvents tbDetalleEntrega As TabPage
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TbEmpleado As TabPage
    Friend WithEvents TbSelectEntrega As TabPage
    Friend WithEvents txtDescripcionEntrega As RichTextBox
    Friend WithEvents txtNombreEntrega As TextBox
    Friend WithEvents DTPEntrega As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TbEntregas As TabPage
    Friend WithEvents dgvEntrega As DataGridView
    Friend WithEvents TbGeneral As TabControl
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents btnProducto As Button
    Friend WithEvents txtNombreProd As TextBox
    Friend WithEvents txtIDProducto As TextBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIDUbicacion As TextBox
    Friend WithEvents txtNombreUbic As TextBox
    Friend WithEvents Label2 As Label
End Class
