Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace SessionRecorder
	Public Class SessionWriter
		Private HRFileWriter As StreamWriter

		Private SessionFileWriter As StreamWriter

		Private SummaryFileWriter As StreamWriter

		Private bIsOpen As Boolean

		Private bRequiresSave As Boolean

		Private outputDir As String

		Public ReadOnly Property SaveRequired As Boolean
			Get
				Return Me.bRequiresSave
			End Get
		End Property

		Public Sub New()
			MyBase.New()
			Me.HRFileWriter = Nothing
			Me.SessionFileWriter = Nothing
			Me.SummaryFileWriter = Nothing
			Me.bIsOpen = False
			Me.bRequiresSave = False
		End Sub

		Public Sub CleanUp()
			If (Me.outputDir Is Nothing) Then
				Return
			End If
			If (Me.bIsOpen) Then
				Me.SessionFileWriter.Close()
				Me.HRFileWriter.Close()
				Me.SummaryFileWriter.Close()
				Me.bIsOpen = False
			End If
			If (Directory.Exists(String.Concat(Me.outputDir, "\tmp"))) Then
				Try
					Dim directories As String() = Directory.GetDirectories(String.Concat(Me.outputDir, "\tmp"))
					Dim num As Integer = 0
					Do
						Dim str As String = directories(num)
						Dim files As String() = Directory.GetFiles(str)
						Dim num1 As Integer = 0
						Do
							File.Delete(files(num1))
							num1 = num1 + 1
						Loop While num1 < CInt(files.Length)
						Directory.Delete(str, True)
						num = num + 1
					Loop While num < CInt(directories.Length)
					Dim strArrays As String() = Directory.GetFiles(String.Concat(Me.outputDir, "\tmp"))
					Dim num2 As Integer = 0
					Do
						File.Delete(strArrays(num2))
						num2 = num2 + 1
					Loop While num2 < CInt(strArrays.Length)
					Directory.Delete(String.Concat(Me.outputDir, "\tmp"))
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			End If
		End Sub

		Public Sub CloseSession()
			Me.bRequiresSave = False
			Me.CleanUp()
		End Sub

		Public Sub CloseSession(ByRef Summary As SessionStats)
			If (Not Me.bIsOpen) Then
				Return
			End If
			Me.SessionFileWriter.Close()
			Me.HRFileWriter.Close()
			Me.WriteSummaryFile(Summary)
			Me.SummaryFileWriter.Close()
			If (Me.bRequiresSave) Then
				Dim str As String = String.Concat(Me.outputDir, "\", Strings.Format(Summary.SessionDateTime, "d-M-y-HH-mm-ss"))
				Dim str1 As String = String.Concat(Me.outputDir, "\tmp")
				Try
					If (Not Directory.Exists(str)) Then
						Directory.CreateDirectory(str)
					End If
					File.Copy(String.Concat(str1, "\SessionSummary.fdf"), String.Concat(str, "\SessionSummary.fdf"), True)
					File.Copy(String.Concat(str1, "\RowerSessionFile.fdf"), String.Concat(str, "\RowerSessionFile.fdf"), True)
					File.Copy(String.Concat(str1, "\HeartRateData.fdf"), String.Concat(str, "\HeartRateData.fdf"), True)
					File.Delete(String.Concat(str1, "\SessionSummary.fdf"))
					File.Delete(String.Concat(str1, "\RowerSessionFile.fdf"))
					File.Delete(String.Concat(str1, "\HeartRateData.fdf"))
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					MessageBox.Show(String.Concat("Failed to Save Session Data Files in ", str), "Data File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					ProjectData.ClearProjectError()
				End Try
			End If
			Me.bRequiresSave = False
			Me.CleanUp()
		End Sub

		Public Function CreateNewSession() As Boolean
			Dim flag As Boolean
			If (Me.bIsOpen) Then
				Me.CloseSession()
			End If
			Try
				Me.outputDir = String.Concat(Environment.GetEnvironmentVariable("USERPROFILE"), "\FDFSavedSessions")
				If (Not Directory.Exists(String.Concat(Me.outputDir, "\tmp"))) Then
					Directory.CreateDirectory(String.Concat(Me.outputDir, "\tmp"))
				End If
				Me.SummaryFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\SessionSummary.fdf"), False)
				Me.SessionFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\RowerSessionFile.fdf"), False)
				Me.HRFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\HeartRateData.fdf"), False)
				Me.SummaryFileWriter.WriteLine("#FDF Rower Session Summary File v1.0")
				Me.SessionFileWriter.WriteLine("#FDF Rower Session Data File v1.0")
				Me.HRFileWriter.WriteLine("#FDF Heart Rate File v1.0")
				Me.bIsOpen = True
				flag = True
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				MessageBox.Show(String.Concat("Cannot Create Session Data Files in ", Me.outputDir, "\tmp"), "Data File Create Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				ProjectData.ClearProjectError()
				If (Not Information.IsNothing(Me.SummaryFileWriter)) Then
					Me.SummaryFileWriter.Close()
					Me.SummaryFileWriter = Nothing
				End If
				If (Not Information.IsNothing(Me.SessionFileWriter)) Then
					Me.SessionFileWriter.Close()
					Me.SessionFileWriter = Nothing
				End If
				If (Not Information.IsNothing(Me.HRFileWriter)) Then
					Me.HRFileWriter.Close()
					Me.HRFileWriter = Nothing
				End If
				Me.CleanUp()
				Return False
			End Try
			Return flag
		End Function

		Public Sub SaveSession(ByRef Summary As SessionStats)
			If (Not Me.bRequiresSave) Then
				Return
			End If
			Me.WriteSummaryFile(Summary)
			Me.SummaryFileWriter.Close()
			Me.SessionFileWriter.Close()
			Me.HRFileWriter.Close()
			Dim str As String = String.Concat(Me.outputDir, "\", Strings.Format(Summary.SessionDateTime, "d-M-y-HH-mm-ss"))
			Dim str1 As String = String.Concat(Me.outputDir, "\tmp")
			Try
				If (Not Directory.Exists(str)) Then
					Directory.CreateDirectory(str)
				End If
				File.Copy(String.Concat(str1, "\SessionSummary.fdf"), String.Concat(str, "\SessionSummary.fdf"), True)
				File.Copy(String.Concat(str1, "\RowerSessionFile.fdf"), String.Concat(str, "\RowerSessionFile.fdf"), True)
				File.Copy(String.Concat(str1, "\HeartRateData.fdf"), String.Concat(str, "\HeartRateData.fdf"), True)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				MessageBox.Show(String.Concat("Failed to Save Session Data Files in ", str), "Data File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				ProjectData.ClearProjectError()
			End Try
			Me.SummaryFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\SessionSummary.fdf"), False)
			Me.SummaryFileWriter.WriteLine("#FDF Rower Session Summary File v1.0")
			Me.SessionFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\RowerSessionFile.fdf"), True)
			Me.HRFileWriter = New StreamWriter(String.Concat(Me.outputDir, "\tmp\HeartRateData.fdf"), True)
			Me.bRequiresSave = False
		End Sub

		Public Sub WriteSummaryFile(ByRef Summary As SessionStats)
			If (Not Me.bIsOpen) Then
				Return
			End If
			Dim str As String = String.Concat(Strings.Format(Summary.SessionDateTime, "#M/d/yyyy HH:mm:ss#"), " ' Session Date & Time")
			Me.SummaryFileWriter.WriteLine(str)
			Me.SummaryFileWriter.Write(Math.Round(New Decimal(Summary.ActualDuration), 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.Distance, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.CalsTotal, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Summary.NumStrokes)
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Summary.Level)
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Summary.Device)
			Me.SummaryFileWriter.WriteLine("  ' Session Duration (s), Distance (m), Totals Cals, #Strokes, Level, Type")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SpeedMin, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SpeedMax, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SpeedAvg, 2))
			Me.SummaryFileWriter.WriteLine("  ' Speed : Min, Max, Avg")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SPMMin, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SPMMax, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.SPMAvg, 2))
			Me.SummaryFileWriter.WriteLine("  ' SPM : Min, Max, Avg")
			Me.SummaryFileWriter.Write(Math.Round(Summary.PowerMin, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.PowerMax, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.PowerAvg, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.EnergyTotal / 1000, 2))
			Me.SummaryFileWriter.WriteLine("  ' Power : Min, Max, Avg, Total Energy (kJ)")
			Me.SummaryFileWriter.Write(Math.Round(Summary.CalsMin, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.CalsMax, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.CalsHrAvg, 2))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.CalsTotal, 2))
			Me.SummaryFileWriter.WriteLine("  ' Cals/hr : Min, Max, Avg, Total")
			Me.SummaryFileWriter.Write(Math.Round(Summary.HeartRateMin, 0))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.HeartRateMax, 0))
			Me.SummaryFileWriter.Write(",")
			Me.SummaryFileWriter.Write(Math.Round(Summary.HeartRateAvg, 0))
			Me.SummaryFileWriter.WriteLine("  ' Heart Rate : Min, Max, Avg")
		End Sub

		Public Sub WriteToHRDataFile(ByVal time As Integer, ByVal HR As Double)
			If (Not Me.bIsOpen) Then
				Return
			End If
			Me.HRFileWriter.WriteLine(String.Concat(Conversions.ToString(time), ",", Conversions.ToString(HR)))
		End Sub

		Public Sub WriteToSessionFile(ByRef strokeData As StrokeInstance)
			If (Not Me.bIsOpen) Then
				Return
			End If
			Me.SessionFileWriter.Write(Math.Round(strokeData.Time, 2))
			Me.SessionFileWriter.Write(",")
			Me.SessionFileWriter.Write(Math.Round(strokeData.Distance, 2))
			Me.SessionFileWriter.Write(",")
			Me.SessionFileWriter.Write(Math.Round(strokeData.Speed, 2))
			Me.SessionFileWriter.Write(",")
			Me.SessionFileWriter.Write(Math.Round(strokeData.SPM, 2))
			Me.SessionFileWriter.Write(",")
			Me.SessionFileWriter.Write(Math.Round(strokeData.Power, 2))
			Me.SessionFileWriter.Write(",")
			Me.SessionFileWriter.WriteLine(Math.Round(strokeData.Cals, 0))
			Me.bRequiresSave = True
		End Sub
	End Class
End Namespace