Imports System.Data.SqlClient

Public Class FormaPagoTraslado
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idFormaPagoTraslado As Integer
    Public nombreFormaPagoT As String
    Public tipoPago As String
    Public valorPago As Decimal
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idConceptoCuenta As Integer
    Private idError As Integer
    Private descripError As String

    Public Sub New(Ambiente)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of FormaPagoTraslado))
        cargarGridGen(dgv, "", obj)
    End Sub

    Public Function geNombreTipoPago() As String
        Select Case tipoPago
            Case "P"
                Return "Porcentaje %"
            Case "F"
                Return "Valor Fijo $"
            Case Else
                Return "Sin Asignar"
        End Select
    End Function

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of FormaPagoTraslado))
        Dim plantilla As FormaPagoTraslado
        Dim dtb As New DataTable("FormaPagoTraslado")
        Dim row As DataRow

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Forma de Pago", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo de Pago", Type.GetType("System.String"))
        dtb.Columns.Add("Valor", Type.GetType("System.String"))
        obj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "FormaPagoTraslado"
        conex.condicion = "Where idEmpresa = " & idEmpresa & " " & condicion
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New FormaPagoTraslado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("ID") = plantilla.idSucursal
                row("Forma de Pago") = plantilla.nombreFormaPagoT
                row("Tipo de Pago") = plantilla.geNombreTipoPago
                row("Valor") = plantilla.valorPago
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
            Mensaje.origen = "FormaPagoTraslado.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idFormaPagoTraslado = rdr("idFormaPagoTraslado")
        nombreFormaPagoT = rdr("nombreFormaPagoT")
        tipoPago = rdr("tipoPago")
        valorPago = rdr("valorPago")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idConceptoCuenta = rdr("idConceptoCuenta")
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

        conex.tabla = "FormaPagoTraslado"

        conex.condicion = "WHERE idFormaPagoTraslado=" & idFormaPagoTraslado

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
        creadoPor = Ambiente.usuario.idEmpleado
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
    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "FormaPagoTraslado"
            conex.accion = accion

            conex.agregaCampo("nombreFormaPagoT", nombreFormaPagoT, False, False)
            conex.agregaCampo("tipoPago", tipoPago, False, False)
            conex.agregaCampo("valorPago", valorPago, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)


            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idFormaPagoTraslado = " & idFormaPagoTraslado

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "FormaPagoTraslado.armaQry" & vbCrLf & conex.descripError
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
                idFormaPagoTraslado = conex.reader("ID")
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
End Class
