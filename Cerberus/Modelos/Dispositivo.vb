Imports System.Data.SqlClient
Imports System.IO
Imports zkemkeeper

Public Class Dispositivo
    Implements InterfaceTablas

    Public dispositivo As CZKEM
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idDispositivo As Integer
    Public nombreDispositivo As String
    Public idZk As Integer
    Public direccionIP As String
    Public puertoDispositivo As String
    Public serieDispositivo As String
    Public modeloDispositivo As String
    Public tipoDispositivo As String
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idUbicacionFisica As Integer
    Public idCocina As Integer
    Public esGeneral As Boolean
    Public esSincronizacionAut As Boolean
    Public esTFT As Boolean
    Public eliminarRegs As Boolean
    Public firmwareVersion As String
    Public activacion As String

    Public idError As Integer
    Public descripError As String

    Private encrip As Encriptar

    Public Sub New(Ambiente)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        dispositivo = New CZKEM

        encrip = New Encriptar
        encrip.myKey = "BYPw@PQq*Vd3w~ad"
    End Sub

    Public Function extraerInfo() As Boolean
        descripError = ""
        idError = 0

        If conectarDispositivo() Then
            If Not dispositivo.GetDeviceInfo(1, 2, idZk) Then
                idError = 1
                descripError &= "No se logro extraer el ID del Dispositivo"
            End If

            If Not dispositivo.GetSerialNumber(1, serieDispositivo) Then
                idError = 2
                descripError &= "No se logro extraer el Número de Serie del Dispositivo"
            End If

            If Not dispositivo.GetProductCode(1, modeloDispositivo) Then
                idError = 3
                descripError &= "No se logro extraer el Modelo del Dispositivo"
            End If

            esTFT = dispositivo.IsTFTMachine(1)

            If Not dispositivo.GetFirmwareVersion(1, firmwareVersion) Then
                idError = 4
                descripError &= "No se puedo extrar la versión del Firmware"
            End If

            If Not actualizar() Then
                Return False
            End If
        Else
            Return False
        End If

        If idError = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function borrarTodo() As Boolean
        If conectarDispositivo() Then
            Return dispositivo.ClearKeeperData(1)
        Else
            Return False
        End If
    End Function

    'Clase especifica de Dispositivo Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Dispositivo))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND (idEmpresa=" & idEmpresa & " OR esGeneral=1 ) "

        getCombo(combo, idCombos, filtro)
    End Sub

    Public Sub getComboActivoXTipo(combo As ComboBox, idCombos As List(Of Dispositivo), elemento As String)
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND (idEmpresa=" & idEmpresa & " OR esGeneral=1) AND tipoDispositivo ='" & elemento & "'"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Dispositivo), filtro As String)
        Dim plantilla As Dispositivo
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Dispositivo " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Dispositivo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreDispositivo)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Dispositivo.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function conectarDispositivo() As Boolean
        If Not My.Computer.Network.Ping(direccionIP) Then
            idError = 1
            descripError = "No se pudo conectar al dispisitivo: " & nombreDispositivo & " (" & direccionIP & ")"
            Return False
        ElseIf dispositivo.Connect_Net(direccionIP, puertoDispositivo) Then
            Return True
        Else
            idError = 1
            descripError = "No se pudo conectar al dispisitivo: " & nombreDispositivo & " (" & direccionIP & ")"
            Return False
        End If
    End Function

    Public Function borrarEmpleado(empl As Empleado) As Boolean
        Dim todoBien As Boolean
        Dim ultimoError As Integer

        If conectarDispositivo() Then
            todoBien = True

            If Not dispositivo.SSR_DeleteEnrollData(idZk, empl.idEmpleado, 12) Then
                todoBien = False
                dispositivo.GetLastError(ultimoError)
                descripError = "Error: " & ultimoError & " ID Empl: " & empl.idEmpleado & vbCrLf
            End If

            If Not todoBien Then
                idError = 1
                descripError = "No todos los Empleados Fueron borrados: " & vbCrLf & descripError
                Return False
            Else
                Return True
            End If
        End If

        Return False
    End Function

    Public Function ActualizaFecha(fecha As DateTime)
        Dim idError As Integer
        If conectarDispositivo() Then
            If dispositivo.SetDeviceTime2(1, fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second) Then
                Return True
            Else
                dispositivo.GetLastError(idError)
                descripError = "No se pudo actualizar la fecha: ID - " & idError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function registrarEmpleado(empl As Empleado) As Boolean
        Dim todoBien As Boolean

        idError = 0
        descripError = ""

        If conectarDispositivo() Then
            todoBien = True

            dispositivo.EnableDevice(idZk, False)

            dispositivo.SetStrCardNumber(empl.numeroTarjeta)

            If dispositivo.SSR_SetUserInfo(idZk, empl.idEmpleado, Mid(empl.nombreCompleto, 1, 22), empl.pwdZK, empl.idTipoUsuario, empl.esActivo) Then

                Dim arch As New Archivo(Ambiente)
                arch.tabla = "Empleado"
                arch.tipoArchivo = "Foto"
                arch.elementoSistema = "FotoReloj"
                arch.idTabla = empl.idEmpleado
                arch.idEmpresa = empl.idEmpresa

                If arch.buscarArchivoPTblIdTTipoArchivoElem() Then
                    Dim ruta As String = "Temporales\"
                    arch.creaArchivo(ruta)
                    dispositivo.UploadUserPhoto(1, ruta & arch.nombreArchivo)
                End If

                If empl.huella0.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 0, 3, empl.huella0)
                End If

                If empl.huella1.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 1, 3, empl.huella1)
                End If

                If empl.huella2.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 2, 3, empl.huella2)
                End If

                If empl.huella3.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 3, 3, empl.huella3)
                End If

                If empl.huella4.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 4, 3, empl.huella4)
                End If

                If empl.huella5.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 5, 3, empl.huella5)
                End If

                If empl.huella6.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 6, 3, empl.huella6)
                End If

                If empl.huella7.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 7, 3, empl.huella7)
                End If

                If empl.huella8.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 8, 3, empl.huella8)
                End If

                If empl.huella9.Length <> 0 Then
                    dispositivo.SetUserTmpExStr(1, empl.idEmpleado, 9, 3, empl.huella9)
                End If

                If empl.rostro.Length <> 0 Then
                    dispositivo.SetUserFaceStr(1, empl.idEmpleado, 50, empl.rostro, empl.rostro.Length)
                End If
            Else
                dispositivo.GetLastError(idError)
                todoBien = False
                descripError = "ID: " & empl.idEmpleado & " Error Disp. " & idError & vbCrLf
            End If

            If Not todoBien Then
                idError = 1
                descripError = "No se registraron todos los Empleados, en el dispositivo: " & nombreDispositivo & " (" & direccionIP & ") >" & vbCrLf & descripError
            Else
                dispositivo.RefreshData(idZk)
                dispositivo.EnableDevice(idZk, True)
                dispositivo.Disconnect()
                Return True
            End If
        End If

        dispositivo.RefreshData(idZk)
        dispositivo.EnableDevice(idZk, True)
        dispositivo.Disconnect()
        Return False
    End Function

    Public Function extraerHuellaRostro(empl As Empleado, ByRef huellasExtraidas As Integer) As Boolean
        Dim bandera As Integer
        Dim huella, rostro As String
        Dim longitud As Integer

        If conectarDispositivo() Then
            huellasExtraidas = 0

            dispositivo.SSR_GetUserInfo(idZk, empl.idEmpleado, "", "", 0, True)
            dispositivo.GetStrCardNumber(empl.numeroTarjeta)

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 0, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella0 = huella
                End If
                huellasExtraidas += 1
            End If

            If dispositivo.DownloadUserPhoto(1, empl.idEmpleado.ToString & ".jpg", Directory.GetCurrentDirectory + "\") Then
                Dim arch As New Archivo(Ambiente)
                arch.tabla = "Empleado"
                arch.tipoArchivo = "Foto"
                arch.elementoSistema = "FotoReloj"
                arch.idTabla = empl.idEmpleado
                arch.idEmpresa = empl.idEmpresa

                If arch.buscarArchivoPTblIdTTipoArchivoElem() Then
                    arch.eliminar()
                End If

                arch.rutaOriginal = Directory.GetCurrentDirectory + "\" + empl.idEmpleado.ToString + ".jpg"
                arch.extension = ".jpg"
                arch.idSucursal = empl.idSucursal

                arch.nombreArchivo = empl.idEmpleado & ".jpg"

                arch.guardar()
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 1, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella1 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 2, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella2 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 3, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella3 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 4, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella4 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 5, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella5 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 6, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella6 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 7, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella7 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 8, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella8 = huella
                End If
                huellasExtraidas += 1
            End If

            huella = ""
            If dispositivo.GetUserTmpExStr(1, empl.idEmpleado, 9, bandera, huella, longitud) Then
                If longitud > 0 Then
                    empl.huella9 = huella
                End If
                huellasExtraidas += 1
            End If

            rostro = ""
            If dispositivo.GetUserFaceStr(1, empl.idEmpleado, 50, rostro, longitud) Then
                If longitud > 0 Then
                    empl.rostro = rostro
                    huellasExtraidas += 1
                Else
                    rostro = ""
                End If
            End If

            Return True
        End If

        Return False
    End Function

    Public Function extraerRegistros(idEvento As Integer, fechaInicial As DateTime, fechaFinal As DateTime) As Boolean
        descripError = ""
        idError = -1

        If conectarDispositivo() Then
            If fechaInicial = Nothing And fechaFinal = Nothing Then
                'If dispositivo.ReadNewGLogData(1) Then
                '    Return extraerRegistros(idEvento)
                'Else
                '    dispositivo.GetLastError(idError)
                '    If idError = 0 Then
                '        descripError = "NO HAY REGISTROS..."
                '    ElseIf idError = -100 Then 'NO SOPORTA...
                If dispositivo.ReadAllGLogData(1) Then
                    Return extraerRegistros(idEvento)
                Else
                    dispositivo.GetLastError(idError)
                    If idError = 0 Then
                        descripError = "NO HAY REGISTROS..."
                    Else
                        descripError = "ID ZK2> " & idError
                    End If
                End If
                '    Else
                '        descripError = "ID ZK1> " & idError
                '    End If

                '    Return False
                'End If
            Else
                If dispositivo.ReadTimeGLogData(1, Format(fechaInicial, "yyyy-MM-dd HH:mm:ss").Trim.ToString, Format(fechaFinal, "yyyy-MM-dd HH:mm:ss").Trim.ToString) Then
                    Return extraerRegistros(idEvento)
                Else
                    dispositivo.GetLastError(idError)
                    If idError = 0 Then
                        descripError = "NO HAY REGISTROS..."
                    ElseIf idError = -100 Then
                        descripError = "FMW INCOMPATIBLE"
                        eliminarRegs = False
                    Else
                        descripError = "ID ZK_> " & idError
                    End If

                    Return False
                End If
            End If
        Else
            Return False
        End If
        Return False
    End Function

    Private Function extraerRegistros(idEvento As Integer) As Boolean
        Dim reg As Registro
        Dim empl As Empleado
        Dim todoBien As Boolean
        Dim numReg As Integer
        Dim errores As String = ""

        reg = New Registro(Ambiente)
        empl = New Empleado(Ambiente)
        reg.tipoRegistro = "AUTOMATICO"
        reg.dispositivo = nombreDispositivo
        reg.esActivo = True
        reg.idEvento = idEvento
        reg.idDispositivo = idDispositivo
        reg.operacion = tipoDispositivo

        todoBien = True

        If esTFT Then
            While dispositivo.SSR_GetGeneralLogData(1, reg.idEmpleado, reg.tipoVerificacion, reg.modoEntradaSalida, reg.anio,
                reg.mes, reg.dia, reg.hora, reg.minuto,
                reg.segundo, reg.idTrabajo)
                empl.idEmpleado = reg.idEmpleado
                If empl.buscarPID() Then
                    reg.idEmpresa = empl.idEmpresa
                    reg.idSucursal = empl.idSucursal
                End If

                reg.armaFecha()

                If Not reg.guardar() Then
                    If reg.idError <> -2146232060 Then 'Duplicate FOR PRIMARY KEY
                        numReg += 1
                        todoBien = False
                        errores &= "(" & numReg & "): " & reg.descripError & vbCrLf
                    End If
                End If
            End While
        Else
            While dispositivo.GetAllGLogData(1, 1, reg.idEmpleado, 1, reg.tipoVerificacion, reg.modoEntradaSalida, reg.anio,
                                            reg.mes, reg.dia, reg.hora, reg.minuto)

                empl.idEmpleado = reg.idEmpleado
                If empl.buscarPID() Then
                    reg.idEmpresa = empl.idEmpresa
                    reg.idSucursal = empl.idSucursal
                End If

                reg.armaFecha()

                If Not reg.guardar() Then
                    If reg.idError <> -2146232060 Then 'Duplicate FOR PRIMARY KEY
                        numReg += 1
                        todoBien = False
                        errores &= "(" & numReg & "): " & reg.descripError & vbCrLf
                    End If
                End If

            End While
        End If

        If Not todoBien Then
            idError = 2
            descripError = "No se guardaron todos los registos (" & numReg & "): " & errores
        Else
            Return borrarAsistenciasReloj()
        End If

        Return False
    End Function

    Public Function borrarAsistenciasReloj() As Boolean
        If conectarDispositivo() Then
            If eliminarRegs Then
                Return dispositivo.ClearGLog(1)
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDispositivo = rdr("idDispositivo")
        nombreDispositivo = rdr("nombreDispositivo")
        idZk = If(IsDBNull(rdr("idZk")), Nothing, rdr("idZk"))
        direccionIP = rdr("direccionIP")
        puertoDispositivo = rdr("puertoDispositivo")
        serieDispositivo = If(IsDBNull(rdr("serieDispositivo")), Nothing, rdr("serieDispositivo"))
        modeloDispositivo = If(IsDBNull(rdr("modeloDispositivo")), Nothing, rdr("modeloDispositivo"))
        tipoDispositivo = rdr("tipoDispositivo")
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idUbicacionFisica = rdr("idUbicacionFisica")
        idCocina = If(IsDBNull(rdr("idCocina")), Nothing, rdr("idCocina"))
        esGeneral = rdr("esGeneral")
        esSincronizacionAut = rdr("esSincronizacionAut")
        esTFT = If(IsDBNull(rdr("esTFT")), Nothing, rdr("esTFT"))
        eliminarRegs = If(IsDBNull(rdr("eliminarRegs")), Nothing, rdr("eliminarRegs"))
        firmwareVersion = If(IsDBNull(rdr("firmwareVersion")), Nothing, rdr("firmwareVersion"))
        activacion = If(IsDBNull(rdr("activacion")), Nothing, rdr("activacion"))
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Dispositivo"
            conex.accion = accion

            conex.agregaCampo("nombreDispositivo", nombreDispositivo, False, False)
            conex.agregaCampo("idZk", idZk, True, False)
            conex.agregaCampo("direccionIP", direccionIP, False, False)
            conex.agregaCampo("puertoDispositivo", puertoDispositivo, False, False)
            conex.agregaCampo("serieDispositivo", serieDispositivo, True, False)
            conex.agregaCampo("modeloDispositivo", modeloDispositivo, True, False)
            conex.agregaCampo("tipoDispositivo", tipoDispositivo, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idUbicacionFisica", idUbicacionFisica, False, False)
            conex.agregaCampo("idCocina", idCocina, True, False)
            conex.agregaCampo("esGeneral", esGeneral, False, False)
            conex.agregaCampo("esSincronizacionAut", esSincronizacionAut, False, False)
            conex.agregaCampo("esTFT", esTFT, False, False)
            conex.agregaCampo("eliminarRegs", eliminarRegs, False, False)
            conex.agregaCampo("firmwareVersion", firmwareVersion, True, False)
            conex.agregaCampo("activacion", activacion, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDispositivo = " & idDispositivo

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

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Dispositivo))
        Dim plantilla As Dispositivo
        Dim dtb As New DataTable("Dispositivo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Nombre Dispositivo", Type.GetType("System.String"))
        dtb.Columns.Add("Direccion IP", Type.GetType("System.String"))
        dtb.Columns.Add("Ubicacion", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo de Dispositivo", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT D.*, U.nombreUbicacionFisica FROM Dispositivo AS D INNER JOIN ubicacionFisica AS U ON D.idUbicacionFisica=U.idUbicacionFisica " &
                    "WHERE (D.idEmpresa = " & Ambiente.empr.idEmpresa & " OR esGeneral=1 ) " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Dispositivo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Nombre Dispositivo") = plantilla.nombreDispositivo
                row("Direccion IP") = plantilla.direccionIP
                row("ubicacion") = Trim(conex.reader("nombreUbicacionFisica"))
                row("Tipo de Dispositivo") = If(plantilla.tipoDispositivo = "ES", "Entrada/Salida", "Comida")

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
            Mensaje.origen = "Dispositivo.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDispositivo As DataGridView, obj As List(Of Dispositivo), activo As Boolean)
        Dim filter As String = ""
        If activo Then
            filter = " AND D.esActivo = 1 "
        Else
            filter = " AND D.esActivo = 0 "
        End If
        cargarGridGen(dgvDispositivo, filter, obj)
    End Sub

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "Dispositivo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idDispositivo = " & idDispositivo

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "El registro solicitado no existe."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idDispositivo & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        idError = 0
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If nombreDispositivo = Nothing Then
            idError = 1
            descripError = "El nombre del dispositivo es un VALOR Obligatorio..."
        ElseIf direccionIP = Nothing Then
            idError = 2
            descripError = "La dirección IP del dispositivo es un VALOR Obligatorio..."
        ElseIf puertoDispositivo = Nothing Then
            idError = 3
            descripError = "El puerto del dispositivo es un VALOR Obligatorio..."
        ElseIf idUbicacionFisica = Nothing Then
            idError = 4
            descripError = "La ubicación de RED del dispositivo es un VALOR Obligatorio..."
        ElseIf tipoDispositivo = Nothing Then
            idError = 5
            descripError = "El tipo del dispositivo es un VALOR Obligatorio..."
        ElseIf Not validaLic And activacion <> Nothing Then
            idError = 6
            descripError = "El código de licencia es INVÁLIDO, favor de contactar a su Administrador..."
        End If

        If idError > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function validaLic() As Boolean
        Dim cod As String
        Dim codigo() As String

        Try
            cod = encrip.Desencriptar(activacion)
            codigo = Split(cod, "||")

            If codigo(1) = serieDispositivo Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
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
