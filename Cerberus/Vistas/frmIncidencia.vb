Public Class frmIncidencia

    Public Ambiente As AmbienteCls

    Private nuevoReg As Boolean
    Private cond As String

    Private objCbTipoInc As New List(Of TipoIncidencia)
    Private tipoInc As TipoIncidencia

    Private objCbDep As New List(Of Departamento)
    Private dep As Departamento

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private objDgvInc As New List(Of Incidencia)
    Private inc As Incidencia

    Private objEmp As New List(Of Empleado)
    Private empl As Empleado

    Private Sub frmIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inc = New Incidencia(Ambiente)
        inc.idEmpresa = Ambiente.empr.idEmpresa

        tipoInc = New TipoIncidencia(Ambiente)
        tipoInc.idEmpresa = Ambiente.empr.idEmpresa
        tipoInc.getComboActivo(cbTipoIncidencia, objCbTipoInc)

        dep = New Departamento(Ambiente)
        dep.idEmpresa = Ambiente.empr.idEmpresa
        dep.getComboActivo(cbDepartamento, objCbDep)

        empl = New Empleado(Ambiente)
        empl.idEmpresa = Ambiente.empr.idEmpresa

        dtpFechaIncidencia.Value = Now
    End Sub

    Private Sub obtenerDatos()
        inc.fecha = dtpFechaIncidencia.Value
        inc.esActivo = True

        If cbTipoIncidencia.SelectedIndex <> -1 Then
            inc.idTipoIncidencia = objCbTipoInc.Item(cbTipoIncidencia.SelectedIndex).idTipoIncidencia
            inc.calculada = objCbTipoInc.Item(cbTipoIncidencia.SelectedIndex).calculada
            inc.incidenciaXDia = objCbTipoInc.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia
        Else
            inc.idTipoIncidencia = Nothing
        End If

        If cbDepartamento.SelectedIndex <> -1 Then
            cond = " AND d.idDepartamento=" & objCbDep.Item(cbDepartamento.SelectedIndex).idDepartamento
        Else
            cond = ""
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim bandera As Boolean = False
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If empl.getEmpleadosXDepartamento(objEmp, cond) Then
            For x As Integer = 0 To objEmp.Count - 1
                inc.idEmpleado = objEmp.Item(x).idEmpleado
                inc.idDepartamento = objEmp.Item(x).idDepartamento
                inc.nombreLider = objEmp.Item(x).getDepartamento.nombreLider
                inc.idSucursal = objEmp.Item(x).idSucursal
                inc.idHorario = objEmp.Item(x).idHorario

                If inc.guardar() Then
                    bandera = True
                End If
            Next
        End If

        If bandera Then
            Mensaje.Mensaje = "Se guardaron correctamente la(s) incidencia(s)"
            Mensaje.ShowDialog()
        End If
        cbDepartamento.SelectedIndex = -1
        cbTipoIncidencia.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "Incidencia"
        frmImportar.valor1 = ""
        frmImportar.valor2 = ""
        frmImportar.ShowDialog()
    End Sub
End Class