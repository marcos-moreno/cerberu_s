Imports System.Data.SqlClient
Imports Cerberus
Public Class Telefonia
    Implements InterfaceTablas
    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idTelefonia As Integer
    Public idEmpresa As Integer
    Public idEmpleado As Integer
    Public idSucursal As Integer
    Public idPlan As Integer
    Public idEquipoTelefonico As Integer
    Public idClasificacion As Integer
    Public telefono As String
    Public numPeriodos As Integer
    Public total As Decimal
    Public montoxperiodo As Decimal
    Public descripcion As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public estado As String
    Public noDocumentoEquipo As String
    Public noDocumentoRed As String
    Public idCompañia As Integer
    Public fechaMovimiento As DateTime
    Public tipoEquipo As String
    Public contable As Boolean
    Public color As String


    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        noDocumentoRed = IIf(rdr("noDocumentoRed") Is DBNull.Value, "", Convert.ToString(rdr("noDocumentoRed")))
        noDocumentoEquipo = IIf(rdr("noDocumentoEquipo") Is DBNull.Value, "", Convert.ToString(rdr("noDocumentoEquipo")))
        idTelefonia = rdr("idTelefonia")
        idEmpresa = rdr("idEmpresa")
        idEmpleado = rdr("idEmpleado")
        idSucursal = rdr("idSucursal")
        idPlan = IIf(rdr("idPlan") Is DBNull.Value, Nothing, Convert.ToString(rdr("idPlan")))
        idEquipoTelefonico = IIf(rdr("idEquipoTelefonico") Is DBNull.Value, Nothing, Convert.ToString(rdr("idEquipoTelefonico")))
        idClasificacion = rdr("idClasificacion")
        telefono = IIf(rdr("telefono") Is DBNull.Value, "", Convert.ToString(rdr("telefono")))
        numPeriodos = IIf(rdr("numPeriodos") Is DBNull.Value, 0, Convert.ToString(rdr("numPeriodos")))
        total = IIf(rdr("total") Is DBNull.Value, 0, Convert.ToString(rdr("total")))
        montoxperiodo = IIf(rdr("montoxperiodo") Is DBNull.Value, 0, Convert.ToString(rdr("montoxperiodo")))
        descripcion = IIf(rdr("descripcion") Is DBNull.Value, "", Convert.ToString(rdr("descripcion")))
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        estado = rdr("estado")
        idCompañia = IIf(rdr("idCompañia") Is DBNull.Value, Nothing, Convert.ToString(rdr("idCompañia")))
        fechaMovimiento = rdr("fechaMovimiento")
        tipoEquipo = IIf(rdr("tipoEquipo") Is DBNull.Value, "", Convert.ToString(rdr("tipoEquipo")))
        contable = IIf(rdr("contable") Is DBNull.Value, False, Convert.ToString(rdr("contable")))
        color = IIf(rdr("color") Is DBNull.Value, Nothing, Convert.ToString(rdr("color")))

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
            conex.tabla = "Telefonia"
            conex.accion = accion

            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idPlan", idPlan, True, False)
            conex.agregaCampo("idEquipoTelefonico", idEquipoTelefonico, True, False)
            conex.agregaCampo("idClasificacion", idClasificacion, False, False)
            conex.agregaCampo("telefono", telefono, False, False)
            conex.agregaCampo("numPeriodos", numPeriodos, False, False)
            conex.agregaCampo("total", total, False, False)
            conex.agregaCampo("montoxperiodo", montoxperiodo, False, False)
            conex.agregaCampo("descripcion", descripcion, False, False)
            conex.agregaCampo("noDocumentoEquipo", noDocumentoEquipo, False, False)
            conex.agregaCampo("noDocumentoRed", noDocumentoRed, False, False)
            conex.agregaCampo("idCompañia", idCompañia, True, False)
            conex.agregaCampo("fechaMovimiento", fechaMovimiento, False, False)
            conex.agregaCampo("Color", color, False, False)

            conex.agregaCampo("tipoEquipo", tipoEquipo, False, False)
            conex.agregaCampo("contable", contable, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            If (estado = Nothing) Then
                estado = "BO"
            End If
            conex.agregaCampo("estado", estado, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idTelefonia = " & idTelefonia
            conex.armarQry()
            '   InputBox("", "", conex.Qry)

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
                idTelefonia = conex.reader("ID")
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
        Dim value = ""
        If estado = "CO" Then
            value = "COMPLETO"
        End If
        If estado = "BO" Then
            value = "BORRADOR"
        End If
        Return value
    End Function

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Telefonia), busqueda As String)
        Dim condicion As String
        condicion = ""
        If Not busqueda = Nothing Then
            condicion = "  AND (CONCAT(emp.nombreEmpleado,' ',emp.apPatEmpleado,' ',emp.apMatEmpleado) like '%" & busqueda & "%' "
            condicion &= "OR s.nombreSucursal like '%" & busqueda & "%' "
            condicion &= "OR t.estado like '%" & busqueda & "%' "
            condicion &= "OR t.descripcion like '%" & busqueda & "%' "
            condicion &= "OR (CASE WHEN t.estado = 'CO' THEN 'COMPLETO' ELSE 'BORRADOR'  END ) LIKE '%" & busqueda & "%' "
            condicion &= "OR c.nombre  LIKE '%" & busqueda & "%' "
            condicion &= "OR t.tipoEquipo like '%" & busqueda & "%' "
            condicion &= "OR et.nombreEquipo  like '%" & busqueda & "%' "
            condicion &= ")"
        End If
        cargarGridGen(dgv, condicion, obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Telefonia))
        Dim plantilla As Telefonia
        Dim dtb As New DataTable("Telefonia")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento Red", Type.GetType("System.String"))
        dtb.Columns.Add("Documento Equipo", Type.GetType("System.String"))
        dtb.Columns.Add("Descripción", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Compañia", Type.GetType("System.String"))
        dtb.Columns.Add("Equipo", Type.GetType("System.String"))
        objEmp.Clear()

        conex.Qry = "SELECT 
                                e.razonSocial
                                ,CONCAT(emp.nombreEmpleado,' ',emp.apPatEmpleado,' ',emp.apMatEmpleado) as empleado
                                ,s.nombreSucursal
                                ,CASE WHEN t.estado = 'CO' THEN
                                'COMPLETO'
                                ELSE
                                'BORRADOR'
                                END as estatus	 
                                ,t.*
                                ,c.nombre as compañia
                                ,et.nombreEquipo 
                          FROM Telefonia t
                          INNER JOIN Empresa e
                          ON e.idEmpresa = t.idEmpresa
                          INNER JOIN Empleado emp
                          ON emp.idEmpleado = t.idEmpleado
                          INNER JOIN Sucursal s
                          ON s.idSucursal = t.idSucursal  
                          LEFT JOIN Compañia c
						  ON c.idCompañia = t.idCompañia
                          LEFT JOIN EquipoTelefonico et
						  ON et.idEquipoTelefonico  = t.idEquipoTelefonico

                            WHERE t.idEmpresa=" & idEmpresa & condicion

        conex.numCon = 0
        ' InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Telefonia(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento Red") = plantilla.noDocumentoRed
                row("Documento Equipo") = plantilla.noDocumentoEquipo
                row("Descripción") = plantilla.descripcion
                row("Sucursal") = conex.reader("nombreSucursal")
                row("Empleado") = conex.reader("empleado")
                row("Fecha") = Format(plantilla.fechaMovimiento, "dd/MM/yyyy")
                row("Estado") = conex.reader("estatus")
                row("Compañia") = conex.reader("compañia")
                row("Equipo") = conex.reader("nombreEquipo")
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
            Mensaje.origen = "Telefonia.cargarGridGen"
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
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
            noDocumentoRed = "No creado"
            noDocumentoEquipo = "No creado"
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
End Class
