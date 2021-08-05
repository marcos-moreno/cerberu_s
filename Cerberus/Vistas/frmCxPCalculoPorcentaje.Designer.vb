<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCxPCalculoPorcentaje
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
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.dtpFechaMov = New System.Windows.Forms.DateTimePicker()
        Me.lbPorcentaje = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lblSueldo = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel4 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        Me.lblMontoFinal = New MaterialSkin.Controls.MaterialLabel()
        Me.SuspendLayout()
        '
        'btnEmpleado
        '
        Me.btnEmpleado.Location = New System.Drawing.Point(641, 39)
        Me.btnEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(57, 28)
        Me.btnEmpleado.TabIndex = 34
        Me.btnEmpleado.Text = "..."
        Me.btnEmpleado.UseVisualStyleBackColor = True
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(269, 41)
        Me.txtNombreEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreEmpleado.TabIndex = 33
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Location = New System.Drawing.Point(193, 41)
        Me.txtIDEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(66, 22)
        Me.txtIDEmpleado.TabIndex = 32
        '
        'dtpFechaMov
        '
        Me.dtpFechaMov.Location = New System.Drawing.Point(193, 144)
        Me.dtpFechaMov.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaMov.Name = "dtpFechaMov"
        Me.dtpFechaMov.Size = New System.Drawing.Size(265, 22)
        Me.dtpFechaMov.TabIndex = 36
        '
        'lbPorcentaje
        '
        Me.lbPorcentaje.AutoSize = True
        Me.lbPorcentaje.Depth = 0
        Me.lbPorcentaje.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.lbPorcentaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbPorcentaje.Location = New System.Drawing.Point(22, 202)
        Me.lbPorcentaje.MouseState = MaterialSkin.MouseState.HOVER
        Me.lbPorcentaje.Name = "lbPorcentaje"
        Me.lbPorcentaje.Size = New System.Drawing.Size(119, 24)
        Me.lbPorcentaje.TabIndex = 37
        Me.lbPorcentaje.Text = "Porcentaje %"
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(22, 144)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(124, 24)
        Me.MaterialLabel1.TabIndex = 38
        Me.MaterialLabel1.Text = "Fecha Cuenta"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel2.Location = New System.Drawing.Point(22, 43)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(96, 24)
        Me.MaterialLabel2.TabIndex = 39
        Me.MaterialLabel2.Text = "Empleado"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(193, 202)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPorcentaje.Size = New System.Drawing.Size(137, 22)
        Me.txtPorcentaje.TabIndex = 40
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(255, 257)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(285, 31)
        Me.MaterialRaisedButton1.TabIndex = 41
        Me.MaterialRaisedButton1.Text = "Crear Cuenta"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'lblSueldo
        '
        Me.lblSueldo.AutoSize = True
        Me.lblSueldo.Depth = 0
        Me.lblSueldo.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.lblSueldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSueldo.Location = New System.Drawing.Point(189, 96)
        Me.lblSueldo.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblSueldo.Name = "lblSueldo"
        Me.lblSueldo.Size = New System.Drawing.Size(153, 24)
        Me.lblSueldo.TabIndex = 42
        Me.lblSueldo.Text = "No seleccionado"
        '
        'MaterialLabel4
        '
        Me.MaterialLabel4.AutoSize = True
        Me.MaterialLabel4.Depth = 0
        Me.MaterialLabel4.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel4.Location = New System.Drawing.Point(22, 96)
        Me.MaterialLabel4.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel4.Name = "MaterialLabel4"
        Me.MaterialLabel4.Size = New System.Drawing.Size(68, 24)
        Me.MaterialLabel4.TabIndex = 43
        Me.MaterialLabel4.Text = "Sueldo"
        '
        'MaterialLabel3
        '
        Me.MaterialLabel3.AutoSize = True
        Me.MaterialLabel3.Depth = 0
        Me.MaterialLabel3.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel3.Location = New System.Drawing.Point(352, 202)
        Me.MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel3.Name = "MaterialLabel3"
        Me.MaterialLabel3.Size = New System.Drawing.Size(81, 24)
        Me.MaterialLabel3.TabIndex = 44
        Me.MaterialLabel3.Text = "CxP por:"
        '
        'lblMontoFinal
        '
        Me.lblMontoFinal.AutoSize = True
        Me.lblMontoFinal.Depth = 0
        Me.lblMontoFinal.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.lblMontoFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMontoFinal.Location = New System.Drawing.Point(439, 202)
        Me.lblMontoFinal.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblMontoFinal.Name = "lblMontoFinal"
        Me.lblMontoFinal.Size = New System.Drawing.Size(122, 24)
        Me.lblMontoFinal.TabIndex = 45
        Me.lblMontoFinal.Text = "No calculado"
        '
        'frmCxPCalculoPorcentaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 300)
        Me.Controls.Add(Me.lblMontoFinal)
        Me.Controls.Add(Me.MaterialLabel3)
        Me.Controls.Add(Me.MaterialLabel4)
        Me.Controls.Add(Me.lblSueldo)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.lbPorcentaje)
        Me.Controls.Add(Me.dtpFechaMov)
        Me.Controls.Add(Me.btnEmpleado)
        Me.Controls.Add(Me.txtNombreEmpleado)
        Me.Controls.Add(Me.txtIDEmpleado)
        Me.Name = "frmCxPCalculoPorcentaje"
        Me.Text = "frmCxPCalculoPorcentaje"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEmpleado As Button
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents dtpFechaMov As DateTimePicker
    Friend WithEvents lbPorcentaje As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents lblSueldo As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel4 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents lblMontoFinal As MaterialSkin.Controls.MaterialLabel
End Class
