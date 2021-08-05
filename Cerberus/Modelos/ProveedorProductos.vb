Imports System.Data.SqlClient
Imports Cerberus

Public Class ProveedorProductos
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idProveedor As Integer
    Public nombreProveedor As String
    Public rfc As String
    Public telefono As String
    Public correo As String
    Public idEmpresa As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos

        idProveedor = rdr("idProveedor")
        nombreProveedor = rdr("nombreProveedor")
        rfc = rdr("rfc")
        telefono = rdr("telefono")
        correo = rdr("correo")
        idEmpresa = rdr("idEmpresa")
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

        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.tabla = "ProveedorProductos"

        conex.condicion = "WHERE idProveedor = " & idProveedor

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If

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
            actualizadoPor = Ambiente.usuario.idEmpleado
            idEmpresa = Ambiente.empr.idEmpresa
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
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

            conex.accion = accion
            conex.tabla = "ProveedorProductos"

            conex.agregaCampo("nombreProveedor", nombreProveedor, False, False)
            conex.agregaCampo("rfc", rfc, False, False)
            conex.agregaCampo("telefono", telefono, False, False)
            conex.agregaCampo("correo", correo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("creadoPor", creadoPor, False, False)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.condicion = "WHERE idProveedor = " & idProveedor 'CUANDO ES UN UPDATE
            conex.armarQry()

            If conex.ejecutaQry() Then
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

    Public Sub cargaGrid(grid As DataGridView, objTabla As List(Of ProveedorProductos), filtro As String)
        Dim condicion As String

        condicion = " AND "
        condicion &= "( "
        condicion &= "correo like '%" & filtro & "%' "
        condicion &= "OR nombreProveedor like '%" & filtro & "%' "
        condicion &= ") "

        cargarGridGen(grid, condicion, objTabla)
    End Sub


    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objTabla As List(Of ProveedorProductos))
        Dim plantilla As ProveedorProductos
        Dim dtb As New DataTable("ProveedorProductos")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("NombreProveedor", Type.GetType("System.String"))
        dtb.Columns.Add("Rfc", Type.GetType("System.String"))
        dtb.Columns.Add("Telefono", Type.GetType("System.String"))
        dtb.Columns.Add("Correo", Type.GetType("System.String"))
        objTabla.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.tabla = "ProveedorProductos"
        conex.condicion = "WHERE idEmpresa= " & Ambiente.empr.idEmpresa & condicion

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ProveedorProductos(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objTabla.Add(plantilla)
                row = dtb.NewRow
                row("NombreProveedor") = plantilla.nombreProveedor
                row("Rfc") = plantilla.rfc
                row("Telefono") = plantilla.telefono
                row("Correo") = plantilla.correo


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
            Mensaje.origen = "ProveedorProductos.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of ProveedorProductos))
        Dim filtro As String
        filtro = "WHERE idEmpresa = " & idEmpresa
        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion  COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of ProveedorProductos), filtro As String)
        Dim plantilla As ProveedorProductos
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM ProveedorProductos " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ProveedorProductos(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreProveedor)
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
