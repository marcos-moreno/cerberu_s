Imports System.Data.SqlClient
Imports Cerberus

Public Class MetodoPagoRuta
    Implements InterfaceTablas
    'VARIABLES DE LA TABLA
    Public idMetodoPago As Integer
    Public inicioKm As Decimal
    Public finKm As Decimal
    Public tipoMetodo As String
    Public valorMetodo As Decimal
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idConceptoCuenta
    'Variables y objetos adicionales
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public edoDocs As EstadoDocumentos
    Public objCuenta As Cuenta
    Public objActualizadoPor As Empleado
    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        Me.edoDocs = New EstadoDocumentos
    End Sub

    Public Function getNombreMeotodo() As String
        Dim nombre As String
        nombre = ""

        If tipoMetodo = "F" Then
            nombre = "Fijo"
        ElseIf tipoMetodo = "P" Then
            nombre = "Porcentaje"

        End If

        Return nombre
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos

        idMetodoPago = rdr("idMetodoPago")
        inicioKm = rdr("inicioKm")
        finKm = rdr("finKm")
        tipoMetodo = rdr("tipoMetodo")
        valorMetodo = rdr("valorMetodo")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        idConceptoCuenta = rdr("idConceptoCuenta")

    End Sub

    Public Sub cargarGridComp(listaObj As List(Of MetodoPagoRuta), dgv As DataGridView)
        cargarGridGen(dgv, "", listaObj)
    End Sub

    Private Sub cargarGridGen(dgv As DataGridView, v As String, listaObj As List(Of MetodoPagoRuta))
        Dim plantilla As MetodoPagoRuta
        Dim dtb As New DataTable("MetodoPagoRuta")
        Dim row As DataRow

        dtb.Columns.Add("Inicio KM", Type.GetType("System.Decimal"))
        dtb.Columns.Add("Fin KM", Type.GetType("System.Decimal"))
        dtb.Columns.Add("Tipo Metodo", Type.GetType("System.String"))
        dtb.Columns.Add("Valor Metodo", Type.GetType("System.Decimal"))
        dtb.Columns.Add("Concepto PAGO", Type.GetType("System.String"))


        listaObj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"
        conex.agregaCampo("M.*")
        conex.agregaCampo("C.NombreConceptoCuenta")
        conex.tabla = "MetodoPagoRuta as M, ConceptoCuenta as C"
        conex.condicion = "WHERE M.idConceptoCuenta = C.idConceptoCuenta AND M.idEmpresa = " & idEmpresa

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New MetodoPagoRuta(Ambiente)
                plantilla.seteaDatos(conex.reader)

                listaObj.Add(plantilla)
                row = dtb.NewRow
                row("Inicio KM") = plantilla.inicioKm
                row("Fin KM") = plantilla.finKm
                row("Tipo Metodo") = If(plantilla.tipoMetodo = "F", "Fijo", "Porcentaje")
                row("Valor Metodo") = plantilla.valorMetodo
                row("Concepto PAGO") = conex.reader("NombreConceptoCuenta")
                dtb.Rows.Add(row)
            End While
            conex.reader.Close()
            dgv.DataSource = dtb

            'Es para no permitir el reordenado de las coulmnas
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "MetodoPagoRuta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry

        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "MetodoPagoRuta"
            conex.accion = accion

            conex.agregaCampo("inicioKm", inicioKm, False, False)
            conex.agregaCampo("finKm", finKm, False, False)
            conex.agregaCampo("tipoMetodo", tipoMetodo, False, False)
            conex.agregaCampo("valorMetodo", valorMetodo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            conex.condicion = "WHERE idMetodoPago=" & idMetodoPago
            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return ObtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Ruta.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Private Function ObtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idMetodoPago = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

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
        conex.tabla = "MetodoPagoRuta"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idMetodoPago=" & idMetodoPago

        conex.armarQry()
        If conex.ejecutaConsulta() Then
            seteaDatos(conex.reader)
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarPKM(km As Decimal) As Boolean
        'select * from MetodoPagoRuta where 90 between inicioKm and finKm

        conex.numCon = 0
        conex.accion = "SELECT"
        conex.tabla = "MetodoPagoRuta"
        conex.agregaCampo("*")
        conex.condicion = "WHERE " & km & " between inicioKM and finKM"

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            'Es aquí
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se encontro el METODO con el KM indicado.."
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

        If inicioKm = Nothing Then
            idError = 1
            descripError = "El campo de inicio de KM es obligatorio"
            Return False
        End If

        If finKm = Nothing Then
            idError = 1
            descripError = "El campo de Fin KM es obligatorio"
            Return False
        End If

        If tipoMetodo = Nothing Then
            idError = 1
            descripError = "Eliga un tipo de Método"
            Return False
        End If

        If valorMetodo = Nothing Then
            idError = 1
            descripError = "Ingrese el valor de método"
            Return False
        End If

        If idConceptoCuenta = Nothing Then
            idError = 1
            descripError = "Seleccione un concepto de cuenta"
            Return False
        End If

        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
            idEmpresa = Ambiente.empr.idEmpresa
            idSucursal = Ambiente.suc.idSucursal

        End If

        actualizadoPor = Ambiente.usuario.idEmpleado
        idEmpresa = Ambiente.empr.idEmpresa
        idSucursal = Ambiente.suc.idSucursal

        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
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