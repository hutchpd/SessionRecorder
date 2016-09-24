Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO.Ports

Namespace SessionRecorder
	Public Class SerialIO
		Private oSerialPort As SerialPort

		Private bIsOpen As Boolean

		Public Sub New()
			MyBase.New()
			Me.oSerialPort = New SerialPort() With
			{
				.BaudRate = 9600,
				.Parity = Parity.None,
				.StopBits = StopBits.One,
				.DataBits = 8,
				.Handshake = Handshake.None,
				.ReadTimeout = 500,
				.WriteTimeout = 100
			}
		End Sub

		Public Sub Close()
			If (Me.bIsOpen) Then
				Me.oSerialPort.Close()
			End If
			Me.bIsOpen = False
		End Sub

		Public Sub OpenPort(ByVal port As String, ByVal baud As Integer)
			Dim str As String
			Me.oSerialPort.PortName = port
			Me.oSerialPort.BaudRate = baud
			Me.oSerialPort.ReadTimeout = 100
			Me.oSerialPort.WriteTimeout = 100
			Try
				str = String.Concat("Attempting to Open Port : ", Me.oSerialPort.PortName)
				Utilities.WriteDebugFile(str)
				Me.oSerialPort.Open()
				Me.bIsOpen = True
				str = String.Concat("Open Port : ", Me.oSerialPort.PortName, " - SUCCESS")
				Utilities.WriteDebugFile(str)
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Dim exception As System.Exception = exception1
				Dim portName() As String = { "Open Port : ", Me.oSerialPort.PortName, " - FAIL (", exception.Message, ")" }
				str = String.Concat(portName)
				Utilities.WriteDebugFile(str)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Function ReadLine() As String
			Dim str As String
			Try
				Dim str1 As String = Me.oSerialPort.ReadLine()
				str1 = str1.Trim()
				Dim strArrays() As String = { "Received data : ", str1, " (", Conversions.ToString(str1.Length), ")" }
				Dim str2 As String = String.Concat(strArrays)
				Utilities.WriteDebugFile(str2)
				str = str1
			Catch invalidOperationException1 As System.InvalidOperationException
				ProjectData.SetProjectError(invalidOperationException1)
				Dim invalidOperationException As System.InvalidOperationException = invalidOperationException1
				Me.Close()
				Throw invalidOperationException
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
				Return String.Empty
			End Try
			Return str
		End Function

		Public Function SendCommand(ByVal cmd As String, Optional ByVal numRetries As Integer = 3) As String
			Dim num As Integer = 0
			Dim str As String = String.Concat("Sending Command : ", cmd, ", Retries ", Conversions.ToString(numRetries))
			Utilities.WriteDebugFile(str)
			If (Not Me.bIsOpen) Then
				Return String.Empty
			End If
			Dim num1 As Integer = numRetries
			Dim num2 As Integer = 1
			Do
				str = String.Concat("Transmitting Command (", Conversions.ToString(num2), ") : ", cmd)
				Utilities.WriteDebugFile(str)
				Try
					Me.oSerialPort.WriteLine(cmd)
					Utilities.Sleep(200)
					While num <> 3
						Dim str1 As String = Me.ReadLine()
						If (Operators.CompareString(Strings.Left(str1, 1), Strings.Left(cmd, 1), False) <> 0) Then
							num = num + 1
							str = "Received data : none"
							Utilities.WriteDebugFile(str)
						Else
							Return str1
						End If
					End While
				Catch invalidOperationException As System.InvalidOperationException
					ProjectData.SetProjectError(invalidOperationException)
					Me.Close()
					RaiseEvent DisonnectEvent()
					ProjectData.ClearProjectError()
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Utilities.Sleep(1000)
					ProjectData.ClearProjectError()
				End Try
				num2 = num2 + 1
			Loop While num2 <= num1
			Return String.Empty
		End Function

		Public Sub SendCommandNoWait(ByVal cmd As String)
			If (Me.bIsOpen) Then
				Try
					Me.oSerialPort.WriteLine(cmd)
					Dim str As String = String.Concat("No Wait Command : ", cmd)
					Utilities.WriteDebugFile(str)
				Catch invalidOperationException As System.InvalidOperationException
					ProjectData.SetProjectError(invalidOperationException)
					Me.Close()
					RaiseEvent DisonnectEvent()
					ProjectData.ClearProjectError()
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			End If
		End Sub

		Public Sub SetReadTimeout(ByVal ReadTO As Integer)
			Me.oSerialPort.ReadTimeout = ReadTO
		End Sub

		Public Event DataAvailable As SerialIO.DataAvailableEventHandler

		Public Event DisonnectEvent As SerialIO.DisonnectEventEventHandler

		Public Delegate Sub DataAvailableEventHandler(ByVal data As String)

		Public Delegate Sub DisonnectEventEventHandler()
	End Class
End Namespace