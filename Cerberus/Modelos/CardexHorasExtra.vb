Imports System.Data.SqlClient
Imports Cerberus

Public Class CardexHorasExtra
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idCardexHorasExtra As Integer
    Public motivoModificacion As String
    Public idEmpleado As Integer
    Public actualizadoPor As Integer
    Public fechaActualizado As DateTime
    Public valorAnterio As String
    Public nuevoValor As String
    Public ventanaCambio As String
    Public idPeriodo As Integer
    Public campo As String


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCardexHorasExtra = rdr("idCardexHorasExtra")
        motivoModificacion = rdr("motivoModificacion")
        idEmpleado = rdr("idEmpleado")
        actualizadoPor = rdr("actualizadoPor")
        fechaActualizado = rdr("fechaActualizado")
        valorAnterio = rdr("valorAnterio")
        nuevoValor = rdr("nuevoValor")
        ventanaCambio = rdr("ventanaCambio")
        idPeriodo = rdr("idPeriodo")
        campo = rdr("campo")
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
        conex.tabla = "CardexHorasExtra"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idCardexHorasExtra=" & idCardexHorasExtra

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
        If motivoModificacion = "" Then
            idError = 1
            descripError = "No se puede ingresar un valor vacio..."
            Return False
        End If
        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getactualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
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
            actualizadoPor = Ambiente.usuario.idEmpleado
            conex.numCon = 0
            conex.tabla = "CardexHorasExtra"
            conex.accion = accion

            conex.agregaCampo("motivoModificacion", motivoModificacion, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("fechaActualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("valorAnterio", valorAnterio, False, False)
            conex.agregaCampo("nuevoValor", nuevoValor, False, False)
            conex.agregaCampo("ventanaCambio", ventanaCambio, False, False)
            conex.agregaCampo("idPeriodo", idPeriodo, False, False)
            conex.agregaCampo("campo", campo, False, False)
            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCardexHorasExtra = " & idCardexHorasExtra

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

    Public Sub cargarGridGen(grid As DataGridView)
        Dim plantilla As CardexHorasExtra
        Dim dtb As New DataTable("CardexHorasExtra")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("Motivo de la modificación", Type.GetType("System.String"))
        dtb.Columns.Add("Modificó", Type.GetType("System.String"))
        dtb.Columns.Add("Ventana", Type.GetType("System.String"))
        dtb.Columns.Add("Campo", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Nuevo", Type.GetType("System.String"))
        dtb.Columns.Add("Anterior", Type.GetType("System.String"))
        dtb.Columns.Add("Período", Type.GetType("System.String"))
        conex.Qry = "SELECT  
                        motivoModificacion, 
                        lider.usuario,
                        cardex.fechaActualizado,
                       	CASE WHEN cardex.valorAnterio = 'True' THEN 
							'Si'
							WHEN cardex.valorAnterio = 'False' THEN 
							'No'
							Else
								cardex.valorAnterio
						END As valorAnterio, 
							CASE WHEN cardex.nuevoValor = 'True' THEN 
							    'Si'
							WHEN cardex.nuevoValor = 'False' THEN 
							    'No'
							Else
								cardex.nuevoValor
						END As nuevoValor, 
                        cardex.ventanaCambio,
                        p.nombrePeriodo,
                        cardex.campo
                        --cardex.*
                    FROM CardexHorasExtra cardex
                    INNER JOIN Empleado lider ON lider.idEmpleado = cardex.actualizadoPor
                    INNER JOIN Periodo p ON p.idPeriodo = cardex.idPeriodo
                    WHERE cardex.idEmpleado = " & idEmpleado & "
                    ORDER BY fechaActualizado DESC"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CardexHorasExtra(Ambiente)
                row = dtb.NewRow
                row("Motivo de la modificación") = conex.reader("motivoModificacion")
                row("Modificó") = conex.reader("usuario")
                row("Ventana") = conex.reader("ventanaCambio")
                row("Campo") = conex.reader("campo")
                row("Fecha") = conex.reader("fechaActualizado")
                row("Nuevo") = conex.reader("nuevoValor")
                row("Anterior") = conex.reader("valorAnterio")
                row("Período") = conex.reader("nombrePeriodo")
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
            Mensaje.origen = "CardexHorasExtra.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
