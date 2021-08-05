Imports System.Data.SqlClient
Imports Cerberus

Public Class TabuladorVersion
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idTabuladorVersion As Integer
    Public idTabulador As Integer
    Public version As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public validoDesde As Date
    Public sueldo As Decimal
    Public costoXhora As Decimal
    Public costoXhoraExtra As Decimal
    Public septimoDia As Decimal

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function buscarActualXFecha(fecha As Date) As Boolean
        conex.Qry = "select top 1 * from TabuladorVersion WHERE idTabulador = " & idTabulador & " AND CONVERT(date,'" & Format(fecha, "yyyy-MM-dd") & "') >= validoDesde order by validoDesde desc"
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
            Mensaje.origen = "TabuladorVersion.buscarActualXFecha: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTabuladorVersion = rdr("idTabuladorVersion")
        idTabulador = rdr("idTabulador")
        version = rdr("version")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        validoDesde = rdr("validoDesde")
        sueldo = rdr("sueldo")
        costoXhora = rdr("costoXhora")
        septimoDia = rdr("septimoDia")
        costoXhoraExtra = rdr("costoXhoraExtra")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return ejecutaQry("INSERT", True)
    End Function

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of TabuladorVersion), busqueda As String)
        Dim condicion As String
        condicion = ""

        'If Not busqueda = Nothing Then
        '    busqueda = busqueda.Replace("*", "%")
        '    condicion = " AND (t.nombreTabulador like '%" & busqueda & "%' "
        '    condicion &= ")"
        'End If

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Function ejecutaQry(accion As String, esInsert As Boolean) As Boolean
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "TabuladorVersion"
            conex.accion = accion

            conex.agregaCampo("idTabulador", idTabulador, False, False)
            conex.agregaCampo("version", "(SELECT CASE WHEN MAX(version) IS NULL THEN 1 ELSE (MAX(version)+1) END FROM TabuladorVersion WHERE idTabulador=" & idTabulador & ")", False, True)
            conex.agregaCampo("validoDesde", validoDesde, False, False)
            conex.agregaCampo("sueldo", sueldo, False, False)
            'conex.agregaCampo("costoXhora", costoXhora, False, False)
            'conex.agregaCampo("septimoDia", septimoDia, False, False)
            conex.agregaCampo("costoXhoraExtra", costoXhoraExtra, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            conex.condicion = "WHERE idTabuladorVersion=" & idTabuladorVersion

            conex.armarQry()

            If conex.ejecutaQry Then
                Return True
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        End If
        Return False
    End Function

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of TabuladorVersion))
        Dim plantilla As TabuladorVersion
        Dim dtb As New DataTable("TabuladorVersion")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Version", Type.GetType("System.Int32"))
        dtb.Columns.Add("Valido Desde", Type.GetType("System.String"))
        dtb.Columns.Add("Sueldo", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = "SELECT tv.* FROM TabuladorVersion AS tv WHERE tv.idTabulador = " & idTabulador & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New TabuladorVersion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Version") = plantilla.version
                row("Valido Desde") = Format(plantilla.validoDesde, "dd/MM/yyyy")
                row("Sueldo") = FormatCurrency(plantilla.sueldo)

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
            Mensaje.origen = "TabuladorVersion.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return ejecutaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return ejecutaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "TabuladorVersion"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idTabuladorVersion=" & idTabuladorVersion

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idTabulador & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If nuevo Then
            If actualizadoPor = Nothing Then
                actualizadoPor = Ambiente.usuario.idEmpleado
            End If
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If costoXhoraExtra = Nothing Then
            idError = 1
            descripError = "El costo por hora extra es un CAMPO obligatorio..."
            Return False
        End If
        If sueldo = Nothing Then
            idError = 2
            descripError = "El sueldo es un CAMPO obligatorio..."
            Return False
        End If
        If validoDesde = Nothing Then
            idError = 3
            descripError = "La fecha válida es un CAMPO obligatorio..."
            Return False
        End If
        Return True
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        Throw New NotImplementedException()
    End Function
End Class
