Imports System.Threading
Public Class frmProcesaIncidenciasGen
    Private perido As Periodo
    Public Ambiente As AmbienteCls
    Private objCbPerido As New List(Of Periodo)
    Public elementoSistemas As String = "ES"
    Private threadSinc As Thread
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If cbPeriodo.SelectedIndex > 0 Then
            If objCbPerido.Item(cbPeriodo.SelectedIndex).esActivo = True Then
                imgLoad.Visible = True
                threadSinc = New Thread(AddressOf execute)
                threadSinc.Start()
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Este Período ya esta completo....."
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "Selecciona un Período....."
            Mensaje.ShowDialog()
        End If

    End Sub

    Public Sub execute()
        Try
            objCbPerido.Item(cbPeriodo.SelectedIndex).procesarIncidencias()
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Ejecución Completa.!!"
            Mensaje.ShowDialog()
            imgLoad.Visible = False
            GC.Collect()
        Catch ex As ThreadAbortException
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = ex.Message
            Mensaje.ShowDialog()
        End Try
    End Sub


    Private Sub frmProcesaIncidenciasGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        perido = New Periodo(Ambiente)
        perido.idEmpresa = Ambiente.empr.idEmpresa
        perido.ejercicio = Now.Year
        perido.tabla = "Registro"
        perido.elementoSistema = elementoSistemas
        If Not perido.getComboTodos(cbPeriodo, objCbPerido) Then
            Mensaje.Mensaje = perido.descripError
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub
End Class