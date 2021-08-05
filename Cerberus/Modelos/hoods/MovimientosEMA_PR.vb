Imports System.Data.SqlClient
Imports Cerberus

Public Class MovimientosEMA_PR
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idMovimientoEMA_PR As Integer
    Public idMovimientoEMA As Integer
    Public idEmpleado As Integer
    Public nEmpleado As String
    Public incapacidades As Integer
    Public diasSinIncapacidad As Integer
    Public salarioMinimo As Decimal
    Public tresVecesSM As Decimal
    Public E3VSMxI As Decimal
    Public CF As Decimal
    Public CFxI As Decimal
    Public ECFP As Decimal
    Public ECFxI As Decimal
    Public PDP As Decimal
    Public PDPxI As Decimal
    Public GMPP As Decimal
    Public GMPPxI As Decimal
    Public RT As Decimal
    Public RTxI As Decimal
    Public IVP As Decimal
    Public IVPxI As Decimal
    Public GPS As Decimal
    Public GPSxI As Decimal
    Public totalPatronal As Decimal
    Public EO As Decimal
    Public EOxI As Decimal
    Public PDO As Decimal
    Public PDOxI As Decimal
    Public GMPO As Decimal
    Public IVO As Decimal
    Public IVOxI As Decimal
    Public totalObrero As Decimal
    Public totalSys As Decimal
    Public nombreRegistro As String
    Public numRegistro As String
    Public idSucursal As Integer
    Public nombreSucursal As String
    Public semanas As Integer
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
        idMovimientoEMA_PR = rdr("idMovimientoEMA_PR")
        idMovimientoEMA = rdr("idMovimientoEMA")
        idEmpleado = If(IsDBNull(rdr("idEmpleado")), Nothing, rdr("idEmpleado"))
        nEmpleado = rdr("nEmpleado")
        incapacidades = rdr("incapacidades")
        diasSinIncapacidad = If(IsDBNull(rdr("diasSinIncapacidad")), Nothing, rdr("diasSinIncapacidad"))
        salarioMinimo = If(IsDBNull(rdr("salarioMinimo")), Nothing, rdr("salarioMinimo"))
        tresVecesSM = If(IsDBNull(rdr("tresVecesSM")), Nothing, rdr("tresVecesSM"))
        E3VSMxI = If(IsDBNull(rdr("E3VSMxI")), Nothing, rdr("E3VSMxI"))
        CF = If(IsDBNull(rdr("CF")), Nothing, rdr("CF"))
        CFxI = If(IsDBNull(rdr("CFxI")), Nothing, rdr("CFxI"))
        ECFP = If(IsDBNull(rdr("ECFP")), Nothing, rdr("ECFP"))
        ECFxI = If(IsDBNull(rdr("ECFxI")), Nothing, rdr("ECFxI"))
        PDP = If(IsDBNull(rdr("PDP")), Nothing, rdr("PDP"))
        PDPxI = If(IsDBNull(rdr("PDPxI")), Nothing, rdr("PDPxI"))
        GMPP = If(IsDBNull(rdr("GMPP")), Nothing, rdr("GMPP"))
        GMPPxI = If(IsDBNull(rdr("GMPPxI")), Nothing, rdr("GMPPxI"))
        RT = If(IsDBNull(rdr("RT")), Nothing, rdr("RT"))
        RTxI = If(IsDBNull(rdr("RTxI")), Nothing, rdr("RTxI"))
        IVP = If(IsDBNull(rdr("IVP")), Nothing, rdr("IVP"))
        IVPxI = If(IsDBNull(rdr("IVPxI")), Nothing, rdr("IVPxI"))
        GPS = If(IsDBNull(rdr("GPS")), Nothing, rdr("GPS"))
        GPSxI = If(IsDBNull(rdr("GPSxI")), Nothing, rdr("GPSxI"))
        totalPatronal = If(IsDBNull(rdr("totalPatronal")), Nothing, rdr("totalPatronal"))
        EO = If(IsDBNull(rdr("EO")), Nothing, rdr("EO"))
        EOxI = If(IsDBNull(rdr("EOxI")), Nothing, rdr("EOxI"))
        PDO = If(IsDBNull(rdr("PDO")), Nothing, rdr("PDO"))
        PDOxI = If(IsDBNull(rdr("PDOxI")), Nothing, rdr("PDOxI"))
        GMPO = If(IsDBNull(rdr("GMPO")), Nothing, rdr("GMPO"))
        IVO = If(IsDBNull(rdr("IVO")), Nothing, rdr("IVO"))
        IVOxI = If(IsDBNull(rdr("IVOxI")), Nothing, rdr("IVOxI"))
        totalObrero = If(IsDBNull(rdr("totalObrero")), Nothing, rdr("totalObrero"))
        totalSys = If(IsDBNull(rdr("totalSys")), Nothing, rdr("totalSys"))
        nombreRegistro = If(IsDBNull(rdr("nombreRegistro")), Nothing, rdr("nombreRegistro"))
        numRegistro = If(IsDBNull(rdr("numRegistro")), Nothing, rdr("numRegistro"))
        idSucursal = If(IsDBNull(rdr("idSucursal")), Nothing, rdr("idSucursal"))
        nombreSucursal = If(IsDBNull(rdr("nombreSucursal")), Nothing, rdr("nombreSucursal"))
        semanas = If(IsDBNull(rdr("semanas")), Nothing, rdr("semanas"))
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

    Public Function recalcular(fecha As Date) As Boolean
        conex.numCon = 0

        conex.Qry = "EXEC [dbo].[spExcelIMSS] '" & Format(fecha, "yyyy-MM-dd") & "',NULL," & idMovimientoEMA_PR & "," & diasSinIncapacidad

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

    End Function

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "MovimientosEMA_PR"
            conex.accion = accion

            conex.agregaCampo("idMovimientoEMA", idMovimientoEMA, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("nEmpleado", nEmpleado, False, False)
            conex.agregaCampo("incapacidades", incapacidades, False, False)
            conex.agregaCampo("diasSinIncapacidad", diasSinIncapacidad, False, False)
            conex.agregaCampo("salarioMinimo", salarioMinimo, False, False)
            conex.agregaCampo("tresVecesSM", tresVecesSM, False, False)
            conex.agregaCampo("E3VSMxI", E3VSMxI, False, False)
            conex.agregaCampo("CF", CF, False, False)
            conex.agregaCampo("CFxI", CFxI, False, False)
            conex.agregaCampo("ECFP", ECFP, False, False)
            conex.agregaCampo("ECFxI", ECFxI, False, False)
            conex.agregaCampo("PDP", PDP, False, False)
            conex.agregaCampo("PDPxI", PDPxI, False, False)
            conex.agregaCampo("GMPP", GMPP, False, False)
            conex.agregaCampo("GMPPxI", GMPPxI, False, False)
            conex.agregaCampo("RT", RT, False, False)
            conex.agregaCampo("RTxI", RTxI, False, False)
            conex.agregaCampo("IVP", IVP, False, False)
            conex.agregaCampo("IVPxI", IVPxI, False, False)
            conex.agregaCampo("GPS", GPS, False, False)
            conex.agregaCampo("GPSxI", GPSxI, False, False)
            conex.agregaCampo("totalPatronal", totalPatronal, False, False)
            conex.agregaCampo("EO", EO, False, False)
            conex.agregaCampo("EOxI", EOxI, False, False)
            conex.agregaCampo("PDO", PDO, False, False)
            conex.agregaCampo("PDOxI", PDOxI, False, False)
            conex.agregaCampo("GMPO", GMPO, False, False)
            conex.agregaCampo("IVO", IVO, False, False)
            conex.agregaCampo("IVOxI", IVOxI, False, False)
            conex.agregaCampo("totalObrero", totalObrero, False, False)
            conex.agregaCampo("totalSys", totalSys, False, False)
            conex.agregaCampo("nombreRegistro", nombreRegistro, False, False)
            conex.agregaCampo("numRegistro", numRegistro, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("nombreSucursal", nombreSucursal, False, False)
            conex.agregaCampo("semanas", semanas, False, False)

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idMovimientoEMA_PR = " & idMovimientoEMA_PR

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

    Public Sub cargarGridFiltro(grid As DataGridView, filtro As String, periodo As Integer, ejercicio As Integer, idRegPatronal As Integer, obj As List(Of MovimientosEMA_PR))
        Dim condicion As String

        condicion = "WHERE "
        condicion &= "("
        condicion &= "nEmpleado like '%" & filtro & "%' "
        condicion &= "OR nombreRegistro Like '%" & filtro & "%' "
        condicion &= "OR numRegistro like '%" & filtro & "%' "
        condicion &= "OR nombreSucursal like '%" & filtro & "%' "
        condicion &= ") "
        condicion &= "AND EMA.idMovimientoEMA IN (SELECT Ma.idMovimientoEMA FROM MovimientosEMA as MA where idRegistroPatronal = " & idRegPatronal & " and periodo = " & periodo & " and ejercicio = " & ejercicio & ")"


        cargarGridGen(grid, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of MovimientosEMA_PR))
        Dim plantilla As MovimientosEMA_PR
        Dim dtb As New DataTable("MovimientosEMA_PR")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Movimiento", Type.GetType("System.String"))
        dtb.Columns.Add("Dias IMSS", Type.GetType("System.String"))
        dtb.Columns.Add("Dias Sin Incapacidad", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))
        dtb.Columns.Add("Total Patronal", Type.GetType("System.String"))
        dtb.Columns.Add("Total Obrero", Type.GetType("System.String"))
        dtb.Columns.Add("Total IMSS", Type.GetType("System.String"))
        dtb.Columns.Add("Total Sistema", Type.GetType("System.String"))


        obj.Clear()

        conex.Qry = "SELECT PR.*,EMA.total as totalIMSS,tipoMovimiento,dias FROM MovimientosEMA_PR as PR INNER JOIN MovimientosEMA as EMA ON EMA.idMovimientoEMA = PR.idMovimientoEMA " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New MovimientosEMA_PR(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Empleado") = plantilla.nEmpleado
                row("Sucursal") = plantilla.nombreSucursal
                row("Dias Sin Incapacidad") = plantilla.diasSinIncapacidad
                row("Dias IMSS") = conex.reader("dias")
                row("Movimiento") = conex.reader("tipoMovimiento")
                row("Total Patronal") = FormatCurrency(plantilla.totalPatronal)
                row("Total Obrero") = FormatCurrency(plantilla.totalObrero)
                row("Total IMSS") = FormatCurrency(If(IsDBNull(conex.reader("totalIMSS")), Nothing, conex.reader("totalIMSS")))
                row("Total Sistema") = FormatCurrency(plantilla.totalSys)

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
            Mensaje.origen = "MovimientosEMA_PR.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idMovimientoEMA_PR = conex.reader("ID")
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

    Private Sub creaDSRep1(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEMA_PR", "Reporte1")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)

    End Sub

    Public Sub RPT_ImprimirReporte1(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep1(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte1(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep1(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep2(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEMA_PR", "Reporte2")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)

    End Sub

    Public Sub RPT_ImprimirReporte2(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep2(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte2(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep2(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep3(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEMA_PR", "Reporte3")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)

    End Sub

    Public Sub RPT_ImprimirReporte3(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep3(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte3(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep3(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRep4(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEMA_PR", "Reporte4")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)

    End Sub

    Public Sub RPT_ModificarReporte4(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep4(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte4(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep4(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

End Class
