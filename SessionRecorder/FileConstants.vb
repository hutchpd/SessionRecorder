Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace SessionRecorder
	Friend Module FileConstants
		Public Const SW_VERSION As String = "1.3.1"

		Public Const SESSION_FOLDER As String = "\FDFSavedSessions"

		Public Const SUMMARY_FILE_HEADER As String = "#FDF Rower Session Summary File v1.0"

		Public Const SESSION_FILE_HEADER As String = "#FDF Rower Session Data File v1.0"

		Public Const HR_FILE_HEADER As String = "#FDF Heart Rate File v1.0"

		Public Const SESSION_SUMMARY_FILE As String = "SessionSummary.fdf"

		Public Const SESSION_DATA_FILE As String = "RowerSessionFile.fdf"

		Public Const HEART_RATE_DATA_FILE As String = "HeartRateData.fdf"

		Sub New()
		End Sub
	End Module
End Namespace