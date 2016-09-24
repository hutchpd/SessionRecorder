Imports System

Namespace SessionRecorder
	Public Enum RowerDataEventType
		DataEventNone = 0
		DataEventStroke = 1
		DataEventStrokeTO = 2
		DataEventForce = 3
		DataEventHeartRate = 4
		DataEventNewLevel = 5
		DataEventResetAck = 7
		DataEventDisconnected = 100
	End Enum
End Namespace