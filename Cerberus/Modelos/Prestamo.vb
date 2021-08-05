Imports System.Data.SqlClient
Imports Cerberus

Public Class Prestamo
    Implements InterfaceTablas

    Private edoDocs As EstadoDocumentos

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String

    Public idPrestamo As Integer
    Public idSocioNegocio As Integer
    Public idEmpleado As Integer
    Public cantidad As Decimal
    Public interesAnual As Decimal
    Public fechaInteres As DateTime
    Public fechaPrestamo As DateTime
    Public observaciones As String
    Public saldo As Decimal
    Public ultimoProceso As DateTime
    Public periodoInteres As String
    Public tipoInteres As String
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public estado As String

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        edoDocs = New EstadoDocumentos
    End Sub

    Private Sub creaDSDatos()
        rptDatos = New Reporte(Ambiente, "Prestamo", "ReportePrestamo")

        rptDatos.agregaVarible("idPrestamo", idPrestamo)
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

    Public Function getNombreEstado() As String
        Return edoDocs.getNombreEstado(estado)
    End Function

    Public Sub actualizarSaldo(cantidad As Decimal)
        saldo += cantidad
        actualizar()
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idPrestamo = rdr("idPrestamo")
        idSocioNegocio = If(IsDBNull(rdr("idSocioNegocio")), Nothing, rdr("idSocioNegocio"))
        idEmpleado = If(IsDBNull(rdr("idEmpleado")), Nothing, rdr("idEmpleado"))
        cantidad = rdr("cantidad")
        interesAnual = rdr("interesAnual")
        fechaInteres = rdr("fechaInteres")
        fechaPrestamo = rdr("fechaPrestamo")
        observaciones = rdr("observaciones")
        saldo = rdr("saldo")
        ultimoProceso = rdr("ultimoProceso")
        periodoInteres = rdr("periodoInteres")
        tipoInteres = rdr("tipoInteres")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        estado = rdr("estado")
    End Sub

    Public Sub cargaGrid(grid As DataGridView, obj As List(Of Prestamo))
        cargarGridGen(grid, "", obj)
    End Sub

    Public Function calculaIntereses()
        conex.numCon = 0

        conex.Qry = "EXEC spCalculaIntereses"

        If conex.ejecutaQry Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of Prestamo))
        Dim plantilla As Prestamo
        Dim dtb As New DataTable("Prestamo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Prestamo", Type.GetType("System.Int32"))
        dtb.Columns.Add("Socio / Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Cantidad", Type.GetType("System.String"))
        dtb.Columns.Add("Interes Anual", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Prestamo", Type.GetType("System.String"))
        dtb.Columns.Add("Saldo", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT P.*,(iif(P.idEmpleado is null,S.nombreSocio,concat(E.nombreEmpleado,' ',E.apPatEmpleado,' ',E.apMatEmpleado))) as nombreEmpSocio FROM Prestamo as P LEFT JOIN Empleado as E ON P.idEmpleado = E.idEmpleado LEFT JOIN SocioNegocio as S ON S.idSocioNegocio = P.idSocioNegocio  WHERE P.idEmpresa =  " & idEmpresa & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Prestamo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("ID Prestamo") = plantilla.idPrestamo
                row("Socio / Empleado") = conex.reader("nombreEmpSocio")
                row("Cantidad") = FormatCurrency(plantilla.cantidad)
                row("Interes Anual") = FormatNumber(plantilla.interesAnual)
                row("Fecha Prestamo") = FormatDateTime(plantilla.fechaPrestamo)
                row("Saldo") = FormatCurrency(plantilla.saldo)

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
        conex.tabla = "Prestamo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idPrestamo = " & idPrestamo

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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos

        If nuevo Then
            idEmpresa = Ambiente.empr.idEmpresa
            ultimoProceso = fechaInteres
            creadoPor = Ambiente.usuario.idEmpleado
            saldo = cantidad
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
            conex.tabla = "Prestamo"
            conex.accion = accion

            conex.agregaCampo("idSocioNegocio", idSocioNegocio, True, False)
            conex.agregaCampo("idEmpleado", idEmpleado, True, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("interesAnual", interesAnual, False, False)
            conex.agregaCampo("fechaInteres", fechaInteres, False, False)
            conex.agregaCampo("tipoInteres", tipoInteres, False, False)
            conex.agregaCampo("fechaPrestamo", fechaPrestamo, False, False)
            conex.agregaCampo("observaciones", observaciones, False, False)
            conex.agregaCampo("saldo", saldo, False, False)
            conex.agregaCampo("ultimoProceso", ultimoProceso, False, False)
            conex.agregaCampo("periodoInteres", periodoInteres, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("estado", estado, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idPrestamo = " & idPrestamo

            conex.armarQry()

            If conex.ejecutaQry Then
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
End Class
