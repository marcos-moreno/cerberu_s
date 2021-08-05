Public Class frmEnviaIncidencias
    Public Ambiente As AmbienteCls
    Private objSincronizar As SincronizarContpaq
    Private objPeriodo As Periodo
    Private cbObjPeriodo As New List(Of Periodo)
    Private cbObjPeriodosCTPQ As New List(Of Integer)

    Private Sub frmEnviaIncidencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSincronizar = New SincronizarContpaq(Ambiente)

        objPeriodo = New Periodo(Ambiente)
        objPeriodo.tabla = "Registro"
        objPeriodo.elementoSistema = "ES"
        objPeriodo.idEmpresa = Ambiente.empr.idEmpresa
        objPeriodo.ejercicio = Now.Year

        cbPeriodos.SelectedIndex = -1

        objPeriodo.getComboTodos(cbPeriodos, cbObjPeriodo)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If Not objSincronizar.creaIncidencias(cbObjPeriodo(cbPeriodos.SelectedIndex), cbObjPeriodosCTPQ(cbPeriodosCTPQ.SelectedIndex)) Then
            Mensaje.Mensaje = objSincronizar.descripError
        Else
            Mensaje.Mensaje = "PROCESO COMPLETADO CORRECTAMENTE..."
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub cbPeriodos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriodos.SelectedIndexChanged
        If cbPeriodos.SelectedIndex <> -1 Then

            objSincronizar.getComboPeriodoCTPQxID(cbPeriodosCTPQ, cbObjPeriodosCTPQ, cbObjPeriodo(cbPeriodos.SelectedIndex).idPeriodoCTPQ)
            If cbPeriodosCTPQ.Items.Count > 0 Then
                cbPeriodosCTPQ.SelectedIndex = 0
                btnSincronizar.Enabled = True
            Else
                cbPeriodosCTPQ.SelectedIndex = -1
                btnSincronizar.Enabled = False
            End If
        Else
            cbPeriodosCTPQ.SelectedIndex = -1
        End If

    End Sub
End Class