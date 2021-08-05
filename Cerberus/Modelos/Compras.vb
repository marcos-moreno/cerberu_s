Imports System.Data.SqlClient
Imports Cerberus

Public Class Compras
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public idCompra As Integer
    Public fecha As Date
    Public noFactura As String
    Public idProveedor As Integer
    Public idSucursal As Integer
    Public idAlmacen As Integer
    Public idEmpresa As Integer
    Public creado As Date
    Public creadoPor As Integer
    Public actualizado As Date
    Public actualizadoPor As Integer
    Public observacion As String
    Public estado As String
    Public nombreProveedor As String
    Public montoTotal As Decimal

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCompra = rdr("idCompra")
        fecha = rdr("fecha")
        noFactura = rdr("noFactura")
        idProveedor = rdr("idProveedor")
        idSucursal = rdr("idSucursal")
        idAlmacen = rdr("idAlmacen")
        idEmpresa = rdr("idEmpresa")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        If rdr("observacion") Is DBNull.Value Then
            observacion = Nothing
        Else
            observacion = rdr("observacion")
        End If
        estado = rdr("estado")
        nombreProveedor = rdr("nombreProveedor")
        montoTotal = rdr("montoTotal")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If estado = "BO" Then
            Return armaQry("DELETE", False)
        ElseIf estado = "CO" Then
            idError = 1
            descripError = "No se puede eliminar la Compra debido a que ya se encuentra Procesada."
            Return False
        Else
            Return True
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        creadoPor = Ambiente.usuario.idEmpleado
        actualizadoPor = Ambiente.usuario.idEmpleado
        If estado = "CO" And Not Ambiente.usuario.esSupervisor Then
            estado = "PA"
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
            conex.tabla = "Compras"
            conex.accion = accion
            conex.agregaCampo("noFactura", noFactura, False, False)
            conex.agregaCampo("idProveedor", idProveedor, False, False)
            conex.agregaCampo("fecha", fecha, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idAlmacen", idAlmacen, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, True, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("observacion", observacion, True, False)
            conex.agregaCampo("estado", estado, False, False)
            conex.agregaCampo("montoTotal", montoTotal, False, False)
            conex.condicion = "WHERE idCompra = " & idCompra
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

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idCompra = conex.reader("ID")
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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Compras), idSucursalB As Integer, fechaFinal As String, documento As String, EstadoDocumentos As String)
        Dim condicion As String
        condicion = " WHERE c.idEmpresa=" & Ambiente.empr.idEmpresa
        If EstadoDocumentos <> "" Then
            condicion &= " AND c.estado = '" & EstadoDocumentos & "' "
        End If
        If fechaFinal <> Nothing Then
            Dim formato As String = ""
            Try
                formato = Format(CDate(fechaFinal), "yyyy/MM/dd")
                condicion &= " AND c.fecha  <=  '" & formato & "' "
            Catch ex As Exception
            End Try
        End If
        If documento <> "" Then
            condicion &= " AND c.noFactura LIKE '%" & documento & "%'"
        End If
        If idSucursalB <> 0 Then
            condicion &= " AND c.idSucursal = '" & idSucursalB & "' "
        End If
        cargarGridGen(dgv, condicion, obj)
    End Sub
    Private edoDocs As EstadoDocumentos

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Compras))
        edoDocs = New EstadoDocumentos
        Dim plantilla As Compras
        Dim dtb As New DataTable("Cuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento", Type.GetType("System.String"))
        dtb.Columns.Add("Observacion", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Monto Total", Type.GetType("System.String"))

        objEmp.Clear()
        conex.Qry = "SELECT c.*,s.nombreSucursal,p.nombreProveedor FROM Compras c INNER JOIN Sucursal s ON s.idSucursal=c.idSucursal  INNER JOIN ProveedorProductos p ON p.idProveedor=c.idProveedor  "

        conex.Qry &= condicion
        conex.Qry &= "  ORDER BY s.idSucursal"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Compras(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento") = plantilla.noFactura
                row("Observacion") = plantilla.observacion
                row("Sucursal") = conex.reader("nombreSucursal")
                row("Fecha") = Format(plantilla.fecha, "dd/MM/yyyy")
                row("Estado") = edoDocs.getNombreEstado(plantilla.estado)
                row("Monto Total") = plantilla.montoTotal
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
            Mensaje.origen = "Cuenta.cargarGridGenEmpl"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

End Class
