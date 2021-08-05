Imports System.Data.SqlClient
Imports Cerberus

Public Class EstacionTrabajo
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public idError As Integer
    Public descripError As String
    Public idEstacionTrabajo As Integer
    Public nombreEstacion As String
    Public idUbicacionFisica As Integer
    Public licencia As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public actualizado As DateTime
    Public observaciones As String
    Public codigoSolicitud As String
    Public validaHasta As DateTime

    Public responsable As Integer
    Public descripcion As String
    Public autorizo As Integer
    Public estado_au As String
    Public canLogin As Boolean
    Public lastAccess As DateTime


    Private encrip As Encriptar

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        encrip = New Encriptar
        encrip.myKey = "ar9CdcRINJv4Bk5gPE07"
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEstacionTrabajo = rdr("idEstacionTrabajo")
        nombreEstacion = rdr("nombreEstacion")
        idUbicacionFisica = If(IsDBNull(rdr("idUbicacionFisica")), Nothing, rdr("idUbicacionFisica"))
        observaciones = rdr("observaciones")
        licencia = rdr("licencia")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        actualizado = rdr("actualizado")


        responsable = If(IsDBNull(rdr("responsable")), Nothing, rdr("responsable"))
        lastAccess = If(IsDBNull(rdr("lastAccess")), Nothing, rdr("lastAccess"))
        canLogin = If(IsDBNull(rdr("canLogin")), False, rdr("canLogin"))
        estado_au = If(IsDBNull(rdr("estado_au")), Nothing, rdr("estado_au"))
        autorizo = If(IsDBNull(rdr("autorizo")), Nothing, rdr("autorizo"))
        descripcion = If(IsDBNull(rdr("descripcion")), Nothing, rdr("descripcion"))
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
        conex.tabla = "EstacionTrabajo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreEstacion = '" & nombreEstacion & "'"

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se encontro la Estación de Trabajo buscada..."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function


    Public Function buscarPNomEstacORobservacion() As Boolean
        conex.numCon = 0
        conex.tabla = "EstacionTrabajo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE nombreEstacion LIKE '%" & nombreEstacion & "%' OR observaciones LIKE '%" & observaciones & "%'"

        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se encontro la Estación de Trabajo buscada..."
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry

        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "EstacionTrabajo"
            conex.accion = accion

            conex.agregaCampo("nombreEstacion", nombreEstacion, False, False)
            conex.agregaCampo("idUbicacionFisica", idUbicacionFisica, False, False)
            conex.agregaCampo("licencia", licencia, False, False)
            conex.agregaCampo("observaciones", observaciones, False, False)

            conex.agregaCampo("responsable", responsable, True, False)
            conex.agregaCampo("lastAccess", lastAccess, True, False)
            conex.agregaCampo("canLogin", canLogin, True, False)
            conex.agregaCampo("estado_au", estado_au, True, False)
            conex.agregaCampo("autorizo", autorizo, True, False)
            conex.agregaCampo("descripcion", descripcion, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEstacionTrabajo = " & idEstacionTrabajo
            conex.armarQry()
            'InputBox("", "", conex.Qry)
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
                idEstacionTrabajo = conex.reader("ID")
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

    Public Function licenciaValida() As Boolean
        Dim dato As String
        Dim datos As String()
        Try
            dato = encrip.Desencriptar(licencia)
            datos = Split(dato, "||")

            If datos(1) <> Ambiente.util.serialHDD Then
                descripError = "La Licencia ACTIVA corresponde A ESTE EQUIPO..."
                codigoSolicitud = encrip.Encriptar(Ambiente.util.serialMotherboard & "||" & Ambiente.util.serialHDD)
                Return False
            ElseIf CDate(datos(2)) < Ambiente.fechaServidor Then
                descripError = "La Licencia SE ENCUENTRA VENCIDA (" & CDate(datos(2)) & ")"
                codigoSolicitud = encrip.Encriptar(Ambiente.util.serialMotherboard & "||" & Ambiente.util.serialHDD)
                Return False
            End If

            validaHasta = CDate(datos(2))

            Return True
        Catch ex As Exception
            descripError = "LICENCIA INCORRECTA..."
            codigoSolicitud = encrip.Encriptar(Ambiente.util.serialMotherboard & "||" & Ambiente.util.serialHDD)
            Return False
        End Try

    End Function


    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of EstacionTrabajo), filter As String, estado As String)
        Dim condicion As String
        If filter <> "" Or estado <> "ALL" Then
            condicion = " WHERE  (observaciones LIKE '%" & filter & "%' OR " & " nombreUbicacionFisica LIKE '%" &
                filter & "%' OR " & " nombreEstacion LIKE '%" &
                filter & "%') AND estado_au = (CASE WHEN '" & estado & "' <> 'ALL' THEN '" & estado & "' ELSE estado_au END)"
        Else
            condicion = ""
        End If
        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of EstacionTrabajo))
        Dim plantilla As EstacionTrabajo
        Dim dtb As New DataTable("EstacionTrabajo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Estación", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Descripción", Type.GetType("System.String"))
        objEmp.Clear()
        conex.accion = "SELECT"
        conex.Qry = "SELECT  u.nombreUbicacionFisica,et.*
                    FROM     EstacionTrabajo et
                    INNER JOIN UbicacionFisica u ON u.idUbicacionFisica =  et.idUbicacionFisica
                     " & condicion & " ORDER BY idEstacionTrabajo DESC"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New EstacionTrabajo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idEstacionTrabajo
                row("Nombre Estación") = plantilla.nombreEstacion
                Select Case plantilla.estado_au
                    Case "AU"
                        row("Estado") = "Autorizado"
                    Case "PA"
                        row("Estado") = "Pendiente Por Autorizar"
                    Case "NA"
                        row("Estado") = "No Autorizado"
                    Case Else
                        row("Estado") = "No Autorizado"
                End Select
                row("Descripción") = plantilla.descripcion
                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()
            grid.DataSource = dtb
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "CaracteristicaTabla.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub


End Class
