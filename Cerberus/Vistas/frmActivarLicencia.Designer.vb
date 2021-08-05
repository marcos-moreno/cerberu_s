<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivarLicencia
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreUbicacion = New System.Windows.Forms.TextBox()
        Me.txtIDUbicacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.bteAutorizar = New System.Windows.Forms.Button()
        Me.lastAcces = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxEstado_au = New System.Windows.Forms.ComboBox()
        Me.canLogin = New System.Windows.Forms.CheckBox()
        Me.txtDescripcion = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreEstacion = New System.Windows.Forms.TextBox()
        Me.btnAtributo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.bteFiltrar = New System.Windows.Forms.Button()
        Me.filterEstado = New System.Windows.Forms.ComboBox()
        Me.TabGeneral = New System.Windows.Forms.TabControl()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(105, 191)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(283, 22)
        Me.TextBox1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 445)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1305, 26)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(153, 20)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(118, 24)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(110, 24)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(66, 24)
        Me.btnNuevo.Text = "Nuevo"
        '
        'txtLicencia
        '
        Me.txtLicencia.Location = New System.Drawing.Point(131, 126)
        Me.txtLicencia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLicencia.Multiline = True
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(413, 29)
        Me.txtLicencia.TabIndex = 14
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(129, 201)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(413, 79)
        Me.txtObservacion.TabIndex = 13
        Me.txtObservacion.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 204)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Observación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Licencia:"
        '
        'txtNombreUbicacion
        '
        Me.txtNombreUbicacion.Location = New System.Drawing.Point(195, 71)
        Me.txtNombreUbicacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreUbicacion.Name = "txtNombreUbicacion"
        Me.txtNombreUbicacion.ReadOnly = True
        Me.txtNombreUbicacion.Size = New System.Drawing.Size(297, 22)
        Me.txtNombreUbicacion.TabIndex = 6
        '
        'txtIDUbicacion
        '
        Me.txtIDUbicacion.Location = New System.Drawing.Point(131, 71)
        Me.txtIDUbicacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDUbicacion.Name = "txtIDUbicacion"
        Me.txtIDUbicacion.ReadOnly = True
        Me.txtIDUbicacion.Size = New System.Drawing.Size(55, 22)
        Me.txtIDUbicacion.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ubicación:"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(77, 24)
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(125, 24)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(76, 24)
        Me.bntGuardar.Text = "Guardar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Estación:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnRecargar, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1305, 28)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.bteAutorizar)
        Me.TabPage2.Controls.Add(Me.lastAcces)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbxEstado_au)
        Me.TabPage2.Controls.Add(Me.canLogin)
        Me.TabPage2.Controls.Add(Me.txtDescripcion)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtNombreEstacion)
        Me.TabPage2.Controls.Add(Me.txtLicencia)
        Me.TabPage2.Controls.Add(Me.txtObservacion)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.btnAtributo)
        Me.TabPage2.Controls.Add(Me.txtNombreUbicacion)
        Me.TabPage2.Controls.Add(Me.txtIDUbicacion)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1280, 378)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'bteAutorizar
        '
        Me.bteAutorizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bteAutorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bteAutorizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bteAutorizar.ForeColor = System.Drawing.Color.White
        Me.bteAutorizar.Location = New System.Drawing.Point(577, 277)
        Me.bteAutorizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bteAutorizar.Name = "bteAutorizar"
        Me.bteAutorizar.Size = New System.Drawing.Size(677, 28)
        Me.bteAutorizar.TabIndex = 23
        Me.bteAutorizar.Text = "Autorizar"
        Me.bteAutorizar.UseVisualStyleBackColor = False
        Me.bteAutorizar.Visible = False
        '
        'lastAcces
        '
        Me.lastAcces.AutoSize = True
        Me.lastAcces.Location = New System.Drawing.Point(573, 225)
        Me.lastAcces.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lastAcces.Name = "lastAcces"
        Me.lastAcces.Size = New System.Drawing.Size(97, 17)
        Me.lastAcces.TabIndex = 22
        Me.lastAcces.Text = "Último Acceso"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(568, 156)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Estado:"
        '
        'cbxEstado_au
        '
        Me.cbxEstado_au.FormattingEnabled = True
        Me.cbxEstado_au.Items.AddRange(New Object() {"Autorizado", "No Autorizado", "Pendiente Por Autorizar"})
        Me.cbxEstado_au.Location = New System.Drawing.Point(633, 150)
        Me.cbxEstado_au.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbxEstado_au.Name = "cbxEstado_au"
        Me.cbxEstado_au.Size = New System.Drawing.Size(268, 24)
        Me.cbxEstado_au.TabIndex = 20
        '
        'canLogin
        '
        Me.canLogin.AutoSize = True
        Me.canLogin.Location = New System.Drawing.Point(1004, 155)
        Me.canLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.canLogin.Name = "canLogin"
        Me.canLogin.Size = New System.Drawing.Size(135, 21)
        Me.canLogin.TabIndex = 19
        Me.canLogin.Text = "Puede Logearse"
        Me.canLogin.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(572, 38)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(681, 77)
        Me.txtDescripcion.TabIndex = 18
        Me.txtDescripcion.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(568, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Descripción:"
        '
        'txtNombreEstacion
        '
        Me.txtNombreEstacion.Location = New System.Drawing.Point(131, 15)
        Me.txtNombreEstacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombreEstacion.Multiline = True
        Me.txtNombreEstacion.Name = "txtNombreEstacion"
        Me.txtNombreEstacion.Size = New System.Drawing.Size(413, 22)
        Me.txtNombreEstacion.TabIndex = 15
        '
        'btnAtributo
        '
        Me.btnAtributo.Location = New System.Drawing.Point(501, 70)
        Me.btnAtributo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAtributo.Name = "btnAtributo"
        Me.btnAtributo.Size = New System.Drawing.Size(43, 28)
        Me.btnAtributo.TabIndex = 7
        Me.btnAtributo.Text = "..."
        Me.btnAtributo.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Location = New System.Drawing.Point(8, 49)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1264, 319)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtBuscar)
        Me.TabPage1.Controls.Add(Me.bteFiltrar)
        Me.TabPage1.Controls.Add(Me.filterEstado)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1280, 378)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(285, 9)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(293, 22)
        Me.txtBuscar.TabIndex = 23
        '
        'bteFiltrar
        '
        Me.bteFiltrar.Location = New System.Drawing.Point(588, 7)
        Me.bteFiltrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bteFiltrar.Name = "bteFiltrar"
        Me.bteFiltrar.Size = New System.Drawing.Size(100, 28)
        Me.bteFiltrar.TabIndex = 22
        Me.bteFiltrar.Text = "Buscar"
        Me.bteFiltrar.UseVisualStyleBackColor = True
        '
        'filterEstado
        '
        Me.filterEstado.FormattingEnabled = True
        Me.filterEstado.Items.AddRange(New Object() {"Todos", "Autorizado", "No Autorizado", "Pendiente Por Autorizar"})
        Me.filterEstado.Location = New System.Drawing.Point(8, 7)
        Me.filterEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.filterEstado.Name = "filterEstado"
        Me.filterEstado.Size = New System.Drawing.Size(268, 24)
        Me.filterEstado.TabIndex = 21
        '
        'TabGeneral
        '
        Me.TabGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabGeneral.Controls.Add(Me.TabPage1)
        Me.TabGeneral.Controls.Add(Me.TabPage2)
        Me.TabGeneral.Location = New System.Drawing.Point(16, 33)
        Me.TabGeneral.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.SelectedIndex = 0
        Me.TabGeneral.Size = New System.Drawing.Size(1288, 407)
        Me.TabGeneral.TabIndex = 12
        '
        'frmActivarLicencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 471)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabGeneral)
        Me.Controls.Add(Me.TextBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmActivarLicencia"
        Me.Text = "Estaciones Autorizadas"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents txtLicencia As TextBox
    Friend WithEvents txtObservacion As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombreUbicacion As TextBox
    Friend WithEvents txtIDUbicacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabGeneral As TabControl
    Friend WithEvents btnAtributo As Button
    Friend WithEvents txtNombreEstacion As TextBox
    Friend WithEvents txtDescripcion As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxEstado_au As ComboBox
    Friend WithEvents canLogin As CheckBox
    Friend WithEvents filterEstado As ComboBox
    Friend WithEvents bteFiltrar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents lastAcces As Label
    Friend WithEvents bteAutorizar As Button
End Class
