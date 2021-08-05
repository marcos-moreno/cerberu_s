Imports System.Data.SqlClient
Imports Cerberus

Public Class Destajo
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idDestajo As Integer
    Public etiqueta As String
    Public idEmpleado As Integer
    Public idEtapa As Integer
    Public fechaDestajo As Date
    Public esPagado As Boolean
    Public numBurbujasXMolde As Integer
    Public numBurbujasXEmpleado As Integer
    Public montoDestajo As Decimal
    Public referenciaExterna As String
    Public numPuntos As Integer
    Public origen As String
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String

    Public objEtapa As Etapa

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        conex = Ambiente.conex
    End Sub

    Public Function getEtapa() As Etapa
        If objEtapa Is Nothing Then
            objEtapa = New Etapa(Ambiente)
            objEtapa.idEtapa = idEtapa
            objEtapa.buscarPID()
        End If
        Return objEtapa
    End Function

    Public Function buscarUltimoID() As String
        Dim ultimo As String
        ultimo = "1"

        conex.Qry = "select top 1 referenciaExterna as ultimo from Destajo WHERE idEmpresa= " & idEmpresa & " AND origen='" & origen & "' order by len(referenciaExterna) desc,referenciaExterna desc "
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                ultimo = If(IsDBNull(conex.reader("ultimo")), "1", conex.reader("ultimo"))
            End If
            conex.reader.Close()
        End If

        Return ultimo
    End Function

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Destajo), soloPendientes As Boolean, valorBuscado As String, idBuscado As String, todo As Boolean)
        Dim condicion As String = ""

        If Not todo Then
            If soloPendientes Then
                condicion &= " AND D.esPagado = 0"
            Else
                condicion &= " AND D.esPagado = 1"
            End If
        End If

        If idBuscado <> Nothing Then
            condicion &= " AND referenciaExterna = '" & idBuscado & "' "
        Else
            If valorBuscado <> Nothing Then
                valorBuscado = valorBuscado.Replace("*", "%")

                condicion &= " AND ("
                condicion &= "concat(Emp.nombreEmpleado,' ', Emp.apPatEmpleado,' ', Emp.apMatEmpleado) like '%" & valorBuscado & "%'"
                condicion &= "OR referenciaExterna like '%" & valorBuscado & "%'"
                condicion &= "OR etiqueta like '%" & valorBuscado & "%'"
                condicion &= "OR E.nombreEtapa like '%" & valorBuscado & "%'"
                condicion &= "OR montoDestajo like '%" & valorBuscado & "%'"
                condicion &= "OR origen like '%" & valorBuscado & "%'"

                condicion &= " )"
            End If
        End If

        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            condicion &= " AND Emp.idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Destajo))
        Dim plantilla As Destajo
        Dim dtb As New DataTable("Destajo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Procesar", Type.GetType("System.Boolean"))
        dtb.Columns.Add("Ref Externa", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Fecha", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Origen", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Empleado", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Clasificacion", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Etiqueta", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Etapa", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Destajo", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Pagada", Type.GetType("System.Boolean")).ReadOnly = True

        objEmp.Clear()

        conex.Qry = "Select D.*,(select concat(nombreClasificacion,' (',porcentajePago,' %)') from DestajoClasificacionEmpleado where idDestajoClasificacionEmpeado = Emp.idDestajoClasificacionEmpeado) as clasiFicacion,E.nombreEtapa,concat(Emp.nombreEmpleado,' ', Emp.apPatEmpleado,' ', Emp.apMatEmpleado) as nEmpleado FROM Destajo as D,Etapa as E, Empleado as Emp WHERE Emp.idEmpleado = D.idEmpleado AND E.idEtapa = D.idEtapa AND D.esActivo = 1 AND D.idEmpresa = " & idEmpresa & condicion & " ORDER BY referenciaExterna"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Destajo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Procesar") = False
                row("Ref Externa") = plantilla.referenciaExterna
                row("Fecha") = Format(plantilla.fechaDestajo, "dd.MM.yyyy")
                row("Origen") = plantilla.origen
                row("Empleado") = conex.reader("nEmpleado")
                row("Clasificacion") = If(IsDBNull(conex.reader("clasiFicacion")), "N/A", conex.reader("clasiFicacion"))
                row("Pagada") = plantilla.esPagado
                row("Etiqueta") = plantilla.etiqueta
                row("Etapa") = conex.reader("nombreEtapa")
                row("Destajo") = FormatCurrency(plantilla.montoDestajo)

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
            Mensaje.origen = "Destajo.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Destajo"
            conex.accion = accion

            conex.agregaCampo("etiqueta", etiqueta, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idEtapa", idEtapa, False, False)
            conex.agregaCampo("fechaDestajo", fechaDestajo, False, False)
            conex.agregaCampo("esPagado", esPagado, False, False)
            conex.agregaCampo("numBurbujasXMolde", numBurbujasXMolde, False, False)
            conex.agregaCampo("numBurbujasXEmpleado", numBurbujasXEmpleado, False, False)
            conex.agregaCampo("montoDestajo", montoDestajo, False, False)
            conex.agregaCampo("referenciaExterna", referenciaExterna, False, False)
            conex.agregaCampo("numPuntos", numPuntos, False, False)
            conex.agregaCampo("origen", origen, False, False)
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
            conex.condicion = "WHERE idDestajo = " & idDestajo

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
        idDestajo = rdr("idDestajo")
        etiqueta = rdr("etiqueta")
        idEmpleado = rdr("idEmpleado")
        idEtapa = rdr("idEtapa")
        fechaDestajo = rdr("fechaDestajo")
        esPagado = rdr("esPagado")
        numBurbujasXMolde = rdr("numBurbujasXMolde")
        numBurbujasXEmpleado = rdr("numBurbujasXEmpleado")
        montoDestajo = rdr("montoDestajo")
        referenciaExterna = rdr("referenciaExterna")
        numPuntos = rdr("numPuntos")
        origen = rdr("origen")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        esActivo = rdr("esActivo")
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
        conex.tabla = "Destajo"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idDestajo = " & idDestajo

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
        Return "ID: " & idDestajo & "/" & origen & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If etiqueta = Nothing Then
            idError = 1
            descripError = "La etiqueta es un CAMPO obligatorio..."
            Return False
        End If

        If idEmpleado = Nothing Then
            idError = 1
            descripError = "El empleado es un CAMPO obligatorio..."
            Return False
        End If

        If idEtapa = Nothing Then
            idError = 1
            descripError = "La etapa es un CAMPO obligatorio..."
            Return False
        End If

        If fechaDestajo = Nothing Then
            idError = 1
            descripError = "La fecha es un CAMPO obligatorio..."
            Return False
        End If

        If montoDestajo = Nothing Then
            idError = 1
            descripError = "El monto es un CAMPO obligatorio..."
            Return False
        End If

        If referenciaExterna = Nothing Then
            idError = 1
            descripError = "La referencia es un CAMPO obligatorio..."
            Return False
        End If

        If origen = Nothing Then
            idError = 1
            descripError = "El origen es un CAMPO obligatorio..."
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

    Private Sub creaDSPromedioDestajo(idEmpleado As Integer)
        rptDatos = New Reporte(Ambiente, "Destajo", "PromedioDestajo")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("_idEmpleado", idEmpleado)
        rptDatos.agregaVarible("fechaActual", Now)
        rptDatos.agregaVarible("nombreEmpresa", Ambiente.empr.nombreEmpresa)
    End Sub

    Public Sub RPT_ImprimirPromedioDestajo(idEmpleado As Integer)
        creaDSPromedioDestajo(idEmpleado)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPromedioDestajo(idEmpleado As Integer)
        creaDSPromedioDestajo(idEmpleado)
        rptDatos.modificar(dsDatos)
    End Sub
End Class
