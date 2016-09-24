Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SessionRecorder.My
Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Namespace SessionRecorder
	<DesignerGenerated>
	Public Class RecorderMainWindow
		Inherits Form
		Private components As IContainer

		<AccessedThroughProperty("SpeedPanel")>
		Private _SpeedPanel As Panel

		<AccessedThroughProperty("Speed")>
		Private _Speed As Label

		<AccessedThroughProperty("SpeedLabel")>
		Private _SpeedLabel As Label

		<AccessedThroughProperty("Panel1")>
		Private _Panel1 As Panel

		<AccessedThroughProperty("Duration")>
		Private _Duration As Label

		<AccessedThroughProperty("Label2")>
		Private _Label2 As Label

		<AccessedThroughProperty("Panel2")>
		Private _Panel2 As Panel

		<AccessedThroughProperty("HeartRate")>
		Private _HeartRate As Label

		<AccessedThroughProperty("Label4")>
		Private _Label4 As Label

		<AccessedThroughProperty("Panel3")>
		Private _Panel3 As Panel

		<AccessedThroughProperty("SPM")>
		Private _SPM As Label

		<AccessedThroughProperty("Label6")>
		Private _Label6 As Label

		<AccessedThroughProperty("Panel4")>
		Private _Panel4 As Panel

		<AccessedThroughProperty("Level")>
		Private _Level As Label

		<AccessedThroughProperty("Label8")>
		Private _Label8 As Label

		<AccessedThroughProperty("Panel5")>
		Private _Panel5 As Panel

		<AccessedThroughProperty("Cals")>
		Private _Cals As Label

		<AccessedThroughProperty("CalsLabel")>
		Private _CalsLabel As Label

		<AccessedThroughProperty("Panel6")>
		Private _Panel6 As Panel

		<AccessedThroughProperty("Power")>
		Private _Power As Label

		<AccessedThroughProperty("Label12")>
		Private _Label12 As Label

		<AccessedThroughProperty("Panel7")>
		Private _Panel7 As Panel

		<AccessedThroughProperty("Distance")>
		Private _Distance As Label

		<AccessedThroughProperty("Label14")>
		Private _Label14 As Label

		<AccessedThroughProperty("NewSession")>
		Private _NewSession As Button

		<AccessedThroughProperty("LaunchViewer")>
		Private _LaunchViewer As Button

		<AccessedThroughProperty("Quit")>
		Private _Quit As Button

		<AccessedThroughProperty("SaveSession")>
		Private _SaveSession As Button

		<AccessedThroughProperty("LevelDown")>
		Private _LevelDown As Button

		<AccessedThroughProperty("SessionTimer")>
		Private _SessionTimer As Timer

		<AccessedThroughProperty("GraphControlPanel")>
		Private _GraphControlPanel As Panel

		<AccessedThroughProperty("ShowBoth")>
		Private _ShowBoth As RadioButton

		<AccessedThroughProperty("ShowSpeedHR")>
		Private _ShowSpeedHR As RadioButton

		<AccessedThroughProperty("ShowPowerSPM")>
		Private _ShowPowerSPM As RadioButton

		<AccessedThroughProperty("LevelUp")>
		Private _LevelUp As Button

		<AccessedThroughProperty("StatusMessage")>
		Private _StatusMessage As Label

		<AccessedThroughProperty("Settings")>
		Private _Settings As Button

		<AccessedThroughProperty("KeepAliveTimer")>
		Private _KeepAliveTimer As Timer

		<AccessedThroughProperty("ConnectTimer")>
		Private _ConnectTimer As Timer

		<AccessedThroughProperty("SessionChart")>
		Private _SessionChart As Chart

		<AccessedThroughProperty("Average")>
		Private _Average As Label

		<AccessedThroughProperty("TotalCalsLabel")>
		Private _TotalCalsLabel As Label

		<AccessedThroughProperty("GroupBox1")>
		Private _GroupBox1 As GroupBox

		<AccessedThroughProperty("oRowerDataSource")>
		Private _oRowerDataSource As ConsoleProxy

		Private dataEvent As RowerDataEventType

		Private strokeData As StrokeInstance

		Private oSessionStats As SessionStats

		Private oSessionWriter As SessionWriter

		Private CurrentHR As Integer

		Private SessionCharts As GraphContainer

		Private FirstConnect As Boolean

		Private MyFormClosed As Boolean

		Private eSessionState As RecorderMainWindow.SessionState

		Friend Overridable Property Average As Label
			Get
				Return Me._Average
			End Get
			Set(ByVal value As Label)
				Me._Average = value
			End Set
		End Property

		Friend Overridable Property Cals As Label
			Get
				Return Me._Cals
			End Get
			Set(ByVal value As Label)
				Me._Cals = value
			End Set
		End Property

		Friend Overridable Property CalsLabel As Label
			Get
				Return Me._CalsLabel
			End Get
			Set(ByVal value As Label)
				Me._CalsLabel = value
			End Set
		End Property

		Friend Overridable Property ConnectTimer As Timer
			Get
				Return Me._ConnectTimer
			End Get
			Set(ByVal value As Timer)
                Dim recorderMainWindow As RecorderMainWindow = Me
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.ConnectTimer_Tick)
				If (Me._ConnectTimer IsNot Nothing) Then
					RemoveHandler Me._ConnectTimer.Tick,  eventHandler
				End If
				Me._ConnectTimer = value
				If (Me._ConnectTimer IsNot Nothing) Then
                    AddHandler Me._ConnectTimer.Tick, eventHandler
                    Me._ConnectTimer.Start()
                End If
			End Set
		End Property

		Friend Overridable Property Distance As Label
			Get
				Return Me._Distance
			End Get
			Set(ByVal value As Label)
				Me._Distance = value
			End Set
		End Property

		Friend Overridable Property Duration As Label
			Get
				Return Me._Duration
			End Get
			Set(ByVal value As Label)
				Me._Duration = value
			End Set
		End Property

		Friend Overridable Property GraphControlPanel As Panel
			Get
				Return Me._GraphControlPanel
			End Get
			Set(ByVal value As Panel)
				Me._GraphControlPanel = value
			End Set
		End Property

		Friend Overridable Property GroupBox1 As GroupBox
			Get
				Return Me._GroupBox1
			End Get
			Set(ByVal value As GroupBox)
				Me._GroupBox1 = value
			End Set
		End Property

		Friend Overridable Property HeartRate As Label
			Get
				Return Me._HeartRate
			End Get
			Set(ByVal value As Label)
				Me._HeartRate = value
			End Set
		End Property

		Friend Overridable Property KeepAliveTimer As Timer
			Get
				Return Me._KeepAliveTimer
			End Get
			Set(ByVal value As Timer)
                Dim recorderMainWindow As RecorderMainWindow = Me
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.KeepAliveTimer_Tick)
				If (Me._KeepAliveTimer IsNot Nothing) Then
					RemoveHandler Me._KeepAliveTimer.Tick,  eventHandler
				End If
				Me._KeepAliveTimer = value
				If (Me._KeepAliveTimer IsNot Nothing) Then
					AddHandler Me._KeepAliveTimer.Tick,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label12 As Label
			Get
				Return Me._Label12
			End Get
			Set(ByVal value As Label)
				Me._Label12 = value
			End Set
		End Property

		Friend Overridable Property Label14 As Label
			Get
				Return Me._Label14
			End Get
			Set(ByVal value As Label)
				Me._Label14 = value
			End Set
		End Property

		Friend Overridable Property Label2 As Label
			Get
				Return Me._Label2
			End Get
			Set(ByVal value As Label)
				Me._Label2 = value
			End Set
		End Property

		Friend Overridable Property Label4 As Label
			Get
				Return Me._Label4
			End Get
			Set(ByVal value As Label)
				Me._Label4 = value
			End Set
		End Property

		Friend Overridable Property Label6 As Label
			Get
				Return Me._Label6
			End Get
			Set(ByVal value As Label)
				Me._Label6 = value
			End Set
		End Property

		Friend Overridable Property Label8 As Label
			Get
				Return Me._Label8
			End Get
			Set(ByVal value As Label)
				Me._Label8 = value
			End Set
		End Property

		Friend Overridable Property LaunchViewer As Button
			Get
				Return Me._LaunchViewer
			End Get
			Set(ByVal value As Button)
                Dim recorderMainWindow As RecorderMainWindow = Me
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.LaunchViewer_Click)
				If (Me._LaunchViewer IsNot Nothing) Then
					RemoveHandler Me._LaunchViewer.Click,  eventHandler
				End If
				Me._LaunchViewer = value
				If (Me._LaunchViewer IsNot Nothing) Then
					AddHandler Me._LaunchViewer.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Level As Label
			Get
				Return Me._Level
			End Get
			Set(ByVal value As Label)
				Me._Level = value
			End Set
		End Property

		Friend Overridable Property LevelDown As Button
			Get
				Return Me._LevelDown
			End Get
			Set(ByVal value As Button)
                Dim recorderMainWindow As RecorderMainWindow = Me
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.LevelDown_Click)
				If (Me._LevelDown IsNot Nothing) Then
					RemoveHandler Me._LevelDown.Click,  eventHandler
				End If
				Me._LevelDown = value
				If (Me._LevelDown IsNot Nothing) Then
					AddHandler Me._LevelDown.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property LevelUp As Button
			Get
				Return Me._LevelUp
			End Get
			Set(ByVal value As Button)
                Dim recorderMainWindow As RecorderMainWindow = Me
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.LevelUp_Click)
				If (Me._LevelUp IsNot Nothing) Then
					RemoveHandler Me._LevelUp.Click,  eventHandler
				End If
				Me._LevelUp = value
				If (Me._LevelUp IsNot Nothing) Then
					AddHandler Me._LevelUp.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property NewSession As Button
			Get
				Return Me._NewSession
			End Get
			Set(ByVal value As Button)
				Dim recorderMainWindow As RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.NewSession_Click)
				If (Me._NewSession IsNot Nothing) Then
					RemoveHandler Me._NewSession.Click,  eventHandler
				End If
				Me._NewSession = value
				If (Me._NewSession IsNot Nothing) Then
					AddHandler Me._NewSession.Click,  eventHandler
				End If
			End Set
		End Property

        Private Property oRowerDataSource As ConsoleProxy
            Get
                Return Me._oRowerDataSource
            End Get
            Set(ByVal value As ConsoleProxy)
                Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
                Dim rowerDataEventEventHandler As ConsoleProxy.RowerDataEventEventHandler = New ConsoleProxy.RowerDataEventEventHandler(AddressOf recorderMainWindow.DataSourceHandler)
                If (Me._oRowerDataSource IsNot Nothing) Then
                    RemoveHandler Me._oRowerDataSource.RowerDataEvent, rowerDataEventEventHandler
                End If
                Me._oRowerDataSource = value
                If (Me._oRowerDataSource IsNot Nothing) Then
                    AddHandler Me._oRowerDataSource.RowerDataEvent, rowerDataEventEventHandler
                End If
            End Set
        End Property

        Friend Overridable Property Panel1 As Panel
			Get
				Return Me._Panel1
			End Get
			Set(ByVal value As Panel)
				Me._Panel1 = value
			End Set
		End Property

		Friend Overridable Property Panel2 As Panel
			Get
				Return Me._Panel2
			End Get
			Set(ByVal value As Panel)
				Me._Panel2 = value
			End Set
		End Property

		Friend Overridable Property Panel3 As Panel
			Get
				Return Me._Panel3
			End Get
			Set(ByVal value As Panel)
				Me._Panel3 = value
			End Set
		End Property

		Friend Overridable Property Panel4 As Panel
			Get
				Return Me._Panel4
			End Get
			Set(ByVal value As Panel)
				Me._Panel4 = value
			End Set
		End Property

		Friend Overridable Property Panel5 As Panel
			Get
				Return Me._Panel5
			End Get
			Set(ByVal value As Panel)
				Me._Panel5 = value
			End Set
		End Property

		Friend Overridable Property Panel6 As Panel
			Get
				Return Me._Panel6
			End Get
			Set(ByVal value As Panel)
				Me._Panel6 = value
			End Set
		End Property

		Friend Overridable Property Panel7 As Panel
			Get
				Return Me._Panel7
			End Get
			Set(ByVal value As Panel)
				Me._Panel7 = value
			End Set
		End Property

		Friend Overridable Property Power As Label
			Get
				Return Me._Power
			End Get
			Set(ByVal value As Label)
				Me._Power = value
			End Set
		End Property

		Friend Overridable Property Quit As Button
			Get
				Return Me._Quit
			End Get
			Set(ByVal value As Button)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.Quit_Click)
				If (Me._Quit IsNot Nothing) Then
					RemoveHandler Me._Quit.Click,  eventHandler
				End If
				Me._Quit = value
				If (Me._Quit IsNot Nothing) Then
					AddHandler Me._Quit.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property SaveSession As Button
			Get
				Return Me._SaveSession
			End Get
			Set(ByVal value As Button)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.SaveSession_Click)
				If (Me._SaveSession IsNot Nothing) Then
					RemoveHandler Me._SaveSession.Click,  eventHandler
				End If
				Me._SaveSession = value
				If (Me._SaveSession IsNot Nothing) Then
					AddHandler Me._SaveSession.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property SessionChart As Chart
			Get
				Return Me._SessionChart
			End Get
			Set(ByVal value As Chart)
				Me._SessionChart = value
			End Set
		End Property

		Friend Overridable Property SessionTimer As Timer
			Get
				Return Me._SessionTimer
			End Get
			Set(ByVal value As Timer)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.SessionTimer_Tick)
				If (Me._SessionTimer IsNot Nothing) Then
					RemoveHandler Me._SessionTimer.Tick,  eventHandler
				End If
				Me._SessionTimer = value
				If (Me._SessionTimer IsNot Nothing) Then
					AddHandler Me._SessionTimer.Tick,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Settings As Button
			Get
				Return Me._Settings
			End Get
			Set(ByVal value As Button)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.Settings_Click)
				If (Me._Settings IsNot Nothing) Then
					RemoveHandler Me._Settings.Click,  eventHandler
				End If
				Me._Settings = value
				If (Me._Settings IsNot Nothing) Then
					AddHandler Me._Settings.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property ShowBoth As RadioButton
			Get
				Return Me._ShowBoth
			End Get
			Set(ByVal value As RadioButton)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.ShowBoth_CheckedChanged)
				If (Me._ShowBoth IsNot Nothing) Then
					RemoveHandler Me._ShowBoth.CheckedChanged,  eventHandler
				End If
				Me._ShowBoth = value
				If (Me._ShowBoth IsNot Nothing) Then
					AddHandler Me._ShowBoth.CheckedChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property ShowPowerSPM As RadioButton
			Get
				Return Me._ShowPowerSPM
			End Get
			Set(ByVal value As RadioButton)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.ShowPowerSPM_CheckedChanged)
				If (Me._ShowPowerSPM IsNot Nothing) Then
					RemoveHandler Me._ShowPowerSPM.CheckedChanged,  eventHandler
				End If
				Me._ShowPowerSPM = value
				If (Me._ShowPowerSPM IsNot Nothing) Then
					AddHandler Me._ShowPowerSPM.CheckedChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property ShowSpeedHR As RadioButton
			Get
				Return Me._ShowSpeedHR
			End Get
			Set(ByVal value As RadioButton)
				Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf recorderMainWindow.ShowSpeedHR_CheckedChanged)
				If (Me._ShowSpeedHR IsNot Nothing) Then
					RemoveHandler Me._ShowSpeedHR.CheckedChanged,  eventHandler
				End If
				Me._ShowSpeedHR = value
				If (Me._ShowSpeedHR IsNot Nothing) Then
					AddHandler Me._ShowSpeedHR.CheckedChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Speed As Label
			Get
				Return Me._Speed
			End Get
			Set(ByVal value As Label)
				Me._Speed = value
			End Set
		End Property

		Friend Overridable Property SpeedLabel As Label
			Get
				Return Me._SpeedLabel
			End Get
			Set(ByVal value As Label)
				Me._SpeedLabel = value
			End Set
		End Property

		Friend Overridable Property SpeedPanel As Panel
			Get
				Return Me._SpeedPanel
			End Get
			Set(ByVal value As Panel)
				Me._SpeedPanel = value
			End Set
		End Property

		Friend Overridable Property SPM As Label
			Get
				Return Me._SPM
			End Get
			Set(ByVal value As Label)
				Me._SPM = value
			End Set
		End Property

		Friend Overridable Property StatusMessage As Label
			Get
				Return Me._StatusMessage
			End Get
			Set(ByVal value As Label)
				Me._StatusMessage = value
			End Set
		End Property

		Friend Overridable Property TotalCalsLabel As Label
			Get
				Return Me._TotalCalsLabel
			End Get
			Set(ByVal value As Label)
				Me._TotalCalsLabel = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Dim recorderMainWindow1 As RecorderMainWindow = Me
			AddHandler MyBase.FormClosing,  New FormClosingEventHandler(AddressOf recorderMainWindow1.MainForm_FormClosing)
			Dim recorderMainWindow2 As RecorderMainWindow = Me
			AddHandler MyBase.Load,  New EventHandler(AddressOf recorderMainWindow2.MainForm_Load)
			Me.oRowerDataSource = New ConsoleProxy()
			Me.oSessionStats = New SessionStats()
			Me.oSessionWriter = New SessionWriter()
			Me.CurrentHR = 0
			Me.FirstConnect = True
			Me.MyFormClosed = False
			Me.eSessionState = RecorderMainWindow.SessionState.Ready
			Me.InitializeComponent()
		End Sub

		Public Function CheckSaveData(Optional ByVal bAllowCancel As Boolean = True) As System.Windows.Forms.DialogResult
			If (Not Me.oSessionWriter.SaveRequired) Then
				Return System.Windows.Forms.DialogResult.None
			End If
			If (bAllowCancel) Then
				Return MessageBox.Show("Do you want to save your Session Data?", "Save Session Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
			End If
			Return MessageBox.Show("Do you want to save your Session Data?", "Save Session Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		End Function

		Private Sub ConfigureButtons()
			Me.LevelUp.Enabled = True
			Me.LevelDown.Enabled = True
			Me.LevelUp.Visible = True
			Me.LevelDown.Visible = True
			Me.NewSession.Visible = True
			Me.SetState(RecorderMainWindow.SessionState.Ready)
		End Sub

		Private Sub ConfigureChart()
			Select Case MySettingsProperty.Settings.DefaultView
				Case 0
					Me.SessionChart.ChartAreas(0).Visible = True
					Me.SessionChart.ChartAreas(1).Visible = False
					Me.ShowSpeedHR.Checked = True
					Exit Select
				Case 1
					Me.SessionChart.ChartAreas(0).Visible = False
					Me.SessionChart.ChartAreas(1).Visible = True
					Me.ShowPowerSPM.Checked = True
					Exit Select
				Case 2
					Me.SessionChart.ChartAreas(0).Visible = True
					Me.SessionChart.ChartAreas(1).Visible = True
					Me.ShowBoth.Checked = True
					Exit Select
			End Select
		End Sub

		Private Sub ConnectTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Me.TryConnectConsole()
		End Sub

		Public Sub DataSourceHandler(ByVal dt As RowerDataEventType)
			Me.dataEvent = dt
			Dim recorderMainWindow As SessionRecorder.RecorderMainWindow = Me
			Me.Invoke(New MethodInvoker(AddressOf recorderMainWindow.ProcessDataEvent))
		End Sub

		<DebuggerNonUserCode>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If (disposing AndAlso Me.components IsNot Nothing) Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
            'Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecorderMainWindow))
            Dim chartArea As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
			Dim customLabel As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel1 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel2 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel3 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel4 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel5 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel6 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel7 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel8 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim customLabel9 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
			Dim font As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
			Dim legend As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
			Dim transparent As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
			Dim series As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
			Dim yellow As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
			Dim lime As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
			Dim series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
			Dim title As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
			Me.SpeedPanel = New System.Windows.Forms.Panel()
			Me.Average = New System.Windows.Forms.Label()
			Me.Speed = New System.Windows.Forms.Label()
			Me.SpeedLabel = New System.Windows.Forms.Label()
			Me.Panel1 = New System.Windows.Forms.Panel()
			Me.Duration = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Panel2 = New System.Windows.Forms.Panel()
			Me.HeartRate = New System.Windows.Forms.Label()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.Panel3 = New System.Windows.Forms.Panel()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.SPM = New System.Windows.Forms.Label()
			Me.Panel4 = New System.Windows.Forms.Panel()
			Me.LevelUp = New System.Windows.Forms.Button()
			Me.LevelDown = New System.Windows.Forms.Button()
			Me.Level = New System.Windows.Forms.Label()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.Panel5 = New System.Windows.Forms.Panel()
			Me.TotalCalsLabel = New System.Windows.Forms.Label()
			Me.Cals = New System.Windows.Forms.Label()
			Me.CalsLabel = New System.Windows.Forms.Label()
			Me.Panel6 = New System.Windows.Forms.Panel()
			Me.Power = New System.Windows.Forms.Label()
			Me.Label12 = New System.Windows.Forms.Label()
			Me.Panel7 = New System.Windows.Forms.Panel()
			Me.Distance = New System.Windows.Forms.Label()
			Me.Label14 = New System.Windows.Forms.Label()
			Me.NewSession = New System.Windows.Forms.Button()
			Me.LaunchViewer = New System.Windows.Forms.Button()
			Me.Quit = New System.Windows.Forms.Button()
			Me.Settings = New System.Windows.Forms.Button()
			Me.SaveSession = New System.Windows.Forms.Button()
			Me.SessionTimer = New Timer(Me.components)
			Me.SessionChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
			Me.GraphControlPanel = New System.Windows.Forms.Panel()
			Me.ShowBoth = New System.Windows.Forms.RadioButton()
			Me.ShowSpeedHR = New System.Windows.Forms.RadioButton()
			Me.ShowPowerSPM = New System.Windows.Forms.RadioButton()
			Me.StatusMessage = New System.Windows.Forms.Label()
			Me.KeepAliveTimer = New Timer(Me.components)
			Me.ConnectTimer = New Timer(Me.components)
			Me.GroupBox1 = New System.Windows.Forms.GroupBox()
			Me.SpeedPanel.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel7.SuspendLayout()
			DirectCast(Me.SessionChart, ISupportInitialize).BeginInit()
			Me.GraphControlPanel.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.SuspendLayout()
			Me.SpeedPanel.BorderStyle = BorderStyle.FixedSingle
			Me.SpeedPanel.Controls.Add(Me.Average)
			Me.SpeedPanel.Controls.Add(Me.Speed)
			Me.SpeedPanel.Controls.Add(Me.SpeedLabel)
			Dim speedPanel As System.Windows.Forms.Panel = Me.SpeedPanel
			Dim point As System.Drawing.Point = New System.Drawing.Point(11, 133)
			speedPanel.Location = point
			Me.SpeedPanel.Name = "SpeedPanel"
			Dim panel As System.Windows.Forms.Panel = Me.SpeedPanel
			Dim size As System.Drawing.Size = New System.Drawing.Size(360, 117)
			panel.Size = size
			Me.SpeedPanel.TabIndex = 0
			Me.Average.AutoSize = True
			Me.Average.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Average.ForeColor = Color.Red
			Dim average As System.Windows.Forms.Label = Me.Average
			point = New System.Drawing.Point(3, 91)
			average.Location = point
			Me.Average.Name = "Average"
			Dim label As System.Windows.Forms.Label = Me.Average
			size = New System.Drawing.Size(77, 19)
			label.Size = size
			Me.Average.TabIndex = 2
			Me.Average.Text = "Average"
			Me.Average.Visible = False
			Me.Speed.BackColor = Color.Transparent
			Me.Speed.Dock = DockStyle.Top
			Me.Speed.Font = New System.Drawing.Font("Tahoma", 58!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Speed.ForeColor = Color.Yellow
			Dim speed As System.Windows.Forms.Label = Me.Speed
			point = New System.Drawing.Point(0, 0)
			speed.Location = point
			Me.Speed.Name = "Speed"
			Dim speed1 As System.Windows.Forms.Label = Me.Speed
			size = New System.Drawing.Size(358, 94)
			speed1.Size = size
			Me.Speed.TabIndex = 1
			Me.Speed.Text = "00:00"
			Me.Speed.TextAlign = ContentAlignment.MiddleCenter
			Me.Speed.UseMnemonic = False
			Me.SpeedLabel.BackColor = Color.Transparent
			Me.SpeedLabel.Dock = DockStyle.Bottom
			Me.SpeedLabel.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.SpeedLabel.ForeColor = Color.White
			Dim speedLabel As System.Windows.Forms.Label = Me.SpeedLabel
			point = New System.Drawing.Point(0, 92)
			speedLabel.Location = point
			Me.SpeedLabel.Name = "SpeedLabel"
			Dim speedLabel1 As System.Windows.Forms.Label = Me.SpeedLabel
			size = New System.Drawing.Size(358, 23)
			speedLabel1.Size = size
			Me.SpeedLabel.TabIndex = 0
			Me.SpeedLabel.Text = "Speed (500m Time)"
			Me.SpeedLabel.TextAlign = ContentAlignment.MiddleCenter
			Me.SpeedLabel.UseMnemonic = False
			Me.Panel1.BackColor = Color.Transparent
			Me.Panel1.BorderStyle = BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Duration)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.Panel1.ForeColor = Color.White
			Dim panel1 As System.Windows.Forms.Panel = Me.Panel1
			point = New System.Drawing.Point(11, 10)
			panel1.Location = point
			Me.Panel1.Name = "Panel1"
			Dim panel11 As System.Windows.Forms.Panel = Me.Panel1
			size = New System.Drawing.Size(360, 117)
			panel11.Size = size
			Me.Panel1.TabIndex = 1
			Me.Duration.BackColor = Color.Transparent
			Me.Duration.Dock = DockStyle.Top
			Me.Duration.Font = New System.Drawing.Font("Tahoma", 58!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Duration.ForeColor = Color.White
			Dim duration As System.Windows.Forms.Label = Me.Duration
			point = New System.Drawing.Point(0, 0)
			duration.Location = point
			Me.Duration.Name = "Duration"
			Dim duration1 As System.Windows.Forms.Label = Me.Duration
			size = New System.Drawing.Size(358, 94)
			duration1.Size = size
			Me.Duration.TabIndex = 1
			Me.Duration.Text = "0:00:00"
			Me.Duration.TextAlign = ContentAlignment.MiddleCenter
			Me.Duration.UseMnemonic = False
			Me.Label2.BackColor = Color.Transparent
			Me.Label2.Dock = DockStyle.Bottom
			Me.Label2.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Color.White
			Dim label2 As System.Windows.Forms.Label = Me.Label2
			point = New System.Drawing.Point(0, 92)
			label2.Location = point
			Me.Label2.Name = "Label2"
			Dim label21 As System.Windows.Forms.Label = Me.Label2
			size = New System.Drawing.Size(358, 23)
			label21.Size = size
			Me.Label2.TabIndex = 0
			Me.Label2.Text = "Session Time"
			Me.Label2.TextAlign = ContentAlignment.MiddleCenter
			Me.Label2.UseMnemonic = False
			Me.Panel2.BorderStyle = BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.HeartRate)
			Me.Panel2.Controls.Add(Me.Label4)
			Dim panel2 As System.Windows.Forms.Panel = Me.Panel2
			point = New System.Drawing.Point(197, 256)
			panel2.Location = point
			Me.Panel2.Name = "Panel2"
			Dim panel21 As System.Windows.Forms.Panel = Me.Panel2
			size = New System.Drawing.Size(174, 74)
			panel21.Size = size
			Me.Panel2.TabIndex = 2
			Me.HeartRate.BackColor = Color.Transparent
			Me.HeartRate.Dock = DockStyle.Top
			Me.HeartRate.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.HeartRate.ForeColor = Color.DodgerBlue
			Dim heartRate As System.Windows.Forms.Label = Me.HeartRate
			point = New System.Drawing.Point(0, 0)
			heartRate.Location = point
			Me.HeartRate.Name = "HeartRate"
			Dim heartRate1 As System.Windows.Forms.Label = Me.HeartRate
			size = New System.Drawing.Size(172, 49)
			heartRate1.Size = size
			Me.HeartRate.TabIndex = 1
			Me.HeartRate.Text = "0"
			Me.HeartRate.TextAlign = ContentAlignment.MiddleCenter
			Me.HeartRate.UseMnemonic = False
			Me.Label4.BackColor = Color.Transparent
			Me.Label4.Dock = DockStyle.Bottom
			Me.Label4.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Color.White
			Dim label4 As System.Windows.Forms.Label = Me.Label4
			point = New System.Drawing.Point(0, 49)
			label4.Location = point
			Me.Label4.Name = "Label4"
			Dim label41 As System.Windows.Forms.Label = Me.Label4
			size = New System.Drawing.Size(172, 23)
			label41.Size = size
			Me.Label4.TabIndex = 0
			Me.Label4.Text = "Heart Rate"
			Me.Label4.TextAlign = ContentAlignment.MiddleCenter
			Me.Label4.UseMnemonic = False
			Me.Panel3.BorderStyle = BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.Label6)
			Me.Panel3.Controls.Add(Me.SPM)
			Dim panel3 As System.Windows.Forms.Panel = Me.Panel3
			point = New System.Drawing.Point(11, 256)
			panel3.Location = point
			Me.Panel3.Name = "Panel3"
			Dim panel31 As System.Windows.Forms.Panel = Me.Panel3
			size = New System.Drawing.Size(180, 74)
			panel31.Size = size
			Me.Panel3.TabIndex = 3
			Me.Label6.BackColor = Color.Transparent
			Me.Label6.Dock = DockStyle.Bottom
			Me.Label6.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Color.White
			Dim label6 As System.Windows.Forms.Label = Me.Label6
			point = New System.Drawing.Point(0, 49)
			label6.Location = point
			Me.Label6.Name = "Label6"
			Dim label61 As System.Windows.Forms.Label = Me.Label6
			size = New System.Drawing.Size(178, 23)
			label61.Size = size
			Me.Label6.TabIndex = 0
			Me.Label6.Text = "SPM"
			Me.Label6.TextAlign = ContentAlignment.MiddleCenter
			Me.Label6.UseMnemonic = False
			Me.SPM.BackColor = Color.Transparent
			Me.SPM.Dock = DockStyle.Top
			Me.SPM.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.SPM.ForeColor = Color.FromArgb(255, 128, 0)
			Dim sPM As System.Windows.Forms.Label = Me.SPM
			point = New System.Drawing.Point(0, 0)
			sPM.Location = point
			Me.SPM.Name = "SPM"
			Dim sPM1 As System.Windows.Forms.Label = Me.SPM
			size = New System.Drawing.Size(178, 49)
			sPM1.Size = size
			Me.SPM.TabIndex = 1
			Me.SPM.Text = "0"
			Me.SPM.TextAlign = ContentAlignment.MiddleCenter
			Me.SPM.UseMnemonic = False
			Me.Panel4.BorderStyle = BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.LevelUp)
			Me.Panel4.Controls.Add(Me.LevelDown)
			Me.Panel4.Controls.Add(Me.Level)
			Me.Panel4.Controls.Add(Me.Label8)
			Dim panel4 As System.Windows.Forms.Panel = Me.Panel4
			point = New System.Drawing.Point(197, 416)
			panel4.Location = point
			Me.Panel4.Name = "Panel4"
			Dim panel41 As System.Windows.Forms.Panel = Me.Panel4
			size = New System.Drawing.Size(174, 74)
			panel41.Size = size
			Me.Panel4.TabIndex = 4
			Me.LevelUp.FlatAppearance.MouseDownBackColor = Color.Transparent
			Me.LevelUp.FlatAppearance.MouseOverBackColor = Color.DimGray
			Me.LevelUp.FlatStyle = FlatStyle.Popup
			Me.LevelUp.Font = New System.Drawing.Font("Tahoma", 6!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.LevelUp.Image = My.Resources.LevelUp_Image
            Dim levelUp As System.Windows.Forms.Button = Me.LevelUp
			point = New System.Drawing.Point(140, 1)
			levelUp.Location = point
			Me.LevelUp.Name = "LevelUp"
			Dim button As System.Windows.Forms.Button = Me.LevelUp
			size = New System.Drawing.Size(29, 28)
			button.Size = size
			Me.LevelUp.TabIndex = 23
			Me.LevelUp.UseVisualStyleBackColor = True
			Me.LevelUp.Visible = False
			Me.LevelDown.FlatAppearance.MouseDownBackColor = Color.Transparent
			Me.LevelDown.FlatAppearance.MouseOverBackColor = Color.DimGray
			Me.LevelDown.FlatStyle = FlatStyle.Popup
			Me.LevelDown.Font = New System.Drawing.Font("Tahoma", 6!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.LevelDown.Image = My.Resources.LevelDown_Image
            Dim levelDown As System.Windows.Forms.Button = Me.LevelDown
			point = New System.Drawing.Point(140, 39)
			levelDown.Location = point
			Me.LevelDown.Name = "LevelDown"
			Dim levelDown1 As System.Windows.Forms.Button = Me.LevelDown
			size = New System.Drawing.Size(29, 28)
			levelDown1.Size = size
			Me.LevelDown.TabIndex = 22
			Me.LevelDown.UseVisualStyleBackColor = True
			Me.LevelDown.Visible = False
			Me.Level.BackColor = Color.Transparent
			Me.Level.Dock = DockStyle.Top
			Me.Level.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Level.ForeColor = Color.MediumAquamarine
			Dim level As System.Windows.Forms.Label = Me.Level
			point = New System.Drawing.Point(0, 0)
			level.Location = point
			Me.Level.Name = "Level"
			Dim level1 As System.Windows.Forms.Label = Me.Level
			size = New System.Drawing.Size(172, 49)
			level1.Size = size
			Me.Level.TabIndex = 1
			Me.Level.Text = "0"
			Me.Level.TextAlign = ContentAlignment.MiddleCenter
			Me.Level.UseMnemonic = False
			Me.Label8.BackColor = Color.Transparent
			Me.Label8.Dock = DockStyle.Bottom
			Me.Label8.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Color.White
			Dim label8 As System.Windows.Forms.Label = Me.Label8
			point = New System.Drawing.Point(0, 49)
			label8.Location = point
			Me.Label8.Name = "Label8"
			Dim label81 As System.Windows.Forms.Label = Me.Label8
			size = New System.Drawing.Size(172, 23)
			label81.Size = size
			Me.Label8.TabIndex = 0
			Me.Label8.Text = "Level"
			Me.Label8.TextAlign = ContentAlignment.MiddleCenter
			Me.Label8.UseMnemonic = False
			Me.Panel5.BorderStyle = BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.TotalCalsLabel)
			Me.Panel5.Controls.Add(Me.Cals)
			Me.Panel5.Controls.Add(Me.CalsLabel)
			Dim panel5 As System.Windows.Forms.Panel = Me.Panel5
			point = New System.Drawing.Point(196, 336)
			panel5.Location = point
			Me.Panel5.Name = "Panel5"
			Dim panel51 As System.Windows.Forms.Panel = Me.Panel5
			size = New System.Drawing.Size(174, 74)
			panel51.Size = size
			Me.Panel5.TabIndex = 5
			Me.TotalCalsLabel.BackColor = Color.Transparent
			Me.TotalCalsLabel.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.TotalCalsLabel.ForeColor = Color.Red
			Dim totalCalsLabel As System.Windows.Forms.Label = Me.TotalCalsLabel
			point = New System.Drawing.Point(0, 47)
			totalCalsLabel.Location = point
			Me.TotalCalsLabel.Name = "TotalCalsLabel"
			Dim totalCalsLabel1 As System.Windows.Forms.Label = Me.TotalCalsLabel
			size = New System.Drawing.Size(172, 23)
			totalCalsLabel1.Size = size
			Me.TotalCalsLabel.TabIndex = 2
			Me.TotalCalsLabel.Text = "Total Cals"
			Me.TotalCalsLabel.TextAlign = ContentAlignment.MiddleCenter
			Me.TotalCalsLabel.UseMnemonic = False
			Me.TotalCalsLabel.Visible = False
			Me.Cals.BackColor = Color.Transparent
			Me.Cals.Dock = DockStyle.Top
			Me.Cals.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Cals.ForeColor = Color.White
			Dim cals As System.Windows.Forms.Label = Me.Cals
			point = New System.Drawing.Point(0, 0)
			cals.Location = point
			Me.Cals.Name = "Cals"
			Dim cals1 As System.Windows.Forms.Label = Me.Cals
			size = New System.Drawing.Size(172, 49)
			cals1.Size = size
			Me.Cals.TabIndex = 1
			Me.Cals.Text = "0"
			Me.Cals.TextAlign = ContentAlignment.MiddleCenter
			Me.Cals.UseMnemonic = False
			Me.CalsLabel.BackColor = Color.Transparent
			Me.CalsLabel.Dock = DockStyle.Bottom
			Me.CalsLabel.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.CalsLabel.ForeColor = Color.White
			Dim calsLabel As System.Windows.Forms.Label = Me.CalsLabel
			point = New System.Drawing.Point(0, 49)
			calsLabel.Location = point
			Me.CalsLabel.Name = "CalsLabel"
			Dim calsLabel1 As System.Windows.Forms.Label = Me.CalsLabel
			size = New System.Drawing.Size(172, 23)
			calsLabel1.Size = size
			Me.CalsLabel.TabIndex = 0
			Me.CalsLabel.Text = "Cals/hr"
			Me.CalsLabel.TextAlign = ContentAlignment.MiddleCenter
			Me.CalsLabel.UseMnemonic = False
			Me.Panel6.BorderStyle = BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.Power)
			Me.Panel6.Controls.Add(Me.Label12)
			Dim panel6 As System.Windows.Forms.Panel = Me.Panel6
			point = New System.Drawing.Point(11, 336)
			panel6.Location = point
			Me.Panel6.Name = "Panel6"
			Dim panel61 As System.Windows.Forms.Panel = Me.Panel6
			size = New System.Drawing.Size(180, 74)
			panel61.Size = size
			Me.Panel6.TabIndex = 6
			Me.Power.BackColor = Color.Transparent
			Me.Power.Dock = DockStyle.Top
			Me.Power.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Power.ForeColor = Color.Lime
			Dim power As System.Windows.Forms.Label = Me.Power
			point = New System.Drawing.Point(0, 0)
			power.Location = point
			Me.Power.Name = "Power"
			Dim power1 As System.Windows.Forms.Label = Me.Power
			size = New System.Drawing.Size(178, 49)
			power1.Size = size
			Me.Power.TabIndex = 1
			Me.Power.Text = "0"
			Me.Power.TextAlign = ContentAlignment.MiddleCenter
			Me.Power.UseMnemonic = False
			Me.Label12.BackColor = Color.Transparent
			Me.Label12.Dock = DockStyle.Bottom
			Me.Label12.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label12.ForeColor = Color.White
			Dim label12 As System.Windows.Forms.Label = Me.Label12
			point = New System.Drawing.Point(0, 49)
			label12.Location = point
			Me.Label12.Name = "Label12"
			Dim label121 As System.Windows.Forms.Label = Me.Label12
			size = New System.Drawing.Size(178, 23)
			label121.Size = size
			Me.Label12.TabIndex = 0
			Me.Label12.Text = "Power (Watts)"
			Me.Label12.TextAlign = ContentAlignment.MiddleCenter
			Me.Label12.UseMnemonic = False
			Me.Panel7.BorderStyle = BorderStyle.FixedSingle
			Me.Panel7.Controls.Add(Me.Distance)
			Me.Panel7.Controls.Add(Me.Label14)
			Dim panel7 As System.Windows.Forms.Panel = Me.Panel7
			point = New System.Drawing.Point(11, 416)
			panel7.Location = point
			Me.Panel7.Name = "Panel7"
			Dim panel71 As System.Windows.Forms.Panel = Me.Panel7
			size = New System.Drawing.Size(180, 74)
			panel71.Size = size
			Me.Panel7.TabIndex = 9
			Me.Distance.BackColor = Color.Transparent
			Me.Distance.Dock = DockStyle.Top
			Me.Distance.Font = New System.Drawing.Font("Tahoma", 32!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Distance.ForeColor = Color.White
			Dim distance As System.Windows.Forms.Label = Me.Distance
			point = New System.Drawing.Point(0, 0)
			distance.Location = point
			Me.Distance.Name = "Distance"
			Dim distance1 As System.Windows.Forms.Label = Me.Distance
			size = New System.Drawing.Size(178, 49)
			distance1.Size = size
			Me.Distance.TabIndex = 1
			Me.Distance.Text = "0"
			Me.Distance.TextAlign = ContentAlignment.MiddleRight
			Me.Distance.UseMnemonic = False
			Me.Label14.BackColor = Color.Transparent
			Me.Label14.Dock = DockStyle.Bottom
			Me.Label14.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Color.White
			Dim label14 As System.Windows.Forms.Label = Me.Label14
			point = New System.Drawing.Point(0, 49)
			label14.Location = point
			Me.Label14.Name = "Label14"
			Dim label141 As System.Windows.Forms.Label = Me.Label14
			size = New System.Drawing.Size(178, 23)
			label141.Size = size
			Me.Label14.TabIndex = 0
			Me.Label14.Text = "Distance (m)"
			Me.Label14.TextAlign = ContentAlignment.MiddleCenter
			Me.Label14.UseMnemonic = False
			Me.NewSession.Enabled = False
			Me.NewSession.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.NewSession.ForeColor = SystemColors.ControlText
			Dim newSession As System.Windows.Forms.Button = Me.NewSession
			point = New System.Drawing.Point(128, 21)
			newSession.Location = point
			Me.NewSession.Name = "NewSession"
			Dim newSession1 As System.Windows.Forms.Button = Me.NewSession
			size = New System.Drawing.Size(109, 30)
			newSession1.Size = size
			Me.NewSession.TabIndex = 4
			Me.NewSession.Text = "New Session"
			Me.NewSession.UseVisualStyleBackColor = True
			Me.NewSession.Visible = False
			Me.LaunchViewer.Enabled = False
			Me.LaunchViewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.LaunchViewer.ForeColor = SystemColors.ControlText
			Dim launchViewer As System.Windows.Forms.Button = Me.LaunchViewer
			point = New System.Drawing.Point(248, 21)
			launchViewer.Location = point
			Me.LaunchViewer.Name = "LaunchViewer"
			Dim launchViewer1 As System.Windows.Forms.Button = Me.LaunchViewer
			size = New System.Drawing.Size(109, 30)
			launchViewer1.Size = size
			Me.LaunchViewer.TabIndex = 3
			Me.LaunchViewer.Text = "View History"
			Me.LaunchViewer.UseVisualStyleBackColor = True
			Me.Quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Quit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.Quit.ForeColor = Color.Red
			Dim quit As System.Windows.Forms.Button = Me.Quit
			point = New System.Drawing.Point(248, 60)
			quit.Location = point
			Me.Quit.Name = "Quit"
			Dim quit1 As System.Windows.Forms.Button = Me.Quit
			size = New System.Drawing.Size(109, 30)
			quit1.Size = size
			Me.Quit.TabIndex = 0
			Me.Quit.Text = "Quit"
			Me.Quit.UseVisualStyleBackColor = True
			Me.Settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.Settings.ForeColor = SystemColors.ControlText
			Dim settings As System.Windows.Forms.Button = Me.Settings
			point = New System.Drawing.Point(8, 60)
			settings.Location = point
			Me.Settings.Name = "Settings"
			Dim settings1 As System.Windows.Forms.Button = Me.Settings
			size = New System.Drawing.Size(109, 30)
			settings1.Size = size
			Me.Settings.TabIndex = 1
			Me.Settings.Text = "Settings"
			Me.Settings.UseVisualStyleBackColor = True
			Me.SaveSession.Enabled = False
			Me.SaveSession.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.SaveSession.ForeColor = SystemColors.ControlText
			Dim saveSession As System.Windows.Forms.Button = Me.SaveSession
			point = New System.Drawing.Point(8, 21)
			saveSession.Location = point
			Me.SaveSession.Name = "SaveSession"
			Dim saveSession1 As System.Windows.Forms.Button = Me.SaveSession
			size = New System.Drawing.Size(109, 30)
			saveSession1.Size = size
			Me.SaveSession.TabIndex = 2
			Me.SaveSession.Text = "Save Session"
			Me.SaveSession.UseVisualStyleBackColor = True
			Me.SessionTimer.Interval = 1000
			Me.SessionChart.BackColor = Color.Black
			Me.SessionChart.BackSecondaryColor = Color.WhiteSmoke
			Me.SessionChart.BorderlineColor = Color.DimGray
			Me.SessionChart.BorderlineDashStyle = ChartDashStyle.Solid
			Me.SessionChart.BorderSkin.BackColor = Color.Transparent
			Me.SessionChart.BorderSkin.BackSecondaryColor = Color.White
			Me.SessionChart.BorderSkin.BorderColor = Color.Transparent
			Me.SessionChart.BorderSkin.BorderWidth = 0
			Me.SessionChart.BorderSkin.PageColor = Color.Transparent
			chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
			chartArea.AxisX.IsLabelAutoFit = False
			chartArea.AxisX.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisX.LabelStyle.ForeColor = Color.White
			chartArea.AxisX.LabelStyle.Format = "#0"
			chartArea.AxisX.MajorGrid.Interval = 10
			chartArea.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Auto
			chartArea.AxisX.MajorGrid.LineColor = Color.White
			chartArea.AxisX.Maximum = 60
			chartArea.AxisX.Minimum = 0
			chartArea.AxisX.MinorGrid.Interval = 15
			chartArea.AxisX.ScaleView.Zoomable = False
			chartArea.AxisX.Title = "Time (s)"
			chartArea.AxisX.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisX.TitleForeColor = Color.White
			chartArea.AxisX2.IntervalAutoMode = IntervalAutoMode.VariableCount
			chartArea.AxisX2.IsLabelAutoFit = False
			chartArea.AxisX2.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisX2.LabelStyle.ForeColor = Color.White
			chartArea.AxisX2.LabelStyle.Format = "#0.0"
			chartArea.AxisX2.MajorGrid.Interval = 100
			chartArea.AxisX2.MajorGrid.IntervalType = DateTimeIntervalType.Auto
			chartArea.AxisX2.Maximum = 60
			chartArea.AxisX2.Minimum = 0
			chartArea.AxisX2.Title = "Time (s)"
			chartArea.AxisX2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisX2.TitleForeColor = Color.White
			chartArea.AxisY.Crossing = Double.MinValue
			customLabel.FromPosition = 15
			customLabel.Text = "0:30"
			customLabel.ToPosition = 45
			customLabel1.FromPosition = 45
			customLabel1.Text = "1:00"
			customLabel1.ToPosition = 75
			customLabel2.FromPosition = 75
			customLabel2.Text = "1:30"
			customLabel2.ToPosition = 105
			customLabel3.FromPosition = 105
			customLabel3.Text = "2:00"
			customLabel3.ToPosition = 135
			customLabel4.FromPosition = 135
			customLabel4.Text = "2:30"
			customLabel4.ToPosition = 165
			customLabel5.FromPosition = 165
			customLabel5.Text = "3:00"
			customLabel5.ToPosition = 195
			customLabel6.FromPosition = 195
			customLabel6.Text = "3:30"
			customLabel6.ToPosition = 225
			customLabel7.FromPosition = 225
			customLabel7.Text = "4:00"
			customLabel7.ToPosition = 255
			customLabel8.FromPosition = 255
			customLabel8.Text = "4:30"
			customLabel8.ToPosition = 285
			customLabel9.FromPosition = 285
			customLabel9.Text = " 5:00"
			customLabel9.ToPosition = 315
			chartArea.AxisY.CustomLabels.Add(customLabel)
			chartArea.AxisY.CustomLabels.Add(customLabel1)
			chartArea.AxisY.CustomLabels.Add(customLabel2)
			chartArea.AxisY.CustomLabels.Add(customLabel3)
			chartArea.AxisY.CustomLabels.Add(customLabel4)
			chartArea.AxisY.CustomLabels.Add(customLabel5)
			chartArea.AxisY.CustomLabels.Add(customLabel6)
			chartArea.AxisY.CustomLabels.Add(customLabel7)
			chartArea.AxisY.CustomLabels.Add(customLabel8)
			chartArea.AxisY.CustomLabels.Add(customLabel9)
			chartArea.AxisY.Interval = 60
			chartArea.AxisY.IsLabelAutoFit = False
			chartArea.AxisY.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisY.LabelStyle.ForeColor = Color.White
			chartArea.AxisY.LabelStyle.Format = "####0"
			chartArea.AxisY.MajorGrid.IntervalType = DateTimeIntervalType.Auto
			chartArea.AxisY.MajorGrid.LineColor = Color.White
			chartArea.AxisY.MajorTickMark.Enabled = False
			chartArea.AxisY.Maximum = 300
			chartArea.AxisY.Minimum = 0
			chartArea.AxisY.MinorGrid.Enabled = True
			chartArea.AxisY.MinorGrid.Interval = 30
			chartArea.AxisY.MinorGrid.LineColor = Color.FromArgb(48, 48, 48)
			chartArea.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash
			chartArea.AxisY.Title = "500m Time"
			chartArea.AxisY.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisY.TitleForeColor = Color.White
			chartArea.AxisY2.Interval = 25
			chartArea.AxisY2.IsLabelAutoFit = False
			chartArea.AxisY2.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisY2.LabelStyle.ForeColor = Color.White
			chartArea.AxisY2.LabelStyle.Format = "#0"
			chartArea.AxisY2.MajorGrid.IntervalType = DateTimeIntervalType.Auto
			chartArea.AxisY2.MajorGrid.LineColor = Color.White
			chartArea.AxisY2.MajorTickMark.Enabled = False
			chartArea.AxisY2.Maximum = 175
			chartArea.AxisY2.Minimum = 50
			chartArea.AxisY2.MinorGrid.LineDashStyle = ChartDashStyle.NotSet
			chartArea.AxisY2.Title = "Heart Rate (BPM)"
			chartArea.AxisY2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			chartArea.AxisY2.TitleForeColor = Color.White
			chartArea.BackColor = Color.Transparent
			chartArea.BackSecondaryColor = Color.White
			chartArea.BorderColor = Color.White
			chartArea.BorderDashStyle = ChartDashStyle.Solid
			chartArea.BorderWidth = 2
			chartArea.IsSameFontSizeForAllAxes = True
			chartArea.Name = "ChartArea1"
			font.AxisX.Interval = 5
			font.AxisX.IsLabelAutoFit = False
			font.AxisX.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisX.LabelStyle.ForeColor = Color.White
			font.AxisX.LabelStyle.Format = "#0"
			font.AxisX.MajorGrid.LineColor = Color.White
			font.AxisX.Maximum = 20
			font.AxisX.Minimum = 0
			font.AxisX.Title = "Stroke Number"
			font.AxisX.TitleFont = New System.Drawing.Font("Tahoma", 8!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisX.TitleForeColor = Color.White
			font.AxisX2.IsLabelAutoFit = False
			font.AxisX2.LabelStyle.ForeColor = Color.White
			font.AxisX2.TitleForeColor = Color.White
			font.AxisY.Crossing = Double.MinValue
			font.AxisY.IsLabelAutoFit = False
			font.AxisY.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisY.LabelStyle.ForeColor = Color.White
			font.AxisY.LabelStyle.Format = "  #0"
			font.AxisY.MajorGrid.LineColor = Color.White
			font.AxisY.MajorTickMark.Enabled = False
			font.AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.InsideArea
			font.AxisY.Maximum = 200
			font.AxisY.Minimum = 0
			font.AxisY.Title = "Power (Watts)"
			font.AxisY.TitleFont = New System.Drawing.Font("Tahoma", 8!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisY.TitleForeColor = Color.White
			font.AxisY2.IsLabelAutoFit = False
			font.AxisY2.LabelStyle.Font = New System.Drawing.Font("Tahoma", 8!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisY2.LabelStyle.ForeColor = Color.White
			font.AxisY2.LabelStyle.Format = " #0"
			font.AxisY2.MajorGrid.LineColor = Color.White
			font.AxisY2.MajorTickMark.Enabled = False
			font.AxisY2.MajorTickMark.TickMarkStyle = TickMarkStyle.InsideArea
			font.AxisY2.Maximum = 50
			font.AxisY2.Minimum = 0
			font.AxisY2.Title = "SPM"
			font.AxisY2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			font.AxisY2.TitleForeColor = Color.White
			font.BackColor = Color.Black
			font.BackSecondaryColor = Color.White
			font.BorderColor = Color.White
			font.BorderDashStyle = ChartDashStyle.Solid
			font.BorderWidth = 2
			font.IsSameFontSizeForAllAxes = True
			font.Name = "ChartArea2"
			Me.SessionChart.ChartAreas.Add(chartArea)
			Me.SessionChart.ChartAreas.Add(font)
			legend.Alignment = StringAlignment.Far
			legend.BackColor = Color.Transparent
			legend.DockedToChartArea = "ChartArea1"
			legend.Docking = Docking.Bottom
			legend.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			legend.ForeColor = Color.DimGray
			legend.IsTextAutoFit = False
			legend.Name = "Legend1"
			legend.TitleAlignment = StringAlignment.Far
			transparent.Alignment = StringAlignment.Far
			transparent.BackColor = Color.Transparent
			transparent.DockedToChartArea = "ChartArea2"
			transparent.Docking = Docking.Bottom
			transparent.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			transparent.ForeColor = Color.Gray
			transparent.IsTextAutoFit = False
			transparent.Name = "Legend2"
			Me.SessionChart.Legends.Add(legend)
			Me.SessionChart.Legends.Add(transparent)
			Dim sessionChart As System.Windows.Forms.DataVisualization.Charting.Chart = Me.SessionChart
			point = New System.Drawing.Point(377, 10)
			sessionChart.Location = point
			Dim chart As System.Windows.Forms.DataVisualization.Charting.Chart = Me.SessionChart
			Dim padding As System.Windows.Forms.Padding = New System.Windows.Forms.Padding(0)
			chart.Margin = padding
			Me.SessionChart.Name = "SessionChart"
			Me.SessionChart.Palette = ChartColorPalette.None
			series.BorderWidth = 3
			series.ChartArea = "ChartArea1"
			series.ChartType = SeriesChartType.Line
			series.Color = Color.DodgerBlue
			series.LabelForeColor = Color.DarkRed
			series.Legend = "Legend1"
			series.Name = "Heart Rate"
			series.YAxisType = AxisType.Secondary
			yellow.BorderWidth = 3
			yellow.ChartArea = "ChartArea1"
			yellow.ChartType = SeriesChartType.Line
			yellow.Color = Color.Yellow
			yellow.Legend = "Legend1"
			yellow.Name = "500m Time"
			lime.BorderWidth = 3
			lime.ChartArea = "ChartArea2"
			lime.ChartType = SeriesChartType.Line
			lime.Color = Color.Lime
			lime.Legend = "Legend2"
			lime.Name = "Power"
			series1.BorderWidth = 3
			series1.ChartArea = "ChartArea2"
			series1.ChartType = SeriesChartType.Line
			series1.Color = Color.FromArgb(255, 128, 0)
			series1.Legend = "Legend2"
			series1.Name = "SPM"
			series1.YAxisType = AxisType.Secondary
			Me.SessionChart.Series.Add(series)
			Me.SessionChart.Series.Add(yellow)
			Me.SessionChart.Series.Add(lime)
			Me.SessionChart.Series.Add(series1)
			Dim sessionChart1 As System.Windows.Forms.DataVisualization.Charting.Chart = Me.SessionChart
			size = New System.Drawing.Size(888, 631)
			sessionChart1.Size = size
			Me.SessionChart.TabIndex = 23
			Me.SessionChart.Text = "Chart1"
			title.Alignment = ContentAlignment.TopLeft
			title.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Bold, GraphicsUnit.Point, 0)
			title.ForeColor = Color.Yellow
			title.Name = "Title1"
			title.Text = "Session Chart(s)"
			Me.SessionChart.Titles.Add(title)
			Me.GraphControlPanel.BackColor = Color.Transparent
			Me.GraphControlPanel.Controls.Add(Me.ShowBoth)
			Me.GraphControlPanel.Controls.Add(Me.ShowSpeedHR)
			Me.GraphControlPanel.Controls.Add(Me.ShowPowerSPM)
			Me.GraphControlPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.GraphControlPanel.ForeColor = Color.DarkRed
			Dim graphControlPanel As System.Windows.Forms.Panel = Me.GraphControlPanel
			point = New System.Drawing.Point(649, 14)
			graphControlPanel.Location = point
			Me.GraphControlPanel.Name = "GraphControlPanel"
			Dim graphControlPanel1 As System.Windows.Forms.Panel = Me.GraphControlPanel
			size = New System.Drawing.Size(344, 35)
			graphControlPanel1.Size = size
			Me.GraphControlPanel.TabIndex = 25
			Me.ShowBoth.AutoSize = True
			Me.ShowBoth.BackColor = Color.Transparent
			Me.ShowBoth.ForeColor = Color.White
			Dim showBoth As System.Windows.Forms.RadioButton = Me.ShowBoth
			point = New System.Drawing.Point(283, 9)
			showBoth.Location = point
			Me.ShowBoth.Name = "ShowBoth"
			Me.ShowBoth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Dim radioButton As System.Windows.Forms.RadioButton = Me.ShowBoth
			size = New System.Drawing.Size(47, 17)
			radioButton.Size = size
			Me.ShowBoth.TabIndex = 25
			Me.ShowBoth.TabStop = True
			Me.ShowBoth.Text = "Both"
			Me.ShowBoth.UseMnemonic = False
			Me.ShowBoth.UseVisualStyleBackColor = False
			Me.ShowSpeedHR.AutoSize = True
			Me.ShowSpeedHR.BackColor = Color.Transparent
			Me.ShowSpeedHR.Dock = DockStyle.Left
			Me.ShowSpeedHR.Font = New System.Drawing.Font("Tahoma", 8!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.ShowSpeedHR.ForeColor = Color.White
			Dim showSpeedHR As System.Windows.Forms.RadioButton = Me.ShowSpeedHR
			point = New System.Drawing.Point(0, 0)
			showSpeedHR.Location = point
			Me.ShowSpeedHR.Name = "ShowSpeedHR"
			Dim showSpeedHR1 As System.Windows.Forms.RadioButton = Me.ShowSpeedHR
			padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
			showSpeedHR1.Padding = padding
			Me.ShowSpeedHR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Dim radioButton1 As System.Windows.Forms.RadioButton = Me.ShowSpeedHR
			size = New System.Drawing.Size(126, 35)
			radioButton1.Size = size
			Me.ShowSpeedHR.TabIndex = 99
			Me.ShowSpeedHR.Text = "Speed & HR vs Time"
			Me.ShowSpeedHR.UseMnemonic = False
			Me.ShowSpeedHR.UseVisualStyleBackColor = False
			Me.ShowPowerSPM.AutoSize = True
			Me.ShowPowerSPM.BackColor = Color.Transparent
			Me.ShowPowerSPM.FlatAppearance.CheckedBackColor = Color.Transparent
			Me.ShowPowerSPM.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0)
			Me.ShowPowerSPM.FlatAppearance.MouseOverBackColor = Color.Blue
			Me.ShowPowerSPM.Font = New System.Drawing.Font("Tahoma", 8!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.ShowPowerSPM.ForeColor = Color.White
			Dim showPowerSPM As System.Windows.Forms.RadioButton = Me.ShowPowerSPM
			point = New System.Drawing.Point(134, 9)
			showPowerSPM.Location = point
			Me.ShowPowerSPM.Name = "ShowPowerSPM"
			Dim showPowerSPM1 As System.Windows.Forms.RadioButton = Me.ShowPowerSPM
			padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
			showPowerSPM1.Padding = padding
			Me.ShowPowerSPM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Dim showPowerSPM2 As System.Windows.Forms.RadioButton = Me.ShowPowerSPM
			size = New System.Drawing.Size(141, 17)
			showPowerSPM2.Size = size
			Me.ShowPowerSPM.TabIndex = 1
			Me.ShowPowerSPM.Text = "Power & SPM vs Stroke"
			Me.ShowPowerSPM.UseMnemonic = False
			Me.ShowPowerSPM.UseVisualStyleBackColor = False
			Me.StatusMessage.BackColor = Color.Yellow
			Me.StatusMessage.BorderStyle = BorderStyle.FixedSingle
			Me.StatusMessage.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim statusMessage As System.Windows.Forms.Label = Me.StatusMessage
			point = New System.Drawing.Point(8, 600)
			statusMessage.Location = point
			Me.StatusMessage.Name = "StatusMessage"
			Dim statusMessage1 As System.Windows.Forms.Label = Me.StatusMessage
			size = New System.Drawing.Size(363, 41)
			statusMessage1.Size = size
			Me.StatusMessage.TabIndex = 27
			Me.StatusMessage.Text = "Please connect an IPM or Console..."
			Me.StatusMessage.TextAlign = ContentAlignment.MiddleCenter
			Me.KeepAliveTimer.Interval = 60000
			Me.ConnectTimer.Interval = 1500
			Me.GroupBox1.Controls.Add(Me.SaveSession)
			Me.GroupBox1.Controls.Add(Me.LaunchViewer)
			Me.GroupBox1.Controls.Add(Me.NewSession)
			Me.GroupBox1.Controls.Add(Me.Settings)
			Me.GroupBox1.Controls.Add(Me.Quit)
			Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12!, FontStyle.Regular, GraphicsUnit.Point, 136)
			Me.GroupBox1.ForeColor = Color.White
			Dim groupBox1 As System.Windows.Forms.GroupBox = Me.GroupBox1
			point = New System.Drawing.Point(8, 493)
			groupBox1.Location = point
			Me.GroupBox1.Name = "GroupBox1"
			Dim groupBox As System.Windows.Forms.GroupBox = Me.GroupBox1
			size = New System.Drawing.Size(363, 101)
			groupBox.Size = size
			Me.GroupBox1.TabIndex = 29
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Control Panel"
			Me.AutoScaleDimensions = New SizeF(6!, 13!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Color.Black
			size = New System.Drawing.Size(1275, 652)
			Me.ClientSize = size
			Me.Controls.Add(Me.GroupBox1)
			Me.Controls.Add(Me.StatusMessage)
			Me.Controls.Add(Me.GraphControlPanel)
			Me.Controls.Add(Me.Panel7)
			Me.Controls.Add(Me.Panel6)
			Me.Controls.Add(Me.Panel5)
			Me.Controls.Add(Me.Panel4)
			Me.Controls.Add(Me.Panel3)
			Me.Controls.Add(Me.Panel2)
			Me.Controls.Add(Me.Panel1)
			Me.Controls.Add(Me.SpeedPanel)
			Me.Controls.Add(Me.SessionChart)
			Me.DoubleBuffered = True
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.Name = "RecorderMainWindow"
			Me.StartPosition = FormStartPosition.CenterScreen
			Me.Text = "First Degree Fitness Fluid Coach Session Recorder"
			Me.SpeedPanel.ResumeLayout(False)
			Me.SpeedPanel.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel5.ResumeLayout(False)
			Me.Panel6.ResumeLayout(False)
			Me.Panel7.ResumeLayout(False)
			DirectCast(Me.SessionChart, ISupportInitialize).EndInit()
			Me.GraphControlPanel.ResumeLayout(False)
			Me.GraphControlPanel.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)
		End Sub

		Private Sub KeepAliveTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Me.oRowerDataSource.KeepAlive()
		End Sub

		Private Sub KeepAwake_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Utilities.IdleTimerReset()
		End Sub

		Private Sub LaunchViewer_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MySettingsProperty.Settings.AutoSaveQuit) Then
				If (Me.oSessionWriter.SaveRequired) Then
					Me.oSessionWriter.CloseSession(Me.oSessionStats)
				End If
				Me.Hide()
				Me.oRowerDataSource.DisconnectConsole()
				Me.Close()
				Process.Start(".\SessionViewer.exe")
				Return
			End If
			Dim dialogResult As System.Windows.Forms.DialogResult = Me.CheckSaveData(True)
			If (dialogResult = System.Windows.Forms.DialogResult.Yes) Then
				Me.oSessionWriter.CloseSession(Me.oSessionStats)
			End If
			If (dialogResult = System.Windows.Forms.DialogResult.No) Then
				Me.oSessionWriter.CloseSession()
			End If
			If (dialogResult <> System.Windows.Forms.DialogResult.Cancel) Then
				Me.Hide()
				Me.oRowerDataSource.DisconnectConsole()
				Me.Close()
				Process.Start(".\SessionViewer.exe")
			End If
		End Sub

		Private Sub LevelDown_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.oRowerDataSource.LevelDown()
			Me.oSessionStats.Level = Me.oRowerDataSource.Level
		End Sub

		Private Sub LevelUp_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.oRowerDataSource.LevelUp()
			Me.oSessionStats.Level = Me.oRowerDataSource.Level
		End Sub

		Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			If (Not Me.MyFormClosed) Then
				If (MySettingsProperty.Settings.AutoSaveQuit) Then
					If (Me.oSessionWriter.SaveRequired) Then
						Me.oSessionWriter.CloseSession(Me.oSessionStats)
					End If
					Me.Hide()
					Me.MyFormClosed = True
					Me.ConnectTimer.[Stop]()
					Me.KeepAliveTimer.[Stop]()
					Me.SessionTimer.[Stop]()
					Me.oRowerDataSource.DisconnectConsole()
					Utilities.CloseDebugFile()
					Return
				End If
				Dim dialogResult As System.Windows.Forms.DialogResult = Me.CheckSaveData(True)
				If (dialogResult = System.Windows.Forms.DialogResult.Yes) Then
					Me.oSessionWriter.CloseSession(Me.oSessionStats)
				End If
				If (dialogResult = System.Windows.Forms.DialogResult.No) Then
					Me.oSessionWriter.CloseSession()
				End If
				If (dialogResult = System.Windows.Forms.DialogResult.Cancel) Then
					e.Cancel = True
				Else
					Me.Hide()
					Me.MyFormClosed = True
					Me.ConnectTimer.[Stop]()
					Me.KeepAliveTimer.[Stop]()
					Me.SessionTimer.[Stop]()
					Me.oRowerDataSource.DisconnectConsole()
					Utilities.CloseDebugFile()
				End If
			End If
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs)
			' 
			' Current member / type: System.Void SessionRecorder.RecorderMainWindow::MainForm_Load(System.Object,System.EventArgs)
			' File path: C:\Program Files (x86)\First Degree Fitness\First Degree Fitness Fluid Coach Application Bundle\SessionRecorder.exe
			' 
			' Product version: 2016.3.913.0
			' Exception in: System.Void MainForm_Load(System.Object,System.EventArgs)
			' 
			' The unary opperator AddressReference is not supported in VisualBasic
			'    at ..( ,  ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 22
			'    at ..(MethodBody ,  , ILanguage ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at ..( , ILanguage , MethodBody , & ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at ..(MethodBody , ILanguage , & ,  ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in c:\Builds\556\Behemoth\ReleaseBranch Production Build NT\Sources\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Private Sub NewSession_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MySettingsProperty.Settings.AutoSaveQuit) Then
				If (Me.oSessionWriter.SaveRequired) Then
					Me.oSessionWriter.CloseSession(Me.oSessionStats)
				End If
				Me.SessionCharts.ClearCharts()
				Me.ResetConsole()
				Me.SetState(RecorderMainWindow.SessionState.Ready)
				Return
			End If
			Dim dialogResult As System.Windows.Forms.DialogResult = Me.CheckSaveData(True)
			If (dialogResult <> System.Windows.Forms.DialogResult.Cancel) Then
				If (dialogResult = System.Windows.Forms.DialogResult.Yes) Then
					Me.oSessionWriter.CloseSession(Me.oSessionStats)
				End If
				If (dialogResult = System.Windows.Forms.DialogResult.No) Then
					Me.oSessionWriter.CloseSession()
				End If
				Me.SessionCharts.ClearCharts()
				Me.ResetConsole()
			End If
		End Sub

		Private Sub ProcessDataEvent()
			If (Me.eSessionState = RecorderMainWindow.SessionState.Stopped) Then
				Return
			End If
			Dim rowerDataEventType As SessionRecorder.RowerDataEventType = Me.dataEvent
			If (rowerDataEventType = SessionRecorder.RowerDataEventType.DataEventStroke) Then
				Me.Average.Visible = False
				If (Me.eSessionState = RecorderMainWindow.SessionState.Ready Or Me.eSessionState = RecorderMainWindow.SessionState.Paused) Then
					Me.SessionTimer.Start()
					Me.SetState(RecorderMainWindow.SessionState.Running)
					Me.UpdateHRGraph()
				End If
				Me.strokeData = Me.oRowerDataSource.GetStrokeData()
				Me.UpdateConsoleMain()
				Me.SessionCharts.UpdateGraphs(Me.strokeData)
				Me.oSessionStats.UpdateStroke(Me.strokeData)
				Me.oSessionWriter.WriteToSessionFile(Me.strokeData)
			ElseIf (rowerDataEventType = SessionRecorder.RowerDataEventType.DataEventHeartRate) Then
				Me.CurrentHR = Me.oRowerDataSource.GetHeartRate()
				Me.UpdateConsoleHR()
			ElseIf (rowerDataEventType = SessionRecorder.RowerDataEventType.DataEventNewLevel) Then
				Me.UpdateConsoleLevel()
			ElseIf (rowerDataEventType = SessionRecorder.RowerDataEventType.DataEventStrokeTO) Then
				Me.SetState(RecorderMainWindow.SessionState.Paused)
				Me.SessionTimer.[Stop]()
				Me.strokeData = Me.oRowerDataSource.GetStrokeData()
				Me.oSessionStats.TotalCals = CInt(Math.Round(Me.strokeData.CalsTotal))
				Me.UpdateConsoleTime()
				Me.UpdateConsoleMain()
			ElseIf (rowerDataEventType = SessionRecorder.RowerDataEventType.DataEventDisconnected) Then
				Me.oRowerDataSource.DisconnectConsole()
				Me.SessionTimer.[Stop]()
				Me.StartConnectTimer()
				Me.SetState(RecorderMainWindow.SessionState.Disonnected)
				MessageBox.Show("IPM or Console has been disconnected!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Dim dialogResult As System.Windows.Forms.DialogResult = Me.CheckSaveData(False)
				If (dialogResult <> System.Windows.Forms.DialogResult.Cancel) Then
					If (dialogResult = System.Windows.Forms.DialogResult.Yes) Then
						Me.oSessionWriter.CloseSession(Me.oSessionStats)
					End If
					If (dialogResult = System.Windows.Forms.DialogResult.No) Then
						Me.oSessionWriter.CloseSession()
					End If
					Me.SessionCharts.ClearCharts()
					Me.ResetConsole()
					Me.SetState(RecorderMainWindow.SessionState.Ready)
				End If
			End If
		End Sub

		Private Sub Quit_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MySettingsProperty.Settings.AutoSaveQuit) Then
				If (Me.oSessionWriter.SaveRequired) Then
					Me.oSessionWriter.CloseSession(Me.oSessionStats)
				End If
				Me.Hide()
				Me.MyFormClosed = True
				Me.ConnectTimer.[Stop]()
				Me.KeepAliveTimer.[Stop]()
				Me.SessionTimer.[Stop]()
				Me.oRowerDataSource.DisconnectConsole()
				Utilities.CloseDebugFile()
				Me.Close()
				Return
			End If
			Dim dialogResult As System.Windows.Forms.DialogResult = Me.CheckSaveData(True)
			If (dialogResult = System.Windows.Forms.DialogResult.Yes) Then
				Me.oSessionWriter.CloseSession(Me.oSessionStats)
			End If
			If (dialogResult = System.Windows.Forms.DialogResult.No) Then
				Me.oSessionWriter.CloseSession()
			End If
			If (dialogResult <> System.Windows.Forms.DialogResult.Cancel) Then
				Me.Hide()
				Me.MyFormClosed = True
				Me.ConnectTimer.[Stop]()
				Me.KeepAliveTimer.[Stop]()
				Me.SessionTimer.[Stop]()
				Me.oRowerDataSource.DisconnectConsole()
				Utilities.CloseDebugFile()
				Me.Close()
			End If
		End Sub

		Private Sub ResetConsole()
			Me.SessionTimer.[Stop]()
			Me.strokeData.Time = 0
			Me.strokeData.Speed = 0
			Me.strokeData.SPM = 0
			Me.strokeData.Power = 0
			Me.strokeData.Distance = 0
			Me.strokeData.Cals = 0
			Me.strokeData.CalsTotal = 0
			Me.oSessionStats.Reset()
			Me.oRowerDataSource.Reset()
			Me.UpdateConsoleMain()
			Me.UpdateConsoleTime()
			Me.oSessionWriter.CreateNewSession()
			Me.oSessionStats.Device = Me.oRowerDataSource.DeviceInfo.DeviceType
		End Sub

		Private Sub SaveSession_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.oSessionWriter.SaveSession(Me.oSessionStats)
			Me.SaveSession.Enabled = False
		End Sub

		Private Sub SessionTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Me.oSessionStats.IncDuration()
			Me.UpdateConsoleTime()
			Me.UpdateHRGraph()
		End Sub

		Private Sub SetState(ByVal newState As RecorderMainWindow.SessionState)
			Dim str As String
			Me.eSessionState = newState
			Select Case Me.eSessionState
				Case RecorderMainWindow.SessionState.Ready
					str = "Ready! Start rowing to being recording..."
					Me.SetStatusMessage(str)
					Me.LaunchViewer.Enabled = True
					Me.Quit.Enabled = True
					Me.NewSession.Enabled = False
					Me.SaveSession.Enabled = False
					Me.Average.Visible = False
					Me.TotalCalsLabel.Visible = False
					Exit Select
				Case RecorderMainWindow.SessionState.Running
					str = "Recording..."
					Me.SetStatusMessage(str)
					Me.LaunchViewer.Enabled = False
					Me.Quit.Enabled = False
					Me.NewSession.Enabled = False
					Me.SaveSession.Enabled = False
					Me.Average.Visible = False
					Me.TotalCalsLabel.Visible = False
					Exit Select
				Case RecorderMainWindow.SessionState.Paused
					str = "Paused. Start rowing to continue..."
					Me.SetStatusMessage(str)
					Me.Average.Visible = True
					Me.TotalCalsLabel.Visible = True
					Me.Quit.Enabled = True
					Exit Select
				Case RecorderMainWindow.SessionState.Stopped
					str = "Stopped. Click 'New Session'"
					Me.SetStatusMessage(str)
					Me.Average.Visible = True
					Me.TotalCalsLabel.Visible = True
					Me.Quit.Enabled = True
					Exit Select
				Case RecorderMainWindow.SessionState.InvalidDevice
					str = "Incorrect IPM or Console Connected!"
					Me.SetStatusMessage(str)
					Me.Quit.Enabled = True
					Exit Select
				Case RecorderMainWindow.SessionState.NotConnected
					str = "Please connect an IPM or Console..."
					Me.SetStatusMessage(str)
					Me.Quit.Enabled = True
					Exit Select
				Case RecorderMainWindow.SessionState.Disonnected
					str = "IPM or Console has been Disconnected"
					Me.SetStatusMessage(str)
					Me.Quit.Enabled = True
					Exit Select
			End Select
			If (Me.eSessionState <> RecorderMainWindow.SessionState.Running) Then
				If (Me.eSessionState = RecorderMainWindow.SessionState.Stopped) Then
					Me.NewSession.Enabled = True
				ElseIf (Me.eSessionState <> RecorderMainWindow.SessionState.Disonnected) Then
					Me.NewSession.Enabled = Me.oSessionWriter.SaveRequired
				Else
					Me.NewSession.Enabled = False
				End If
				Me.SaveSession.Enabled = Me.oSessionWriter.SaveRequired
			End If
		End Sub

		Private Sub SetStatusMessage(ByRef strMessage As String)
			Me.StatusMessage.Text = strMessage
		End Sub

		Private Sub Settings_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim settingsDlg As SessionRecorder.SettingsDlg = New SessionRecorder.SettingsDlg()
			settingsDlg.SetDeviceInfo(Me.oRowerDataSource.DeviceInfo)
			If (settingsDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
				Me.ConfigureChart()
			End If
		End Sub

		Private Sub ShowBoth_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SessionCharts.SetView(GraphContainer.GraphView.ViewBoth)
		End Sub

		Private Sub ShowPowerSPM_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SessionCharts.SetView(GraphContainer.GraphView.ViewPowerSPM)
		End Sub

		Private Sub ShowSpeedHR_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SessionCharts.SetView(GraphContainer.GraphView.ViewSpeedHR)
		End Sub

		Private Sub StartConnectTimer()
			Me.ConnectTimer.Interval = Conversions.ToInteger(Interaction.IIf(Me.FirstConnect, 500, 2000))
			Me.ConnectTimer.Enabled = True
			Me.ConnectTimer.Start()
			Me.FirstConnect = False
		End Sub

		Private Sub StartKATimer()
			Me.KeepAliveTimer.Interval = 5000
			Me.KeepAliveTimer.Enabled = True
			Me.KeepAliveTimer.Start()
		End Sub

		Private Sub StopConnectTimer()
			Me.ConnectTimer.[Stop]()
			Me.ConnectTimer.Enabled = False
		End Sub

		Private Sub StopKATimer()
			Me.KeepAliveTimer.[Stop]()
			Me.KeepAliveTimer.Enabled = False
		End Sub

		Private Sub TryConnectConsole()
			Dim console As ConsoleProxy.OpenCode = Me.oRowerDataSource.ConnectToConsole()
			If (console = ConsoleProxy.OpenCode.ValidDevice) Then
				Me.ResetConsole()
				Me.StopConnectTimer()
				Me.oSessionStats.Level = Me.oRowerDataSource.Level
				Me.oSessionStats.Device = Me.oRowerDataSource.DeviceInfo.DeviceType
				Me.SetState(RecorderMainWindow.SessionState.Ready)
			ElseIf (console <> ConsoleProxy.OpenCode.NoDevice) Then
				Me.SetState(RecorderMainWindow.SessionState.InvalidDevice)
				Me.StartConnectTimer()
			Else
				Me.SetState(RecorderMainWindow.SessionState.NotConnected)
				Me.StartConnectTimer()
			End If
		End Sub

		Private Sub UpdateConsoleHR()
			Me.HeartRate.Text = Conversions.ToString(Me.CurrentHR)
		End Sub

		Private Sub UpdateConsoleLevel()
			Me.Level.Text = Strings.Format(Me.oRowerDataSource.Level, "#0")
		End Sub

		Private Sub UpdateConsoleMain()
			Me.Speed.Text = String.Concat(Strings.Format(Conversion.Int(Me.strokeData.Speed / 60), "00"), ":", Strings.Format(Conversion.Int(Me.strokeData.Speed Mod 60), "00"))
			Me.SPM.Text = Strings.Format(Math.Round(Me.strokeData.SPM, 0), "#0")
			Me.Power.Text = Strings.Format(Math.Round(Me.strokeData.Power, 0), "#0")
			If (Not (Me.eSessionState = RecorderMainWindow.SessionState.Paused Or Me.eSessionState = RecorderMainWindow.SessionState.Stopped)) Then
				Me.Cals.Text = Strings.Format(Math.Round(Me.strokeData.Cals, 0), "#0")
			Else
				Me.Cals.Text = Strings.Format(Math.Round(Me.strokeData.CalsTotal, 0), "#0")
			End If
			Me.Distance.Text = Strings.Format(Math.Round(Me.strokeData.Distance, 0), "#,##0")
			Me.Level.Text = Strings.Format(Me.oRowerDataSource.Level, "#0")
		End Sub

		Private Sub UpdateConsoleTime()
			Dim duration As Label = Me.Duration
			Dim strArrays() As String = { Strings.Format(Me.oSessionStats.Duration / 3600, "0"), ":", Strings.Format(Me.oSessionStats.Duration / 60 Mod 60, "00"), ":", Strings.Format(Me.oSessionStats.Duration Mod 60, "00") }
			duration.Text = String.Concat(strArrays)
		End Sub

		Private Sub UpdateHRGraph()
			If (Me.eSessionState = RecorderMainWindow.SessionState.Running) Then
				Me.oSessionStats.UpdateHR(Me.CurrentHR)
				Me.oSessionWriter.WriteToHRDataFile(Me.oSessionStats.Duration, CDbl(Me.CurrentHR))
				Me.SessionCharts.UpdateHRGraph(CDbl(Me.oSessionStats.Duration), CDbl(Me.CurrentHR))
			End If
		End Sub

		Private Enum SessionState
			Ready
			Running
			Paused
			Stopped
			InvalidDevice
			NotConnected
			Disonnected
		End Enum
	End Class
End Namespace