<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportarInformacion
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
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.cbFieldDate = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MaterialRaisedButton5 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MaterialRaisedButton6 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton3 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lbText = New System.Windows.Forms.Label()
        Me.txtFilterText = New System.Windows.Forms.TextBox()
        Me.cbFieldText = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFilterIDs = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.MaterialRaisedButton4 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.cbFormato = New System.Windows.Forms.ComboBox()
        Me.bteExportar = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbDepartamento = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpInicio
        '
        Me.dtpInicio.Location = New System.Drawing.Point(315, 17)
        Me.dtpInicio.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(222, 20)
        Me.dtpInicio.TabIndex = 0
        '
        'dtpFin
        '
        Me.dtpFin.Location = New System.Drawing.Point(548, 17)
        Me.dtpFin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(230, 20)
        Me.dtpFin.TabIndex = 1
        '
        'cbFieldDate
        '
        Me.cbFieldDate.FormattingEnabled = True
        Me.cbFieldDate.Location = New System.Drawing.Point(133, 15)
        Me.cbFieldDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbFieldDate.Name = "cbFieldDate"
        Me.cbFieldDate.Size = New System.Drawing.Size(179, 21)
        Me.cbFieldDate.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MaterialRaisedButton5)
        Me.GroupBox1.Controls.Add(Me.MaterialRaisedButton2)
        Me.GroupBox1.Controls.Add(Me.lbFecha)
        Me.GroupBox1.Controls.Add(Me.dtpFin)
        Me.GroupBox1.Controls.Add(Me.cbFieldDate)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(782, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar por Fecha"
        '
        'MaterialRaisedButton5
        '
        Me.MaterialRaisedButton5.Depth = 0
        Me.MaterialRaisedButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 4.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaterialRaisedButton5.Location = New System.Drawing.Point(4, 51)
        Me.MaterialRaisedButton5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton5.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton5.Name = "MaterialRaisedButton5"
        Me.MaterialRaisedButton5.Primary = True
        Me.MaterialRaisedButton5.Size = New System.Drawing.Size(29, 30)
        Me.MaterialRaisedButton5.TabIndex = 10
        Me.MaterialRaisedButton5.Text = "-"
        Me.MaterialRaisedButton5.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(98, 10)
        Me.MaterialRaisedButton2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = True
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(30, 30)
        Me.MaterialRaisedButton2.TabIndex = 9
        Me.MaterialRaisedButton2.Text = "+"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = True
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Location = New System.Drawing.Point(38, 51)
        Me.lbFecha.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(10, 13)
        Me.lbFecha.TabIndex = 3
        Me.lbFecha.Text = ":"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MaterialRaisedButton6)
        Me.GroupBox2.Controls.Add(Me.MaterialRaisedButton3)
        Me.GroupBox2.Controls.Add(Me.lbText)
        Me.GroupBox2.Controls.Add(Me.txtFilterText)
        Me.GroupBox2.Controls.Add(Me.cbFieldText)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 128)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(782, 81)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtrar por Texto"
        '
        'MaterialRaisedButton6
        '
        Me.MaterialRaisedButton6.Depth = 0
        Me.MaterialRaisedButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 4.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaterialRaisedButton6.Location = New System.Drawing.Point(4, 46)
        Me.MaterialRaisedButton6.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton6.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton6.Name = "MaterialRaisedButton6"
        Me.MaterialRaisedButton6.Primary = True
        Me.MaterialRaisedButton6.Size = New System.Drawing.Size(29, 30)
        Me.MaterialRaisedButton6.TabIndex = 11
        Me.MaterialRaisedButton6.Text = "-"
        Me.MaterialRaisedButton6.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton3
        '
        Me.MaterialRaisedButton3.Depth = 0
        Me.MaterialRaisedButton3.Location = New System.Drawing.Point(97, 11)
        Me.MaterialRaisedButton3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton3.Name = "MaterialRaisedButton3"
        Me.MaterialRaisedButton3.Primary = True
        Me.MaterialRaisedButton3.Size = New System.Drawing.Size(30, 30)
        Me.MaterialRaisedButton3.TabIndex = 10
        Me.MaterialRaisedButton3.Text = "+"
        Me.MaterialRaisedButton3.UseVisualStyleBackColor = True
        '
        'lbText
        '
        Me.lbText.AutoSize = True
        Me.lbText.Location = New System.Drawing.Point(52, 54)
        Me.lbText.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbText.Name = "lbText"
        Me.lbText.Size = New System.Drawing.Size(10, 13)
        Me.lbText.TabIndex = 4
        Me.lbText.Text = ":"
        '
        'txtFilterText
        '
        Me.txtFilterText.Location = New System.Drawing.Point(315, 12)
        Me.txtFilterText.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtFilterText.Multiline = True
        Me.txtFilterText.Name = "txtFilterText"
        Me.txtFilterText.Size = New System.Drawing.Size(463, 25)
        Me.txtFilterText.TabIndex = 3
        '
        'cbFieldText
        '
        Me.cbFieldText.FormattingEnabled = True
        Me.cbFieldText.Location = New System.Drawing.Point(133, 17)
        Me.cbFieldText.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbFieldText.Name = "cbFieldText"
        Me.cbFieldText.Size = New System.Drawing.Size(179, 21)
        Me.cbFieldText.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFilterIDs)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 214)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(350, 55)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtrar por ID's, separa por comas."
        '
        'txtFilterIDs
        '
        Me.txtFilterIDs.Location = New System.Drawing.Point(11, 17)
        Me.txtFilterIDs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtFilterIDs.Multiline = True
        Me.txtFilterIDs.Name = "txtFilterIDs"
        Me.txtFilterIDs.Size = New System.Drawing.Size(300, 25)
        Me.txtFilterIDs.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.MaterialRaisedButton4)
        Me.GroupBox4.Controls.Add(Me.txtSQL)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 375)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(782, 134)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SQL"
        '
        'MaterialRaisedButton4
        '
        Me.MaterialRaisedButton4.Depth = 0
        Me.MaterialRaisedButton4.Location = New System.Drawing.Point(601, 89)
        Me.MaterialRaisedButton4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton4.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton4.Name = "MaterialRaisedButton4"
        Me.MaterialRaisedButton4.Primary = True
        Me.MaterialRaisedButton4.Size = New System.Drawing.Size(176, 36)
        Me.MaterialRaisedButton4.TabIndex = 9
        Me.MaterialRaisedButton4.Text = "Exportar"
        Me.MaterialRaisedButton4.UseVisualStyleBackColor = True
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(11, 32)
        Me.txtSQL.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(767, 54)
        Me.txtSQL.TabIndex = 4
        '
        'cbFormato
        '
        Me.cbFormato.FormattingEnabled = True
        Me.cbFormato.Location = New System.Drawing.Point(14, 34)
        Me.cbFormato.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbFormato.Name = "cbFormato"
        Me.cbFormato.Size = New System.Drawing.Size(198, 21)
        Me.cbFormato.TabIndex = 7
        '
        'bteExportar
        '
        Me.bteExportar.Depth = 0
        Me.bteExportar.Location = New System.Drawing.Point(222, 25)
        Me.bteExportar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.bteExportar.MouseState = MaterialSkin.MouseState.HOVER
        Me.bteExportar.Name = "bteExportar"
        Me.bteExportar.Primary = True
        Me.bteExportar.Size = New System.Drawing.Size(176, 36)
        Me.bteExportar.TabIndex = 8
        Me.bteExportar.Text = "Exportar"
        Me.bteExportar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cbFormato)
        Me.GroupBox5.Controls.Add(Me.bteExportar)
        Me.GroupBox5.Location = New System.Drawing.Point(376, 276)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(428, 72)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Selecciona un Formato para Exportar"
        '
        'cbDepartamento
        '
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(11, 18)
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(246, 21)
        Me.cbDepartamento.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbDepartamento)
        Me.GroupBox6.Location = New System.Drawing.Point(22, 287)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(350, 55)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Filtrar por Departamento"
        '
        'frmExportarInformacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 359)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmExportarInformacion"
        Me.Text = "frmExportarInformacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents cbFieldDate As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtFilterText As TextBox
    Friend WithEvents cbFieldText As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtFilterIDs As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtSQL As TextBox
    Friend WithEvents cbFormato As ComboBox
    Friend WithEvents bteExportar As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents lbFecha As Label
    Friend WithEvents lbText As Label
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton3 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents MaterialRaisedButton4 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton5 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton6 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents cbDepartamento As ComboBox
    Friend WithEvents GroupBox6 As GroupBox
End Class
