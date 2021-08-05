<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisoLider
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtgrid = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.group2 = New System.Windows.Forms.GroupBox()
        Me.txtComentarioLider = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbTipoIncidencia = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIDSolicitudPermiso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaPermiso = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.horaFin = New System.Windows.Forms.DateTimePicker()
        Me.horaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtNOmbreEmpleado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechazarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.pendientes = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.group2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1024, 360)
        Me.TabControl1.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgrid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1016, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtgrid
        '
        Me.dtgrid.AllowUserToAddRows = False
        Me.dtgrid.AllowUserToDeleteRows = False
        Me.dtgrid.AllowUserToResizeRows = False
        Me.dtgrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrid.Location = New System.Drawing.Point(6, 6)
        Me.dtgrid.MultiSelect = False
        Me.dtgrid.Name = "dtgrid"
        Me.dtgrid.ReadOnly = True
        Me.dtgrid.RowHeadersWidth = 51
        Me.dtgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgrid.Size = New System.Drawing.Size(1006, 323)
        Me.dtgrid.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.group2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.txtNOmbreEmpleado)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1016, 334)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        '
        'group2
        '
        Me.group2.Controls.Add(Me.txtComentarioLider)
        Me.group2.Controls.Add(Me.Label7)
        Me.group2.Controls.Add(Me.Label6)
        Me.group2.Controls.Add(Me.txtEstado)
        Me.group2.ForeColor = System.Drawing.Color.White
        Me.group2.Location = New System.Drawing.Point(492, 11)
        Me.group2.Margin = New System.Windows.Forms.Padding(2)
        Me.group2.Name = "group2"
        Me.group2.Padding = New System.Windows.Forms.Padding(2)
        Me.group2.Size = New System.Drawing.Size(469, 287)
        Me.group2.TabIndex = 32
        Me.group2.TabStop = False
        Me.group2.Text = "Respuesta"
        '
        'txtComentarioLider
        '
        Me.txtComentarioLider.Location = New System.Drawing.Point(172, 54)
        Me.txtComentarioLider.Margin = New System.Windows.Forms.Padding(2)
        Me.txtComentarioLider.Multiline = True
        Me.txtComentarioLider.Name = "txtComentarioLider"
        Me.txtComentarioLider.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarioLider.Size = New System.Drawing.Size(253, 119)
        Me.txtComentarioLider.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(29, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Comentario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Estado:"
        '
        'txtEstado
        '
        Me.txtEstado.Enabled = False
        Me.txtEstado.Location = New System.Drawing.Point(172, 17)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(253, 20)
        Me.txtEstado.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMotivo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbTipoIncidencia)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtIDSolicitudPermiso)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPermiso)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.horaFin)
        Me.GroupBox1.Controls.Add(Me.horaInicio)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(13, 54)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(436, 244)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de La Solicitud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Motivo del Permiso:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Enabled = False
        Me.txtMotivo.Location = New System.Drawing.Point(172, 162)
        Me.txtMotivo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivo.Size = New System.Drawing.Size(253, 68)
        Me.txtMotivo.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Horario del Permiso:"
        '
        'cbTipoIncidencia
        '
        Me.cbTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIncidencia.Enabled = False
        Me.cbTipoIncidencia.FormattingEnabled = True
        Me.cbTipoIncidencia.Location = New System.Drawing.Point(172, 85)
        Me.cbTipoIncidencia.Name = "cbTipoIncidencia"
        Me.cbTipoIncidencia.Size = New System.Drawing.Size(253, 21)
        Me.cbTipoIncidencia.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Incidencia:"
        '
        'txtIDSolicitudPermiso
        '
        Me.txtIDSolicitudPermiso.Enabled = False
        Me.txtIDSolicitudPermiso.Location = New System.Drawing.Point(172, 18)
        Me.txtIDSolicitudPermiso.Name = "txtIDSolicitudPermiso"
        Me.txtIDSolicitudPermiso.Size = New System.Drawing.Size(92, 20)
        Me.txtIDSolicitudPermiso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Permiso:"
        '
        'dtpFechaPermiso
        '
        Me.dtpFechaPermiso.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaPermiso.Enabled = False
        Me.dtpFechaPermiso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaPermiso.Location = New System.Drawing.Point(172, 50)
        Me.dtpFechaPermiso.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFechaPermiso.Name = "dtpFechaPermiso"
        Me.dtpFechaPermiso.Size = New System.Drawing.Size(253, 20)
        Me.dtpFechaPermiso.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Fecha Permiso:"
        '
        'horaFin
        '
        Me.horaFin.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.horaFin.CustomFormat = "hh:mm tt"
        Me.horaFin.Enabled = False
        Me.horaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.horaFin.Location = New System.Drawing.Point(296, 128)
        Me.horaFin.Name = "horaFin"
        Me.horaFin.Size = New System.Drawing.Size(130, 20)
        Me.horaFin.TabIndex = 32
        '
        'horaInicio
        '
        Me.horaInicio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.horaInicio.CustomFormat = "hh:mm tt"
        Me.horaInicio.Enabled = False
        Me.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.horaInicio.Location = New System.Drawing.Point(172, 128)
        Me.horaInicio.Name = "horaInicio"
        Me.horaInicio.Size = New System.Drawing.Size(118, 20)
        Me.horaInicio.TabIndex = 31
        '
        'txtNOmbreEmpleado
        '
        Me.txtNOmbreEmpleado.Enabled = False
        Me.txtNOmbreEmpleado.Location = New System.Drawing.Point(82, 15)
        Me.txtNOmbreEmpleado.Name = "txtNOmbreEmpleado"
        Me.txtNOmbreEmpleado.Size = New System.Drawing.Size(368, 20)
        Me.txtNOmbreEmpleado.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(20, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Empleado:"
        '
        'bntGuardar
        '
        Me.bntGuardar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutorizarToolStripMenuItem, Me.RechazarToolStripMenuItem})
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(61, 20)
        Me.bntGuardar.Text = "Guardar"
        '
        'AutorizarToolStripMenuItem
        '
        Me.AutorizarToolStripMenuItem.Name = "AutorizarToolStripMenuItem"
        Me.AutorizarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AutorizarToolStripMenuItem.Text = "Autorizar"
        '
        'RechazarToolStripMenuItem
        '
        Me.RechazarToolStripMenuItem.Name = "RechazarToolStripMenuItem"
        Me.RechazarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RechazarToolStripMenuItem.Text = "Rechazar"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(229, 17)
        Me.lblStatus.Text = "Solicitu de Permisos, Líder Departamental."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 14, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bntGuardar, Me.btnRecargar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'pendientes
        '
        Me.pendientes.AutoSize = True
        Me.pendientes.Location = New System.Drawing.Point(581, 6)
        Me.pendientes.Margin = New System.Windows.Forms.Padding(2)
        Me.pendientes.Name = "pendientes"
        Me.pendientes.Size = New System.Drawing.Size(103, 17)
        Me.pendientes.TabIndex = 2
        Me.pendientes.Text = "Solo Pendientes"
        Me.pendientes.UseVisualStyleBackColor = True
        '
        'frmPermisoLider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 419)
        Me.Controls.Add(Me.pendientes)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(1044, 458)
        Me.MinimumSize = New System.Drawing.Size(1044, 458)
        Me.Name = "frmPermisoLider"
        Me.Text = "Permiso Líder"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.group2.ResumeLayout(False)
        Me.group2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtgrid As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents group2 As GroupBox
    Friend WithEvents txtComentarioLider As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTipoIncidencia As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtIDSolicitudPermiso As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaPermiso As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents horaFin As DateTimePicker
    Friend WithEvents horaInicio As DateTimePicker
    Friend WithEvents txtNOmbreEmpleado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AutorizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RechazarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pendientes As CheckBox
End Class
