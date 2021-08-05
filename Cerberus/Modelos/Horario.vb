Imports System.Data.SqlClient
Imports Cerberus

Public Class Horario
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idError As Integer
    Public descripError As String

    Public idHorario As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public esActivo As Boolean
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public nombreHorario As String
    Public tabla As String
    Public tipoHorario As String 'CO = Comida, LA=Laboral
    Public esNocturno As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub


    'Clase especifica de Horario Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Horario))
        Dim filtro As String
        filtro = " AND esActivo = 1"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Horario), filtro As String)
        Dim plantilla As Horario
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Horario WHERE idEmpresa=" & idEmpresa & " AND tipoHorario = '" & tipoHorario & "' AND tabla ='" & tabla & "' " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Horario(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreHorario)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Horario.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idHorario = conex.reader("ID")
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

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Horario))
        cargarGridGen(dgvDepartamento, " AND h.tipoHorario = '" & tipoHorario & "'", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Horario))
        Dim plantilla As Horario
        Dim dtb As New DataTable("Horario")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Horario", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Horario", Type.GetType("System.String"))
        dtb.Columns.Add("Es Activo", Type.GetType("System.Boolean"))

        objEmp.Clear()

        conex.Qry = "SELECT h.* FROM Horario AS h WHERE h.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Horario(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Horario") = plantilla.idHorario
                row("Nombre Horario") = plantilla.nombreHorario
                row("Es Activo") = plantilla.esActivo

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
            Mensaje.origen = "Horario.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Horario"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("nombreHorario", nombreHorario, False, False)
            conex.agregaCampo("tabla", tabla, False, False)
            conex.agregaCampo("tipoHorario", tipoHorario, False, False)
            conex.agregaCampo("esNocturno", esNocturno, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idHorario = " & idHorario

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idHorario = rdr("idHorario")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        esActivo = rdr("esActivo")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        nombreHorario = rdr("nombreHorario")
        tabla = rdr("tabla")
        tipoHorario = rdr("tipoHorario")
        esNocturno = rdr("esNocturno")
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
        conex.tabla = "Horario"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idHorario=" & idHorario

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

    Public Function horarioDefault() As Boolean
        conex.numCon = 0
        conex.tabla = "Horario"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE idEmpresa=" & idEmpresa & " AND esActivo = 1 AND tipoHorario='" & tipoHorario & "' AND tabla='" & tabla & "' ORDER BY idHorario asc"

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
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idHorario & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If nuevo Then
            If actualizadoPor = Nothing Then
                actualizadoPor = Ambiente.usuario.idEmpleado
            End If
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If nombreHorario = Nothing Then
            idError = 1
            descripError = "El nombre del horario es un CAMPO obligatorio..."
            Return False
        End If
        Return True
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
