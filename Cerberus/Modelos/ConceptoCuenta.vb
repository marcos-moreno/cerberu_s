Imports System.Data.SqlClient
Imports Cerberus

Public Class ConceptoCuenta
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idConceptoCuenta As Integer
    Public nombreConceptoCuenta As String
    Public tipoCuenta As String
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public esReservado As Boolean
    Public esPagoDeExcedentes As Boolean

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ConceptoCuenta"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("nombreConceptoCuenta", nombreConceptoCuenta, False, False)
            conex.agregaCampo("tipoCuenta", tipoCuenta, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("esReservado", esReservado, False, False)
            conex.agregaCampo("esPagoDeExcedentes", esPagoDeExcedentes, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idConceptoCuenta = " & idConceptoCuenta

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

    Public Sub getComboActivoXTipo(combo As ComboBox, idCombos As List(Of ConceptoCuenta))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa=" & idEmpresa & " AND tipoCuenta ='" & tipoCuenta & "'"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of ConceptoCuenta), filtro As String)
        Dim plantilla As ConceptoCuenta
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM ConceptoCuenta " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ConceptoCuenta(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreConceptoCuenta)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "ConceptoCuenta.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of ConceptoCuenta))
        Dim plantilla As ConceptoCuenta
        Dim dtb As New DataTable("ConceptoCuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Cuenta", Type.GetType("System.Int32"))
        dtb.Columns.Add("Concepto Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo Cuenta", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT CC.* FROM ConceptoCuenta AS CC WHERE CC.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ConceptoCuenta(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Cuenta") = plantilla.idConceptoCuenta
                row("Concepto Cuenta") = plantilla.nombreConceptoCuenta
                row("Tipo Cuenta") = plantilla.tipoCuenta

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
            Mensaje.origen = "ConceptoCuenta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of ConceptoCuenta), busqueda As String)
        Dim condicion As String
        condicion = ""

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace("*", "%")
            condicion = " AND (CC.nombreConceptoCuenta like '%" & busqueda & "%' "
            condicion &= "OR CC.tipoCuenta like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Public Sub cargaGridSistema(dgvDepartamento As DataGridView, obj As List(Of ConceptoCuenta), busqueda As String, pagoExecentes As Boolean)
        Dim condicion As String
        condicion = ""

        condicion = " AND esReservado = 1 AND tipoCuenta='" & tipoCuenta & "'"

        If pagoExecentes Then
            condicion &= " AND esPagoDeExcedentes = 1"
        Else
            condicion &= " AND esPagoDeExcedentes = 0"
        End If

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace(" * ", "%")
            condicion &= " And (CC.nombreConceptoCuenta Like '%" & busqueda & "%' "
            condicion &= "OR CC.tipoCuenta like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub


    Public Sub cargaGridSinSistema(dgvDepartamento As DataGridView, obj As List(Of ConceptoCuenta), busqueda As String)
        Dim condicion As String
        condicion = ""

        condicion = " AND esReservado = 0 AND esPagoDeExcedentes = 0 AND tipoCuenta='" & tipoCuenta & "'"

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace("*", "%")
            condicion &= " AND (CC.nombreConceptoCuenta like '%" & busqueda & "%' "
            condicion &= "OR CC.tipoCuenta like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idConceptoCuenta = rdr("idConceptoCuenta")
        nombreConceptoCuenta = rdr("nombreConceptoCuenta")
        tipoCuenta = rdr("tipoCuenta")
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        esReservado = rdr("esReservado")
        esPagoDeExcedentes = rdr("esPagoDeExcedentes")
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
        conex.tabla = "ConceptoCuenta"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idConceptoCuenta=" & idConceptoCuenta

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            Else
                conex.reader.Close()
                Return False
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function


    Public Function buscarPISucursal(tipo As String) As Boolean
        conex.numCon = 0
        conex.tabla = "ConceptoCuenta"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreConceptoCuenta = '" & tipo & "'
                            AND idEmpresa =" & idEmpresa
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            Else
                conex.reader.Close()
                Return False
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function


    Public Function buscarPTipo() As Boolean
        conex.numCon = 0
        conex.tabla = "ConceptoCuenta"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreConceptoCuenta='" & nombreConceptoCuenta & "' AND idEmpresa=" & idEmpresa
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            Else
                conex.reader.Close()
                Return False
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function
    Private Function validaExcedentes() As Boolean
        conex.numCon = 0
        conex.tabla = "ConceptoCuenta"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idEmpresa=" & idEmpresa & " AND esPagoDeExcedentes=1 AND idConceptoCuenta<>" & idConceptoCuenta
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                conex.reader.Close()
                idError = 3
                descripError = "Ya existe un concepto asociado a excedentes"
                Return False
            Else
                conex.reader.Close()
                Return True
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idConceptoCuenta & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If esPagoDeExcedentes Then
            If Not validaExcedentes() Then
                Return False
            End If
        End If
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If idEmpresa = Nothing Then
            idEmpresa = Ambiente.empr.idEmpresa
        End If
        If idSucursal = Nothing Then
            idSucursal = Ambiente.suc.idSucursal
        End If
        If nombreConceptoCuenta = Nothing Then
            idError = 1
            descripError = "El concepto de la cuenta es un CAMPO obligatorio..."
            Return False
        End If
        If tipoCuenta = Nothing Then
            idError = 2
            descripError = "El tipo de cuenta es un CAMPO obligatorio..."
            Return False
        End If
        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        If objCreadoPor Is Nothing Then
            objCreadoPor = New Empleado(Ambiente)
            objCreadoPor.idEmpleado = creadoPor
            objCreadoPor.buscarPID()
        End If
        Return objCreadoPor
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        If objActualizadoPor Is Nothing Then
            objActualizadoPor = New Empleado(Ambiente)
            objActualizadoPor.idEmpleado = actualizadoPor
            objActualizadoPor.buscarPID()

        End If
        Return objActualizadoPor
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function
End Class
