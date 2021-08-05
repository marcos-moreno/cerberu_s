Public Class Dao_AD_PP_Order

	Public idError As Integer
	Public descripError As String
	Private _context As AmbienteCls
	Private _dto_AD_PP_Order As Dto_AD_PP_Order
	Private _ListOf_Dto_AD_PP As List(Of Dto_AD_PP_Order)
	Private _ListOfDistinct_C_Payment_ID As List(Of String)
	Private _C_Payment_ID As Integer
	Private conPgSQL As ConexionPG

	Public Sub New(Ambiente As AmbienteCls, conPgSQL As ConexionPG)
		Me._context = Ambiente
		Me.conPgSQL = conPgSQL
		_ListOf_Dto_AD_PP = New List(Of Dto_AD_PP_Order)
	End Sub

	Public Property Dto_AD_PP_Order As Dto_AD_PP_Order
		Get
			Return _dto_AD_PP_Order
		End Get
		Set(value As Dto_AD_PP_Order)
			_dto_AD_PP_Order = value
		End Set
	End Property

	Public Property ListOf_Dto_AD_PP As List(Of Dto_AD_PP_Order)
		Get
			Return _ListOf_Dto_AD_PP
		End Get
		Set(value As List(Of Dto_AD_PP_Order))
			_ListOf_Dto_AD_PP = value
		End Set
	End Property


	Public Property C_Payment_ID As Integer
		Get
			Return _C_Payment_ID
		End Get
		Set(value As Integer)
			_C_Payment_ID = value
		End Set
	End Property

	Public Property ListOfDistinct_C_Payment_ID As List(Of String)
		Get
			Return _ListOfDistinct_C_Payment_ID
		End Get
		Set(value As List(Of String))
			_ListOfDistinct_C_Payment_ID = value
		End Set
	End Property

	Protected Friend Function consult_AD_PP_Order(idOrgSelected As Integer) As Boolean
		Me.conPgSQL.numCon = 0
		Me.conPgSQL.Qry = Replace(Replace(_qry, "#####", _C_Payment_ID), "idOrgSelected", idOrgSelected)

		'InputBox("", "", Me.conPgSQL.Qry)

		Try
			Me.conPgSQL.reader.Close()
		Catch ex As Exception
		End Try
		If Me.conPgSQL.ejecutaConsulta Then
			While Me.conPgSQL.reader.Read
				seteaDatos(Me.conPgSQL.reader)
			End While
			Me.conPgSQL.reader.Close()
			Return True
		Else
			Me.conPgSQL.reader.Close()
			idError = Me.conPgSQL.idError
			descripError = Me.conPgSQL.descripError
			Mensaje.Mensaje = "Error:" & descripError
			Mensaje.tipoMsj = TipoMensaje.Error
			Mensaje.ShowDialog()
			Return False
		End If
		Return True
	End Function


	Protected Friend Function consult_Distinct_C_Payment_ID(idOrgSelected As Integer) As Boolean
		Try
			Me.conPgSQL.reader.Close()
		Catch ex As Exception
		End Try
		_ListOfDistinct_C_Payment_ID = New List(Of String)
		Me.conPgSQL.numCon = 0
		Me.conPgSQL.Qry = Replace(_qry_0, "idOrgSelected", idOrgSelected)
		'InputBox("", "", Me.conPgSQL.Qry)
		If Me.conPgSQL.ejecutaConsulta Then
			While Me.conPgSQL.reader.Read
				_ListOfDistinct_C_Payment_ID.Add(Me.conPgSQL.reader("C_Payment_ID"))
			End While
			Me.conPgSQL.reader.Close()
			Return True
		Else
			idError = Me.conPgSQL.idError
			descripError = Me.conPgSQL.descripError
			Mensaje.Mensaje = "Error:" & descripError
			Mensaje.tipoMsj = TipoMensaje.Error
			Mensaje.ShowDialog()
			Return False
		End If
		Return True
	End Function

	Public Sub seteaDatos(rdr As Npgsql.NpgsqlDataReader)
		_dto_AD_PP_Order = New Dto_AD_PP_Order

		_dto_AD_PP_Order.Organizacion = If(rdr("Organizacion").Equals(DBNull.Value), Nothing, rdr("Organizacion"))
		_dto_AD_PP_Order.PagoDestajo = If(rdr("PagoDestajo").Equals(DBNull.Value), Nothing, rdr("PagoDestajo"))
		_dto_AD_PP_Order.PagoTotal = If(rdr("PagoTotal").Equals(DBNull.Value), Nothing, rdr("PagoTotal"))

		_dto_AD_PP_Order.FechaPago = If(rdr("FechaPago").Equals(DBNull.Value), Nothing, rdr("FechaPago"))
		_dto_AD_PP_Order.Colaborador = If(rdr("Colaborador").Equals(DBNull.Value), Nothing, rdr("Colaborador"))
		_dto_AD_PP_Order.CURP = If(rdr("CURP").Equals(DBNull.Value), Nothing, rdr("CURP"))

		_dto_AD_PP_Order.SeguroSocial = If(rdr("SeguroSocial").Equals(DBNull.Value), Nothing, rdr("SeguroSocial"))
		_dto_AD_PP_Order.OrdenManoFactura = If(rdr("OrdenManoFactura").Equals(DBNull.Value), Nothing, rdr("OrdenManoFactura"))
		_dto_AD_PP_Order.TotalesFinales = If(rdr("TotalesFinales").Equals(DBNull.Value), Nothing, rdr("TotalesFinales"))

		_dto_AD_PP_Order.CalculoTotalFinal = If(rdr("CalculoTotalFinal").Equals(DBNull.Value), Nothing, rdr("CalculoTotalFinal"))

		_dto_AD_PP_Order.PP_Cost_Collector_ID = If(rdr("PP_Cost_Collector_ID").Equals(DBNull.Value), Nothing, rdr("PP_Cost_Collector_ID"))
		_ListOf_Dto_AD_PP.Add(_dto_AD_PP_Order)
	End Sub

	Protected Friend Function update_identificationmark() As Boolean
		Me.conPgSQL.reader.Close()
		Me.conPgSQL.numCon = 0
		'Me.conPgSQL.Qry = "UPDATE PP_Cost_Collector SET IsAchieved =  'Y' , identificationmark = '" & _dto_AD_PP_Order.Identificationmark &
		'							"' WHERE PP_Cost_Collector_ID = " & _dto_AD_PP_Order.PP_Cost_Collector_ID

		Me.conPgSQL.Qry = "UPDATE C_Payment SET IsAchieved =  'Y' , identificationmark = '" & _dto_AD_PP_Order.Identificationmark &
									"' WHERE documentno = '" & _dto_AD_PP_Order.PagoDestajo & "' "
		'InputBox("", "", Me.conPgSQL.Qry)
		If Me.conPgSQL.ejecutaConsulta Then
			Try
				Me.conPgSQL.reader.Close()
			Catch ex As Exception
			End Try
			Return True
		Else
			Try
				Me.conPgSQL.reader.Close()
			Catch ex As Exception
			End Try
			idError = Me.conPgSQL.idError
			descripError = Me.conPgSQL.descripError
			Return False
		End If
		Return True
	End Function

	Public Function getComboSucursales(combo As ComboBox, idCombos As List(Of Integer)) As Boolean
		combo.Items.Clear()
		idCombos.Clear()

		Try
			Me.conPgSQL.reader.Close()
		Catch ex As Exception
		End Try

		Me.conPgSQL.numCon = 0
		If _context.empr.idEmpresa = 1 Then
			Me.conPgSQL.Qry = "	SELECT  ad_org_ID,name FROM adempiere.ad_org WHERE ad_org_id IN (1000008,1000010,1000009,1000007) "
		ElseIf _context.empr.idEmpresa = 5 Then
			Me.conPgSQL.Qry = "	SELECT  ad_org_ID,name FROM adempiere.ad_org WHERE ad_org_id IN (1000007,1000009,1000010,1000008) "
		ElseIf _context.empr.idEmpresa = 9 Then
			Me.conPgSQL.Qry = "	SELECT  ad_org_ID,name FROM adempiere.ad_org WHERE ad_org_id IN (1000004) "
		End If

		If Me.conPgSQL.ejecutaConsulta Then
			While Me.conPgSQL.reader.Read
				idCombos.Add(Me.conPgSQL.reader("ad_org_ID"))
				combo.Items.Add(Me.conPgSQL.reader("name"))
			End While
			Me.conPgSQL.reader.Close()
			Return True
		Else
			idError = Me.conPgSQL.idError
			descripError = Me.conPgSQL.descripError
			Mensaje.Mensaje = "Error:" & descripError
			Mensaje.tipoMsj = TipoMensaje.Error
			Mensaje.ShowDialog()
			Return False
		End If
		Return True
	End Function


	Private _qry = "SELECT * FROM adempiere.rf_showcostcollector_mfv2('#####',idOrgSelected);"

	Private _qry_0 = "   SELECT DISTINCT(PagoDestajo)as C_Payment_ID FROM adempiere.rf_showcostcollector_mfv2('0',idOrgSelected);"

End Class
