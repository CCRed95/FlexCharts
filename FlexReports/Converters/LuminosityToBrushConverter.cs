using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;

namespace FlexReports.Converters
{
	public class LuminosityToBrushConverter : IMultiValueConverter
	{

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var luminosity = values[1].RequireType<Luminosity>();

				var themeSource = values[0].RequireType<MaterialTheme>();
				return themeSource.FromLuminosity(luminosity);
			}
			catch
			{
				return MaterialPalette.Red500;
			}
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
/*public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var luminosity = parameter.RequireType<Luminosity>();
				var themeSource = value.RequireType<MaterialTheme>();
				return themeSource.FromLuminosity(luminosity);
			}
			catch
			{
				return MaterialPalette.Red500;
			}


		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}*/
