using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.FileManager
{
	public abstract class AbstractFileManagerListItem : Control
	{
		public static readonly DependencyProperty DescriptionProperty = DP.Register(
			new Meta<AbstractFileManagerListItem, string>("Item Description"));

		public string Description
		{
			get { return (string) GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}

		public static readonly RoutedEvent SelectedEvent = EM.Register
			<AbstractFileManagerListItem, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler Selected
		{
			add { AddHandler(SelectedEvent, value); }
			remove { RemoveHandler(SelectedEvent, value); }
		}

		public abstract FileSystemInfo FileSystemItemBase { get; }
	}
}
