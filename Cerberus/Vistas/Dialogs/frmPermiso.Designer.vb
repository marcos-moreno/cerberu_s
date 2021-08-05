<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPermiso
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.group2 = New System.Windows.Forms.GroupBox()
        Me.bteModificarFormato = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.bteFormato = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialDivider1 = New MaterialSkin.Controls.MaterialDivider()
        Me.txtComentarioLider = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbLider = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.dtgrid = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pendientes = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.group2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
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
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(263, 17)
        Me.lblStatus.Text = "Solicitud de Permisos, Encargado de Incidencias."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 14, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnRecargar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabPage2.Controls.Add(Me.group2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.txtNOmbreEmpleado)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1016, 340)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        '
        'group2
        '
        Me.group2.Controls.Add(Me.bteModificarFormato)
        Me.group2.Controls.Add(Me.bteFormato)
        Me.group2.Controls.Add(Me.MaterialDivider1)
        Me.group2.Controls.Add(Me.txtComentarioLider)
        Me.group2.Controls.Add(Me.Label7)
        Me.group2.Controls.Add(Me.Label6)
        Me.group2.Controls.Add(Me.txtEstado)
        Me.group2.ForeColor = System.Drawing.Color.Black
        Me.group2.Location = New System.Drawing.Point(515, 20)
        Me.group2.Margin = New System.Windows.Forms.Padding(2)
        Me.group2.Name = "group2"
        Me.group2.Padding = New System.Windows.Forms.Padding(2)
        Me.group2.Size = New System.Drawing.Size(436, 298)
        Me.group2.TabIndex = 37
        Me.group2.TabStop = False
        Me.group2.Text = "Respuesta Líder"
        '
        'bteModificarFormato
        '
        Me.bteModificarFormato.Cursor = System.Windows.Forms.Cursors.Default
        Me.bteModificarFormato.Depth = 0
        Me.bteModificarFormato.Location = New System.Drawing.Point(94, 229)
        Me.bteModificarFormato.Margin = New System.Windows.Forms.Padding(2)
        Me.bteModificarFormato.MouseState = MaterialSkin.MouseState.HOVER
        Me.bteModificarFormato.Name = "bteModificarFormato"
        Me.bteModificarFormato.Primary = True
        Me.bteModificarFormato.Size = New System.Drawing.Size(252, 18)
        Me.bteModificarFormato.TabIndex = 41
        Me.bteModificarFormato.Text = "Modificar Formato"
        Me.bteModificarFormato.UseVisualStyleBackColor = True
        '
        'bteFormato
        '
        Me.bteFormato.Depth = 0
        Me.bteFormato.Location = New System.Drawing.Point(94, 261)
        Me.bteFormato.Margin = New System.Windows.Forms.Padding(2)
        Me.bteFormato.MouseState = MaterialSkin.MouseState.HOVER
        Me.bteFormato.Name = "bteFormato"
        Me.bteFormato.Primary = True
        Me.bteFormato.Size = New System.Drawing.Size(252, 18)
        Me.bteFormato.TabIndex = 40
        Me.bteFormato.Text = "Formato de Permiso"
        Me.bteFormato.UseVisualStyleBackColor = True
        Me.bteFormato.Visible = False
        '
        'MaterialDivider1
        '
        Me.MaterialDivider1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialDivider1.Depth = 0
        Me.MaterialDivider1.Location = New System.Drawing.Point(27, 207)
        Me.MaterialDivider1.Margin = New System.Windows.Forms.Padding(2)
        Me.MaterialDivider1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialDivider1.Name = "MaterialDivider1"
        Me.MaterialDivider1.Size = New System.Drawing.Size(398, 86)
        Me.MaterialDivider1.TabIndex = 39
        Me.MaterialDivider1.Text = "MaterialDivider1"
        '
        'txtComentarioLider
        '
        Me.txtComentarioLider.Enabled = False
        Me.txtComentarioLider.Location = New System.Drawing.Point(172, 54)
        Me.txtComentarioLider.Margin = New System.Windows.Forms.Padding(2)
        Me.txtComentarioLider.Multiline = True
        Me.txtComentarioLider.Name = "txtComentarioLider"
        Me.txtComentarioLider.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarioLider.Size = New System.Drawing.Size(253, 90)
        Me.txtComentarioLider.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Comentario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
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
        Me.GroupBox1.Controls.Add(Me.cbLider)
        Me.GroupBox1.Controls.Add(Me.Label8)
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
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(4, 58)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(454, 260)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de La Solicitud"
        '
        'cbLider
        '
        Me.cbLider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLider.FormattingEnabled = True
        Me.cbLider.Location = New System.Drawing.Point(171, 140)
        Me.cbLider.Name = "cbLider"
        Me.cbLider.Size = New System.Drawing.Size(253, 21)
        Me.cbLider.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Líder que Autoriza"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Motivo del Permiso:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(172, 173)
        Me.txtMotivo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivo.Size = New System.Drawing.Size(265, 68)
        Me.txtMotivo.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Horario del Permiso:"
        '
        'cbTipoIncidencia
        '
        Me.cbTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIncidencia.FormattingEnabled = True
        Me.cbTipoIncidencia.Location = New System.Drawing.Point(172, 76)
        Me.cbTipoIncidencia.Name = "cbTipoIncidencia"
        Me.cbTipoIncidencia.Size = New System.Drawing.Size(253, 21)
        Me.cbTipoIncidencia.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Incidencia:"
        '
        'txtIDSolicitudPermiso
        '
        Me.txtIDSolicitudPermiso.Enabled = False
        Me.txtIDSolicitudPermiso.Location = New System.Drawing.Point(172, 17)
        Me.txtIDSolicitudPermiso.Name = "txtIDSolicitudPermiso"
        Me.txtIDSolicitudPermiso.Size = New System.Drawing.Size(92, 20)
        Me.txtIDSolicitudPermiso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Permiso:"
        '
        'dtpFechaPermiso
        '
        Me.dtpFechaPermiso.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaPermiso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaPermiso.Location = New System.Drawing.Point(172, 46)
        Me.dtpFechaPermiso.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFechaPermiso.Name = "dtpFechaPermiso"
        Me.dtpFechaPermiso.Size = New System.Drawing.Size(253, 20)
        Me.dtpFechaPermiso.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Fecha Permiso:"
        '
        'horaFin
        '
        Me.horaFin.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.horaFin.CustomFormat = "hh:mm tt"
        Me.horaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.horaFin.Location = New System.Drawing.Point(295, 111)
        Me.horaFin.Name = "horaFin"
        Me.horaFin.Size = New System.Drawing.Size(130, 20)
        Me.horaFin.TabIndex = 32
        '
        'horaInicio
        '
        Me.horaInicio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.horaInicio.CustomFormat = "hh:mm tt"
        Me.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.horaInicio.Location = New System.Drawing.Point(171, 111)
        Me.horaInicio.Name = "horaInicio"
        Me.horaInicio.Size = New System.Drawing.Size(118, 20)
        Me.horaInicio.TabIndex = 31
        '
        'txtNOmbreEmpleado
        '
        Me.txtNOmbreEmpleado.Enabled = False
        Me.txtNOmbreEmpleado.Location = New System.Drawing.Point(73, 20)
        Me.txtNOmbreEmpleado.Name = "txtNOmbreEmpleado"
        Me.txtNOmbreEmpleado.Size = New System.Drawing.Size(368, 20)
        Me.txtNOmbreEmpleado.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Empleado:"
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
        Me.dtgrid.Size = New System.Drawing.Size(1006, 326)
        Me.dtgrid.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgrid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1016, 340)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 21)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1024, 366)
        Me.TabControl1.TabIndex = 15
        '
        'pendientes
        '
        Me.pendientes.AutoSize = True
        Me.pendientes.Location = New System.Drawing.Point(582, 7)
        Me.pendientes.Margin = New System.Windows.Forms.Padding(2)
        Me.pendientes.Name = "pendientes"
        Me.pendientes.Size = New System.Drawing.Size(103, 17)
        Me.pendientes.TabIndex = 33
        Me.pendientes.Text = "Solo Pendientes"
        Me.pendientes.UseVisualStyleBackColor = True
        '
        'frmPermiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 419)
        Me.Controls.Add(Me.pendientes)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(1044, 458)
        Me.MinimumSize = New System.Drawing.Size(1044, 458)
        Me.Name = "frmPermiso"
        Me.Text = "Solicitud de Permiso"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.group2.ResumeLayout(False)
        Me.group2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dtgrid As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabControl1 As TabControl
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
    Friend WithEvents pendientes As CheckBox
    Friend WithEvents bteFormato As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialDivider1 As MaterialSkin.Controls.MaterialDivider
    Friend WithEvents bteModificarFormato As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents cbLider As ComboBox
    Friend WithEvents Label8 As Label
End Class
