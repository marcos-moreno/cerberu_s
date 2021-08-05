Imports System.Data.SqlClient
Imports Cerberus

Public Class IncrementoDetalle
    Implements InterfaceTablas

    Public idIncrementoDetalle As Integer
    Public idIncremento As Integer
    Public idEmpleado As Integer
    Public idSucursal As Integer
    Public idDepartamento As Integer
    Public idPuesto As Integer
    Public lider As String
    Public AD As String
    Public fechaIgreso As Date
    Public idTabuladorActual As Integer
    Public observaciones As String


    Public idSuledoIMSSActual As Integer
    Public idTabuladorVersion As Integer
    Public idTabuladorPropuesta As Integer
    Public idTabuladorPropuestaVersion As Integer
    Public idTabuladorAD As Integer

    Public idTabuladorADVersion As Integer
    Public idSueldoIMSSFinal As Integer
    Public creado As Date
    Public creadoPor As Integer
    Public actualizado As Date
    Public actualizadoPor As Integer


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
        idIncrementoDetalle = rdr("idIncrementoDetalle")
        idIncremento = rdr("idIncremento")
        idEmpleado = rdr("idEmpleado")
        idSucursal = rdr("idSucursal")
        idDepartamento = rdr("idDepartamento")
        idPuesto = rdr("idPuesto")
        lider = rdr("lider")
        AD = rdr("AD")
        fechaIgreso = rdr("fechaIgreso")
        idTabuladorActual = rdr("idTabuladorActual")
        idSuledoIMSSActual = If(IsDBNull(rdr("idSuledoIMSSActual")), Nothing, rdr("idSuledoIMSSActual"))
        idTabuladorVersion = rdr("idTabuladorVersion")
        idTabuladorPropuesta = If(IsDBNull(rdr("idTabuladorPropuesta")), Nothing, rdr("idTabuladorPropuesta"))
        idTabuladorPropuestaVersion = If(IsDBNull(rdr("idTabuladorPropuestaVersion")), Nothing, rdr("idTabuladorPropuestaVersion"))
        idTabuladorAD = If(IsDBNull(rdr("idTabuladorAD")), Nothing, rdr("idTabuladorAD"))
        idTabuladorADVersion = If(IsDBNull(rdr("idTabuladorADVersion")), Nothing, rdr("idTabuladorADVersion"))
        idSueldoIMSSFinal = If(IsDBNull(rdr("idSueldoIMSSFinal")), Nothing, rdr("idSueldoIMSSFinal"))
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        observaciones = If(IsDBNull(rdr("observaciones")), Nothing, rdr("observaciones"))
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
            conex.tabla = "incrementoDetalle"
            conex.accion = accion

            conex.agregaCampo("idIncremento", idIncremento, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idDepartamento", idDepartamento, False, False)
            conex.agregaCampo("idPuesto", idPuesto, False, False)
            conex.agregaCampo("lider", lider, False, False)
            conex.agregaCampo("AD", AD, False, False)
            conex.agregaCampo("fechaIgreso", fechaIgreso, False, False)
            conex.agregaCampo("idTabuladorActual", idTabuladorActual, False, False)
            conex.agregaCampo("idSuledoIMSSActual", idSuledoIMSSActual, False, False)
            conex.agregaCampo("idTabuladorPropuesta", idTabuladorPropuesta, False, False)
            conex.agregaCampo("idTabuladorAD", idTabuladorAD, False, False)
            conex.agregaCampo("idSueldoIMSSFinal", idSueldoIMSSFinal, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("observaciones", observaciones, True, False)

            conex.condicion = "WHERE idIncrementoDetalle = " & idIncrementoDetalle
            conex.armarQry()
            'InputBox("s", "s", conex.Qry)
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
                Return True
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
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
                idIncrementoDetalle = conex.reader("ID")
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

    Public Sub cargaGridFiltrado(dgv As DataGridView, obj As List(Of IncrementoDetalle), idIncrementoBuscar As Integer, filtro As String)
        Dim condicion As String
        condicion = " WHERE incd.idIncremento = " & idIncrementoBuscar & " AND concat(empl.nombreEmpleado,' ',empl.apMatEmpleado,' ',empl.apPatEmpleado) like '%" & filtro & "%'"
        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of IncrementoDetalle))
        Dim plantilla As IncrementoDetalle
        Dim dtb As New DataTable("Cuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Detalle Incremento", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))
        dtb.Columns.Add("Departamento", Type.GetType("System.String"))
        dtb.Columns.Add("Puesto", Type.GetType("System.String"))
        dtb.Columns.Add("Tabulador Actual", Type.GetType("System.String"))
        dtb.Columns.Add("Tabulador Autorizado", Type.GetType("System.String"))
        objEmp.Clear()
        conex.Qry = "SELECT concat(empl.nombreEmpleado,' ',empl.apMatEmpleado,' ',empl.apPatEmpleado) As nombreEmpl
		                    ,a.nombreSucursal
		                    ,d.nombreDepartamento
		                    ,p.puesto
		                    ,ta.nombreTabulador As tab_actual
		                    ,tp.nombreTabulador As tab_propuesta
		                    ,incd.* 
                    FROM IncrementoDetalle incd

                    INNER JOIN Empleado empl 
                    ON empl.idEmpleado = incd.idEmpleado

                    INNER JOIN Sucursal a 
                    ON a.idSucursal = incd.idSucursal

                    INNER JOIN Departamento d 
                    ON d.idDepartamento = incd.idDepartamento

                    INNER JOIN Puesto p
                    ON p.idPuesto = incd.idPuesto

                    INNER JOIN Tabulador ta
                    ON incd.idTabuladorActual = ta.idTabulador


                    INNER JOIN Tabulador tp
                    ON incd.idTabuladorAD = tp.idTabulador"
        conex.Qry &= condicion
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New IncrementoDetalle(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Detalle Incremento") = plantilla.idIncrementoDetalle
                row("Empleado") = conex.reader("nombreEmpl")
                row("Sucursal") = conex.reader("nombreSucursal")
                row("Departamento") = conex.reader("nombreDepartamento")
                row("Puesto") = conex.reader("puesto")
                row("Tabulador Actual") = conex.reader("tab_actual")
                row("Tabulador Autorizado") = conex.reader("tab_propuesta")
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
            Mensaje.origen = "Cuenta.cargarGridGen Detalle INCREMENTO"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub creaDSNegociacion(inicioPeriodo As Date)
        rptDatos = New Reporte(Ambiente, "DetalleIncremento", "Negociacion")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idIncrementoDetalle", idIncrementoDetalle, GetType(Integer))
        rptDatos.agregaVarible("vFechaInicial", inicioPeriodo, GetType(Date))
    End Sub

    Public Sub RPT_ImprimirNegociacion(inicioPeriodo As Date)
        creaDSNegociacion(inicioPeriodo)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarNegociacion(inicioPeriodo As Date)
        creaDSNegociacion(inicioPeriodo)
        rptDatos.modificar(dsDatos)
    End Sub
End Class
