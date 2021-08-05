<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHorario
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.bntGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnComentarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdjuntos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.esActivo = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbEmpresa = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpC7 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC6 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC5 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC4 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC3 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC2 = New System.Windows.Forms.DateTimePicker()
        Me.DtpC1 = New System.Windows.Forms.DateTimePicker()
        Me.lblDia2 = New System.Windows.Forms.Label()
        Me.lblMinLaborar = New System.Windows.Forms.Label()
        Me.DtpI1 = New System.Windows.Forms.DateTimePicker()
        Me.DtpMin7 = New System.Windows.Forms.DateTimePicker()
        Me.lblDia1 = New System.Windows.Forms.Label()
        Me.DtpMin6 = New System.Windows.Forms.DateTimePicker()
        Me.DtpI2 = New System.Windows.Forms.DateTimePicker()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.DtpMin5 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpI3 = New System.Windows.Forms.DateTimePicker()
        Me.lblDia3 = New System.Windows.Forms.Label()
        Me.DtpMin4 = New System.Windows.Forms.DateTimePicker()
        Me.DtpF6 = New System.Windows.Forms.DateTimePicker()
        Me.DtpF5 = New System.Windows.Forms.DateTimePicker()
        Me.DtpMin3 = New System.Windows.Forms.DateTimePicker()
        Me.DtpF7 = New System.Windows.Forms.DateTimePicker()
        Me.DtpI4 = New System.Windows.Forms.DateTimePicker()
        Me.DtpF4 = New System.Windows.Forms.DateTimePicker()
        Me.DtpMin2 = New System.Windows.Forms.DateTimePicker()
        Me.Chb1 = New System.Windows.Forms.CheckBox()
        Me.lblDia4 = New System.Windows.Forms.Label()
        Me.DtpF3 = New System.Windows.Forms.DateTimePicker()
        Me.DtpMin1 = New System.Windows.Forms.DateTimePicker()
        Me.Chb2 = New System.Windows.Forms.CheckBox()
        Me.DtpI5 = New System.Windows.Forms.DateTimePicker()
        Me.DtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chb3 = New System.Windows.Forms.CheckBox()
        Me.lblDia5 = New System.Windows.Forms.Label()
        Me.DtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chb4 = New System.Windows.Forms.CheckBox()
        Me.DtpI6 = New System.Windows.Forms.DateTimePicker()
        Me.lblDia7 = New System.Windows.Forms.Label()
        Me.Chb7 = New System.Windows.Forms.CheckBox()
        Me.Chb5 = New System.Windows.Forms.CheckBox()
        Me.lblDia6 = New System.Windows.Forms.Label()
        Me.DtpI7 = New System.Windows.Forms.DateTimePicker()
        Me.Chb6 = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.bntGuardar, Me.btnEliminar, Me.btnComentarios, Me.btnAdjuntos, Me.btnReportes, Me.btnRecargar, Me.btnDetalle, Me.btnAnterior, Me.btnSiguiente})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1079, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
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
        'btnComentarios
        '
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(87, 20)
        Me.btnComentarios.Text = "Comentarios"
        '
        'btnAdjuntos
        '
        Me.btnAdjuntos.Name = "btnAdjuntos"
        Me.btnAdjuntos.Size = New System.Drawing.Size(67, 20)
        Me.btnAdjuntos.Text = "Adjuntos"
        '
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem1, Me.ModificarToolStripMenuItem})
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(65, 20)
        Me.btnReportes.Text = "Reportes"
        '
        'ImprimirToolStripMenuItem1
        '
        Me.ImprimirToolStripMenuItem1.Name = "ImprimirToolStripMenuItem1"
        Me.ImprimirToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.ImprimirToolStripMenuItem1.Text = "Imprimir"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'btnRecargar
        '
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(98, 20)
        Me.btnRecargar.Text = "Recargar Datos"
        '
        'btnDetalle
        '
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(144, 20)
        Me.btnDetalle.Text = "Detalle de Movimientos"
        '
        'btnAnterior
        '
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(88, 20)
        Me.btnAnterior.Text = "Reg. Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(94, 20)
        Me.btnSiguiente.Text = "Reg. Siguiente"
        '
        'esActivo
        '
        Me.esActivo.AutoSize = True
        Me.esActivo.Location = New System.Drawing.Point(328, 88)
        Me.esActivo.Name = "esActivo"
        Me.esActivo.Size = New System.Drawing.Size(56, 17)
        Me.esActivo.TabIndex = 42
        Me.esActivo.Text = "Activo"
        Me.esActivo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Sucursal:"
        '
        'cbSucursal
        '
        Me.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSucursal.Enabled = False
        Me.cbSucursal.FormattingEnabled = True
        Me.cbSucursal.Location = New System.Drawing.Point(128, 52)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Size = New System.Drawing.Size(323, 21)
        Me.cbSucursal.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Empresa:"
        '
        'cbEmpresa
        '
        Me.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmpresa.Enabled = False
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(128, 28)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(323, 21)
        Me.cbEmpresa.TabIndex = 10
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnCopiar)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.DtpC7)
        Me.TabPage2.Controls.Add(Me.DtpC6)
        Me.TabPage2.Controls.Add(Me.DtpC5)
        Me.TabPage2.Controls.Add(Me.DtpC4)
        Me.TabPage2.Controls.Add(Me.DtpC3)
        Me.TabPage2.Controls.Add(Me.DtpC2)
        Me.TabPage2.Controls.Add(Me.DtpC1)
        Me.TabPage2.Controls.Add(Me.lblDia2)
        Me.TabPage2.Controls.Add(Me.lblMinLaborar)
        Me.TabPage2.Controls.Add(Me.esActivo)
        Me.TabPage2.Controls.Add(Me.DtpI1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.DtpMin7)
        Me.TabPage2.Controls.Add(Me.cbSucursal)
        Me.TabPage2.Controls.Add(Me.lblDia1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.DtpMin6)
        Me.TabPage2.Controls.Add(Me.cbEmpresa)
        Me.TabPage2.Controls.Add(Me.DtpI2)
        Me.TabPage2.Controls.Add(Me.txtNombre)
        Me.TabPage2.Controls.Add(Me.DtpMin5)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.DtpI3)
        Me.TabPage2.Controls.Add(Me.lblDia3)
        Me.TabPage2.Controls.Add(Me.DtpMin4)
        Me.TabPage2.Controls.Add(Me.DtpF6)
        Me.TabPage2.Controls.Add(Me.DtpF5)
        Me.TabPage2.Controls.Add(Me.DtpMin3)
        Me.TabPage2.Controls.Add(Me.DtpF7)
        Me.TabPage2.Controls.Add(Me.DtpI4)
        Me.TabPage2.Controls.Add(Me.DtpF4)
        Me.TabPage2.Controls.Add(Me.DtpMin2)
        Me.TabPage2.Controls.Add(Me.Chb1)
        Me.TabPage2.Controls.Add(Me.lblDia4)
        Me.TabPage2.Controls.Add(Me.DtpF3)
        Me.TabPage2.Controls.Add(Me.DtpMin1)
        Me.TabPage2.Controls.Add(Me.Chb2)
        Me.TabPage2.Controls.Add(Me.DtpI5)
        Me.TabPage2.Controls.Add(Me.DtpF2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Chb3)
        Me.TabPage2.Controls.Add(Me.lblDia5)
        Me.TabPage2.Controls.Add(Me.DtpF1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Chb4)
        Me.TabPage2.Controls.Add(Me.DtpI6)
        Me.TabPage2.Controls.Add(Me.lblDia7)
        Me.TabPage2.Controls.Add(Me.Chb7)
        Me.TabPage2.Controls.Add(Me.Chb5)
        Me.TabPage2.Controls.Add(Me.lblDia6)
        Me.TabPage2.Controls.Add(Me.DtpI7)
        Me.TabPage2.Controls.Add(Me.Chb6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1047, 492)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Selección"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(710, 162)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(75, 23)
        Me.btnCopiar.TabIndex = 89
        Me.btnCopiar.Text = "Copiar"
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(451, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Tiempo Comida"
        '
        'DtpC7
        '
        Me.DtpC7.CustomFormat = "HH:mm:ss"
        Me.DtpC7.Enabled = False
        Me.DtpC7.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC7.Location = New System.Drawing.Point(454, 321)
        Me.DtpC7.Name = "DtpC7"
        Me.DtpC7.Size = New System.Drawing.Size(107, 20)
        Me.DtpC7.TabIndex = 87
        Me.DtpC7.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC6
        '
        Me.DtpC6.CustomFormat = "HH:mm:ss"
        Me.DtpC6.Enabled = False
        Me.DtpC6.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC6.Location = New System.Drawing.Point(454, 295)
        Me.DtpC6.Name = "DtpC6"
        Me.DtpC6.Size = New System.Drawing.Size(107, 20)
        Me.DtpC6.TabIndex = 86
        Me.DtpC6.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC5
        '
        Me.DtpC5.CustomFormat = "HH:mm:ss"
        Me.DtpC5.Enabled = False
        Me.DtpC5.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC5.Location = New System.Drawing.Point(454, 269)
        Me.DtpC5.Name = "DtpC5"
        Me.DtpC5.Size = New System.Drawing.Size(107, 20)
        Me.DtpC5.TabIndex = 85
        Me.DtpC5.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC4
        '
        Me.DtpC4.CustomFormat = "HH:mm:ss"
        Me.DtpC4.Enabled = False
        Me.DtpC4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC4.Location = New System.Drawing.Point(454, 243)
        Me.DtpC4.Name = "DtpC4"
        Me.DtpC4.Size = New System.Drawing.Size(107, 20)
        Me.DtpC4.TabIndex = 84
        Me.DtpC4.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC3
        '
        Me.DtpC3.CustomFormat = "HH:mm:ss"
        Me.DtpC3.Enabled = False
        Me.DtpC3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC3.Location = New System.Drawing.Point(454, 217)
        Me.DtpC3.Name = "DtpC3"
        Me.DtpC3.Size = New System.Drawing.Size(107, 20)
        Me.DtpC3.TabIndex = 83
        Me.DtpC3.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC2
        '
        Me.DtpC2.CustomFormat = "HH:mm:ss"
        Me.DtpC2.Enabled = False
        Me.DtpC2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC2.Location = New System.Drawing.Point(454, 191)
        Me.DtpC2.Name = "DtpC2"
        Me.DtpC2.Size = New System.Drawing.Size(107, 20)
        Me.DtpC2.TabIndex = 82
        Me.DtpC2.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'DtpC1
        '
        Me.DtpC1.CustomFormat = "HH:mm:ss"
        Me.DtpC1.Enabled = False
        Me.DtpC1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpC1.Location = New System.Drawing.Point(454, 165)
        Me.DtpC1.Name = "DtpC1"
        Me.DtpC1.Size = New System.Drawing.Size(107, 20)
        Me.DtpC1.TabIndex = 81
        Me.DtpC1.Value = New Date(2018, 1, 21, 13, 0, 0, 0)
        '
        'lblDia2
        '
        Me.lblDia2.AutoSize = True
        Me.lblDia2.Location = New System.Drawing.Point(21, 191)
        Me.lblDia2.Name = "lblDia2"
        Me.lblDia2.Size = New System.Drawing.Size(39, 13)
        Me.lblDia2.TabIndex = 46
        Me.lblDia2.Text = "Martes"
        '
        'lblMinLaborar
        '
        Me.lblMinLaborar.AutoSize = True
        Me.lblMinLaborar.Location = New System.Drawing.Point(579, 135)
        Me.lblMinLaborar.Name = "lblMinLaborar"
        Me.lblMinLaborar.Size = New System.Drawing.Size(72, 13)
        Me.lblMinLaborar.TabIndex = 80
        Me.lblMinLaborar.Text = "Min a Laborar"
        '
        'DtpI1
        '
        Me.DtpI1.CustomFormat = ""
        Me.DtpI1.Enabled = False
        Me.DtpI1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI1.Location = New System.Drawing.Point(196, 163)
        Me.DtpI1.Name = "DtpI1"
        Me.DtpI1.Size = New System.Drawing.Size(107, 20)
        Me.DtpI1.TabIndex = 43
        '
        'DtpMin7
        '
        Me.DtpMin7.CustomFormat = ""
        Me.DtpMin7.Enabled = False
        Me.DtpMin7.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin7.Location = New System.Drawing.Point(582, 321)
        Me.DtpMin7.Name = "DtpMin7"
        Me.DtpMin7.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin7.TabIndex = 79
        '
        'lblDia1
        '
        Me.lblDia1.AutoSize = True
        Me.lblDia1.Location = New System.Drawing.Point(21, 165)
        Me.lblDia1.Name = "lblDia1"
        Me.lblDia1.Size = New System.Drawing.Size(36, 13)
        Me.lblDia1.TabIndex = 44
        Me.lblDia1.Text = "Lunes"
        '
        'DtpMin6
        '
        Me.DtpMin6.CustomFormat = ""
        Me.DtpMin6.Enabled = False
        Me.DtpMin6.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin6.Location = New System.Drawing.Point(582, 295)
        Me.DtpMin6.Name = "DtpMin6"
        Me.DtpMin6.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin6.TabIndex = 78
        '
        'DtpI2
        '
        Me.DtpI2.CustomFormat = ""
        Me.DtpI2.Enabled = False
        Me.DtpI2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI2.Location = New System.Drawing.Point(196, 189)
        Me.DtpI2.Name = "DtpI2"
        Me.DtpI2.Size = New System.Drawing.Size(107, 20)
        Me.DtpI2.TabIndex = 45
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(128, 86)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(170, 20)
        Me.txtNombre.TabIndex = 1
        '
        'DtpMin5
        '
        Me.DtpMin5.CustomFormat = ""
        Me.DtpMin5.Enabled = False
        Me.DtpMin5.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin5.Location = New System.Drawing.Point(582, 269)
        Me.DtpMin5.Name = "DtpMin5"
        Me.DtpMin5.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin5.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'DtpI3
        '
        Me.DtpI3.CustomFormat = ""
        Me.DtpI3.Enabled = False
        Me.DtpI3.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI3.Location = New System.Drawing.Point(196, 215)
        Me.DtpI3.Name = "DtpI3"
        Me.DtpI3.Size = New System.Drawing.Size(107, 20)
        Me.DtpI3.TabIndex = 47
        '
        'lblDia3
        '
        Me.lblDia3.AutoSize = True
        Me.lblDia3.Location = New System.Drawing.Point(21, 217)
        Me.lblDia3.Name = "lblDia3"
        Me.lblDia3.Size = New System.Drawing.Size(52, 13)
        Me.lblDia3.TabIndex = 48
        Me.lblDia3.Text = "Miercoles"
        '
        'DtpMin4
        '
        Me.DtpMin4.CustomFormat = ""
        Me.DtpMin4.Enabled = False
        Me.DtpMin4.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin4.Location = New System.Drawing.Point(582, 243)
        Me.DtpMin4.Name = "DtpMin4"
        Me.DtpMin4.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin4.TabIndex = 76
        '
        'DtpF6
        '
        Me.DtpF6.CustomFormat = ""
        Me.DtpF6.Enabled = False
        Me.DtpF6.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF6.Location = New System.Drawing.Point(328, 295)
        Me.DtpF6.Name = "DtpF6"
        Me.DtpF6.Size = New System.Drawing.Size(107, 20)
        Me.DtpF6.TabIndex = 62
        '
        'DtpF5
        '
        Me.DtpF5.CustomFormat = ""
        Me.DtpF5.Enabled = False
        Me.DtpF5.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF5.Location = New System.Drawing.Point(328, 269)
        Me.DtpF5.Name = "DtpF5"
        Me.DtpF5.Size = New System.Drawing.Size(107, 20)
        Me.DtpF5.TabIndex = 61
        '
        'DtpMin3
        '
        Me.DtpMin3.CustomFormat = ""
        Me.DtpMin3.Enabled = False
        Me.DtpMin3.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin3.Location = New System.Drawing.Point(582, 217)
        Me.DtpMin3.Name = "DtpMin3"
        Me.DtpMin3.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin3.TabIndex = 75
        '
        'DtpF7
        '
        Me.DtpF7.CustomFormat = ""
        Me.DtpF7.Enabled = False
        Me.DtpF7.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF7.Location = New System.Drawing.Point(328, 321)
        Me.DtpF7.Name = "DtpF7"
        Me.DtpF7.Size = New System.Drawing.Size(107, 20)
        Me.DtpF7.TabIndex = 63
        '
        'DtpI4
        '
        Me.DtpI4.CustomFormat = ""
        Me.DtpI4.Enabled = False
        Me.DtpI4.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI4.Location = New System.Drawing.Point(196, 241)
        Me.DtpI4.Name = "DtpI4"
        Me.DtpI4.Size = New System.Drawing.Size(107, 20)
        Me.DtpI4.TabIndex = 49
        '
        'DtpF4
        '
        Me.DtpF4.CustomFormat = ""
        Me.DtpF4.Enabled = False
        Me.DtpF4.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF4.Location = New System.Drawing.Point(328, 243)
        Me.DtpF4.Name = "DtpF4"
        Me.DtpF4.Size = New System.Drawing.Size(107, 20)
        Me.DtpF4.TabIndex = 60
        '
        'DtpMin2
        '
        Me.DtpMin2.CustomFormat = ""
        Me.DtpMin2.Enabled = False
        Me.DtpMin2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin2.Location = New System.Drawing.Point(582, 191)
        Me.DtpMin2.Name = "DtpMin2"
        Me.DtpMin2.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin2.TabIndex = 74
        '
        'Chb1
        '
        Me.Chb1.AutoSize = True
        Me.Chb1.Enabled = False
        Me.Chb1.Location = New System.Drawing.Point(117, 164)
        Me.Chb1.Name = "Chb1"
        Me.Chb1.Size = New System.Drawing.Size(56, 17)
        Me.Chb1.TabIndex = 64
        Me.Chb1.Text = "Activo"
        Me.Chb1.UseVisualStyleBackColor = True
        '
        'lblDia4
        '
        Me.lblDia4.AutoSize = True
        Me.lblDia4.Location = New System.Drawing.Point(21, 243)
        Me.lblDia4.Name = "lblDia4"
        Me.lblDia4.Size = New System.Drawing.Size(41, 13)
        Me.lblDia4.TabIndex = 50
        Me.lblDia4.Text = "Jueves"
        '
        'DtpF3
        '
        Me.DtpF3.CustomFormat = ""
        Me.DtpF3.Enabled = False
        Me.DtpF3.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF3.Location = New System.Drawing.Point(328, 217)
        Me.DtpF3.Name = "DtpF3"
        Me.DtpF3.Size = New System.Drawing.Size(107, 20)
        Me.DtpF3.TabIndex = 59
        '
        'DtpMin1
        '
        Me.DtpMin1.CustomFormat = ""
        Me.DtpMin1.Enabled = False
        Me.DtpMin1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpMin1.Location = New System.Drawing.Point(582, 165)
        Me.DtpMin1.Name = "DtpMin1"
        Me.DtpMin1.Size = New System.Drawing.Size(107, 20)
        Me.DtpMin1.TabIndex = 73
        '
        'Chb2
        '
        Me.Chb2.AutoSize = True
        Me.Chb2.Enabled = False
        Me.Chb2.Location = New System.Drawing.Point(117, 190)
        Me.Chb2.Name = "Chb2"
        Me.Chb2.Size = New System.Drawing.Size(56, 17)
        Me.Chb2.TabIndex = 65
        Me.Chb2.Text = "Activo"
        Me.Chb2.UseVisualStyleBackColor = True
        '
        'DtpI5
        '
        Me.DtpI5.CustomFormat = ""
        Me.DtpI5.Enabled = False
        Me.DtpI5.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI5.Location = New System.Drawing.Point(196, 267)
        Me.DtpI5.Name = "DtpI5"
        Me.DtpI5.Size = New System.Drawing.Size(107, 20)
        Me.DtpI5.TabIndex = 51
        '
        'DtpF2
        '
        Me.DtpF2.CustomFormat = ""
        Me.DtpF2.Enabled = False
        Me.DtpF2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF2.Location = New System.Drawing.Point(328, 191)
        Me.DtpF2.Name = "DtpF2"
        Me.DtpF2.Size = New System.Drawing.Size(107, 20)
        Me.DtpF2.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(325, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Salida"
        '
        'Chb3
        '
        Me.Chb3.AutoSize = True
        Me.Chb3.Enabled = False
        Me.Chb3.Location = New System.Drawing.Point(117, 216)
        Me.Chb3.Name = "Chb3"
        Me.Chb3.Size = New System.Drawing.Size(56, 17)
        Me.Chb3.TabIndex = 66
        Me.Chb3.Text = "Activo"
        Me.Chb3.UseVisualStyleBackColor = True
        '
        'lblDia5
        '
        Me.lblDia5.AutoSize = True
        Me.lblDia5.Location = New System.Drawing.Point(21, 269)
        Me.lblDia5.Name = "lblDia5"
        Me.lblDia5.Size = New System.Drawing.Size(42, 13)
        Me.lblDia5.TabIndex = 52
        Me.lblDia5.Text = "Viernes"
        '
        'DtpF1
        '
        Me.DtpF1.CustomFormat = ""
        Me.DtpF1.Enabled = False
        Me.DtpF1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpF1.Location = New System.Drawing.Point(328, 165)
        Me.DtpF1.Name = "DtpF1"
        Me.DtpF1.Size = New System.Drawing.Size(107, 20)
        Me.DtpF1.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Entrada"
        '
        'Chb4
        '
        Me.Chb4.AutoSize = True
        Me.Chb4.Enabled = False
        Me.Chb4.Location = New System.Drawing.Point(117, 242)
        Me.Chb4.Name = "Chb4"
        Me.Chb4.Size = New System.Drawing.Size(56, 17)
        Me.Chb4.TabIndex = 67
        Me.Chb4.Text = "Activo"
        Me.Chb4.UseVisualStyleBackColor = True
        '
        'DtpI6
        '
        Me.DtpI6.CustomFormat = ""
        Me.DtpI6.Enabled = False
        Me.DtpI6.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI6.Location = New System.Drawing.Point(196, 293)
        Me.DtpI6.Name = "DtpI6"
        Me.DtpI6.Size = New System.Drawing.Size(107, 20)
        Me.DtpI6.TabIndex = 53
        '
        'lblDia7
        '
        Me.lblDia7.AutoSize = True
        Me.lblDia7.Location = New System.Drawing.Point(21, 321)
        Me.lblDia7.Name = "lblDia7"
        Me.lblDia7.Size = New System.Drawing.Size(49, 13)
        Me.lblDia7.TabIndex = 56
        Me.lblDia7.Text = "Domingo"
        '
        'Chb7
        '
        Me.Chb7.AutoSize = True
        Me.Chb7.Enabled = False
        Me.Chb7.Location = New System.Drawing.Point(117, 321)
        Me.Chb7.Name = "Chb7"
        Me.Chb7.Size = New System.Drawing.Size(56, 17)
        Me.Chb7.TabIndex = 70
        Me.Chb7.Text = "Activo"
        Me.Chb7.UseVisualStyleBackColor = True
        '
        'Chb5
        '
        Me.Chb5.AutoSize = True
        Me.Chb5.Enabled = False
        Me.Chb5.Location = New System.Drawing.Point(117, 268)
        Me.Chb5.Name = "Chb5"
        Me.Chb5.Size = New System.Drawing.Size(56, 17)
        Me.Chb5.TabIndex = 68
        Me.Chb5.Text = "Activo"
        Me.Chb5.UseVisualStyleBackColor = True
        '
        'lblDia6
        '
        Me.lblDia6.AutoSize = True
        Me.lblDia6.Location = New System.Drawing.Point(21, 295)
        Me.lblDia6.Name = "lblDia6"
        Me.lblDia6.Size = New System.Drawing.Size(44, 13)
        Me.lblDia6.TabIndex = 54
        Me.lblDia6.Text = "Sabado"
        '
        'DtpI7
        '
        Me.DtpI7.CustomFormat = ""
        Me.DtpI7.Enabled = False
        Me.DtpI7.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpI7.Location = New System.Drawing.Point(196, 319)
        Me.DtpI7.Name = "DtpI7"
        Me.DtpI7.Size = New System.Drawing.Size(107, 20)
        Me.DtpI7.TabIndex = 55
        '
        'Chb6
        '
        Me.Chb6.AutoSize = True
        Me.Chb6.Enabled = False
        Me.Chb6.Location = New System.Drawing.Point(117, 294)
        Me.Chb6.Name = "Chb6"
        Me.Chb6.Size = New System.Drawing.Size(56, 17)
        Me.Chb6.TabIndex = 69
        Me.Chb6.Text = "Activo"
        Me.Chb6.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 480)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1047, 492)
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1055, 518)
        Me.TabControl1.TabIndex = 6
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 561)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1079, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmHorario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 583)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmHorario"
        Me.Text = "..:: Horarios ::.."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents bntGuardar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnComentarios As ToolStripMenuItem
    Friend WithEvents btnAdjuntos As ToolStripMenuItem
    Friend WithEvents btnReportes As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnRecargar As ToolStripMenuItem
    Friend WithEvents btnDetalle As ToolStripMenuItem
    Friend WithEvents btnAnterior As ToolStripMenuItem
    Friend WithEvents btnSiguiente As ToolStripMenuItem
    Friend WithEvents esActivo As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbSucursal As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbEmpresa As ComboBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chb7 As CheckBox
    Friend WithEvents Chb6 As CheckBox
    Friend WithEvents Chb5 As CheckBox
    Friend WithEvents Chb4 As CheckBox
    Friend WithEvents Chb3 As CheckBox
    Friend WithEvents Chb2 As CheckBox
    Friend WithEvents Chb1 As CheckBox
    Friend WithEvents DtpF7 As DateTimePicker
    Friend WithEvents DtpF6 As DateTimePicker
    Friend WithEvents DtpF5 As DateTimePicker
    Friend WithEvents DtpF4 As DateTimePicker
    Friend WithEvents DtpF3 As DateTimePicker
    Friend WithEvents DtpF2 As DateTimePicker
    Friend WithEvents DtpF1 As DateTimePicker
    Friend WithEvents lblDia7 As Label
    Friend WithEvents DtpI7 As DateTimePicker
    Friend WithEvents lblDia6 As Label
    Friend WithEvents DtpI6 As DateTimePicker
    Friend WithEvents lblDia5 As Label
    Friend WithEvents DtpI5 As DateTimePicker
    Friend WithEvents lblDia4 As Label
    Friend WithEvents DtpI4 As DateTimePicker
    Friend WithEvents lblDia3 As Label
    Friend WithEvents DtpI3 As DateTimePicker
    Friend WithEvents lblDia2 As Label
    Friend WithEvents DtpI2 As DateTimePicker
    Friend WithEvents lblDia1 As Label
    Friend WithEvents DtpI1 As DateTimePicker
    Friend WithEvents lblMinLaborar As Label
    Friend WithEvents DtpMin7 As DateTimePicker
    Friend WithEvents DtpMin6 As DateTimePicker
    Friend WithEvents DtpMin5 As DateTimePicker
    Friend WithEvents DtpMin4 As DateTimePicker
    Friend WithEvents DtpMin3 As DateTimePicker
    Friend WithEvents DtpMin2 As DateTimePicker
    Friend WithEvents DtpMin1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpC7 As DateTimePicker
    Friend WithEvents DtpC6 As DateTimePicker
    Friend WithEvents DtpC5 As DateTimePicker
    Friend WithEvents DtpC4 As DateTimePicker
    Friend WithEvents DtpC3 As DateTimePicker
    Friend WithEvents DtpC2 As DateTimePicker
    Friend WithEvents DtpC1 As DateTimePicker
    Friend WithEvents btnCopiar As Button
End Class
