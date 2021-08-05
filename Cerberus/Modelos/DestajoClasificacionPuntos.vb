Imports System.Data.SqlClient
Imports Cerberus

Public Class DestajoClasificacionPuntos
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idError As Integer
    Public descripError As String

    Public idDestajoClasificacionPuntos As Integer
    Public nombreClasificacion As String
    Public numPuntos As Integer
    Public montoPagoClasificacion As Decimal
    Public idEtapa As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public esActivo As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of DestajoClasificacionPuntos))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 and idEmpresa = " & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of DestajoClasificacionPuntos), filtro As String)
        Dim plantilla As DestajoClasificacionPuntos
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM DestajoClasificacionPuntos " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoClasificacionPuntos(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreClasificacion)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DestajoClasificacionPuntos.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of DestajoClasificacionPuntos))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of DestajoClasificacionPuntos))
        Dim plantilla As DestajoClasificacionPuntos
        Dim dtb As New DataTable("DestajoClasificacionPuntos")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Clasificacion", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Clasificacion", Type.GetType("System.String"))
        dtb.Columns.Add("Monto de Pago", Type.GetType("System.Decimal"))
        dtb.Columns.Add("Activo", Type.GetType("System.Boolean"))

        objEmp.Clear()

        conex.Qry = "SELECT D.* FROM DestajoClasificacionPuntos as D"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoClasificacionPuntos(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Clasificacion") = plantilla.idDestajoClasificacionPuntos
                row("Nombre Clasificacion") = plantilla.nombreClasificacion
                row("Monto de Pago") = plantilla.montoPagoClasificacion
                row("Activo") = plantilla.esActivo

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
            Mensaje.origen = "DestajoClasificacionPuntos.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "DestajoClasificacionPuntos"
            conex.accion = accion

            conex.agregaCampo("nombreClasificacion", nombreClasificacion, False, False)
            conex.agregaCampo("numPuntos", numPuntos, False, False)
            conex.agregaCampo("montoPagoClasificacion", montoPagoClasificacion, False, False)
            conex.agregaCampo("idEtapa", idEtapa, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDestajoClasificacionPuntos = " & idDestajoClasificacionPuntos

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
        idDestajoClasificacionPuntos = rdr("idDestajoClasificacionPuntos")
        nombreClasificacion = rdr("nombreClasificacion")
        numPuntos = rdr("numPuntos")
        montoPagoClasificacion = rdr("montoPagoClasificacion")
        idEtapa = rdr("idEtapa")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        esActivo = rdr("esActivo")
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
        conex.tabla = "DestajoClasificacionPuntos"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idDestajoClasificacionPuntos=" & idDestajoClasificacionPuntos

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
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If nombreClasificacion = Nothing Then
            idError = 1
            descripError = "El nombre es un CAMPO obligatorio..."
            Return False
        End If
        If numPuntos = Nothing Then
            idError = 2
            descripError = "El número de puntos es un CAMPO obligatorio..."
            Return False
        End If
        If montoPagoClasificacion = Nothing Then
            idError = 3
            descripError = "El monto del pago es un CAMPO obligatorio..."
            Return False
        End If
        If idEtapa = Nothing Then
            idError = 4
            descripError = "La etapa es un CAMPO obligatorio..."
            Return False
        End If
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
End Class
