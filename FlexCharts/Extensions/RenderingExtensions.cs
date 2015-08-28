using System.Globalization;
using System.Windows;
using System.Windows.Media;
using FlexCharts.MaterialDesign;

namespace FlexCharts.Extensions
{
	public class RenderingExtensions
	{
		// TODO pass string content for all these. or else size.width means nothing
		public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
		{
			var defaultPadding = new Thickness(5);
			return EstimateTextRenderSize(fontFamily, fontSize, defaultPadding, content);
		}
		public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
		{
			return EstimateTextRenderSize(fontFamily, fontSize, padding, content);
		}
		public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
		{
			return EstimateTextRenderSize(fontFamily, fontSize, new Thickness(0), content);
		}
		public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
		{
			var formattedText = new FormattedText("Fq", CultureInfo.GetCultureInfo("en-us"),
						FlowDirection.LeftToRight, new Typeface(fontFamily.ToString()), fontSize, MaterialPalette.Black000);
			return new Size(formattedText.Width + padding.Left + padding.Right, formattedText.Height + padding.Top + padding.Bottom);
		}
	}
}
