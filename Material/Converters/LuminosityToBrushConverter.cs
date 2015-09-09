using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;
using Material.Static;

namespace Material.Converters
{
	public class LuminosityToBrushConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var themeSource = values[0] as MaterialSet;
				if (themeSource == null || Equals(themeSource, DependencyProperty.UnsetValue))
				{
					themeSource = Palette.Pink;
				}
				var luminosity = values[1].RequireType<Luminosity>();
				

				return themeSource.FromLuminosity(luminosity);
			}
			catch
			{
				return Palette.Pink.P500;
				//throw new NotSupportedException($"LuminosityToBrushConverter with params {values[0]} - {values[1]} not supported");
			}
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}