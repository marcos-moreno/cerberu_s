Imports System.Data.SqlClient
Imports Cerberus

Public Class Incremento
    Implements InterfaceTablas

    Public id_incremento As Integer
    Public idPeriodoInicia As Integer
    Public idPeriodoAplica As Integer
    Public idEmpresa As Integer

    Public creado As Date
    Public creadoPor As Integer
    Public actualizado As Date
    Public actualizadoPor As Integer
    Public observaciones As String
    Public estado As String

    Public idError As Integer
    Public descripError As String
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        id_incremento = rdr("id_incremento")
        idPeriodoInicia = rdr("idPeriodoInicia")
        idPeriodoAplica = rdr("idPeriodoAplica")
        idEmpresa = rdr("idEmpresa")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        Try
            observaciones = rdr("observaciones")
        Catch ex As Exception
            observaciones = Nothing
        End Try
        estado = If(IsDBNull(rdr("estado")), Nothing, rdr("estado"))
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function procesarIncremento() As Boolean
        conex.numCon = 0
        conex.Qry = "EXEC [spID_CopiarTabuladores] " & id_incremento

        If Not conex.ejecutaQry Then
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

        conex.Qry = "EXEC [spID_CopiarSueldosIMSS] " & id_incremento
        If Not conex.ejecutaQry Then
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If


        estado = "CO"
        Return actualizar()
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
        idEmpresa = Ambiente.empr.idEmpresa

        If nuevo Then
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
            conex.tabla = "incremento"
            conex.accion = accion
            conex.agregaCampo("idPeriodoInicia", idPeriodoInicia, False, False)
            conex.agregaCampo("idPeriodoAplica", idPeriodoAplica, False, False)
            conex.agregaCampo("observaciones", observaciones, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("estado", estado, True, False)


            conex.condicion = "WHERE id_incremento = " & id_incremento
            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    obtenerID()
                    Return creaLista()
                Else
                    creaLista()
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function creaLista() As Boolean
        conex.Qry = "EXEC spCrearIncrementoDetalle " & id_incremento & "," & Ambiente.usuario.idEmpleado & "," & Ambiente.empr.idEmpresa

        If Not (conex.ejecutaQry()) Then
            idError = conex.idError
            descripError = conex.descripError
            Return False
        Else
            Return True
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                id_incremento = conex.reader("ID")
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

    Public Sub cargaGridFiltrado(dgv As DataGridView, obj As List(Of Incremento))
        Dim condicion As String
        condicion = " WHERE i.idEmpresa=" & Ambiente.empr.idEmpresa
        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Incremento))
        Dim plantilla As Incremento
        Dim dtb As New DataTable("Cuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Incremento", Type.GetType("System.String"))
        dtb.Columns.Add("Periodo Inicial", Type.GetType("System.String"))
        dtb.Columns.Add("Periodo Aplica", Type.GetType("System.String"))
        dtb.Columns.Add("observaciones", Type.GetType("System.String"))
        objEmp.Clear()
        conex.Qry = "SELECT concat(pa.nombrePeriodo,' : ',pa.inicioPeriodo,' - ',pa.finPeriodo) as p_aplica ,concat(pi.nombrePeriodo,' : ',pi.inicioPeriodo,' - ',pi.finPeriodo) as p_inicia,i.* FROM incremento i inner join Periodo pi ON idPeriodoInicia = pi.idPeriodo INNER JOIN  Periodo pa ON idPeriodoAplica	= pa.idPeriodo "
        conex.Qry &= condicion
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Incremento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Incremento") = plantilla.id_incremento
                row("Periodo Inicial") = conex.reader("p_inicia")
                row("Periodo Aplica") = conex.reader("p_aplica")
                row("observaciones") = plantilla.observaciones
                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()
            grid.DataSource = dtb
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Cuenta.cargarGridGenINCREMENTO"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub creaDSEscalafones()
        rptDatos = New Reporte(Ambiente, "Incremento", "Escalafones")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vidIncremento", id_incremento, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirEscalafones()
        creaDSEscalafones()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarEscalafones()
        creaDSEscalafones()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSAjusteIMSS()
        rptDatos = New Reporte(Ambiente, "Incremento", "AjusteIMSS")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("id_incremento", id_incremento, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirAjusteIMSS()
        creaDSAjusteIMSS()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarAjusteIMSS()
        creaDSAjusteIMSS()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSPorcentajes()
        rptDatos = New Reporte(Ambiente, "Incremento", "Porcentajes")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("id_incremento", id_incremento, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirPorcentajes()
        creaDSPorcentajes()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPorcentajes()
        creaDSPorcentajes()
        rptDatos.modificar(dsDatos)
    End Sub

    'REPORTE M/S
    Public Sub RPT_ImprimirMs()
        creaDS_MS()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarMs()
        creaDS_MS()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDS_MS()
        rptDatos = New Reporte(Ambiente, "Incremento", "M_s")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
    End Sub
End Class
