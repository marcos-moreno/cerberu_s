Imports System.Data.SqlClient
Imports Cerberus

Public Class Ubicacion
    Implements InterfaceTablas


    Public idError As Integer
    Public descripError As String

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idUbicacion As Integer
    Public idAlmacen As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As Date
    Public creadoPor As Integer
    Public actualizado As Date
    Public actualizadoPor As Integer
    Public codigo As String
    Public cantidadproductos As Integer
    Public idTipoProducto As Integer

    Public almacen As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub



    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idUbicacion = rdr("idUbicacion")
        idAlmacen = rdr("idAlmacen")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        codigo = rdr("codigo")
        cantidadproductos = rdr("cantidadproductos")
        idTipoProducto = rdr("idTipoProducto")
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

    Public Sub cargaGridCom(dgv As DataGridView, idSucursal As Integer, obj As List(Of Ubicacion))
        cargarGrid(dgv, idSucursal, obj)
    End Sub

    Private Sub cargarGrid(grid As DataGridView, idSucursal As Integer, objEmp As List(Of Ubicacion))
        Dim plantilla As Ubicacion
        Dim dtb As New DataTable("Ubicacion")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Código", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo Producto", Type.GetType("System.String"))
        dtb.Columns.Add("Cantidad productos", Type.GetType("System.String"))

        objEmp.Clear()
        conex.Qry = "SELECT * FROM Ubicacion WHERE idSucursal=" & idSucursal
        conex.numCon = 0
        If conex.ejecutaConsulta() Then

            While conex.reader.Read
                plantilla = New Ubicacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Código") = plantilla.codigo
                row("Tipo Producto") = plantilla.idTipoProducto
                row("Cantidad productos") = plantilla.cantidadproductos

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
            Mensaje.origen = "Ubicación.cargarGridUbicacion"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

End Class
