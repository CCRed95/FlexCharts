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
	public class FileItemDataSource : DependencyObject
	{
		public static readonly DependencyProperty FileProperty = DP.Register(
			new Meta<FileItemDataSource, FileInfo>(null, FileChanged));

		private static void FileChanged(FileItemDataSource i, DPChangedEventArgs<FileInfo> e)
		{
			//if (e.NewValue != null)
			//{
			//	i.Description = $"Contains {e.NewValue.GetFiles().Count()} Files";
			//}
			//else
			//{
			//	i.Description = $"Null Directory!";
			//}
		}

		public FileInfo File
		{
			get { return (FileInfo) GetValue(FileProperty); }
			set { SetValue(FileProperty, value); }
		}
		public static readonly DependencyProperty DescriptionProperty = DP.Register(
			new Meta<FileItemDataSource, string>("File Description"));
		public string Description
		{
			get { return (string) GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		public FileItemDataSource() { }
	}
}
