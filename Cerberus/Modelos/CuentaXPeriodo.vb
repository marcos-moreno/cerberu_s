Imports System.Data.SqlClient
Imports Cerberus

Public Class CuentaXPeriodo
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idCuentaXPeriodo As Integer
    Public tipoCuenta As String
    Public monto As Decimal
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public noDocumento As String
    Public fechaCuenta As Date
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public estado As String 'BO = Borrador, CO = Completo, CA=Cancelado
    Public idEmpleado As Integer
    Public numeroPeriodos As Integer
    Public montoXPeriodo As Decimal
    Public descripccionCuenta As String
    Public esActivo As Boolean
    Public idConceptoCuenta As Integer

    Public idError As Integer
    Public descripError As String

    Private consec As Consecutivo

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCuentaXPeriodo = rdr("idCuentaXPeriodo")
        tipoCuenta = rdr("tipoCuenta")
        monto = rdr("monto")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        noDocumento = rdr("noDocumento")
        fechaCuenta = rdr("fechaCuenta")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        estado = rdr("estado")
        idEmpleado = rdr("idEmpleado")
        numeroPeriodos = rdr("numeroPeriodos")
        montoXPeriodo = rdr("montoXPeriodo")
        descripccionCuenta = rdr("descripccionCuenta")
        esActivo = rdr("esActivo")
        idConceptoCuenta = rdr("idConceptoCuenta")
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
            conex.tabla = "CuentaXPeriodo"
            conex.accion = accion

            conex.agregaCampo("tipoCuenta", tipoCuenta, False, False)
            conex.agregaCampo("monto", monto, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("noDocumento", noDocumento, False, False)
            conex.agregaCampo("fechaCuenta", fechaCuenta, False, False)
            conex.agregaCampo("estado", estado, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("numeroPeriodos", numeroPeriodos, False, False)
            conex.agregaCampo("montoXPeriodo", montoXPeriodo, False, False)
            conex.agregaCampo("descripccionCuenta", descripccionCuenta, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCuentaXPeriodo = " & idCuentaXPeriodo

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

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idCuentaXPeriodo = conex.reader("ID")
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

    Public Function getNombreEstado() As String
        Return If(estado = "BO", "BORRADOR", If(estado = "CO", "COMPLETO", If(estado = "CA", "CANCELADO", If(estado = "PR", "PROCESADO", "NUEVO"))))
    End Function

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of CuentaXPeriodo), busqueda As String)
        Dim condicion As String
        condicion = ""

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace("*", "%")
            condicion = " AND (Concat(Empleado.NombreEmpleado,' ',Empleado.ApPatEmpleado,' ',Empleado.ApMatEmpleado) like '%" & busqueda & "%' "
            condicion &= "OR cp.noDocumento like '%" & busqueda & "%' "
            condicion &= "OR cp.monto like '%" & busqueda & "%' "
            condicion &= "OR cp.estado like '%" & busqueda & "%' "
            condicion &= "OR convert(date,cp.fechaCuenta) like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of CuentaXPeriodo))
        Dim plantilla As CuentaXPeriodo
        Dim dtb As New DataTable("CuentaXPeriodo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Total Cuenta", Type.GetType("System.Double"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT cp.*,Concat(Empleado.NombreEmpleado,' ',Empleado.ApPatEmpleado,' ',Empleado.ApMatEmpleado) as nEmpleado FROM CuentaXPeriodo AS cp,Empleado WHERE cp.idEmpleado = Empleado.idEmpleado AND cp.idEmpresa = " & idEmpresa & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New CuentaXPeriodo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento") = plantilla.noDocumento
                row("Empleado") = conex.reader("nEmpleado")
                row("Fecha Cuenta") = Format(plantilla.fechaCuenta, "dd/MM/yyyy")
                row("Total Cuenta") = plantilla.monto
                row("Estado") = plantilla.getNombreEstado

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
            Mensaje.origen = "Cuenta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If estado = "BO" Then
            Return armaQry("DELETE", False)
        ElseIf estado = "CO" Then
            estado = "CA"
            Return armaQry("UPDATE", False)
        ElseIf estado = "PR" Then
            idError = 1
            descripError = "No se puede eliminar la Cuenta debido a que ya se encuentra Procesada."
            Return False
        Else
            Return True
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Return ""
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        consec = New Consecutivo(Ambiente)
        consec.idEmpresa = Ambiente.empr.idEmpresa
        consec.dato = tipoCuenta
        consec.tabla = "CuentaXPeriodo"

        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If noDocumento = Nothing Then
            If consec.generaSiguienteConsec Then
                noDocumento = consec.siguienteConsecutivo
                Return True
            Else
                idError = consec.idError
                descripError = consec.descripError
                Return False
            End If
        End If

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
