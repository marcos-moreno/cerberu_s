Imports System.Data.SqlClient
Imports Cerberus

Public Class Unidad
    Implements InterfaceTablas

    Public idUnidad As Integer
    Public placa As String
    Public modelo As String
    Public marca As String
    Public generaCobro As Boolean
    Public asignadoA As Integer
    Public comentario As String
    Public numTagAsignado As String
    Public numTarjetaGasolina As String
    Public porcentajeDescuento As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idConceptoCuenta As Integer

    'Variables y objetos a usar
    Public Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objEmpleadoActualiza As Empleado
    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idUnidad = rdr("idUnidad")
        placa = rdr("placa")
        marca = rdr("marca")
        modelo = rdr("modelo")
        generaCobro = rdr("generaCobro")
        asignadoA = If(IsDBNull(rdr("asignadoA")), Nothing, rdr("asignadoA"))
        numTagAsignado = rdr("numTagAsignado")
        numTarjetaGasolina = rdr("numTarjetaGasolina")
        porcentajeDescuento = rdr("porcentajeDescuento")
        comentario = rdr("comentario")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        idConceptoCuenta = rdr("idConceptoCuenta")

    End Sub

    Public Sub cargaGridCom(obj As List(Of Unidad), dgv As DataGridView)
        cargarGridGen(dgv, "", obj)
    End Sub

    Private Sub cargarGridGen(dgv As DataGridView, v As String, obj As List(Of Unidad))
        Dim plantilla As Unidad
        Dim dtb As New DataTable("Unidad")
        Dim row As DataRow

        dtb.Columns.Add("Placa", Type.GetType("System.String"))
        dtb.Columns.Add("Marca", Type.GetType("System.String"))
        dtb.Columns.Add("Modelo", Type.GetType("System.String"))
        dtb.Columns.Add("Genera Cobro", Type.GetType("System.String"))
        dtb.Columns.Add("Asignado a", Type.GetType("System.String"))
        dtb.Columns.Add("Número de TAG asignado", Type.GetType("System.String"))
        dtb.Columns.Add("Número de tarjeta gasolina", Type.GetType("System.String"))
        dtb.Columns.Add("% Descuento", Type.GetType("System.Decimal"))

        obj.Clear()
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.agregaCampo("Unidad.* ")
        conex.agregaCampo("Emp.nombreEmpleado as empleadoName")
        conex.agregaCampo("Emp.apPatEmpleado as apat")
        conex.agregaCampo("Emp.apMatEmpleado as amat")
        conex.tabla = "Unidad "
        conex.tabla &= "INNER JOIN Sucursal as SUC on Unidad.idSucursal=SUC.idSucursal "
        conex.tabla &= "LEFT JOIN Empleado as EMP on Unidad.asignadoA=EMP.idEmpleado "
        conex.condicion = "WHERE Unidad.idEmpresa=" & idEmpresa & " ORDER BY Marca,Modelo"

        conex.armarQry()
        Console.WriteLine(conex.Qry)

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New Unidad(ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("Placa") = plantilla.placa
                row("Marca") = plantilla.marca
                row("Modelo") = plantilla.modelo

                Dim paramPlantilla As String
                If plantilla.generaCobro = True Then
                    paramPlantilla = "Sí"
                Else
                    paramPlantilla = "No"
                End If

                row("Genera Cobro") = paramPlantilla
                row("Asignado a") = conex.reader("empleadoName") & " " & conex.reader("apat") & " " & conex.reader("amat")
                row("Número de TAG asignado") = plantilla.numTagAsignado
                row("Número de tarjeta gasolina") = plantilla.numTarjetaGasolina
                row("% Descuento") = plantilla.porcentajeDescuento

                dtb.Rows.Add(row)
            End While
            conex.reader.Close()
            dgv.DataSource = dtb

            'Se bloquea el reordenado de todas las columnas de este GRID

            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Unidad.cargarGridGen"
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
            conex.tabla = "Unidad"
            conex.accion = accion

            conex.agregaCampo("placa", placa, False, False)
            conex.agregaCampo("marca", marca, False, False)
            conex.agregaCampo("modelo", modelo, False, False)
            conex.agregaCampo("generaCobro", generaCobro, False, False)
            conex.agregaCampo("asignadoA", asignadoA, True, False)
            conex.agregaCampo("comentario", comentario, False, False)
            conex.agregaCampo("numTagAsignado", numTagAsignado, False, False)
            conex.agregaCampo("numTarjetaGasolina", numTarjetaGasolina, False, False)
            conex.agregaCampo("porcentajeDescuento", porcentajeDescuento, False, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If

            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.condicion = "where idUnidad=" & idUnidad

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    ObtenerID()
                End If

                Dim objCargaGas As New CargasGasolina(Ambiente)
                If objCargaGas.ActualizaCargasConPlaca(asignadoA, idUnidad, placa, generaCobro, porcentajeDescuento, idConceptoCuenta) Then
                    Return True
                Else
                    idError = objCargaGas.idError
                    descripError = objCargaGas.descripError
                    Return False
                End If
            Else
                idError = conex.idError
                descripError = "Unidad.ArmaQry: " & vbCrLf & conex.descripError
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
                idUnidad = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo obtener el ID de la unidad"
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

        conex.agregaCampo("*")

        conex.tabla = "Unidad"

        conex.condicion = "WHERE idUnidad=" & idUnidad

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
        If placa = Nothing Then
            idError = 1
            descripError = "Ingrese la placa de la unidad..."
            Return False
        End If

        If marca = Nothing Then
            idError = 1
            descripError = "Ingrese la marca de la unidad..."
            Return False
        End If

        If modelo = Nothing Then
            idError = 1
            descripError = "Ingrese el modelo de la unidad..."
            Return False
        End If

        If comentario = Nothing Then
            idError = 1
            descripError = "Ingrese un comentario..."
            Return False
        End If

        If numTagAsignado = Nothing Then
            idError = 1
            descripError = "Ingrese un número de TAG asignado"
            Return False
        End If

        If numTarjetaGasolina = Nothing Then
            idError = 1
            descripError = "Ingrese un número de tarjeta de gasolina..."
            Return False
        End If

        If porcentajeDescuento = Nothing Then
            idError = 1
            descripError = "Ingrese un % de descuento..."
            Return False
        End If

        If nuevo Then
            creadoPor = ambiente.usuario.idEmpleado
        End If

        actualizadoPor = ambiente.usuario.idEmpleado
        idEmpresa = Ambiente.empr.idEmpresa


        Return True

    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        If objEmpleadoActualiza Is Nothing Then
            objEmpleadoActualiza = New Empleado(ambiente)
            objEmpleadoActualiza.idEmpleado = actualizadoPor
            objEmpleadoActualiza.buscarPID()
        End If
        Return objEmpleadoActualiza
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function
End Class
