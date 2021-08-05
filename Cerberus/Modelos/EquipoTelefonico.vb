Imports System.Data.SqlClient
Imports Cerberus
Public Class EquipoTelefonico
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idEquipoTelefonico As Integer
    Public idCompañia As Integer
    Public nombreEquipo As String
    Public descripcionEquipo As String
    Public costoEquipo As Decimal

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub
    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEquipoTelefonico = rdr("idEquipoTelefonico")
        nombreEquipo = rdr("nombreEquipo")
        descripcionEquipo = IIf(rdr("descripcionEquipo") Is DBNull.Value, "", Convert.ToString(rdr("descripcionEquipo")))
        costoEquipo = IIf(rdr("costoEquipo") Is DBNull.Value, 0, Convert.ToString(rdr("costoEquipo")))
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

            conex.agregaCampo("nombrePlan", nombreEquipo, False, False)
            conex.agregaCampo("descripcionPlan", descripcionEquipo, False, False)
            conex.agregaCampo("costoPlan", costoEquipo, False, False)


            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEquipoTelefonico = " & idEquipoTelefonico
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
                idEquipoTelefonico = conex.reader("ID")
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

    Public Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of EquipoTelefonico))
        Dim plantilla As EquipoTelefonico
        Dim dtb As New DataTable("EquipoTelefonico")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtb.Columns.Add("Costo", Type.GetType("System.String"))
        objEmp.Clear()
        conex.Qry = "SELECT * FROM EquipoTelefonico WHERE idCompañia = " & idCompañia
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New EquipoTelefonico(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idEquipoTelefonico
                row("Nombre") = plantilla.nombreEquipo
                row("Descripcion") = plantilla.descripcionEquipo
                row("Costo") = plantilla.costoEquipo
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
            Mensaje.origen = "Equipo Telefonico.cargarGridGen"
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
        conex.tabla = "EquipoTelefonico"
        conex.condicion = "WHERE idEquipoTelefonico=" & idEquipoTelefonico
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
