<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDestajoUnionEmpleado
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvDestajoUnionEmp = New System.Windows.Forms.DataGridView()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.cbOrigen = New System.Windows.Forms.ComboBox()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDestajoUnionEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Origen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(502, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Sucursal:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDestajoUnionEmp)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1145, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvDestajoUnionEmp
        '
        Me.dgvDestajoUnionEmp.AllowUserToAddRows = False
        Me.dgvDestajoUnionEmp.AllowUserToDeleteRows = False
        Me.dgvDestajoUnionEmp.AllowUserToResizeRows = False
        Me.dgvDestajoUnionEmp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDestajoUnionEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDestajoUnionEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDestajoUnionEmp.Location = New System.Drawing.Point(6, 6)
        Me.dgvDestajoUnionEmp.MultiSelect = False
        Me.dgvDestajoUnionEmp.Name = "dgvDestajoUnionEmp"
        Me.dgvDestajoUnionEmp.ReadOnly = True
        Me.dgvDestajoUnionEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDestajoUnionEmp.Size = New System.Drawing.Size(1133, 358)
        Me.dgvDestajoUnionEmp.TabIndex = 0
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(559, 55)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(323, 21)
        Me.cbSucursal.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtNombreEmpleado)
        Me.TabPage2.Controls.Add(Me.txtIDEmpleado)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtReferencia)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1145, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(425, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(153, 29)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(266, 20)
        Me.txtNombreEmpleado.TabIndex = 33
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(96, 29)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(51, 20)
        Me.txtIDEmpleado.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(502, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Empresa:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Empleado (PIN):"
        '
        'esActivo
        '
        Me.esActivo.Location = New System.Drawing.Point(505, 83)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(71, 17)
        Me.esActivo.TabIndex = 0
        Me.esActivo.Text = "Es Activo"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'cbEmpresa
        '
        Me.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(559, 29)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(323, 21)
        Me.cbEmpresa.TabIndex = 10
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(96, 55)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(323, 20)
        Me.txtReferencia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Referencia:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1153, 396)
        Me.TabControl1.TabIndex = 14
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1177, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.btnNuevo.Text = "Nuevo"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(61, 20)
        Me.bntGuardar.Text = "Guardar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(87, 20)
        Me.btnComentarios.Text = "Comentarios"
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1177, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cbOrigen
        '
        Me.cbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrigen.FormattingEnabled = True
        Me.cbOrigen.Location = New System.Drawing.Point(102, 33)
        Me.cbOrigen.Name = "cbOrigen"
        Me.cbOrigen.Size = New System.Drawing.Size(323, 21)
        Me.cbOrigen.TabIndex = 35
        '
        'frmDestajoUnionEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 485)
        Me.Controls.Add(Me.cbOrigen)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Name = "frmDestajoUnionEmpleado"
        Me.Text = "..:: Asociacion Empleados ::.."
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvDestajoUnionEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvDestajoUnionEmp As DataGridView
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Button1 As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbOrigen As ComboBox
End Class
