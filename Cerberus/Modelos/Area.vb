Imports System.Data.SqlClient
Imports Cerberus

Public Class Area
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idArea As Integer
    Public nombreArea As String
    Public idDepartamento As Integer
    Public descripcion As String
    Public idEmpresa As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public esActivo As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idArea = rdr("idArea")
        nombreArea = rdr("nombreArea")
        idDepartamento = rdr("idDepartamento")
        descripcion = If(IsDBNull(rdr("descripcion")), Nothing, rdr("descripcion"))
        idEmpresa = rdr("idEmpresa")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        esActivo = rdr("esActivo")
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
        conex.tabla = "Area"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idArea=" & idArea

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
        conex.tabla = "Area"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE idDepartamento=" & idDepartamento & " ORDER BY idArea ASC"

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

    Public Function getComboActivos(combo As ComboBox, objCombo As List(Of Area)) As Boolean
        Dim filtro As String
        filtro = " AND esActivo = 1"

        Return getComboTodos(combo, objCombo, filtro)
    End Function

    Public Function getComboTodos(combo As ComboBox, objCombo As List(Of Area)) As Boolean
        Return getComboTodos(combo, objCombo, "")
    End Function

    Public Function getComboTodos(combo As ComboBox, objCombo As List(Of Area), filtro As String) As Boolean
        idError = 0
        descripError = ""

        objCombo.Clear()
        combo.Items.Clear()

        Dim plantilla As Area

        conex.numCon = 0
        conex.Qry = "SELECT * FROM Area WHERE idEmpresa = " & idEmpresa & " AND idDepartamento=" & idDepartamento & filtro

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New Area(Ambiente)
                plantilla.seteaDatos(conex.reader)

                combo.Items.Add(plantilla.nombreArea)

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

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Area))
        Dim condicion As String
        condicion = ""

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Area))
        Dim plantilla As Area
        Dim dtb As New DataTable("Area")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Area", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtb.Columns.Add("Activo", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT * FROM Area WHERE idEmpresa = " & idEmpresa & " AND idDepartamento= " & idDepartamento & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Area(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Area") = plantilla.idArea
                row("Nombre") = plantilla.nombreArea
                row("Descripcion") = plantilla.descripcion
                row("Activo") = If(plantilla.esActivo, "Si", "No")

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
            conex.tabla = "Area"
            conex.accion = accion

            conex.agregaCampo("nombreArea", nombreArea, False, False)
            conex.agregaCampo("idDepartamento", idDepartamento, False, False)
            conex.agregaCampo("descripcion", descripcion, True, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idArea = " & idArea

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
                idArea = conex.reader("ID")
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
