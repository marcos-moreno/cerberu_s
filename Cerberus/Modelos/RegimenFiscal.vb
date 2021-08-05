Imports System.Data.SqlClient
Imports Cerberus

Public Class RegimenFiscal
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idRegimen As Integer
    Public nombreregimen As String

    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idRegimen = rdr("idRegimen")
        nombreregimen = rdr("nombreregimen")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", True)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "RegimenFiscal"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idRegimen=" & idRegimen

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

    Public Function areaDefault() As Boolean
        conex.numCon = 0
        conex.tabla = "RegimenFiscal"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE idRegimen=" & idRegimen & " ORDER BY idRegimen ASC"

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

        actualizadoPor = Ambiente.usuario.idEmpleado

        Return True
    End Function

    Public Function getCombo(combo As ComboBox, objCombo As List(Of RegimenFiscal)) As Boolean
        Dim filtro As String
        filtro = ""
        Return getComboTodos(combo, objCombo, filtro)
    End Function

    Public Function getComboTodos(combo As ComboBox, objCombo As List(Of RegimenFiscal), filtro As String) As Boolean
        idError = 0
        descripError = ""

        objCombo.Clear()
        combo.Items.Clear()

        Dim plantilla As RegimenFiscal

        conex.numCon = 0
        conex.Qry = "SELECT * FROM RegimenFiscal WHERE idEmpresa IN (" & idEmpresa & filtro & ", 0)"

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New RegimenFiscal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                combo.Items.Add(plantilla.nombreregimen)
                objCombo.Add(plantilla)
            End While
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of RegimenFiscal))
        Dim condicion As String
        condicion = ""

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of RegimenFiscal))
        Dim plantilla As RegimenFiscal
        Dim dtb As New DataTable("RegimenFiscal")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT * FROM Area WHERE idEmpresa = " & idEmpresa & " AND idDepartamento= " & idRegimen & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New RegimenFiscal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idRegimen
                row("Nombre") = plantilla.nombreregimen
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
            Mensaje.origen = "Area.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

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
            conex.tabla = "RegimenFiscal"
            conex.accion = accion

            conex.agregaCampo("nombreregimen", nombreregimen, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", Ambiente.usuario.idEmpleado, False, False)
            End If

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", Ambiente.usuario.idEmpleado, False, False)
            conex.agregaCampo("idEmpresa", Ambiente.empr.idEmpresa, False, False)


            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idRegimen = " & idRegimen

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
                idRegimen = conex.reader("ID")
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
