Imports System.Data.SqlClient
Imports Cerberus

Public Class CodigoPostal
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private idError As Integer
    Private descripError As String

    Public idCodigoPostal As Integer
    Public codigoPostal As String
    Public estado As String
    Public municipio As String
    Public ciudad As String
    Public tipoAsentamiento As String
    Public asentamiento As String
    Public claveOficina As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub getAsentamiento(combo As ComboBox, idCombos As List(Of CodigoPostal))
        Dim plantilla As CodigoPostal
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "EXEC [spGetAsentamiento] " & If(idCodigoPostal = Nothing, "NULL", idCodigoPostal) & "," & If(codigoPostal = Nothing, "NULL", "'" & codigoPostal & "'") & "," & If(estado = Nothing, "NULL", "'" & estado & "'") & "," & If(municipio = Nothing, "NULL", "'" & municipio & "'") & "," & If(ciudad = Nothing, "NULL", "'" & ciudad & "'") & "," & If(tipoAsentamiento = Nothing, "NULL", "'" & tipoAsentamiento & "'")
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CodigoPostal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.asentamiento)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "CodigoPostal.getAsentamiento:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub GetCombosCP(combo As ComboBox, nombreCombo As String)
        combo.Items.Clear()

        conex.Qry = "EXEC spGetCombosCP " & If(idCodigoPostal = Nothing, "NULL", idCodigoPostal) & "," & If(codigoPostal = Nothing, "NULL", "'" & codigoPostal & "'") & "," & If(estado = Nothing, "NULL", "'" & estado & "'") & "," & If(municipio = Nothing, "NULL", "'" & municipio & "'") & "," & If(ciudad = Nothing, "NULL", "'" & ciudad & "'") & "," & If(tipoAsentamiento = Nothing, "NULL", "'" & tipoAsentamiento & "'") & ",'" & nombreCombo & "'"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                Select Case nombreCombo
                    Case "estado"
                        combo.Items.Add(conex.reader(0))
                    Case "municipio"
                        combo.Items.Add(conex.reader(0))
                    Case "ciudad"
                        combo.Items.Add(conex.reader(0))
                    Case "tipoAsentamiento"
                        combo.Items.Add(conex.reader(0))
                End Select

            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "CodigoPostal.GetCombosCP:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCodigoPostal = rdr("idCodigoPostal")
        codigoPostal = rdr("codigoPostal")
        estado = rdr("estado")
        municipio = rdr("municipio")
        ciudad = rdr("ciudad")
        tipoAsentamiento = rdr("tipoAsentamiento")
        asentamiento = rdr("asentamiento")
        claveOficina = rdr("claveOficina")
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
        If idCodigoPostal <= 0 Then
            Return False
        End If

        conex.Qry = "SELECT * FROM CodigoPostal WHERE idCodigoPostal = " & idCodigoPostal
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
            Mensaje.origen = "CodigoPostal.buscarPID: "
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
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "CodigoPostal"
            conex.accion = accion

            conex.agregaCampo("codigoPostal", codigoPostal, False, False)
            conex.agregaCampo("estado", estado, False, False)
            conex.agregaCampo("municipio", municipio, False, False)
            conex.agregaCampo("ciudad", ciudad, False, False)
            conex.agregaCampo("tipoAsentamiento", tipoAsentamiento, False, False)
            conex.agregaCampo("asentamiento", asentamiento, False, False)
            conex.agregaCampo("claveOficina", claveOficina, False, False)

            'If esInsert Then
            '    conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
            '    conex.agregaCampo("creadoPor", creadoPor, False, False)
            'End If
            'conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            'conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCodigoPostal = " & idCodigoPostal

            conex.armarQry()

            If conex.ejecutaQry Then
                Return True
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function
End Class
