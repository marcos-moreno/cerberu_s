<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSincCxPAdempiere
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
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.imgLoad = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cbxSucursal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(9, 7)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(39, 13)
        Me.lblEstado.TabIndex = 16
        Me.lblEstado.Text = "Label1"
        '
        'imgLoad
        '
        Me.imgLoad.ErrorImage = Nothing
        Me.imgLoad.Image = Global.Cerberus.My.Resources.Resources.tres
        Me.imgLoad.InitialImage = Nothing
        Me.imgLoad.Location = New System.Drawing.Point(69, 44)
        Me.imgLoad.Margin = New System.Windows.Forms.Padding(2)
        Me.imgLoad.Name = "imgLoad"
        Me.imgLoad.Size = New System.Drawing.Size(153, 153)
        Me.imgLoad.TabIndex = 21
        Me.imgLoad.TabStop = False
        Me.imgLoad.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.Cerberus.My.Resources.Resources.sincronizar
        Me.Button1.Location = New System.Drawing.Point(118, 66)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 89)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Sincronizar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.Image = Global.Cerberus.My.Resources.Resources.log
        Me.PictureBox3.InitialImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(11, 314)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(49, 38)
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'cbxSucursal
        '
        Me.cbxSucursal.FormattingEnabled = True
        Me.cbxSucursal.Location = New System.Drawing.Point(61, 249)
        Me.cbxSucursal.Margin = New System.Windows.Forms.Padding(2)
        Me.cbxSucursal.Name = "cbxSucursal"
        Me.cbxSucursal.Size = New System.Drawing.Size(212, 21)
        Me.cbxSucursal.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(141, 234)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Organización"
        '
        'frmSincCxPAdempiere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 362)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxSucursal)
        Me.Controls.Add(Me.imgLoad)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.PictureBox3)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmSincCxPAdempiere"
        Me.Text = "Pagos de Destajo ADempiere"
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents imgLoad As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cbxSucursal As ComboBox
    Friend WithEvents Label1 As Label
End Class
