<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesaIncidenciasGen
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.imgLoad = New System.Windows.Forms.PictureBox()
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(374, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 45)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Procesar Todo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Periodo: "
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(128, 41)
        Me.cbPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(441, 24)
        Me.cbPeriodo.TabIndex = 4
        '
        'imgLoad
        '
        Me.imgLoad.ErrorImage = Nothing
        Me.imgLoad.Image = Global.Cerberus.My.Resources.Resources.tres
        Me.imgLoad.InitialImage = Nothing
        Me.imgLoad.Location = New System.Drawing.Point(128, -8)
        Me.imgLoad.Name = "imgLoad"
        Me.imgLoad.Size = New System.Drawing.Size(441, 210)
        Me.imgLoad.TabIndex = 22
        Me.imgLoad.TabStop = False
        Me.imgLoad.Visible = False
        '
        'frmProcesaIncidenciasGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 202)
        Me.Controls.Add(Me.imgLoad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmProcesaIncidenciasGen"
        Me.Text = "frmProcesaIncidenciasGen"
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents imgLoad As PictureBox
End Class
