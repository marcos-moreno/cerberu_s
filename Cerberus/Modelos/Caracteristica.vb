Imports System.Data.SqlClient
Imports Cerberus

Public Class Caracteristica
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idCaracteristica As Integer
    Public nombreCaracteristica As String
    Public idEmpresa As Integer
    Public tabla As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCaracteristica = rdr("idCaracteristica")
        nombreCaracteristica = rdr("nombreCaracteristica")
        idEmpresa = rdr("idEmpresa")
        tabla = rdr("tabla")
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
        conex.tabla = "Caracteristica"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idCaracteristica=" & idCaracteristica

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
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
            idEmpresa = Ambiente.empr.idEmpresa
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If nombreCaracteristica = "" Then
            idError = 1
            descripError = "No se puede ingresar un valor vacio..."
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Caracteristica"
            conex.accion = accion

            conex.agregaCampo("nombreCaracteristica", nombreCaracteristica, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("tabla", tabla, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCaracteristica = " & idCaracteristica

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

    Public Sub cargaGridFiltro(dgv As DataGridView, obj As List(Of Caracteristica), filtro As String)
        Dim condicion As String

        filtro = Replace(filtro, "*", "%")
        condicion = " AND nombreCaracteristica like '%" & filtro & "%'"

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of Caracteristica))
        Dim plantilla As Caracteristica
        Dim dtb As New DataTable("Caracteristica")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID", Type.GetType("System.Int32"))
        dtb.Columns.Add("Caracteristica", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT * FROM Caracteristica WHERE idEmpresa = " & idEmpresa & " AND tabla= '" & tabla & "'" & condicion & " Order By nombreCaracteristica"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Caracteristica(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idCaracteristica
                row("Caracteristica") = plantilla.nombreCaracteristica

                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Caracteristica.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
