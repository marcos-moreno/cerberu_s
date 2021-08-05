Imports System.Data.SqlClient
Imports Cerberus

Public Class AccesoEmpleado
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Public idAccesoEmpleado As Integer
    Public idEmpleado As Integer
    Public nombreTabla As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public soloLectura As Boolean
    Public idAcceso As Integer
    Public idElementoSistema As Integer
    Public activa As Boolean

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub cargaGridMenu(grid As DataGridView, obj As List(Of AccesoEmpleado), ventana As String)
        Dim condicion As String
        condicion = "AND nombreTabla = 'Boton' AND idEmpleado = " & idEmpleado & " AND ventana = '" & ventana & "'"

        cargarGridGen(grid, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of AccesoEmpleado))
        Dim plantilla As AccesoEmpleado
        Dim dtb As New DataTable("AccesoEmpleado")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Permitido", Type.GetType("System.Boolean"))
        dtb.Columns.Add("Codigo", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Orden", Type.GetType("System.String")).ReadOnly = True
        dtb.Columns.Add("Nombre Menu", Type.GetType("System.String")).ReadOnly = True

        obj.Clear()

        conex.Qry = "SELECT A.*,E.elemento,e.nombreElemento,e.orden FROM AccesoEmpleado as A, ElementoAcceso  as E WHERE E.idElementoSistema = A.idElementoSistema " & condicion & " ORDER BY E.orden"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New AccesoEmpleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Permitido") = plantilla.activa
                row("Codigo") = conex.reader("elemento")
                row("Orden") = conex.reader("orden")
                row("Nombre Menu") = conex.reader("nombreElemento")

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
            Mensaje.origen = "AccesoEmpleado.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub validaMenu(ventana As String, menu As MenuStrip)

        For Each tsmi As ToolStripMenuItem In menu.Items

            If obtenerAccesosXEmplXTabla("", ventana, tsmi.Name) Then
                tsmi.Visible = activa
            Else
                tsmi.Visible = False
            End If

            For Each tsmiI As ToolStripMenuItem In tsmi.DropDownItems
                If obtenerAccesosXEmplXTabla("", ventana, tsmiI.Name) Then
                    tsmiI.Visible = activa
                Else
                    tsmiI.Visible = False
                End If

                For Each tsmiII As ToolStripMenuItem In tsmiI.DropDownItems
                    If obtenerAccesosXEmplXTabla("", ventana, tsmiII.Name) Then
                        tsmiII.Visible = activa
                    Else
                        tsmiII.Visible = False
                    End If

                    For Each tsmiIII As ToolStripMenuItem In tsmiII.DropDownItems
                        If obtenerAccesosXEmplXTabla("", ventana, tsmiIII.Name) Then
                            tsmiIII.Visible = activa
                        Else
                            tsmiIII.Visible = False
                        End If

                    Next tsmiIII
                Next tsmiII
            Next tsmiI

        Next tsmi

    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idAccesoEmpleado = rdr("idAccesoEmpleado")
        idEmpleado = rdr("idEmpleado")
        nombreTabla = rdr("nombreTabla")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        soloLectura = rdr("soloLectura")
        idAcceso = rdr("idAcceso")
        idElementoSistema = rdr("idElementoSistema")
        activa = rdr("activa")
    End Sub

    Public Function obtenerAccesosXEmplXTabla(ByRef listaIdsAccesos As String, ventana As String, elemento As String) As Boolean
        Dim contador As Integer

        conex.numCon = 0
        conex.tabla = "AccesoEmpleado as A,ElementoAcceso as E"
        conex.accion = "SELECT"

        conex.agregaCampo("A.*")
        conex.condicion = "WHERE E.idElementoSistema = A.idElementoSistema AND A.nombreTabla='" & nombreTabla & "' AND A.idEmpleado=" & idEmpleado & " AND E.elemento='" & elemento & "' AND E.ventana='" & ventana & "' AND isActive = 1"

        conex.armarQry()

        contador = 0
        listaIdsAccesos = ""

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                seteaDatos(conex.reader)
                listaIdsAccesos &= idAcceso & ","
                contador += 1
            End While
            conex.reader.Close()

            listaIdsAccesos &= "*"
            listaIdsAccesos = listaIdsAccesos.Replace(",*", "")

            If contador > 0 Then
                Return True
            Else
                listaIdsAccesos = "0"
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

    End Function

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "AccesoEmpleado"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("nombreTabla", nombreTabla, False, False)
            conex.agregaCampo("soloLectura", soloLectura, False, False)
            conex.agregaCampo("idAcceso", idAcceso, False, False)
            conex.agregaCampo("idElementoSistema", idElementoSistema, False, False)
            conex.agregaCampo("activa", activa, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idAccesoEmpleado = " & idAccesoEmpleado

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
                idAccesoEmpleado = conex.reader("ID")
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

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Private Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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
