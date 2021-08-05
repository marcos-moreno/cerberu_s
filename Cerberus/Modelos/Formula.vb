Imports System.Data.SqlClient
Imports Cerberus

Public Class Formula
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado
    Private objIdVariableFormula As VariableFormula

    Public idFormula As Integer
    Public idEmpresa As Integer
    Public formula As String
    Public idVariableFormula As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public tipoCalculo As String
    Public ordenEnReporte As Integer
    Public esImpreso As Boolean

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Formula Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Formula))
        Dim filtro As String
        filtro = "AND F.idEmpresa = " & Ambiente.empr.idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Formula), filtro As String)
        Dim plantilla As Formula
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT F.*,VF.nombreVariable,VF.elemento FROM Formula as F,VariableFormula as VF WHERE F.tipoCalculo = '" & tipoCalculo & "' AND F.idVariableFormula = VF.idVariableFormula " & filtro & " ORDER BY VF.elemento"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Formula(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add("(" & conex.reader("elemento") & ") - " & conex.reader("nombreVariable"))
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Formula.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Formula"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idVariableFormula", idVariableFormula, False, False)
            conex.agregaCampo("formula", formula, False, False)
            conex.agregaCampo("tipoCalculo", tipoCalculo, False, False)
            conex.agregaCampo("ordenEnReporte", ordenEnReporte, False, False)
            conex.agregaCampo("esImpreso", esImpreso, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idFormula = " & idFormula

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
        idFormula = rdr("idFormula")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        formula = rdr("formula")
        idVariableFormula = rdr("idVariableFormula")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        tipoCalculo = rdr("tipoCalculo")
        ordenEnReporte = rdr("ordenEnReporte")
        esImpreso = rdr("esImpreso")
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
        conex.tabla = "Formula"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idFormula=" & idFormula

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function

    Public Function buscarPElementoTCal(elemento As String) As Boolean
        conex.numCon = 0
        conex.tabla = "Formula as F,VariableFormula as VF"
        conex.accion = "SELECT"

        conex.agregaCampo("F.*")
        conex.condicion = "WHERE VF.idVariableFormula = F.idVariableFormula AND F.idEmpresa=" & idEmpresa & " AND VF.elemento='" & elemento & "' AND tipoCalculo='" & tipoCalculo & "'"

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Formula))
        Dim plantilla As Formula
        Dim dtb As New DataTable("Formula")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Formula", Type.GetType("System.Int32"))
        dtb.Columns.Add("Codigo Formula", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Formula", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT F.*, nombreVariable,VF.elemento FROM Formula AS F INNER JOIN VariableFormula AS VF ON F.idVariableFormula=VF.idVariableFormula WHERE F.tipoCalculo = '" & tipoCalculo & "' AND F.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Formula(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Formula") = plantilla.idFormula
                row("Codigo Formula") = conex.reader("elemento")
                row("Nombre Formula") = conex.reader("nombreVariable")

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
            Mensaje.origen = "Formula.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Formula), busqueda As String)
        Dim condicion As String
        condicion = ""

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace("*", "%")
            condicion = " AND (F.formula like '%" & busqueda & "%' "
            condicion &= "OR VF.nombreVariable like '%" & busqueda & "%' "
            condicion &= "OR F.idFormula like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgvDepartamento, condicion, obj)
    End Sub

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idFormula & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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
        If formula = Nothing Then
            idError = 1
            descripError = "La fórmula es un CAMPO obligatorio..."
            Return False
        End If
        If idVariableFormula = Nothing Then
            idError = 2
            descripError = "El ID de la fórmula es un CAMPO obligatorio..."
            Return False
        End If
        Return True
    End Function

    Public Function getNombreVariableFormula() As VariableFormula
        If objIdVariableFormula Is Nothing Then
            objIdVariableFormula = New VariableFormula(Ambiente)
            objIdVariableFormula.idVariableFormula = idVariableFormula
            objIdVariableFormula.buscarPID()
        End If
        Return objIdVariableFormula
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
