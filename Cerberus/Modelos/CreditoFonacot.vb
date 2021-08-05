Imports System.Data.SqlClient
Imports Cerberus

Public Class CreditoFonacot
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idCreditoFonacot As Integer
    Public idEmpleado As Integer
    Public numCliente As String
    Public numCredito As String
    Public fechaInicioCredito As Date
    Public montoCredito As Decimal
    Public retencionMensual As Decimal
    Public plazos As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCreditoFonacot = rdr("idCreditoFonacot")
        idEmpleado = rdr("idEmpleado")
        numCliente = rdr("numCliente")
        numCredito = rdr("numCredito")
        fechaInicioCredito = rdr("fechaInicioCredito")
        montoCredito = rdr("montoCredito")
        retencionMensual = rdr("retencionMensual")
        plazos = rdr("plazos")
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
        conex.tabla = "CreditoFonacot"
        conex.condicion = "WHERE idCreditoFonacot=" & idCreditoFonacot

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID buscado..."
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
            conex.tabla = "CreditoFonacot"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("numCliente", numCliente, False, False)
            conex.agregaCampo("numCredito", numCredito, False, False)
            conex.agregaCampo("fechaInicioCredito", fechaInicioCredito, False, False)
            conex.agregaCampo("montoCredito", montoCredito, False, False)
            conex.agregaCampo("retencionMensual", retencionMensual, False, False)
            conex.agregaCampo("plazos", plazos, False, False)

            conex.condicion = "WHERE idCreditoFonacot = " & idCreditoFonacot

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "CreditoFonacot.armaQry" & vbCrLf & conex.descripError
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
                idCreditoFonacot = conex.reader("ID")
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

    Public Sub cargaGridEmpleado(grid As DataGridView, objTabla As List(Of CreditoFonacot))
        Dim condicion As String

        condicion = "WHERE idEmpleado = " & idEmpleado

        cargarGridGen(grid, condicion, objTabla)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objTabla As List(Of CreditoFonacot))
        Dim plantilla As CreditoFonacot
        Dim dtb As New DataTable("CreditoFonacot")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Num.Crédito", Type.GetType("System.String"))
        dtb.Columns.Add("Monto", Type.GetType("System.String"))
        dtb.Columns.Add("Plazos", Type.GetType("System.String"))
        dtb.Columns.Add("Retención", Type.GetType("System.String"))

        objTabla.Clear()

        conex.Qry = "SELECT * FROM CreditoFonacot " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CreditoFonacot(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objTabla.Add(plantilla)
                row = dtb.NewRow
                row("Num.Crédito") = plantilla.numCredito
                row("Monto") = FormatCurrency(plantilla.montoCredito)
                row("Plazos") = plantilla.plazos
                row("Retención") = FormatCurrency(plantilla.retencionMensual)

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
            Mensaje.origen = "CreditoFonacot.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
