<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoCuenta
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btnConcepto = New System.Windows.Forms.Button()
        Me.txtDescripConcepto = New System.Windows.Forms.TextBox()
        Me.txtIDConcepto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(44, 36)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(321, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'btnConcepto
        '
        Me.btnConcepto.Location = New System.Drawing.Point(371, 79)
        Me.btnConcepto.Name = "btnConcepto"
        Me.btnConcepto.Size = New System.Drawing.Size(43, 23)
        Me.btnConcepto.TabIndex = 39
        Me.btnConcepto.Text = "..."
        Me.btnConcepto.UseVisualStyleBackColor = True
        '
        'txtDescripConcepto
        '
        Me.txtDescripConcepto.Location = New System.Drawing.Point(99, 81)
        Me.txtDescripConcepto.Name = "txtDescripConcepto"
        Me.txtDescripConcepto.ReadOnly = True
        Me.txtDescripConcepto.Size = New System.Drawing.Size(266, 20)
        Me.txtDescripConcepto.TabIndex = 38
        '
        'txtIDConcepto
        '
        Me.txtIDConcepto.Location = New System.Drawing.Point(42, 81)
        Me.txtIDConcepto.Name = "txtIDConcepto"
        Me.txtIDConcepto.ReadOnly = True
        Me.txtIDConcepto.Size = New System.Drawing.Size(51, 20)
        Me.txtIDConcepto.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Concepto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Fecha Cuenta:"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(295, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(161, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 23)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmPagoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 159)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConcepto)
        Me.Controls.Add(Me.txtDescripConcepto)
        Me.Controls.Add(Me.txtIDConcepto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmPagoCuenta"
        Me.Text = "..:: Datos de la Cuenta ::.."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents btnConcepto As Button
    Friend WithEvents txtDescripConcepto As TextBox
    Friend WithEvents txtIDConcepto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
