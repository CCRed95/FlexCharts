using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.FileManager
{
	public abstract class AbstractFileManagerListItem : FlexControl
	{
		#region Dependency Properties
		public static readonly DependencyProperty DescriptionProperty = DP.Register(
			new Meta<AbstractFileManagerListItem, string>("Item Description"));
		public static readonly DependencyProperty IsContextMenuExpandedProperty = DP.Register(
			new Meta<AbstractFileManagerListItem, bool>());

		public string Description
		{
			get { return (string)GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		public bool IsContextMenuExpanded
		{
			get { return (bool)GetValue(IsContextMenuExpandedProperty); }
			set { SetValue(IsContextMenuExpandedProperty, value); }
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent SelectedEvent = EM.Register<AbstractFileManagerListItem, RoutedEventHandler>(EM.BUBBLE);
		public static readonly RoutedEvent DeleteFileEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);
		//public static readonly RoutedEvent ContextMenuExpandedEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler Selected
		{
			add { AddHandler(SelectedEvent, value); }
			remove { RemoveHandler(SelectedEvent, value); }
		}
		public event RoutedEventHandler DeleteFile
		{
			add { AddHandler(DeleteFileEvent, value); }
			remove { RemoveHandler(DeleteFileEvent, value); }
		}
		//public event RoutedEventHandler ContextMenuExpanded
		//{
		//	add { AddHandler(ContextMenuExpandedEvent, value); }
		//	remove { RemoveHandler(ContextMenuExpandedEvent, value); }
		//}
		#endregion

		#region Properties
		public abstract FileSystemInfo FileSystemItemBase { get; }
		#endregion

		#region Overriden Members
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			if (IsEnabled && !IsContextMenuExpanded)
			{
				RaiseEvent(new RoutedEventArgs(SelectedEvent));
			}
		}
		#endregion
	}
}
