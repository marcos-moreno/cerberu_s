<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvento
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
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjecutarEventoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoloLosDeMiUbicaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraccionDeRegistrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FijarFechaHoraToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbAccion = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDispositivo = New System.Windows.Forms.ComboBox()
        Me.chbSoloLocales = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.DataGridView1.Location = New System.Drawing.Point(9, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(932, 311)
        Me.DataGridView1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.EjecutarEventoToolStripMenuItem, Me.SoloLosDeMiUbicaciónToolStripMenuItem, Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(953, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'EjecutarEventoToolStripMenuItem
        '
        Me.EjecutarEventoToolStripMenuItem.Name = "EjecutarEventoToolStripMenuItem"
        Me.EjecutarEventoToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.EjecutarEventoToolStripMenuItem.Text = "Ejecutar Evento"
        '
        'SoloLosDeMiUbicaciónToolStripMenuItem
        '
        Me.SoloLosDeMiUbicaciónToolStripMenuItem.Name = "SoloLosDeMiUbicaciónToolStripMenuItem"
        Me.SoloLosDeMiUbicaciónToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.SoloLosDeMiUbicaciónToolStripMenuItem.Text = "Actualizar"
        '
        'GenerarExtraccionDeTodosLosDispoToolStripMenuItem
        '
        Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExtraccionDeRegistrosToolStripMenuItem, Me.FijarFechaHoraToolStripMenuItem1})
        Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem.Name = "GenerarExtraccionDeTodosLosDispoToolStripMenuItem"
        Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem.Size = New System.Drawing.Size(138, 20)
        Me.GenerarExtraccionDeTodosLosDispoToolStripMenuItem.Text = "Extraccion Automatica"
        '
        'ExtraccionDeRegistrosToolStripMenuItem
        '
        Me.ExtraccionDeRegistrosToolStripMenuItem.Name = "ExtraccionDeRegistrosToolStripMenuItem"
        Me.ExtraccionDeRegistrosToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ExtraccionDeRegistrosToolStripMenuItem.Text = "Extraccion de Registros"
        '
        'FijarFechaHoraToolStripMenuItem1
        '
        Me.FijarFechaHoraToolStripMenuItem1.Name = "FijarFechaHoraToolStripMenuItem1"
        Me.FijarFechaHoraToolStripMenuItem1.Size = New System.Drawing.Size(195, 22)
        Me.FijarFechaHoraToolStripMenuItem1.Text = "Fijar Fecha Hora"
        '
        'pbAccion
        '
        Me.pbAccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAccion.Location = New System.Drawing.Point(0, 371)
        Me.pbAccion.MarqueeAnimationSpeed = 10
        Me.pbAccion.Maximum = 0
        Me.pbAccion.Name = "pbAccion"
        Me.pbAccion.Size = New System.Drawing.Size(953, 23)
        Me.pbAccion.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbAccion.TabIndex = 3
        '
        'BackgroundWorker1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Dispositivo"
        '
        'cbDispositivo
        '
        Me.cbDispositivo.FormattingEnabled = True
        Me.cbDispositivo.Location = New System.Drawing.Point(220, 27)
        Me.cbDispositivo.Name = "cbDispositivo"
        Me.cbDispositivo.Size = New System.Drawing.Size(271, 21)
        Me.cbDispositivo.TabIndex = 6
        '
        'chbSoloLocales
        '
        Me.chbSoloLocales.AutoSize = True
        Me.chbSoloLocales.Checked = True
        Me.chbSoloLocales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSoloLocales.Location = New System.Drawing.Point(9, 31)
        Me.chbSoloLocales.Name = "chbSoloLocales"
        Me.chbSoloLocales.Size = New System.Drawing.Size(105, 17)
        Me.chbSoloLocales.TabIndex = 7
        Me.chbSoloLocales.Text = "Eventos Locales"
        Me.chbSoloLocales.UseVisualStyleBackColor = True
        '
        'frmEvento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 394)
        Me.Controls.Add(Me.chbSoloLocales)
        Me.Controls.Add(Me.cbDispositivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbAccion)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmEvento"
        Me.Text = "..:: Eventos - Pendientes ::.."
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EjecutarEventoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoloLosDeMiUbicaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pbAccion As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDispositivo As ComboBox
    Friend WithEvents GenerarExtraccionDeTodosLosDispoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtraccionDeRegistrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FijarFechaHoraToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chbSoloLocales As CheckBox
End Class
