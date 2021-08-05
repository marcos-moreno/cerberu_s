<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitaSucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitaSucursal))
        Me.dtpLlegadaSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpSalidaSalida = New System.Windows.Forms.DateTimePicker()
        Me.txtTotalSalida = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalida = New System.Windows.Forms.Button()
        Me.txtIDSucOrigen = New System.Windows.Forms.TextBox()
        Me.txtNombreSucOrigen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSucOrigen = New System.Windows.Forms.Button()
        Me.BtnSucDestino = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreSucDestino = New System.Windows.Forms.TextBox()
        Me.txtIdSucDestino = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHorasExtraAut = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbtnYes = New System.Windows.Forms.RadioButton()
        Me.rbtnNot = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvVisitas = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.BtnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDescrip = New System.Windows.Forms.RichTextBox()
        Me.btnFormaPagoT = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNombreFormaPago = New System.Windows.Forms.TextBox()
        Me.txtIDFormaPago = New System.Windows.Forms.TextBox()
        Me.gbRegreso = New System.Windows.Forms.GroupBox()
        Me.txtTotalCuentaR = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCuentaRegreso = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalRegreso = New System.Windows.Forms.TextBox()
        Me.btnRegreso = New System.Windows.Forms.Button()
        Me.dtpLlegadaRegreso = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpSalidaRegreso = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbSalida = New System.Windows.Forms.GroupBox()
        Me.txtTotalCuenta = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCuentaSalida = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.anio_filter = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvVisitas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.gbRegreso.SuspendLayout()
        Me.gbSalida.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpLlegadaSalida
        '
        resources.ApplyResources(Me.dtpLlegadaSalida, "dtpLlegadaSalida")
        Me.dtpLlegadaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLlegadaSalida.Name = "dtpLlegadaSalida"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'dtpSalidaSalida
        '
        resources.ApplyResources(Me.dtpSalidaSalida, "dtpSalidaSalida")
        Me.dtpSalidaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalidaSalida.Name = "dtpSalidaSalida"
        '
        'txtTotalSalida
        '
        resources.ApplyResources(Me.txtTotalSalida, "txtTotalSalida")
        Me.txtTotalSalida.Name = "txtTotalSalida"
        Me.txtTotalSalida.ReadOnly = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'btnSalida
        '
        resources.ApplyResources(Me.btnSalida, "btnSalida")
        Me.btnSalida.Name = "btnSalida"
        Me.btnSalida.UseVisualStyleBackColor = True
        '
        'txtIDSucOrigen
        '
        resources.ApplyResources(Me.txtIDSucOrigen, "txtIDSucOrigen")
        Me.txtIDSucOrigen.Name = "txtIDSucOrigen"
        Me.txtIDSucOrigen.ReadOnly = True
        '
        'txtNombreSucOrigen
        '
        resources.ApplyResources(Me.txtNombreSucOrigen, "txtNombreSucOrigen")
        Me.txtNombreSucOrigen.Name = "txtNombreSucOrigen"
        Me.txtNombreSucOrigen.ReadOnly = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'BtnSucOrigen
        '
        resources.ApplyResources(Me.BtnSucOrigen, "BtnSucOrigen")
        Me.BtnSucOrigen.Name = "BtnSucOrigen"
        Me.BtnSucOrigen.UseVisualStyleBackColor = True
        '
        'BtnSucDestino
        '
        resources.ApplyResources(Me.BtnSucDestino, "BtnSucDestino")
        Me.BtnSucDestino.Name = "BtnSucDestino"
        Me.BtnSucDestino.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtNombreSucDestino
        '
        resources.ApplyResources(Me.txtNombreSucDestino, "txtNombreSucDestino")
        Me.txtNombreSucDestino.Name = "txtNombreSucDestino"
        Me.txtNombreSucDestino.ReadOnly = True
        '
        'txtIdSucDestino
        '
        resources.ApplyResources(Me.txtIdSucDestino, "txtIdSucDestino")
        Me.txtIdSucDestino.Name = "txtIdSucDestino"
        Me.txtIdSucDestino.ReadOnly = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtHorasExtraAut
        '
        resources.ApplyResources(Me.txtHorasExtraAut, "txtHorasExtraAut")
        Me.txtHorasExtraAut.Name = "txtHorasExtraAut"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'rbtnYes
        '
        resources.ApplyResources(Me.rbtnYes, "rbtnYes")
        Me.rbtnYes.Checked = True
        Me.rbtnYes.Name = "rbtnYes"
        Me.rbtnYes.TabStop = True
        Me.rbtnYes.UseVisualStyleBackColor = True
        '
        'rbtnNot
        '
        resources.ApplyResources(Me.rbtnNot, "rbtnNot")
        Me.rbtnNot.Name = "rbtnNot"
        Me.rbtnNot.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvVisitas)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvVisitas
        '
        Me.dgvVisitas.AllowUserToAddRows = False
        Me.dgvVisitas.AllowUserToDeleteRows = False
        Me.dgvVisitas.AllowUserToResizeRows = False
        resources.ApplyResources(Me.dgvVisitas, "dgvVisitas")
        Me.dgvVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitas.MultiSelect = False
        Me.dgvVisitas.Name = "dgvVisitas"
        Me.dgvVisitas.ReadOnly = True
        Me.dgvVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtEstado)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtIDEmpleado)
        Me.TabPage2.Controls.Add(Me.BtnEmpleado)
        Me.TabPage2.Controls.Add(Me.txtNombreEmpleado)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtDescrip)
        Me.TabPage2.Controls.Add(Me.btnFormaPagoT)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtNombreFormaPago)
        Me.TabPage2.Controls.Add(Me.txtIDFormaPago)
        Me.TabPage2.Controls.Add(Me.gbRegreso)
        Me.TabPage2.Controls.Add(Me.gbSalida)
        Me.TabPage2.Controls.Add(Me.txtHorasExtraAut)
        Me.TabPage2.Controls.Add(Me.rbtnNot)
        Me.TabPage2.Controls.Add(Me.rbtnYes)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.BtnSucDestino)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtNombreSucDestino)
        Me.TabPage2.Controls.Add(Me.txtIdSucDestino)
        Me.TabPage2.Controls.Add(Me.txtIDSucOrigen)
        Me.TabPage2.Controls.Add(Me.BtnSucOrigen)
        Me.TabPage2.Controls.Add(Me.txtNombreSucOrigen)
        Me.TabPage2.Controls.Add(Me.Label4)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtEstado
        '
        resources.ApplyResources(Me.txtEstado, "txtEstado")
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'txtIDEmpleado
        '
        resources.ApplyResources(Me.txtIDEmpleado, "txtIDEmpleado")
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        '
        'BtnEmpleado
        '
        resources.ApplyResources(Me.BtnEmpleado, "BtnEmpleado")
        Me.BtnEmpleado.Name = "BtnEmpleado"
        Me.BtnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        resources.ApplyResources(Me.txtNombreEmpleado, "txtNombreEmpleado")
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'txtDescrip
        '
        resources.ApplyResources(Me.txtDescrip, "txtDescrip")
        Me.txtDescrip.Name = "txtDescrip"
        '
        'btnFormaPagoT
        '
        resources.ApplyResources(Me.btnFormaPagoT, "btnFormaPagoT")
        Me.btnFormaPagoT.Name = "btnFormaPagoT"
        Me.btnFormaPagoT.UseVisualStyleBackColor = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'txtNombreFormaPago
        '
        resources.ApplyResources(Me.txtNombreFormaPago, "txtNombreFormaPago")
        Me.txtNombreFormaPago.Name = "txtNombreFormaPago"
        Me.txtNombreFormaPago.ReadOnly = True
        '
        'txtIDFormaPago
        '
        resources.ApplyResources(Me.txtIDFormaPago, "txtIDFormaPago")
        Me.txtIDFormaPago.Name = "txtIDFormaPago"
        Me.txtIDFormaPago.ReadOnly = True
        '
        'gbRegreso
        '
        Me.gbRegreso.Controls.Add(Me.txtTotalCuentaR)
        Me.gbRegreso.Controls.Add(Me.Label18)
        Me.gbRegreso.Controls.Add(Me.txtCuentaRegreso)
        Me.gbRegreso.Controls.Add(Me.Label14)
        Me.gbRegreso.Controls.Add(Me.txtTotalRegreso)
        Me.gbRegreso.Controls.Add(Me.btnRegreso)
        Me.gbRegreso.Controls.Add(Me.dtpLlegadaRegreso)
        Me.gbRegreso.Controls.Add(Me.Label8)
        Me.gbRegreso.Controls.Add(Me.dtpSalidaRegreso)
        Me.gbRegreso.Controls.Add(Me.Label9)
        Me.gbRegreso.Controls.Add(Me.Label10)
        resources.ApplyResources(Me.gbRegreso, "gbRegreso")
        Me.gbRegreso.Name = "gbRegreso"
        Me.gbRegreso.TabStop = False
        '
        'txtTotalCuentaR
        '
        resources.ApplyResources(Me.txtTotalCuentaR, "txtTotalCuentaR")
        Me.txtTotalCuentaR.Name = "txtTotalCuentaR"
        Me.txtTotalCuentaR.ReadOnly = True
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'txtCuentaRegreso
        '
        resources.ApplyResources(Me.txtCuentaRegreso, "txtCuentaRegreso")
        Me.txtCuentaRegreso.Name = "txtCuentaRegreso"
        Me.txtCuentaRegreso.ReadOnly = True
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'txtTotalRegreso
        '
        resources.ApplyResources(Me.txtTotalRegreso, "txtTotalRegreso")
        Me.txtTotalRegreso.Name = "txtTotalRegreso"
        Me.txtTotalRegreso.ReadOnly = True
        '
        'btnRegreso
        '
        resources.ApplyResources(Me.btnRegreso, "btnRegreso")
        Me.btnRegreso.Name = "btnRegreso"
        Me.btnRegreso.UseVisualStyleBackColor = True
        '
        'dtpLlegadaRegreso
        '
        resources.ApplyResources(Me.dtpLlegadaRegreso, "dtpLlegadaRegreso")
        Me.dtpLlegadaRegreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLlegadaRegreso.Name = "dtpLlegadaRegreso"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'dtpSalidaRegreso
        '
        resources.ApplyResources(Me.dtpSalidaRegreso, "dtpSalidaRegreso")
        Me.dtpSalidaRegreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalidaRegreso.Name = "dtpSalidaRegreso"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'gbSalida
        '
        Me.gbSalida.Controls.Add(Me.txtTotalCuenta)
        Me.gbSalida.Controls.Add(Me.Label17)
        Me.gbSalida.Controls.Add(Me.txtCuentaSalida)
        Me.gbSalida.Controls.Add(Me.Label13)
        Me.gbSalida.Controls.Add(Me.txtTotalSalida)
        Me.gbSalida.Controls.Add(Me.btnSalida)
        Me.gbSalida.Controls.Add(Me.dtpLlegadaSalida)
        Me.gbSalida.Controls.Add(Me.Label3)
        Me.gbSalida.Controls.Add(Me.dtpSalidaSalida)
        Me.gbSalida.Controls.Add(Me.Label1)
        Me.gbSalida.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.gbSalida, "gbSalida")
        Me.gbSalida.Name = "gbSalida"
        Me.gbSalida.TabStop = False
        '
        'txtTotalCuenta
        '
        resources.ApplyResources(Me.txtTotalCuenta, "txtTotalCuenta")
        Me.txtTotalCuenta.Name = "txtTotalCuenta"
        Me.txtTotalCuenta.ReadOnly = True
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'txtCuentaSalida
        '
        resources.ApplyResources(Me.txtCuentaSalida, "txtCuentaSalida")
        Me.txtCuentaSalida.Name = "txtCuentaSalida"
        Me.txtCuentaSalida.ReadOnly = True
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardar, Me.btnEliminar, Me.btnAdjuntos})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Name = "btnNuevo"
        resources.ApplyResources(Me.btnNuevo, "btnNuevo")
        '
        'btnGuardar
        '
        Me.btnGuardar.Name = "btnGuardar"
        resources.ApplyResources(Me.btnGuardar, "btnGuardar")
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        resources.ApplyResources(Me.btnEliminar, "btnEliminar")
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        resources.ApplyResources(Me.btnAdjuntos, "btnAdjuntos")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        '
        'anio_filter
        '
        Me.anio_filter.FormattingEnabled = True
        Me.anio_filter.Items.AddRange(New Object() {resources.GetString("anio_filter.Items"), resources.GetString("anio_filter.Items1"), resources.GetString("anio_filter.Items2"), resources.GetString("anio_filter.Items3"), resources.GetString("anio_filter.Items4"), resources.GetString("anio_filter.Items5"), resources.GetString("anio_filter.Items6")})
        resources.ApplyResources(Me.anio_filter, "anio_filter")
        Me.anio_filter.Name = "anio_filter"
        '
        'frmVisitaSucursal
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.anio_filter)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmVisitaSucursal"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvVisitas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.gbRegreso.ResumeLayout(False)
        Me.gbRegreso.PerformLayout()
        Me.gbSalida.ResumeLayout(False)
        Me.gbSalida.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpLlegadaSalida As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpSalidaSalida As DateTimePicker
    Friend WithEvents txtTotalSalida As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalida As Button
    Friend WithEvents txtIDSucOrigen As TextBox
    Friend WithEvents txtNombreSucOrigen As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnSucOrigen As Button
    Friend WithEvents BtnSucDestino As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNombreSucDestino As TextBox
    Friend WithEvents txtIdSucDestino As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtHorasExtraAut As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents rbtnYes As RadioButton
    Friend WithEvents rbtnNot As RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvVisitas As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDescrip As RichTextBox
    Friend WithEvents btnFormaPagoT As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNombreFormaPago As TextBox
    Friend WithEvents txtIDFormaPago As TextBox
    Friend WithEvents gbRegreso As GroupBox
    Friend WithEvents txtCuentaRegreso As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotalRegreso As TextBox
    Friend WithEvents btnRegreso As Button
    Friend WithEvents dtpLlegadaRegreso As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpSalidaRegreso As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents gbSalida As GroupBox
    Friend WithEvents txtCuentaSalida As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents BtnEmpleado As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTotalCuentaR As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTotalCuenta As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents anio_filter As ComboBox
End Class
