Imports Cerberus

Public Class frmControlVacaciones
    Public Ambiente As AmbienteCls

    Private conVac As ControlVacaciones
    Private empl As Empleado

    Private Sub frmControlVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        asignarDatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If obtenerDatos() Then
            If Not conVac.guardar() Then
                Mensaje.Mensaje = conVac.descripError
                Mensaje.ShowDialog()
                Exit Sub
            End If

            conVac.buscarPID()
            empl.diasVacacionesDisponibles += conVac.diasMovimiento

            If Not empl.actualizar() Then
                Mensaje.Mensaje = empl.descripError
                Mensaje.ShowDialog()
                Exit Sub
            End If
        Else
            Mensaje.ShowDialog()
            Exit Sub
        End If

        Mensaje.Mensaje = "Datos almacenados correctamente..."
        Mensaje.ShowDialog()

        asignarDatos()
        'Me.Close()
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True

        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            empl = frmBuscaEmpleado.EmpleadoRetorno

            txtIDEmpleado.Text = empl.idEmpleado
            txtNombreEmpleado.Text = empl.nombreCompleto
            txtDiasActuales.Text = empl.diasVacacionesDisponibles
        End If
    End Sub

    Private Function obtenerDatos() As Boolean
        If Not txtIDEmpleado.Text <> "" Then
            Mensaje.Mensaje = "Favor de seleccionar un empleado antes de proceder"
            Return False
        End If

        conVac.diasRestantes = txtDiasActuales.Text
        conVac.idEmpleado = txtIDEmpleado.Text
        conVac.diasMovimiento = txtDiasMovimiento.Text
        conVac.idIncidencia = Nothing
        conVac.concepto = rtbConcepto.Text
        conVac.tipoMovimiento = "E"

        Return True
    End Function

    Private Sub asignarDatos()
        conVac = New ControlVacaciones(Ambiente)

        txtIDEmpleado.Text = ""
        txtDiasActuales.Text = ""
        txtNombreEmpleado.Text = ""

        rtbConcepto.Text = ""
        txtDiasMovimiento.Text = conVac.diasMovimiento
    End Sub
End Class