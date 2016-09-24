Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows.Forms.DataVisualization.Charting

Namespace SessionRecorder
	Public Class GraphContainer
		Private SessionCharts As Chart

		Private StrokeIndex As Integer

		Private GraphTime As Double

		Private NoData As Boolean

		Private NoHRData As Boolean

		Private PowerRange As Integer

		Private HRRange As Integer

		Private UseLongTimeFormat As Boolean

		Private UseExtraLongTimeFormat As Boolean

		Private CurrentView As GraphContainer.GraphView

		Public Sub New(ByRef chart As System.Windows.Forms.DataVisualization.Charting.Chart)
			MyBase.New()
			Me.NoData = True
			Me.NoHRData = True
			Me.PowerRange = 200
			Me.HRRange = 100
			Me.UseLongTimeFormat = False
			Me.UseExtraLongTimeFormat = False
			Me.CurrentView = GraphContainer.GraphView.ViewSpeedHR
			Me.SessionCharts = chart
			Me.SetView(GraphContainer.GraphView.ViewSpeedHR)
			Me.ClearCharts()
		End Sub

		Public Sub ClearCharts()
			Me.StrokeIndex = 1
			Me.GraphTime = 0
			Me.NoData = True
			Me.NoHRData = True
			Me.PowerRange = 200
			Me.HRRange = 175
			Me.UseLongTimeFormat = False
			Me.UseExtraLongTimeFormat = False
			Me.SessionCharts.Series(0).Points.Clear()
			Me.SessionCharts.Series(1).Points.Clear()
			Me.SessionCharts.Series(2).Points.Clear()
			Me.SessionCharts.Series(3).Points.Clear()
			Me.SessionCharts.ChartAreas(0).AxisX.Minimum = 0
			Me.SessionCharts.ChartAreas(0).AxisX.Maximum = 60
			Me.SessionCharts.ChartAreas(0).AxisX.CustomLabels.Clear()
			Me.SessionCharts.ChartAreas(0).AxisX.Title = "Time (seconds)"
			Me.SessionCharts.ChartAreas(1).AxisX.Minimum = 1
			Me.SessionCharts.ChartAreas(1).AxisX.Maximum = 21
			Me.SessionCharts.ChartAreas(1).AxisX.Interval = 5
			Me.SessionCharts.ChartAreas(0).AxisY2.Minimum = 50
			Me.SessionCharts.ChartAreas(0).AxisY2.Maximum = CDbl(Me.HRRange)
			Me.SessionCharts.ChartAreas(0).AxisY2.Interval = CDbl((Me.HRRange - 50)) / 5
			Me.SessionCharts.ChartAreas(1).AxisY.Maximum = CDbl(Me.PowerRange)
			Me.SessionCharts.ChartAreas(1).AxisY.Interval = CDbl(Me.PowerRange) / 5
			Me.SessionCharts.ChartAreas(1).AxisY.LabelStyle.Format = "  #0"
			Me.SessionCharts.Series(0).Points.AddXY(0, 0)
			Me.SessionCharts.Series(1).Points.AddXY(0, 0)
			Me.SessionCharts.Series(2).Points.AddXY(0, 0)
			Me.SessionCharts.Series(3).Points.AddXY(0, 0)
		End Sub

		Public Sub SetView(ByVal view As GraphContainer.GraphView)
			Me.CurrentView = view
			If (view = GraphContainer.GraphView.ViewBoth) Then
				Me.SessionCharts.ChartAreas(0).Visible = True
				Me.SessionCharts.ChartAreas(1).Visible = True
			ElseIf (view = GraphContainer.GraphView.ViewSpeedHR) Then
				Me.SessionCharts.ChartAreas(0).Visible = True
				Me.SessionCharts.ChartAreas(1).Visible = False
			ElseIf (view = GraphContainer.GraphView.ViewPowerSPM) Then
				Me.SessionCharts.ChartAreas(0).Visible = False
				Me.SessionCharts.ChartAreas(1).Visible = True
			End If
		End Sub

		Public Sub UpdateGraphs(ByRef StrokeData As StrokeInstance)
			Me.GraphTime = StrokeData.Time
			Me.SessionCharts.Series("500m Time").Points.AddXY(Me.GraphTime, StrokeData.Speed)
			If (StrokeData.Power > CDbl(Me.PowerRange)) Then
				If (StrokeData.Power > 500) Then
					Me.PowerRange = 1000
				ElseIf (StrokeData.Power > 200) Then
					Me.PowerRange = 500
				End If
				Me.SessionCharts.ChartAreas(1).AxisY.Maximum = CDbl(Me.PowerRange)
				Me.SessionCharts.ChartAreas(1).AxisY.Interval = CDbl(Me.PowerRange) / 5
				Me.SessionCharts.ChartAreas(1).AxisY.LabelStyle.Format = Conversions.ToString(Interaction.IIf(Me.PowerRange < 1000, "  #0", "#0"))
			End If
			If (Me.StrokeIndex > 21) Then
				Me.SessionCharts.ChartAreas(1).AxisX.Minimum = CDbl((Me.StrokeIndex - 20))
				Me.SessionCharts.ChartAreas(1).AxisX.Maximum = CDbl(Me.StrokeIndex)
			End If
			Me.SessionCharts.Series("Power").Points.AddXY(CDbl(Me.StrokeIndex), StrokeData.Power)
			Me.SessionCharts.Series("SPM").Points.AddXY(CDbl(Me.StrokeIndex), StrokeData.SPM)
			Me.StrokeIndex = Me.StrokeIndex + 1
			If (Me.NoData) Then
				Me.SessionCharts.Series("500m Time").Points.RemoveAt(0)
				Me.SessionCharts.Series("Power").Points.RemoveAt(0)
				Me.SessionCharts.Series("SPM").Points.RemoveAt(0)
				Me.NoData = False
			End If
		End Sub

		Public Sub UpdateHRGraph(ByVal time As Double, ByVal HR As Double)
			Dim str As String
			If (HR > CDbl(Me.HRRange)) Then
				Me.HRRange = Me.HRRange + 50
				Me.SessionCharts.ChartAreas(0).AxisY2.Maximum = CDbl(Me.HRRange)
				Me.SessionCharts.ChartAreas(0).AxisY2.Interval = CDbl((Me.HRRange - 50)) / 5
			End If
			If (time >= 60) Then
				Me.SessionCharts.ChartAreas(0).AxisX.Minimum = time - 60
				Me.SessionCharts.ChartAreas(0).AxisX.Maximum = time
				If (time > 600 AndAlso Not Me.UseLongTimeFormat And Not Me.UseExtraLongTimeFormat) Then
					Me.SessionCharts.ChartAreas(0).AxisX.Title = "Time (m:ss)"
					Me.UseLongTimeFormat = True
				End If
				If (time >= 3600 And Not Me.UseExtraLongTimeFormat) Then
					Me.SessionCharts.ChartAreas(0).AxisX.Title = "Time (h:mm:ss)"
					Me.UseExtraLongTimeFormat = True
					Me.UseLongTimeFormat = False
				End If
			End If
			If (Me.UseLongTimeFormat Or Me.UseExtraLongTimeFormat) Then
				Dim num As Double = 10
				Dim num1 As Double = time - 60
				Me.SessionCharts.ChartAreas(0).AxisX.CustomLabels.Clear()
				Dim num2 As Integer = 0
				Do
					str = If(Not Me.UseExtraLongTimeFormat, String.Format("{0}:{1:00}", Conversion.Int(num1 / 60), Conversion.Int(num1 Mod 60)), String.Format("{0}:{1:00}:{2:00}", Conversion.Int(num1 / 3600), Conversion.Int(num1 Mod 3600 / 60), num1 Mod 60))
					Me.SessionCharts.ChartAreas(0).AxisX.CustomLabels.Add(num1 - num / 2, num1 + num / 2, str, 0, LabelMarkStyle.None)
					num1 = num1 + num
					num2 = num2 + 1
				Loop While num2 <= 6
			End If
			Me.SessionCharts.Series("Heart Rate").Points.AddXY(time, HR)
			If (Me.NoHRData) Then
				Me.SessionCharts.Series("Heart Rate").Points.RemoveAt(0)
				Me.NoHRData = False
			End If
		End Sub

		Public Enum GraphView
			ViewSpeedHR = 1
			ViewPowerSPM = 2
			ViewBoth = 3
		End Enum
	End Class
End Namespace