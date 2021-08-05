<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCargasGasolina
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImportarExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjuntosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabGasolina = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.CmbFiltro = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvGasolina = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreAsignadoA = New System.Windows.Forms.TextBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rbCobroSi = New System.Windows.Forms.RadioButton()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.txtMontoCuenta = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rbCobroNo = New System.Windows.Forms.RadioButton()
        Me.txtNoCuenta = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BtnGenerarCxp = New System.Windows.Forms.Button()
        Me.txtNombreUnidad = New System.Windows.Forms.TextBox()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.DtpFechaCuenta = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtIdAsignadoA = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtVehiculo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txtplacas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtGrupo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtEstacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFechaYHora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDespacho = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtPocision = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.chbProcesado = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.TabGasolina.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvGasolina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarExcelToolStripMenuItem, Me.AdjuntosToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.AdjuntosToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1051, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImportarExcelToolStripMenuItem
        '
        Me.ImportarExcelToolStripMenuItem.Name = "ImportarExcelToolStripMenuItem"
        Me.ImportarExcelToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.ImportarExcelToolStripMenuItem.Text = "Importar Excel"
        '
        'AdjuntosToolStripMenuItem
        '
        Me.AdjuntosToolStripMenuItem.Name = "AdjuntosToolStripMenuItem"
        Me.AdjuntosToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.AdjuntosToolStripMenuItem.Text = "Recargar Grid"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'AdjuntosToolStripMenuItem1
        '
        Me.AdjuntosToolStripMenuItem1.Name = "AdjuntosToolStripMenuItem1"
        Me.AdjuntosToolStripMenuItem1.Size = New System.Drawing.Size(67, 20)
        Me.AdjuntosToolStripMenuItem1.Text = "Adjuntos"
        '
        'TabGasolina
        '
        Me.TabGasolina.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabGasolina.Controls.Add(Me.TabPage1)
        Me.TabGasolina.Controls.Add(Me.TabPage2)
        Me.TabGasolina.Location = New System.Drawing.Point(0, 27)
        Me.TabGasolina.Name = "TabGasolina"
        Me.TabGasolina.SelectedIndex = 0
        Me.TabGasolina.Size = New System.Drawing.Size(1039, 482)
        Me.TabGasolina.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtFiltro)
        Me.TabPage1.Controls.Add(Me.CmbFiltro)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.CmbPeriodo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dgvGasolina)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1031, 456)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(644, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Filtro:"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(682, 22)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(248, 20)
        Me.txtFiltro.TabIndex = 5
        '
        'CmbFiltro
        '
        Me.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFiltro.FormattingEnabled = True
        Me.CmbFiltro.Location = New System.Drawing.Point(372, 19)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(253, 21)
        Me.CmbFiltro.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(337, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Filtro"
        '
        'CmbPeriodo
        '
        Me.CmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeriodo.FormattingEnabled = True
        Me.CmbPeriodo.Location = New System.Drawing.Point(65, 19)
        Me.CmbPeriodo.Name = "CmbPeriodo"
        Me.CmbPeriodo.Size = New System.Drawing.Size(253, 21)
        Me.CmbPeriodo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Periodo"
        '
        'dgvGasolina
        '
        Me.dgvGasolina.AllowUserToAddRows = False
        Me.dgvGasolina.AllowUserToDeleteRows = False
        Me.dgvGasolina.AllowUserToResizeColumns = False
        Me.dgvGasolina.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGasolina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvGasolina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGasolina.Location = New System.Drawing.Point(19, 61)
        Me.dgvGasolina.MultiSelect = False
        Me.dgvGasolina.Name = "dgvGasolina"
        Me.dgvGasolina.ReadOnly = True
        Me.dgvGasolina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGasolina.Size = New System.Drawing.Size(993, 372)
        Me.dgvGasolina.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1031, 456)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1017, 444)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chbProcesado)
        Me.GroupBox4.Controls.Add(Me.btnEliminarEmpleado)
        Me.GroupBox4.Controls.Add(Me.txtNombreAsignadoA)
        Me.GroupBox4.Controls.Add(Me.btnEmpleado)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.rbCobroSi)
        Me.GroupBox4.Controls.Add(Me.txtDescuento)
        Me.GroupBox4.Controls.Add(Me.txtMontoCuenta)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.rbCobroNo)
        Me.GroupBox4.Controls.Add(Me.txtNoCuenta)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.BtnGenerarCxp)
        Me.GroupBox4.Controls.Add(Me.txtNombreUnidad)
        Me.GroupBox4.Controls.Add(Me.txtPlaca)
        Me.GroupBox4.Controls.Add(Me.DtpFechaCuenta)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtIdAsignadoA)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(529, 60)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(370, 362)
        Me.GroupBox4.TabIndex = 120
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Configuraciones"
        '
        'btnEliminarEmpleado
        '
        Me.btnEliminarEmpleado.Enabled = False
        Me.btnEliminarEmpleado.Location = New System.Drawing.Point(310, 147)
        Me.btnEliminarEmpleado.Name = "btnEliminarEmpleado"
        Me.btnEliminarEmpleado.Size = New System.Drawing.Size(45, 23)
        Me.btnEliminarEmpleado.TabIndex = 119
        Me.btnEliminarEmpleado.Text = "X"
        Me.btnEliminarEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreAsignadoA
        '
        Me.txtNombreAsignadoA.Location = New System.Drawing.Point(84, 150)
        Me.txtNombreAsignadoA.Name = "txtNombreAsignadoA"
        Me.txtNombreAsignadoA.ReadOnly = True
        Me.txtNombreAsignadoA.Size = New System.Drawing.Size(169, 20)
        Me.txtNombreAsignadoA.TabIndex = 118
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Enabled = False
        Me.btnEmpleado.Location = New System.Drawing.Point(259, 148)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(45, 23)
        Me.btnEmpleado.TabIndex = 117
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(82, 182)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 13)
        Me.Label22.TabIndex = 115
        Me.Label22.Text = "Unidad"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(206, 233)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "% Descuento"
        '
        'rbCobroSi
        '
        Me.rbCobroSi.AutoSize = True
        Me.rbCobroSi.Enabled = False
        Me.rbCobroSi.Location = New System.Drawing.Point(18, 252)
        Me.rbCobroSi.Name = "rbCobroSi"
        Me.rbCobroSi.Size = New System.Drawing.Size(34, 17)
        Me.rbCobroSi.TabIndex = 115
        Me.rbCobroSi.Text = "Si"
        Me.rbCobroSi.UseVisualStyleBackColor = True
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(209, 249)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(146, 20)
        Me.txtDescuento.TabIndex = 108
        '
        'txtMontoCuenta
        '
        Me.txtMontoCuenta.Location = New System.Drawing.Point(84, 87)
        Me.txtMontoCuenta.Name = "txtMontoCuenta"
        Me.txtMontoCuenta.ReadOnly = True
        Me.txtMontoCuenta.Size = New System.Drawing.Size(169, 20)
        Me.txtMontoCuenta.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Cuenta"
        '
        'rbCobroNo
        '
        Me.rbCobroNo.AutoSize = True
        Me.rbCobroNo.Checked = True
        Me.rbCobroNo.Enabled = False
        Me.rbCobroNo.Location = New System.Drawing.Point(74, 253)
        Me.rbCobroNo.Name = "rbCobroNo"
        Me.rbCobroNo.Size = New System.Drawing.Size(39, 17)
        Me.rbCobroNo.TabIndex = 116
        Me.rbCobroNo.TabStop = True
        Me.rbCobroNo.Text = "No"
        Me.rbCobroNo.UseVisualStyleBackColor = True
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Location = New System.Drawing.Point(16, 87)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.ReadOnly = True
        Me.txtNoCuenta.Size = New System.Drawing.Size(62, 20)
        Me.txtNoCuenta.TabIndex = 25
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 182)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 13)
        Me.Label20.TabIndex = 112
        Me.Label20.Text = "Placa"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 233)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Genera cobro"
        '
        'BtnGenerarCxp
        '
        Me.BtnGenerarCxp.Enabled = False
        Me.BtnGenerarCxp.Location = New System.Drawing.Point(270, 85)
        Me.BtnGenerarCxp.Name = "BtnGenerarCxp"
        Me.BtnGenerarCxp.Size = New System.Drawing.Size(75, 23)
        Me.BtnGenerarCxp.TabIndex = 0
        Me.BtnGenerarCxp.Text = "Generar CxC"
        Me.BtnGenerarCxp.UseVisualStyleBackColor = True
        '
        'txtNombreUnidad
        '
        Me.txtNombreUnidad.Location = New System.Drawing.Point(85, 198)
        Me.txtNombreUnidad.Name = "txtNombreUnidad"
        Me.txtNombreUnidad.ReadOnly = True
        Me.txtNombreUnidad.Size = New System.Drawing.Size(168, 20)
        Me.txtNombreUnidad.TabIndex = 111
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(17, 198)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.ReadOnly = True
        Me.txtPlaca.Size = New System.Drawing.Size(62, 20)
        Me.txtPlaca.TabIndex = 110
        '
        'DtpFechaCuenta
        '
        Me.DtpFechaCuenta.Enabled = False
        Me.DtpFechaCuenta.Location = New System.Drawing.Point(16, 40)
        Me.DtpFechaCuenta.Name = "DtpFechaCuenta"
        Me.DtpFechaCuenta.Size = New System.Drawing.Size(213, 20)
        Me.DtpFechaCuenta.TabIndex = 114
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "Fecha cuenta"
        '
        'txtIdAsignadoA
        '
        Me.txtIdAsignadoA.Location = New System.Drawing.Point(16, 150)
        Me.txtIdAsignadoA.Name = "txtIdAsignadoA"
        Me.txtIdAsignadoA.ReadOnly = True
        Me.txtIdAsignadoA.Size = New System.Drawing.Size(62, 20)
        Me.txtIdAsignadoA.TabIndex = 109
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 134)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Unidad asignada a:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtVehiculo)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Txtplacas)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TxtGrupo)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TxtEstacion)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtFechaYHora)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtDespacho)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtMonto)
        Me.GroupBox3.Controls.Add(Me.txtPocision)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtProducto)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtCantidad)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 60)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(487, 362)
        Me.GroupBox3.TabIndex = 119
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos Importados"
        '
        'TxtVehiculo
        '
        Me.TxtVehiculo.Location = New System.Drawing.Point(24, 44)
        Me.TxtVehiculo.Name = "TxtVehiculo"
        Me.TxtVehiculo.ReadOnly = True
        Me.TxtVehiculo.Size = New System.Drawing.Size(213, 20)
        Me.TxtVehiculo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vehículo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Placas"
        '
        'Txtplacas
        '
        Me.Txtplacas.Location = New System.Drawing.Point(24, 101)
        Me.Txtplacas.Name = "Txtplacas"
        Me.Txtplacas.ReadOnly = True
        Me.Txtplacas.Size = New System.Drawing.Size(213, 20)
        Me.Txtplacas.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(24, 158)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(213, 20)
        Me.TxtDescripcion.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Grupo"
        '
        'TxtGrupo
        '
        Me.TxtGrupo.Location = New System.Drawing.Point(24, 212)
        Me.TxtGrupo.Name = "TxtGrupo"
        Me.TxtGrupo.ReadOnly = True
        Me.TxtGrupo.Size = New System.Drawing.Size(213, 20)
        Me.TxtGrupo.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Estación"
        '
        'TxtEstacion
        '
        Me.TxtEstacion.Location = New System.Drawing.Point(24, 269)
        Me.TxtEstacion.Name = "TxtEstacion"
        Me.TxtEstacion.ReadOnly = True
        Me.TxtEstacion.Size = New System.Drawing.Size(213, 20)
        Me.TxtEstacion.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(253, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Fecha y hora"
        '
        'txtFechaYHora
        '
        Me.txtFechaYHora.Location = New System.Drawing.Point(256, 44)
        Me.txtFechaYHora.Name = "txtFechaYHora"
        Me.txtFechaYHora.ReadOnly = True
        Me.txtFechaYHora.Size = New System.Drawing.Size(213, 20)
        Me.txtFechaYHora.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(253, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Despacho"
        '
        'txtDespacho
        '
        Me.txtDespacho.Location = New System.Drawing.Point(256, 101)
        Me.txtDespacho.Name = "txtDespacho"
        Me.txtDespacho.ReadOnly = True
        Me.txtDespacho.Size = New System.Drawing.Size(213, 20)
        Me.txtDespacho.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 314)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Monto $"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(253, 142)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Pocisión"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(24, 330)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(213, 20)
        Me.txtMonto.TabIndex = 23
        '
        'txtPocision
        '
        Me.txtPocision.Location = New System.Drawing.Point(256, 158)
        Me.txtPocision.Name = "txtPocision"
        Me.txtPocision.ReadOnly = True
        Me.txtPocision.Size = New System.Drawing.Size(213, 20)
        Me.txtPocision.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(253, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Producto"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(256, 212)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(213, 20)
        Me.txtProducto.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(253, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Cantidad LT"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(256, 269)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(213, 20)
        Me.txtCantidad.TabIndex = 21
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(175, 28)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(213, 20)
        Me.txtEstado.TabIndex = 101
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(15, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(154, 13)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Estado del DOCUMENTO:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'chbProcesado
        '
        Me.chbProcesado.AutoSize = True
        Me.chbProcesado.Enabled = False
        Me.chbProcesado.Location = New System.Drawing.Point(18, 293)
        Me.chbProcesado.Name = "chbProcesado"
        Me.chbProcesado.Size = New System.Drawing.Size(77, 17)
        Me.chbProcesado.TabIndex = 120
        Me.chbProcesado.Text = "Procesado"
        Me.chbProcesado.UseVisualStyleBackColor = True
        '
        'FrmCargasGasolina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 521)
        Me.Controls.Add(Me.TabGasolina)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmCargasGasolina"
        Me.Text = "..::CxC Gasolinas::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabGasolina.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvGasolina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ImportarExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabGasolina As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvGasolina As DataGridView
    Friend WithEvents CmbPeriodo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnGenerarCxp As Button
    Friend WithEvents TxtVehiculo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtplacas As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtEstacion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtGrupo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtProducto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPocision As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDespacho As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFechaYHora As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtMontoCuenta As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNoCuenta As TextBox
    Friend WithEvents CmbFiltro As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents AdjuntosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents AdjuntosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtIdAsignadoA As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtNombreUnidad As TextBox
    Friend WithEvents txtPlaca As TextBox
    Friend WithEvents DtpFechaCuenta As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnEliminarEmpleado As Button
    Friend WithEvents txtNombreAsignadoA As TextBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents rbCobroNo As RadioButton
    Friend WithEvents rbCobroSi As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents chbProcesado As CheckBox
End Class
