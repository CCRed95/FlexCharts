using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls
{
	public class DirectoryListItem : Control
	{
		public static readonly DependencyProperty DirectoryProperty = DP.Register(
			new Meta<DirectoryListItem, DirectoryInfo>(null, DirectoryChanged));

		private static void DirectoryChanged(DirectoryListItem i, DPChangedEventArgs<DirectoryInfo> e)
		{
			if (e.NewValue != null)
			{
				i.Description = $"Contains {e.NewValue.GetFiles().Count()} Files";
			}
			else
			{
				i.Description = $"Null Directory!";
			}
		}

		public DirectoryInfo Directory
		{
			get { return (DirectoryInfo) GetValue(DirectoryProperty); }
			set { SetValue(DirectoryProperty, value); }
		}
		public static readonly DependencyProperty DescriptionProperty = DP.Register(
			new Meta<DirectoryListItem, string>("Directory Description"));
		public string Description
		{
			get { return (string) GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		static DirectoryListItem()
		{
			 DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectoryListItem), new FrameworkPropertyMetadata(typeof(DirectoryListItem)));
			
		}
	}
}
