Public Class EstadoCuenta
    'PRIVADAS
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Sub creaDSDatosEdoCuenta(periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "rptEdoCuentaEmpleado")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        'conex.numCon = 0
        'conex.Qry = "EXEC spEstadoCuenta '" & Format(periodo.inicioPeriodo, "yyyy-MM-dd") & "','" & Format(periodo.finPeriodo, "yyyy-MM-dd") & "'," & Ambiente.empr.idEmpresa & "," & idBusqueda & "," & idDep

        rptDatos.agregaVarible("vFechaInicial", periodo.inicioPeriodo, GetType(System.DateTime))
        rptDatos.agregaVarible("vFechaFinal", periodo.finPeriodo, GetType(System.DateTime))
        rptDatos.agregaVarible("vIdEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("vIdEmpleado", idBusqueda)
        rptDatos.agregaVarible("vIdDep", idDep)

        rptDatos.agregaVarible("InicioPerido", Format(periodo.inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(periodo.finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", periodo.nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", periodo.numeroPeriodo)
        rptDatos.agregaVarible("ejercicioPeriodo", periodo.ejercicio)

        'dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Private Sub creaDSDatosSolicitudEfec(periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "rptSolicitudEfecEmpleado")
        dsDatos = New DataSet

        conex.numCon = 0
        'conex.Qry = "EXEC [spEdoCuentaSolicitudEfec] '" & Format(periodo.inicioPeriodo, "yyyy-MM-dd") & "','" & Format(periodo.finPeriodo, "yyyy-MM-dd") & "'," & Ambiente.empr.idEmpresa & "," & idDep & ""

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        rptDatos.agregaVarible("InicioPerido", Format(periodo.inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(periodo.finPeriodo, "dd MMMM yyyy"))

        rptDatos.agregaVarible("fechaInicio", Format(periodo.inicioPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("fechaFin", Format(periodo.finPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
        rptDatos.agregaVarible("idDep", idDep, GetType(Integer))

        rptDatos.agregaVarible("nombrePeriodo", periodo.nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", periodo.numeroPeriodo)
        rptDatos.agregaVarible("ejercicioPeriodo", periodo.ejercicio)

        'dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Private Sub creaDSDatosConcentradosEntrega(periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "rptConcentEntregaEmpleado")
        dsDatos = New DataSet

        conex.numCon = 0

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        'conex.Qry = "EXEC [spEdoCuentaConcentrados] '" & Format(periodo.inicioPeriodo, "yyyy-MM-dd") & "','" & Format(periodo.finPeriodo, "yyyy-MM-dd") & "'," & Ambiente.empr.idEmpresa & "," & idDep & ""


        rptDatos.agregaVarible("fechaInicio", Format(periodo.inicioPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("fechaFin", Format(periodo.finPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
        rptDatos.agregaVarible("idDep", idDep, GetType(Integer))
        rptDatos.agregaVarible("idBusqueda", idBusqueda, GetType(Integer))

        rptDatos.agregaVarible("InicioPerido", Format(periodo.inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(periodo.finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", periodo.nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", periodo.numeroPeriodo)
        rptDatos.agregaVarible("ejercicioPeriodo", periodo.ejercicio)

        'dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Private Sub creaDSDatosSobres(periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "rptSobresEmpleado")
        dsDatos = New DataSet

        conex.numCon = 0

        'conex.Qry = "EXEC [spEdoCuentaSolicitudEfec] '" & Format(periodo.inicioPeriodo, "yyyy-MM-dd") & "','" & Format(periodo.finPeriodo, "yyyy-MM-dd") & "'," & Ambiente.empr.idEmpresa & "," & idDep & ",1"
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)


        rptDatos.agregaVarible("fechaInicio", Format(periodo.inicioPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("fechaFin", Format(periodo.finPeriodo, "yyyy-MM-dd"), GetType(Date))
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
        rptDatos.agregaVarible("idDep", idDep, GetType(Integer))
        rptDatos.agregaVarible("idBusqueda", idBusqueda, GetType(Integer))

        rptDatos.agregaVarible("InicioPerido", Format(periodo.inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(periodo.finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", periodo.nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", periodo.numeroPeriodo)
        rptDatos.agregaVarible("ejercicioPeriodo", periodo.ejercicio)

        'dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Private Sub creaDSPagoExc(Periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "pagoExedentes")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        rptDatos.agregaVarible("ejercicioPeriodo", Periodo.ejercicio)
        rptDatos.agregaVaribleRU("fechaInicial", Periodo.inicioPeriodo, GetType(Date))
        rptDatos.agregaVaribleRU("fechaFinal", Periodo.finPeriodo, GetType(Date))
        rptDatos.agregaVarible("idDep", idDep)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("nombrePeriodo", Periodo.nombrePeriodo)
    End Sub

    Private Sub creaDSPercepcionesPeriodo(Periodo As Periodo)
        rptDatos = New Reporte(Ambiente, "Cuenta", "percepcionesXPeriodo")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        rptDatos.agregaVarible("ejercicioPeriodo", Periodo.ejercicio)
        rptDatos.agregaVarible("fechaFinal", Periodo.finPeriodo, GetType(Date))
        rptDatos.agregaVarible("fechaInicial", Periodo.inicioPeriodo, GetType(Date))
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("nombrePeriodo", Periodo.nombrePeriodo)
    End Sub

    Private Sub creaDSTotalGeneral(Periodo As Periodo, idBusqueda As Integer, idDep As Integer)
        rptDatos = New Reporte(Ambiente, "Cuenta", "totalGen")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        rptDatos.agregaVarible("ejercicioPeriodo", Periodo.ejercicio)
        rptDatos.agregaVarible("fechaFinal", Periodo.finPeriodo)
        rptDatos.agregaVarible("fechaInicial", Periodo.inicioPeriodo)
        rptDatos.agregaVarible("idDep", idDep)
        rptDatos.agregaVarible("idEmpresa", 0)
        rptDatos.agregaVarible("nombrePeriodo", Periodo.nombrePeriodo)
    End Sub


    Public Sub RPT_ImprimirDatos(periodo As Periodo, idBusqueda As Integer, idDep As Integer, tipoRep As Integer)
        If tipoRep = TipoReporteEdoCuenta.ConcentradosEntrega Then
            creaDSDatosConcentradosEntrega(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.EstadosCuenta Then
            creaDSDatosEdoCuenta(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.Sobres Then
            creaDSDatosSobres(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.SolicitudEfectivo Then
            creaDSDatosSolicitudEfec(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.TotalGeneral Then
            creaDSTotalGeneral(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.PagoExcedentes Then
            creaDSPagoExc(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.PercepcionesPeriodo Then
            creaDSPercepcionesPeriodo(periodo)
        End If

        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatos(periodo As Periodo, idBusqueda As Integer, idDep As Integer, tipoRep As Integer)
        If tipoRep = TipoReporteEdoCuenta.ConcentradosEntrega Then
            creaDSDatosConcentradosEntrega(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.EstadosCuenta Then
            creaDSDatosEdoCuenta(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.Sobres Then
            creaDSDatosSobres(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.SolicitudEfectivo Then
            creaDSDatosSolicitudEfec(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.TotalGeneral Then
            creaDSTotalGeneral(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.PagoExcedentes Then
            creaDSPagoExc(periodo, idBusqueda, idDep)
        ElseIf tipoRep = TipoReporteEdoCuenta.PercepcionesPeriodo Then
            creaDSPercepcionesPeriodo(periodo)
        End If

        rptDatos.modificar(dsDatos)
    End Sub
End Class
