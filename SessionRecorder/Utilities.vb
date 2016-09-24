Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SessionRecorder.My
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace SessionRecorder
	Friend Module Utilities
		Private debugWriter As StreamWriter

		Private bHasDebugStream As Boolean

		Sub New()
			Utilities.bHasDebugStream = False
		End Sub

		Public Sub CloseDebugFile()
			If (Not Utilities.bHasDebugStream) Then
				Return
			End If
			Utilities.debugWriter.Close()
			Utilities.bHasDebugStream = False
		End Sub

		Public Sub CreateDebugFile()
			If (Not MySettingsProperty.Settings.CreateDebugFile) Then
				Utilities.bHasDebugStream = False
				Return
			End If
			Dim now As DateTime = DateAndTime.Now
			Try
				Utilities.debugWriter = New StreamWriter(String.Concat(Environment.GetEnvironmentVariable("USERPROFILE"), "\FC_DebugOutput_", Strings.Format(now, "d-M-y_HH-mm-ss"), ".txt"))
				Utilities.debugWriter.WriteLine("Fluid Coach Debug File")
				Utilities.bHasDebugStream = True
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				MessageBox.Show("Cannot Create Debug File", "File Create Error", MessageBoxButtons.OK)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		<DllImport("CoreDll.dll", CharSet:=CharSet.Ansi, EntryPoint:="SystemIdleTimerReset", ExactSpelling:=True, SetLastError:=True)>
		Public Sub IdleTimerReset()
		End Sub

		<DllImport("kernel32", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
		Public Sub Sleep(ByVal dwMilliseconds As Integer)
		End Sub

		Public Sub WriteDebugFile(ByRef strDebug As String)
			If (Not Utilities.bHasDebugStream) Then
				Return
			End If
			Utilities.debugWriter.Write(Strings.Format(DateAndTime.Now, "HH-mm-ss : "))
			Utilities.debugWriter.WriteLine(strDebug)
		End Sub
	End Module
End Namespace