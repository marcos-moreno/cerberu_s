Imports System.Data.SqlClient
Imports Cerberus

Public Class ExistenciaProducto
    Implements InterfaceTablas

    Public idExistencia As Integer
    Public idProductoCompuesto As Integer
    Public idUbicacion As Integer
    Public cantidad As Decimal
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idAlmacen As Integer
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public cantidadTemporal As Decimal
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String
    Private conex As ConexionSQL

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        Throw New NotImplementedException()
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQryMod("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID

        conex.accion = "SELECT"
        conex.agregaCampo("idExistencia ")
        conex.agregaCampo("cantidad")
        conex.tabla = "ExistenciaProducto"
        conex.condicion = "WHERE idProductoCompuesto=" & idProductoCompuesto
        conex.condicion += "  AND idUbicacion=" & idUbicacion
        conex.armarQry()
        'MsgBox(conex.Qry)
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idExistencia = conex.reader.Item("idExistencia")
                cantidadTemporal = conex.reader.Item("cantidad")
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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
            actualizadoPor = Ambiente.usuario.idEmpleado
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
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


    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ExistenciaProducto"
            conex.accion = accion
            conex.agregaCampo("idProductoCompuesto", idProductoCompuesto, False, False)
            conex.agregaCampo("idUbicacion", idUbicacion, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idAlmacen", idAlmacen, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = " WHERE idExistencia = " & idExistencia
            conex.armarQry()
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function armaQryMod(accion As String, esInsert As Boolean) As Boolean
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ExistenciaProducto"
            conex.accion = accion
            conex.agregaCampo("idProductoCompuesto", idProductoCompuesto, False, False)
            conex.agregaCampo("idUbicacion", idUbicacion, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = " WHERE idExistencia = " & idExistencia
            conex.armarQry()
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
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
                idExistencia = conex.reader("ID")
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
End Class
