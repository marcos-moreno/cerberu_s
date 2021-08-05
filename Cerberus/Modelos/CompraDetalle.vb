Imports System.Data.SqlClient
Imports Cerberus

Public Class CompraDetalle
    Implements InterfaceTablas


    Public idError As Integer
    Public descripError As String
    Public idEmpresa As Integer
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idDetalleCompra As Integer
    Public idCompra As Integer
    Public idProductoCompuesto As Integer
    Public cantidad As Integer
    Public precio As Decimal
    Public idUbicacion As Integer
    Public creado As Date
    Public creadoPor As Integer
    Public actualizado As Date
    Public actualizadoPor As Integer
    Public idProducto As Integer
    Public ubicacion As String
    Public nombreProducto As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDetalleCompra = rdr("idDetalleCompra")
        idCompra = rdr("idCompra")
        idProductoCompuesto = rdr("idProductoCompuesto")
        cantidad = rdr("cantidad")
        precio = rdr("precio")
        idUbicacion = rdr("idUbicacion")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        nombreProducto = rdr("nombreProducto")
        idProducto = rdr("idProducto")
        ubicacion = rdr("ubicacion")
        idUbicacion = rdr("idUbicacion")
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
        Throw New NotImplementedException()
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
            conex.tabla = "DetalleCompra"
            conex.accion = accion
            conex.agregaCampo("idCompra", idCompra, False, False)
            conex.agregaCampo("idProductoCompuesto", idProductoCompuesto, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("precio", precio, False, False)
            conex.agregaCampo("idUbicacion", idUbicacion, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            conex.condicion = "WHERE idDetalleCompra = " & idDetalleCompra
            conex.armarQry()
            'MsgBox(conex.Qry)
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
                idDetalleCompra = conex.reader("ID")
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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of CompraDetalle))
        cargarGridGen(dgv, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of CompraDetalle))
        Dim plantilla As CompraDetalle
        Dim dtb As New DataTable("CompraDetalle")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("Compra", Type.GetType("System.String"))
        dtb.Columns.Add("Producto compuesto", Type.GetType("System.String"))
        dtb.Columns.Add("Descripción", Type.GetType("System.String"))
        dtb.Columns.Add("Monto", Type.GetType("System.String"))
        dtb.Columns.Add("Ubicación", Type.GetType("System.String"))
        dtb.Columns.Add("Cantidad", Type.GetType("System.String"))

        objEmp.Clear()
        conex.Qry = "SELECT 
					u.codigo As ubicacion
                    ,c.*
                    ,pc.* 
                    ,CONCAT(p.descripcion,' ',modelo.nombre,' ',color.nombre,' ',talla.nombre) as nombreProducto
                    ,p.idProducto
                    FROM 
                    DetalleCompra  c
                    INNER JOIN 
                    ProductoCompuesto pc  
                    ON  pc.idProductoCompuesto=c.idProductoCompuesto
                    INNER JOIN producto p
                    ON p.idProducto = pc.idProducto
                    INNER JOIN CaracteristicaProducto color
					ON color.idCaracteristica=pc.idColor

					INNER JOIN CaracteristicaProducto modelo
					ON modelo.idCaracteristica=pc.idModelo

					INNER JOIN CaracteristicaProducto talla
					ON talla.idCaracteristica=pc.idTalla
                    INNER JOIN Ubicacion u
					ON u.idUbicacion=c.idUbicacion
                
                    WHERE idCompra= " & idCompra & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CompraDetalle(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow

                row("Compra") = plantilla.idCompra
                row("Producto compuesto") = plantilla.idProductoCompuesto
                row("Descripción") = plantilla.nombreProducto
                row("Monto") = FormatCurrency(plantilla.precio)
                row("Ubicación") = plantilla.ubicacion
                row("Cantidad") = plantilla.cantidad
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
            Mensaje.origen = "CuentaDetalle.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
