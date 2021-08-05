<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnidad
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
        Me.TabUnidad = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvUnidad = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtNombreConcepto = New System.Windows.Forms.TextBox()
        Me.TxtIdConceptoCuenta = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIdEmpleado = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNumTarjetaGasolina = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPorcentajeDescuento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumTagAsignado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RdNo = New System.Windows.Forms.RadioButton()
        Me.RdSi = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtNombreSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSuc = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabUnidad.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabUnidad
        '
        Me.TabUnidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabUnidad.Controls.Add(Me.TabPage1)
        Me.TabUnidad.Controls.Add(Me.TabPage2)
        Me.TabUnidad.Location = New System.Drawing.Point(12, 30)
        Me.TabUnidad.Name = "TabUnidad"
        Me.TabUnidad.SelectedIndex = 0
        Me.TabUnidad.Size = New System.Drawing.Size(725, 421)
        Me.TabUnidad.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvUnidad)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(717, 395)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Coleccion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvUnidad
        '
        Me.dgvUnidad.AllowUserToAddRows = False
        Me.dgvUnidad.AllowUserToDeleteRows = False
        Me.dgvUnidad.AllowUserToResizeColumns = False
        Me.dgvUnidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUnidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvUnidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnidad.Location = New System.Drawing.Point(10, 12)
        Me.dgvUnidad.MultiSelect = False
        Me.dgvUnidad.Name = "dgvUnidad"
        Me.dgvUnidad.ReadOnly = True
        Me.dgvUnidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUnidad.Size = New System.Drawing.Size(692, 370)
        Me.dgvUnidad.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(717, 395)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Seleccion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNombreSucursal)
        Me.GroupBox2.Controls.Add(Me.txtIDSuc)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TxtNombreConcepto)
        Me.GroupBox2.Controls.Add(Me.TxtIdConceptoCuenta)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtComentario)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtNombreEmpleado)
        Me.GroupBox2.Controls.Add(Me.txtIdEmpleado)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(318, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 361)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Empleado asignado"
        '
        'TxtNombreConcepto
        '
        Me.TxtNombreConcepto.Enabled = False
        Me.TxtNombreConcepto.Location = New System.Drawing.Point(54, 94)
        Me.TxtNombreConcepto.Name = "TxtNombreConcepto"
        Me.TxtNombreConcepto.Size = New System.Drawing.Size(258, 20)
        Me.TxtNombreConcepto.TabIndex = 23
        '
        'TxtIdConceptoCuenta
        '
        Me.TxtIdConceptoCuenta.Enabled = False
        Me.TxtIdConceptoCuenta.Location = New System.Drawing.Point(6, 94)
        Me.TxtIdConceptoCuenta.Name = "TxtIdConceptoCuenta"
        Me.TxtIdConceptoCuenta.Size = New System.Drawing.Size(42, 20)
        Me.TxtIdConceptoCuenta.TabIndex = 22
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(318, 92)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Concepto de cuenta de unidad"
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(9, 204)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(351, 151)
        Me.txtComentario.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Comentario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Asignada a"
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Enabled = False
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(54, 44)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(258, 20)
        Me.txtNombreEmpleado.TabIndex = 16
        '
        'txtIdEmpleado
        '
        Me.txtIdEmpleado.Enabled = False
        Me.txtIdEmpleado.Location = New System.Drawing.Point(6, 44)
        Me.txtIdEmpleado.Name = "txtIdEmpleado"
        Me.txtIdEmpleado.Size = New System.Drawing.Size(42, 20)
        Me.txtIdEmpleado.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(318, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumTarjetaGasolina)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtModelo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPorcentajeDescuento)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNumTagAsignado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.RdNo)
        Me.GroupBox1.Controls.Add(Me.RdSi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMarca)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPlaca)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 370)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de unidad"
        '
        'txtNumTarjetaGasolina
        '
        Me.txtNumTarjetaGasolina.Location = New System.Drawing.Point(6, 289)
        Me.txtNumTarjetaGasolina.Name = "txtNumTarjetaGasolina"
        Me.txtNumTarjetaGasolina.Size = New System.Drawing.Size(273, 20)
        Me.txtNumTarjetaGasolina.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Número de tarjeta Gasolina"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(6, 129)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(273, 20)
        Me.txtModelo.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Modelo"
        '
        'txtPorcentajeDescuento
        '
        Me.txtPorcentajeDescuento.Location = New System.Drawing.Point(6, 344)
        Me.txtPorcentajeDescuento.Name = "txtPorcentajeDescuento"
        Me.txtPorcentajeDescuento.Size = New System.Drawing.Size(273, 20)
        Me.txtPorcentajeDescuento.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "% Descuento"
        '
        'txtNumTagAsignado
        '
        Me.txtNumTagAsignado.Location = New System.Drawing.Point(6, 229)
        Me.txtNumTagAsignado.Name = "txtNumTagAsignado"
        Me.txtNumTagAsignado.Size = New System.Drawing.Size(273, 20)
        Me.txtNumTagAsignado.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Número de Tag Asignado"
        '
        'RdNo
        '
        Me.RdNo.AutoSize = True
        Me.RdNo.Location = New System.Drawing.Point(180, 186)
        Me.RdNo.Name = "RdNo"
        Me.RdNo.Size = New System.Drawing.Size(39, 17)
        Me.RdNo.TabIndex = 7
        Me.RdNo.TabStop = True
        Me.RdNo.Text = "No"
        Me.RdNo.UseVisualStyleBackColor = True
        '
        'RdSi
        '
        Me.RdSi.AutoSize = True
        Me.RdSi.Location = New System.Drawing.Point(84, 186)
        Me.RdSi.Name = "RdSi"
        Me.RdSi.Size = New System.Drawing.Size(36, 17)
        Me.RdSi.TabIndex = 6
        Me.RdSi.TabStop = True
        Me.RdSi.Text = "Sí"
        Me.RdSi.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Genera cobro"
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(6, 83)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(273, 20)
        Me.txtMarca.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Marca"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Placa"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(6, 43)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(273, 20)
        Me.txtPlaca.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.btnGuardar, Me.btnEliminar, Me.RecargarGridToolStripMenuItem, Me.btnAdjuntos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(749, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(54, 20)
        Me.BtnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(61, 20)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 20)
        Me.btnEliminar.Text = "Eliminar"
        '
        'RecargarGridToolStripMenuItem
        '
        Me.RecargarGridToolStripMenuItem.Name = "RecargarGridToolStripMenuItem"
        Me.RecargarGridToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.RecargarGridToolStripMenuItem.Text = "Recargar Grid"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'txtNombreSucursal
        '
        Me.txtNombreSucursal.Enabled = False
        Me.txtNombreSucursal.Location = New System.Drawing.Point(54, 145)
        Me.txtNombreSucursal.Name = "txtNombreSucursal"
        Me.txtNombreSucursal.Size = New System.Drawing.Size(258, 20)
        Me.txtNombreSucursal.TabIndex = 27
        '
        'txtIDSuc
        '
        Me.txtIDSuc.Enabled = False
        Me.txtIDSuc.Location = New System.Drawing.Point(6, 145)
        Me.txtIDSuc.Name = "txtIDSuc"
        Me.txtIDSuc.Size = New System.Drawing.Size(42, 20)
        Me.txtIDSuc.TabIndex = 26
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(318, 143)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Sucursal"
        '
        'FrmUnidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 463)
        Me.Controls.Add(Me.TabUnidad)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmUnidad"
        Me.Text = "..::Unidad::.."
        Me.TabUnidad.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabUnidad As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BtnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents dgvUnidad As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPlaca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RdNo As RadioButton
    Friend WithEvents RdSi As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtComentario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents txtIdEmpleado As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtNumTagAsignado As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPorcentajeDescuento As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNumTarjetaGasolina As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtNombreConcepto As TextBox
    Friend WithEvents TxtIdConceptoCuenta As TextBox
    Friend WithEvents RecargarGridToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtNombreSucursal As TextBox
    Friend WithEvents txtIDSuc As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label11 As Label
End Class
