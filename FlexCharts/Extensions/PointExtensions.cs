using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Layout;

namespace FlexCharts.Extensions
{
	public static class PointExtensions
	{
		public static PolarPoint ToPolar(this Point i)
		{
			throw new NotImplementedException();
		}
		// TODO i.Loc(f.RenderedSize);
		public static Point LocalizeInPolarSpace(this Point i, FrameworkElement f)
		{
			var width = f.ActualWidth;
			var height = f.ActualHeight;
			var halfwidth = width / 2;
			return new Point(i.X + halfwidth, height - (i.Y + (height / 2)));
		}
		public static Point LocalizeInPolarSpace(this Point i, Size s)
		{
			var width = s.Width;
			var height = s.Height;
			var halfwidth = width / 2;
			return new Point(i.X + halfwidth, height - (i.Y + (height / 2)));
		}
		public static Point LocalizeInCartesianSpace(this Point i, FrameworkElement f)
		{
			var height = f.ActualHeight;
			return new Point(i.X, height - i.Y);
		}
		public static Point LocalizeInCartesianSpace(this Point i, Size s)
		{
			var height = s.Height;
			return new Point(i.X , height - i.Y);
		}
		public static Point CalculateCenter(this Size i)
		{
			return new Point(i.Width / 2, i.Height / 2);
		}
		public static Point Add(this Point i, Point p)
		{
			return new Point(i.X + p.X, i.Y + p.Y);
		}
		public static Point Push(this Point i, double x, double y)
		{
			return new Point(i.X + x, i.Y + y);
		}
		public static double FindLowestPoint(Point f, params Point[] i)
		{
			return i.Select(pt => pt.Y).Concat(new[] {f.Y}).Min();
		}
	}
}
