using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primatives
{
	
	public class CircularPrimative : FlexPrimative, ICircularContract
	{
		public static readonly DependencyProperty CircleScaleProperty =
			DP.Attach<double>(typeof (CircularPrimative), new FrameworkPropertyMetadata(0.8));

		public static readonly DependencyProperty AngleOffsetProperty =
			DP.Attach<double>(typeof (CircularPrimative), new FrameworkPropertyMetadata(0.0));
		

		public static double GetCircleScale(DependencyObject i) => i.Get<double>(CircleScaleProperty);
		public static void SetCircleScale(DependencyObject i, double v) => i.Set(CircleScaleProperty, v);

		public double CircleScale
		{
			get { return (double) GetValue(CircleScaleProperty); }
			set { SetValue(CircleScaleProperty, value); }
		}
		
		public static double GetAngleOffset(DependencyObject i) => i.Get<double>(AngleOffsetProperty);
		public static void SetAngleOffset(DependencyObject i, double v) => i.Set(AngleOffsetProperty, v);
		
		public double AngleOffset
		{
			get { return (double) GetValue(AngleOffsetProperty); }
			set { SetValue(AngleOffsetProperty, value); }
		}
	}
}
