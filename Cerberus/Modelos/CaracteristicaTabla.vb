Imports System.Data.SqlClient
Imports Cerberus

Public Class CaracteristicaTabla
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idCaracteristicaTabla As Integer
    Public idTabla As Integer
    Public tabla As String
    Public idCaracteristica As Integer
    Public idAtributo As Integer
    Public idValor As Integer
    Public activo As Boolean
    Public comentario As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCaracteristicaTabla = rdr("idCaracteristicaTabla")
        idTabla = rdr("idTabla")
        tabla = rdr("tabla")
        idCaracteristica = rdr("idCaracteristica")
        idAtributo = rdr("idAtributo")
        idValor = rdr("idValor")
        activo = If(IsDBNull(rdr("activo")), False, rdr("activo"))
        comentario = If(IsDBNull(rdr("comentario")), Nothing, rdr("comentario"))
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
        conex.tabla = "CaracteristicaTabla"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idCaracteristicaTabla=" & idCaracteristicaTabla

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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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
            conex.tabla = "CaracteristicaTabla"
            conex.accion = accion

            conex.agregaCampo("idTabla", idTabla, False, False)
            conex.agregaCampo("tabla", tabla, False, False)
            conex.agregaCampo("idCaracteristica", idCaracteristica, False, False)
            conex.agregaCampo("idAtributo", idAtributo, False, False)
            conex.agregaCampo("idValor", idValor, False, False)
            conex.agregaCampo("comentario", comentario, True, False)
            conex.agregaCampo("activo", activo, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCaracteristicaTabla = " & idCaracteristicaTabla

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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of CaracteristicaTabla))
        Dim condicion As String
        condicion = ""

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of CaracteristicaTabla))
        Dim plantilla As CaracteristicaTabla
        Dim dtb As New DataTable("CaracteristicaTabla")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Caracteristica", Type.GetType("System.String"))
        dtb.Columns.Add("Atributo", Type.GetType("System.String"))
        dtb.Columns.Add("Valor", Type.GetType("System.String"))
        dtb.Columns.Add("Comentario", Type.GetType("System.String"))
        dtb.Columns.Add("Activo", Type.GetType("System.String"))

        objEmp.Clear()

        conex.accion = "SELECT"

        conex.tabla = "CaracteristicaTabla as ct"
        conex.tabla &= ",Caracteristica as c"
        conex.tabla &= ",Atributo as a"
        conex.tabla &= ",Valor as v"

        conex.agregaCampo("ct.*")
        conex.agregaCampo("c.nombreCaracteristica")
        conex.agregaCampo("a.nombreAtributo")
        conex.agregaCampo("v.valor")
        conex.agregaCampo("ct.activo")

        conex.condicion = "WHERE ct.idValor = v.idValor AND ct.idCaracteristica = c.idCaracteristica AND ct.idAtributo = a.idAtributo"
        conex.condicion &= " AND ct.idTabla = " & idTabla & "AND ct.tabla = '" & tabla & "' " & condicion & " Order By c.nombreCaracteristica,a.nombreAtributo,v.valor"

        conex.armarQry()

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                Dim value As String = "Desactivado"
                plantilla = New CaracteristicaTabla(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Caracteristica") = conex.reader("nombreCaracteristica")
                row("Atributo") = conex.reader("nombreAtributo")
                row("Valor") = conex.reader("valor")
                row("Comentario") = plantilla.comentario
                If plantilla.activo Then
                    value = "Activo"
                End If
                row("activo") = value
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
            Mensaje.origen = "CaracteristicaTabla.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
