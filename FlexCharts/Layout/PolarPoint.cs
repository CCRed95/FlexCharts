using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Extensions;

namespace FlexCharts.Layout
{
	[DebuggerDisplay("r={Radius} φ={Angle}°")]
	public class PolarPoint
	{
		public double Angle { get; set; }
		public double Radius { get; set; }

		public PolarPoint(double angle, double radius)
		{
			Angle = angle;
			Radius = radius;
		}

		public override string ToString()
		{
			return $"r={Math.Round(Radius,1)} φ={Math.Round(Angle,1)}°";
		}

		public Point ToCartesian()
		{
			var angleRadian = CoordinateHelpers.ToRadian(Angle);
			var x = Radius * Math.Cos(angleRadian);
			var y = Radius * Math.Sin(angleRadian);
			return new Point(x, y);
		}
	}
}
