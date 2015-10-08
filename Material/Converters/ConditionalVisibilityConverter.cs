using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Material.Converters
{
	public class ConditionalVisibilityConverter : MarkupExtension, IValueConverter
	{
		private static ConditionalVisibilityConverter _converter;
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value).Equals(parameter) ? Visibility.Visible : Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _converter ?? (_converter = new ConditionalVisibilityConverter());
		}
	}
	public class ConditionalExpressionVisibilityConverter : MarkupExtension, IValueConverter
	{
		private static ConditionalExpressionVisibilityConverter _converter;
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToBoolean(value)).Equals(System.Convert.ToBoolean(parameter)) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _converter ?? (_converter = new ConditionalExpressionVisibilityConverter());
		}
	}
}
