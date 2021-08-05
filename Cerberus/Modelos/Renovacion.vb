
Imports System.Data.SqlClient
Imports Cerberus
Public Class Renovacion
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public idError As Integer
    Public descripError As String
    Public id_renovacion As Integer
    Public fecha_renovacion As Date
    Public fecha_termino As Date
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public id_tipo_renovacion As Integer
    Public idEmpleado As Integer
    Public ultimaFechaTermino As Date


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        id_renovacion = rdr("id_renovacion")
        fecha_renovacion = rdr("fecha_renovacion")
        fecha_termino = rdr("fecha_termino")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        idEmpleado = rdr("idEmpleado")
        id_tipo_renovacion = rdr("id_tipo_renovacion")
        Try
            ultimaFechaTermino = rdr("ultimaFechaTermino")
        Catch ex As Exception
        End Try
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
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE id_renovacion=" & id_renovacion
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
            If verifica_Update(accion) Then
                conex.numCon = 0
                conex.accion = accion
                conex.tabla = "Renovacion"
                conex.agregaCampo("fecha_renovacion", fecha_renovacion, False, False)
                conex.agregaCampo("fecha_termino", fecha_termino, False, False)
                conex.agregaCampo("idEmpleado", idEmpleado, False, False)
                conex.agregaCampo("id_tipo_renovacion", id_tipo_renovacion, False, False)
                If esInsert Then
                    conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                    conex.agregaCampo("creadoPor", creadoPor, False, False)
                End If
                conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
                'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
                If accion = "SELECT" Then
                    conex.agregaCampo("ultimaFecha.ultimaFechaTermino", ultimaFechaTermino, False, False)
                    conex.condicion = "
                    LEFT JOIN(
	                    SELECT MAX(fecha_termino)As ultimaFechaTermino FROM renovacion WHERE idEmpleado = " & idEmpleado & "
                    )AS ultimaFecha ON 1 = 1 "
                End If

                conex.condicion = " WHERE id_renovacion = " & id_renovacion
                conex.armarQry()

                Try
                    If conex.ejecutaQry Then
                        Return True
                    Else
                        idError = conex.idError
                        descripError = conex.descripError
                        Return False
                    End If
                Catch ex As Exception
                    descripError = ex.Message
                    Return False
                End Try
            Else
                'Mensaje.tipoMsj = TipoMensaje.Error
                'Mensaje.Mensaje = "Solo Puedes Actualizar El Últmio Contrato."
                'Mensaje.ShowDialog()
                descripError = "Solo Puedes Actualizar El Últmio Contrato."
                Return False
            End If

        Else
            Return False
        End If
    End Function

    Private Function verifica_Update(accion As String) As Boolean
        If accion = "UPDATE" Then
            conex.Qry = "SELECT MAX(id_renovacion)As id_renovacion FROM renovacion WHERE idEmpleado = " & idEmpleado
            If conex.ejecutaConsulta() Then
                Dim retornado As Boolean = False
                While conex.reader.Read
                    '  If (IsDBNull(rdr("idTabulador")), 0, rdr("idTabulador")) Then
                    If conex.reader("id_renovacion") = id_renovacion Then
                        retornado = True
                    End If
                End While
                conex.reader.Close()
                Return retornado
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.origen = "renovacion.cargarGridGen"
                Mensaje.Mensaje = conex.descripError
                Mensaje.ShowDialog()
            End If
        Else
            Return True
        End If
        Return False
    End Function

    Public Sub cargarGridGen(grid As DataGridView, obj As List(Of Renovacion))
        Dim plantilla As Renovacion
        Dim dtb As New DataTable("renovacion")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("ID", Type.GetType("System.Int32"))
        dtb.Columns.Add("Fecha Renovación", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Término", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo Renovación", Type.GetType("System.String"))
        dtb.Columns.Add("Días Renovación", Type.GetType("System.String"))
        obj.Clear()
        conex.Qry = "SELECT *  FROM renovacion r INNER JOIN tipo_renovacion tr ON tr.id_tipo_renovacion = r.id_tipo_renovacion 
                    LEFT JOIN(
	                    SELECT MAX(fecha_termino)As ultimaFechaTermino FROM renovacion WHERE idEmpleado = " & idEmpleado & "
                    )AS ultimaFecha ON 1 = 1
                    WHERE idEmpleado = " & idEmpleado & " Order By fecha_renovacion DESC"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Renovacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.id_renovacion
                row("Fecha Renovación") = FormatDateTime(plantilla.fecha_renovacion, DateFormat.ShortDate)
                row("Fecha Término") = FormatDateTime(plantilla.fecha_termino, DateFormat.ShortDate)
                row("Tipo Renovación") = conex.reader("nombre")
                row("Días Renovación") = conex.reader("dias_renovacion")
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
            Mensaje.origen = "renovacion.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
