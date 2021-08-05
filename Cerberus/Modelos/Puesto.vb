Imports System.Data.SqlClient
Imports Cerberus

Public Class Puesto
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idPuesto As Integer
    Public puesto As String
    Public idEmpresa As Integer
    Public esActivo As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idPuesto = rdr("idPuesto")
        puesto = rdr("puesto")
        idEmpresa = rdr("idEmpresa")
        esActivo = If(IsDBNull(rdr("esActivo")), False, rdr("esActivo"))
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Puesto"
            conex.accion = accion

            conex.agregaCampo("puesto", puesto, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idPuesto = " & idPuesto

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
                idPuesto = conex.reader("ID")
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

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        If idPuesto <= 0 Then
            Return False
        End If

        conex.Qry = "SELECT * FROM Puesto WHERE idPuesto = " & idPuesto
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
            Mensaje.origen = "Puesto.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarPNombre() As Boolean
        conex.numCon = 0
        conex.tabla = "Puesto"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE puesto='" & puesto & "'"

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

    Public Sub getCombo(combo As ComboBox, idCombos As List(Of Puesto))
        Dim plantilla As Puesto
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Puesto WHERE idEmpresa = " & idEmpresa & " AND esActivo = 1 ORDER BY Puesto"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Puesto(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.puesto)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Puesto.getCombo:"
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



    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Puesto), filtro As String, esActivo As Integer)
        Dim condicion As String

        condicion = " AND (idPuesto like '%" & filtro & "%'"
        condicion &= " or puesto like '%" & filtro & "%')  AND esActivo = " & esActivo

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of Puesto))
        Dim plantilla As Puesto
        Dim dtb As New DataTable("Puesto")
        Dim row As DataRow

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre de Puesto", Type.GetType("System.String"))
        obj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")


        conex.tabla = "Puesto"
        conex.condicion = "Where idEmpresa = " & idEmpresa & " " & condicion
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Puesto(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idPuesto
                row("Nombre de Puesto") = plantilla.puesto
                dtb.Rows.Add(row)
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Puesto.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
