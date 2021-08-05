<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIMSS
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.dtpFiltro = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.txtDiasSinInc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
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
        Me.btnImportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbRegPatronal = New System.Windows.Forms.ComboBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgv.Location = New System.Drawing.Point(12, 101)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(972, 247)
        Me.dgv.TabIndex = 33
        '
        'dtpFiltro
        '
        Me.dtpFiltro.CustomFormat = "MM-yyyy"
        Me.dtpFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFiltro.Location = New System.Drawing.Point(134, 65)
        Me.dtpFiltro.Name = "dtpFiltro"
        Me.dtpFiltro.Size = New System.Drawing.Size(129, 20)
        Me.dtpFiltro.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Periodo / Ejercicio: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Filtro:"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(316, 68)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(171, 20)
        Me.txtFiltro.TabIndex = 37
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(493, 68)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 23)
        Me.btnBuscar.TabIndex = 38
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Enabled = False
        Me.btnRecalcular.Location = New System.Drawing.Point(887, 51)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(97, 23)
        Me.btnRecalcular.TabIndex = 40
        Me.btnRecalcular.Text = "Actualizar"
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'txtDiasSinInc
        '
        Me.txtDiasSinInc.Location = New System.Drawing.Point(792, 53)
        Me.txtDiasSinInc.Name = "txtDiasSinInc"
        Me.txtDiasSinInc.Size = New System.Drawing.Size(89, 20)
        Me.txtDiasSinInc.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(755, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Dias:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReportes, Me.btnImportar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(996, 24)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep1, Me.btnRep2, Me.btnRep3, Me.btnRep4})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(65, 20)
        Me.btnReportes.Text = "Reportes"
        '
        'btnRep1
        '
        Me.btnRep1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRep1Imp, Me.btnRep1Mod})
        Me.btnRep1.Name = "btnRep1"
        Me.btnRep1.Size = New System.Drawing.Size(152, 22)
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
        Me.btnRep2.Size = New System.Drawing.Size(152, 22)
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
        Me.btnRep3.Size = New System.Drawing.Size(152, 22)
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
        Me.btnRep4.Size = New System.Drawing.Size(152, 22)
        Me.btnRep4.Text = "Reporte 4"
        '
        'btnRep4Imp
        '
        Me.btnRep4Imp.Name = "btnRep4Imp"
        Me.btnRep4Imp.Size = New System.Drawing.Size(152, 22)
        Me.btnRep4Imp.Text = "Imprimir"
        '
        'btnRep4Mod
        '
        Me.btnRep4Mod.Name = "btnRep4Mod"
        Me.btnRep4Mod.Size = New System.Drawing.Size(152, 22)
        Me.btnRep4Mod.Text = "Modificar"
        '
        'btnImportar
        '
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(65, 20)
        Me.btnImportar.Text = "Importar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Registro Patronal:"
        '
        'cbRegPatronal
        '
        Me.cbRegPatronal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegPatronal.FormattingEnabled = True
        Me.cbRegPatronal.Location = New System.Drawing.Point(134, 38)
        Me.cbRegPatronal.Name = "cbRegPatronal"
        Me.cbRegPatronal.Size = New System.Drawing.Size(353, 21)
        Me.cbRegPatronal.TabIndex = 88
        '
        'frmIMSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 360)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbRegPatronal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.txtDiasSinInc)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFiltro)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmIMSS"
        Me.Text = "frmIMSS"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents dtpFiltro As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents txtDiasSinInc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents btnRep1 As ToolStripMenuItem
    Friend WithEvents btnRep2 As ToolStripMenuItem
    Friend WithEvents btnRep3 As ToolStripMenuItem
    Friend WithEvents btnRep1Imp As ToolStripMenuItem
    Friend WithEvents btnRep1Mod As ToolStripMenuItem
    Friend WithEvents btnRep2Imp As ToolStripMenuItem
    Friend WithEvents btnRep2Mod As ToolStripMenuItem
    Friend WithEvents btnRep3Imp As ToolStripMenuItem
    Friend WithEvents btnRep3Mod As ToolStripMenuItem
    Friend WithEvents btnImportar As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents cbRegPatronal As ComboBox
    Friend WithEvents btnRep4 As ToolStripMenuItem
    Friend WithEvents btnRep4Imp As ToolStripMenuItem
    Friend WithEvents btnRep4Mod As ToolStripMenuItem
End Class
