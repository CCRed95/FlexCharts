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
	public class LuminosityToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var luminosity = parameter.RequireType<Luminosity>();
				var themeSource = value.RequireType<MaterialSet>();
				return themeSource.GetMaterial(luminosity);
			}
			catch
			{
				return MaterialPalette.Red500;
			}


		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
