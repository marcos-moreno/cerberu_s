Imports System.Data.SqlClient
Imports Cerberus

Public Class ResultadoCocina
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Public idResultadoCocina As Integer
    Public idPeriodo As Integer
    Public idEmpleado As Integer
    Public nssEmpleado As String
    Public idDepartamento As Integer
    Public idCocinaAsig As Integer
    Public idCocinaReg As Integer
    Public costoComida As Decimal
    Public descuento As Decimal
    Public sansion As Decimal
    Public numReg As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public fecha As Date

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idResultadoCocina = rdr("idResultadoCocina")
        idPeriodo = rdr("idPeriodo")
        idEmpleado = rdr("idEmpleado")
        nssEmpleado = If(IsDBNull(rdr("nssEmpleado")), Nothing, rdr("nssEmpleado"))
        idDepartamento = rdr("idDepartamento")
        idCocinaAsig = If(IsDBNull(rdr("idCocinaAsig")), Nothing, rdr("idCocinaAsig"))
        idCocinaReg = If(IsDBNull(rdr("idCocinaReg")), Nothing, rdr("idCocinaReg"))
        costoComida = If(IsDBNull(rdr("costoComida")), Nothing, rdr("costoComida"))
        descuento = If(IsDBNull(rdr("descuento")), Nothing, rdr("descuento"))
        sansion = If(IsDBNull(rdr("sansion")), Nothing, rdr("sansion"))
        numReg = rdr("numReg")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        fecha = rdr("fecha")
    End Sub

    Public Function totalPEmplyPeriodo(ByRef numReg As Integer, ByRef totalComidas As Decimal) As Boolean
        numReg = 0
        totalComidas = 0

        conex.numCon = 0
        conex.tabla = "ResultadoCocina"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idPeriodo=" & idPeriodo & " AND idEmpleado=" & idEmpleado

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                seteaDatos(conex.reader)

                numReg += Me.numReg
                totalComidas += numReg * (costoComida - descuento)
            End While
            conex.reader.Close()

            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

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
