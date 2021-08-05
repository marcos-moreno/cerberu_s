<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstadoCuenta
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
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEmpleadoDep = New System.Windows.Forms.Button()
        Me.txtNombreEmpleadoDep = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleadoDep = New System.Windows.Forms.TextBox()
        Me.lblEmpleadoDepartamento = New System.Windows.Forms.Label()
        Me.rbtnEdoCuenta = New System.Windows.Forms.RadioButton()
        Me.rbtnSolEfec = New System.Windows.Forms.RadioButton()
        Me.rbtnConcentradoEntrega = New System.Windows.Forms.RadioButton()
        Me.rbtnSobres = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnNinguno = New System.Windows.Forms.RadioButton()
        Me.rbtnEmpleado = New System.Windows.Forms.RadioButton()
        Me.rdbDepartamento = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtnPercepPeriodo = New System.Windows.Forms.RadioButton()
        Me.rbtnPagoExc = New System.Windows.Forms.RadioButton()
        Me.rbtnTotalGen = New System.Windows.Forms.RadioButton()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton3 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(291, 360)
        Me.cbPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(429, 24)
        Me.cbPeriodo.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 363)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Periodo:"
        '
        'dtpInicial
        '
        Me.dtpInicial.Enabled = False
        Me.dtpInicial.Location = New System.Drawing.Point(291, 424)
        Me.dtpInicial.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(265, 22)
        Me.dtpInicial.TabIndex = 29
        '
        'dtpFinal
        '
        Me.dtpFinal.Enabled = False
        Me.dtpFinal.Location = New System.Drawing.Point(730, 424)
        Me.dtpFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(265, 22)
        Me.dtpFinal.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(142, 429)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Fecha Inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(615, 424)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Fecha Final:"
        '
        'btnEmpleadoDep
        '
        Me.btnEmpleadoDep.Enabled = False
        Me.btnEmpleadoDep.Location = New System.Drawing.Point(730, 294)
        Me.btnEmpleadoDep.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmpleadoDep.Name = "btnEmpleadoDep"
        Me.btnEmpleadoDep.Size = New System.Drawing.Size(57, 28)
        Me.btnEmpleadoDep.TabIndex = 36
        Me.btnEmpleadoDep.Text = "..."
        Me.btnEmpleadoDep.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleadoDep
        '
        Me.txtNombreEmpleadoDep.Location = New System.Drawing.Point(367, 297)
        Me.txtNombreEmpleadoDep.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreEmpleadoDep.Name = "txtNombreEmpleadoDep"
        Me.txtNombreEmpleadoDep.ReadOnly = True
        Me.txtNombreEmpleadoDep.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreEmpleadoDep.TabIndex = 35
        '
        'txtIDEmpleadoDep
        '
        Me.txtIDEmpleadoDep.Location = New System.Drawing.Point(291, 297)
        Me.txtIDEmpleadoDep.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDEmpleadoDep.Name = "txtIDEmpleadoDep"
        Me.txtIDEmpleadoDep.ReadOnly = True
        Me.txtIDEmpleadoDep.Size = New System.Drawing.Size(67, 22)
        Me.txtIDEmpleadoDep.TabIndex = 34
        '
        'lblEmpleadoDepartamento
        '
        Me.lblEmpleadoDepartamento.AutoSize = True
        Me.lblEmpleadoDepartamento.Location = New System.Drawing.Point(142, 300)
        Me.lblEmpleadoDepartamento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmpleadoDepartamento.Name = "lblEmpleadoDepartamento"
        Me.lblEmpleadoDepartamento.Size = New System.Drawing.Size(111, 17)
        Me.lblEmpleadoDepartamento.TabIndex = 33
        Me.lblEmpleadoDepartamento.Text = "Empleado (PIN):"
        '
        'rbtnEdoCuenta
        '
        Me.rbtnEdoCuenta.AutoSize = True
        Me.rbtnEdoCuenta.Checked = True
        Me.rbtnEdoCuenta.Location = New System.Drawing.Point(32, 31)
        Me.rbtnEdoCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnEdoCuenta.Name = "rbtnEdoCuenta"
        Me.rbtnEdoCuenta.Size = New System.Drawing.Size(149, 21)
        Me.rbtnEdoCuenta.TabIndex = 43
        Me.rbtnEdoCuenta.TabStop = True
        Me.rbtnEdoCuenta.Text = "Estados de Cuenta"
        Me.rbtnEdoCuenta.UseVisualStyleBackColor = True
        '
        'rbtnSolEfec
        '
        Me.rbtnSolEfec.AutoSize = True
        Me.rbtnSolEfec.Location = New System.Drawing.Point(212, 31)
        Me.rbtnSolEfec.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnSolEfec.Name = "rbtnSolEfec"
        Me.rbtnSolEfec.Size = New System.Drawing.Size(136, 21)
        Me.rbtnSolEfec.TabIndex = 44
        Me.rbtnSolEfec.Text = "Solicitud Efectivo"
        Me.rbtnSolEfec.UseVisualStyleBackColor = True
        '
        'rbtnConcentradoEntrega
        '
        Me.rbtnConcentradoEntrega.AutoSize = True
        Me.rbtnConcentradoEntrega.Location = New System.Drawing.Point(517, 31)
        Me.rbtnConcentradoEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnConcentradoEntrega.Name = "rbtnConcentradoEntrega"
        Me.rbtnConcentradoEntrega.Size = New System.Drawing.Size(191, 21)
        Me.rbtnConcentradoEntrega.TabIndex = 45
        Me.rbtnConcentradoEntrega.Text = "Concentrados de Entrega"
        Me.rbtnConcentradoEntrega.UseVisualStyleBackColor = True
        '
        'rbtnSobres
        '
        Me.rbtnSobres.AutoSize = True
        Me.rbtnSobres.Location = New System.Drawing.Point(735, 31)
        Me.rbtnSobres.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnSobres.Name = "rbtnSobres"
        Me.rbtnSobres.Size = New System.Drawing.Size(74, 21)
        Me.rbtnSobres.TabIndex = 46
        Me.rbtnSobres.Text = "Sobres"
        Me.rbtnSobres.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnNinguno)
        Me.GroupBox1.Controls.Add(Me.rbtnEmpleado)
        Me.GroupBox1.Controls.Add(Me.rdbDepartamento)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 178)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1007, 78)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Filtro"
        '
        'rbtnNinguno
        '
        Me.rbtnNinguno.AutoSize = True
        Me.rbtnNinguno.Checked = True
        Me.rbtnNinguno.Location = New System.Drawing.Point(385, 38)
        Me.rbtnNinguno.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnNinguno.Name = "rbtnNinguno"
        Me.rbtnNinguno.Size = New System.Drawing.Size(82, 21)
        Me.rbtnNinguno.TabIndex = 2
        Me.rbtnNinguno.TabStop = True
        Me.rbtnNinguno.Text = "Ninguno"
        Me.rbtnNinguno.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.rbtnNinguno.UseVisualStyleBackColor = True
        '
        'rbtnEmpleado
        '
        Me.rbtnEmpleado.AutoSize = True
        Me.rbtnEmpleado.Location = New System.Drawing.Point(212, 38)
        Me.rbtnEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnEmpleado.Name = "rbtnEmpleado"
        Me.rbtnEmpleado.Size = New System.Drawing.Size(92, 21)
        Me.rbtnEmpleado.TabIndex = 1
        Me.rbtnEmpleado.Text = "Empleado"
        Me.rbtnEmpleado.UseVisualStyleBackColor = True
        '
        'rdbDepartamento
        '
        Me.rdbDepartamento.AutoSize = True
        Me.rdbDepartamento.Location = New System.Drawing.Point(32, 38)
        Me.rdbDepartamento.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbDepartamento.Name = "rdbDepartamento"
        Me.rdbDepartamento.Size = New System.Drawing.Size(119, 21)
        Me.rdbDepartamento.TabIndex = 0
        Me.rdbDepartamento.Text = "Departamento"
        Me.rdbDepartamento.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnPercepPeriodo)
        Me.GroupBox2.Controls.Add(Me.rbtnPagoExc)
        Me.GroupBox2.Controls.Add(Me.rbtnTotalGen)
        Me.GroupBox2.Controls.Add(Me.rbtnConcentradoEntrega)
        Me.GroupBox2.Controls.Add(Me.rbtnEdoCuenta)
        Me.GroupBox2.Controls.Add(Me.rbtnSobres)
        Me.GroupBox2.Controls.Add(Me.rbtnSolEfec)
        Me.GroupBox2.Location = New System.Drawing.Point(40, 27)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1007, 117)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Proceso Actual"
        '
        'rbtnPercepPeriodo
        '
        Me.rbtnPercepPeriodo.AutoSize = True
        Me.rbtnPercepPeriodo.Location = New System.Drawing.Point(32, 74)
        Me.rbtnPercepPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnPercepPeriodo.Name = "rbtnPercepPeriodo"
        Me.rbtnPercepPeriodo.Size = New System.Drawing.Size(199, 21)
        Me.rbtnPercepPeriodo.TabIndex = 49
        Me.rbtnPercepPeriodo.Text = "Perecepciones del Período"
        Me.rbtnPercepPeriodo.UseVisualStyleBackColor = True
        '
        'rbtnPagoExc
        '
        Me.rbtnPagoExc.AutoSize = True
        Me.rbtnPagoExc.Location = New System.Drawing.Point(835, 31)
        Me.rbtnPagoExc.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnPagoExc.Name = "rbtnPagoExc"
        Me.rbtnPagoExc.Size = New System.Drawing.Size(139, 21)
        Me.rbtnPagoExc.TabIndex = 48
        Me.rbtnPagoExc.Text = "Pago Excedentes"
        Me.rbtnPagoExc.UseVisualStyleBackColor = True
        '
        'rbtnTotalGen
        '
        Me.rbtnTotalGen.AutoSize = True
        Me.rbtnTotalGen.Location = New System.Drawing.Point(379, 31)
        Me.rbtnTotalGen.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnTotalGen.Name = "rbtnTotalGen"
        Me.rbtnTotalGen.Size = New System.Drawing.Size(116, 21)
        Me.rbtnTotalGen.TabIndex = 47
        Me.rbtnTotalGen.Text = "Total General"
        Me.rbtnTotalGen.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(597, 538)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(204, 49)
        Me.MaterialRaisedButton1.TabIndex = 49
        Me.MaterialRaisedButton1.Text = "Aceptar"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(841, 538)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = True
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(206, 46)
        Me.MaterialRaisedButton2.TabIndex = 50
        Me.MaterialRaisedButton2.Text = "Cerrar"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton3
        '
        Me.MaterialRaisedButton3.Depth = 0
        Me.MaterialRaisedButton3.Location = New System.Drawing.Point(59, 556)
        Me.MaterialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton3.Name = "MaterialRaisedButton3"
        Me.MaterialRaisedButton3.Primary = True
        Me.MaterialRaisedButton3.Size = New System.Drawing.Size(253, 28)
        Me.MaterialRaisedButton3.TabIndex = 51
        Me.MaterialRaisedButton3.Text = "Modificar Reporte"
        Me.MaterialRaisedButton3.UseVisualStyleBackColor = True
        '
        'frmEstadoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1086, 610)
        Me.ControlBox = False
        Me.Controls.Add(Me.MaterialRaisedButton3)
        Me.Controls.Add(Me.MaterialRaisedButton2)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEmpleadoDep)
        Me.Controls.Add(Me.txtNombreEmpleadoDep)
        Me.Controls.Add(Me.txtIDEmpleadoDep)
        Me.Controls.Add(Me.lblEmpleadoDepartamento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicial)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.Label4)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(1104, 657)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1104, 657)
        Me.Name = "frmEstadoCuenta"
        Me.Text = "..:: Estados de Cuenta ::.."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpInicial As DateTimePicker
    Friend WithEvents dtpFinal As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnEmpleadoDep As Button
    Friend WithEvents txtNombreEmpleadoDep As TextBox
    Friend WithEvents txtIDEmpleadoDep As TextBox
    Friend WithEvents lblEmpleadoDepartamento As Label
    Friend WithEvents rbtnEdoCuenta As RadioButton
    Friend WithEvents rbtnSolEfec As RadioButton
    Friend WithEvents rbtnConcentradoEntrega As RadioButton
    Friend WithEvents rbtnSobres As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbtnNinguno As RadioButton
    Friend WithEvents rbtnEmpleado As RadioButton
    Friend WithEvents rdbDepartamento As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtnTotalGen As RadioButton
    Friend WithEvents rbtnPagoExc As RadioButton
    Friend WithEvents rbtnPercepPeriodo As RadioButton
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton3 As MaterialSkin.Controls.MaterialRaisedButton
End Class
