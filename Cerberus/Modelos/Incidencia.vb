Imports System.Data.SqlClient
Imports Cerberus

Public Class Incidencia
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idIncidencia As Integer
    Public idTipoIncidencia As Integer
    Public fecha As Date
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idEmpleado As Integer
    Public idDepartamento As Integer
    Public nombreLider As String
    Public numIncidenciaPeriodo As Integer
    Public calculada As Boolean
    Public idHorario As Integer
    Public incidenciaXDia As Boolean

    Private tipoInc As TipoIncidencia
    Private createdBy As Empleado
    Private objActualizadoPor As Empleado

    Private emplInci As Empleado

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Incidencia))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa=" & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Incidencia), filtro As String)
        Dim plantilla As Incidencia
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Incidencia " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Incidencia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.idIncidencia)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Departamento.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub getIncidenciasXRangoFechas(incidencias As List(Of Incidencia), fechaInicial As Date, fechaFinal As Date, filtro As String)
        Dim plantilla As Incidencia
        incidencias.Clear()

        conex.Qry = "SELECT * FROM Incidencia WHERE idEmpresa = " & idEmpresa & " AND fecha between convert(date,'" & Format(fechaInicial, "yyyy-MM-dd") & "') and convert(date,'" & Format(fechaFinal, "yyyy-MM-dd") & "') " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Incidencia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                incidencias.Add(plantilla)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Incidencia.getIncidenciasXRangoFechas:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub getInicidenciaXRangoFechasCTPQ(incidencias As List(Of Incidencia), fechaInicial As Date, fechaFinal As Date)
        Dim filtro As String
        'filtro = "AND idTipoIncidencia IN (SELECT idTipoIncidencia FROM TipoIncidencia WHERE idEmpresa = " & idEmpresa & " AND idTipoIncidenciaCTPQ is not null)"
        filtro = "AND idTipoIncidencia IN (SELECT idTipoIncidencia FROM TipoIncidencia WHERE idTipoIncidenciaCTPQ is not null)"

        'MODO PRUEBA
        'filtro &= " AND idEmpleado = 11 "

        filtro &= " order by idTipoIncidencia,idEmpleado,fecha"

        getIncidenciasXRangoFechas(incidencias, fechaInicial, fechaFinal, filtro)
    End Sub


    Public Function getTipoInicidencia() As TipoIncidencia
        If tipoInc Is Nothing Then
            tipoInc = New TipoIncidencia(Ambiente)
            tipoInc.idTipoIncidencia = idTipoIncidencia
            tipoInc.buscarPID()
        End If
        Return tipoInc
    End Function

    Public Function buscarXFechaXEmpl() As Boolean
        conex.numCon = 0
        conex.tabla = "Incidencia"
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.condicion = "WHERE idEmpresa = " & idEmpresa & " AND idEmpleado = " & idEmpleado & " AND fecha = convert(date,'" & Format(fecha, "yyyy-MM-dd") & "') AND calculada=" & If(calculada, 1, 0)
        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = conex.descripError
                conex.reader.Close()
                Return False
            End If
        Else
            idError = 2
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarXFechaXEmpl(objInci As List(Of Incidencia)) As Boolean
        conex.numCon = 0
        conex.tabla = "Incidencia"
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.condicion = "WHERE idEmpresa = " & idEmpresa & " AND idEmpleado = " & idEmpleado & " AND fecha = convert(date,'" & Format(fecha, "yyyy-MM-dd") & "') AND calculada=" & If(calculada, 1, 0)
        conex.armarQry()

        Dim plantilla As Incidencia
        objInci.Clear()

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New Incidencia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objInci.Add(plantilla)
            End While
            conex.reader.Close()
            Return True
        Else
            idError = 2
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarReglaIncidencia() As String
        conex.numCon = 0
        conex.tabla = "Incidencia"
        conex.accion = "SELECT"

        conex.Qry = "SELECT rs.nombre as incidencia FROM Incidencia i
                    INNER JOIN ReglaSancion rs ON rs.idReglaSancion = i.idReglaSancion
                    WHERE idIncidencia =" & idIncidencia
        Dim valor As String = Nothing
        If conex.ejecutaConsulta Then
            While conex.reader.Read
                valor = conex.reader("incidencia")
            End While
            conex.reader.Close()
            Return valor
        Else
            MsgBox(conex.descripError)

            descripError = conex.descripError
            Return valor
        End If
    End Function

    Public Function buscarPermisoIncidencia() As String
        conex.numCon = 0
        conex.Qry = "SELECT motivo FROM SolicitudPermiso WHERE idIncidencia = " & idIncidencia
        Dim valor As String = Nothing
        If conex.ejecutaConsulta Then
            While conex.reader.Read
                valor = conex.reader("motivo")
            End While
            conex.reader.Close()
            Return valor
        Else
            MsgBox(conex.descripError)
            descripError = conex.descripError
            Return valor
        End If
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idIncidencia = rdr("idIncidencia")
        idTipoIncidencia = rdr("idTipoIncidencia")
        fecha = rdr("fecha")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        idEmpleado = rdr("idEmpleado")
        nombreLider = If(IsDBNull(rdr("nombreLider")), Nothing, rdr("nombreLider"))
        numIncidenciaPeriodo = If(IsDBNull(rdr("numIncidenciaPeriodo")), Nothing, rdr("numIncidenciaPeriodo"))
        calculada = rdr("calculada")
        idHorario = If(IsDBNull(rdr("idHorario")), Nothing, rdr("idHorario"))
        incidenciaXDia = rdr("incidenciaXDia")
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Incidencia"
            conex.accion = accion

            conex.agregaCampo("idTipoIncidencia", idTipoIncidencia, False, False)
            conex.agregaCampo("fecha", fecha, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idDepartamento", idDepartamento, False, False)
            conex.agregaCampo("nombreLider", nombreLider, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("calculada", calculada, False, False)
            conex.agregaCampo("idHorario", idHorario, False, False)
            conex.agregaCampo("incidenciaXDia", incidenciaXDia, False, False)
            conex.agregaCampo("numIncidenciaPeriodo", "(SELECT 
	                                                        COUNT(*) + 1
                                                        FROM 
	                                                        Incidencia 
                                                        WHERE 
	                                                        idEmpleado = " & idEmpleado & "
	                                                        AND YEAR(fecha) = " & fecha.Year & "
	                                                        AND MONTH(fecha) = " & fecha.Month & "
	                                                        AND idTipoIncidencia = " & idTipoIncidencia & "
                                                        )", False, True)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idIncidencia = " & idIncidencia

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    obtenerID()
                    If getTipoInicidencia.codigoIncidencia = "VD" Then
                        Return AgregaVacacion(True)
                    ElseIf getTipoInicidencia.codigoIncidencia = "TT" Then
                        Return AgregaTT
                    Else
                        Return True
                    End If
                Else
                    Return AgregaVacacion(False)
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
                idIncidencia = conex.reader("ID")
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

    Private Function AgregaTT() As Boolean
        Dim objTT As TiempoXTiempo
        Dim objHD As HorarioDetalle
        Dim tiempoXdia As Decimal

        objHD = New HorarioDetalle(Ambiente)
        objHD.idHorario = emplInci.idHorario
        objHD.numDia = fecha.DayOfWeek
        objHD.buscarPID()

        tiempoXdia = DateDiff(DateInterval.Minute, objHD.horaInicial, objHD.horaFinal)
        tiempoXdia = tiempoXdia - DateDiff(DateInterval.Minute, objHD.tiempoComida, CDate("00:00:00"))

        objTT = New TiempoXTiempo(Ambiente)

        objTT.idEmpleado = idEmpleado
        objTT.idEmpresa = Ambiente.empr.idEmpresa
        objTT.idIncidencia = idIncidencia
        objTT.tipoMov = "S"
        objTT.valor = tiempoXdia

        If objTT.guardar() Then
            Return True
        Else
            idError = 0
            descripError = objTT.descripError
            Return False
        End If
    End Function

    Private Function AgregaVacacion(esInsert As Boolean) As Boolean
        Dim controlVac As ControlVacaciones
        controlVac = New ControlVacaciones(Ambiente)

        If esInsert Then
            controlVac.tipoMovimiento = "S"
            controlVac.concepto = "VACACIONES DISFRUTADAS"
            controlVac.idEmpleado = idEmpleado
            controlVac.idIncidencia = idIncidencia
            controlVac.diasRestantes = emplInci.diasVacacionesDisponibles
            controlVac.diasMovimiento = 1
            'controlVac.fechaRegreso = ""

            emplInci.diasVacacionesDisponibles -= 1
            emplInci.actualizar()
            Return controlVac.guardar()
        Else
            controlVac.idIncidencia = idIncidencia

            If controlVac.buscarPIDIncidencia() Then
                If getTipoInicidencia.codigoIncidencia <> "VD" Then
                    emplInci.diasVacacionesDisponibles += 1
                    emplInci.actualizar()
                    Return controlVac.eliminar()
                Else
                    Return True
                End If
            Else
                If getTipoInicidencia.codigoIncidencia = "VD" Then
                    controlVac.tipoMovimiento = "S"
                    controlVac.concepto = "VACACIONES DISFRUTADAS"
                    controlVac.idEmpleado = idEmpleado
                    controlVac.idIncidencia = idIncidencia
                    controlVac.diasRestantes = emplInci.diasVacacionesDisponibles
                    controlVac.diasMovimiento = 1
                    'controlVac.fechaRegreso = ""

                    emplInci.diasVacacionesDisponibles -= 1
                    emplInci.actualizar()
                    Return controlVac.guardar()
                Else
                    Return True
                End If
            End If
        End If
    End Function

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        If getActualizadoPor().noBorrarMisIncidencias And actualizadoPor <> Ambiente.usuario.idEmpleado Then
            descripError = "Las incidencias creadas por: " & getActualizadoPor.nombreEmpleado & ", no pueden ser alteradas."
            Return False
        End If
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If getActualizadoPor().noBorrarMisIncidencias And actualizadoPor <> Ambiente.usuario.idEmpleado Then
            descripError = "Las incidencias creadas por: " & getActualizadoPor.nombreEmpleado & ", no pueden ser borradas."
            Return False
        End If

        Dim controlVac As ControlVacaciones
        controlVac = New ControlVacaciones(Ambiente)
        controlVac.idIncidencia = idIncidencia

        If controlVac.buscarPIDIncidencia() Then
            tipoInc = Nothing
            emplInci = New Empleado(Ambiente)
            emplInci.idEmpleado = idEmpleado
            emplInci.buscarPID()
            emplInci.diasVacacionesDisponibles += 1
            emplInci.actualizar()
            controlVac.eliminar()
        End If


        conex.numCon = 0
        conex.tabla = "Incidencia"
        conex.accion = "DELETE"

        conex.condicion = "WHERE idIncidencia=" & idIncidencia

        conex.armarQry()

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "Incidencia"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idIncidencia=" & idIncidencia

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
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idIncidencia & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        emplInci = New Empleado(Ambiente)
        emplInci.idEmpleado = idEmpleado
        emplInci.buscarPID()

        actualizadoPor = Ambiente.usuario.idEmpleado

        tipoInc = Nothing
        If getTipoInicidencia.codigoIncidencia = "VD" Then
            If emplInci.diasVacacionesDisponibles <= 0 Then
                idError = 1
                descripError = "No tiene dias de VACACIONES disponibles para poder ingresar la incidencia..."
                Return False
            End If
        ElseIf getTipoInicidencia.codigoIncidencia = "TT" Then
            Dim objTxT As TiempoXTiempo
            Dim objHD As HorarioDetalle
            Dim tiempoXdia As Integer

            objTxT = New TiempoXTiempo(Ambiente)
            objTxT.idEmpleado = idEmpleado

            objHD = New HorarioDetalle(Ambiente)
            objHD.idHorario = emplInci.idHorario
            objHD.numDia = fecha.DayOfWeek
            objHD.buscarPID()

            tiempoXdia = DateDiff(DateInterval.Minute, objHD.horaInicial, objHD.horaFinal)

            tiempoXdia = tiempoXdia - DateDiff(DateInterval.Minute, DateTime.Parse(CDate("00:00:00").ToString), objHD.tiempoComida)

            MsgBox(DateDiff(DateInterval.Minute, DateTime.Parse(CDate("00:00:00").ToString), objHD.tiempoComida))

            MsgBox(DateTime.Parse(CDate("00:00:00").ToString))
            MsgBox(objHD.tiempoComida)

            MsgBox(tiempoXdia)
            MsgBox(objTxT.minutosDisponibles())

            If objTxT.minutosDisponibles() < tiempoXdia Then
                idError = 2
                descripError = "No cuenta con tiempo disponible para poder aplicarlo en este dia..."
                Return False
            End If
        End If

        If incidenciaXDia Then
            conex.Qry = "DELETE FROM Incidencia as I WHERE fecha = '" & Format(fecha, "yyyy-MM-dd") & "' and idEmpleado = " & idEmpleado & " 
                       AND  I.idTipoIncidencia in (SELECT Ti.idTipoIncidencia FROM TipoIncidencia as Ti where incidenciaXDia = 1 and calculada = 1)"
            conex.ejecutaQry()
        End If

        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        idEmpresa = Ambiente.empr.idEmpresa

        If idSucursal = Nothing Then
            idSucursal = Ambiente.suc.idSucursal
        End If

        If idDepartamento = Nothing Then
            idDepartamento = emplInci.idDepartamento
        End If

        If nombreLider = Nothing Then
            Dim objDep As New Departamento(Ambiente)
            objDep.idDepartamento = idDepartamento
            objDep.buscarPID()

            nombreLider = objDep.nombreLider
        End If

        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        If createdBy Is Nothing Then
            createdBy = New Empleado(Ambiente)
            createdBy.idEmpleado = creadoPor
            createdBy.buscarPID()
        End If
        Return createdBy
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

    Public Function ImportarExcel(archivo As String, hoja As String, rango As String, objColumnas As List(Of DetalleFormatoImportacion)) As Boolean
        Dim objExcel As New Excel(archivo, hoja, rango)
        Dim objData As DataSet
        objData = objExcel.leer()

        idError = 0
        descripError = ""

        For Each fila In objData.Tables(0).Rows 'Filas
            Dim numColumna As Integer
            Dim dato As Object
            Dim coment As String

            coment = Nothing

            Dim objTabla As Incidencia
            objTabla = New Incidencia(Ambiente)
            objTabla.esActivo = True

            For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                dato = If(IsDBNull(fila.Item(numColumna)), Nothing, fila.Item(numColumna))

                If objColumnas.Item(i).tabla = "Incidencia" Then
                    Select Case objColumnas.Item(i).columnaSQL
                        Case "idTipoIncidencia"
                            Try
                                objTabla.idTipoIncidencia = dato
                            Catch ex As Exception
                                Dim objtipoInci As New TipoIncidencia(Ambiente)
                                objtipoInci.nombreIncidencia = dato
                                If objtipoInci.buscarPNombre() Then
                                    objTabla.idTipoIncidencia = objtipoInci.idTipoIncidencia
                                    objTabla.incidenciaXDia = objtipoInci.incidenciaXDia
                                    objTabla.calculada = objtipoInci.calculada
                                End If
                            End Try
                        Case "fecha"
                            objTabla.fecha = dato
                        Case "idEmpresa"
                            objTabla.idEmpresa = dato
                        Case "idSucursal"
                            objTabla.idSucursal = dato
                        Case "idEmpleado"
                            objTabla.idEmpleado = dato
                        Case "idDepartamento"
                            objTabla.idDepartamento = dato
                        Case "nombreLider"
                            objTabla.nombreLider = dato
                        Case "comentarios"
                            coment = dato
                    End Select
                End If
            Next

            If esActivo = Nothing Then
                esActivo = True
            End If

            If Not objTabla.guardar() Then
                idError = objTabla.idError
                descripError &= "Registro: " & objTabla.descripError & vbCrLf
            Else
                If coment <> Nothing Then
                    Dim comen As New Comentario(Ambiente)
                    comen.tabla = "Incidencia"
                    comen.esActivo = True
                    comen.idTabla = objTabla.idIncidencia
                    comen.descripccion = dato

                    comen.guardar()
                End If
            End If
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
