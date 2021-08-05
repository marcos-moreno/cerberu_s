Imports System.Xml
Imports Npgsql

Public Class ConexionPG
    Private servidorConex As New List(Of String)
    Public nameConeccion As String
    Private baseConex As New List(Of String)
    Private passwordConex As New List(Of String)
    Private userConex As New List(Of String)
    Private searchPath As New List(Of String)
    Private puerto As New List(Of Integer)

    Public conn As New List(Of NpgsqlConnection)
    Public idError As Integer
    Public descripError As String

    Public reader As NpgsqlDataReader
    Public Qry As String

    'Arma Qry
    Public accion As String  'Es un INSERT, UPDATE, SELECT
    Public condicion As String 'WHERE
    Public tabla As String
    Private campos As New List(Of String)
    Private valores As New List(Of Object)
    Private esFuncionSQL As New List(Of Boolean)
    Public insertConSelect As Boolean
    Public numCon As Integer
    Public estadoConn As New List(Of Boolean)
    Public conexBuild As New List(Of NpgsqlConnectionStringBuilder)
    Private archivoXML As String = ""

    Public Sub cargarGridConexiones(archivo As String, dgv As DataGridView)
        Dim dtb As New DataTable("Conexiones")
        Dim row As DataRow
        Dim m_xmld As New XmlDocument
        Dim contador As Integer

        contador = 1

        dtb.Columns.Add("Num.", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Archivo", Type.GetType("System.String"))

        Try
            m_xmld.Load(archivo)
        Catch ex As Exception
            MsgBox("Ocurrio un error al leer el XML: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Dim servidor = m_xmld.GetElementsByTagName("servidor")

        Try
            For Each m_node As XmlNode In servidor

                row = dtb.NewRow
                row("Num.") = contador
                row("Nombre") = m_node.Attributes.GetNamedItem("nombre").Value
                row("Archivo") = m_node.Attributes.GetNamedItem("archivo").Value

                dtb.Rows.Add(row)

                contador += 1
            Next

            dgv.DataSource = dtb
            'dgv.Columns(0).Visible = False

            'Bloquear REORDENAR
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch e As Exception
            MsgBox("Ocurrio un error intentando leer: " & e.Message)
        End Try
    End Sub

    Public Sub agregaCampo(campo As String, valor As Object, puedeSerNulo As Boolean, esFuncionSQL As Boolean) 'PARA INSERT, UPDATE
        Try
            If valor.GetType.Name = "Boolean" Then
                If Convert.ChangeType(valor, valor.GetType()) = True Then
                    valor = True
                Else
                    valor = False
                End If
            End If
        Catch ex As Exception

        End Try

        If puedeSerNulo Then
            Try
                If valor.GetType().Name = "Date" Then
                    If Convert.ChangeType(valor, valor.GetType()) = DateTimePicker.MinimumDateTime Then 'VALIDA FECHA
                        Me.campos.Add(campo)
                        Me.valores.Add("NULL")
                        Me.esFuncionSQL.Add(True)
                    Else
                        Me.campos.Add(campo)
                        Me.valores.Add(valor)
                        Me.esFuncionSQL.Add(esFuncionSQL)
                    End If
                ElseIf Not Convert.ChangeType(valor, valor.GetType()) = Nothing Then
                    Me.campos.Add(campo)
                    Me.valores.Add(valor)
                    Me.esFuncionSQL.Add(esFuncionSQL)
                Else
                    Me.campos.Add(campo)
                    Me.valores.Add("NULL")
                    Me.esFuncionSQL.Add(True)
                End If
            Catch ex As Exception
                Me.campos.Add(campo)
                Me.valores.Add("NULL")
                Me.esFuncionSQL.Add(True)
            End Try
        Else
            Me.campos.Add(campo)
            Me.valores.Add(valor)
            Me.esFuncionSQL.Add(esFuncionSQL)
        End If

    End Sub

    Public Sub agregaCampo(campo As String) ' PARA SELECT
        campos.Add(campo)
    End Sub

    Public Sub armarQry()
        'INSERT INTO tabla () VALUES ()
        'UPDATE tabla SET campo='valor', campoN='valorN'

        If UCase(Trim(accion)) = "INSERT" Then
            Qry = "INSERT INTO " & tabla & "("

            For i As Integer = 0 To campos.Count - 1
                Qry &= campos.Item(i) & ","
            Next

            If insertConSelect Then
                Qry &= ") SELECT "
            Else
                Qry &= ") VALUES ("
            End If

            Qry = Qry.Replace(",)", ")")

            For i As Integer = 0 To valores.Count - 1
                Try
                    If valores.Item(i).GetType.Name = "String" And Not esFuncionSQL.Item(i) Then
                        Qry &= "'" & valores.Item(i) & "',"
                    Else
                        If valores.Item(i).GetType.Name = "Date" Then
                            Qry &= "'" & Format(valores.Item(i), "yyyy-MM-dd") & "'::date,"
                        ElseIf valores.Item(i).GetType.Name = "DateTime" Then
                            Qry &= "'" & Format(valores.Item(i), "yyyy-MM-dd HH:mm:ss") & "'::timestamp,"
                        Else
                            Qry &= Convert.ChangeType(valores.Item(i), valores.Item(i).GetType()) & ","
                        End If
                    End If
                Catch ex As Exception
                    Qry &= "'" & valores.Item(i) & "',"
                End Try
            Next

            Qry &= ")"

            If insertConSelect Then
                Qry = Qry.Replace(",)", "")
                Qry &= " " & condicion
            Else
                Qry = Qry.Replace(",)", ")")
            End If

        ElseIf UCase(Trim(accion)) = "UPDATE" Then
            Qry = "UPDATE " & tabla & " SET "

            For i As Integer = 0 To valores.Count - 1
                If valores.Item(i).GetType.Name = "String" And Not esFuncionSQL.Item(i) Then
                    Qry &= campos.Item(i) & "='" & valores.Item(i) & "',"
                Else
                    If valores.Item(i).GetType.Name = "Date" Then
                        Qry &= campos.Item(i) & "=" & "'" & Format(valores.Item(i), "yyyy-MM-dd") & "'::date,"
                    ElseIf valores.Item(i).GetType.Name = "DateTime" Then
                        Qry &= campos.Item(i) & "=" & "'" & Format(valores.Item(i), "yyyy-MM-dd HH:mm:ss") & "'::timestamp,"
                    Else
                        Qry &= campos.Item(i) & "=" & Convert.ChangeType(valores.Item(i), valores.Item(i).GetType()) & ","
                    End If
                End If
            Next

            Qry &= "--Final" & condicion

            Qry = Qry.Replace(",--Final", " ")
        ElseIf UCase(Trim(accion)) = "SELECT" Then
            Qry = "SELECT "

            For i As Integer = 0 To campos.Count - 1
                Qry &= campos.Item(i) & ","
            Next

            Qry &= "--Final"
            Qry = Qry.Replace(",--Final", " ")

            Qry &= "FROM " & tabla & " " & condicion
        ElseIf UCase(Trim(accion)) = "DELETE" Then
            Qry = "DELETE FROM " & tabla & " " & condicion
        End If

        campos.Clear()
        valores.Clear()
        esFuncionSQL.Clear()
        insertConSelect = False
    End Sub

    'Construcctor
    Public Sub New(baseDatos As String, archivoXML As String)
        Dim connBuild As New NpgsqlConnectionStringBuilder

        Me.archivoXML = archivoXML
        estadoConn.Clear()

        If datosConfig() Then
            conn.Add(New NpgsqlConnection)

            connBuild.Host = servidorConex.Item(0)
            connBuild.Database = baseDatos
            connBuild.Username = userConex.Item(0)
            connBuild.Password = passwordConex.Item(0)
            connBuild.SearchPath = searchPath.Item(0)
            connBuild.Port = puerto(0)

            conexBuild.Add(connBuild)

            If abreConn(conn(0), connBuild.ConnectionString) Then
                estadoConn.Add(True)
            Else
                estadoConn.Add(False)
            End If
        End If
    End Sub

    Public Sub New(archivoXML As String, NConn As Integer)
        Dim connBuild As New NpgsqlConnectionStringBuilder
        Me.archivoXML = archivoXML
        estadoConn.Clear()
        If datosConfig() Then
            For i As Integer = 0 To NConn - 1
                conn.Add(New NpgsqlConnection)
                connBuild.Host = servidorConex.Item(0)
                connBuild.Database = baseConex.Item(0)
                connBuild.Username = userConex.Item(0)
                connBuild.Password = passwordConex.Item(0)
                connBuild.SearchPath = searchPath.Item(0)
                connBuild.Port = puerto(0)
                conexBuild.Add(connBuild)
                If abreConn(conn(i), connBuild.ConnectionString) Then
                    estadoConn.Add(True)
                Else
                    estadoConn.Add(False)
                End If
            Next
        End If
    End Sub

    Public Sub New(xmlConexiones As String, dgv As DataGridView)
        cargarGridConexiones(xmlConexiones, dgv)
    End Sub

    Public Sub New(host As String, database As String, user As String, password As String, searchPath As String, puerto As Integer, NConn As Integer)
        Dim connBuild As New NpgsqlConnectionStringBuilder

        Me.archivoXML = archivoXML
        estadoConn.Clear()
        For i As Integer = 0 To NConn - 1
            conn.Add(New NpgsqlConnection)

            connBuild.Host = host
            connBuild.Database = database
            connBuild.Username = user
            connBuild.Password = password
            connBuild.SearchPath = searchPath
            connBuild.Port = puerto

            conexBuild.Add(connBuild)

            If abreConn(conn(i), connBuild.ConnectionString) Then
                estadoConn.Add(True)
            Else
                estadoConn.Add(False)
            End If
        Next
    End Sub

    '***********
    Private Function abreConn(nConn As NpgsqlConnection, cadena As String) As Boolean
        idError = 0
        descripError = ""

        If nConn.State = ConnectionState.Closed Then
            Try
                nConn.ConnectionString = cadena
                nConn.Open()
            Catch e As Exception
                idError = e.HResult
                descripError = e.Message
                Return False
            End Try
        End If
        Return True
    End Function

    Public Sub cerrarTodo()
        For i As Integer = 0 To conn.Count - 1
            cerrarConexiones(conn(i))
        Next
    End Sub


    Private Sub cerrarConexiones(nConn As NpgsqlConnection)
        If nConn.State = ConnectionState.Open Then
            nConn.Close()
        End If
    End Sub

    Public Function ejecutaConsulta() As Boolean
        idError = 0
        descripError = ""

        Dim reader As NpgsqlDataReader = Nothing

        Try
            Dim command As New NpgsqlCommand(Qry, conn(numCon))
            reader = command.ExecuteReader()
            Me.reader = reader
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function


    Public Function ejecutaQryIMG(Datos As Byte()) As Boolean 'Requiere el parametroByte 
        idError = 0
        descripError = ""

        Dim reader As NpgsqlDataReader = Nothing

        Try
            Dim command As New NpgsqlCommand(Qry, conn(numCon))
            command.Parameters.AddWithValue("@Datos", Datos)
            reader = command.ExecuteReader()
            Me.reader = reader
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function
    Public Function ejecutaQry(Datos As Byte()) As Boolean 'Requiere el parametroByte
        idError = 0
        descripError = ""

        Try
            Dim command As New NpgsqlCommand()
            command.CommandText = Qry
            command.Connection = conn(numCon)
            command.Parameters.AddWithValue("@Datos", Datos)

            command.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function


    Public Function ejecutaConsultaDS(soloLect As Boolean) As DataSet
        idError = 0
        descripError = ""

        Dim dataadapter As NpgsqlDataAdapter = Nothing
        Dim ds As DataSet = Nothing

        Try
            dataadapter = New NpgsqlDataAdapter(Qry, conn(numCon))
            ds = New DataSet()
            dataadapter.Fill(ds, "dataTable")

            If soloLect Then
                For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
                    ds.Tables(0).Columns(i).ReadOnly = True
                Next
            End If

        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
        End Try

        Return ds
    End Function

    Function ejecutaQry() As Boolean
        idError = 0
        descripError = ""

        Try
            Dim myCommand As New NpgsqlCommand(Qry)

            myCommand.Connection = conn(numCon)
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    Function ejecutaQryConVerif() As Boolean
        idError = 0
        descripError = ""

        Try
            Dim myCommand As New NpgsqlCommand(Qry)

            myCommand.Connection = conn(numCon)
            If myCommand.ExecuteNonQuery() <> 1 Then
                idError = 1
                descripError = "El registro, no fue Insertado bajo las condiciones establecidas..."
                Return False
            End If
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    Private Function datosConfig()
        Dim bandera As Boolean = True
        Dim encrip As New Encriptar
        Dim Url = archivoXML
        Dim m_xmld As New XmlDocument
        Try
            m_xmld.Load(Url)
        Catch ex As Exception
            MsgBox("Ocurrio un error al leer el XML: " & ex.Message, MsgBoxStyle.Exclamation)
            bandera = False
        End Try

        Dim servidor = m_xmld.GetElementsByTagName("servidor")

        Try
            For Each m_node As XmlNode In servidor
                servidorConex.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("nombre").Value))
                baseConex.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("base").Value))
                passwordConex.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("password").Value))
                userConex.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("username").Value))
                searchPath.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("pathSearch").Value))
                puerto.Add(encrip.Desencriptar(m_node.Attributes.GetNamedItem("puerto").Value))
            Next
        Catch e As Exception
            MsgBox("Ocurrio un error intentando leer: " & e.Message)
            bandera = False
        End Try
        Return bandera
    End Function

    Public Function ejecutaSP(parametros As Object(,)) As Boolean
        idError = 0
        descripError = ""
        Try
            Dim cmd = New NpgsqlCommand()
            cmd.CommandText = Qry
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn(numCon)

            For x As Integer = 0 To parametros.GetLength(0) - 2
                cmd.Parameters.AddWithValue(parametros(x, 0).ToString(), parametros(x, 1))
            Next

            reader = cmd.ExecuteReader()
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    Public Function ejecutaSP(parametros As Object(,), parametrosOUT As Object(,)) As Boolean
        idError = 0
        descripError = ""
        Try
            Dim cmd = New NpgsqlCommand()
            cmd.CommandText = Qry
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn(numCon)

            For x As Integer = 0 To parametros.GetLength(0) - 2
                cmd.Parameters.AddWithValue(parametros(x, 0).ToString(), parametros(x, 1))
            Next


            Dim param As NpgsqlParameter
            For x As Integer = 0 To parametrosOUT.GetLength(0) - 2
                param = New NpgsqlParameter(parametrosOUT(x, 0).ToString(), parametrosOUT(x, 1))
                param.Direction = ParameterDirection.Output
                cmd.Parameters.Add(param)
            Next

            reader = cmd.ExecuteReader()

            For x As Integer = 0 To parametrosOUT.GetLength(0) - 2
                parametrosOUT(x, 1) = cmd.Parameters(parametrosOUT(x, 0).ToString()).Value.ToString()
            Next
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    Public Function ejecutaSP() As Boolean
        idError = 0
        descripError = ""
        Try
            Dim cmd As NpgsqlCommand = New NpgsqlCommand()
            cmd.CommandText = Qry
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn(numCon)
            reader = cmd.ExecuteReader()
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function
End Class
