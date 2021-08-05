Imports System.Data.SqlClient
Imports Cerberus

Public Class Entregas
    Implements InterfaceTablas


    Public idEntrega As Integer
    Public fecha As Date
    Public nombre As String
    Public descripcion As String
    Public idEmpresa As Integer

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String
    Public creadoPor As Integer
    Public actualizadoPor As Integer

    'reportes 
    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEntrega = rdr("idEntrega")
        fecha = rdr("fecha")
        nombre = rdr("nombre")
        descripcion = rdr("descripcion")
        idEmpresa = rdr("idEmpresa")
        creadoPor = rdr("creadoPor")
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
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
            actualizadoPor = Ambiente.usuario.idEmpleado
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Entregas"
            conex.accion = accion
            conex.agregaCampo("fecha", fecha, False, False)
            conex.agregaCampo("nombre", nombre, False, False)
            conex.agregaCampo("descripcion", descripcion, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEntrega = " & idEntrega

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
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
                idEntrega = conex.reader("ID")
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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Entregas), idSucursalB As Integer, fechaFinal As Date)
        Dim condicion As String
        condicion = " WHERE idEmpresa=" & Ambiente.empr.idEmpresa
        If fechaFinal <> Nothing Then
            Dim formato As String = ""
            Try
                formato = Format(CDate(fechaFinal), "yyyy/MM/dd")
                condicion &= " AND fecha  <=  '" & formato & "' "
            Catch ex As Exception
            End Try
        End If
        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Entregas))
        Dim plantilla As Entregas
        Dim dtb As New DataTable("Entregas")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Entrga", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Descripción", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))

        objEmp.Clear()
        conex.Qry = "SELECT * FROM Entregas "
        conex.Qry &= condicion
        conex.Qry &= "  ORDER BY idEntrega"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Entregas(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Entrga") = plantilla.idEntrega
                row("Nombre") = plantilla.nombre
                row("Descripción") = plantilla.descripcion
                row("Fecha") = Format(plantilla.fecha, "dd/MM/yyyy")
                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()
            grid.DataSource = dtb
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Entrga.cargarGrid"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    'dev. Marcos Moreno
    Public Sub RPT_ImprimirRptcXc()
        creaDSRptcXc()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarRptcXc()
        creaDSRptcXc()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSRptcXc()
        rptDatos = New Reporte(Ambiente, "CXCDEUNIFORMES", "rptCXCDEUNIFORMES")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno

End Class
