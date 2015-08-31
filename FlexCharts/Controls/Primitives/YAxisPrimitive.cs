using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Primitives.TextAttributes;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primitives
{
	public abstract class YAxisPrimitive : TextualPrimitive, IYAxisContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Body1;
		[TextualRoleProperty(TextualRole.Font)]
		public static readonly DependencyProperty YAxisFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(typeface.FontFamily));
		[TextualRoleProperty(TextualRole.Style)]
		public static readonly DependencyProperty YAxisFontStyleProperty =
			DP.Attach<FontStyle>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(typeface.Style));
		[TextualRoleProperty(TextualRole.Weight)]
		public static readonly DependencyProperty YAxisFontWeightProperty =
			DP.Attach<FontWeight>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(typeface.Weight));
		[TextualRoleProperty(TextualRole.Stretch)]
		public static readonly DependencyProperty YAxisFontStretchProperty =
			DP.Attach<FontStretch>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(typeface.Stretch));
		[TextualRoleProperty(TextualRole.Size)]
		public static readonly DependencyProperty YAxisFontSizeProperty =
			DP.Attach<double>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty YAxisForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(YAxisPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P500Descriptor));

		[TypeConverter(typeof(FontFamilyConverter))]
		public static FontFamily GetYAxisFontFamily(DependencyObject i) => i.Get<FontFamily>(YAxisFontFamilyProperty);
		[TypeConverter(typeof(FontFamilyConverter))]
		public static void SetYAxisFontFamily(DependencyObject i, FontFamily v) => i.Set(YAxisFontFamilyProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily YAxisFontFamily
		{
			get { return (FontFamily)GetValue(YAxisFontFamilyProperty); }
			set { SetValue(YAxisFontFamilyProperty, value); }
		}
		[TypeConverter(typeof(FontStyleConverter))]
		public static FontStyle GetYAxisFontStyle(DependencyObject i) => i.Get<FontStyle>(YAxisFontStyleProperty);
		[TypeConverter(typeof(FontStyleConverter))]
		public static void SetYAxisFontStyle(DependencyObject i, FontStyle v) => i.Set(YAxisFontStyleProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle YAxisFontStyle
		{
			get { return (FontStyle)GetValue(YAxisFontStyleProperty); }
			set { SetValue(YAxisFontStyleProperty, value); }
		}
		[TypeConverter(typeof(FontWeightConverter))]
		public static FontWeight GetYAxisFontWeight(DependencyObject i) => i.Get<FontWeight>(YAxisFontWeightProperty);
		[TypeConverter(typeof(FontWeightConverter))]
		public static void SetYAxisFontWeight(DependencyObject i, FontWeight v) => i.Set(YAxisFontWeightProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight YAxisFontWeight
		{
			get { return (FontWeight)GetValue(YAxisFontWeightProperty); }
			set { SetValue(YAxisFontWeightProperty, value); }
		}
		[TypeConverter(typeof(FontStretchConverter))]
		public static FontStretch GetYAxisFontStretch(DependencyObject i) => i.Get<FontStretch>(YAxisFontStretchProperty);
		[TypeConverter(typeof(FontStretchConverter))]
		public static void SetYAxisFontStretch(DependencyObject i, FontStretch v) => i.Set(YAxisFontStretchProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch YAxisFontStretch
		{
			get { return (FontStretch)GetValue(YAxisFontStretchProperty); }
			set { SetValue(YAxisFontStretchProperty, value); }
		}
		[TypeConverter(typeof(FontSizeConverter))]
		public static double GetYAxisFontSize(DependencyObject i) => i.Get<double>(YAxisFontSizeProperty);
		[TypeConverter(typeof(FontSizeConverter))]
		public static void SetYAxisFontSize(DependencyObject i, double v) => i.Set(YAxisFontSizeProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double YAxisFontSize
		{
			get { return (double)GetValue(YAxisFontSizeProperty); }
			set { SetValue(YAxisFontSizeProperty, value); }
		}
		public static AbstractMaterialDescriptor GetYAxisForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(YAxisForegroundProperty);
		public static void SetYAxisForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(YAxisForegroundProperty, v);
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor YAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(YAxisForegroundProperty); }
			set { SetValue(YAxisForegroundProperty, value); }
		}

	}
}