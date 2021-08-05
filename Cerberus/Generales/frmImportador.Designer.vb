<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportador
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton3 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.cbFormato = New System.Windows.Forms.ComboBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.imgLoad = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "*.xlsx|*.xlsx|*.png|*.png"
        Me.OpenFileDialog1.Multiselect = True
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(442, 146)
        Me.MaterialRaisedButton2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = True
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(139, 41)
        Me.MaterialRaisedButton2.TabIndex = 19
        Me.MaterialRaisedButton2.Text = "Cargar"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton3
        '
        Me.MaterialRaisedButton3.Depth = 0
        Me.MaterialRaisedButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 4.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaterialRaisedButton3.Location = New System.Drawing.Point(416, 18)
        Me.MaterialRaisedButton3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton3.Name = "MaterialRaisedButton3"
        Me.MaterialRaisedButton3.Primary = True
        Me.MaterialRaisedButton3.Size = New System.Drawing.Size(165, 20)
        Me.MaterialRaisedButton3.TabIndex = 21
        Me.MaterialRaisedButton3.Text = "Ver Ejemplo"
        Me.MaterialRaisedButton3.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(9, 112)
        Me.MaterialRaisedButton1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(169, 21)
        Me.MaterialRaisedButton1.TabIndex = 17
        Me.MaterialRaisedButton1.Text = "Examinar"
        Me.MaterialRaisedButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'cbFormato
        '
        Me.cbFormato.FormattingEnabled = True
        Me.cbFormato.Location = New System.Drawing.Point(9, 38)
        Me.cbFormato.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbFormato.Name = "cbFormato"
        Me.cbFormato.Size = New System.Drawing.Size(386, 21)
        Me.cbFormato.TabIndex = 20
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(11, 85)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPath.Multiline = True
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(572, 23)
        Me.txtPath.TabIndex = 22
        '
        'imgLoad
        '
        Me.imgLoad.ErrorImage = Nothing
        Me.imgLoad.Image = Global.Cerberus.My.Resources.Resources.tres
        Me.imgLoad.InitialImage = Nothing
        Me.imgLoad.Location = New System.Drawing.Point(399, 11)
        Me.imgLoad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.imgLoad.Name = "imgLoad"
        Me.imgLoad.Size = New System.Drawing.Size(198, 187)
        Me.imgLoad.TabIndex = 23
        Me.imgLoad.TabStop = False
        Me.imgLoad.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Formato de Importación"
        '
        'frmImportador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(597, 197)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.imgLoad)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.MaterialRaisedButton2)
        Me.Controls.Add(Me.MaterialRaisedButton3)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.cbFormato)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximumSize = New System.Drawing.Size(613, 236)
        Me.MinimumSize = New System.Drawing.Size(613, 236)
        Me.Name = "frmImportador"
        Me.Text = "Importador de Cuentas"
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton3 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents cbFormato As ComboBox
    Friend WithEvents imgLoad As PictureBox
    Public WithEvents txtPath As TextBox
    Friend WithEvents Label1 As Label
End Class
