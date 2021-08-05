Imports System.Data.SqlClient
Imports Cerberus

Public Class Empresa
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    'VARIABLES
    Public idEmpresa As Integer
    Public nombreEmpresa As String
    Public rfcEmpresa As String
    Public razonSocial As String
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public tiempoXTiempo As Boolean

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public idError As Integer
    Public descripError As String

    Sub New(amb As AmbienteCls)
        Ambiente = amb
        conex = amb.conex
    End Sub

    'Clase especifica de Empresa x Empleado >>>
    Public Sub getComboXEmplado(combo As ComboBox, idCombos As List(Of Empresa), idEmpleado As Integer)
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa in (select idAcceso from dbo.fnGetIDsAcceso(" & idEmpleado & ",'Empresa'))"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Clase especifica de Empresas Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Empresa))
        Dim filtro As String
        filtro = "WHERE esActivo = 1"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Empresa), filtro As String)
        Dim plantilla As Empresa
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Empresa " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Empresa(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreEmpresa)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Empresa.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.Qry = "SELECT * FROM Empresa WHERE idEmpresa = " & idEmpresa
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID Buscado..."
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        'VARIABLES
        idEmpresa = rdr("idEmpresa")
        nombreEmpresa = rdr("nombreEmpresa")
        rfcEmpresa = rdr("rfcEmpresa")
        razonSocial = rdr("razonSocial")
        esActivo = rdr("esActivo")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        tiempoXTiempo = rdr("tiempoXTiempo")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", True)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        Return True
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Empresa"
            conex.accion = accion

            conex.agregaCampo("nombreEmpresa", nombreEmpresa, False, False)
            conex.agregaCampo("rfcEmpresa", rfcEmpresa, False, False)
            conex.agregaCampo("razonSocial", razonSocial, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("tiempoXTiempo", tiempoXTiempo, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEmpresa = " & idEmpresa

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

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idEmpresa = conex.reader("ID")
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

    Private Sub creaDSConfig()
        rptDatos = New Reporte(Ambiente, "Empresa", "ConfigGenerales")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
        rptDatos.agregaVarible("nombreEmpresa", Ambiente.empr.nombreEmpresa)
    End Sub

    Public Sub RPT_ImprimirConfiguraciones()
        creaDSConfig()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarConfiguraciones()
        creaDSConfig()
        rptDatos.modificar(dsDatos)
    End Sub

End Class
