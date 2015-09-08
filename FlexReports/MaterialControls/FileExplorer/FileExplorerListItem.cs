using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexReports.MaterialControls.FileExplorer
{
	public abstract class FileExplorerListItem : Control
	{
		public static readonly DependencyProperty DescriptionProperty = DP.Register(
			new Meta<FileExplorerListItem, string>("Item Description"));
		public string Description
		{
			get { return (string)GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}

		public static readonly RoutedEvent FileExplorerItemSelectedEvent = EM.Register
			<FileExplorerListItem, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler FileExplorerItemSelected
		{
			add { AddHandler(FileExplorerItemSelectedEvent, value); }
			remove { RemoveHandler(FileExplorerItemSelectedEvent, value); }
		}
	}
}
