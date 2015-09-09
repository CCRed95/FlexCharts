using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;

namespace Material.Controls.Primitives
{
	public static class VisualFeedback
	{
		public static readonly DependencyProperty ClickFeedbackProperty = DependencyProperty.RegisterAttached(
			"ClickFeedback",
			typeof(Luminosity),
			typeof(VisualFeedback),
			new FrameworkPropertyMetadata(Luminosity.P100, FrameworkPropertyMetadataOptions.Inherits));

		public static Luminosity GetClickFeedback(DependencyObject i) => i.Get<Luminosity>(ClickFeedbackProperty);
		public static void SetClickFeedback(DependencyObject i, Luminosity v) => i.Set(ClickFeedbackProperty, v);
	}
}
