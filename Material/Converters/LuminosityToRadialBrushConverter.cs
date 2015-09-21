using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;
using Material.Static;

namespace Material.Converters
{
	public class LuminosityToRadialBrushConverter : IMultiValueConverter
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
				var themeBrush = themeSource.FromLuminosity(luminosity);
				return new RadialGradientBrush
				{
					GradientOrigin = new Point(.5, .5),
					Center = new Point(.5, .5),
					GradientStops = new GradientStopCollection
				{
					new GradientStop(themeBrush.Color, 0),
					new GradientStop(themeBrush.Color, 0.6),
					new GradientStop(Colors.Transparent, 1)
				}
				};

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