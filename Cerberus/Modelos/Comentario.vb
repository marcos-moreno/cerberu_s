Imports System.Data.SqlClient
Imports Cerberus

Public Class Comentario
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    'VARIABLES
    Public idComentario As Integer
    Public descripccion As String
    Public esActivo As Boolean
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public tabla As String
    Public idTabla As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function getTodosComentrios(ByRef comentarios As String) As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT stuff((
			SELECT ', ' + descripccion
			FROM comentario
			WHERE idTabla = " & idTabla & " AND tabla = '" & tabla & "'
			FOR XML PATH('')
			), 1, 1, '') Coments"

        comentarios = ""

        If conex.ejecutaQry Then
            While conex.reader.Read
                comentarios = conex.reader("Coments")
            End While
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

        Return False
    End Function



    Public Sub cargarGrid(grid As DataGridView)
        Dim plantilla As Comentario
        Dim dtb As New DataTable("Comentario")
        Dim row As DataRow

        dtb.Columns.Add("Creado Por", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Comentario", Type.GetType("System.String"))

        conex.Qry = "SELECT Co.*,C.nombreEmpleado as CreadoPor,A.nombreEmpleado as ActualizadoPor FROM Comentario as Co, Empleado as C,Empleado as A WHERE C.idEmpleado = Co.creadoPor AND A.idEmpleado = Co.actualizadoPor AND tabla = '" & tabla & "' AND idTabla = " & idTabla

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Comentario(Ambiente)
                plantilla.seteaDatos(conex.reader)
                row = dtb.NewRow
                row("Creado Por") = conex.reader("CreadoPor")
                row("Fecha") = plantilla.creado
                row("Comentario") = plantilla.descripccion

                dtb.Rows.Add(row)
            End While

            grid.DataSource = dtb
            conex.reader.Close()

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Comentario.cargarGrid"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idComentario = rdr("idComentario")
        descripccion = rdr("descripccion")
        esActivo = rdr("esActivo")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        tabla = rdr("tabla")
        idTabla = rdr("idTabla")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Comentario"
            conex.accion = accion

            conex.agregaCampo("descripccion", descripccion, False, False)
            conex.agregaCampo("tabla", tabla, False, False)
            conex.agregaCampo("idTabla", idTabla, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("creadoPor", creadoPor, False, False)
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idComentario = " & idComentario

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
        Throw New NotImplementedException()
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

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos

        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If

        If descripccion.Length < 5 Then
            idError = 1
            descripError = "Debe de indicar por lo menos 5 caracteres en la descripcción."
            Return False
        Else
            Return True
        End If
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
