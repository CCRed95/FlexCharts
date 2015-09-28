using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;
using Material.IO;

namespace Material.Controls.FileManager
{
	public class DriveBinder : DependencyObject
	{
		public static readonly DependencyProperty ValueProperty = DP.Register(
			new Meta<DriveBinder, IWMIDriveInfo>());
		public IWMIDriveInfo Value
		{
			get { return (IWMIDriveInfo) GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public DriveBinder()
		{
		}

		public DriveBinder(IWMIDriveInfo value)
		{
			Value = value;
		}
	}
}
