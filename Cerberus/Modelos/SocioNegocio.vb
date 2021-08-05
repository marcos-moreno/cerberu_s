Imports System.Data.SqlClient
Imports Cerberus

Public Class SocioNegocio
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String

    Public idSocioNegocio As Integer
    Public codigoSocio As String
    Public nombreCorto As String
    Public nombreSocio As String
    Public rfc As String
    Public accesoNivelEmpresa As Boolean
    Public esActivo As Boolean
    Public esCliente As Boolean
    Public esProveedor As Boolean
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idSocioNegocio = rdr("idSocioNegocio")
        codigoSocio = rdr("codigoSocio")
        nombreCorto = rdr("nombreCorto")
        nombreSocio = rdr("nombreSocio")
        rfc = rdr("rfc")
        accesoNivelEmpresa = rdr("accesoNivelEmpresa")
        esActivo = rdr("esActivo")
        esCliente = rdr("esCliente")
        esProveedor = rdr("esProveedor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
    End Sub

    Public Sub cargaGridFiltro(grid As DataGridView, valorBuscado As String, todos As Boolean, soloClientes As Boolean, soloProveedores As Boolean, soloActivos As Boolean, obj As List(Of SocioNegocio))
        Dim filtro As String

        valorBuscado = Replace(valorBuscado, "*", "%")

        filtro = " AND ("
        filtro &= "codigoSocio Like '%" & valorBuscado & "%'"
        filtro &= "OR codigoSocio Like '%" & valorBuscado & "%'"
        filtro &= "OR nombreCorto Like '%" & valorBuscado & "%'"
        filtro &= "OR nombreSocio Like '%" & valorBuscado & "%'"
        filtro &= "OR rfc Like '%" & valorBuscado & "%'"
        filtro &= ") "

        If Not todos And soloClientes Then
            filtro &= " AND esCliente=1 "
        ElseIf Not todos And soloProveedores Then
            filtro &= " AND esProveedor=1 "
        End If

        If soloActivos Then
            filtro &= " AND esActivo=1 "
        End If

        cargarGridGen(grid, filtro, obj)
    End Sub

    Public Sub cargaGrid(grid As DataGridView, obj As List(Of SocioNegocio))
        cargarGridGen(grid, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of SocioNegocio))
        Dim plantilla As SocioNegocio
        Dim dtb As New DataTable("SocioNegocio")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Codigo Socio", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Socio", Type.GetType("System.String"))
        dtb.Columns.Add("RFC", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT * FROM SocioNegocio WHERE idEmpresa =  " & idEmpresa & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New SocioNegocio(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("Codigo Socio") = plantilla.codigoSocio
                row("Nombre Socio") = plantilla.nombreSocio
                row("RFC") = plantilla.rfc

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
            Mensaje.origen = "SocioNegocio.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", False)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "SocioNegocio"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idSocioNegocio=" & idSocioNegocio

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 0
                descripError = "No se encontro el ID Solicitado..."
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
        idEmpresa = Ambiente.empr.idEmpresa

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
            conex.tabla = "SocioNegocio"
            conex.accion = accion

            conex.agregaCampo("codigoSocio", codigoSocio, False, False)
            conex.agregaCampo("nombreCorto", nombreCorto, False, False)
            conex.agregaCampo("nombreSocio", nombreSocio, False, False)
            conex.agregaCampo("rfc", rfc, False, False)
            conex.agregaCampo("accesoNivelEmpresa", accesoNivelEmpresa, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("esCliente", esCliente, False, False)
            conex.agregaCampo("esProveedor", esProveedor, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idSocioNegocio = " & idSocioNegocio

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
End Class
