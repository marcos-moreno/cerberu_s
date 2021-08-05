Imports System.Data.SqlClient
Imports Cerberus

Public Class DetalleEntregas
    Implements InterfaceTablas

    Public idEntrega As Integer
    Public idDetalleEntrega As Integer
    Public idEmpleado As Integer
    Public idProductoCompuesto As Integer
    Public cantidad As Decimal
    Public descuento As Decimal
    Public precio As Decimal
    Public total As Decimal
    Public nombreProd As String
    Public nombreEmpleado As String
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String
    Public idUbicacion As Integer
    Public nombreUbicacion As String


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        nombreUbicacion = rdr("nombreUbicacion")
        idUbicacion = rdr("idUbicacion")
        idEntrega = rdr("idEntrega")
        idDetalleEntrega = rdr("idDetalleEntrega")
        idEmpleado = rdr("idEmpleado")
        idProductoCompuesto = rdr("idProductoCompuesto")
        cantidad = rdr("cantidad")
        descuento = rdr("descuento")
        precio = rdr("precio")
        total = rdr("total")
        actualizadoPor = rdr("actualizadoPor")
        creadoPor = rdr("creadoPor")
        nombreProd = rdr("producto")
        nombreEmpleado = rdr("empleado")
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
            conex.tabla = "DetalleEntregas"
            conex.accion = accion
            conex.agregaCampo("idEntrega", idEntrega, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idProductoCompuesto", idProductoCompuesto, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("descuento", descuento, False, False)
            conex.agregaCampo("precio", precio, False, False)
            conex.agregaCampo("total", total, False, False)
            conex.agregaCampo("idUbicacion", idUbicacion, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.condicion = "WHERE idDetalleEntrega = " & idDetalleEntrega
            conex.armarQry()
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub cargaGrdDetallesEntrega(grid As DataGridView, idEntregaBs As Integer, idEmpleadoBs As Integer, objDEntrega As List(Of DetalleEntregas))
        Dim condicion As String
        condicion = ""
        If idEmpleadoBs <> 0 And idEntregaBs <> 0 Then
            condicion += " WHERE de.idEmpleado =" & idEmpleadoBs & " AND de.idEntrega=" & idEntregaBs
            cargarGridGenDetallesEntrega(grid, condicion, objDEntrega)
        End If
    End Sub


    Private Sub cargarGridGenDetallesEntrega(grid As DataGridView, condicion As String, objDEntrega As List(Of DetalleEntregas))
        Dim plantilla As DetalleEntregas
        Dim dtb As New DataTable("DetalleEntrega")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("Entrega", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Producto Compuesto", Type.GetType("System.String"))
        dtb.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtb.Columns.Add("descuento", Type.GetType("System.String"))
        dtb.Columns.Add("precio", Type.GetType("System.String"))
        dtb.Columns.Add("Total", Type.GetType("System.Double"))
        objDEntrega.Clear()
        conex.accion = "SELECT "
        conex.agregaCampo("CONCAT(ubic.codigo,' ',al.nombreAlmacen) as nombreUbicacion")
        conex.agregaCampo("CONCAT(p.descripcion,' ',modelo.nombre,' ',talla.nombre,' ',color.nombre) as producto")
        conex.agregaCampo("concat(empl.nombreEmpleado,' ',empl.apMatEmpleado,' ', empl.apPatEmpleado) as empleado")
        conex.agregaCampo("de.*")
        conex.tabla = " DetalleEntregas de "
        conex.condicion = "
                         INNER JOIN Empleado empl ON empl.idEmpleado = de.idEmpleado
                         INNER JOIN ProductoCompuesto pc ON pc.idProductoCompuesto = de.idProductoCompuesto
                         INNER JOIN CaracteristicaProducto color ON pc.idColor = color.idCaracteristica
                         INNER JOIN CaracteristicaProducto modelo ON pc.idModelo = modelo.idCaracteristica
                         INNER JOIN CaracteristicaProducto talla ON pc.idTalla = talla.idCaracteristica
                         INNER JOIN Ubicacion ubic ON ubic.idUbicacion = de.idUbicacion
					     INNER JOIN Almacen al ON al.idAlmacen = ubic.idAlmacen
                         INNER JOIN Producto p ON p.idProducto = pc.idProducto
                          " & condicion

        conex.armarQry()
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DetalleEntregas(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objDEntrega.Add(plantilla)
                row = dtb.NewRow
                row("Entrega") = plantilla.idEntrega
                row("Empleado") = plantilla.idEmpleado
                row("Producto Compuesto") = conex.reader("producto")
                row("Cantidad") = plantilla.cantidad
                row("Descuento") = plantilla.descuento
                row("precio") = plantilla.precio
                row("Total") = plantilla.total
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
            Mensaje.origen = "Cuenta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(grid As DataGridView, idEntrega As Integer)
        Dim condicion As String
        condicion = ""
        If idEntrega <> 0 Then
            condicion = " WHERE idEntrega= " & idEntrega
        End If
        cargarGridEmpleado(grid, condicion)
    End Sub

    Public Sub cargarGridEmpleado(grid As DataGridView, condicion As String)
        Dim plantilla As DetalleEntregas
        Dim dtb As New DataTable("DetalleEntrega")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("nombre", Type.GetType("System.String"))
        dtb.Columns.Add("ID Empleado", Type.GetType("System.String"))
        conex.accion = "SELECT"
        conex.agregaCampo("concat(e.nombreEmpleado,' ',e.apMatEmpleado,' ', e.apPatEmpleado) as nombre")
        conex.agregaCampo("e.idEmpleado")
        conex.tabla = "DetalleEntregas de"
        conex.condicion = "INNER JOIN Empleado e on de.idEmpleado=e.idEmpleado " & condicion & " 
                            GROUP BY e.nombreEmpleado,e.apMatEmpleado,e.apPatEmpleado,e.idEmpleado"
        conex.armarQry()
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DetalleEntregas(Ambiente)
                'plantilla.seteaDatos(conex.reader)
                row = dtb.NewRow
                row("nombre") = conex.reader("idEmpleado")
                row("ID Empleado") = conex.reader("nombre")
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
            Mensaje.origen = "Empleado.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idEntrega = conex.reader("ID")
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

    Friend Function calcular(descuento As Decimal, precio As Decimal, cantidad As Integer, idEmpleado As Integer, fecha As Date) As Decimal
        If validarEmpleado(idEmpleado, fecha) Then
            descuento = descuento * 0.01
            precio = cantidad * precio
            descuento = precio * descuento
            Return precio - descuento
        Else
            Return cantidad * precio
        End If
    End Function

    Friend Function validarEmpleado(idEmpleado As Integer, fecha As Date) As Byte
        Dim numeroEntregas As Integer
        conex.Qry = "SELECT 
	        count(idDetalleEntrega)  as numeroEntregas
            FROM DetalleEntregas de
            INNER JOIN Entregas e
            ON e.idEntrega = de.idEntrega 
            WHERE  
	            MONTH(e.fecha) < DATEADD(MM, -6, " & fecha & ")  
	            AND idEmpleado = " & idEmpleado & "
	            AND de.descuento <> 0"
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                numeroEntregas = conex.reader("numeroEntregas")
            End While
            conex.reader.Close()
        Else
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
        If numeroEntregas > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
