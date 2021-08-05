Imports System.Data.SqlClient
Imports Cerberus

Public Class Tabulador
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado

    Public idTabulador As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public esActivo As Boolean
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public nombreTabulador As String
    Public idNivelPuesto As Integer
    Public idError As Integer
    Public descripError As String

    Private objTabVer As TabuladorVersion

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function getVersionActual() As TabuladorVersion
        If objTabVer Is Nothing Then
            objTabVer = New TabuladorVersion(Ambiente)
            objTabVer.idTabulador = idTabulador
            objTabVer.buscarActualXFecha(Now)
        End If
        Return objTabVer
    End Function

    Public Function getVersionActualXFecha(fecha As Date) As TabuladorVersion
        objTabVer = New TabuladorVersion(Ambiente)
        objTabVer.idTabulador = idTabulador
        objTabVer.buscarActualXFecha(fecha)
        Return objTabVer
    End Function

    'Clase especifica de Tabulador Activas >>>
    Public Sub getComboActivoPorNivel(combo As ComboBox, idCombos As List(Of Tabulador), idNivel As Integer, idTabulador As Integer)
        Dim filtro As String
        If idNivel = 0 Then
            filtro = "WHERE t.esActivo = 1 AND t.idEmpresa=" & idEmpresa & " AND t.idTabulador=" & idTabulador
            getCombo(combo, idCombos, filtro, Now)
        Else
            filtro = " WHERE t.esActivo = 1 AND t.idEmpresa=" & idEmpresa & "  AND
                        (t.idNivelPuesto = " & idNivel & " 
                            OR (SELECT nivel FROM
                                    NivelPuesto n 
                                WHERE  
                                n.idNivelPuesto = " & idNivel & ") = 'SIN ASIGNAR'
                        )"
            getCombo(combo, idCombos, filtro, Now)
        End If
    End Sub

    'Clase especifica de Tabulador Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Tabulador))
        Dim filtro As String
        filtro = "WHERE t.esActivo = 1 AND t.idEmpresa=" & idEmpresa

        getCombo(combo, idCombos, filtro, Now)
    End Sub

    Public Sub getComboActivoFecha(combo As ComboBox, idCombos As List(Of Tabulador), fecha As Date)
        Dim filtro As String
        filtro = "WHERE t.esActivo = 1 AND t.idEmpresa=" & idEmpresa

        getCombo(combo, idCombos, filtro, fecha)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Tabulador), filtro As String, fecha As Date)
        Dim plantilla As Tabulador
        combo.Items.Clear()
        idCombos.Clear()

        'conex.Qry = "SELECT *,ISNULL((select top 1 sueldo from TabuladorVersion 
        '                WHERE TabuladorVersion.idTabulador = Tabulador.idTabulador 
        '             AND CONVERT(date,'" & Format(fecha, "yyyy-MM-dd") & "') >= validoDesde order by validoDesde desc),0) 
        '             SueldoAct FROM Tabulador " & filtro & " 
        '             ORDER BY orden asc,nombreTabulador"

        conex.Qry = "
            SELECT 
	            ISNULL((select top 1 sueldo from TabuladorVersion 
                                    WHERE TabuladorVersion.idTabulador = t.idTabulador 
                                    AND CONVERT(date,'" & Format(fecha, "yyyy-MM-dd") & "') >= validoDesde order by validoDesde desc),0
		            )SueldoAct 
					  
            ,t.*,COALESCE(np.nivel,'') nivel
            FROM Tabulador t 
            LEFT JOIN NivelPuesto np ON np.idNivelPuesto = t.idNivelPuesto
            " & filtro & " 
            ORDER BY t.idNivelPuesto,orden asc
            "
        conex.numCon = 0
        'InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Tabulador(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreTabulador & "  -  (" & FormatCurrency(conex.reader("SueldoAct")) & ") (" & conex.reader("nivel") & ")")
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Tabulador.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTabulador = rdr("idTabulador")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        esActivo = rdr("esActivo")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        nombreTabulador = rdr("nombreTabulador")
        idNivelPuesto = If(IsDBNull(rdr("idNivelPuesto")), Nothing, rdr("idNivelPuesto"))

    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return ejecutaQry("INSERT", True)
    End Function

    Private Function ejecutaQry(accion As String, esInsert As Boolean) As Boolean
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Tabulador"
            conex.accion = accion

            conex.agregaCampo("nombreTabulador", nombreTabulador, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idNivelPuesto", idNivelPuesto, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            conex.condicion = "WHERE idTabulador =" & idTabulador

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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Tabulador), busqueda As String)
        Dim condicion As String
        condicion = ""

        If Not busqueda = Nothing Then
            busqueda = busqueda.Replace("*", "%")
            condicion = " AND (t.nombreTabulador like '%" & busqueda & "%' "
            condicion &= ")"
        End If

        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Tabulador))
        Dim plantilla As Tabulador
        Dim dtb As New DataTable("Tabulador")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID Tabulador", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Es Activo", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = "SELECT t.*,ni.nivel FROM Tabulador AS t 
                    LEFT JOIN NivelPuesto ni ON t.idNivelPuesto = ni.idNivelPuesto
                    WHERE t.idEmpresa =" & idEmpresa & " " & condicion
        'InputBox("", "", conex.Qry)
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Tabulador(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID Tabulador") = plantilla.idTabulador
                row("Nombre") = plantilla.nombreTabulador & " " & conex.reader("nivel")
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
            Mensaje.origen = "Tabulador.cargarGridGen"
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
        conex.tabla = "Tabulador"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idTabulador=" & idTabulador

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

    Public Function tabuladorDefault() As Boolean
        conex.numCon = 0
        conex.tabla = "Tabulador"
        conex.accion = "SELECT"

        conex.agregaCampo("TOP 1 *")
        conex.condicion = "WHERE idEmpresa=" & idEmpresa & " and esActivo = 1 ORDER By idTabulador ASC"

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
        If nombreTabulador = Nothing Then
            idError = 1
            descripError = "El nombre del tabulador es un CAMPO obligatorio..."
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
