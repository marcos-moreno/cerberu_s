<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoIncidencia
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvTipoIncidencia = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chbIncidenciaXDia = New System.Windows.Forms.CheckBox()
        Me.chbCalculada = New System.Windows.Forms.CheckBox()
        Me.txtTolerancia = New System.Windows.Forms.TextBox()
        Me.lblTolerancia = New System.Windows.Forms.Label()
        Me.chbDefault = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNombreInciCTPQ = New System.Windows.Forms.TextBox()
        Me.txtIDIincCTPQ = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chbEsActiva = New System.Windows.Forms.CheckBox()
        Me.txtNombreIncidencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.chbPrimaVac = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvTipoIncidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(586, 379)
        Me.TabControl1.TabIndex = 40
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvTipoIncidencia)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(578, 353)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvTipoIncidencia
        '
        Me.dgvTipoIncidencia.AllowUserToAddRows = False
        Me.dgvTipoIncidencia.AllowUserToDeleteRows = False
        Me.dgvTipoIncidencia.AllowUserToResizeColumns = False
        Me.dgvTipoIncidencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTipoIncidencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTipoIncidencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoIncidencia.Location = New System.Drawing.Point(6, 6)
        Me.dgvTipoIncidencia.MultiSelect = False
        Me.dgvTipoIncidencia.Name = "dgvTipoIncidencia"
        Me.dgvTipoIncidencia.ReadOnly = True
        Me.dgvTipoIncidencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoIncidencia.Size = New System.Drawing.Size(566, 341)
        Me.dgvTipoIncidencia.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chbPrimaVac)
        Me.TabPage2.Controls.Add(Me.chbIncidenciaXDia)
        Me.TabPage2.Controls.Add(Me.chbCalculada)
        Me.TabPage2.Controls.Add(Me.txtTolerancia)
        Me.TabPage2.Controls.Add(Me.lblTolerancia)
        Me.TabPage2.Controls.Add(Me.chbDefault)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.txtNombreInciCTPQ)
        Me.TabPage2.Controls.Add(Me.txtIDIincCTPQ)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.chbEsActiva)
        Me.TabPage2.Controls.Add(Me.txtNombreIncidencia)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtCodigo)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(578, 353)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chbIncidenciaXDia
        '
        Me.chbIncidenciaXDia.AutoSize = True
        Me.chbIncidenciaXDia.Enabled = False
        Me.chbIncidenciaXDia.Location = New System.Drawing.Point(410, 91)
        Me.chbIncidenciaXDia.Name = "chbIncidenciaXDia"
        Me.chbIncidenciaXDia.Size = New System.Drawing.Size(81, 17)
        Me.chbIncidenciaXDia.TabIndex = 24
        Me.chbIncidenciaXDia.Text = "Todo el día"
        Me.chbIncidenciaXDia.UseVisualStyleBackColor = True
        '
        'chbCalculada
        '
        Me.chbCalculada.AutoSize = True
        Me.chbCalculada.Enabled = False
        Me.chbCalculada.Location = New System.Drawing.Point(410, 68)
        Me.chbCalculada.Name = "chbCalculada"
        Me.chbCalculada.Size = New System.Drawing.Size(73, 17)
        Me.chbCalculada.TabIndex = 23
        Me.chbCalculada.Text = "Calculada"
        Me.chbCalculada.UseVisualStyleBackColor = True
        '
        'txtTolerancia
        '
        Me.txtTolerancia.Location = New System.Drawing.Point(96, 75)
        Me.txtTolerancia.Name = "txtTolerancia"
        Me.txtTolerancia.Size = New System.Drawing.Size(59, 20)
        Me.txtTolerancia.TabIndex = 22
        Me.txtTolerancia.Visible = False
        '
        'lblTolerancia
        '
        Me.lblTolerancia.AutoSize = True
        Me.lblTolerancia.Location = New System.Drawing.Point(16, 78)
        Me.lblTolerancia.Name = "lblTolerancia"
        Me.lblTolerancia.Size = New System.Drawing.Size(60, 13)
        Me.lblTolerancia.TabIndex = 21
        Me.lblTolerancia.Text = "Tolerancia:"
        Me.lblTolerancia.Visible = False
        '
        'chbDefault
        '
        Me.chbDefault.AutoSize = True
        Me.chbDefault.Enabled = False
        Me.chbDefault.Location = New System.Drawing.Point(410, 45)
        Me.chbDefault.Name = "chbDefault"
        Me.chbDefault.Size = New System.Drawing.Size(82, 17)
        Me.chbDefault.TabIndex = 20
        Me.chbDefault.Text = "Del Sistema"
        Me.chbDefault.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(336, 179)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNombreInciCTPQ
        '
        Me.txtNombreInciCTPQ.Location = New System.Drawing.Point(179, 181)
        Me.txtNombreInciCTPQ.Name = "txtNombreInciCTPQ"
        Me.txtNombreInciCTPQ.ReadOnly = True
        Me.txtNombreInciCTPQ.Size = New System.Drawing.Size(151, 20)
        Me.txtNombreInciCTPQ.TabIndex = 18
        '
        'txtIDIincCTPQ
        '
        Me.txtIDIincCTPQ.Location = New System.Drawing.Point(122, 181)
        Me.txtIDIincCTPQ.Name = "txtIDIincCTPQ"
        Me.txtIDIincCTPQ.ReadOnly = True
        Me.txtIDIincCTPQ.Size = New System.Drawing.Size(51, 20)
        Me.txtIDIincCTPQ.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Incidencia CTPQ:"
        '
        'chbEsActiva
        '
        Me.chbEsActiva.AutoSize = True
        Me.chbEsActiva.Location = New System.Drawing.Point(410, 22)
        Me.chbEsActiva.Name = "chbEsActiva"
        Me.chbEsActiva.Size = New System.Drawing.Size(59, 17)
        Me.chbEsActiva.TabIndex = 4
        Me.chbEsActiva.Text = "Activa."
        Me.chbEsActiva.UseVisualStyleBackColor = True
        '
        'txtNombreIncidencia
        '
        Me.txtNombreIncidencia.Location = New System.Drawing.Point(96, 49)
        Me.txtNombreIncidencia.Name = "txtNombreIncidencia"
        Me.txtNombreIncidencia.Size = New System.Drawing.Size(234, 20)
        Me.txtNombreIncidencia.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(96, 23)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(234, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnGuardar, Me.BtnEliminar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(610, 24)
        Me.MenuStrip1.TabIndex = 39
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.BtnNuevo.Text = "Nuevo"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.BtnGuardar.Text = "Guardar"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.BtnEliminar.Text = "Eliminar"
        '
        'chbPrimaVac
        '
        Me.chbPrimaVac.AutoSize = True
        Me.chbPrimaVac.Enabled = False
        Me.chbPrimaVac.Location = New System.Drawing.Point(410, 114)
        Me.chbPrimaVac.Name = "chbPrimaVac"
        Me.chbPrimaVac.Size = New System.Drawing.Size(139, 17)
        Me.chbPrimaVac.TabIndex = 25
        Me.chbPrimaVac.Text = "Pagar Prima Vacacional"
        Me.chbPrimaVac.UseVisualStyleBackColor = True
        '
        'frmTipoIncidencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 428)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmTipoIncidencia"
        Me.Text = "Tipos de Incidencias"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvTipoIncidencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvTipoIncidencia As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BtnNuevo As ToolStripMenuItem
    Friend WithEvents BtnGuardar As ToolStripMenuItem
    Friend WithEvents BtnEliminar As ToolStripMenuItem
    Friend WithEvents chbEsActiva As CheckBox
    Friend WithEvents txtNombreIncidencia As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtNombreInciCTPQ As TextBox
    Friend WithEvents txtIDIincCTPQ As TextBox
    Friend WithEvents chbCalculada As CheckBox
    Friend WithEvents txtTolerancia As TextBox
    Friend WithEvents lblTolerancia As Label
    Friend WithEvents chbDefault As CheckBox
    Friend WithEvents chbIncidenciaXDia As CheckBox
    Friend WithEvents chbPrimaVac As CheckBox
End Class
