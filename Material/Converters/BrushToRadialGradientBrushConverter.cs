using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Material.Converters
{
	public class BrushToRadialGradientBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var scb = value as SolidColorBrush;
			if(scb == null)
				throw new ArgumentException(@"Expected SolidColorBrush value.", nameof(value));
			return new RadialGradientBrush
			{
				GradientOrigin= new Point(.5,.5),
				Center = new Point(.5, .5),
				GradientStops = new GradientStopCollection()
				{
					new GradientStop(scb.Color, 0),
					new GradientStop(scb.Color, 0.6),
					new GradientStop(Colors.Transparent, 1)
				}
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
