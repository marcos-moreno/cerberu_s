<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPuestos
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvPuesto = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtNombrePuesto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.activo = New System.Windows.Forms.CheckBox()
        Me.buscarActivod = New System.Windows.Forms.CheckBox()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvPuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvPuesto)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage1.Size = New System.Drawing.Size(977, 367)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvPuesto
        '
        Me.dgvPuesto.AllowUserToAddRows = False
        Me.dgvPuesto.AllowUserToDeleteRows = False
        Me.dgvPuesto.AllowUserToResizeRows = False
        Me.dgvPuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPuesto.Location = New System.Drawing.Point(6, 6)
        Me.dgvPuesto.MultiSelect = False
        Me.dgvPuesto.Name = "dgvPuesto"
        Me.dgvPuesto.ReadOnly = True
        Me.dgvPuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPuesto.Size = New System.Drawing.Size(965, 355)
        Me.dgvPuesto.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.activo)
        Me.TabPage2.Controls.Add(Me.txtNombrePuesto)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(977, 367)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtNombrePuesto
        '
        Me.txtNombrePuesto.Location = New System.Drawing.Point(152, 69)
        Me.txtNombrePuesto.Name = "txtNombrePuesto"
        Me.txtNombrePuesto.Size = New System.Drawing.Size(236, 20)
        Me.txtNombrePuesto.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre del puesto"
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
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.btnNuevo.Text = "Nuevo"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnRecargar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(992, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(10, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(985, 393)
        Me.TabControl1.TabIndex = 7
        '
        'activo
        '
        Me.activo.AutoSize = True
        Me.activo.Location = New System.Drawing.Point(33, 121)
        Me.activo.Name = "activo"
        Me.activo.Size = New System.Drawing.Size(56, 17)
        Me.activo.TabIndex = 4
        Me.activo.Text = "Activo"
        Me.activo.UseVisualStyleBackColor = True
        '
        'buscarActivod
        '
        Me.buscarActivod.AutoSize = True
        Me.buscarActivod.Location = New System.Drawing.Point(292, 7)
        Me.buscarActivod.Name = "buscarActivod"
        Me.buscarActivod.Size = New System.Drawing.Size(56, 17)
        Me.buscarActivod.TabIndex = 5
        Me.buscarActivod.Text = "Activo"
        Me.buscarActivod.UseVisualStyleBackColor = True
        '
        'frmPuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 448)
        Me.Controls.Add(Me.buscarActivod)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmPuestos"
        Me.Text = "frmPuestos"
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvPuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvPuesto As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents txtNombrePuesto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents activo As CheckBox
    Friend WithEvents buscarActivod As CheckBox
End Class
