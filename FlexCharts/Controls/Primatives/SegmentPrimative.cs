using System.Windows;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primatives
{
	public abstract class SegmentPrimative : FlexPrimative, ISegmentContract
	{
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof (SegmentPrimative), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.White000O05Descriptor));

		public static readonly DependencyProperty SegmentWidthPercentageProperty =
			DP.Attach<double>(typeof (SegmentPrimative), new FrameworkPropertyMetadata(.6));


		public static AbstractMaterialDescriptor GetSegmentSpaceBackground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(SegmentSpaceBackgroundProperty);
		public static void SetSegmentSpaceBackground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(SegmentSpaceBackgroundProperty, v);
		public AbstractMaterialDescriptor SegmentSpaceBackground
		{
			get { return (AbstractMaterialDescriptor) GetValue(SegmentSpaceBackgroundProperty); }
			set { SetValue(SegmentSpaceBackgroundProperty, value); }
		}

		public static double GetSegmentWidthPercentage(DependencyObject i) => i.Get<double>(SegmentWidthPercentageProperty);
		public static void SetSegmentWidthPercentage(DependencyObject i, double v) => i.Set(SegmentWidthPercentageProperty, v);
		public double SegmentWidthPercentage
		{
			get { return (double) GetValue(SegmentWidthPercentageProperty); }
			set { SetValue(SegmentWidthPercentageProperty, value); }
		}
	}
}
