using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Material.Converters
{
	public class LargestValueConverter : IMultiValueConverter 
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var val1 = values[0] as double?;
			var val2 = values[1] as double?;
			if (val1 == null || val2 == null)
			{
				throw new Exception("LargestValue param/val cannot be null");
			}
			return val1 > val2 ? val1 : val2;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
