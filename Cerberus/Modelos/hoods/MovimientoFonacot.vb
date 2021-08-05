Imports System.Data.SqlClient
Imports Cerberus

Public Class MovimientoFonacot
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idMovimientoFonacot As Integer
    Public numFonacot As String
    Public rfc As String
    Public nombre As String
    Public numCredito As Integer
    Public retencionMensual As Decimal
    Public claveEmp As Integer
    Public plazo As Integer
    Public cuotasPagadas As Integer
    Public retencionReal As Decimal
    Public incidencia As String
    Public fechaIncBaja As Date
    Public fechaFin As Date
    Public rehubicado As String
    Public ejercicio As Integer
    Public periodo As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idMovimientoFonacot = rdr("idMovimientoFonacot")
        numFonacot = rdr("numFonacot")
        rfc = rdr("rfc")
        nombre = rdr("nombre")
        numCredito = rdr("numCredito")
        retencionMensual = rdr("retencionMensual")
        claveEmp = rdr("claveEmp")
        plazo = rdr("plazo")
        cuotasPagadas = rdr("cuotasPagadas")
        retencionReal = rdr("retencionReal")
        incidencia = If(IsDBNull(rdr("incidencia")), Nothing, rdr("incidencia"))
        fechaIncBaja = If(IsDBNull(rdr("fechaIncBaja")), Nothing, rdr("fechaIncBaja"))
        fechaFin = If(IsDBNull(rdr("fechaFin")), Nothing, rdr("fechaFin"))
        rehubicado = If(IsDBNull(rdr("rehubicado")), Nothing, rdr("rehubicado"))
        ejercicio = rdr("ejercicio")
        periodo = rdr("periodo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = If(IsDBNull(rdr("idSucursal")), Nothing, rdr("idSucursal"))
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
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            idEmpresa = Ambiente.empr.idEmpresa
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
            conex.tabla = "MovimientoFonacot"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", "dbo.fnGetSucPeriodo((SELECT e.idEmpleado FROM Empleado as e where e.rfc = '" & rfc & "'  AND esActivo = 1 ), '" & ejercicio & "-" & periodo & "-01')", True, True)
            conex.agregaCampo("numFonacot", numFonacot, False, False)
            conex.agregaCampo("rfc", rfc, False, False)
            conex.agregaCampo("nombre", nombre, False, False)
            conex.agregaCampo("numCredito", numCredito, False, False)
            conex.agregaCampo("retencionMensual", retencionMensual, False, False)
            conex.agregaCampo("claveEmp", claveEmp, False, False)
            conex.agregaCampo("plazo", plazo, False, False)
            conex.agregaCampo("cuotasPagadas", cuotasPagadas, False, False)
            conex.agregaCampo("retencionReal", retencionReal, False, False)
            conex.agregaCampo("incidencia", incidencia, True, False)
            conex.agregaCampo("fechaIncBaja", fechaIncBaja, True, False)
            conex.agregaCampo("fechaFin", fechaFin, True, False)
            conex.agregaCampo("rehubicado", rehubicado, True, False)
            conex.agregaCampo("ejercicio", ejercicio, False, False)
            conex.agregaCampo("periodo", periodo, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            conex.condicion = "WHERE idMovimientoFonacot=" & idMovimientoFonacot

            conex.armarQry()
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    ObtenerID()
                End If
                Return True
            Else
                idError = conex.idError
                descripError = "MovimientoFonacot.ArmaQry: " & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function ObtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idMovimientoFonacot = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function ImportarExcel(archivo As String, hoja As String, rango As String, objColumnas As List(Of DetalleFormatoImportacion)) As Boolean
        Dim objExcel As New Excel(archivo, hoja, rango)
        Dim objData As DataSet
        objData = objExcel.leer()

        idError = 0
        descripError = ""

        Try
            For Each fila In objData.Tables(0).Rows 'Filas
                Dim numColumna As Integer
                Dim dato As Object
                Dim objTabla As MovimientoFonacot
                objTabla = New MovimientoFonacot(Ambiente)

                For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                    numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                    dato = fila.Item(numColumna)

                    If objColumnas.Item(i).tabla = "MovimientoFonacot" Then
                        Try
                            Select Case objColumnas.Item(i).columnaSQL
                                Case "idEmpresa"
                                    objTabla.idEmpresa = dato
                                Case "idSucursal"
                                    objTabla.idSucursal = dato
                                Case "numFonacot"
                                    objTabla.numFonacot = dato
                                Case "rfc"
                                    objTabla.rfc = dato
                                Case "nombre"
                                    objTabla.nombre = dato
                                Case "numCredito"
                                    objTabla.numCredito = dato
                                Case "retencionMensual"
                                    objTabla.retencionMensual = dato
                                Case "claveEmp"
                                    objTabla.claveEmp = dato
                                Case "plazo"
                                    objTabla.plazo = dato
                                Case "cuotasPagadas"
                                    objTabla.cuotasPagadas = dato
                                Case "retencionReal"
                                    objTabla.retencionReal = dato
                                Case "incidencia"
                                    objTabla.incidencia = dato
                                Case "fechaIncBaja"
                                    objTabla.fechaIncBaja = dato
                                Case "fechaFin"
                                    objTabla.fechaFin = dato
                                Case "rehubicado"
                                    objTabla.rehubicado = dato
                                Case "ejercicio"
                                    objTabla.ejercicio = dato
                                Case "periodo"
                                    objTabla.periodo = dato
                            End Select
                        Catch ex As Exception

                        End Try
                    End If
                Next

                If objTabla.idSucursal = Nothing Then
                    'Dim objEmpl As Empleado
                    'adad
                End If

                If Not objTabla.guardar() Then
                    idError = objTabla.idError
                    descripError &= "MovimientoFonacot.ImportarExcel().1: " & objTabla.descripError & vbCrLf
                End If
            Next
        Catch ex As Exception
            idError = ex.HResult
            descripError &= "MovimientoFonacot.ImportarExcel().2: " & ex.Message & vbCrLf
        End Try


        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub creaDSRep1()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte1")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)

    End Sub

    Private Sub creaDSRep2()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte2")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte1()
        creaDSRep1()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte1()
        creaDSRep1()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte2()
        creaDSRep2()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte2()
        creaDSRep2()
        rptDatos.imprimir(dsDatos)
    End Sub

    Private Sub creaDSRep3()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte3")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte3()
        creaDSRep3()
        rptDatos.imprimir(dsDatos)
    End Sub
    Public Sub RPT_ModificarReporte3()
        creaDSRep3()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep4()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte4")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte4()
        creaDSRep4()
        rptDatos.imprimir(dsDatos)
    End Sub
    Public Sub RPT_ModificarReporte4()
        creaDSRep4()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep5()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte5")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte5()
        creaDSRep5()
        rptDatos.imprimir(dsDatos)
    End Sub
    Public Sub RPT_ModificarReporte5()
        creaDSRep5()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep6()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte6")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte6()
        creaDSRep6()
        rptDatos.imprimir(dsDatos)
    End Sub
    Public Sub RPT_ModificarReporte6()
        creaDSRep6()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep7()
        rptDatos = New Reporte(Ambiente, "MovimientoFonacot", "Reporte7")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
    End Sub

    Public Sub RPT_ImprimirReporte7()
        creaDSRep7()
        rptDatos.imprimir(dsDatos)
    End Sub
    Public Sub RPT_ModificarReporte7()
        creaDSRep7()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub cargarGridGen(grid As DataGridView, obj As List(Of MovimientoFonacot), texto As String)
        Dim condicion As String
        texto = Replace(texto, "*", "%")

        condicion = " AND (nombre like '%" & texto & "%'"
        condicion &= " OR numFonacot like '%" & texto & "%'"
        condicion &= " OR S.nombreSucursal like '%" & texto & "%')"
        condicion = "WHERE ejercicio=" & ejercicio & " AND periodo=" & periodo & condicion

        cargarGridGen(grid, condicion, obj)
    End Sub


    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of MovimientoFonacot))
        Dim plantilla As MovimientoFonacot
        Dim dtb As New DataTable("MovimientoFonacot")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Num. Credito", Type.GetType("System.String"))
        dtb.Columns.Add("Plazo", Type.GetType("System.String"))
        dtb.Columns.Add("Cuotas Pagadas", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))


        obj.Clear()

        conex.Qry = "SELECT F.*,S.nombreSucursal FROM MovimientoFonacot as  F INNER JOIN Sucursal as S ON S.idSucursal = F.idSucursal " & condicion & " ORDER BY F.nombre"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New MovimientoFonacot(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Num. Credito") = plantilla.numCredito
                row("Nombre") = plantilla.nombre
                row("Plazo") = plantilla.plazo
                row("Cuotas Pagadas") = plantilla.cuotasPagadas
                row("Sucursal") = conex.reader("nombreSucursal")

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
            Mensaje.origen = "MovimientoFonacot.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
