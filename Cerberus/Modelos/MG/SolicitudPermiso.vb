Imports System.Data.SqlClient
Imports Cerberus
Public Class SolicitudPermiso

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public idError As Integer
    Public descripError As String

    Public idSolicitudPermiso As Integer
    Public idEmpleado As Integer
    Public idTipoIncidencia As Integer
    Public fechaPermiso As Date
    Public calculada As Boolean
    Public horaI As TimeSpan
    Public horaF As TimeSpan
    Public motivo As String
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public respuesta As String
    Public estado As String
    Public idLider As Integer
    Public idIncidencia As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader)
        Try
            idSolicitudPermiso = rdr("idSolicitudPermiso")
            idEmpleado = rdr("idEmpleado")
            idTipoIncidencia = rdr("idTipoIncidencia")
            fechaPermiso = rdr("fechaPermiso")
            calculada = rdr("calculada")
            horaI = IIf(rdr("horaI") Is DBNull.Value, Nothing, rdr("horaI"))
            horaF = IIf(rdr("horaF") Is DBNull.Value, Nothing, rdr("horaF"))
            motivo = rdr("motivo")
            creado = rdr("creado")
            actualizado = rdr("actualizado")
            creadoPor = rdr("creadoPor")
            actualizadoPor = rdr("actualizadoPor")
            respuesta = IIf(rdr("respuesta") Is DBNull.Value, "", Convert.ToString(rdr("respuesta")))
            idIncidencia = IIf(rdr("idIncidencia") Is DBNull.Value, Nothing, Convert.ToString(rdr("idIncidencia")))
            estado = rdr("estado")
            idLider = IIf(rdr("idLider") Is DBNull.Value, 0, Convert.ToString(rdr("idLider")))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function guardar(esAdmin As Boolean) As Boolean
        Return armaQry("INSERT", True, esAdmin)
    End Function

    Public Function actualizar(esAdmin As Boolean) As Boolean
        Return armaQry("UPDATE", False, esAdmin)
    End Function

    Public Function eliminar(esAdmin As Boolean) As Boolean
        Return armaQry("DELETE", False, esAdmin)
    End Function

    Public Function buscarPID() As Boolean
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.tabla = "SELECT"
        conex.agregaCampo("SolicitudPermiso")
        conex.condicion = "WHERE idSolicitudPermiso=" & idSolicitudPermiso
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

    Public Function validaDatos(nuevo As Boolean, esAdmmin As Boolean) As Boolean
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        Else
            If esAdmmin Then
            Else
                If estado = "AU" Then
                    descripError = "La acción NO se pudo completar porque el Permiso ya fué Autorizado."
                    Return False
                End If
                'If estado = "RE" Then
                '    descripError = "La acción NO se pudo completar porque el Permiso fué Rechazado."
                '    Return False
                'End If
            End If
        End If
        actualizadoPor = Ambiente.usuario.idEmpleado
        Return True
    End Function


    Public Function armaQry(accion As String, esInsert As Boolean, esAdmin As Boolean) As Boolean
        If validaDatos(esInsert, esAdmin) Then
            conex.numCon = 0
            conex.accion = accion
            conex.tabla = "SolicitudPermiso"
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idTipoIncidencia", idTipoIncidencia, False, False)
            conex.agregaCampo("fechaPermiso", fechaPermiso, False, False)
            conex.agregaCampo("calculada", calculada, False, False)
            conex.agregaCampo("idLider", idLider, True, False)
            conex.agregaCampo("estado", estado, False, False)
            conex.agregaCampo("horaI", horaI.ToString(), True, False)
            conex.agregaCampo("horaF", horaF.ToString(), True, False)
            conex.agregaCampo("motivo", motivo, False, False)
            conex.agregaCampo("respuesta", respuesta, False, False)
            conex.agregaCampo("idIncidencia", idIncidencia, True, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no... 
            conex.condicion = " WHERE idSolicitudPermiso = " & idSolicitudPermiso
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
            Return False
        End If
    End Function

    'Friend Function crearPermiso(respuesta As String) As Boolean
    '    Dim result As Integer = 0
    '    conex.Qry = "DECLARE @idSolicitudPermiso int = " & idSolicitudPermiso & "
    '                 DECLARE @return int 
    '                 EXECUTE [dbo].[spGenerarPermiso]  
    '                    @idSolicitudPermiso
    '                    ," & Ambiente.usuario.idEmpleado & "
    '                    ,'" & respuesta & "'
    '                    ,@return OUTPUT 
    '                 SELECT @return As resultado"
    '    conex.numCon = 0
    '    If conex.ejecutaConsulta() Then
    '        While conex.reader.Read
    '            result = conex.reader("resultado")
    '        End While
    '        conex.reader.Close()
    '        If result > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Else
    '        Mensaje.tipoMsj = TipoMensaje.Error
    '        Mensaje.origen = "crearPermiso"
    '        Mensaje.Mensaje = conex.descripError
    '        Mensaje.ShowDialog()
    '        Return 0
    '    End If
    'End Function

    Public Sub cargarGridGen(grid As DataGridView, obj As List(Of SolicitudPermiso), isAdmin As Boolean, soloPendientes As Boolean)
        Dim plantilla As SolicitudPermiso
        Dim dtb As New DataTable("SolicitudPermiso")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Permiso", Type.GetType("System.String"))
        If isAdmin Then
            dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        Else
            dtb.Columns.Add("Líder", Type.GetType("System.String"))
        End If
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Creado Por", Type.GetType("System.String"))
        obj.Clear()
        conex.Qry = "SELECT 
                        sp.*,CONCAT(lider.nombreEmpleado,' ',lider.apPatEmpleado) As nombreLider
                        ,CASE sp.estado 
                            WHEN 'RE' THEN 'RECHAZADO' 
                            WHEN 'AU'  THEN 'AUTORIZDO'
                            WHEN 'PA'  THEN 'PENDIENTE DE AUTORIZAR' 
                        END As estadoLargo
                        ,CONCAT(crea.nombreEmpleado,' ',crea.apPatEmpleado) As nombreCreado 
                        ,CONCAT(emp.nombreEmpleado,' ',emp.apPatEmpleado) As empleado 
                    FROM     SolicitudPermiso sp
                    INNER JOIN Empleado crea ON crea.idEmpleado = sp.creadoPor
                    INNER JOIN Empleado emp ON emp.idEmpleado = sp.idEmpleado
                    INNER JOIN Departamento dep ON dep.idDepartamento = emp.idDepartamento"
        Dim pendientesSql = ""
        If soloPendientes Then
            pendientesSql = " AND sp.estado = 'PA' "
        End If
        If isAdmin Then
            conex.Qry += "
                INNER JOIN Empleado lider ON lider.idEmpleado = sp.idLider
                AND lider.idEmpleado =" & idEmpleado & " 
                WHERE 1 = 1  " & pendientesSql & "
                AND emp.idEmpresa = " & Ambiente.empr.idEmpresa & "
                Order By sp.fechaPermiso DESC,idSolicitudPermiso DESC"
        Else
            conex.Qry += "
                INNER JOIN Empleado lider ON lider.idEmpleado = sp.idLider
                WHERE emp.idEmpleado =" & idEmpleado & "  " & pendientesSql & "
                AND emp.idEmpresa = " & Ambiente.empr.idEmpresa & "
                Order By sp.fechaPermiso DESC,idSolicitudPermiso DESC"
        End If

        conex.numCon = 0
        'InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New SolicitudPermiso(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idSolicitudPermiso
                row("Fecha Permiso") = FormatDateTime(plantilla.fechaPermiso, DateFormat.ShortDate)
                If isAdmin Then
                    row("Empleado") = conex.reader("empleado")
                Else
                    row("Líder") = conex.reader("nombreLider")
                End If
                row("Estado") = conex.reader("estadoLargo")
                row("Creado Por") = conex.reader("nombreCreado")
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
            Mensaje.origen = "cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function esLider() As Integer
        Dim total As Integer = 0
        conex.Qry = "SELECT CAST(COALESCE(COUNT(*),0) As int) As total FROM LiderDepartamento WHERE idEmpleado = " & idEmpleado
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                total = conex.reader("total")
            End While
            conex.reader.Close()
            Return total
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "esLider"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return 0
        End If
    End Function
End Class
