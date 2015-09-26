using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using Material.Controls.FileManager;
using Material.IO;

namespace Material.Controls.Popups
{
	public delegate void RoutedSelectDriveEventHandler(object i, RoutedSelectDriveEventArgs e);

	public class RoutedSelectDriveEventArgs : RoutedEventArgs
	{
		public DriveInfo SelectedDrive { get; }
		public RoutedSelectDriveEventArgs(DriveInfo selectedDrive, RoutedEvent routedEvent) : base(routedEvent)
		{
			SelectedDrive = selectedDrive;
		}
		public RoutedSelectDriveEventArgs(DriveInfo selectedDrive, RoutedEvent routedEvent, object source) : base(routedEvent, source)
		{
			SelectedDrive = selectedDrive;
		}
	}
	public class SelectDrivePopup : PopupBase
	{
		public static readonly DependencyProperty DrivesProperty = DP.Register(
			new Meta<SelectDrivePopup, ObservableCollection<DriveBinder>>());
		public ObservableCollection<DriveBinder> Drives
		{
			get { return (ObservableCollection<DriveBinder>)GetValue(DrivesProperty); }
			set { SetValue(DrivesProperty, value); }
		}

		protected Button PART_buttoncancel;

		static SelectDrivePopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectDrivePopup),
				new FrameworkPropertyMetadata(typeof(SelectDrivePopup)));
		}

		public SelectDrivePopup()
		{
			Drives = new ObservableCollection<DriveBinder>();
			foreach (var d in LocalDriveInfo.GetDrives())
			{
				Drives.Add(new DriveBinder(d));
			}
			EventManager.RegisterClassHandler(typeof(SelectDrivePopup), DriveListItem.DriveSelectedEvent, new RoutedSelectDriveEventHandler(driveSelected));
		}

		private void driveSelected(object i, RoutedSelectDriveEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_buttoncancel = GetTemplateChild<Button>(nameof(PART_buttoncancel));
			PART_buttoncancel.Click += onCancelClicked;
		}

		private void onCancelClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
		
	}
}
