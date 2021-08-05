<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFonacot
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep1Imp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep1Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep2Imp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep2Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep3Imp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep3Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep4Imp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep4Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep5Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep6Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFiltro = New System.Windows.Forms.DateTimePicker()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCuotas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnRep7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRep7Mod = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 477)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(986, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep1, Me.btnRep2, Me.btnRep3, Me.btnRep4, Me.btnRep5, Me.btnRep6, Me.btnRep7})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(65, 20)
        Me.btnReportes.Text = "Reportes"
        '
        'btnRep1
        '
        Me.btnRep1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep1Imp, Me.btnRep1Mod})
        Me.btnRep1.Name = "btnRep1"
        Me.btnRep1.Size = New System.Drawing.Size(180, 22)
        Me.btnRep1.Text = "Reporte 1"
        '
        'btnRep1Imp
        '
        Me.btnRep1Imp.Name = "btnRep1Imp"
        Me.btnRep1Imp.Size = New System.Drawing.Size(125, 22)
        Me.btnRep1Imp.Text = "Imprimir"
        '
        'btnRep1Mod
        '
        Me.btnRep1Mod.Name = "btnRep1Mod"
        Me.btnRep1Mod.Size = New System.Drawing.Size(125, 22)
        Me.btnRep1Mod.Text = "Modificar"
        '
        'btnRep2
        '
        Me.btnRep2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep2Imp, Me.btnRep2Mod})
        Me.btnRep2.Name = "btnRep2"
        Me.btnRep2.Size = New System.Drawing.Size(180, 22)
        Me.btnRep2.Text = "Reporte 2"
        '
        'btnRep2Imp
        '
        Me.btnRep2Imp.Name = "btnRep2Imp"
        Me.btnRep2Imp.Size = New System.Drawing.Size(125, 22)
        Me.btnRep2Imp.Text = "Imprimir"
        '
        'btnRep2Mod
        '
        Me.btnRep2Mod.Name = "btnRep2Mod"
        Me.btnRep2Mod.Size = New System.Drawing.Size(125, 22)
        Me.btnRep2Mod.Text = "Modificar"
        '
        'btnRep3
        '
        Me.btnRep3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep3Imp, Me.btnRep3Mod})
        Me.btnRep3.Name = "btnRep3"
        Me.btnRep3.Size = New System.Drawing.Size(180, 22)
        Me.btnRep3.Text = "Reporte 3"
        '
        'btnRep3Imp
        '
        Me.btnRep3Imp.Name = "btnRep3Imp"
        Me.btnRep3Imp.Size = New System.Drawing.Size(125, 22)
        Me.btnRep3Imp.Text = "Imprimir"
        '
        'btnRep3Mod
        '
        Me.btnRep3Mod.Name = "btnRep3Mod"
        Me.btnRep3Mod.Size = New System.Drawing.Size(125, 22)
        Me.btnRep3Mod.Text = "Modificar"
        '
        'btnRep4
        '
        Me.btnRep4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep4Imp, Me.btnRep4Mod})
        Me.btnRep4.Name = "btnRep4"
        Me.btnRep4.Size = New System.Drawing.Size(180, 22)
        Me.btnRep4.Text = "Reporte 4"
        '
        'btnRep4Imp
        '
        Me.btnRep4Imp.Name = "btnRep4Imp"
        Me.btnRep4Imp.Size = New System.Drawing.Size(125, 22)
        Me.btnRep4Imp.Text = "Imprimir"
        '
        'btnRep4Mod
        '
        Me.btnRep4Mod.Name = "btnRep4Mod"
        Me.btnRep4Mod.Size = New System.Drawing.Size(125, 22)
        Me.btnRep4Mod.Text = "Modificar"
        '
        'btnRep5
        '
        Me.btnRep5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep5Mod})
        Me.btnRep5.Name = "btnRep5"
        Me.btnRep5.Size = New System.Drawing.Size(180, 22)
        Me.btnRep5.Text = "Reporte 5"
        '
        'btnRep5Mod
        '
        Me.btnRep5Mod.Name = "btnRep5Mod"
        Me.btnRep5Mod.Size = New System.Drawing.Size(125, 22)
        Me.btnRep5Mod.Text = "Modificar"
        '
        'btnRep6
        '
        Me.btnRep6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep6Mod})
        Me.btnRep6.Name = "btnRep6"
        Me.btnRep6.Size = New System.Drawing.Size(180, 22)
        Me.btnRep6.Text = "Reporte 6"
        '
        'btnRep6Mod
        '
        Me.btnRep6Mod.Name = "btnRep6Mod"
        Me.btnRep6Mod.Size = New System.Drawing.Size(180, 22)
        Me.btnRep6Mod.Text = "Modificar"
        '
        'btnImportar
        '
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(65, 20)
        Me.btnImportar.Text = "Importar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReportes, Me.btnImportar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(986, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 124)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(962, 339)
        Me.dgv.TabIndex = 34
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(504, 49)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 23)
        Me.btnBuscar.TabIndex = 43
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(327, 49)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(171, 20)
        Me.txtFiltro.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(289, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Filtro:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Periodo / Ejercicio: "
        '
        'dtpFiltro
        '
        Me.dtpFiltro.CustomFormat = "MM-yyyy"
        Me.dtpFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFiltro.Location = New System.Drawing.Point(145, 46)
        Me.dtpFiltro.Name = "dtpFiltro"
        Me.dtpFiltro.Size = New System.Drawing.Size(129, 20)
        Me.dtpFiltro.TabIndex = 39
        '
        'cbSucursal
        '
        Me.cbSucursal.Enabled = False
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(82, 84)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(292, 21)
        Me.cbSucursal.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Sucursal:"
        '
        'txtCuotas
        '
        Me.txtCuotas.Enabled = False
        Me.txtCuotas.Location = New System.Drawing.Point(504, 85)
        Me.txtCuotas.Name = "txtCuotas"
        Me.txtCuotas.Size = New System.Drawing.Size(69, 20)
        Me.txtCuotas.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(411, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Cuotas Pagadas:"
        '
        'btnActualizar
        '
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.Location = New System.Drawing.Point(589, 82)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(97, 23)
        Me.btnActualizar.TabIndex = 48
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnRep7
        '
        Me.btnRep7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep7Mod})
        Me.btnRep7.Name = "btnRep7"
        Me.btnRep7.Size = New System.Drawing.Size(180, 22)
        Me.btnRep7.Text = "Reporte 7"
        '
        'btnRep7Mod
        '
        Me.btnRep7Mod.Name = "btnRep7Mod"
        Me.btnRep7Mod.Size = New System.Drawing.Size(180, 22)
        Me.btnRep7Mod.Text = "Modificar"
        '
        'frmFonacot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 499)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.txtCuotas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbSucursal)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFiltro)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmFonacot"
        Me.Text = "frmFonacot"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents btnImportar As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnRep1 As ToolStripMenuItem
    Friend WithEvents btnRep1Imp As ToolStripMenuItem
    Friend WithEvents btnRep1Mod As ToolStripMenuItem
    Friend WithEvents btnRep2 As ToolStripMenuItem
    Friend WithEvents btnRep2Imp As ToolStripMenuItem
    Friend WithEvents btnRep2Mod As ToolStripMenuItem
    Friend WithEvents btnRep3 As ToolStripMenuItem
    Friend WithEvents btnRep3Imp As ToolStripMenuItem
    Friend WithEvents btnRep3Mod As ToolStripMenuItem
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFiltro As DateTimePicker
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCuotas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnRep4 As ToolStripMenuItem
    Friend WithEvents btnRep4Imp As ToolStripMenuItem
    Friend WithEvents btnRep4Mod As ToolStripMenuItem
    Friend WithEvents btnRep5 As ToolStripMenuItem
    Friend WithEvents btnRep5Mod As ToolStripMenuItem
    Friend WithEvents btnRep6 As ToolStripMenuItem
    Friend WithEvents btnRep6Mod As ToolStripMenuItem
    Friend WithEvents btnRep7 As ToolStripMenuItem
    Friend WithEvents btnRep7Mod As ToolStripMenuItem
End Class
