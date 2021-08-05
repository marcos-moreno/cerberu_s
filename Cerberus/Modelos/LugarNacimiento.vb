Imports System.Data.SqlClient
Imports Cerberus

Public Class LugarNacimiento
    Implements InterfaceTablas

    Private idError As Integer
    Private descripError As String
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objUtil As Utilerias

    Public idLugarNacimiento
    Public lugarNacimiento

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idLugarNacimiento = rdr("idLugarNacimiento")
        lugarNacimiento = rdr("lugarNacimiento")
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
        If idLugarNacimiento <= 0 Then
            Return False
        End If

        conex.Qry = "SELECT * FROM LugarNacimiento WHERE idLugarNacimiento = " & idLugarNacimiento
        conex.numCon = 0
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
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "LugarNacimiento.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarPNombre() As Boolean
        If idLugarNacimiento <= 0 Then
            Return False
        End If

        lugarNacimiento = UCase(lugarNacimiento)
        lugarNacimiento = objUtil.quitarAcentos(lugarNacimiento)

        conex.Qry = "SELECT TOP 1 * FROM LugarNacimiento WHERE upper(lugarNacimiento) like '%" & lugarNacimiento & "%' ORDER BY lugarNacimiento ASC"
        conex.numCon = 0
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
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "LugarNacimiento.buscarPNombre: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
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

    Public Sub getCombo(combo As ComboBox, idCombos As List(Of LugarNacimiento))
        Dim plantilla As LugarNacimiento
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM LugarNacimiento Order By LugarNacimiento"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New LugarNacimiento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.lugarNacimiento)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "LugarNacimiento.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
