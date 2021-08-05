<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccesoEmpleadoMenu
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbVentanas = New System.Windows.Forms.ComboBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleadoCocina = New System.Windows.Forms.TextBox()
        Me.lblEmplCocina = New System.Windows.Forms.Label()
        Me.txtIDEmpleadoCocina = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 144)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(887, 283)
        Me.DataGridView1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnRecargar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(911, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbVentanas)
        Me.GroupBox1.Controls.Add(Me.btnEmpleado)
        Me.GroupBox1.Controls.Add(Me.txtNombreEmpleadoCocina)
        Me.GroupBox1.Controls.Add(Me.lblEmplCocina)
        Me.GroupBox1.Controls.Add(Me.txtIDEmpleadoCocina)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(887, 89)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accesos del Empleado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Ventana:"
        '
        'cbVentanas
        '
        Me.cbVentanas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVentanas.FormattingEnabled = True
        Me.cbVentanas.Items.AddRange(New Object() {"frmPrincipal", "frmEmpleado"})
        Me.cbVentanas.Location = New System.Drawing.Point(147, 51)
        Me.cbVentanas.Name = "cbVentanas"
        Me.cbVentanas.Size = New System.Drawing.Size(323, 21)
        Me.cbVentanas.TabIndex = 35
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Location = New System.Drawing.Point(476, 23)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(43, 23)
        Me.btnEmpleado.TabIndex = 34
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleadoCocina
        '
        Me.txtNombreEmpleadoCocina.Location = New System.Drawing.Point(204, 25)
        Me.txtNombreEmpleadoCocina.Name = "txtNombreEmpleadoCocina"
        Me.txtNombreEmpleadoCocina.ReadOnly = True
        Me.txtNombreEmpleadoCocina.Size = New System.Drawing.Size(266, 20)
        Me.txtNombreEmpleadoCocina.TabIndex = 33
        '
        'lblEmplCocina
        '
        Me.lblEmplCocina.AutoSize = True
        Me.lblEmplCocina.Location = New System.Drawing.Point(16, 28)
        Me.lblEmplCocina.Name = "lblEmplCocina"
        Me.lblEmplCocina.Size = New System.Drawing.Size(84, 13)
        Me.lblEmplCocina.TabIndex = 31
        Me.lblEmplCocina.Text = "Empleado (PIN):"
        '
        'txtIDEmpleadoCocina
        '
        Me.txtIDEmpleadoCocina.Location = New System.Drawing.Point(147, 25)
        Me.txtIDEmpleadoCocina.Name = "txtIDEmpleadoCocina"
        Me.txtIDEmpleadoCocina.ReadOnly = True
        Me.txtIDEmpleadoCocina.Size = New System.Drawing.Size(51, 20)
        Me.txtIDEmpleadoCocina.TabIndex = 32
        '
        'frmAccesoEmpleadoMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 439)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmAccesoEmpleadoMenu"
        Me.Text = "..:: Acceso a Menus ::.."
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents txtNombreEmpleadoCocina As TextBox
    Friend WithEvents lblEmplCocina As Label
    Friend WithEvents txtIDEmpleadoCocina As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbVentanas As ComboBox
End Class
