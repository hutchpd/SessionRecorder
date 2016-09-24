Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace SessionRecorder
	Public Class SessionStats
		Public SessionDateTime As DateTime

		Public Duration As Integer

		Public ActualDuration As Integer

		Public Distance As Double

		Public NumStrokes As Integer

		Public SpeedMin As Double

		Public SpeedMax As Double

		Public SPMMin As Double

		Public SPMMax As Double

		Private SPMTotal As Double

		Public CalsMin As Double

		Public CalsMax As Double

		Public CalsTotal As Double

		Public PowerMin As Double

		Public PowerMax As Double

		Public EnergyTotal As Double

		Public HeartRateMin As Double

		Public HeartRateMax As Double

		Private HeartRateTotal As Double

		Private SessionLevel As Integer

		Private SessionDevice As Integer

		Private numHRSamples As Integer

		Public ReadOnly Property CalsHrAvg As Double
			Get
				Return Conversions.ToDouble(Interaction.IIf(Me.ActualDuration > 0, Me.CalsTotal / (CDbl(Me.ActualDuration) / 3600), 0))
			End Get
		End Property

		Public Property Device As Integer
			Get
				Return Me.SessionDevice
			End Get
			Set(ByVal value As Integer)
				Me.SessionDevice = value
			End Set
		End Property

		Public ReadOnly Property HeartRateAvg As Double
			Get
				Return Conversions.ToDouble(Interaction.IIf(Me.numHRSamples > 0, Me.HeartRateTotal / CDbl(Me.numHRSamples), 0))
			End Get
		End Property

		Public Property Level As Integer
			Get
				Return Me.SessionLevel
			End Get
			Set(ByVal value As Integer)
				Me.SessionLevel = value
			End Set
		End Property

		Public ReadOnly Property PowerAvg As Double
			Get
				Return Conversions.ToDouble(Interaction.IIf(Me.ActualDuration > 0, Me.EnergyTotal / CDbl(Me.ActualDuration), 0))
			End Get
		End Property

		Public ReadOnly Property SpeedAvg As Double
			Get
				Return Conversions.ToDouble(Interaction.IIf(Me.Distance > 0, CDbl((500 * Me.ActualDuration)) / Me.Distance, 0))
			End Get
		End Property

		Public ReadOnly Property SPMAvg As Double
			Get
				Return Conversions.ToDouble(Interaction.IIf(Me.ActualDuration > 0, CDbl((60 * Me.NumStrokes)) / CDbl(Me.ActualDuration), 0))
			End Get
		End Property

		Public Property TotalCals As Integer
			Get
				Return CInt(Math.Round(Me.CalsTotal))
			End Get
			Set(ByVal value As Integer)
				Me.CalsTotal = CDbl(value)
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.numHRSamples = 0
		End Sub

		Public Sub IncDuration()
			Me.Duration = Me.Duration + 1
		End Sub

		Public Sub Reset()
			Me.SessionDateTime = DateAndTime.Now
			Me.Duration = 0
			Me.Distance = 0
			Me.NumStrokes = 0
			Me.SpeedMin = 99999
			Me.SpeedMax = 0
			Me.SPMMin = 99999
			Me.SPMMax = 0
			Me.SPMTotal = 0
			Me.PowerMin = 99999
			Me.PowerMax = 0
			Me.EnergyTotal = 0
			Me.CalsMin = 99999
			Me.CalsMax = 0
			Me.CalsTotal = 0
			Me.HeartRateMin = 99999
			Me.HeartRateMax = 0
			Me.HeartRateTotal = 0
			Me.numHRSamples = 0
		End Sub

		Public Sub UpdateHR(ByVal HR As Integer)
			If (CDbl(HR) < Me.HeartRateMin) Then
				Me.HeartRateMin = CDbl(HR)
			End If
			If (CDbl(HR) > Me.HeartRateMax) Then
				Me.HeartRateMax = CDbl(HR)
			End If
			Me.HeartRateTotal = Me.HeartRateTotal + CDbl(HR)
			Me.numHRSamples = Me.numHRSamples + 1
		End Sub

		Public Sub UpdateStroke(ByRef strokeData As StrokeInstance)
			Me.ActualDuration = CInt(Math.Round(strokeData.Time))
			Me.Distance = strokeData.Distance
			If (strokeData.Speed < Me.SpeedMin) Then
				Me.SpeedMin = strokeData.Speed
			End If
			If (strokeData.Speed > Me.SpeedMax) Then
				Me.SpeedMax = strokeData.Speed
			End If
			If (Me.SPMMin = 0 Or strokeData.SPM < Me.SPMMin) Then
				Me.SPMMin = strokeData.SPM
			End If
			If (strokeData.SPM > Me.SPMMax) Then
				Me.SPMMax = strokeData.SPM
			End If
			Me.SPMTotal = Me.SPMTotal + strokeData.SPM
			If (strokeData.Power < Me.PowerMin) Then
				Me.PowerMin = strokeData.Power
			End If
			If (strokeData.Power > Me.PowerMax) Then
				Me.PowerMax = strokeData.Power
			End If
			If (strokeData.Cals < Me.CalsMin) Then
				Me.CalsMin = strokeData.Cals
			End If
			If (strokeData.Cals > Me.CalsMax) Then
				Me.CalsMax = strokeData.Cals
			End If
			If (strokeData.SPM > 0) Then
				Me.CalsTotal = Me.CalsTotal + strokeData.Cals / (60 * strokeData.SPM)
				Me.EnergyTotal = Me.EnergyTotal + strokeData.Power / (strokeData.SPM / 60)
			End If
			Me.NumStrokes = Me.NumStrokes + 1
		End Sub
	End Class
End Namespace