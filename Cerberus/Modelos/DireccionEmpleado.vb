Imports System.Data.SqlClient
Imports Cerberus

Public Class DireccionEmpleado
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idDireccionEmpleado As Integer
    Public idEmpleado As Integer
    Public idEmpresa As Integer
    Public calle As String
    Public noInterior As String
    Public noExterior As String
    Public idCodigoPostal As Integer
    Public referencia As String
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Private objCP As CodigoPostal

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        objCP = New CodigoPostal(Ambiente)
    End Sub

    Public Sub getComboEstado(combo As ComboBox, codigoPostal As String)
        objCP.idCodigoPostal = idCodigoPostal
        objCP.codigoPostal = codigoPostal
        objCP.estado = Nothing
        objCP.municipio = Nothing
        objCP.ciudad = Nothing
        objCP.tipoAsentamiento = Nothing

        objCP.GetCombosCP(combo, "estado")
    End Sub

    Public Sub getComboMunicipio(combo As ComboBox, codigoPostal As String, estado As String)
        objCP.idCodigoPostal = idCodigoPostal
        objCP.codigoPostal = codigoPostal
        objCP.estado = estado
        objCP.municipio = Nothing
        objCP.ciudad = Nothing
        objCP.tipoAsentamiento = Nothing

        objCP.GetCombosCP(combo, "municipio")
    End Sub

    Public Sub getComboCiudad(combo As ComboBox, codigoPostal As String, estado As String, municipio As String)
        objCP.idCodigoPostal = idCodigoPostal
        objCP.codigoPostal = codigoPostal
        objCP.estado = estado
        objCP.municipio = municipio
        objCP.ciudad = Nothing
        objCP.tipoAsentamiento = Nothing

        objCP.GetCombosCP(combo, "ciudad")
    End Sub

    Public Sub getComboTipoAsentamiento(combo As ComboBox, codigoPostal As String, estado As String, municipio As String, ciudad As String)
        objCP.idCodigoPostal = idCodigoPostal
        objCP.codigoPostal = codigoPostal
        objCP.estado = estado
        objCP.municipio = municipio
        objCP.ciudad = ciudad
        objCP.tipoAsentamiento = Nothing

        objCP.GetCombosCP(combo, "tipoAsentamiento")
    End Sub

    Public Sub getComboAsentamiento(combo As ComboBox, idCombo As List(Of CodigoPostal), codigoPostal As String, estado As String, municipio As String, ciudad As String, tipoAsentamiento As String)
        objCP.idCodigoPostal = idCodigoPostal
        objCP.codigoPostal = codigoPostal
        objCP.estado = estado
        objCP.municipio = municipio
        objCP.ciudad = ciudad
        objCP.tipoAsentamiento = tipoAsentamiento

        objCP.getAsentamiento(combo, idCombo)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDireccionEmpleado = rdr("idDireccionEmpleado")
        idEmpleado = rdr("idEmpleado")
        idEmpresa = rdr("idEmpresa")
        calle = rdr("calle")
        noInterior = If(IsDBNull(rdr("noInterior")), Nothing, rdr("noInterior"))
        noExterior = rdr("noExterior")
        idCodigoPostal = rdr("idCodigoPostal")
        referencia = If(IsDBNull(rdr("referencia")), Nothing, rdr("referencia"))
        esActivo = rdr("esActivo")
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
        If idDireccionEmpleado <= 0 Then
            Return False
        End If

        conex.Qry = "SELECT * FROM DireccionEmpleado WHERE idDireccionEmpleado = " & idDireccionEmpleado
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If

        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DireccionEmpleado.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            idEmpresa = Ambiente.empr.idEmpresa
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "DireccionEmpleado"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("calle", calle, False, False)
            conex.agregaCampo("noInterior", noInterior, True, False)
            conex.agregaCampo("noExterior", noExterior, False, False)
            conex.agregaCampo("idCodigoPostal", idCodigoPostal, False, False)
            conex.agregaCampo("referencia", referencia, True, False)
            conex.agregaCampo("esActivo", esActivo, False, False)


            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDireccionEmpleado = " & idDireccionEmpleado

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

    Public Sub cargaGrid(grid As DataGridView, obj As List(Of DireccionEmpleado))
        cargarGridGen(grid, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of DireccionEmpleado))
        Dim plantilla As DireccionEmpleado
        Dim dtb As New DataTable("DireccionEmpleado")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Calle", Type.GetType("System.String"))
        dtb.Columns.Add("No Exterior", Type.GetType("System.String"))
        dtb.Columns.Add("C.P.", Type.GetType("System.String"))
        dtb.Columns.Add("Municipio", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "select D.*,C.codigoPostal,C.municipio from DireccionEmpleado as D INNER JOIN CodigoPostal as C On D.idCodigoPostal = C.idCodigoPostal WHERE D.idEmpleado =  " & idEmpleado & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DireccionEmpleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("Calle") = plantilla.calle
                row("No Exterior") = plantilla.noExterior
                row("C.P.") = conex.reader("codigoPostal")
                row("Municipio") = conex.reader("municipio")

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
            Mensaje.origen = "DireccionEmpleado.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
