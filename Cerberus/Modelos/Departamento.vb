Imports System.Data.SqlClient
Imports Cerberus

Public Class Departamento
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado
    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public idError As Integer
    Public descripError As String
    Public idDepartamento As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public esActivo As Boolean
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public nombreDepartamento As String
    Public nombreLider As String
    Public altaDireccion As String
    Public firmaConcenEntrega As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Departamento))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa=" & idEmpresa

        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            filtro &= " AND idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Departamento), filtro As String)
        Dim plantilla As Departamento
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Departamento " & filtro & " ORDER BY nombreDepartamento"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Departamento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreDepartamento)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Departamento.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    'Funcion getListByEmpresa
    Public Sub getListByEmpresa(listCombos As List(Of Departamento))
        Dim plantilla As Departamento
        listCombos.Clear()
        conex.Qry = "SELECT * FROM Departamento WHERE idEmpresa = " & Ambiente.empr.idEmpresa & " AND esActivo = 1 ORDER BY nombreDepartamento"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Departamento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                listCombos.Add(plantilla)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Departamento.listCombos:" & conex.descripError
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDepartamento = rdr("idDepartamento")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        esActivo = rdr("esActivo")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        nombreDepartamento = rdr("nombreDepartamento")
        nombreLider = rdr("nombreLider")
        altaDireccion = rdr("altaDireccion")
        firmaConcenEntrega = rdr("firmaConcenEntrega")
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
        conex.tabla = "Departamento"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idDepartamento=" & idDepartamento

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

    Public Function buscarPNombre() As Boolean
        conex.numCon = 0
        conex.tabla = "Departamento"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreDepartamento='" & nombreDepartamento & "'"

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Departamento))
        Dim plantilla As Departamento
        Dim dtb As New DataTable("Departamento")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Departamento", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Departamento", Type.GetType("System.String"))
        dtb.Columns.Add("Es Activo", Type.GetType("System.Boolean"))

        objEmp.Clear()

        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            condicion &= " AND D.idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If

        conex.Qry = "SELECT D.* FROM Departamento as D WHERE D.idEmpresa = " & idEmpresa & " " & condicion & " ORDER BY esActivo DESC,nombreDepartamento ASC"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Departamento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Departamento") = plantilla.idDepartamento
                row("Nombre Departamento") = plantilla.nombreDepartamento
                row("Es Activo") = plantilla.esActivo

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
            Mensaje.origen = "Departamento.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridXBusqueda(dgvDepartamento As DataGridView, obj As List(Of Departamento), filtro As String)
        Dim condicion As String = ""

        If filtro <> Nothing Then
            filtro = filtro.Replace("*", "%")
            condicion = " AND (D.nombreDepartamento like '%" & filtro & "%'"
            condicion &= " OR D.idDepartamento like '%" & filtro & "%'"
            condicion &= ") "
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Departamento))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Departamento"
            conex.accion = accion

            conex.agregaCampo("nombreDepartamento", nombreDepartamento, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("nombreLider", nombreLider, False, False)
            conex.agregaCampo("altaDireccion", altaDireccion, False, False)
            conex.agregaCampo("firmaConcenEntrega", firmaConcenEntrega, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDepartamento = " & idDepartamento

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
                idDepartamento = conex.reader("ID")
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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idDepartamento & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If nombreDepartamento = Nothing Then
            idError = 1
            descripError = "Es necesario capturar el nombre del departamento"
            Return False
        Else
            Return True
        End If
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

    Private Sub creaDSDatos()
        Dim dr As DataRow

        rptDatos = New Reporte(Ambiente, "Departamento", "DatosDepartamento")
        dsDatos = New DataSet

        'Tabla
        dsDatos.Tables.Add("Departamento")

        'Columnas
        dsDatos.Tables(0).Columns.Add("idDepartamento")
        dsDatos.Tables(0).Columns.Add("nombreDepartamento")
        dsDatos.Tables(0).Columns.Add("esActivo")

        'Registros
        dr = dsDatos.Tables(0).NewRow
        dr(0) = idDepartamento
        dr(1) = nombreDepartamento
        dr(2) = esActivo


        dsDatos.Tables(0).Rows.Add(dr)
    End Sub

    Public Sub RPT_ImprimirDatos()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatos()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

End Class
