<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDestajo
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtBurbujasMolde = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDestajo = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.SincronizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SincronizarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarPagoSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblTotalSeleccion = New System.Windows.Forms.Label()
        Me.chbSelTodo = New System.Windows.Forms.CheckBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.chbTodo = New System.Windows.Forms.CheckBox()
        Me.chbSoloPendientes = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.esPagado = New System.Windows.Forms.CheckBox()
        Me.cbEtapa = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEtiqueta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumPuntos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbOrigen = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMontoDes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBurbujasEmp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaDes = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        CType(Me.dgvDestajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Origen:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 20)
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
        Me.cbEmpresa.Location = New System.Drawing.Point(106, 17)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(323, 21)
        Me.cbEmpresa.TabIndex = 10
        '
        'txtBurbujasMolde
        '
        Me.txtBurbujasMolde.Location = New System.Drawing.Point(646, 44)
        Me.txtBurbujasMolde.Name = "txtBurbujasMolde"
        Me.txtBurbujasMolde.Size = New System.Drawing.Size(229, 20)
        Me.txtBurbujasMolde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(515, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Burbujas X Molde:"
        '
        'dgvDestajo
        '
        Me.dgvDestajo.AllowUserToAddRows = False
        Me.dgvDestajo.AllowUserToDeleteRows = False
        Me.dgvDestajo.AllowUserToResizeRows = False
        Me.dgvDestajo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDestajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDestajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDestajo.Location = New System.Drawing.Point(6, 29)
        Me.dgvDestajo.MultiSelect = False
        Me.dgvDestajo.Name = "dgvDestajo"
        Me.dgvDestajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDestajo.Size = New System.Drawing.Size(1002, 281)
        Me.dgvDestajo.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem, Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente, Me.SincronizarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1046, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.Visible = False
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(61, 20)
        Me.bntGuardar.Text = "Guardar"
        Me.bntGuardar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(87, 20)
        Me.btnComentarios.Text = "Comentarios"
        Me.btnComentarios.Visible = False
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.btnAdjuntos.Text = "Adjuntos"
        Me.btnAdjuntos.Visible = False
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
        'SincronizarToolStripMenuItem
        '
        Me.SincronizarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SincronizarToolStripMenuItem1, Me.GenerarPagoSeleccionadosToolStripMenuItem})
        Me.SincronizarToolStripMenuItem.Name = "SincronizarToolStripMenuItem"
        Me.SincronizarToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.SincronizarToolStripMenuItem.Text = "Eventos Destajo"
        '
        'SincronizarToolStripMenuItem1
        '
        Me.SincronizarToolStripMenuItem1.Name = "SincronizarToolStripMenuItem1"
        Me.SincronizarToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.SincronizarToolStripMenuItem1.Text = "Sincronizar"
        '
        'GenerarPagoSeleccionadosToolStripMenuItem
        '
        Me.GenerarPagoSeleccionadosToolStripMenuItem.Name = "GenerarPagoSeleccionadosToolStripMenuItem"
        Me.GenerarPagoSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.GenerarPagoSeleccionadosToolStripMenuItem.Text = "Generar Pago Seleccionados"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 392)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1046, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
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
        Me.TabControl1.Size = New System.Drawing.Size(1022, 362)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblTotalSeleccion)
        Me.TabPage1.Controls.Add(Me.chbSelTodo)
        Me.TabPage1.Controls.Add(Me.lblTotal)
        Me.TabPage1.Controls.Add(Me.chbTodo)
        Me.TabPage1.Controls.Add(Me.chbSoloPendientes)
        Me.TabPage1.Controls.Add(Me.dgvDestajo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1014, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblTotalSeleccion
        '
        Me.lblTotalSeleccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalSeleccion.AutoSize = True
        Me.lblTotalSeleccion.Location = New System.Drawing.Point(7, 316)
        Me.lblTotalSeleccion.Name = "lblTotalSeleccion"
        Me.lblTotalSeleccion.Size = New System.Drawing.Size(45, 13)
        Me.lblTotalSeleccion.TabIndex = 18
        Me.lblTotalSeleccion.Text = "Label13"
        '
        'chbSelTodo
        '
        Me.chbSelTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbSelTodo.AutoSize = True
        Me.chbSelTodo.Location = New System.Drawing.Point(855, 6)
        Me.chbSelTodo.Name = "chbSelTodo"
        Me.chbSelTodo.Size = New System.Drawing.Size(153, 17)
        Me.chbSelTodo.TabIndex = 17
        Me.chbSelTodo.Text = "Quitar - Seleccionar TODO"
        Me.chbSelTodo.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(6, 6)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(45, 13)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Label13"
        '
        'chbTodo
        '
        Me.chbTodo.AutoSize = True
        Me.chbTodo.Location = New System.Drawing.Point(370, 6)
        Me.chbTodo.Name = "chbTodo"
        Me.chbTodo.Size = New System.Drawing.Size(95, 17)
        Me.chbTodo.TabIndex = 15
        Me.chbTodo.Text = "Mostrar TODO"
        Me.chbTodo.UseVisualStyleBackColor = True
        '
        'chbSoloPendientes
        '
        Me.chbSoloPendientes.AutoSize = True
        Me.chbSoloPendientes.Checked = True
        Me.chbSoloPendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSoloPendientes.Location = New System.Drawing.Point(153, 6)
        Me.chbSoloPendientes.Name = "chbSoloPendientes"
        Me.chbSoloPendientes.Size = New System.Drawing.Size(192, 17)
        Me.chbSoloPendientes.TabIndex = 14
        Me.chbSoloPendientes.Text = "Mostrar solo los Pendintes de Pago"
        Me.chbSoloPendientes.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtReferencia)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.esPagado)
        Me.TabPage2.Controls.Add(Me.cbEtapa)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtEtiqueta)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtNumPuntos)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.cbOrigen)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtNombreEmpleado)
        Me.TabPage2.Controls.Add(Me.txtIDEmpleado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtMontoDes)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtBurbujasEmp)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtpFechaDes)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.txtBurbujasMolde)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1014, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(106, 177)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(323, 20)
        Me.txtReferencia.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Referencia:"
        '
        'esActivo
        '
        Me.esActivo.AutoSize = True
        Me.esActivo.Location = New System.Drawing.Point(518, 178)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(74, 17)
        Me.esActivo.TabIndex = 39
        Me.esActivo.Text = "Es Activo:"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'esPagado
        '
        Me.esPagado.AutoSize = True
        Me.esPagado.Location = New System.Drawing.Point(518, 152)
        Me.esPagado.Name = "esPagado"
        Me.esPagado.Size = New System.Drawing.Size(81, 17)
        Me.esPagado.TabIndex = 38
        Me.esPagado.Text = "Es Pagado:"
        Me.esPagado.UseVisualStyleBackColor = True
        '
        'cbEtapa
        '
        Me.cbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEtapa.FormattingEnabled = True
        Me.cbEtapa.Location = New System.Drawing.Point(106, 150)
        Me.cbEtapa.Name = "cbEtapa"
        Me.cbEtapa.Size = New System.Drawing.Size(323, 21)
        Me.cbEtapa.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Etapa:"
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(106, 124)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(323, 20)
        Me.txtEtiqueta.TabIndex = 35
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Etiqueta:"
        '
        'txtNumPuntos
        '
        Me.txtNumPuntos.Location = New System.Drawing.Point(646, 124)
        Me.txtNumPuntos.Name = "txtNumPuntos"
        Me.txtNumPuntos.Size = New System.Drawing.Size(229, 20)
        Me.txtNumPuntos.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(515, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Número de Puntos:"
        '
        'cbOrigen
        '
        Me.cbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrigen.FormattingEnabled = True
        Me.cbOrigen.Location = New System.Drawing.Point(106, 71)
        Me.cbOrigen.Name = "cbOrigen"
        Me.cbOrigen.Size = New System.Drawing.Size(323, 21)
        Me.cbOrigen.TabIndex = 31
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(435, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(163, 98)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(266, 20)
        Me.txtNombreEmpleado.TabIndex = 29
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(106, 98)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(51, 20)
        Me.txtIDEmpleado.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Empleado (PIN):"
        '
        'txtMontoDes
        '
        Me.txtMontoDes.Location = New System.Drawing.Point(646, 98)
        Me.txtMontoDes.Name = "txtMontoDes"
        Me.txtMontoDes.Size = New System.Drawing.Size(229, 20)
        Me.txtMontoDes.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Monto Destajo:"
        '
        'txtBurbujasEmp
        '
        Me.txtBurbujasEmp.Location = New System.Drawing.Point(646, 72)
        Me.txtBurbujasEmp.Name = "txtBurbujasEmp"
        Me.txtBurbujasEmp.Size = New System.Drawing.Size(229, 20)
        Me.txtBurbujasEmp.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(515, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Burbujas X Empleado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Sucursal:"
        '
        'dtpFechaDes
        '
        Me.dtpFechaDes.Location = New System.Drawing.Point(646, 14)
        Me.dtpFechaDes.Name = "dtpFechaDes"
        Me.dtpFechaDes.Size = New System.Drawing.Size(229, 20)
        Me.dtpFechaDes.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(515, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha de Destajo:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(106, 44)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(323, 21)
        Me.cbSucursal.TabIndex = 12
        '
        'frmDestajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 414)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmDestajo"
        Me.Text = "..:: DESTAJOS ::.."
        CType(Me.dgvDestajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents txtBurbujasMolde As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDestajo As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
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
    Friend WithEvents txtMontoDes As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBurbujasEmp As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaDes As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents cbOrigen As ComboBox
    Friend WithEvents txtEtiqueta As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNumPuntos As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents esPagado As CheckBox
    Friend WithEvents cbEtapa As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents SincronizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SincronizarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GenerarPagoSeleccionadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chbSoloPendientes As CheckBox
    Friend WithEvents chbTodo As CheckBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents chbSelTodo As CheckBox
    Friend WithEvents lblTotalSeleccion As Label
End Class
