<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCryptLicencia
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtLicenciaOld = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Licencia / Solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 153)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Vencimiento"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(11, 173)
        Me.dtpFechaVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(265, 22)
        Me.dtpFechaVencimiento.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 169)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(167, 28)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtLicenciaOld
        '
        Me.txtLicenciaOld.Location = New System.Drawing.Point(12, 26)
        Me.txtLicenciaOld.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLicenciaOld.Name = "txtLicenciaOld"
        Me.txtLicenciaOld.Size = New System.Drawing.Size(636, 113)
        Me.txtLicenciaOld.TabIndex = 7
        Me.txtLicenciaOld.Text = ""
        '
        'frmCryptLicencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 232)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFechaVencimiento)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtLicenciaOld)
        Me.Name = "frmCryptLicencia"
        Me.Text = "frmCryptLicencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaVencimiento As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents txtLicenciaOld As RichTextBox
End Class
