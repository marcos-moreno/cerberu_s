Imports System.Data.SqlClient
Imports Cerberus

Public Class ProductoCompuesto
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idProductoCompuesto As Integer
    Public idProduct As Integer
    Public idTalla As Integer
    Public idModelo As Integer
    Public idColor As Integer
    Public idEmpresa As Integer
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public codigo As Integer

    Public idUbicacion As Integer
    Public porcentaje As Decimal
    Public precio As Decimal
    Public discount As Byte
    Public color As String
    Public talla As String
    Public modelo As String
    Public producto As String

    Public nombreUbicacion As String
    Public cantidad As Decimal
    Public creado As DateTime
    Public actualizado As DateTime
    Public codigoCompuesto As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        producto = rdr("producto")
        talla = rdr("talla")
        modelo = rdr("modelo")
        color = rdr("color")
        idProductoCompuesto = rdr("idProductoCompuesto")
        idProduct = rdr("idProducto")
        creadoPor = rdr("creadoPor")
        discount = rdr("discount")
        idModelo = rdr("idModelo")
        idColor = rdr("idColor")
        idTalla = rdr("idTalla")
        precio = rdr("precio")
        idEmpresa = rdr("idEmpresa")
        porcentaje = rdr("porcentaje")
        Try
            idUbicacion = rdr("idUbicacion")
        Catch ex As Exception
            idUbicacion = 0
        End Try
        Try
            nombreUbicacion = rdr("ubicacionC")
        Catch ex As Exception
            nombreUbicacion = ""
        End Try
        Try
            cantidad = rdr("cantidad")
        Catch ex As Exception
            cantidad = 0
        End Try
        codigoCompuesto = rdr("codigoProd") & Format(idModelo, "00") & Format(idColor, "00") & Format(idTalla, "00")

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

        conex.accion = "SELECT "
        conex.agregaCampo("pc.*")
        conex.agregaCampo("p.codigo As codigoProd")
        conex.agregaCampo("cpM.nombre As modelo")
        conex.agregaCampo("cpT.nombre As talla")
        conex.agregaCampo("cpC.nombre As color")
        conex.tabla = " ProductoCompuesto"
        conex.condicion = " 
                            INNER JOIN Producto p ON p.idProducto =pc.idProducto
                            INNER JOIN CaracteristicaProducto cpM ON cpM.idCaracteristica=pc.idModelo
                            INNER JOIN CaracteristicaProducto cpT ON cpT.idCaracteristica=pc.idTalla
                            INNER JOIN CaracteristicaProducto cpC ON cpC.idCaracteristica=pc.idColor "
        conex.condicion &= " WHERE idProductoCompuesto = " & idProductoCompuesto

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
            creadoPor = Ambiente.usuario.idEmpleado
            actualizadoPor = Ambiente.usuario.idEmpleado
            idEmpresa = Ambiente.empr.idEmpresa
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
            conex.tabla = "ProductoCompuesto"
            conex.agregaCampo("idProducto", idProduct, False, False)
            conex.agregaCampo("idTalla", idTalla, False, False)
            conex.agregaCampo("idModelo", idModelo, False, False)
            conex.agregaCampo("idColor", idColor, False, False)
            conex.agregaCampo("idEmpresa", Ambiente.empr.idEmpresa, False, False)
            conex.agregaCampo("creadoPor", creadoPor, False, False)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("precio", precio, False, False)
            conex.agregaCampo("discount", discount, False, False)
            conex.agregaCampo("porcentaje", porcentaje, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.condicion = "WHERE idProductoCompuesto = " & idProductoCompuesto 'CUANDO ES UN UPDATE
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

    Public Sub cargaGrid(grid As DataGridView, objTabla As List(Of ProductoCompuesto), filtro As String, wExistence As Boolean)
        Dim condicion As String
        condicion = " AND "
        condicion &= "( "
        condicion &= " cpM.nombre like '%" & filtro & "%' "
        condicion &= " OR cpT.nombre like '%" & filtro & "%' "
        condicion &= " OR cpC.nombre like '%" & filtro & "%' "
        condicion &= " OR p.descripcion like '%" & filtro & "%' "
        condicion &= ") "
        If wExistence = False Then
            condicion &= " GROUP BY pc.idProductoCompuesto,u.codigo,al.nombreAlmacen,u.idUbicacion, u.idAlmacen,exis.cantidad,
	                        p.descripcion,pc.idProducto,pc.idTalla,pc.idModelo,pc.idColor,pc.creado,pc.creadoPor,pc.actualizado,pc.actualizadoPor
	                        ,pc.idEmpresa,pc.precio,pc.discount,pc.porcentaje,p.codigo,cpM.nombre,cpT.nombre,cpC.nombre "
        End If
        cargarGridGen(grid, condicion, objTabla, wExistence)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objTabla As List(Of ProductoCompuesto), wExistence As Boolean)
        Dim plantilla As ProductoCompuesto
        Dim dtb As New DataTable("ProductoCompuesto")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("Modelo", Type.GetType("System.String"))
        dtb.Columns.Add("Color", Type.GetType("System.String"))
        dtb.Columns.Add("Talla", Type.GetType("System.String"))
        dtb.Columns.Add("producto", Type.GetType("System.String"))
        dtb.Columns.Add("Precio", Type.GetType("System.String"))
        If wExistence Then
            dtb.Columns.Add("Ubicación", Type.GetType("System.String"))
            dtb.Columns.Add("Cantidad disponible", Type.GetType("System.String"))
        End If
        objTabla.Clear()
        conex.numCon = 0
        conex.accion = "SELECT "
        conex.agregaCampo("CASE 
		                        WHEN u.codigo is NULL
		                        THEN '--'
		                        ELSE CONCAT(u.codigo, ' ',al.nombreAlmacen  )
                            END as ubicacionC")
        conex.agregaCampo("CASE 
		                            WHEN u.idUbicacion is NULL
		                            THEN 0
		                            ELSE u.idUbicacion
                                END as idUbicacion")
        conex.agregaCampo("CASE 
		                            WHEN u.idAlmacen is NULL
		                            THEN 0
		                            ELSE u.idAlmacen
                                END as idAlmacen")
        conex.agregaCampo("CASE 
		                            WHEN exis.cantidad is NULL
		                            THEN 0
		                            ELSE exis.cantidad
                                END as cantidad ")
        conex.agregaCampo("p.descripcion As producto")
        conex.agregaCampo("pc.*")
        conex.agregaCampo("p.codigo As codigoProd")
        conex.agregaCampo("cpM.nombre As modelo")
        conex.agregaCampo("cpT.nombre As talla")
        conex.agregaCampo("cpC.nombre As color")
        conex.tabla = " ProductoCompuesto as pc "
        conex.condicion = " 
	                        INNER JOIN CaracteristicaProducto cpM    ON cpM.idCaracteristica=pc.idModelo
                            INNER JOIN CaracteristicaProducto cpT  ON cpT.idCaracteristica=pc.idTalla
                            INNER JOIN CaracteristicaProducto cpC  ON cpC.idCaracteristica=pc.idColor 
                            INNER JOIN Producto As p  ON p.idProducto=pc.idProducto
	                        LEFT JOIN ExistenciaProducto  exis ON exis.idProductoCompuesto = pc.idProductoCompuesto
	                        LEFT JOIN Ubicacion u ON u.idUbicacion = exis.idUbicacion 
	                        LEFT JOIN Almacen al  ON al.idAlmacen = u.idAlmacen
"
        conex.condicion &= "WHERE pc.idEmpresa= " & Ambiente.empr.idEmpresa & condicion
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ProductoCompuesto(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objTabla.Add(plantilla)
                row = dtb.NewRow
                row("Modelo") = plantilla.modelo
                row("Color") = plantilla.color
                row("Talla") = plantilla.talla
                row("producto") = plantilla.producto
                row("Precio") = plantilla.precio
                If wExistence Then
                    row("Ubicación") = conex.reader("ubicacionC")
                    row("Cantidad disponible") = plantilla.cantidad
                End If
                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()
            grid.DataSource = dtb
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "ProductoCompuesto.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of ProductoCompuesto))
        Dim filtro As String
        filtro = "WHERE idEmpresa = " & idEmpresa
        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion  COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of ProductoCompuesto), filtro As String)
        Dim plantilla As ProductoCompuesto
        combo.Items.Clear()
        idCombos.Clear()
        conex.Qry = "SELECT * FROM ProductoCompuesto " & filtro
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ProductoCompuesto(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.idColor)
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
