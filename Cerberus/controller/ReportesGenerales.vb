Imports Stimulsoft.Report.Dictionary

Public Class ReportesGenerales

    Private Ambiente As AmbienteCls
    Private rptDatos As Reporte
    Private dsDatos As DataSet
    Public idError As Integer
    Public descripError As String
    Private list_variables As StiVariablesCollection
    Private list_variables_valores As StiVariablesCollection

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        list_variables = New StiVariablesCollection
        list_variables_valores = New StiVariablesCollection
    End Sub



    'Reporte Telefonia General
    Public Sub RPT_TelefoniaGen(modificar As Boolean)
        creaDSReport("Telefonia", "rptTelefoniaGeneral")
        list_variables.Add("idEmpresa")
        list_variables_valores.Add(CStr(Ambiente.empr.idEmpresa))
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub

    Private Sub creaDSReport(tabla As String, elementoSistema As String)
        '  rptDatos = New Reporte(Ambiente, "Credenciales", "empleado")
        rptDatos = New Reporte(Ambiente, tabla, elementoSistema)
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        For i As Integer = 0 To list_variables.Count - 1
            rptDatos.agregaVarible(list_variables.Item(i), list_variables_valores.Item(i))
        Next
    End Sub
    'End Reporte Telefonia General


    'Reporte RPT_Cheques_Finiquito
    Public Sub RPT_Cheques_Finiquito(modificar As Boolean)
        list_variables.Add("idEmpresa")
        list_variables_valores.Add(CStr(Ambiente.empr.idEmpresa))
        creaDSReport("Cheques_Finiquito", "rptCheques_Finiquito")
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_Cheques_Finiquito


    'Reporte RPT_poliza_Nomina_extraordinario
    Public Sub RPT_EmpleEmpreSuc(modificar As Boolean)
        creaDSReport("RPT_EmpleEmpreSuc", "RPT_EmpleEmpreSuc")
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_poliza_Nomina_extraordinario

    'Reporte RPT_
    Public Sub RPT_poliza_Nomina_extraordinario(modificar As Boolean)
        creaDSReport("poliza_Nom_extraor", "RPT_poliza_Nom_extraor")
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_poliza_Nomina_extraordinario


    'Reporte RPT_poliza_3p_extraordinario
    Public Sub RPT_3p_extraordinario(modificar As Boolean)
        creaDSReport("3p_extraordinario", "RPT_3p_extraordinario")
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_poliza_3p_extraordinario


    'Reporte RPT_Cheques_Finiquito
    Public Sub RPT_RenovacionContrato(modificar As Boolean)
        creaDSReport("Renovacion", "rptRevisarRenovacion")
        list_variables.Add("idEmpresa")
        list_variables_valores.Add(CStr(Ambiente.empr.idEmpresa))
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_Cheques_Finiquito


    'Reporte RPT_CardexHrsExtra
    Public Sub RPT_CardexHrsExtra(modificar As Boolean, idDepa As Integer, filter As String)
        creaDSReport("ControlHorasExtra", "RPT_CardexHrsExtra")
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("idUser", Ambiente.usuario.idEmpleado)
        rptDatos.agregaVarible("idDepa", idDepa)
        rptDatos.agregaVarible("filter", filter)
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_CardexHrsExtra


    'Reporte RPT_frmatPeriso
    Public Sub RPT_frmatPeriso(modificar As Boolean, idSolicitudPermiso As Integer)
        creaDSReport("Renovacion", "RPT_frmat_Periso")
        'list_variables_valores.Add(CStr(idSolicitudPermiso))
        rptDatos.agregaVarible("idSolicitudPermiso", idSolicitudPermiso)
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End Reporte RPT_frmatPeriso 
    '
    Friend Sub RPT_TiempoExtra(modificar As Boolean, nmeReport As String)
        rptDatos = New Reporte(Ambiente, "periodo", nmeReport)
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub

    'Reporte RPT_frmatPerisoEmpleado FRM viejo
    Public Sub RPT_frmatPerisoEmpleado(modificar As Boolean, idEmpleado As Integer, inicioPeriodo As Date, finPeriodo As Date)
        rptDatos = New Reporte(Ambiente, "Periodo", "IncidenciasEmplado")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpleado", idEmpleado)
        rptDatos.agregaVarible("VInicioPeriodo", inicioPeriodo)
        rptDatos.agregaVarible("VFinPeriodo", finPeriodo)
        If modificar Then
            rptDatos.modificar(dsDatos)
        Else
            rptDatos.imprimir(dsDatos)
        End If
    End Sub
    'End RPT_frmatPerisoEmpleado FRM viejo
End Class
