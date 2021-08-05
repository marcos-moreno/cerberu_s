<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoCompuesto
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
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjuntosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProductoCompuesto = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbDiscount = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigoCompuesto = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtIdModelo = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.txtIdTalla = New System.Windows.Forms.TextBox()
        Me.bteColor = New System.Windows.Forms.Button()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.txtIdColor = New System.Windows.Forms.TextBox()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.txtDescProducto = New System.Windows.Forms.TextBox()
        Me.txtIDProducto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProductoCompuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 29)
        Me.btnBuscar.Text = "Buscar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnBuscar, Me.btnEliminar, Me.btnComentarios, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente, Me.AdjuntosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1261, 35)
        Me.MenuStrip1.TabIndex = 10
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
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(87, 29)
        Me.bntGuardar.Text = "Guardar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 29)
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(125, 29)
        Me.btnComentarios.Text = "Comentarios"
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
        'AdjuntosToolStripMenuItem
        '
        Me.AdjuntosToolStripMenuItem.Name = "AdjuntosToolStripMenuItem"
        Me.AdjuntosToolStripMenuItem.Size = New System.Drawing.Size(96, 29)
        Me.AdjuntosToolStripMenuItem.Text = "Adjuntos"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(180, 25)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 771)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1261, 30)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvProductoCompuesto)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(1235, 691)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvProductoCompuesto
        '
        Me.dgvProductoCompuesto.AllowUserToAddRows = False
        Me.dgvProductoCompuesto.AllowUserToDeleteRows = False
        Me.dgvProductoCompuesto.AllowUserToResizeRows = False
        Me.dgvProductoCompuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductoCompuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProductoCompuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductoCompuesto.Location = New System.Drawing.Point(9, 9)
        Me.dgvProductoCompuesto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvProductoCompuesto.MultiSelect = False
        Me.dgvProductoCompuesto.Name = "dgvProductoCompuesto"
        Me.dgvProductoCompuesto.ReadOnly = True
        Me.dgvProductoCompuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductoCompuesto.Size = New System.Drawing.Size(1213, 665)
        Me.dgvProductoCompuesto.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtPrecio)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtPorcentaje)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cbDiscount)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtCodigoCompuesto)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.txtModelo)
        Me.TabPage2.Controls.Add(Me.txtIdModelo)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtTalla)
        Me.TabPage2.Controls.Add(Me.txtIdTalla)
        Me.TabPage2.Controls.Add(Me.bteColor)
        Me.TabPage2.Controls.Add(Me.txtColor)
        Me.TabPage2.Controls.Add(Me.txtIdColor)
        Me.TabPage2.Controls.Add(Me.btnProducto)
        Me.TabPage2.Controls.Add(Me.txtDescProducto)
        Me.TabPage2.Controls.Add(Me.txtIDProducto)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage2.Size = New System.Drawing.Size(1235, 691)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(480, 270)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 20)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "%"
        Me.Label8.Visible = False
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.AcceptsTab = True
        Me.txtPorcentaje.Location = New System.Drawing.Point(378, 265)
        Me.txtPorcentaje.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(94, 26)
        Me.txtPorcentaje.TabIndex = 49
        Me.txtPorcentaje.Text = "0"
        Me.txtPorcentaje.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(281, 268)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Porcentaje: "
        Me.Label7.Visible = False
        '
        'cbDiscount
        '
        Me.cbDiscount.AutoCompleteCustomSource.AddRange(New String() {"SI", "NO"})
        Me.cbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDiscount.FormattingEnabled = True
        Me.cbDiscount.Items.AddRange(New Object() {"SI", "NO"})
        Me.cbDiscount.Location = New System.Drawing.Point(157, 265)
        Me.cbDiscount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbDiscount.Name = "cbDiscount"
        Me.cbDiscount.Size = New System.Drawing.Size(93, 28)
        Me.cbDiscount.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 268)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Aplica descuento :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 388)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Código Compuesto:"
        '
        'txtCodigoCompuesto
        '
        Me.txtCodigoCompuesto.AcceptsTab = True
        Me.txtCodigoCompuesto.Location = New System.Drawing.Point(182, 385)
        Me.txtCodigoCompuesto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCodigoCompuesto.Name = "txtCodigoCompuesto"
        Me.txtCodigoCompuesto.ReadOnly = True
        Me.txtCodigoCompuesto.Size = New System.Drawing.Size(404, 26)
        Me.txtCodigoCompuesto.TabIndex = 43
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(620, 195)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 35)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtModelo
        '
        Me.txtModelo.AcceptsTab = True
        Me.txtModelo.Location = New System.Drawing.Point(200, 200)
        Me.txtModelo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(397, 26)
        Me.txtModelo.TabIndex = 41
        '
        'txtIdModelo
        '
        Me.txtIdModelo.Location = New System.Drawing.Point(100, 200)
        Me.txtIdModelo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIdModelo.Name = "txtIdModelo"
        Me.txtIdModelo.ReadOnly = True
        Me.txtIdModelo.Size = New System.Drawing.Size(74, 26)
        Me.txtIdModelo.TabIndex = 40
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(620, 145)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 35)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTalla
        '
        Me.txtTalla.AcceptsTab = True
        Me.txtTalla.Location = New System.Drawing.Point(200, 150)
        Me.txtTalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.ReadOnly = True
        Me.txtTalla.Size = New System.Drawing.Size(397, 26)
        Me.txtTalla.TabIndex = 38
        '
        'txtIdTalla
        '
        Me.txtIdTalla.Location = New System.Drawing.Point(100, 150)
        Me.txtIdTalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIdTalla.Name = "txtIdTalla"
        Me.txtIdTalla.ReadOnly = True
        Me.txtIdTalla.Size = New System.Drawing.Size(74, 26)
        Me.txtIdTalla.TabIndex = 37
        '
        'bteColor
        '
        Me.bteColor.Location = New System.Drawing.Point(620, 95)
        Me.bteColor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bteColor.Name = "bteColor"
        Me.bteColor.Size = New System.Drawing.Size(64, 35)
        Me.bteColor.TabIndex = 36
        Me.bteColor.Text = "..."
        Me.bteColor.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.AcceptsTab = True
        Me.txtColor.Location = New System.Drawing.Point(200, 100)
        Me.txtColor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(397, 26)
        Me.txtColor.TabIndex = 35
        '
        'txtIdColor
        '
        Me.txtIdColor.Location = New System.Drawing.Point(100, 100)
        Me.txtIdColor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIdColor.Name = "txtIdColor"
        Me.txtIdColor.ReadOnly = True
        Me.txtIdColor.Size = New System.Drawing.Size(74, 26)
        Me.txtIdColor.TabIndex = 34
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(620, 45)
        Me.btnProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(64, 35)
        Me.btnProducto.TabIndex = 33
        Me.btnProducto.Text = "..."
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'txtDescProducto
        '
        Me.txtDescProducto.Location = New System.Drawing.Point(200, 50)
        Me.txtDescProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescProducto.Name = "txtDescProducto"
        Me.txtDescProducto.ReadOnly = True
        Me.txtDescProducto.Size = New System.Drawing.Size(397, 26)
        Me.txtDescProducto.TabIndex = 32
        '
        'txtIDProducto
        '
        Me.txtIDProducto.Location = New System.Drawing.Point(100, 50)
        Me.txtIDProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIDProducto.Name = "txtIDProducto"
        Me.txtIDProducto.ReadOnly = True
        Me.txtIDProducto.Size = New System.Drawing.Size(74, 26)
        Me.txtIDProducto.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 104)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Color:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 154)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Talla:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 204)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Modelo:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(18, 42)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1243, 724)
        Me.TabControl1.TabIndex = 9
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(157, 327)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(162, 26)
        Me.txtPrecio.TabIndex = 54
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 333)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 20)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Precio:"
        '
        'frmProductoCompuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 801)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmProductoCompuesto"
        Me.Text = "frmProductoCompuesto"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvProductoCompuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents AdjuntosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvProductoCompuesto As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnProducto As Button
    Friend WithEvents txtDescProducto As TextBox
    Friend WithEvents txtIDProducto As TextBox
    Friend WithEvents bteColor As Button
    Friend WithEvents txtColor As TextBox
    Friend WithEvents txtIdColor As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents txtIdModelo As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTalla As TextBox
    Friend WithEvents txtIdTalla As TextBox
    Friend WithEvents txtCodigoCompuesto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbDiscount As ComboBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label15 As Label
End Class
