Imports System.Data.SqlClient
Imports Cerberus
Public Class Plan
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idPlan As Integer
    Public nombrePlan As String
    Public descripcionPlan As String
    Public costoPlan As Decimal
    Public idCompañia As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub
    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idPlan = rdr("idPlan")
        nombrePlan = rdr("nombrePlan")
        descripcionPlan = IIf(rdr("descripcionPlan") Is DBNull.Value, "", Convert.ToString(rdr("descripcionPlan")))
        costoPlan = IIf(rdr("costoPlan") Is DBNull.Value, "", Convert.ToString(rdr("costoPlan")))
        idCompañia = IIf(rdr("idCompañia") Is DBNull.Value, "", Convert.ToString(rdr("idCompañia")))
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

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Plan"
            conex.accion = accion

            conex.agregaCampo("nombrePlan", nombrePlan, False, False)
            conex.agregaCampo("descripcionPlan", descripcionPlan, False, False)
            conex.agregaCampo("costoPlan", costoPlan, False, False)
            conex.agregaCampo("idCompañia", idCompañia, False, False)


            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idPlan = " & idPlan
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
                idPlan = conex.reader("ID")
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

    Public Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Plan))
        Dim plantilla As Plan
        Dim dtb As New DataTable("Plan")
        Dim row As DataRow
        Dim indice As Integer = 0


        dtb.Columns.Add("idPlan", Type.GetType("System.String"))
        dtb.Columns.Add("Plan", Type.GetType("System.String"))
        dtb.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtb.Columns.Add("Costo", Type.GetType("System.String"))
        dtb.Columns.Add("Compañia", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = " SELECT 
	                    *,
	                    comp.nombre nomCompa
                    FROM [Plan] as p
                    INNER JOIN Compañia comp
                    ON comp.idCompañia = p.idCompañia 
                            WHERE  p.idCompañia=" & idCompañia

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Plan(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("idPlan") = plantilla.idPlan
                row("Plan") = plantilla.nombrePlan
                row("Descripcion") = plantilla.descripcionPlan
                row("Costo") = plantilla.costoPlan
                row("Compañia") = conex.reader("nomCompa")
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
            Mensaje.origen = "Telefonia.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        Throw New NotImplementedException()
    End Function
    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.tabla = "[Plan]"
        conex.condicion = "WHERE idPlan=" & idPlan
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID buscado..."
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
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
