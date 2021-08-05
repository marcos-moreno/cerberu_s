Imports System.Data.SqlClient
Imports Cerberus

Public Class LogTransaccion
    Implements InterfaceTablas

    Public idLogTransaccion As Integer
    Public tabla As String
    Public idTabla As Integer
    Public valorAnterior As String
    Public nuevoValor As String
    Public columna As String
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub cargarGrid(grid As DataGridView, objEmp As List(Of LogTransaccion))
        Dim plantilla As LogTransaccion
        Dim dtb As New DataTable("Archivo")
        Dim row As DataRow

        dtb.Columns.Add("Campo", Type.GetType("System.String"))
        dtb.Columns.Add("Valor Anterior", Type.GetType("System.String"))
        dtb.Columns.Add("Nuevo Valor", Type.GetType("System.String"))
        dtb.Columns.Add("Actualizado", Type.GetType("System.String"))
        dtb.Columns.Add("Actualizado Por", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT l.*,e.nombreEmpleado as ActualizadoPor FROM LogTransaccion as l,Empleado as e WHERE l.actualizadoPor = e.idEmpleado AND l.idTabla = " & idTabla & " AND l.tabla = '" & tabla & "' ORDER BY actualizado desc"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New LogTransaccion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)

                row = dtb.NewRow
                row("Campo") = plantilla.columna
                row("Valor Anterior") = plantilla.valorAnterior
                row("Nuevo Valor") = plantilla.nuevoValor
                row("Actualizado") = plantilla.actualizado
                row("Actualizado Por") = conex.reader("ActualizadoPor")

                dtb.Rows.Add(row)
            End While

            grid.DataSource = dtb
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "LogTransaccion.cargarGrid"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idLogTransaccion = rdr("idLogTransaccion")
        tabla = rdr("tabla")
        idTabla = rdr("idTabla")
        valorAnterior = rdr("valorAnterior")
        nuevoValor = rdr("nuevoValor")
        columna = rdr("columna")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Throw New NotImplementedException()
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Throw New NotImplementedException()
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        Throw New NotImplementedException()
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        Throw New NotImplementedException()
    End Function
End Class
