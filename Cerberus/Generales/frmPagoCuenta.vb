Public Class frmPagoCuenta
    Public Ambiente As AmbienteCls
    Public idRetorno As Integer
    Public fechaRetorno As Date
    Public tipoCuenta As String ' CxP - CxC

    Private Sub btnConcepto_Click(sender As Object, e As EventArgs) Handles btnConcepto.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = tipoCuenta
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If txtIDConcepto.Text = "" Then
            Mensaje.Mensaje = "Es necesario Seleccionar el Concepto, con las que seran generadas la(s) Cuenta(s) >> (" & tipoCuenta & ")"
            Mensaje.ShowDialog()
        Else
            fechaRetorno = DateTimePicker1.Value
            idRetorno = txtIDConcepto.Text
            DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmPagoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIDConcepto.Text = ""
        txtDescripConcepto.Text = ""
        DateTimePicker1.Value = Now
    End Sub
End Class