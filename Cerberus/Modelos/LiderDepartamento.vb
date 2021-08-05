Imports System.Data.SqlClient
Imports Cerberus

Public Class LiderDepartamento
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idError As Integer
    Public descripError As String

    Public idLiderDepartamento As Integer
    Public idEmpleado As Integer
    Public idDepartamento As Integer
    Public tipoLider As String
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    ''Funcion General de COMBOS
    Public Sub getComboLiderXdepartamento(combo As ComboBox, idCombos As List(Of LiderDepartamento), filtro As Integer)
        Dim plantilla As LiderDepartamento
        combo.Items.Clear()
        idCombos.Clear()
        conex.Qry = " SELECT ld.*,CONCAT(e.nombreEmpleado,' ',e.apPatEmpleado,' ',apMatEmpleado)as nomlider 
                        FROM LiderDepartamento ld
                     INNER JOIN Empleado e ON e.idEmpleado  = ld.idEmpleado
                     WHERE ld.idDepartamento = " & filtro & " ORDER BY nomlider"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New LiderDepartamento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(conex.reader("nomlider"))
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Departamento.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idLiderDepartamento = rdr("idLiderDepartamento")
        idEmpleado = rdr("idEmpleado")
        idDepartamento = rdr("idDepartamento")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        tipoLider = rdr("tipoLider")
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
        conex.tabla = "LiderDepartamento"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idLiderDepartamento=" & idLiderDepartamento

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

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of LiderDepartamento))
        Dim plantilla As LiderDepartamento
        Dim dtb As New DataTable("LiderDepartamento")
        Dim row As DataRow
        Dim indice As Integer = 0
        dtb.Columns.Add("Nombre Líder", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo Lider", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = "SELECT CONCAT(e.apPatEmpleado,' ',e.apMatEmpleado,' ',e.nombreEmpleado) As nomlide, ld.*
                    FROM     LiderDepartamento ld
                    INNER JOIN Empleado As e ON e.idEmpleado = ld.idEmpleado
                    WHERE ld.idDepartamento = " & idDepartamento

        conex.numCon = 0
        'InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New LiderDepartamento(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Nombre Líder") = conex.reader("nomlide")
                row("Tipo Lider") = plantilla.tipoLider
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
            Mensaje.origen = "Departamento.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    'Public Sub cargaGridXBusqueda(dgvDepartamento As DataGridView, obj As List(Of Departamento), filtro As String)
    '    Dim condicion As String = ""

    '    If filtro <> Nothing Then
    '        filtro = filtro.Replace("*", "%")
    '        condicion = " AND (D.tipoLider like '%" & filtro & "%'"
    '        condicion &= " OR D.idLiderDepartamento like '%" & filtro & "%'"
    '        condicion &= ") "
    '    End If

    '    cargarGridGen(dgvDepartamento, condicion, obj)
    'End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of LiderDepartamento))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "LiderDepartamento"
            conex.accion = accion

            conex.agregaCampo("tipoLider", tipoLider, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idDepartamento", idDepartamento, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idLiderDepartamento = " & idLiderDepartamento

            conex.armarQry()
            'InputBox("", "", conex.Qry)
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
                idLiderDepartamento = conex.reader("ID")
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

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idLiderDepartamento & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
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

End Class
