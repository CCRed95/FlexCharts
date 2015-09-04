using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.Data
{
	public class DirectoryItemDataSource : DependencyObject
	{
		public static readonly DependencyProperty DirectoryProperty = DP.Register(
			new Meta<DirectoryItemDataSource, DirectoryInfo>(null, DirectoryChanged));

		private static void DirectoryChanged(DirectoryItemDataSource i, DPChangedEventArgs<DirectoryInfo> e)
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
			new Meta<DirectoryItemDataSource, string>("Contains # Items"));
		public string Description
		{
			get { return (string) GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		public DirectoryItemDataSource() { }
	}
}
