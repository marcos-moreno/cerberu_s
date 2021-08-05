Imports System.Data.SqlClient
Imports Cerberus

Public Class Cocina
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idCocina As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public nombreCocina As String
    Public costoComida As Integer
    Public descuentoXColaborador As Decimal
    Public sancion As Decimal
    Public observaciones As String
    Public telefono As String
    Public correo As String
    Public contacto As String
    Public ubicacionGeografica As String
    Public esGeneral As Boolean

    Public idError As Integer
    Public descripError As String

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Sub creaDSEmplXCocina()
        rptDatos = New Reporte(Ambiente, "Cocina", "EmpleXCocina")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ModificarEmplXCocina()
        creaDSEmplXCocina()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirEmplXCocina()
        creaDSEmplXCocina()
        rptDatos.imprimir(dsDatos)
    End Sub

    Private Sub creaDSAsigCocina()
        rptDatos = New Reporte(Ambiente, "Cocina", "AsignacionCocina")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ModificarAsigCocina()
        creaDSAsigCocina()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirAsigCocina()
        creaDSAsigCocina()
        rptDatos.imprimir(dsDatos)
    End Sub

    'Clase especifica de Cocina Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Cocina))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 and (idEmpresa=" & idEmpresa & " OR esGeneral=1)"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Cocina), filtro As String)
        Dim plantilla As Cocina
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Cocina " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Cocina(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreCocina)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Cocina.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Cocina))
        cargarGridGen(dgv, "", obj)
    End Sub


    Public Sub cargaGridXParam(dgv As DataGridView, obj As List(Of Cocina), params As String, soloActivos As Boolean)
        Dim condicion As String = ""

        If soloActivos Then
            condicion = " AND esActivo = 1"
        End If

        If params <> Nothing Then
            params = params.Replace("*", "%")

            condicion &= " AND ("
            condicion &= " idCocina like '%" & params & "%'"
            condicion &= " OR nombreCocina like '%" & params & "%'"
            condicion &= " OR costoComida like '%" & params & "%'"
            condicion &= " OR telefono like '%" & params & "%'"
            condicion &= " OR correo like '%" & params & "%'"
            condicion &= " OR contacto like '%" & params & "%'"
            condicion &= ")"
        End If

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Cocina))
        Dim plantilla As Cocina
        Dim dtb As New DataTable("Cocina")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Cocina", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Cocina", Type.GetType("System.String"))
        dtb.Columns.Add("Costo x Comida", Type.GetType("System.Decimal"))
        dtb.Columns.Add("Telefono", Type.GetType("System.String"))
        dtb.Columns.Add("Correo", Type.GetType("System.String"))
        dtb.Columns.Add("Contacto", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT c.* FROM Cocina AS c WHERE (c.idEmpresa = " & idEmpresa & " OR esGeneral=1 ) " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Cocina(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Cocina") = plantilla.idCocina
                row("Nombre Cocina") = plantilla.nombreCocina
                row("Costo x Comida") = plantilla.costoComida
                row("Telefono") = plantilla.telefono
                row("Correo") = plantilla.correo
                row("Contacto") = plantilla.contacto

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
            Mensaje.origen = "Cocina.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idCocina = conex.reader("ID")
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

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Cocina"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("nombreCocina", nombreCocina, False, False)
            conex.agregaCampo("costoComida", costoComida, False, False)
            conex.agregaCampo("descuentoXColaborador", descuentoXColaborador, False, False)
            conex.agregaCampo("sancion", sancion, False, False)
            conex.agregaCampo("observaciones", observaciones, False, False)
            conex.agregaCampo("telefono", telefono, False, False)
            conex.agregaCampo("correo", correo, False, False)
            conex.agregaCampo("contacto", contacto, False, False)
            conex.agregaCampo("ubicacionGeografica", ubicacionGeografica, False, False)
            conex.agregaCampo("esGeneral", esGeneral, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCocina = " & idCocina

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCocina = rdr("idCocina")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        esActivo = rdr("esActivo")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        nombreCocina = rdr("nombreCocina")
        costoComida = rdr("costoComida")
        descuentoXColaborador = rdr("descuentoXColaborador")
        sancion = rdr("sancion")
        observaciones = rdr("observaciones")
        telefono = rdr("telefono")
        correo = rdr("correo")
        contacto = rdr("contacto")
        ubicacionGeografica = rdr("ubicacionGeografica")
        esGeneral = rdr("esGeneral")
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
        conex.tabla = "Cocina"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idCocina=" & idCocina

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

    Public Function cocinaDefault() As Boolean
        conex.numCon = 0
        conex.tabla = "Cocina"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE esActivo = 1 AND (idEmpresa = " & idEmpresa & " OR esGeneral = 1) ORDER BY idCocina ASC"

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
        Return "ID: " & idCocina & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If nuevo Then
            If actualizadoPor = Nothing Then
                actualizadoPor = Ambiente.usuario.idEmpleado
            End If
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If nombreCocina = Nothing Then
            idError = 1
            descripError = "El nombre de la cocina es un CAMPO obligatorio..."
            Return False
        End If
        If costoComida = Nothing Then
            idError = 1
            descripError = "El costo de la comida es un CAMPO obligatorio..."
            Return False
        End If
        If descuentoXColaborador = Nothing Then
            idError = 1
            descripError = "El descuento por colaborador es un CAMPO obligatorio..."
            Return False
        End If
        If sancion = Nothing Then
            idError = 1
            descripError = "La sancion es un CAMPO obligatorio..."
            Return False
        End If
        If observaciones = Nothing Then
            idError = 1
            descripError = "Las Observaciones son un CAMPO obligatorio..."
            Return False
        End If
        If telefono = Nothing Then
            idError = 1
            descripError = "El telefono es un CAMPO obligatorio..."
            Return False
        End If
        If correo = Nothing Then
            idError = 1
            descripError = "El correo es un CAMPO obligatorio..."
            Return False
        End If
        If contacto = Nothing Then
            idError = 1
            descripError = "El contacto es un CAMPO obligatorio..."
            Return False
        End If
        If ubicacionGeografica = Nothing Then
            idError = 1
            descripError = "La ubicación es un CAMPO obligatorio..."
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
