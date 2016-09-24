Imports Microsoft.VisualBasic.CompilerServices
Imports SessionRecorder.My
Imports SessionRecorder.My.Resources
Imports System
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SessionRecorder
	<DesignerGenerated>
	Public Class SettingsDlg
		Inherits Form
		Private components As IContainer

		<AccessedThroughProperty("TableLayoutPanel1")>
		Private _TableLayoutPanel1 As TableLayoutPanel

		<AccessedThroughProperty("OK_Button")>
		Private _OK_Button As Button

		<AccessedThroughProperty("Cancel_Button")>
		Private _Cancel_Button As Button

		<AccessedThroughProperty("GroupBox1")>
		Private _GroupBox1 As GroupBox

		<AccessedThroughProperty("gbOdometer")>
		Private _gbOdometer As GroupBox

		<AccessedThroughProperty("DevODODist")>
		Private _DevODODist As Label

		<AccessedThroughProperty("Label10")>
		Private _Label10 As Label

		<AccessedThroughProperty("DevODOTime")>
		Private _DevODOTime As Label

		<AccessedThroughProperty("Label8")>
		Private _Label8 As Label

		<AccessedThroughProperty("DeviceLevels")>
		Private _DeviceLevels As Label

		<AccessedThroughProperty("DeviceVersion")>
		Private _DeviceVersion As Label

		<AccessedThroughProperty("DeviceType")>
		Private _DeviceType As Label

		<AccessedThroughProperty("Label3")>
		Private _Label3 As Label

		<AccessedThroughProperty("Label2")>
		Private _Label2 As Label

		<AccessedThroughProperty("Label1")>
		Private _Label1 As Label

		<AccessedThroughProperty("VersionLabel")>
		Private _VersionLabel As Label

		<AccessedThroughProperty("GroupBox3")>
		Private _GroupBox3 As GroupBox

		<AccessedThroughProperty("Label13")>
		Private _Label13 As Label

		<AccessedThroughProperty("ASOnLaunch")>
		Private _ASOnLaunch As CheckBox

		<AccessedThroughProperty("ASOnQuit")>
		Private _ASOnQuit As CheckBox

		<AccessedThroughProperty("ASOnNew")>
		Private _ASOnNew As CheckBox

		<AccessedThroughProperty("DefaultView")>
		Private _DefaultView As ListBox

		<AccessedThroughProperty("Banner")>
		Private _Banner As PictureBox

		Private DeviceInfo As DeviceInformation

		Friend Overridable Property ASOnLaunch As CheckBox
			Get
				Return Me._ASOnLaunch
			End Get
			Set(ByVal value As CheckBox)
				Me._ASOnLaunch = value
			End Set
		End Property

		Friend Overridable Property ASOnNew As CheckBox
			Get
				Return Me._ASOnNew
			End Get
			Set(ByVal value As CheckBox)
				Me._ASOnNew = value
			End Set
		End Property

		Friend Overridable Property ASOnQuit As CheckBox
			Get
				Return Me._ASOnQuit
			End Get
			Set(ByVal value As CheckBox)
				Me._ASOnQuit = value
			End Set
		End Property

		Friend Overridable Property Banner As PictureBox
			Get
				Return Me._Banner
			End Get
			Set(ByVal value As PictureBox)
				Me._Banner = value
			End Set
		End Property

		Friend Overridable Property Cancel_Button As Button
			Get
				Return Me._Cancel_Button
			End Get
			Set(ByVal value As Button)
				Dim settingsDlg As SessionRecorder.SettingsDlg = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf settingsDlg.Cancel_Button_Click)
				If (Me._Cancel_Button IsNot Nothing) Then
					RemoveHandler Me._Cancel_Button.Click,  eventHandler
				End If
				Me._Cancel_Button = value
				If (Me._Cancel_Button IsNot Nothing) Then
					AddHandler Me._Cancel_Button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property DefaultView As ListBox
			Get
				Return Me._DefaultView
			End Get
			Set(ByVal value As ListBox)
				Me._DefaultView = value
			End Set
		End Property

		Friend Overridable Property DeviceLevels As Label
			Get
				Return Me._DeviceLevels
			End Get
			Set(ByVal value As Label)
				Me._DeviceLevels = value
			End Set
		End Property

		Friend Overridable Property DeviceType As Label
			Get
				Return Me._DeviceType
			End Get
			Set(ByVal value As Label)
				Me._DeviceType = value
			End Set
		End Property

		Friend Overridable Property DeviceVersion As Label
			Get
				Return Me._DeviceVersion
			End Get
			Set(ByVal value As Label)
				Me._DeviceVersion = value
			End Set
		End Property

		Friend Overridable Property DevODODist As Label
			Get
				Return Me._DevODODist
			End Get
			Set(ByVal value As Label)
				Me._DevODODist = value
			End Set
		End Property

		Friend Overridable Property DevODOTime As Label
			Get
				Return Me._DevODOTime
			End Get
			Set(ByVal value As Label)
				Me._DevODOTime = value
			End Set
		End Property

		Friend Overridable Property gbOdometer As GroupBox
			Get
				Return Me._gbOdometer
			End Get
			Set(ByVal value As GroupBox)
				Me._gbOdometer = value
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

		Friend Overridable Property GroupBox3 As GroupBox
			Get
				Return Me._GroupBox3
			End Get
			Set(ByVal value As GroupBox)
				Me._GroupBox3 = value
			End Set
		End Property

		Friend Overridable Property Label1 As Label
			Get
				Return Me._Label1
			End Get
			Set(ByVal value As Label)
				Me._Label1 = value
			End Set
		End Property

		Friend Overridable Property Label10 As Label
			Get
				Return Me._Label10
			End Get
			Set(ByVal value As Label)
				Me._Label10 = value
			End Set
		End Property

		Friend Overridable Property Label13 As Label
			Get
				Return Me._Label13
			End Get
			Set(ByVal value As Label)
				Me._Label13 = value
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

		Friend Overridable Property Label3 As Label
			Get
				Return Me._Label3
			End Get
			Set(ByVal value As Label)
				Me._Label3 = value
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

		Friend Overridable Property OK_Button As Button
			Get
				Return Me._OK_Button
			End Get
			Set(ByVal value As Button)
				Dim settingsDlg As SessionRecorder.SettingsDlg = Me
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf settingsDlg.OK_Button_Click)
				If (Me._OK_Button IsNot Nothing) Then
					RemoveHandler Me._OK_Button.Click,  eventHandler
				End If
				Me._OK_Button = value
				If (Me._OK_Button IsNot Nothing) Then
					AddHandler Me._OK_Button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel
			Get
				Return Me._TableLayoutPanel1
			End Get
			Set(ByVal value As TableLayoutPanel)
				Me._TableLayoutPanel1 = value
			End Set
		End Property

		Friend Overridable Property VersionLabel As Label
			Get
				Return Me._VersionLabel
			End Get
			Set(ByVal value As Label)
				Me._VersionLabel = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Dim settingsDlg1 As SettingsDlg = Me
			AddHandler MyBase.Load,  New EventHandler(AddressOf settingsDlg1.SettingsDlg_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()
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
			Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
			Me.OK_Button = New System.Windows.Forms.Button()
			Me.Cancel_Button = New System.Windows.Forms.Button()
			Me.GroupBox1 = New System.Windows.Forms.GroupBox()
			Me.DeviceLevels = New System.Windows.Forms.Label()
			Me.DeviceVersion = New System.Windows.Forms.Label()
			Me.DeviceType = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.gbOdometer = New System.Windows.Forms.GroupBox()
			Me.DevODODist = New System.Windows.Forms.Label()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.DevODOTime = New System.Windows.Forms.Label()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.VersionLabel = New System.Windows.Forms.Label()
			Me.GroupBox3 = New System.Windows.Forms.GroupBox()
			Me.DefaultView = New System.Windows.Forms.ListBox()
			Me.Label13 = New System.Windows.Forms.Label()
			Me.ASOnLaunch = New System.Windows.Forms.CheckBox()
			Me.ASOnQuit = New System.Windows.Forms.CheckBox()
			Me.ASOnNew = New System.Windows.Forms.CheckBox()
			Me.Banner = New System.Windows.Forms.PictureBox()
			Me.TableLayoutPanel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.gbOdometer.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			DirectCast(Me.Banner, ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			Me.TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
			Me.TableLayoutPanel1.ColumnCount = 2
			Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
			Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
			Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
			Dim tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel = Me.TableLayoutPanel1
			Dim point As System.Drawing.Point = New System.Drawing.Point(277, 336)
			tableLayoutPanel1.Location = point
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 1
			Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50!))
			Dim tableLayoutPanel As System.Windows.Forms.TableLayoutPanel = Me.TableLayoutPanel1
			Dim size As System.Drawing.Size = New System.Drawing.Size(146, 29)
			tableLayoutPanel.Size = size
			Me.TableLayoutPanel1.TabIndex = 0
			Me.OK_Button.Anchor = AnchorStyles.None
			Dim oKButton As System.Windows.Forms.Button = Me.OK_Button
			point = New System.Drawing.Point(3, 3)
			oKButton.Location = point
			Me.OK_Button.Name = "OK_Button"
			Dim button As System.Windows.Forms.Button = Me.OK_Button
			size = New System.Drawing.Size(67, 23)
			button.Size = size
			Me.OK_Button.TabIndex = 0
			Me.OK_Button.Text = "OK"
			Me.Cancel_Button.Anchor = AnchorStyles.None
			Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Dim cancelButton As System.Windows.Forms.Button = Me.Cancel_Button
			point = New System.Drawing.Point(76, 3)
			cancelButton.Location = point
			Me.Cancel_Button.Name = "Cancel_Button"
			Dim cancelButton1 As System.Windows.Forms.Button = Me.Cancel_Button
			size = New System.Drawing.Size(67, 23)
			cancelButton1.Size = size
			Me.Cancel_Button.TabIndex = 1
			Me.Cancel_Button.Text = "Cancel"
			Me.GroupBox1.Controls.Add(Me.DeviceLevels)
			Me.GroupBox1.Controls.Add(Me.DeviceVersion)
			Me.GroupBox1.Controls.Add(Me.DeviceType)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim groupBox1 As System.Windows.Forms.GroupBox = Me.GroupBox1
			point = New System.Drawing.Point(12, 158)
			groupBox1.Location = point
			Me.GroupBox1.Name = "GroupBox1"
			Dim groupBox As System.Windows.Forms.GroupBox = Me.GroupBox1
			size = New System.Drawing.Size(208, 90)
			groupBox.Size = size
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Console Information"
			Me.DeviceLevels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim deviceLevels As System.Windows.Forms.Label = Me.DeviceLevels
			point = New System.Drawing.Point(129, 68)
			deviceLevels.Location = point
			Me.DeviceLevels.Name = "DeviceLevels"
			Dim label As System.Windows.Forms.Label = Me.DeviceLevels
			size = New System.Drawing.Size(65, 13)
			label.Size = size
			Me.DeviceLevels.TabIndex = 6
			Me.DeviceLevels.Text = "N/A"
			Me.DeviceLevels.TextAlign = ContentAlignment.MiddleRight
			Me.DeviceVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim deviceVersion As System.Windows.Forms.Label = Me.DeviceVersion
			point = New System.Drawing.Point(103, 44)
			deviceVersion.Location = point
			Me.DeviceVersion.Name = "DeviceVersion"
			Dim deviceVersion1 As System.Windows.Forms.Label = Me.DeviceVersion
			size = New System.Drawing.Size(91, 13)
			deviceVersion1.Size = size
			Me.DeviceVersion.TabIndex = 5
			Me.DeviceVersion.Text = "N/A"
			Me.DeviceVersion.TextAlign = ContentAlignment.MiddleRight
			Me.DeviceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim deviceType As System.Windows.Forms.Label = Me.DeviceType
			point = New System.Drawing.Point(47, 20)
			deviceType.Location = point
			Me.DeviceType.Name = "DeviceType"
			Dim deviceType1 As System.Windows.Forms.Label = Me.DeviceType
			size = New System.Drawing.Size(147, 13)
			deviceType1.Size = size
			Me.DeviceType.TabIndex = 4
			Me.DeviceType.Text = "N/A"
			Me.DeviceType.TextAlign = ContentAlignment.MiddleRight
			Me.Label3.AutoSize = True
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim label3 As System.Windows.Forms.Label = Me.Label3
			point = New System.Drawing.Point(10, 68)
			label3.Location = point
			Me.Label3.Name = "Label3"
			Dim label31 As System.Windows.Forms.Label = Me.Label3
			size = New System.Drawing.Size(94, 13)
			label31.Size = size
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "Resistance Levels"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim label2 As System.Windows.Forms.Label = Me.Label2
			point = New System.Drawing.Point(10, 44)
			label2.Location = point
			Me.Label2.Name = "Label2"
			Dim label21 As System.Windows.Forms.Label = Me.Label2
			size = New System.Drawing.Size(87, 13)
			label21.Size = size
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "Firmware Version"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim label1 As System.Windows.Forms.Label = Me.Label1
			point = New System.Drawing.Point(10, 20)
			label1.Location = point
			Me.Label1.Name = "Label1"
			Dim label11 As System.Windows.Forms.Label = Me.Label1
			size = New System.Drawing.Size(31, 13)
			label11.Size = size
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Type"
			Me.gbOdometer.Controls.Add(Me.DevODODist)
			Me.gbOdometer.Controls.Add(Me.Label10)
			Me.gbOdometer.Controls.Add(Me.DevODOTime)
			Me.gbOdometer.Controls.Add(Me.Label8)
			Me.gbOdometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim groupBox2 As System.Windows.Forms.GroupBox = Me.gbOdometer
			point = New System.Drawing.Point(12, 254)
			groupBox2.Location = point
			Me.gbOdometer.Name = "gbOdometer"
			Dim groupBox3 As System.Windows.Forms.GroupBox = Me.gbOdometer
			size = New System.Drawing.Size(208, 67)
			groupBox3.Size = size
			Me.gbOdometer.TabIndex = 7
			Me.gbOdometer.TabStop = False
			Me.gbOdometer.Text = "Odometer"
			Me.gbOdometer.Visible = False
			Me.DevODODist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim devODODist As System.Windows.Forms.Label = Me.DevODODist
			point = New System.Drawing.Point(88, 45)
			devODODist.Location = point
			Me.DevODODist.Name = "DevODODist"
			Dim devODODist1 As System.Windows.Forms.Label = Me.DevODODist
			size = New System.Drawing.Size(106, 13)
			devODODist1.Size = size
			Me.DevODODist.TabIndex = 10
			Me.DevODODist.Text = "N/A"
			Me.DevODODist.TextAlign = ContentAlignment.MiddleRight
			Me.Label10.AutoSize = True
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim label10 As System.Windows.Forms.Label = Me.Label10
			point = New System.Drawing.Point(10, 45)
			label10.Location = point
			Me.Label10.Name = "Label10"
			Dim label101 As System.Windows.Forms.Label = Me.Label10
			size = New System.Drawing.Size(49, 13)
			label101.Size = size
			Me.Label10.TabIndex = 9
			Me.Label10.Text = "Distance"
			Me.DevODOTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim devODOTime As System.Windows.Forms.Label = Me.DevODOTime
			point = New System.Drawing.Point(88, 18)
			devODOTime.Location = point
			Me.DevODOTime.Name = "DevODOTime"
			Dim devODOTime1 As System.Windows.Forms.Label = Me.DevODOTime
			size = New System.Drawing.Size(106, 13)
			devODOTime1.Size = size
			Me.DevODOTime.TabIndex = 8
			Me.DevODOTime.Text = "N/A"
			Me.DevODOTime.TextAlign = ContentAlignment.MiddleRight
			Me.Label8.AutoSize = True
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim label8 As System.Windows.Forms.Label = Me.Label8
			point = New System.Drawing.Point(10, 18)
			label8.Location = point
			Me.Label8.Name = "Label8"
			Dim label81 As System.Windows.Forms.Label = Me.Label8
			size = New System.Drawing.Size(30, 13)
			label81.Size = size
			Me.Label8.TabIndex = 7
			Me.Label8.Text = "Time"
			Me.VersionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim versionLabel As System.Windows.Forms.Label = Me.VersionLabel
			point = New System.Drawing.Point(10, 125)
			versionLabel.Location = point
			Me.VersionLabel.Name = "VersionLabel"
			Dim versionLabel1 As System.Windows.Forms.Label = Me.VersionLabel
			size = New System.Drawing.Size(410, 18)
			versionLabel1.Size = size
			Me.VersionLabel.TabIndex = 3
			Me.VersionLabel.Text = "FDF Version Label"
			Me.VersionLabel.TextAlign = ContentAlignment.MiddleCenter
			Me.GroupBox3.Controls.Add(Me.DefaultView)
			Me.GroupBox3.Controls.Add(Me.Label13)
			Me.GroupBox3.Controls.Add(Me.ASOnLaunch)
			Me.GroupBox3.Controls.Add(Me.ASOnQuit)
			Me.GroupBox3.Controls.Add(Me.ASOnNew)
			Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim groupBox31 As System.Windows.Forms.GroupBox = Me.GroupBox3
			point = New System.Drawing.Point(230, 158)
			groupBox31.Location = point
			Me.GroupBox3.Name = "GroupBox3"
			Dim groupBox32 As System.Windows.Forms.GroupBox = Me.GroupBox3
			size = New System.Drawing.Size(193, 163)
			groupBox32.Size = size
			Me.GroupBox3.TabIndex = 4
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Settings"
			Me.DefaultView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.DefaultView.FormattingEnabled = True
			Me.DefaultView.Items.AddRange(New Object() { "Speed & HR against Time", "Power & SPM against Stroke #", "Both" })
			Dim defaultView As System.Windows.Forms.ListBox = Me.DefaultView
			point = New System.Drawing.Point(11, 108)
			defaultView.Location = point
			Me.DefaultView.Name = "DefaultView"
			Dim listBox As System.Windows.Forms.ListBox = Me.DefaultView
			size = New System.Drawing.Size(170, 43)
			listBox.Size = size
			Me.DefaultView.TabIndex = 4
			Me.Label13.AutoSize = True
			Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Dim label13 As System.Windows.Forms.Label = Me.Label13
			point = New System.Drawing.Point(7, 90)
			label13.Location = point
			Me.Label13.Name = "Label13"
			Dim label131 As System.Windows.Forms.Label = Me.Label13
			size = New System.Drawing.Size(113, 13)
			label131.Size = size
			Me.Label13.TabIndex = 3
			Me.Label13.Text = "Default Chart View"
			Me.ASOnLaunch.AutoSize = True
			Me.ASOnLaunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim aSOnLaunch As System.Windows.Forms.CheckBox = Me.ASOnLaunch
			point = New System.Drawing.Point(11, 60)
			aSOnLaunch.Location = point
			Me.ASOnLaunch.Name = "ASOnLaunch"
			Dim checkBox As System.Windows.Forms.CheckBox = Me.ASOnLaunch
			size = New System.Drawing.Size(160, 17)
			checkBox.Size = size
			Me.ASOnLaunch.TabIndex = 2
			Me.ASOnLaunch.Text = "Autosave on Launch Viewer"
			Me.ASOnLaunch.UseVisualStyleBackColor = True
			Me.ASOnQuit.AutoSize = True
			Me.ASOnQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim aSOnQuit As System.Windows.Forms.CheckBox = Me.ASOnQuit
			point = New System.Drawing.Point(11, 39)
			aSOnQuit.Location = point
			Me.ASOnQuit.Name = "ASOnQuit"
			Dim aSOnQuit1 As System.Windows.Forms.CheckBox = Me.ASOnQuit
			size = New System.Drawing.Size(115, 17)
			aSOnQuit1.Size = size
			Me.ASOnQuit.TabIndex = 1
			Me.ASOnQuit.Text = "Autosave on QUIT"
			Me.ASOnQuit.UseVisualStyleBackColor = True
			Me.ASOnNew.AutoSize = True
			Me.ASOnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim aSOnNew As System.Windows.Forms.CheckBox = Me.ASOnNew
			point = New System.Drawing.Point(11, 18)
			aSOnNew.Location = point
			Me.ASOnNew.Name = "ASOnNew"
			Dim aSOnNew1 As System.Windows.Forms.CheckBox = Me.ASOnNew
			size = New System.Drawing.Size(151, 17)
			aSOnNew1.Size = size
			Me.ASOnNew.TabIndex = 0
			Me.ASOnNew.Text = "Autosave on New Session"
			Me.ASOnNew.UseVisualStyleBackColor = True
			Me.Banner.BackColor = Color.White
			Dim banner As System.Windows.Forms.PictureBox = Me.Banner
			point = New System.Drawing.Point(12, 9)
			banner.Location = point
			Dim pictureBox As System.Windows.Forms.PictureBox = Me.Banner
			Dim padding As System.Windows.Forms.Padding = New System.Windows.Forms.Padding(0)
			pictureBox.Margin = padding
			Me.Banner.Name = "Banner"
			Dim banner1 As System.Windows.Forms.PictureBox = Me.Banner
			padding = New System.Windows.Forms.Padding(3)
			banner1.Padding = padding
			Dim pictureBox1 As System.Windows.Forms.PictureBox = Me.Banner
			size = New System.Drawing.Size(410, 105)
			pictureBox1.Size = size
			Me.Banner.SizeMode = PictureBoxSizeMode.StretchImage
			Me.Banner.TabIndex = 9
			Me.Banner.TabStop = False
			Me.AcceptButton = Me.OK_Button
			Me.AutoScaleDimensions = New SizeF(6!, 13!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.Cancel_Button
			size = New System.Drawing.Size(435, 377)
			Me.ClientSize = size
			Me.Controls.Add(Me.Banner)
			Me.Controls.Add(Me.gbOdometer)
			Me.Controls.Add(Me.GroupBox3)
			Me.Controls.Add(Me.VersionLabel)
			Me.Controls.Add(Me.GroupBox1)
			Me.Controls.Add(Me.TableLayoutPanel1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "SettingsDlg"
			Me.ShowInTaskbar = False
			Me.StartPosition = FormStartPosition.CenterParent
			Me.Text = "FDF Session Recorder Settings"
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.gbOdometer.ResumeLayout(False)
			Me.gbOdometer.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			DirectCast(Me.Banner, ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
		End Sub

		Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
			MySettingsProperty.Settings.AutoSaveNew = Me.ASOnNew.Checked
			MySettingsProperty.Settings.AutoSaveLaunch = Me.ASOnLaunch.Checked
			MySettingsProperty.Settings.AutoSaveQuit = Me.ASOnQuit.Checked
			MySettingsProperty.Settings.DefaultView = Me.DefaultView.SelectedIndex
			MySettingsProperty.Settings.Save()
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		End Sub

		Public Sub SetDeviceInfo(ByRef devInfo As DeviceInformation)
			Me.DeviceInfo = devInfo
		End Sub

		Private Sub SettingsDlg_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.VersionLabel.Text = "First Degree Fitness Session Recorder Version 1.3.1"
            Me.Banner.Image = My.Resources.New_Banner
            If (Me.DeviceInfo.DeviceType <> -1) Then
				Me.DeviceVersion.Text = Me.DeviceInfo.VersionInfo
				Me.DeviceLevels.Text = Conversions.ToString(Me.DeviceInfo.NumLevels)
				If (Me.DeviceInfo.DeviceType > 3 And Me.DeviceInfo.DeviceType < 8) Then
					Me.DeviceType.Text = "IPM"
					Me.DevODOTime.Text = Conversions.ToString(Me.DeviceInfo.OdoTime)
					Me.DevODODist.Text = Conversions.ToString(Me.DeviceInfo.OdoDistance)
					Me.gbOdometer.Visible = True
				ElseIf (Me.DeviceInfo.DeviceType < 10) Then
					Me.DeviceType.Text = "Mult-Level Console"
					Me.DevODOTime.Text = "N/A"
					Me.DevODODist.Text = "N/A"
					Me.gbOdometer.Visible = False
				ElseIf (Me.DeviceInfo.DeviceType = 12) Then
					Me.DeviceType.Text = "Mult-Level RowGX"
					Me.DevODOTime.Text = "N/A"
					Me.DevODODist.Text = "N/A"
					Me.gbOdometer.Visible = False
				ElseIf (Me.DeviceInfo.DeviceType <> 13) Then
					Me.DeviceType.Text = "Non-Rower Device"
					Me.DevODOTime.Text = "N/A"
					Me.DevODODist.Text = "N/A"
					Me.gbOdometer.Visible = False
				Else
					Me.DeviceType.Text = "Mult-Level RowHX"
					Me.DevODOTime.Text = "N/A"
					Me.DevODODist.Text = "N/A"
					Me.gbOdometer.Visible = False
				End If
			Else
				Me.DeviceType.Text = "Not Connected"
				Me.DeviceVersion.Text = "N/A"
				Me.DeviceLevels.Text = "N/A"
				Me.DevODOTime.Text = "N/A"
				Me.DevODODist.Text = "N/A"
				Me.gbOdometer.Visible = False
			End If
			Me.ASOnNew.Checked = MySettingsProperty.Settings.AutoSaveNew
			Me.ASOnLaunch.Checked = MySettingsProperty.Settings.AutoSaveLaunch
			Me.ASOnQuit.Checked = MySettingsProperty.Settings.AutoSaveQuit
			Me.DefaultView.SelectedIndex = MySettingsProperty.Settings.DefaultView
		End Sub
	End Class
End Namespace