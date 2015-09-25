using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using FlexCharts.Extensions;
using FlexCharts.Require;

namespace Material.Converters
{
	public class RootTrimConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var str = values[0].RequireType<string>();
			var renderstr = str;

			var targetControl = values[1].RequireType<Control>();
			var relativeControl = values[2].RequireType<Control>();
			if (!targetControl.IsLoaded)
			{
				targetControl.Loaded += (s, e) =>
				{
					//targetControl.Width = (double)Convert(values, targetType, parameter, culture);
				};
			}
			var ellipse = "...";
			var ellipseSize = RenderingExtensions.EstimateLabelRenderSize(targetControl.FontFamily, targetControl.FontSize, ellipse);

			var targetWidth = relativeControl.ActualWidth - ellipseSize.Width - 10;
			var renderSize = RenderingExtensions.EstimateLabelRenderSize(targetControl.FontFamily, targetControl.FontSize, renderstr);
			if (renderSize.Width > targetWidth)
			{
				do
				{
					renderstr = renderstr.Substring(1);
					renderSize = RenderingExtensions.EstimateLabelRenderSize(targetControl.FontFamily, targetControl.FontSize, renderstr);
				} while (renderSize.Width > targetWidth && renderstr.Length > 2);
				return ellipse + renderstr;
			}

			return renderstr;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
