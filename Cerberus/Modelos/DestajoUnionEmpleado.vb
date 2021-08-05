Imports System.Data.SqlClient
Imports Cerberus

Public Class DestajoUnionEmpleado
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idEmpleado As Integer
    Public referenciaExterna As String
    Public origen As String
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of DestajoUnionEmpleado))
        Dim filtro As String
        filtro = "WHERE idEmpleado = " & idEmpleado & " AND origen = '" & origen & "' AND idEmpresa = " & idEmpresa & ""

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of DestajoUnionEmpleado), filtro As String)
        Dim plantilla As DestajoUnionEmpleado
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM DestajoUnionEmpleado " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoUnionEmpleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.origen)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DestajoUnionEmpleado.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of DestajoUnionEmpleado))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of DestajoUnionEmpleado))
        Dim plantilla As DestajoUnionEmpleado
        Dim dtb As New DataTable("DestajoUnionEmpleado")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Clasificacion", Type.GetType("System.Int32"))
        dtb.Columns.Add("Origen", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Es Activo", Type.GetType("System.Boolean"))

        objEmp.Clear()

        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            condicion &= " AND E.idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If

        conex.Qry = "SELECT D.*,concat('(',E.idEmpleado,') ',E.nombreEmpleado,' ',E.apPatEmpleado,' ',E.apMatEmpleado) as nEmpl FROM DestajoUnionEmpleado as D,Empleado as E WHERE  E.idEmpleado = D.idEmpleado AND D.idEmpresa = " & idEmpresa & " AND D.origen='" & origen & "' " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DestajoUnionEmpleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Clasificacion") = plantilla.idEmpleado
                row("Origen") = plantilla.origen
                row("Empleado") = conex.reader("nEmpl")
                row("Es Activo") = plantilla.esActivo

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
            Mensaje.origen = "DestajoUnionEmpleado.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "DestajoUnionEmpleado"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("referenciaExterna", referenciaExterna, False, False)
            conex.agregaCampo("origen", origen, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEmpleado = " & idEmpleado & " AND origen = '" & origen & "' AND idEmpresa = " & idEmpresa

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEmpleado = rdr("idEmpleado")
        referenciaExterna = rdr("referenciaExterna")
        origen = rdr("origen")
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
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
        conex.numCon = 0
        conex.tabla = "DestajoUnionEmpleado"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idEmpleado=" & idEmpleado & " AND origen='" & origen & "' AND idEmpresa=" & idEmpresa

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

    Public Function buscarPREF() As Boolean
        conex.numCon = 0
        conex.tabla = "DestajoUnionEmpleado"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE referenciaExterna=" & referenciaExterna & " AND origen='" & origen & "' AND idEmpresa=" & idEmpresa

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se encontro la referencia: """ & referenciaExterna & """ (" & origen & ")"
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
        Return "ID: " & idEmpleado & "/" & origen & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        If referenciaExterna = Nothing Then
            idError = 1
            descripError = "La referencia es un CAMPO obligatorio..."
            Return False
        End If
        If idEmpleado = Nothing Then
            idError = 2
            descripError = "El empleado es un CAMPO obligatorio..."
            Return False
        End If
        If origen = Nothing Then
            idError = 3
            descripError = "El origen es un CAMPO obligatorio..."
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
End Class
