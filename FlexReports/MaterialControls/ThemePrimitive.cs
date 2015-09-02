using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;

namespace FlexReports.MaterialControls
{
	public static class ThemePrimitive
	{
		public static readonly DependencyProperty ThemeProperty = DependencyProperty.RegisterAttached(
			"Theme",
			typeof(MaterialTheme),
			typeof(ThemePrimitive),
			new FrameworkPropertyMetadata(MaterialThemes.DeepPurpleTheme, FrameworkPropertyMetadataOptions.Inherits)
			);
		//DP.Attach<MaterialTheme>(typeof (MaterialPalette), new FrameworkPropertyMetadata(MaterialThemes.BrownTheme, FrameworkPropertyMetadataOptions.Inherits));

		public static MaterialTheme GetTheme(DependencyObject i) => i.Get<MaterialTheme>(ThemeProperty);
		public static void SetTheme(DependencyObject i, MaterialTheme v) => i.Set(ThemeProperty, v);

	}
}
