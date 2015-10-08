using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Extensions;

namespace FlexCharts.Controls.Core
{
	public abstract class TextOverflowRenderingStrategy
	{
		public string ProvideText(string text, double width, FontFamily font, double fontSize)
		{
			return ProvideText(text, width, font, fontSize, new Thickness(5));
		} 
		public abstract string ProvideText(string text, double width, FontFamily font, double fontSize, Thickness padding);
	}
	public class EmptyTextRenderingStrategy : TextOverflowRenderingStrategy
	{
		public override string ProvideText(string text, double width, FontFamily font, double fontSize, Thickness padding)
		{
			return text;
		}
	}
	public class RootTrimRenderingStrategy : TextOverflowRenderingStrategy
	{
		public override string ProvideText(string text, double width, FontFamily font, double fontSize, Thickness padding)
		{
			var renderstr = text;
			
			var ellipse = "...";
			var ellipseSize = RenderingExtensions.EstimateLabelRenderSize(font, fontSize, padding, ellipse);
			
			var renderSize = RenderingExtensions.EstimateLabelRenderSize(font, fontSize, padding, renderstr);
			if (renderSize.Width > width)
			{
				do
				{
					renderstr = renderstr.Substring(1);
					renderSize = RenderingExtensions.EstimateLabelRenderSize(font, fontSize, padding, renderstr);
				} while (renderSize.Width > width - ellipseSize.Width && renderstr.Length > 2);
				return ellipse + renderstr;
			}

			return renderstr;
		}
	}
	public class FixedIndexTrimRenderingStrategy : TextOverflowRenderingStrategy
	{
		public int TrimIndex { get; set; } = 5;
		public override string ProvideText(string text, double width, FontFamily font, double fontSize, Thickness padding)
		{
			var renderstr = text;
			width -= 10;
			if (TrimIndex >= renderstr.Length)
				return renderstr;
			if (width <= 40)
				return renderstr;
			var fixedprefix = text.Substring(0, TrimIndex);
			var suffix = text.Substring(TrimIndex);
			var ellipse = "...";
			
			
			var renderSize = RenderingExtensions.EstimateLabelRenderSize(font, fontSize, padding, renderstr);
			if (renderSize.Width > width)
			{
				do
				{
					suffix = suffix.Substring(1);
					renderstr = fixedprefix + ellipse + suffix;
					renderSize = RenderingExtensions.EstimateLabelRenderSize(font, fontSize, padding, renderstr);
				} while (renderSize.Width > width && renderstr.Length > 2);
			}

			return renderstr;
		}
	}
}
