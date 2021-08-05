Imports System.Data.SqlClient
Imports Cerberus

Public Class Evento
    Implements InterfaceTablas

    Public idEvento As Integer
    Public idTipoEvento As Integer
    Public idDispositivo As Integer
    Public esActivo As Boolean
    Public intentos As Integer
    Public ultimoError As String
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idEmpleado As Integer
    Public fechaInicial As DateTime
    Public fechaFinal As DateTime

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private disp As Dispositivo

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        disp = New Dispositivo(Ambiente)
    End Sub

    Public Function generarExtraccionAutDispositivos() As Boolean
        conex.numCon = 0
        conex.Qry = "EXEC spGeneraEventosDispositivos " & idEmpresa & "," & Ambiente.usuario.idEmpleado

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function generarFijarHoraAutDispositivos() As Boolean
        conex.numCon = 0
        conex.Qry = "EXEC spGeneraFijarHoraDispositivos " & idEmpresa & "," & Ambiente.usuario.idEmpleado

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Sub cargaGrid(grid As DataGridView, objEvento As List(Of Evento), idDispositivo As Integer, estacion As String)
        Dim condicion As String
        condicion = "AND E.esActivo = 1 AND E.idEmpresa = " & idEmpresa


        If idDispositivo <> Nothing Then
            condicion &= " AND E.idDispositivo=" & idDispositivo
        End If

        If estacion <> "" Then
            condicion &= " AND D.idUbicacionFisica IN (SELECT eT.idUbicacionFisica FROM EstacionTrabajo as eT WHERE eT.nombreEstacion = '" & estacion & "') "
        End If

        cargarGridGen(grid, condicion, objEvento)
    End Sub

    Public Function ejecutarEvento() As Boolean
        disp.idDispositivo = idDispositivo
        If Not disp.buscarPID() Then
            idError = disp.idError
            descripError = disp.descripError
            Return False
        End If

        If Not disp.validaLic And idTipoEvento <> TipoEvento.ExtraerInformacionReloj Then
            idError = 1
            descripError = "Licencia INVÁLIDA...!!!"
            Return False
        End If

        Select Case idTipoEvento
            Case TipoEvento.ExtraerRegistros
                If Not disp.extraerRegistros(idEvento, fechaInicial, fechaFinal) Then
                    idError = disp.idError
                    descripError = disp.descripError
                Else
                    Return True
                End If
            Case TipoEvento.ExtraerInformacionBiometrica
                Dim plantilla As New Empleado(Ambiente)
                plantilla.idEmpleado = idEmpleado
                plantilla.buscarPID()
                Dim numHullas As Integer

                If Not disp.extraerHuellaRostro(plantilla, numHullas) Then
                    idError = disp.idError
                    descripError = disp.descripError
                    Return False
                Else
                    If plantilla.actualizar() Then
                        Return True
                    Else
                        idError = plantilla.idError
                        descripError = plantilla.descripError
                        Return False
                    End If
                End If
            Case TipoEvento.RegistrarEmpleado
                Dim plantilla As New Empleado(Ambiente)
                plantilla.idEmpleado = idEmpleado
                plantilla.buscarPID()

                If Not disp.registrarEmpleado(plantilla) Then
                    idError = disp.idError
                    descripError = disp.descripError
                    Return False
                Else
                    Return True
                End If
            Case TipoEvento.BorrarEmpleado
                Dim plantilla As New Empleado(Ambiente)
                plantilla.idEmpleado = idEmpleado
                plantilla.buscarPID()

                If Not disp.borrarEmpleado(plantilla) Then
                    idError = disp.idError
                    descripError = disp.descripError
                    Return False
                Else
                    Return True
                End If
            Case TipoEvento.ExtraerInformacionReloj
                If Not disp.extraerInfo Then
                    idError = disp.idError
                    descripError = disp.descripError
                Else
                    Return True
                End If
            Case TipoEvento.FijarFecha
                If Not disp.ActualizaFecha(Now) Then
                    idError = disp.idError
                    descripError = disp.descripError
                Else
                    Return True
                End If
            Case TipoEvento.EliminarTodo
                Return disp.borrarTodo
        End Select

        Return False
    End Function

    Public Function esActivoBD(requiereEmpleado As Boolean) As Boolean
        conex.Qry = "SELECT * FROM Evento WHERE esActivo=1 AND idTipoEvento=" & idTipoEvento & " AND idDispositivo=" & idDispositivo
        If requiereEmpleado Then
            If Not idEmpleado = Nothing Then
                conex.Qry += " AND idEmpleado=" & idEmpleado
            End If
        Else
            idEmpleado = Nothing
        End If
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                conex.reader.Close()
            Else
                conex.reader.Close()
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Evento))
        Dim plantilla As Evento
        Dim dtb As New DataTable("Evento")
        Dim row As DataRow

        dtb.Columns.Add("ID Evento", Type.GetType("System.Int32"))
        dtb.Columns.Add("Tipo Evento", Type.GetType("System.String"))
        dtb.Columns.Add("Dispositivo", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Actualizado", Type.GetType("System.String"))
        dtb.Columns.Add("Actualizado Por", Type.GetType("System.String"))
        dtb.Columns.Add("Intentos", Type.GetType("System.String"))
        dtb.Columns.Add("Ultimo Error", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = "SELECT E.*,T.nombreEvento,D.nombreDispositivo,AP.usuario as ActualizadoPor,isnull(concat(rtrim(Emp.nombreEmpleado),' ',rtrim(Emp.ApPatEmpleado),' ',rtrim(Emp.ApMatEmpleado)),'NA') as nEmpleado " &
                    "FROM Evento as E INNER JOIN TipoEvento as T ON T.idTipoEvento = E.idTipoEvento INNER JOIN Dispositivo as D ON D.idDispositivo = E.idDispositivo INNER JOIN Empleado as AP ON AP.idEmpleado = E.actualizadoPor LEFT JOIN Empleado as Emp ON Emp.idEmpleado = E.idEmpleado " &
                    "WHERE E.idEmpresa = " & idEmpresa & " " &
                    condicion & " ORDER BY T.Orden "

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Evento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Evento") = plantilla.idEvento
                row("Tipo Evento") = conex.reader("nombreEvento")
                row("Dispositivo") = conex.reader("nombreDispositivo")
                row("Empleado") = conex.reader("nEmpleado")
                row("Actualizado") = plantilla.actualizado
                row("Actualizado Por") = conex.reader("ActualizadoPor")
                row("Intentos") = plantilla.intentos
                row("Ultimo Error") = plantilla.ultimoError

                dtb.Rows.Add(row)
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Evento.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEvento = rdr("idEvento")
        idTipoEvento = rdr("idTipoEvento")
        idDispositivo = rdr("idDispositivo")
        esActivo = rdr("esActivo")
        intentos = If(IsDBNull(rdr("intentos")), Nothing, rdr("intentos"))
        ultimoError = If(IsDBNull(rdr("ultimoError")), Nothing, rdr("ultimoError"))
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        idEmpleado = If(IsDBNull(rdr("idEmpleado")), Nothing, rdr("idEmpleado"))
        fechaInicial = If(IsDBNull(rdr("fechaInicial")), Nothing, rdr("fechaInicial"))
        fechaFinal = If(IsDBNull(rdr("fechaFinal")), Nothing, rdr("fechaFinal"))
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Evento"
            conex.accion = accion

            conex.agregaCampo("idTipoEvento", idTipoEvento, False, False)
            conex.agregaCampo("idDispositivo", idDispositivo, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("intentos", intentos, True, False)
            conex.agregaCampo("ultimoError", ultimoError, True, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, True, False)
            conex.agregaCampo("fechaInicial", fechaInicial, True, False)
            conex.agregaCampo("fechaFinal", fechaFinal, True, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEvento = " & idEvento

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

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "Evento"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idEvento = " & idEvento

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID Buscando."
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function execSpBorradoEmpleadoReloj() As Integer
        conex.numCon = 0
        conex.Qry = "EXEC [spBorradoEmpleadoReloj] " & idEmpleado
        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                Dim valor = conex.reader("insertados")
                conex.reader.Close()
                Return valor
            Else
                conex.reader.Close()
                idError = 1
                descripError = "Error in procedure spBorradoEmpleadoReloj"
                Return 0
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return 0
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
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
End Class