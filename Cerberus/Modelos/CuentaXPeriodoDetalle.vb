Imports System.Data.SqlClient

Public Class CuentaXPeriodoDetalle
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idCuentaXPeriodoDetalle As Integer
    Public idCuentaXPeriodo As Integer
    Public idCuenta As Integer
    Public idPeriodo As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public descuentoNum As Integer

    Public idError As Integer
    Public descripError As String

    Private edoDocs As EstadoDocumentos

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        edoDocs = New EstadoDocumentos()
    End Sub

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of CuentaXPeriodoDetalle))
        cargarGridGen(dgv, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of CuentaXPeriodoDetalle))
        Dim plantilla As CuentaXPeriodoDetalle
        Dim dtb As New DataTable("CuentaXPeriodoDetalle")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Num Descuento", Type.GetType("System.String"))
        dtb.Columns.Add("Monto", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "select CD.*,C.noDocumento,fechaCuenta,CD.descuentoNum,C.monto,C.estado from CuentaXPeriodoDetalle as CD,Cuenta as C WHERE C.idCuenta = CD.idCuenta AND CD.idCuentaXPeriodo = " & idCuentaXPeriodo & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CuentaXPeriodoDetalle(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento") = conex.reader("noDocumento")
                row("Estado") = edoDocs.getNombreEstado(conex.reader("estado"))
                row("Fecha Cuenta") = Format(conex.reader("fechaCuenta"), "dd/MM/yyyy")
                row("Num Descuento") = plantilla.descuentoNum
                row("Monto") = FormatCurrency(conex.reader("monto"))

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
            Mensaje.origen = "CuentaXPeriodoDetalle.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCuentaXPeriodoDetalle = rdr("idCuentaXPeriodoDetalle")
        idCuenta = rdr("idCuenta")
        idCuentaXPeriodo = rdr("idCuentaXPeriodo")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        descuentoNum = rdr("descuentoNum")
        idPeriodo = rdr("idPeriodo")
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
            conex.tabla = "CuentaXPeriodoDetalle"
            conex.accion = accion

            conex.agregaCampo("idCuenta", idCuenta, False, False)
            conex.agregaCampo("idCuentaXPeriodo", idCuentaXPeriodo, False, False)
            conex.agregaCampo("idPeriodo", idPeriodo, False, False)
            conex.agregaCampo("descuentoNum", descuentoNum, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCuentaXPeriodoDetalle = " & idCuentaXPeriodoDetalle

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

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
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

