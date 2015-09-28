<FlexDocument Width="1275" MinHeight="1650"
					xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
					xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
					Background="#282828">
	<FlexDocumentTab Title="Dial Uptime - 2" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Sep 22 2015 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<BarChart Margin="30" Title="Dial Uptime (Minutes)" Foreground="White" FontSize="32"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="A1" Value="199" />
					<CategoricalDouble CategoryName="B1" Value="206" />
					<CategoricalDouble CategoryName="C1" Value="215" />
					<CategoricalDouble CategoryName="D1" Value="200" />
					<CategoricalDouble CategoryName="E1" Value="140" />
					<CategoricalDouble CategoryName="G1" Value="143" />
					<CategoricalDouble CategoryName="H1" Value="197" />
					<CategoricalDouble CategoryName="I1" Value="188" />
					<CategoricalDouble CategoryName="J1" Value="191" />
					<CategoricalDouble CategoryName="K1" Value="213" />
					<CategoricalDouble CategoryName="M1" Value="204" />
					<CategoricalDouble CategoryName="P1" Value="228" />
					<CategoricalDouble CategoryName="Q1" Value="151" />
					<CategoricalDouble CategoryName="R1" Value="56" />
					<CategoricalDouble CategoryName="S1" Value="130" />
				</BarChart>
			</Grid>
			<Label Content="Sep 22 2015 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<NestedArcChart Margin="30" Title="Dial Uptime (Minutes)" Foreground="White" FontSize="32"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										ValueForeground="P300" ValueFontWeight="Medium"
										SegmentSpaceBackground="->White000,0.05"
										SecondaryValueForeground="->Grey400" SecondaryValueFontWeight="Light" SecondaryValueFontStyle="Italic">
					<CategoricalDouble CategoryName="A1" Value="199" />
					<CategoricalDouble CategoryName="B1" Value="206" />
					<CategoricalDouble CategoryName="C1" Value="215" />
					<CategoricalDouble CategoryName="D1" Value="200" />
					<CategoricalDouble CategoryName="E1" Value="140" />
					<CategoricalDouble CategoryName="G1" Value="143" />
					<CategoricalDouble CategoryName="H1" Value="197" />
					<CategoricalDouble CategoryName="I1" Value="188" />
					<CategoricalDouble CategoryName="J1" Value="191" />
					<CategoricalDouble CategoryName="K1" Value="213" />
					<CategoricalDouble CategoryName="M1" Value="204" />
					<CategoricalDouble CategoryName="P1" Value="228" />
					<CategoricalDouble CategoryName="Q1" Value="151" />
					<CategoricalDouble CategoryName="R1" Value="56" />
					<CategoricalDouble CategoryName="S1" Value="130" />
				</NestedArcChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>
	<FlexDocumentTab Title="Production Overview">
		<FlexDocumentTab.Resources>
			<Style TargetType="Label" x:Key="lpheader" BasedOn="{StaticResource t12pCaption}">
				<Setter Property="Foreground" Value="{StaticResource mtBlue300}"/>
				<Setter Property="FontWeight" Value="Light"/>
				<Setter Property="Padding" Value="5 10"/>
			</Style>
			<Style TargetType="Label" x:Key="lpitemcn" BasedOn="{StaticResource t12pCaption}">
				<Setter Property="Foreground" Value="{StaticResource mtGrey300}"/>
				<Setter Property="FontWeight" Value="Light"/>
				<Setter Property="HorizontalContentAlignment" Value="Left"/>
				<Setter Property="Padding" Value="15 3 3 3"/>
			</Style>
			<Style TargetType="Label" x:Key="lpitemval" BasedOn="{StaticResource t12pCaption}">
				<Setter Property="Foreground" Value="{StaticResource mtGreen400}"/>
				<Setter Property="FontWeight" Value="Normal"/>
				<Setter Property="HorizontalContentAlignment" Value="Right"/>
				<Setter Property="Padding" Value="3 3 15 3"/>
			</Style>
			<Style TargetType="Label" x:Key="mpcn" BasedOn="{StaticResource t12pCaption}">
				<Setter Property="Foreground" Value="{StaticResource mtGrey700}"/>
				<Setter Property="FontWeight" Value="Heavy"/>
				<Setter Property="Padding" Value="0"/>
				<Setter Property="DockPanel.Dock" Value="Top"/>
			</Style>
			<Style TargetType="Label" x:Key="mpvalue" BasedOn="{StaticResource t24pHeadline}">
				<Setter Property="Foreground" Value="{StaticResource mtGrey900}"/>
				<Setter Property="FontWeight" Value="Light"/>
				<Setter Property="Padding" Value="0"/>
			</Style>
			<Style TargetType="DockPanel" x:Key="mpv">
				<Setter Property="Width" Value="130"/>
				<Setter Property="Height" Value="70"/>
			</Style>
		</FlexDocumentTab.Resources>
		<Grid Background="#FFE0E0E0">
			<StackPanel Width="220" Background="{StaticResource mtGrey900}" HorizontalAlignment="Left" Margin="10 0 0 0">
				<Border Height="98"/>
				<Label Content="REPORT DURATION" Style="{StaticResource lpheader}"/>
				<StackPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="RUN DATE"/>
						<Label Style="{StaticResource lpitemval}" Content="Sep 22 2015"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="SHIFT"/>
						<Label Style="{StaticResource lpitemval}" Content="1"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="START TIME"/>
						<Label Style="{StaticResource lpitemval}" Content="07:00"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="END TIME"/>
						<Label Style="{StaticResource lpitemval}" Content="15:30"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="DURATION"/>
						<Label Style="{StaticResource lpitemval}" Content="7 Hrs 58 Mins"/>
					</DockPanel>
				</StackPanel>
				<Label Content="HEAD COUNT" Style="{StaticResource lpheader}"/>
				<StackPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="LINE OPERATORS"/>
						<Label Style="{StaticResource lpitemval}" Content="14"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="AUTOMATION TECHS"/>
						<Label Style="{StaticResource lpitemval}" Content="3"/>
					</DockPanel>
					<DockPanel>
						<Label Style="{StaticResource lpitemcn}" Content="ENGINEERS"/>
						<Label Style="{StaticResource lpitemval}" Content="2"/>
					</DockPanel>
				</StackPanel>
				<Label Content="FINANCIALS" Style="{StaticResource lpheader}"/>
				<DockPanel Margin="0 10 0 0">
					<Label Content="SALEABLE PRODUCT" Style="{StaticResource mpcn}" Foreground="{StaticResource mtGrey500}"/>
					<Label Content="$0.00" Style="{StaticResource mpvalue}" Foreground="{StaticResource mtGreen400}"/>
				</DockPanel>
				<DockPanel Margin="0 20 0 0">
					<Label Content="COST OF REJECTS" Style="{StaticResource mpcn}" Foreground="{StaticResource mtGrey500}"/>
					<Label Content="$0.00" Style="{StaticResource mpvalue}" Foreground="{StaticResource mtRed400}"/>
				</DockPanel>
			</StackPanel>
			<DockPanel Height="80" VerticalAlignment="Top" Margin="0 8 0 0">
				<Border Height="7" DockPanel.Dock="Top" Background="{StaticResource mtBlue600}"/>
				<Label Content="AUTOMATION LINE" Style="{StaticResource t24pHeadline}" Background="{StaticResource mtBlue800}"
						 Foreground="White" FontWeight="Light" HorizontalContentAlignment="Left" Padding="20 0 0 0"/>
			</DockPanel>
			<StackPanel Margin="240 100 10 10" Orientation="Vertical">
				<Label Content="SYSTEM PERFORMANCE" Style="{StaticResource t24pHeadline}" BorderThickness="0 0 0 2"
						 BorderBrush="{StaticResource mtBlue600}"/>
				<StackPanel VerticalAlignment="Top" Orientation="Horizontal" Margin="0 10">
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="OEE" Style="{StaticResource mpcn}"/>
						<Label Content="0.0" Style="{StaticResource mpvalue}"/>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="THROUGHPUT" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="1,821" Style="{StaticResource mpvalue}"/>
							<Label Content="UNITS" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="AVG CYCLE RATE" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="3.8" Style="{StaticResource mpvalue}"/>
							<Label Content="CPM" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="UPTIME" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="421.00" Style="{StaticResource mpvalue}"/>
							<Label Content="mins" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="REJECTS" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="895" Style="{StaticResource mpvalue}"/>
							<Label Content="SA" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="SCRAP RATE" Style="{StaticResource mpcn}"/>
						<Label Content="0.00%" Style="{StaticResource mpvalue}"/>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="YIELD" Style="{StaticResource mpcn}"/>
						<Label Content="0.00%" Style="{StaticResource mpvalue}"/>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="ROLLED YIELD" Style="{StaticResource mpcn}"/>
						<Label Content="0.00%" Style="{StaticResource mpvalue}"/>
					</DockPanel>
				</StackPanel>
				<Label Content="DIAL K PERFORMANCE" Style="{StaticResource t24pHeadline}" BorderThickness="0 0 0 2" BorderBrush="{StaticResource mtGreen400}"/>
				<StackPanel VerticalAlignment="Top" Orientation="Horizontal" Margin="0 10" HorizontalAlignment="Center">
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="GOOD PARTS" Style="{StaticResource mpcn}"/>
						<Label Content="1821" Style="{StaticResource mpvalue}"/>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="REJECTS" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="174" Style="{StaticResource mpvalue}"/>
							<Label Content="UNITS" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="YIELD" Style="{StaticResource mpcn}"/>
						<Label Content="91.3%" Style="{StaticResource mpvalue}"/>
					</DockPanel>
					<DockPanel Style="{StaticResource mpv}">
						<Label Content="UPTIME" Style="{StaticResource mpcn}"/>
						<StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
							<Label Content="450.00" Style="{StaticResource mpvalue}"/>
							<Label Content="mins" Style="{StaticResource _t10pSubCaption}" Padding="3"/>
						</StackPanel>
					</DockPanel>
				</StackPanel>
			</StackPanel>
		</Grid>
	</FlexDocumentTab>
	<FlexDocumentTab Title="Completed vs. Rejects" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Sep 22 2015 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<StackedBarChart Foreground="White" Title="Reject Breakdown"  BarTotalForeground="->White000"
