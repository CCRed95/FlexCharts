using System;
using System.IO;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.FileManager
{
	public class DirectoryBinder : DependencyObject
	{
		public static readonly DependencyProperty ValueProperty = DP.Register(
			new Meta<DirectoryBinder, DirectoryInfo>());
		public DirectoryInfo Value
		{
			get { return (DirectoryInfo) GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public DirectoryBinder() { }

		public DirectoryBinder(DirectoryInfo value)
		{
			Value = value;
		}
	}
}
