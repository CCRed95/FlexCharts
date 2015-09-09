using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;

namespace Material.Converters
{
	public class LuminosityToBrushConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var luminosity = values[1].RequireType<Luminosity>();
				var themeSource = values[0].RequireType<MaterialSet>();
				return themeSource.FromLuminosity(luminosity);
			}
			catch
			{
				throw new NotSupportedException("luminosity not supported");
			}
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}