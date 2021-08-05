Imports System.Data.SqlClient
Imports Cerberus

Public Class Almacen
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idAlmacen As Integer
    Public nombreAlmacen As String
    Public codigoAlmacen As String
    Public idEmpresa As String
    Public idSucursal As String
    Public creadoPor As Integer

    Public creado As Date
    Public actualizado As Date
    Public actualizadoPor As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idAlmacen = rdr("idAlmacen")
        nombreAlmacen = rdr("nombreAlmacen")
        codigoAlmacen = rdr("codigoAlmacen")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
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


    Friend Sub getComboAlmacen(combo As ComboBox, idCombos As List(Of Almacen), idSucursal As Integer)
        Dim filtro As String
        filtro = "WHERE idSucursal = " & idSucursal
        getCombo(combo, idCombos, filtro)
    End Sub



    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Almacen), filtro As String)
        Dim plantilla As Almacen
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Almacen " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Almacen(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreAlmacen)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Sucursal.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
