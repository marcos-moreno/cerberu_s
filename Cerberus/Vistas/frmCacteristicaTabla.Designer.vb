<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCacteristicaTabla
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
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtComentario = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnValor = New System.Windows.Forms.Button()
        Me.txtNombreValor = New System.Windows.Forms.TextBox()
        Me.txtIDValor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAtributo = New System.Windows.Forms.Button()
        Me.txtNombreAtributo = New System.Windows.Forms.TextBox()
        Me.txtIDAtributo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCaracteristica = New System.Windows.Forms.Button()
        Me.txtNombreCaracteristica = New System.Windows.Forms.TextBox()
        Me.txtIDCaracteristica = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(66, 24)
        Me.btnNuevo.Text = "Nuevo"
        '
        'bntGuardar
        '
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(76, 24)
        Me.bntGuardar.Text = "Guardar"
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
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1303, 28)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(107, 24)
        Me.btnComentarios.Text = "Comentarios"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(82, 24)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(182, 24)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(110, 24)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(118, 24)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 523)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1303, 26)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(153, 20)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtComentario)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.btnValor)
        Me.TabPage2.Controls.Add(Me.txtNombreValor)
        Me.TabPage2.Controls.Add(Me.txtIDValor)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.btnAtributo)
        Me.TabPage2.Controls.Add(Me.txtNombreAtributo)
        Me.TabPage2.Controls.Add(Me.txtIDAtributo)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.btnCaracteristica)
        Me.TabPage2.Controls.Add(Me.txtNombreCaracteristica)
        Me.TabPage2.Controls.Add(Me.txtIDCaracteristica)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1263, 444)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(131, 124)
        Me.txtComentario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(412, 117)
        Me.txtComentario.TabIndex = 13
        Me.txtComentario.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 128)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comentario:"
        '
        'btnValor
        '
        Me.btnValor.Location = New System.Drawing.Point(501, 90)
        Me.btnValor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnValor.Name = "btnValor"
        Me.btnValor.Size = New System.Drawing.Size(43, 28)
        Me.btnValor.TabIndex = 11
        Me.btnValor.Text = "..."
        Me.btnValor.UseVisualStyleBackColor = True
        '
        'txtNombreValor
        '
        Me.txtNombreValor.Location = New System.Drawing.Point(195, 92)
        Me.txtNombreValor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreValor.Name = "txtNombreValor"
        Me.txtNombreValor.ReadOnly = True
        Me.txtNombreValor.Size = New System.Drawing.Size(297, 22)
        Me.txtNombreValor.TabIndex = 10
        '
        'txtIDValor
        '
        Me.txtIDValor.Location = New System.Drawing.Point(131, 92)
        Me.txtIDValor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDValor.Name = "txtIDValor"
        Me.txtIDValor.ReadOnly = True
        Me.txtIDValor.Size = New System.Drawing.Size(55, 22)
        Me.txtIDValor.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Valor:"
        '
        'btnAtributo
        '
        Me.btnAtributo.Location = New System.Drawing.Point(501, 58)
        Me.btnAtributo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAtributo.Name = "btnAtributo"
        Me.btnAtributo.Size = New System.Drawing.Size(43, 28)
        Me.btnAtributo.TabIndex = 7
        Me.btnAtributo.Text = "..."
        Me.btnAtributo.UseVisualStyleBackColor = True
        '
        'txtNombreAtributo
        '
        Me.txtNombreAtributo.Location = New System.Drawing.Point(195, 60)
        Me.txtNombreAtributo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreAtributo.Name = "txtNombreAtributo"
        Me.txtNombreAtributo.ReadOnly = True
        Me.txtNombreAtributo.Size = New System.Drawing.Size(297, 22)
        Me.txtNombreAtributo.TabIndex = 6
        '
        'txtIDAtributo
        '
        Me.txtIDAtributo.Location = New System.Drawing.Point(131, 60)
        Me.txtIDAtributo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDAtributo.Name = "txtIDAtributo"
        Me.txtIDAtributo.ReadOnly = True
        Me.txtIDAtributo.Size = New System.Drawing.Size(55, 22)
        Me.txtIDAtributo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Atributo:"
        '
        'btnCaracteristica
        '
        Me.btnCaracteristica.Location = New System.Drawing.Point(501, 26)
        Me.btnCaracteristica.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCaracteristica.Name = "btnCaracteristica"
        Me.btnCaracteristica.Size = New System.Drawing.Size(43, 28)
        Me.btnCaracteristica.TabIndex = 3
        Me.btnCaracteristica.Text = "..."
        Me.btnCaracteristica.UseVisualStyleBackColor = True
        '
        'txtNombreCaracteristica
        '
        Me.txtNombreCaracteristica.Location = New System.Drawing.Point(195, 28)
        Me.txtNombreCaracteristica.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreCaracteristica.Name = "txtNombreCaracteristica"
        Me.txtNombreCaracteristica.ReadOnly = True
        Me.txtNombreCaracteristica.Size = New System.Drawing.Size(297, 22)
        Me.txtNombreCaracteristica.TabIndex = 2
        '
        'txtIDCaracteristica
        '
        Me.txtIDCaracteristica.Location = New System.Drawing.Point(131, 28)
        Me.txtIDCaracteristica.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIDCaracteristica.Name = "txtIDCaracteristica"
        Me.txtIDCaracteristica.ReadOnly = True
        Me.txtIDCaracteristica.Size = New System.Drawing.Size(55, 22)
        Me.txtIDCaracteristica.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Característica:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1263, 444)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1244, 426)
        Me.DataGridView1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 33)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1271, 473)
        Me.TabControl1.TabIndex = 6
        '
        'frmCacteristicaTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 549)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCacteristicaTabla"
        Me.Text = "Atributos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtIDCaracteristica As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents txtComentario As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnValor As Button
    Friend WithEvents txtNombreValor As TextBox
    Friend WithEvents txtIDValor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAtributo As Button
    Friend WithEvents txtNombreAtributo As TextBox
    Friend WithEvents txtIDAtributo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCaracteristica As Button
    Friend WithEvents txtNombreCaracteristica As TextBox
End Class
