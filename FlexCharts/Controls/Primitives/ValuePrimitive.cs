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
	
	public abstract class ValuePrimitive : TextualPrimitive, IValueContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Caption;
		[TextualRoleProperty(TextualRole.Font)]
		public static readonly DependencyProperty ValueFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(typeface.FontFamily));
		[TextualRoleProperty(TextualRole.Style)]
		public static readonly DependencyProperty ValueFontStyleProperty =
			DP.Attach<FontStyle>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(typeface.Style));
		[TextualRoleProperty(TextualRole.Weight)]
		public static readonly DependencyProperty ValueFontWeightProperty =
			DP.Attach<FontWeight>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(typeface.Weight));
		[TextualRoleProperty(TextualRole.Stretch)]
		public static readonly DependencyProperty ValueFontStretchProperty =
			DP.Attach<FontStretch>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(typeface.Stretch));
			[TextualRoleProperty(TextualRole.Size)]
		public static readonly DependencyProperty ValueFontSizeProperty =
			DP.Attach<double>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty ValueForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(ValuePrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		[TypeConverter(typeof(FontFamilyConverter))]
		public static FontFamily GetValueFontFamily(DependencyObject i) => i.Get<FontFamily>(ValueFontFamilyProperty);
		[TypeConverter(typeof(FontFamilyConverter))]
		public static void SetValueFontFamily(DependencyObject i, FontFamily v) => i.Set(ValueFontFamilyProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily ValueFontFamily
		{
			get { return (FontFamily)GetValue(ValueFontFamilyProperty); }
			set { SetValue(ValueFontFamilyProperty, value); }
		}
		[TypeConverter(typeof(FontStyleConverter))]
		public static FontStyle GetValueFontStyle(DependencyObject i) => i.Get<FontStyle>(ValueFontStyleProperty);
		[TypeConverter(typeof(FontStyleConverter))]
		public static void SetValueFontStyle(DependencyObject i, FontStyle v) => i.Set(ValueFontStyleProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle ValueFontStyle
		{
			get { return (FontStyle)GetValue(ValueFontStyleProperty); }
			set { SetValue(ValueFontStyleProperty, value); }
		}
		[TypeConverter(typeof(FontWeightConverter))]
		public static FontWeight GetValueFontWeight(DependencyObject i) => i.Get<FontWeight>(ValueFontWeightProperty);
		[TypeConverter(typeof(FontWeightConverter))]
		public static void SetValueFontWeight(DependencyObject i, FontWeight v) => i.Set(ValueFontWeightProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight ValueFontWeight
		{
			get { return (FontWeight)GetValue(ValueFontWeightProperty); }
			set { SetValue(ValueFontWeightProperty, value); }
		}
		[TypeConverter(typeof(FontStretchConverter))]
		public static FontStretch GetValueFontStretch(DependencyObject i) => i.Get<FontStretch>(ValueFontStretchProperty);
		[TypeConverter(typeof(FontStretchConverter))]
		public static void SetValueFontStretch(DependencyObject i, FontStretch v) => i.Set(ValueFontStretchProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch ValueFontStretch
		{
			get { return (FontStretch)GetValue(ValueFontStretchProperty); }
			set { SetValue(ValueFontStretchProperty, value); }
		}
		[TypeConverter(typeof(FontSizeConverter))]
		public static double GetValueFontSize(DependencyObject i) => i.Get<double>(ValueFontSizeProperty);
		[TypeConverter(typeof(FontSizeConverter))]
		public static void SetValueFontSize(DependencyObject i, double v) => i.Set(ValueFontSizeProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double ValueFontSize
		{
			get { return (double)GetValue(ValueFontSizeProperty); }
			set { SetValue(ValueFontSizeProperty, value); }
		}

		public static AbstractMaterialDescriptor GetValueForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(ValueForegroundProperty);
		public static void SetValueForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(ValueForegroundProperty, v);
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor ValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(ValueForegroundProperty); }
			set { SetValue(ValueForegroundProperty, value); }
		}
	}
}
