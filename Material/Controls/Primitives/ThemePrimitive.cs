using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using Material.Static;

namespace Material.Controls.Primitives
{
	public static class ThemePrimitive
	{
		public static readonly DependencyProperty ThemeProperty = DependencyProperty.RegisterAttached(
			"Theme",
			typeof(MaterialSet),
			typeof(ThemePrimitive),
			new FrameworkPropertyMetadata(Palette.Teal, FrameworkPropertyMetadataOptions.Inherits)
			);
		public static MaterialSet GetTheme(DependencyObject i) => i.Get<MaterialSet>(ThemeProperty);
		public static void SetTheme(DependencyObject i, MaterialSet v) => i.Set(ThemeProperty, v);

	}
}
