Imports System.Data.SqlClient
Imports Cerberus

Public Class UMF
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idUMF As Integer
    Public UMF As String
    Public numUMF As String


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idUMF = rdr("idUMF")
        UMF = rdr("UMF")
        numUMF = rdr("numUMF")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Throw New NotImplementedException()
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        If idUMF <= 0 Then
            Return False
        End If

        conex.Qry = "SELECT * FROM UMF WHERE idUMF = " & idUMF
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
            Mensaje.origen = "UMF.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarPNUM() As Boolean

        conex.Qry = "SELECT * FROM UMF WHERE numUMF = " & numUMF
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
            Mensaje.origen = "UMF.buscarPNUM: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Sub getComboUMF(combo As ComboBox, idCombos As List(Of UMF))
        Dim plantilla As UMF
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM UMF"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New UMF(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.UMF)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "UMF.getComboUMF:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "UMF"
            conex.accion = accion

            conex.agregaCampo("UMF", UMF, False, False)
            conex.agregaCampo("numUMF", numUMF, False, False)

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    ObtenerID()
                End If
                Return True
            Else
                idError = conex.idError
                descripError = "UMF.ArmaQry: " & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function ObtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idUMF = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo obtener el ID de la unidad"
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
