Imports System.Data.SqlClient
Imports Cerberus

Public Class CargoAbonoPrestamo
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String

    Public idCargoAbonoPrestamo As Integer
    Public idPrestamo As Integer
    Public cantidad As Decimal
    Public observaciones As String
    Public idConceptoCuenta As Integer
    Public tipo As String
    Public fecha As DateTime
    Public idCuenta As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public referencia As String
    Public estado As String

    Private edoDocs As EstadoDocumentos

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        edoDocs = New EstadoDocumentos
    End Sub

    Public Function getNombreEstado() As String
        Return edoDocs.getNombreEstado(estado)
    End Function

    Private Sub creaDSDatos()
        rptDatos = New Reporte(Ambiente, "CargoAbonoPrestamo", "Recibo")

        rptDatos.agregaVarible("idCargoAbonoPrestamo", idCargoAbonoPrestamo)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub imprimeRecibo()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificaRecibo()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCargoAbonoPrestamo = rdr("idCargoAbonoPrestamo")
        idPrestamo = rdr("idPrestamo")
        cantidad = rdr("cantidad")
        observaciones = rdr("observaciones")
        idConceptoCuenta = rdr("idConceptoCuenta")
        tipo = rdr("tipo")
        fecha = rdr("fecha")
        idCuenta = If(IsDBNull(rdr("idCuenta")), Nothing, rdr("idCuenta"))
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        referencia = rdr("referencia")
        estado = rdr("estado")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", True)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", True)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "CargoAbonoPrestamo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idCargoAbonoPrestamo = " & idCargoAbonoPrestamo

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "El registro solicitado no existe."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub actualizarSaldo()
        Dim objPrestamo As New Prestamo(Ambiente)
        Dim cantidadOperacion As Decimal

        If tipo = "CxP" Then
            cantidadOperacion = cantidad * -1
        Else
            cantidadOperacion = cantidad
        End If

        objPrestamo.idPrestamo = idPrestamo
        objPrestamo.buscarPID()
        objPrestamo.actualizarSaldo(cantidadOperacion)
    End Sub

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
            conex.tabla = "CargoAbonoPrestamo"
            conex.accion = accion

            conex.agregaCampo("idPrestamo", idPrestamo, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("observaciones", observaciones, False, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)
            conex.agregaCampo("tipo", tipo, False, False)
            conex.agregaCampo("fecha", fecha, False, False)
            conex.agregaCampo("idCuenta", idCuenta, True, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("referencia", referencia, False, False)
            conex.agregaCampo("estado", estado, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCargoAbonoPrestamo = " & idCargoAbonoPrestamo

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    actualizarSaldo()
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "CargoAbonoPrestamo.armaQry" & vbCrLf & conex.descripError
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
                idCargoAbonoPrestamo = conex.reader("ID")
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

    Public Sub cargaGrid(grid As DataGridView, obj As List(Of CargoAbonoPrestamo))
        cargarGridGen(grid, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of CargoAbonoPrestamo))
        Dim plantilla As CargoAbonoPrestamo
        Dim dtb As New DataTable("CargoAbonoPrestamo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo", Type.GetType("System.String"))
        dtb.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Observaciones", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT * FROM CargoAbonoPrestamo as C  WHERE C.idPrestamo =  " & idPrestamo & condicion & " Order By fecha"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CargoAbonoPrestamo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("Fecha") = FormatDateTime(plantilla.fecha)
                row("Tipo") = If(plantilla.tipo = "CxC", "Cargo", "Abono")
                row("Cantidad") = FormatCurrency(plantilla.cantidad)
                row("Estado") = plantilla.estado
                row("Observaciones") = Mid(plantilla.observaciones, 1, 20)

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
            Mensaje.origen = "Prestamo.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
