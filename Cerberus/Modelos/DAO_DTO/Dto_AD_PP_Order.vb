Public Class Dto_AD_PP_Order

	Private _Organizacion As String
	Private _PagoDestajo As Integer
	Private _PagoTotal As String
	Private _FechaPago As Date
	Private _Colaborador As String
	Private _CURP As String
	Private _SeguroSocial As String
	Private _OrdenManoFactura As String
	Private _TotalesFinales As String
	Private _CalculoTotalFinal As String
	Private _PP_Cost_Collector_ID As String
	Private _Identificationmark As String

	Public Property Organizacion As String
		Get
			Return _Organizacion
		End Get
		Set(value As String)
			_Organizacion = value
		End Set
	End Property

	Public Property PagoDestajo As Integer
		Get
			Return _PagoDestajo
		End Get
		Set(value As Integer)
			_PagoDestajo = value
		End Set
	End Property

	Public Property PagoTotal As String
		Get
			Return _PagoTotal
		End Get
		Set(value As String)
			_PagoTotal = value
		End Set
	End Property

	Public Property FechaPago As Date
		Get
			Return _FechaPago
		End Get
		Set(value As Date)
			_FechaPago = value
		End Set
	End Property

	Public Property Colaborador As String
		Get
			Return _Colaborador
		End Get
		Set(value As String)
			_Colaborador = value
		End Set
	End Property

	Public Property CURP As String
		Get
			Return _CURP
		End Get
		Set(value As String)
			_CURP = value
		End Set
	End Property

	Public Property SeguroSocial As String
		Get
			Return _SeguroSocial
		End Get
		Set(value As String)
			_SeguroSocial = value
		End Set
	End Property

	Public Property OrdenManoFactura As String
		Get
			Return _OrdenManoFactura
		End Get
		Set(value As String)
			_OrdenManoFactura = value
		End Set
	End Property

	Public Property TotalesFinales As String
		Get
			Return _TotalesFinales
		End Get
		Set(value As String)
			_TotalesFinales = value
		End Set
	End Property

	Public Property CalculoTotalFinal As String
		Get
			Return _CalculoTotalFinal
		End Get
		Set(value As String)
			_CalculoTotalFinal = value
		End Set
	End Property

	Public Property PP_Cost_Collector_ID As String
		Get
			Return _PP_Cost_Collector_ID
		End Get
		Set(value As String)
			_PP_Cost_Collector_ID = value
		End Set
	End Property

	Public Property Identificationmark As String
		Get
			Return _Identificationmark
		End Get
		Set(value As String)
			_Identificationmark = value
		End Set
	End Property
End Class
