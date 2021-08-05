Imports System.Data.SqlClient
Imports Cerberus

Public Class TipoIncidencia
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idTipoIncidencia As Integer
    Public codigoIncidencia As String
    Public nombreIncidencia As String
    Public idEmpresa As Integer
    Public esActivo As Boolean
    Public idTipoIncidenciaCTPQ As Integer
    Public nombreCTPQ As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public isDefault As Boolean
    Public calculada As Boolean
    Public tolerancia As Integer
    Public incidenciaXDia As Boolean
    Public pagaPrimaVac As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of TipoIncidencia))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND calculada= " & If(calculada, 1, 0)

        getCombo(combo, idCombos, filtro)
    End Sub

    Public Sub getComboActivoTablaRegistro(combo As ComboBox, idCombos As List(Of TipoIncidencia), filtr As String)
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND calculada= " & If(calculada, 1, 0) & filtr

        getCombo(combo, idCombos, filtro)
    End Sub
    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of TipoIncidencia), filtro As String)
        Dim plantilla As TipoIncidencia
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM TipoIncidencia " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New TipoIncidencia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreIncidencia)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "TipoIncidencia.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTipoIncidencia = rdr("idTipoIncidencia")
        nombreIncidencia = rdr("nombreIncidencia")
        idEmpresa = rdr("idEmpresa")
        esActivo = rdr("esActivo")
        codigoIncidencia = rdr("codigoIncidencia")
        idTipoIncidenciaCTPQ = If(IsDBNull(rdr("idTipoIncidenciaCTPQ")), Nothing, rdr("idTipoIncidenciaCTPQ"))
        nombreCTPQ = If(IsDBNull(rdr("nombreCTPQ")), Nothing, rdr("nombreCTPQ"))
        isDefault = rdr("isDefault")
        calculada = rdr("calculada")
        tolerancia = rdr("tolerancia")
        incidenciaXDia = rdr("incidenciaXDia")
        pagaPrimaVac = rdr("pagaPrimaVac")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        conex.numCon = 0
        conex.tabla = "TipoIncidencia"
        conex.accion = "DELETE"

        conex.condicion = "WHERE idTipoIncidencia=" & idTipoIncidencia

        conex.armarQry()

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "TipoIncidencia"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idTipoIncidencia=" & idTipoIncidencia

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function

    Public Function buscarPNombre() As Boolean
        conex.numCon = 0
        conex.tabla = "TipoIncidencia"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreIncidencia='" & nombreIncidencia & "'"

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
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

        'If isDefault Then
        '    descripError = "Los VALORES POR DEFAULT no pueden ser modificados...!!"
        '    Return False
        'End If

        actualizadoPor = Ambiente.usuario.idEmpleado

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
            conex.tabla = "TipoIncidencia"
            conex.accion = accion

            conex.agregaCampo("codigoIncidencia", codigoIncidencia, False, False)
            conex.agregaCampo("nombreIncidencia", nombreIncidencia, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idTipoIncidenciaCTPQ", idTipoIncidenciaCTPQ, False, False)
            conex.agregaCampo("nombreCTPQ", nombreCTPQ, True, False)
            conex.agregaCampo("isDefault", isDefault, False, False)
            conex.agregaCampo("calculada", calculada, False, False)
            conex.agregaCampo("tolerancia", tolerancia, False, False)
            conex.agregaCampo("incidenciaXDia", incidenciaXDia, False, False)
            conex.agregaCampo("pagaPrimaVac", pagaPrimaVac, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idTipoIncidencia = " & idTipoIncidencia

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "TipoIncidencia.armaQry" & vbCrLf & conex.descripError
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
                idTipoIncidencia = conex.reader("ID")
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

    Public Sub cargaGridGen(grid As DataGridView, obj As List(Of TipoIncidencia))
        cargaGridGen(grid, "", obj)
    End Sub

    Private Sub cargaGridGen(grid As DataGridView, condicion As String, obj As List(Of TipoIncidencia))
        Dim plantilla As TipoIncidencia
        Dim dtb As New DataTable("TipoIncidencia")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Código", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Incidencia CTPQ", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT T.* FROM TipoIncidencia as T WHERE T.idEmpresa = " & idEmpresa & " " & condicion & " ORDER BY nombreIncidencia"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New TipoIncidencia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Código") = plantilla.codigoIncidencia
                row("Nombre") = plantilla.nombreIncidencia
                row("Incidencia CTPQ") = plantilla.nombreCTPQ

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
            Mensaje.origen = "TipoIncidencia.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

End Class
