using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;

namespace FlexReports.MaterialControls
{
public class MaterialSetToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var materialSet = value.RequireType<MaterialSet>();
			var luminosity = parameter.RequireType<Luminosity>();
			var ScaledValue = materialSet.GetMaterial(luminosity);
			return ScaledValue.Brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