MaterialProvider="{x:Static AlternatingMaterialProvider.AltGP}" Margin="30">
					<CategoricalDoubleSeries CategoryName="A1">
						<CategoricalDouble CategoryName="Good Parts" Value="2057" />
						<CategoricalDouble CategoryName="Rejects" Value="37" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="M1">
						<CategoricalDouble CategoryName="Good Parts" Value="1993" />
						<CategoricalDouble CategoryName="Rejects" Value="81" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="B1">
						<CategoricalDouble CategoryName="Good Parts" Value="1871" />
						<CategoricalDouble CategoryName="Rejects" Value="212" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="C1">
						<CategoricalDouble CategoryName="Good Parts" Value="1995" />
						<CategoricalDouble CategoryName="Rejects" Value="23" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="D1">
						<CategoricalDouble CategoryName="Good Parts" Value="1928" />
						<CategoricalDouble CategoryName="Rejects" Value="100" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="E1">
						<CategoricalDouble CategoryName="Good Parts" Value="1405" />
						<CategoricalDouble CategoryName="Rejects" Value="6" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="G1">
						<CategoricalDouble CategoryName="Good Parts" Value="1399" />
						<CategoricalDouble CategoryName="Rejects" Value="0" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="R1">
						<CategoricalDouble CategoryName="Good Parts" Value="1409" />
						<CategoricalDouble CategoryName="Rejects" Value="1" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="H1">
						<CategoricalDouble CategoryName="Good Parts" Value="1889" />
						<CategoricalDouble CategoryName="Rejects" Value="31" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="I1">
						<CategoricalDouble CategoryName="Good Parts" Value="1979" />
						<CategoricalDouble CategoryName="Rejects" Value="46" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="J1">
						<CategoricalDouble CategoryName="Good Parts" Value="1874" />
						<CategoricalDouble CategoryName="Rejects" Value="9" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="P1">
						<CategoricalDouble CategoryName="Good Parts" Value="2009" />
						<CategoricalDouble CategoryName="Rejects" Value="175" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="Q1">
						<CategoricalDouble CategoryName="Good Parts" Value="2003" />
						<CategoricalDouble CategoryName="Rejects" Value="0" />
					</CategoricalDoubleSeries>
					<CategoricalDoubleSeries CategoryName="K1">
						<CategoricalDouble CategoryName="Good Parts" Value="1821" />
						<CategoricalDouble CategoryName="Rejects" Value="174" />
					</CategoricalDoubleSeries>
				</StackedBarChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>
	<FlexDocumentTab Title="Dial K Rejects" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Sep 22 2015 | Cell: 206 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<ParetoChart Margin="30" Title="Dial K Rejects" Foreground="White" FontSize="32"
								LineStroke="->White000" LineStrokeThickness="3"
								MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
								DotFill="P600" DotStroke="->White000" DotRadius="9" DotStrokeThickness="2"
								SegmentSpaceBackground="->White000,.03"
								SegmentWidthPercentage=".3"
								BarTotalFontWeight="Light" BarTotalFontStyle="Normal" BarTotalForeground="->White000" BarTotalFontSize="18"
								XAxisFontWeight="Medium"  XAxisFontStyle="Italic" XAxisFontSize="20" XAxisForeground="P200">
					<CategoricalDouble CategoryName="HALLSENS_PUSHTEST_LT" Value="25" />
					<CategoricalDouble CategoryName="HALLSENS_PUSHTEST_RT" Value="5" />
					<CategoricalDouble CategoryName="HAPTIC_L" Value="4" />
					<CategoricalDouble CategoryName="JOYSTICK_POSTSCAN" Value="9" />
					<CategoricalDouble CategoryName="JOYSTICK_PRESCAN" Value="6" />
					<CategoricalDouble CategoryName="KEY_SCAN_RESULT" Value="50" />
					<CategoricalDouble CategoryName="TP_FIRST_TOUCH_L" Value="18" />
					<CategoricalDouble CategoryName="TP_FIRST_TOUCH_R" Value="9" />
					<CategoricalDouble CategoryName="TP_SCAN" Value="4" />
				</ParetoChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>

	<FlexDocumentTab Title="Dial Uptime" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Sep 22 2015 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<BarChart Margin="30" Title="Dial Uptime (Minutes)" Foreground="White" FontSize="32"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="A1" Value="199" />
					<CategoricalDouble CategoryName="B1" Value="206" />
					<CategoricalDouble CategoryName="C1" Value="215" />
					<CategoricalDouble CategoryName="D1" Value="200" />
					<CategoricalDouble CategoryName="E1" Value="140" />
					<CategoricalDouble CategoryName="G1" Value="143" />
					<CategoricalDouble CategoryName="H1" Value="197" />
					<CategoricalDouble CategoryName="I1" Value="188" />
					<CategoricalDouble CategoryName="J1" Value="191" />
					<CategoricalDouble CategoryName="K1" Value="213" />
					<CategoricalDouble CategoryName="M1" Value="204" />
					<CategoricalDouble CategoryName="P1" Value="228" />
					<CategoricalDouble CategoryName="Q1" Value="151" />
					<CategoricalDouble CategoryName="R1" Value="56" />
					<CategoricalDouble CategoryName="S1" Value="130" />
				</BarChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>
	<FlexDocumentTab Title="System OEE" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Sep 22 2015 | Start: 07:00 | Stop: 15:30" Style="{StaticResource t24pHeadline}" FontSize="24" Foreground="White" Padding="5 30"/>
			<Grid Height="600">
				<BarChart Margin="30" Title="Dial and System OEE" Foreground="White" FontSize="32"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="A" Value="44.43" />
					<CategoricalDouble CategoryName="B" Value="40.34" />
					<CategoricalDouble CategoryName="C" Value="43.56" />
					<CategoricalDouble CategoryName="D" Value="41.97" />
					<CategoricalDouble CategoryName="E" Value="30.29" />
					<CategoricalDouble CategoryName="G" Value="30.20" />
					<CategoricalDouble CategoryName="H" Value="41.10" />
					<CategoricalDouble CategoryName="I" Value="42.81" />
					<CategoricalDouble CategoryName="J" Value="40.45" />
					<CategoricalDouble CategoryName="K" Value="39.48" />
					<CategoricalDouble CategoryName="M" Value="43.02" />
					<CategoricalDouble CategoryName="P" Value="43.58" />
					<CategoricalDouble CategoryName="Q" Value="43.30" />
					<CategoricalDouble CategoryName="R" Value="30.52" />
					<CategoricalDouble CategoryName="S" Value="0.00" />
				</BarChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>
	<FlexDocumentTab Title="Line Faults" Background="#282828">
		<StackPanel Margin="30" Orientation="Vertical" >
			<Label Content="Assembly Line Faults for Dial 100 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="750">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="A - FAULT:FR Robot-Controller Level Error" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:FR Robot-Robot Application Did Not Start" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:FRScan-Too Many Bad Parts Detected" Value="11" />
					<CategoricalDouble CategoryName="A - FAULT:Offload Pallet Pusher-Pallet Pusher Did Not Extend" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:Offload Pallet Shuttle-Shuttle Failed To Extend" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:Offload Pallet Shuttle-Unexpected Pallet At Shuttle Exit" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:Offload Pallet Shuttle-Unexpected Part On Pallet At Prestop" Value="27" />
					<CategoricalDouble CategoryName="A - FAULT:Offload Robot-Controller Level Error" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:PCA Main-Failed To Clear Buffer Dial (Remove Remaining Parts)" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:PCA Robot-Controller Level Error" Value="3" />
					<CategoricalDouble CategoryName="A - FAULT:PSA1 Robot-Controller Level Error" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:PSA1 Robot-Robot Application Did Not Start" Value="3" />
					<CategoricalDouble CategoryName="A - FAULT:PSA1 Tape Dispenser-Run Mode Not On" Value="3" />
					<CategoricalDouble CategoryName="A - FAULT:PSA2 Robot-Robot Application Did Not Start" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:Tamp Main-Failed To Extend Cylinder" Value="6" />
					<CategoricalDouble CategoryName="A - FAULT:Verify Offload Main-Part Sensed In Left Pocket" Value="1" />
					<CategoricalDouble CategoryName="A - FAULT:Vision Server Multiplexer-Socket Is Not Open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 105 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="830">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="M - FAULT:CvrBufferDial-VFD Not In Ready (Faults Not Cleared)" Value="4" />
					<CategoricalDouble CategoryName="M - FAULT:CvrMain-Failed To Clear Buffer Dial (Remove Remaining Parts)" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:CvrMain-Part Missing From Robot Gripper" Value="4" />
					<CategoricalDouble CategoryName="M - FAULT:CvrMain-Unexpected Part In Left Nest" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:CvrMain-Vision Test Failed Too Many Times In A Row" Value="3" />
					<CategoricalDouble CategoryName="M - FAULT:DispenseRobot-Robot Handshakes On When Expected Off" Value="2" />
					<CategoricalDouble CategoryName="M - FAULT:LHMountFeeder-Part Not Present At Escapement" Value="7" />
					<CategoricalDouble CategoryName="M - FAULT:LHMountFeeder-Part Present Sensor Failed To Transition" Value="15" />
					<CategoricalDouble CategoryName="M - FAULT:MountMain-Failed To Place Left Part" Value="3" />
					<CategoricalDouble CategoryName="M - FAULT:MountMain-Missing Part In Robot Gripper" Value="3" />
					<CategoricalDouble CategoryName="M - FAULT:MountRobot-Controller Level Error" Value="15" />
					<CategoricalDouble CategoryName="M - FAULT:OffloadPalletShuttle-Failed To Confirm Pallet On Entry" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:PCAMain-Robot Failed To Pick From Pallet" Value="15" />
					<CategoricalDouble CategoryName="M - FAULT:PCAPalletShuttle-Missing Pallet At Shuttle Entry" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:PSA1 Tape Dispenser-Failed To Present New Product" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:PSA1Main-Robot Failed To Pick Part From Nest" Value="1" />
					<CategoricalDouble CategoryName="M - FAULT:PSA2 Tape Dispenser-Failed To Present New Product" Value="2" />
					<CategoricalDouble CategoryName="M - FAULT:PSA2Main-Robot Failed To Pick Part From Nest" Value="6" />
					<CategoricalDouble CategoryName="M - FAULT:RHMountFeeder-Part Not Present At Escapement" Value="6" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 110 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="750">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="B - FAULT:ContinuityMain-3 Right Bad Parts In A Row" Value="2" />
					<CategoricalDouble CategoryName="B - FAULT:FPC_Prepare-Failed Pick Frm Bfr Dial after 3 Bfr Dial Indexes (Rmv Several F" Value="12" />
					<CategoricalDouble CategoryName="B - FAULT:FPC_Prepare-Robot Failed To Hold Left FPC" Value="5" />
					<CategoricalDouble CategoryName="B - FAULT:FPC_Prepare-Robot Failed To Hold Right FPC" Value="11" />
					<CategoricalDouble CategoryName="B - FAULT:FPC_Prepare-Robot Failed To Maintain Grip At Tape Disp" Value="3" />
					<CategoricalDouble CategoryName="B - FAULT:FPC_RgtSlide-Failed To Confirm FPC Present At Slide (Remove)" Value="2" />
					<CategoricalDouble CategoryName="B - FAULT:FPCInsertRobot-Robot Could Not Park" Value="4" />
					<CategoricalDouble CategoryName="B - FAULT:FPCInsertRobot-Robot Handshakes On When Expected Off" Value="8" />
					<CategoricalDouble CategoryName="B - FAULT:FPCMain-Missing Part In Robot" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:Guard Door Relay Tripped" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:LftSolderServo-Emergency Stop Active" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:OffloadPalletShuttle-Missing Pallet At Shuttle Exit" Value="8" />
					<CategoricalDouble CategoryName="B - FAULT:OffloadRobot-Controller Level Error" Value="3" />
					<CategoricalDouble CategoryName="B - FAULT:OffloadRobot-Robot Heartbeat Not Responding" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:RgtPasteServo-(No message defined)" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:TrkPadsMain-Robot Failed To Pick PCA From Pallet" Value="1" />
					<CategoricalDouble CategoryName="B - FAULT:VisionServerMultiplexer-Socket is not open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 120 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="550">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="C - FAULT:ABXYMain-Failed To Clear Buffer Dial (Remove Remaining Parts)" Value="1" />
					<CategoricalDouble CategoryName="C - FAULT:FlapSpringMain-Too Many Spring Probe Failures In A Row" Value="4" />
					<CategoricalDouble CategoryName="C - FAULT:OffloadPalletShuttle-Unexpected Part On Pallet At Prestop" Value="1" />
					<CategoricalDouble CategoryName="C - FAULT:OffloadRobot-Controller Level Error" Value="2" />
					<CategoricalDouble CategoryName="C - FAULT:OffloadRobot-Robot Handshakes On When Expected Off" Value="1" />
					<CategoricalDouble CategoryName="C - FAULT:OffloadVerifyMain-Part Sensed In Nest" Value="1" />
					<CategoricalDouble CategoryName="C - FAULT:SprFlapMain-Part Missing From Robot Gripper" Value="2" />
					<CategoricalDouble CategoryName="C - FAULT:SprFlapRobot-Controller Level Error" Value="2" />
					<CategoricalDouble CategoryName="C - FAULT:SysMain-Remove Remaining Parts From Sys Buffer Dial And Re-Init Line" Value="6" />
					<CategoricalDouble CategoryName="C - FAULT:SysOrientScan-Too Many Button Sets Failed" Value="14" />
					<CategoricalDouble CategoryName="C - FAULT:TopBufferDial-Failed To Reach Dwell Position" Value="1" />
					<CategoricalDouble CategoryName="C - FAULT:VisionServerMultiplexer-Socket is not open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 130 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="670">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="D - FAULT:Guard Door Relay Tripped" Value="2" />
					<CategoricalDouble CategoryName="D - FAULT:OffloadMain-Failed To Pick From Nest" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:OffloadRobot-Controller Level Error" Value="8" />
					<CategoricalDouble CategoryName="D - FAULT:OffloadRobot-Robot Application Did Not Start" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:OffloadRobot-Robot Heartbeat Not Responding" Value="3" />
					<CategoricalDouble CategoryName="D - FAULT:OffloadVerifyMain-Part Sensed In Nest" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:Screw12Feeder-Failed To Escape Screw To Tube 2" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:TopOnloadMain-Failed To Pick From Pallet" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:TrkpadsMain-Fail To Pick Left Part. Please Manually Reject Parts" Value="2" />
					<CategoricalDouble CategoryName="D - FAULT:TrkpadsMain-Fail To Pick Right Part. Please Manually Reject Parts" Value="11" />
					<CategoricalDouble CategoryName="D - FAULT:TrkpadsMain-Left Part Already Present In Nest" Value="9" />
					<CategoricalDouble CategoryName="D - FAULT:TrkpadsMain-Unexpected Part In Left Robot Gripper" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:TrkpadsMain-Unexpected Parts In Both Robot Grippers" Value="2" />
					<CategoricalDouble CategoryName="D - FAULT:TrkPadsPalletPusher-Pallet Pusher Did Not Extend" Value="1" />
					<CategoricalDouble CategoryName="D - FAULT:TrkPadsPalletShuttle-Missing 1 Or More Parts At Prestop" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 140 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="510">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="E - FAULT:MountMain-Failed To Clear Buffer Dial (Remove Remaining Parts)" Value="6" />
					<CategoricalDouble CategoryName="E - FAULT:MountMain-Failed To Place Left " Value="1" />
					<CategoricalDouble CategoryName="E - FAULT:MountMain-Part Missing From Left Nest" Value="1" />
					<CategoricalDouble CategoryName="E - FAULT:OffloadMain-Missing Part In Right Nest" Value="1" />
					<CategoricalDouble CategoryName="E - FAULT:OffloadMain-Unexpected Part In Left Nest" Value="1" />
					<CategoricalDouble CategoryName="E - FAULT:RHTriggerTestPC-(No message defined)" Value="1" />
					<CategoricalDouble CategoryName="E - FAULT:SpringFeeder-Failed To Feed Left Trigger Spring In Escapement" Value="6" />
					<CategoricalDouble CategoryName="E - FAULT:SpringFeeder-Failed To Feed Right Trigger Spring In Escapement" Value="4" />
					<CategoricalDouble CategoryName="E - FAULT:SpringFeeder-Left Hand Spring Low Level" Value="4" />
					<CategoricalDouble CategoryName="E - FAULT:SpringFeeder-Right Hand Spring Low Level" Value="9" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 150 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="110">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="F - FAULT:VisionServerMultiplexer-Socket is not open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 160 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="150">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="G - FAULT:TrgMain-Left Trigger Failed to be Detected After Robot Placed" Value="1" />
					<CategoricalDouble CategoryName="G - FAULT:TrgPalletShuttle-Missing 1 Or More Parts At Prestop" Value="2" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 170 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="630">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="H - FAULT:FPCToPCAMain-Left Wedge Failed To Raise" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:FPCToPCARobot-Robot Did Not Turn Off Complete Handshakes" Value="2" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadMain-Part Missing From Nest" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadPalletPusher-Pallet Pusher Did Not Extend" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadPalletPusher-Unexpected Pallet At Exit" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadPalletShuttle-Lift Failed To Lower During Reset" Value="3" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadPalletShuttle-Lift Failed To Lower" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:OffloadPalletShuttle-Unexpected Pallet At Shuttle Entry" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:Screw12Feeder-Failed To Escape Screw To Tube 1" Value="4" />
					<CategoricalDouble CategoryName="H - FAULT:Screw12Feeder-Failed To Escape Screw To Tube 2" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:Screw1Main-Holder Failed To Extend" Value="1" />
					<CategoricalDouble CategoryName="H - FAULT:Screw2Robot-Controller Level Error" Value="4" />
					<CategoricalDouble CategoryName="H - FAULT:Screw2Robot-Robot Application Did Not Start" Value="5" />
					<CategoricalDouble CategoryName="H - FAULT:VisionServerMultiplexer-Socket is not open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 180 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="1150">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="I - FAULT:Cam1Interface_FinalVerify-(No message defined)" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:CaseMain-Remove case from robot and update status" Value="3" />
					<CategoricalDouble CategoryName="I - FAULT:CaseMain-Unexpected part sensed in nest prior to placing." Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:Emergency Stop" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:LatchAssyMain-Too Many Pick Fails In A Row" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:LatchMain-Part Missing From Dial Nest" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:LatchMain-Unexpected Part In Nest" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:LatchRobot-Robot Could Not Park" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:LatchSprFeeder-Failed To Feed 3 Times In A Row" Value="3" />
					<CategoricalDouble CategoryName="I - FAULT:LHLvrFeeder-Escapement Failed To Raise" Value="3" />
					<CategoricalDouble CategoryName="I - FAULT:LHLvrMain-Lever Still Sensed On Dial After Pick" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:LHLvrPNP-Part Not Sensed At Dial Load Position After Placing" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:LHLvrSprFeeder-Both Feeders Empty Or Faulted" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadFlipper-Failed To Close Gripper To Release Part" Value="3" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadFlipper-Unexpected Part In Gripper" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadFlipper-Vertical Slide Failed To Lower" Value="4" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadMain-Missing Part In Dial Nest" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadMain-Part Missing From Dial" Value="3" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadMain-Part Missing From Robot Vacuum" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadMain-Robot Failed To Pick" Value="22" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadMain-Unexpected Part On Dial" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadPalletPusher-Pallet Pusher Did Not Retract" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadPalletShuttle-Unexpected Pallet At Exit" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadPalletShuttle-Unexpected Pallet At Shuttle Entry" Value="1" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadPalletShuttle-Unexpected Pallet At Shuttle Exit" Value="2" />
					<CategoricalDouble CategoryName="I - FAULT:OffloadRobot-Controller Level Error" Value="8" />
					<CategoricalDouble CategoryName="I - FAULT:RHLvrSprFeeder-Both Feeders Empty Or Faulted" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 190 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="950">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Bottom Case Missing From Nest" Value="3" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Bottom Case Not Sensed In Nest After Placing" Value="2" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Part Missing From Robot Gripper" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Robot Failed To Pick From Pallet" Value="5" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Unexpected Bottom Case Sensed In Nest" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Unexpected Bottom Case Sensed In Nest" Value="2" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadMain-Vision Failed 3 Times In A Row" Value="4" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadPalletShuttle-Shuttle did not extend" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadPalletShuttle-Unexpected pallet present on shuttle." Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadRobot-Controller Level Error" Value="8" />
					<CategoricalDouble CategoryName="J - FAULT:BotOnloadRobot-Robot Heartbeat Not Responding" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:DongleMain-Unexpected Dongle Sensed In Dial Nest" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:Label Main-Fail Missing Part" Value="3" />
					<CategoricalDouble CategoryName="J - FAULT:Label Main-Failed Vision 3 Times In A Row" Value="3" />
					<CategoricalDouble CategoryName="J - FAULT:LabelPrinter-Failed To Load Print Job" Value="4" />
					<CategoricalDouble CategoryName="J - FAULT:LabelPrinter-Failed To Print Label" Value="5" />
					<CategoricalDouble CategoryName="J - FAULT:LabelRobot-Controller Level Error" Value="4" />
					<CategoricalDouble CategoryName="J - FAULT:LabelRobot-Robot Heartbeat Not Responding" Value="4" />
					<CategoricalDouble CategoryName="J - FAULT:Screw12Feeder-Failed To Escape Screw To Tube 1 - Feeder Low" Value="2" />
					<CategoricalDouble CategoryName="J - FAULT:Screw12Feeder-Failed To Escape Screw To Tube 2 - Feeder Low" Value="1" />
					<CategoricalDouble CategoryName="J - FAULT:Screw4Feeder-Failed To Escape Screw To Tube 1" Value="2" />
					<CategoricalDouble CategoryName="J - FAULT:TopOnloadMain-Unexpected Part Present In Dial Nest" Value="2" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 206 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="390">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="K - FAULT:Emergency Stop" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:OffloadPalletShuttle-Unexpected Part On Pallet At Prestop" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:OnloadClamps-Coupling Cylinder Failed To Retract Or USB Not Inserted" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:OnloadFlipper-Controller And/Or Dongle Not Sensed In Grippers" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:OnloadMain-Dongle Not Sensed After Placing In Nest (Manually Load Parts To N" Value="10" />
					<CategoricalDouble CategoryName="K - FAULT:OnloadRobot-Controller Level Error" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:OnloadRobot-Robot Handshakes On When Expected Off" Value="1" />
					<CategoricalDouble CategoryName="K - FAULT:Test2Robot-Controller Level Error" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 145 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="350">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="N - FAULT:LHHolderFeeder-Bowl Status Not Ok" Value="2" />
					<CategoricalDouble CategoryName="N - FAULT:LHHolderFeeder-Escape Slide Retract Failure" Value="1" />
					<CategoricalDouble CategoryName="N - FAULT:Main-Dial Position Recovery Complete - Full Init Required" Value="1" />
					<CategoricalDouble CategoryName="N - FAULT:OffloadPalletShuttle-Failed To Detect Pallet At Exit" Value="1" />
					<CategoricalDouble CategoryName="N - FAULT:OffloadPalletShuttle-Missing Pallet At Shuttle Exit" Value="2" />
					<CategoricalDouble CategoryName="N - FAULT:OffloadPalletShuttle-Unexpected Part On Pallet At Prestop" Value="5" />
					<CategoricalDouble CategoryName="N - FAULT:VisionServerMultiplexer-Socket is not open" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 155 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="70">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 200 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="350">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="P - FAULT:IAI2AxisServo1-IAI Heartbeat Not Ok" Value="1" />
					<CategoricalDouble CategoryName="P - FAULT:RFPNP1-Head1 Failed To Achieve Vacuum" Value="1" />
					<CategoricalDouble CategoryName="P - FAULT:RFPNP1-Too Many Consecutive Rejected Parts" Value="5" />
					<CategoricalDouble CategoryName="P - FAULT:RFTester1-Too Many Consecutive Bad Parts" Value="3" />
					<CategoricalDouble CategoryName="P - FAULT:RFTester3-Too Many Consecutive Bad Parts" Value="1" />
					<CategoricalDouble CategoryName="P - FAULT:RFWorkstops-Missing Dongle In Downstream" Value="1" />
					<CategoricalDouble CategoryName="P - FAULT:RFWorkstops-Missing Dongle In Upstream" Value="2" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 204 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="110">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="Q - FAULT:Emergency Stop" Value="1" />
				</HorizontalBarChart>
			</Grid>
			<Label Content="Assembly Line Faults for Dial 165 - Sep 22 2015" Style="{StaticResource t24pHeadline}" FontSize="18" Foreground="White" Padding="5 10"/>
			<Grid Height="190">
				<HorizontalBarChart	Margin="20" Title="" Foreground="Black" FontSize="8"
										MaterialProvider="{x:Static GradientMaterialProvider.MaterialHLbB}"
										DataSorter="{x:Static Sorters.Ascending}">
					<CategoricalDouble CategoryName="R - FAULT:GRBufferStop1-Stop Failed To Retract" Value="1" />
					<CategoricalDouble CategoryName="R - FAULT:ThumbMain-Manually Reject Thumbstick/Part Not Sensed After Place" Value="10" />
					<CategoricalDouble CategoryName="R - FAULT:WorkStop1-Unexpected Thumbstick" Value="2" />
				</HorizontalBarChart>
			</Grid>
		</StackPanel>
	</FlexDocumentTab>
</FlexDocument>
