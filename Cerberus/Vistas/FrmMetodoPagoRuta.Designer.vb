<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMetodoPagoRuta
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
        Me.TabMetodoPago = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvMetodoPagoRuta = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CmTipoMetodo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNombreCuenta = New System.Windows.Forms.TextBox()
        Me.TxtIdCuenta = New System.Windows.Forms.TextBox()
        Me.BtnIdCuenta = New System.Windows.Forms.Button()
        Me.txtValorMetodo = New System.Windows.Forms.TextBox()
        Me.TxtKMFin = New System.Windows.Forms.TextBox()
        Me.txtKMInicio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMetodoPago.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvMetodoPagoRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMetodoPago
        '
        Me.TabMetodoPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMetodoPago.Controls.Add(Me.TabPage1)
        Me.TabMetodoPago.Controls.Add(Me.TabPage2)
        Me.TabMetodoPago.Location = New System.Drawing.Point(12, 27)
        Me.TabMetodoPago.Name = "TabMetodoPago"
        Me.TabMetodoPago.SelectedIndex = 0
        Me.TabMetodoPago.Size = New System.Drawing.Size(599, 380)
        Me.TabMetodoPago.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvMetodoPagoRuta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(591, 354)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvMetodoPagoRuta
        '
        Me.dgvMetodoPagoRuta.AllowUserToAddRows = False
        Me.dgvMetodoPagoRuta.AllowUserToDeleteRows = False
        Me.dgvMetodoPagoRuta.AllowUserToResizeRows = False
        Me.dgvMetodoPagoRuta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMetodoPagoRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMetodoPagoRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMetodoPagoRuta.Location = New System.Drawing.Point(6, 6)
        Me.dgvMetodoPagoRuta.MultiSelect = False
        Me.dgvMetodoPagoRuta.Name = "dgvMetodoPagoRuta"
        Me.dgvMetodoPagoRuta.ReadOnly = True
        Me.dgvMetodoPagoRuta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMetodoPagoRuta.Size = New System.Drawing.Size(574, 341)
        Me.dgvMetodoPagoRuta.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CmTipoMetodo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.TxtNombreCuenta)
        Me.TabPage2.Controls.Add(Me.TxtIdCuenta)
        Me.TabPage2.Controls.Add(Me.BtnIdCuenta)
        Me.TabPage2.Controls.Add(Me.txtValorMetodo)
        Me.TabPage2.Controls.Add(Me.TxtKMFin)
        Me.TabPage2.Controls.Add(Me.txtKMInicio)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(606, 365)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CmTipoMetodo
        '
        Me.CmTipoMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmTipoMetodo.FormattingEnabled = True
        Me.CmTipoMetodo.Location = New System.Drawing.Point(25, 139)
        Me.CmTipoMetodo.Name = "CmTipoMetodo"
        Me.CmTipoMetodo.Size = New System.Drawing.Size(269, 21)
        Me.CmTipoMetodo.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Cuenta"
        '
        'TxtNombreCuenta
        '
        Me.TxtNombreCuenta.Enabled = False
        Me.TxtNombreCuenta.Location = New System.Drawing.Point(68, 225)
        Me.TxtNombreCuenta.Name = "TxtNombreCuenta"
        Me.TxtNombreCuenta.Size = New System.Drawing.Size(188, 20)
        Me.TxtNombreCuenta.TabIndex = 10
        '
        'TxtIdCuenta
        '
        Me.TxtIdCuenta.Enabled = False
        Me.TxtIdCuenta.Location = New System.Drawing.Point(25, 225)
        Me.TxtIdCuenta.Name = "TxtIdCuenta"
        Me.TxtIdCuenta.Size = New System.Drawing.Size(37, 20)
        Me.TxtIdCuenta.TabIndex = 9
        '
        'BtnIdCuenta
        '
        Me.BtnIdCuenta.Location = New System.Drawing.Point(262, 222)
        Me.BtnIdCuenta.Name = "BtnIdCuenta"
        Me.BtnIdCuenta.Size = New System.Drawing.Size(32, 23)
        Me.BtnIdCuenta.TabIndex = 8
        Me.BtnIdCuenta.Text = "..."
        Me.BtnIdCuenta.UseVisualStyleBackColor = True
        '
        'txtValorMetodo
        '
        Me.txtValorMetodo.Location = New System.Drawing.Point(25, 179)
        Me.txtValorMetodo.Name = "txtValorMetodo"
        Me.txtValorMetodo.Size = New System.Drawing.Size(269, 20)
        Me.txtValorMetodo.TabIndex = 7
        '
        'TxtKMFin
        '
        Me.TxtKMFin.Location = New System.Drawing.Point(25, 85)
        Me.TxtKMFin.Name = "TxtKMFin"
        Me.TxtKMFin.Size = New System.Drawing.Size(269, 20)
        Me.TxtKMFin.TabIndex = 5
        '
        'txtKMInicio
        '
        Me.txtKMInicio.Location = New System.Drawing.Point(25, 35)
        Me.txtKMInicio.Name = "txtKMInicio"
        Me.txtKMInicio.Size = New System.Drawing.Size(269, 20)
        Me.txtKMInicio.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Valor Método"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo Método"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "KM Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "KM Inicio"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnGuardar, Me.BtnEliminar, Me.BtnAdjuntos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(623, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.BtnNuevo.Text = "Nuevo"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.BtnGuardar.Text = "Guardar"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.BtnEliminar.Text = "Eliminar"
        '
        'BtnAdjuntos
        '
        Me.BtnAdjuntos.Name = "BtnAdjuntos"
        Me.BtnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.BtnAdjuntos.Text = "Adjuntos"
        '
        'FrmMetodoPagoRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 419)
        Me.Controls.Add(Me.TabMetodoPago)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMetodoPagoRuta"
        Me.Text = "..:: Metodo Pago Ruta ::.."
        Me.TabMetodoPago.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvMetodoPagoRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabMetodoPago As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvMetodoPagoRuta As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BtnNuevo As ToolStripMenuItem
    Friend WithEvents BtnGuardar As ToolStripMenuItem
    Friend WithEvents BtnEliminar As ToolStripMenuItem
    Friend WithEvents BtnAdjuntos As ToolStripMenuItem
    Friend WithEvents txtValorMetodo As TextBox
    Friend WithEvents TxtKMFin As TextBox
    Friend WithEvents txtKMInicio As TextBox
    Friend WithEvents TxtNombreCuenta As TextBox
    Friend WithEvents TxtIdCuenta As TextBox
    Friend WithEvents BtnIdCuenta As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CmTipoMetodo As ComboBox
End Class
