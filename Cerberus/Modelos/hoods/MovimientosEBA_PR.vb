Imports System.Data.SqlClient
Imports Cerberus

Public Class MovimientosEBA_PR
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        Throw New NotImplementedException()
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

    Private Sub creaDSRep1(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEBA_PR", "Reporte1")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)
        rptDatos.agregaVarible("anio1", fechaProc.Year)
        rptDatos.agregaVarible("mes1", fechaProc.Month)
        rptDatos.agregaVarible("anio2", fechaProc.AddMonths(-1).Year)
        rptDatos.agregaVarible("mes2", fechaProc.AddMonths(-1).Month)

    End Sub

    Private Sub creaDSRep2(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEBA_PR", "Reporte2")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)
        rptDatos.agregaVarible("anio1", fechaProc.Year)
        rptDatos.agregaVarible("mes1", fechaProc.Month)
        rptDatos.agregaVarible("anio2", fechaProc.AddMonths(-1).Year)
        rptDatos.agregaVarible("mes2", fechaProc.AddMonths(-1).Month)

    End Sub

    Private Sub creaDSRep3(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEBA_PR", "Reporte3")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)
        rptDatos.agregaVarible("anio1", fechaProc.Year)
        rptDatos.agregaVarible("mes1", fechaProc.Month)
        rptDatos.agregaVarible("anio2", fechaProc.AddMonths(-1).Year)
        rptDatos.agregaVarible("mes2", fechaProc.AddMonths(-1).Month)

    End Sub

    Private Sub creaDSRep4(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEBA_PR", "Reporte4")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)
        rptDatos.agregaVarible("anio1", fechaProc.Year)
        rptDatos.agregaVarible("mes1", fechaProc.Month)
        rptDatos.agregaVarible("anio2", fechaProc.AddMonths(-1).Year)
        rptDatos.agregaVarible("mes2", fechaProc.AddMonths(-1).Month)

    End Sub

    Private Sub creaDSRep5(fechaProc As Date, idRegPatronal As Integer)
        rptDatos = New Reporte(Ambiente, "MovimientosEBA_PR", "Reporte5")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("fechaProc", fechaProc, GetType(DateTime))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idRegPatronal", idRegPatronal)
        rptDatos.agregaVarible("anio1", fechaProc.Year)
        rptDatos.agregaVarible("mes1", fechaProc.Month)
        rptDatos.agregaVarible("anio2", fechaProc.AddMonths(-1).Year)
        rptDatos.agregaVarible("mes2", fechaProc.AddMonths(-1).Month)

    End Sub

    Public Sub RPT_ImprimirReporte1(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep1(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte1(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep1(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte2(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep2(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte2(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep2(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte3(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep3(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte3(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep3(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte4(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep4(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte4(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep4(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirReporte5(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep5(fechaProc, idRegPatronal)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte5(fechaProc As Date, idRegPatronal As Integer)
        creaDSRep5(fechaProc, idRegPatronal)
        rptDatos.modificar(dsDatos)
    End Sub
End Class
