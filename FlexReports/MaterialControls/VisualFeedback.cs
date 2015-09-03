using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;

namespace FlexReports.MaterialControls
{
	public static class VisualFeedback
	{
		public static readonly DependencyProperty ClickFeedbackProperty = DependencyProperty.RegisterAttached(
			"ClickFeedback",
			typeof(Luminosity),
			typeof(VisualFeedback),
			new FrameworkPropertyMetadata(Luminosity.P700, FrameworkPropertyMetadataOptions.Inherits));
			//DP.Attach<Luminosity>(typeof (VisualFeedback), new FrameworkPropertyMetadata(Luminosity.P700, FrameworkPropertyMetadataOptions.Inherits));

		public static Luminosity GetClickFeedback(DependencyObject i) => i.Get<Luminosity>(ClickFeedbackProperty);
		public static void SetClickFeedback(DependencyObject i, Luminosity v) => i.Set(ClickFeedbackProperty, v);
	}
}
