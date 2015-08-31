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
	public abstract class XAxisPrimitive : TextualPrimitive, IXAxisContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Body1;
		[TextualRoleProperty(TextualRole.Font)]
		public static readonly DependencyProperty XAxisFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(typeface.FontFamily));
		[TextualRoleProperty(TextualRole.Style)]
		public static readonly DependencyProperty XAxisFontStyleProperty =
			DP.Attach<FontStyle>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(typeface.Style));
		[TextualRoleProperty(TextualRole.Weight)]
		public static readonly DependencyProperty XAxisFontWeightProperty =
			DP.Attach<FontWeight>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(typeface.Weight));
		[TextualRoleProperty(TextualRole.Stretch)]
		public static readonly DependencyProperty XAxisFontStretchProperty =
			DP.Attach<FontStretch>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(typeface.Stretch));
		[TextualRoleProperty(TextualRole.Size)]
		public static readonly DependencyProperty XAxisFontSizeProperty =
			DP.Attach<double>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty XAxisForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(XAxisPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P500Descriptor));

		[TypeConverter(typeof(FontFamilyConverter))]
		public static FontFamily GetXAxisFontFamily(DependencyObject i) => i.Get<FontFamily>(XAxisFontFamilyProperty);
		[TypeConverter(typeof(FontFamilyConverter))]
		public static void SetXAxisFontFamily(DependencyObject i, FontFamily v) => i.Set(XAxisFontFamilyProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily XAxisFontFamily
		{
			get { return (FontFamily)GetValue(XAxisFontFamilyProperty); }
			set { SetValue(XAxisFontFamilyProperty, value); }
		}
		[TypeConverter(typeof(FontStyleConverter))]
		public static FontStyle GetXAxisFontStyle(DependencyObject i) => i.Get<FontStyle>(XAxisFontStyleProperty);
		[TypeConverter(typeof(FontStyleConverter))]
		public static void SetXAxisFontStyle(DependencyObject i, FontStyle v) => i.Set(XAxisFontStyleProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle XAxisFontStyle
		{
			get { return (FontStyle)GetValue(XAxisFontStyleProperty); }
			set { SetValue(XAxisFontStyleProperty, value); }
		}
		[TypeConverter(typeof(FontWeightConverter))]
		public static FontWeight GetXAxisFontWeight(DependencyObject i) => i.Get<FontWeight>(XAxisFontWeightProperty);
		[TypeConverter(typeof(FontWeightConverter))]
		public static void SetXAxisFontWeight(DependencyObject i, FontWeight v) => i.Set(XAxisFontWeightProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight XAxisFontWeight
		{
			get { return (FontWeight)GetValue(XAxisFontWeightProperty); }
			set { SetValue(XAxisFontWeightProperty, value); }
		}
		[TypeConverter(typeof(FontStretchConverter))]
		public static FontStretch GetXAxisFontStretch(DependencyObject i) => i.Get<FontStretch>(XAxisFontStretchProperty);
		[TypeConverter(typeof(FontStretchConverter))]
		public static void SetXAxisFontStretch(DependencyObject i, FontStretch v) => i.Set(XAxisFontStretchProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch XAxisFontStretch
		{
			get { return (FontStretch)GetValue(XAxisFontStretchProperty); }
			set { SetValue(XAxisFontStretchProperty, value); }
		}
		[TypeConverter(typeof(FontSizeConverter))]
		public static double GetXAxisFontSize(DependencyObject i) => i.Get<double>(XAxisFontSizeProperty);
		[TypeConverter(typeof(FontSizeConverter))]
		public static void SetXAxisFontSize(DependencyObject i, double v) => i.Set(XAxisFontSizeProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double XAxisFontSize
		{
			get { return (double)GetValue(XAxisFontSizeProperty); }
			set { SetValue(XAxisFontSizeProperty, value); }
		}
		public static AbstractMaterialDescriptor GetXAxisForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(XAxisForegroundProperty);
		public static void SetXAxisForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(XAxisForegroundProperty, v);
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor XAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(XAxisForegroundProperty); }
			set { SetValue(XAxisForegroundProperty, value); }
		}

	}
}