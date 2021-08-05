Imports System.Data.SqlClient
Imports Cerberus

Public Class Sucursal
    Implements InterfaceTablas

    'CAMPOS TABLA
    Public idSucursal As Integer
    Public nombreSucursal As String
    Public idEmpresa As Integer
    Public esActivo As Boolean
    Public creadoPor As String
    Public creado As DateTime
    Public actualizadoPor As String
    Public actualizado As DateTime
    Public excedentesPagaSuc As Boolean
    Public cuentapago As String
    Public bancopago As String
    Public telefono As String
    'VARIABLES
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Sucursal), filtro As String)
        Dim condicion As String

        condicion = " AND (idSucursal like '%" & filtro & "%'"
        condicion &= " or nombreSucursal like '%" & filtro & "%')"

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of Sucursal))
        Dim plantilla As Sucursal
        Dim dtb As New DataTable("Sucursal")
        Dim row As DataRow

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre de Sucursal", Type.GetType("System.String"))
        obj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")


        conex.tabla = "Sucursal"
        conex.condicion = "Where idEmpresa = " & idEmpresa & " " & condicion
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Sucursal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idSucursal
                row("Nombre de Sucursal") = plantilla.nombreSucursal
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
            Mensaje.origen = "Sucursal.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


    Sub New(amb As AmbienteCls)
        Ambiente = amb
        conex = amb.conex
    End Sub

    'Clase especifica de Empresa x Empleado >>>
    Public Sub getComboXEmplado(combo As ComboBox, idCombos As List(Of Sucursal), idEmpleado As Integer, idEmpresa As Integer)
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa = " & idEmpresa & " AND idSucursal in (select idAcceso from dbo.fnGetIDsAcceso(" & idEmpleado & ",'Sucursal'))"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Clase especifica de Sucursal Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Sucursal))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 and idEmpresa = " & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Sucursal), filtro As String)
        Dim plantilla As Sucursal
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Sucursal " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Sucursal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreSucursal)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Sucursal.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idSucursal = rdr("idSucursal")
        nombreSucursal = rdr("nombreSucursal")
        idEmpresa = rdr("idEmpresa")
        esActivo = rdr("esActivo")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        excedentesPagaSuc = rdr("excedentesPagaSuc")
        cuentapago = If(IsDBNull(rdr("cuentapago")), Nothing, rdr("cuentapago"))
        bancopago = If(IsDBNull(rdr("bancopago")), Nothing, rdr("bancopago"))
        telefono = If(IsDBNull(rdr("telefono")), Nothing, rdr("telefono"))
    End Sub

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.Qry = "SELECT * FROM Sucursal WHERE idSucursal = " & idSucursal
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID Buscado..."
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
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

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        Return True
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Sucursal"
            conex.accion = accion

            conex.agregaCampo("nombreSucursal", nombreSucursal, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("excedentesPagaSuc", excedentesPagaSuc, False, False)
            conex.agregaCampo("cuentapago", cuentapago, True, False)
            conex.agregaCampo("bancopago", bancopago, True, False)
            conex.agregaCampo("telefono", telefono, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idSucursal = " & idSucursal

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
                idSucursal = conex.reader("ID")
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
