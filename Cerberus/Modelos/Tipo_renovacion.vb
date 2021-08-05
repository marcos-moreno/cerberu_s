Imports System.Data.SqlClient

Public Class Tipo_renovacion
    Implements InterfaceTablas


    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL


    Public id_tipo_renovacion As Integer
    Public nombre As String
    Public dias_renovacion As Integer
    Public indetermindado As Boolean

    Public idError As Integer
    Public descripError As String


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        id_tipo_renovacion = rdr("id_tipo_renovacion")
        nombre = rdr("nombre")
        dias_renovacion = rdr("dias_renovacion")
        indetermindado = rdr("indetermindado")
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
        conex.numCon = 0
        conex.tabla = "tipo_renovacion"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE id_tipo_renovacion =" & id_tipo_renovacion
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

    Public Sub getCombo(combo As ComboBox, idCombos As List(Of Tipo_renovacion))
        Dim plantilla As Tipo_renovacion
        combo.Items.Clear()
        idCombos.Clear()
        conex.Qry = "SELECT * FROM  tipo_renovacion "
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Tipo_renovacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombre)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "tipo_renovacion.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        conex.numCon = 0
        conex.accion = accion
        conex.agregaCampo("nombre", nombre, False, False)
        conex.agregaCampo("dias_renovacion", dias_renovacion, False, False)
        conex.agregaCampo("indetermindado", indetermindado, False, False)
        conex.agregaCampo("id_tipo_renovacion", id_tipo_renovacion, False, False)
        conex.condicion = "WHERE id_tipo_renovacion = " & id_tipo_renovacion
        conex.armarQry()
        If conex.ejecutaQry Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function
End Class
