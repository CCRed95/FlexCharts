using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace Material.Converters
{
	public class ConditionalVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((DriveType)value).Equals((DriveType)parameter) ? Visibility.Visible : Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
