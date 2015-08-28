using System.Windows;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primatives
{
	public abstract class PolarLabelingPrimative : FlexPrimative, IPolarLabelingContract
	{
		public static readonly DependencyProperty HorizontalLabelPositionSkewProperty =
			DP.Attach<double>(typeof (PolarLabelingPrimative), new FrameworkPropertyMetadata(15.0));

		public static readonly DependencyProperty OuterLabelPositionScaleProperty =
			DP.Attach<double>(typeof (PolarLabelingPrimative), new FrameworkPropertyMetadata(1.2));


		public static double GetHorizontalLabelPositionSkew(DependencyObject i) => i.Get<double>(HorizontalLabelPositionSkewProperty);
		public static void SetHorizontalLabelPositionSkew(DependencyObject i, double v) => i.Set(HorizontalLabelPositionSkewProperty, v);

		public double HorizontalLabelPositionSkew
		{
			get { return (double) GetValue(HorizontalLabelPositionSkewProperty); }
			set { SetValue(HorizontalLabelPositionSkewProperty, value); }
		}
		public static double GetOuterLabelPositionScale(DependencyObject i) => i.Get<double>(OuterLabelPositionScaleProperty);
		public static void SetOuterLabelPositionScale(DependencyObject i, double v) => i.Set(OuterLabelPositionScaleProperty, v);

		public double OuterLabelPositionScale
		{
			get { return (double) GetValue(OuterLabelPositionScaleProperty); }
			set { SetValue(OuterLabelPositionScaleProperty, value); }
		}

	}
}
