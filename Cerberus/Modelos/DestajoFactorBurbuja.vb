Imports System.Data.SqlClient
Imports Cerberus

Public Class DestajoFactorBurbuja
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idDestajoFactorBurbuja As Integer
    Public nombreFactor As String
    Public minBurbujas As Integer
    Public maxBurbujas As Integer
    Public porcentajeFactor As Decimal
    Public idEtapa As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of DestajoFactorBurbuja))
        Dim filtro As String
        filtro = "WHERE idEmpresa = " & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of DestajoFactorBurbuja), filtro As String)
        Dim plantilla As DestajoFactorBurbuja
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM DestajoFactorBurbuja " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoFactorBurbuja(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreFactor)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DestajoFactorBurbuja.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of DestajoFactorBurbuja))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of DestajoFactorBurbuja))
        Dim plantilla As DestajoFactorBurbuja
        Dim dtb As New DataTable("DestajoFactorBurbuja")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Factor", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Factor", Type.GetType("System.String"))
        dtb.Columns.Add("Porcentaje Factor", Type.GetType("System.Decimal"))

        objEmp.Clear()

        conex.Qry = "SELECT D.* FROM DestajoFactorBurbuja as D WHERE D.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoFactorBurbuja(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Factor") = plantilla.idDestajoFactorBurbuja
                row("Nombre Factor") = plantilla.nombreFactor
                row("Porcentaje Factor") = plantilla.porcentajeFactor

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
            Mensaje.origen = "DestajoFactorBurbuja.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "DestajoFactorBurbuja"
            conex.accion = accion

            conex.agregaCampo("nombreFactor", nombreFactor, False, False)
            conex.agregaCampo("minBurbujas", minBurbujas, False, False)
            conex.agregaCampo("maxBurbujas", maxBurbujas, False, False)
            conex.agregaCampo("porcentajeFactor", porcentajeFactor, False, False)
            conex.agregaCampo("idEtapa", idEtapa, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDestajoFactorBurbuja = " & idDestajoFactorBurbuja

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDestajoFactorBurbuja = rdr("idDestajoFactorBurbuja")
        nombreFactor = rdr("nombreFactor")
        minBurbujas = rdr("minBurbujas")
        maxBurbujas = rdr("maxBurbujas")
        porcentajeFactor = rdr("porcentajeFactor")
        idEtapa = rdr("idEtapa")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
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
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "DestajoFactorBurbuja"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idDestajoFactorBurbuja=" & idDestajoFactorBurbuja

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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idDestajoFactorBurbuja & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If nombreFactor = Nothing Then
            idError = 1
            descripError = "El nombre del factor es un CAMPO obligatorio..."
            Return False
        End If
        If minBurbujas = Nothing Then
            idError = 2
            descripError = "El mínimo de burbujas es un CAMPO obligatorio..."
            Return False
        End If
        If maxBurbujas = Nothing Then
            idError = 3
            descripError = "El máximo de burbujas es un CAMPO obligatorio..."
            Return False
        End If
        If porcentajeFactor = Nothing Then
            idError = 4
            descripError = "El porcentaje del factor es un CAMPO obligatorio..."
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
