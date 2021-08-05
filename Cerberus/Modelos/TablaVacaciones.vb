Imports System.Data.SqlClient
Imports Cerberus

Public Class TablaVacaciones
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idTablaVacaciones As Integer
    Public aniosCumplidos As Integer
    Public diasVacaciones As Integer
    Public idEmpresa As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of TablaVacaciones))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of TablaVacaciones))
        Dim plantilla As TablaVacaciones
        Dim dtb As New DataTable("TablaVacaciones")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Años Cumplidos", Type.GetType("System.String"))
        dtb.Columns.Add("Dias Vacaciones", Type.GetType("System.Int32"))

        objEmp.Clear()

        conex.Qry = "SELECT D.* FROM TablaVacaciones as D WHERE D.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New TablaVacaciones(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Dias Vacaciones") = plantilla.diasVacaciones
                row("Años Cumplidos") = plantilla.aniosCumplidos & " AÑOS"

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
            Mensaje.origen = "TablaVacaciones.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "TablaVacaciones"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("aniosCumplidos", aniosCumplidos, False, False)
            conex.agregaCampo("diasVacaciones", diasVacaciones, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idTablaVacaciones = " & idTablaVacaciones

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTablaVacaciones = rdr("idTablaVacaciones")
        idEmpresa = rdr("idEmpresa")
        aniosCumplidos = rdr("aniosCumplidos")
        diasVacaciones = rdr("diasVacaciones")
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
        conex.tabla = "TablaVacaciones"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idTablaVacaciones=" & idTablaVacaciones

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
        Return "ID: " & idTablaVacaciones & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        actualizadoPor = Ambiente.usuario.idEmpleado
        If aniosCumplidos = Nothing Then
            descripError = "'Años cumplidos' es un CAMPO OBLIGATORIO..."
            idError = 1
            Return False
        End If
        If diasVacaciones = Nothing Then
            descripError = "Dias de vacaciones es un CAMPO OBLIGATORIO..."
            idError = 2
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
