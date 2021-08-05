<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarCONTPAQ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarCONTPAQ))
        Me.chbEmpleados = New System.Windows.Forms.CheckBox()
        Me.chbImporDiasVac = New System.Windows.Forms.CheckBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chbTodos = New System.Windows.Forms.CheckBox()
        Me.chbPeriodos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDsSincro = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarAbono = New System.Windows.Forms.Button()
        Me.txtDescripConceptoAbono = New System.Windows.Forms.TextBox()
        Me.txtIDAbono = New System.Windows.Forms.TextBox()
        Me.btnBuscarCargo = New System.Windows.Forms.Button()
        Me.txtDescripConceptoCargo = New System.Windows.Forms.TextBox()
        Me.txtIDCargo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbVarFormula = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombrePers = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTiposPeriodos = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbTiposPeriodo = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbEmpleados
        '
        Me.chbEmpleados.AutoSize = True
        Me.chbEmpleados.Checked = True
        Me.chbEmpleados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEmpleados.Location = New System.Drawing.Point(18, 29)
        Me.chbEmpleados.Name = "chbEmpleados"
        Me.chbEmpleados.Size = New System.Drawing.Size(239, 17)
        Me.chbEmpleados.TabIndex = 0
        Me.chbEmpleados.Text = "Importar Empleados/Departamentos/Puestos"
        Me.chbEmpleados.UseVisualStyleBackColor = True
        '
        'chbImporDiasVac
        '
        Me.chbImporDiasVac.AutoSize = True
        Me.chbImporDiasVac.Checked = True
        Me.chbImporDiasVac.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbImporDiasVac.Location = New System.Drawing.Point(18, 52)
        Me.chbImporDiasVac.Name = "chbImporDiasVac"
        Me.chbImporDiasVac.Size = New System.Drawing.Size(204, 17)
        Me.chbImporDiasVac.TabIndex = 3
        Me.chbImporDiasVac.Text = "Importar Dias Vacaciones Disponibles"
        Me.chbImporDiasVac.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(454, 54)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(105, 23)
        Me.btnImportar.TabIndex = 4
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(257, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'chbTodos
        '
        Me.chbTodos.AutoSize = True
        Me.chbTodos.Checked = True
        Me.chbTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodos.Location = New System.Drawing.Point(274, 29)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(56, 17)
        Me.chbTodos.TabIndex = 7
        Me.chbTodos.Text = "Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'chbPeriodos
        '
        Me.chbPeriodos.AutoSize = True
        Me.chbPeriodos.Location = New System.Drawing.Point(11, 31)
        Me.chbPeriodos.Name = "chbPeriodos"
        Me.chbPeriodos.Size = New System.Drawing.Size(108, 17)
        Me.chbPeriodos.TabIndex = 8
        Me.chbPeriodos.Text = "Importar Periodos"
        Me.chbPeriodos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbTiposPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbTiposPeriodos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIDsSincro)
        Me.GroupBox1.Controls.Add(Me.chbTodos)
        Me.GroupBox1.Controls.Add(Me.chbEmpleados)
        Me.GroupBox1.Controls.Add(Me.chbImporDiasVac)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(537, 164)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empleados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Código(s) CONTPAQi Nóminas a Sincronizar"
        '
        'txtIDsSincro
        '
        Me.txtIDsSincro.Location = New System.Drawing.Point(274, 73)
        Me.txtIDsSincro.Name = "txtIDsSincro"
        Me.txtIDsSincro.Size = New System.Drawing.Size(254, 44)
        Me.txtIDsSincro.TabIndex = 8
        Me.txtIDsSincro.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscarAbono)
        Me.GroupBox2.Controls.Add(Me.txtDescripConceptoAbono)
        Me.GroupBox2.Controls.Add(Me.txtIDAbono)
        Me.GroupBox2.Controls.Add(Me.btnBuscarCargo)
        Me.GroupBox2.Controls.Add(Me.txtDescripConceptoCargo)
        Me.GroupBox2.Controls.Add(Me.txtIDCargo)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cbVarFormula)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtNombrePers)
        Me.GroupBox2.Controls.Add(Me.chbPeriodos)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(537, 187)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodos"
        '
        'btnBuscarAbono
        '
        Me.btnBuscarAbono.Location = New System.Drawing.Point(459, 116)
        Me.btnBuscarAbono.Name = "btnBuscarAbono"
        Me.btnBuscarAbono.Size = New System.Drawing.Size(43, 23)
        Me.btnBuscarAbono.TabIndex = 75
        Me.btnBuscarAbono.Text = "..."
        Me.btnBuscarAbono.UseVisualStyleBackColor = True
        '
        'txtDescripConceptoAbono
        '
        Me.txtDescripConceptoAbono.Location = New System.Drawing.Point(187, 118)
        Me.txtDescripConceptoAbono.Name = "txtDescripConceptoAbono"
        Me.txtDescripConceptoAbono.ReadOnly = True
        Me.txtDescripConceptoAbono.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripConceptoAbono.TabIndex = 74
        '
        'txtIDAbono
        '
        Me.txtIDAbono.Location = New System.Drawing.Point(130, 118)
        Me.txtIDAbono.Name = "txtIDAbono"
        Me.txtIDAbono.ReadOnly = True
        Me.txtIDAbono.Size = New System.Drawing.Size(51, 20)
        Me.txtIDAbono.TabIndex = 73
        '
        'btnBuscarCargo
        '
        Me.btnBuscarCargo.Location = New System.Drawing.Point(459, 90)
        Me.btnBuscarCargo.Name = "btnBuscarCargo"
        Me.btnBuscarCargo.Size = New System.Drawing.Size(43, 23)
        Me.btnBuscarCargo.TabIndex = 72
        Me.btnBuscarCargo.Text = "..."
        Me.btnBuscarCargo.UseVisualStyleBackColor = True
        '
        'txtDescripConceptoCargo
        '
        Me.txtDescripConceptoCargo.Location = New System.Drawing.Point(187, 92)
        Me.txtDescripConceptoCargo.Name = "txtDescripConceptoCargo"
        Me.txtDescripConceptoCargo.ReadOnly = True
        Me.txtDescripConceptoCargo.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripConceptoCargo.TabIndex = 71
        '
        'txtIDCargo
        '
        Me.txtIDCargo.Location = New System.Drawing.Point(130, 92)
        Me.txtIDCargo.Name = "txtIDCargo"
        Me.txtIDCargo.ReadOnly = True
        Me.txtIDCargo.Size = New System.Drawing.Size(51, 20)
        Me.txtIDCargo.TabIndex = 70
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Resultado de Formula:"
        '
        'cbVarFormula
        '
        Me.cbVarFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVarFormula.FormattingEnabled = True
        Me.cbVarFormula.Location = New System.Drawing.Point(131, 147)
        Me.cbVarFormula.Name = "cbVarFormula"
        Me.cbVarFormula.Size = New System.Drawing.Size(322, 21)
        Me.cbVarFormula.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Concepto de Abono:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Concepto de Cargo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Nombre Inicio:"
        '
        'txtNombrePers
        '
        Me.txtNombrePers.Location = New System.Drawing.Point(130, 67)
        Me.txtNombrePers.Name = "txtNombrePers"
        Me.txtNombrePers.Size = New System.Drawing.Size(138, 20)
        Me.txtNombrePers.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Configuración Conexión"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(271, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "=COD, >COD, <COD, COD-COD"
        '
        'cbTiposPeriodos
        '
        Me.cbTiposPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTiposPeriodos.FormattingEnabled = True
        Me.cbTiposPeriodos.Location = New System.Drawing.Point(9, 120)
        Me.cbTiposPeriodos.Name = "cbTiposPeriodos"
        Me.cbTiposPeriodos.Size = New System.Drawing.Size(239, 21)
        Me.cbTiposPeriodos.TabIndex = 76
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Periodos CONTPAQi Nominas"
        '
        'chbTiposPeriodo
        '
        Me.chbTiposPeriodo.AutoSize = True
        Me.chbTiposPeriodo.Checked = True
        Me.chbTiposPeriodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTiposPeriodo.Location = New System.Drawing.Point(18, 75)
        Me.chbTiposPeriodo.Name = "chbTiposPeriodo"
        Me.chbTiposPeriodo.Size = New System.Drawing.Size(168, 17)
        Me.chbTiposPeriodo.TabIndex = 79
        Me.chbTiposPeriodo.Text = "De todos los tipos de periodos"
        Me.chbTiposPeriodo.UseVisualStyleBackColor = True
        '
        'frmImportarCONTPAQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 483)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnImportar)
        Me.Name = "frmImportarCONTPAQ"
        Me.Text = "..:: IMPORTAR ::.."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chbEmpleados As CheckBox
    Friend WithEvents chbImporDiasVac As CheckBox
    Friend WithEvents btnImportar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents chbTodos As CheckBox
    Friend WithEvents chbPeriodos As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombrePers As TextBox
    Friend WithEvents btnBuscarAbono As Button
    Friend WithEvents txtDescripConceptoAbono As TextBox
    Friend WithEvents txtIDAbono As TextBox
    Friend WithEvents btnBuscarCargo As Button
    Friend WithEvents txtDescripConceptoCargo As TextBox
    Friend WithEvents txtIDCargo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbVarFormula As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIDsSincro As RichTextBox
    Friend WithEvents chbTiposPeriodo As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbTiposPeriodos As ComboBox
    Friend WithEvents Label3 As Label
End Class
