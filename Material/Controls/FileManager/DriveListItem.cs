using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.Require;
using Material.Controls.Popups;
using Material.IO;

namespace Material.Controls.FileManager
{
	public class DriveListItem : AbstractFileManagerListItem
	{
		#region Dependency Properties
		public static readonly DependencyProperty DriveProperty = DP.Register(
			new Meta<DriveListItem, IWMIDriveInfo>());
		public IWMIDriveInfo Drive
		{
			get { return (IWMIDriveInfo)GetValue(DriveProperty); }
			set { SetValue(DriveProperty, value); }
		}
		#endregion

		public static readonly RoutedEvent DriveSelectedEvent = EM.Register<DriveListItem, RoutedSelectDriveEventHandler>(EM.BUBBLE);
		public event RoutedSelectDriveEventHandler DriveSelected
		{
			add { AddHandler(DriveSelectedEvent, value); }
			remove { RemoveHandler(DriveSelectedEvent, value); }
		}

		static DriveListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DriveListItem), new FrameworkPropertyMetadata(typeof(DriveListItem)));
		}
		#region Overriden Members
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			RaiseEvent(new RoutedSelectDriveEventArgs(Drive.RequireType<LocalDriveInfo>().Drive, DriveSelectedEvent));
			
		}
		#endregion
		//public override void OnApplyTemplate()
		//{
		//	base.OnApplyTemplate();
		//	PART_delete = GetTemplateChild<Button>(nameof(PART_delete));
		//	PART_delete.Click += onDeleteClick;
		//}

		//private void onDeleteClick(object s, RoutedEventArgs e)
		//{
		//	RaiseEvent(new RoutedEventArgs(DeleteFileEvent));
		//}

	}
}
