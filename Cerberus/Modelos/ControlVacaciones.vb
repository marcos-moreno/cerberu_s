Imports System.Data.SqlClient
Imports Cerberus

Public Class ControlVacaciones
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idControlVacaciones As Integer
    Public tipoMovimiento As String
    Public concepto As String
    Public idEmpleado As Integer
    Public idIncidencia As Integer
    Public diasRestantes As Integer
    Public diasMovimiento As Integer
    Public fechaRegreso As Date
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ControlVacaciones"
            conex.accion = accion

            conex.agregaCampo("tipoMovimiento", tipoMovimiento, False, False)
            conex.agregaCampo("concepto", concepto, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idIncidencia", idIncidencia, True, False)
            conex.agregaCampo("diasRestantes", diasRestantes, False, False)
            conex.agregaCampo("diasMovimiento", diasMovimiento, False, False)
            conex.agregaCampo("fechaRegreso", fechaRegreso, True, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idControlVacaciones = " & idControlVacaciones

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idControlVacaciones = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo Obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub creaDSDatos()
        rptDatos = New Reporte(Ambiente, "ControlVacaciones", "ControlVacaciones")
        dsDatos = New DataSet

        conex.numCon = 0

        conex.Qry = "EXEC [spGetKardexVacaciones] " & idEmpleado

        dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Private Sub creaDSDatosDiasVacXDep()
        rptDatos = New Reporte(Ambiente, "ControlVacaciones", "ControlVacacionesXDep")
        dsDatos = New DataSet

        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub imprimeKardex()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificarKardex()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub imprimeDiasVacXDep()
        creaDSDatosDiasVacXDep()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificarDiasVacXDep()
        creaDSDatosDiasVacXDep()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idControlVacaciones = rdr("idControlVacaciones")
        tipoMovimiento = rdr("tipoMovimiento")
        concepto = rdr("concepto")
        idEmpleado = rdr("idEmpleado")
        idIncidencia = If(IsDBNull(rdr("idIncidencia")), Nothing, rdr("idIncidencia"))
        diasRestantes = rdr("diasRestantes")
        diasMovimiento = rdr("diasMovimiento")
        fechaRegreso = If(IsDBNull(rdr("fechaRegreso")), Nothing, rdr("fechaRegreso"))
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "ControlVacaciones"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idControlVacaciones=" & idControlVacaciones

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarPIDIncidencia() As Boolean
        conex.numCon = 0
        conex.tabla = "ControlVacaciones"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idIncidencia=" & idIncidencia

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If diasMovimiento = Nothing Then
            descripError = "El número de días es un CAMPO obligatorio..."
            Return False
        End If
        If tipoMovimiento = Nothing Then
            descripError = "El tipo de movimiento es un CAMPO obligatorio..."
            Return False
        End If
        If concepto = Nothing Then
            descripError = "El concepto es un CAMPO obligatorio..."
            Return False
        End If
        If idEmpleado = Nothing Then
            descripError = "El empleado es un CAMPO obligatorio..."
            Return False
        End If


        Return True
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
End Class
