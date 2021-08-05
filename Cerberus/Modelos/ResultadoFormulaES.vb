Imports System.Data.SqlClient
Imports Cerberus

Public Class ResultadoFormulaES
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idFormula As Integer
    Public idResultadoPeriodoES As Integer
    Public formula As String
    Public resultado As Decimal

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idFormula = rdr("idFormula")
        idResultadoPeriodoES = rdr("idResultadoPeriodoES")
        formula = rdr("formula")
        resultado = rdr("resultado")
    End Sub

    Public Sub cargaGridXIDPeriodoES(grid As DataGridView, obj As List(Of ResultadoFormulaES))
        Dim cond As String = ""

        cond &= " AND idResultadoPeriodoES = " & idResultadoPeriodoES & " "
        cond &= " AND F.esImpreso = 1 "

        cargarGridGen(grid, cond, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of ResultadoFormulaES))
        Dim plantilla As ResultadoFormulaES
        Dim dtb As New DataTable("ResultadoFormulaES")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Elemento", Type.GetType("System.String"))
        dtb.Columns.Add("Formula", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Formula", Type.GetType("System.String"))
        dtb.Columns.Add("Resultado", Type.GetType("System.Decimal"))

        obj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("R.*")
        conex.agregaCampo("VF.elemento")
        conex.agregaCampo("VF.nombreVariable")

        conex.tabla = "ResultadoFormulaES as R,Formula as F,VariableFormula as VF"

        conex.condicion = "WHERE "
        conex.condicion &= "R.idFormula = F.idFormula "
        conex.condicion &= "AND VF.idVariableFormula = F.idVariableFormula "
        conex.condicion &= condicion
        conex.condicion &= " ORDER BY F.ordenEnReporte "

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            'Registros

            While conex.reader.Read
                plantilla = New ResultadoFormulaES(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Elemento") = conex.reader("elemento")
                row("Formula") = conex.reader("formula")
                row("Nombre Formula") = conex.reader("nombreVariable")
                row("Resultado") = plantilla.resultado

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
            Mensaje.origen = "ResultadoFormulaES.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ResultadoFormulaES"
            conex.accion = accion

            conex.agregaCampo("idFormula", idFormula, False, False)
            conex.agregaCampo("idResultadoPeriodoES", idResultadoPeriodoES, False, False)
            conex.agregaCampo("formula", formula, False, False)
            conex.agregaCampo("resultado", resultado, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idFormula = " & idFormula & " AND idResultadoPeriodoES=" & idResultadoPeriodoES

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

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
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
End Class
