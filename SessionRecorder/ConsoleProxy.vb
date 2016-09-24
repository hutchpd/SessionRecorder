Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO.Ports
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading

Namespace SessionRecorder
	Public Class ConsoleProxy
		<AccessedThroughProperty("oSerialIO")>
		Private _oSerialIO As SerialIO

		Private StrokeData As StrokeInstance

		Public HeartRate As Integer

		Public Level As Integer

		Private readThread As Thread

		Private _ContinueRead As Boolean

		Private bResetComplete As Boolean

		Private bIsAlive As Boolean

		Public DeviceInfo As DeviceInformation

		Private DeviceLevels As Integer()

        Private Property oSerialIO As SerialIO
            Get
                Return Me._oSerialIO
            End Get
            Set(ByVal value As SerialIO)
                Me._oSerialIO = value
            End Set
        End Property

        Public Sub New()
			MyBase.New()
			Me.oSerialIO = New SerialIO()
			Me._ContinueRead = False
			Me.bResetComplete = False
			Me.bIsAlive = False
			Dim numArray() As Integer = { -1, -1, -1, 20, 16, -1, 4, 4, 16, -1, -1, 16, 4 }
			Me.DeviceLevels = numArray
		End Sub

		Private Sub ClearStrokeData()
			Me.StrokeData.Time = 0
			Me.StrokeData.Distance = 0
			Me.StrokeData.SPM = 0
			Me.StrokeData.Power = 0
			Me.StrokeData.Cals = 0
			Me.StrokeData.CalsTotal = 0
		End Sub

		Public Function ConnectToConsole() As ConsoleProxy.OpenCode
			Dim openCode As ConsoleProxy.OpenCode = Me.OpenSerialUSB()
			If (openCode = ConsoleProxy.OpenCode.ValidDevice) Then
				Me.ClearStrokeData()
				Me.StartReadThread()
			End If
			Return openCode
		End Function

		Public Sub DisconnectConsole()
			If (Me._ContinueRead) Then
				Me._ContinueRead = False
				Me.readThread.Join(1000)
			End If
			Me.oSerialIO.SendCommandNoWait("D")
			Me.oSerialIO.Close()
		End Sub

		Private Sub GetDeviceInfo()
			Dim strArrays As String()
			Dim str As String = Me.oSerialIO.SendCommand("T", 3)
			If (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str, 1), "T", False) = 0 And str.Length > 1) Then
				Me.DeviceInfo.DeviceType = Conversions.ToInteger(Microsoft.VisualBasic.Strings.Mid(str, 2))
				If (Me.DeviceInfo.DeviceType > 0 And Me.DeviceInfo.DeviceType <= 20) Then
					str = Me.oSerialIO.SendCommand("V", 3)
					If (Not (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str, 1), "V", False) = 0 And str.Length >= 8)) Then
						Me.DeviceInfo.DeviceType = -1
					Else
						Me.DeviceInfo.ConsoleType = Conversions.ToInteger(Microsoft.VisualBasic.Strings.Mid(str, 2, 1))
						If (Not (Me.DeviceInfo.DeviceType = 8 Or Me.DeviceInfo.DeviceType = 9 Or Me.DeviceInfo.DeviceType = 12)) Then
							strArrays = New String() { Microsoft.VisualBasic.Strings.Mid(str, 2, 1), ".", Microsoft.VisualBasic.Strings.Mid(str, 3, 1), ".", Microsoft.VisualBasic.Strings.Mid(str, 4, 1), " (", Microsoft.VisualBasic.Strings.Mid(str, 6, 2), "/20", Microsoft.VisualBasic.Strings.Mid(str, 8, 2), ")" }
							Me.DeviceInfo.VersionInfo = String.Concat(strArrays)
							str = Me.oSerialIO.SendCommand("O", 3)
							If (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str, 1), "O", False) = 0 And str.Length >= 4) Then
								Dim strArrays1 As String() = Microsoft.VisualBasic.Strings.Mid(str, 2).Split(New Char() { ","C })
								If (strArrays1.Count() >= 2) Then
									Me.DeviceInfo.OdoDistance = Conversions.ToInteger(strArrays1(0))
									Me.DeviceInfo.OdoTime = Conversions.ToInteger(strArrays1(1))
								End If
							End If
						Else
							strArrays = New String() { Microsoft.VisualBasic.Strings.Mid(str, 2, 1), ".", Microsoft.VisualBasic.Strings.Mid(str, 3, 1), ".", Microsoft.VisualBasic.Strings.Mid(str, 4, 1), " (", Microsoft.VisualBasic.Strings.Mid(str, 5, 2), "/20", Microsoft.VisualBasic.Strings.Mid(str, 7, 2), ")" }
							Me.DeviceInfo.VersionInfo = String.Concat(strArrays)
						End If
						str = Me.oSerialIO.SendCommand("L", 3)
						If (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str, 1), "L", False) = 0 And str.Length > 1) Then
							Me.Level = Conversions.ToInteger(Microsoft.VisualBasic.Strings.Mid(str, 2))
							str = Me.oSerialIO.SendCommand("H", 3)
							If (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str, 1), "H", False) = 0 And str.Length > 1) Then
								Me.HeartRate = Conversions.ToInteger(Microsoft.VisualBasic.Strings.Mid(str, 2))
								RaiseEvent RowerDataEvent(4)
							End If
						End If
						If (Me.DeviceInfo.DeviceType > 13) Then
							Me.DeviceInfo.DeviceType = -1
						Else
							Me.DeviceInfo.NumLevels = Me.DeviceLevels(Me.DeviceInfo.DeviceType - 1)
						End If
					End If
					If (Me.DeviceInfo.DeviceType = -1) Then
						Me.DeviceInfo.VersionInfo = ""
						Me.oSerialIO.Close()
					End If
				End If
			End If
		End Sub

		Public Function GetHeartRate() As Integer
			Return Me.HeartRate
		End Function

		Public Function GetStrokeData() As StrokeInstance
			Return Me.StrokeData
		End Function

		Public Sub KeepAlive()
			Me.oSerialIO.SendCommandNoWait("K")
		End Sub

		Public Sub LevelDown()
			Me.oSerialIO.SendCommandNoWait(String.Concat("L", Conversions.ToString(Me.Level - 1)))
		End Sub

		Public Sub LevelUp()
			Me.oSerialIO.SendCommandNoWait(String.Concat("L", Conversions.ToString(Me.Level + 1)))
		End Sub

		Private Function OpenSerialUSB() As ConsoleProxy.OpenCode
			Dim openCode As ConsoleProxy.OpenCode
			Dim portNames As String() = SerialPort.GetPortNames()
			Me.ResetDeviceInfo()
			If (CInt(portNames.Length) > 0) Then
				Dim str As String = String.Concat("Enumerating COM Ports...", Conversions.ToString(CInt(portNames.Length)), " ports found)")
				Utilities.WriteDebugFile(str)
			End If
			Dim strArrays As String() = portNames
			Dim num As Integer = 0
		Label1:
			While num < CInt(strArrays.Length)
				Dim str1 As String = strArrays(num)
				Try
                    Me.oSerialIO.OpenPort(str1, 9600)
                    Dim str2 As String = Me.oSerialIO.SendCommand("C", 3)
                    If (Not (str2.Length >= 5 And Operators.CompareString(Microsoft.VisualBasic.Strings.Left(str2, 1), "C", False) = 0)) Then
						Me.oSerialIO.Close()
						GoTo Label0
					Else
						Me.GetDeviceInfo()
						If (Me.DeviceInfo.DeviceType <> -1) Then
							Me.oSerialIO.SetReadTimeout(100)
							openCode = ConsoleProxy.OpenCode.ValidDevice
						Else
							Me.oSerialIO.Close()
							openCode = ConsoleProxy.OpenCode.InvalidDevice
						End If
					End If
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Me.oSerialIO.Close()
					ProjectData.ClearProjectError()
					GoTo Label0
				End Try
				Return openCode
			End While
			Return ConsoleProxy.OpenCode.NoDevice
		Label0:
			num = num + 1
			GoTo Label1
		End Function

		Private Function ProcessData(ByRef data As String) As RowerDataEventType
			If (data.Length > 0) Then
				Dim str As String = Microsoft.VisualBasic.Strings.Left(data, 1)
				If (Operators.CompareString(str, "A", False) = 0) Then
					Return Me.ProcessStrokeData(data)
				End If
				If (Operators.CompareString(str, "H", False) = 0) Then
					Return Me.ProcessHeartRateData(data)
				End If
				If (Operators.CompareString(str, "L", False) = 0) Then
					Return Me.ProcessLevelData(data)
				End If
				If (Operators.CompareString(str, "R", False) = 0) Then
					Me.bResetComplete = True
				ElseIf (Operators.CompareString(str, "K", False) = 0) Then
					Me.bIsAlive = True
				ElseIf (Operators.CompareString(str, "W", False) = 0) Then
					Me.oSerialIO.SendCommandNoWait("K")
				End If
			End If
			Return RowerDataEventType.DataEventNone
		End Function

		Private Function ProcessHeartRateData(ByRef data As String) As RowerDataEventType
			If (data.Length <= 1) Then
				Return RowerDataEventType.DataEventNone
			End If
			Me.HeartRate = CInt(Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 2))))
			Return RowerDataEventType.DataEventHeartRate
		End Function

		Private Function ProcessLevelData(ByRef data As String) As RowerDataEventType
			If (data.Length <= 1) Then
				Return RowerDataEventType.DataEventNone
			End If
			Me.Level = CInt(Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 2))))
			Return RowerDataEventType.DataEventNewLevel
		End Function

		Private Function ProcessStrokeData(ByRef data As String) As RowerDataEventType
			If (data.Length = 0) Then
				Return RowerDataEventType.DataEventNone
			End If
			If (Not (Operators.CompareString(Microsoft.VisualBasic.Strings.Left(data, 1), "A", False) = 0 And data.Length = 29)) Then
				Return RowerDataEventType.DataEventNone
			End If
			Me.StrokeData.Time = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 3, 1)) * 60 * 60 + Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 4, 2)) * 60 + Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 6, 2))
			Me.StrokeData.Distance = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 8, 5))
			Me.StrokeData.Speed = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 14, 2)) * 60 + Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 16, 2))
			Me.StrokeData.SPM = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 18, 3))
			Me.StrokeData.Power = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 21, 3))
			If (Me.StrokeData.SPM > 0) Then
				Me.StrokeData.CalsTotal = Me.StrokeData.CalsTotal + Me.StrokeData.Cals / (60 * Me.StrokeData.SPM)
			End If
			If (Me.StrokeData.SPM = 0 And Me.StrokeData.Time > 0) Then
				Me.StrokeData.CalsTotal = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 24, 4))
				Return RowerDataEventType.DataEventStrokeTO
			End If
			Me.StrokeData.Cals = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(data, 24, 4))
			Return RowerDataEventType.DataEventStroke
		End Function

		Public Function ReadSerial() As SessionRecorder.RowerDataEventType
			Dim rowerDataEventType As SessionRecorder.RowerDataEventType
			Try
				Dim str As String = Me.oSerialIO.ReadLine()
				rowerDataEventType = Me.ProcessData(str)
			Catch timeoutException As System.TimeoutException
				ProjectData.SetProjectError(timeoutException)
				ProjectData.ClearProjectError()
				Return SessionRecorder.RowerDataEventType.DataEventNone
			End Try
			Return rowerDataEventType
		End Function

		Private Sub ReadThreadSub()
			Dim rowerDataEventType As SessionRecorder.RowerDataEventType = SessionRecorder.RowerDataEventType.DataEventNone
			While Me._ContinueRead
				Try
					rowerDataEventType = Me.ReadSerial()
					If (rowerDataEventType <> SessionRecorder.RowerDataEventType.DataEventNone) Then
						RaiseEvent RowerDataEvent(rowerDataEventType)
					End If
					Thread.Sleep(10)
				Catch invalidOperationException As System.InvalidOperationException
					ProjectData.SetProjectError(invalidOperationException)
					Me.oSerialIO.Close()
					Me._ContinueRead = False
					RaiseEvent RowerDataEvent(100)
					ProjectData.ClearProjectError()
				End Try
			End While
		End Sub

		Public Sub Reset()
			Me.bResetComplete = False
			Me.oSerialIO.SendCommand("R", 3)
		End Sub

		Private Sub ResetDeviceInfo()
			Me.DeviceInfo.DeviceType = -1
			Me.DeviceInfo.VersionInfo = ""
			Me.DeviceInfo.NumLevels = -1
			Me.DeviceInfo.OdoTime = -1
			Me.DeviceInfo.OdoDistance = -1
		End Sub

		Private Sub StartReadThread()
			Me._ContinueRead = True
			Dim consoleProxy As SessionRecorder.ConsoleProxy = Me
			Me.readThread = New Thread(New ThreadStart(AddressOf consoleProxy.ReadThreadSub)) With
			{
				.IsBackground = True,
				.Name = "Rower Data Source Read Thread"
			}
			Me.readThread.Start()
		End Sub

		Public Event RowerDataEvent As ConsoleProxy.RowerDataEventEventHandler

		Public Enum OpenCode
			NoDevice
			InvalidDevice
			ValidDevice
		End Enum

		Public Delegate Sub RowerDataEventEventHandler(ByVal dt As RowerDataEventType)
	End Class
End Namespace