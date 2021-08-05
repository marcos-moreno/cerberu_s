Imports System.Data.SqlClient
Imports Cerberus

Public Class RegistroPatronal
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idRegistroPatronal As Integer
    Public idEmpresa As Integer
    Public nombrePatron As String
    Public nombreRegistro As String
    Public numRegistro As String
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public rfc As String
    Public domicioFiscal As String

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Sub creaDSDatos()
        rptDatos = New Reporte(Ambiente, "RegistroPatronal", "ReporteRegPatronal")

        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub imprimeReporteRegistros()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificaReporteRegistros()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosTabuladores()
        rptDatos = New Reporte(Ambiente, "RegistroPatronal", "ReporteTabuladores")

        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub imprimeReporteTabuladores()
        creaDSDatosTabuladores()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificaReporteTabuladores()
        creaDSDatosTabuladores()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosSueldos()
        rptDatos = New Reporte(Ambiente, "RegistroPatronal", "ReporteSueldos")

        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub imprimeReporteSueldos()
        creaDSDatosSueldos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub modificaReporteSueldos()
        creaDSDatosSueldos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idRegistroPatronal = rdr("idRegistroPatronal")
        idEmpresa = rdr("idEmpresa")
        nombrePatron = rdr("nombrePatron")
        nombreRegistro = rdr("nombreRegistro")
        numRegistro = rdr("numRegistro")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        esActivo = rdr("esActivo")
        rfc = rdr("rfc")
        domicioFiscal = rdr("domicioFiscal")
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
            conex.tabla = "Periodo"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("nombrePatron", nombrePatron, False, False)
            conex.agregaCampo("nombreRegistro", nombreRegistro, False, False)
            conex.agregaCampo("numRegistro", numRegistro, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("rfc", rfc, False, False)
            conex.agregaCampo("domicioFiscal", domicioFiscal, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idRegistroPatronal = " & idRegistroPatronal

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

    'Clase especifica de Activos >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of RegistroPatronal))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 and idEmpresa = " & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    Public Function registroPatronalDefault() As Boolean
        conex.numCon = 0
        conex.tabla = "RegistroPatronal"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE idEmpresa=" & idEmpresa & " AND esActivo = 1 ORDER BY idRegistroPatronal ASC"

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of RegistroPatronal), filtro As String)
        Dim plantilla As RegistroPatronal
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM RegistroPatronal " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New RegistroPatronal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreRegistro & " (" & plantilla.numRegistro & ")")
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "RegistroPatronal.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
