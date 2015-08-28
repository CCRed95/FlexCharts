using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primatives
{
	public interface IValueContract
	{
		FontFamily ValueFontFamily { get; set; }
		FontStyle ValueFontStyle { get; set; }
		FontWeight ValueFontWeight { get; set; }
		FontStretch ValueFontStretch { get; set; }
		double ValueFontSize { get; set; }
		AbstractMaterialDescriptor ValueForeground { get; set; }
	}
	public abstract class ValuePrimative : TextualPrimative, IValueContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Caption;

		public static readonly DependencyProperty ValueFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(ValuePrimative), new FrameworkPropertyMetadata(typeface.FontFamily));

		public static readonly DependencyProperty ValueFontStyleProperty =
			DP.Attach<FontStyle>(typeof(ValuePrimative), new FrameworkPropertyMetadata(typeface.Style));

		public static readonly DependencyProperty ValueFontWeightProperty =
			DP.Attach<FontWeight>(typeof(ValuePrimative), new FrameworkPropertyMetadata(typeface.Weight));

		public static readonly DependencyProperty ValueFontStretchProperty =
			DP.Attach<FontStretch>(typeof(ValuePrimative), new FrameworkPropertyMetadata(typeface.Stretch));

		public static readonly DependencyProperty ValueFontSizeProperty =
			DP.Attach<double>(typeof(ValuePrimative), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty ValueForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(ValuePrimative), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		//TODO [SharedFont___Attribute] for attached ApplyTargetedTypset<T>(flextypeface) where T : FlexTextualPrimative
		public static FontFamily GetValueFontFamily(DependencyObject i) => i.Get<FontFamily>(ValueFontFamilyProperty);
		public static void SetValueFontFamily(DependencyObject i, FontFamily v) => i.Set(ValueFontFamilyProperty, v);
		public FontFamily ValueFontFamily
		{
			get { return (FontFamily)GetValue(ValueFontFamilyProperty); }
			set { SetValue(ValueFontFamilyProperty, value); }
		}

		public static FontStyle GetValueFontStyle(DependencyObject i) => i.Get<FontStyle>(ValueFontStyleProperty);
		public static void SetValueFontStyle(DependencyObject i, FontStyle v) => i.Set(ValueFontStyleProperty, v);
		public FontStyle ValueFontStyle
		{
			get { return (FontStyle)GetValue(ValueFontStyleProperty); }
			set { SetValue(ValueFontStyleProperty, value); }
		}

		public static FontWeight GetValueFontWeight(DependencyObject i) => i.Get<FontWeight>(ValueFontWeightProperty);
		public static void SetValueFontWeight(DependencyObject i, FontWeight v) => i.Set(ValueFontWeightProperty, v);
		public FontWeight ValueFontWeight
		{
			get { return (FontWeight)GetValue(ValueFontWeightProperty); }
			set { SetValue(ValueFontWeightProperty, value); }
		}

		public static FontStretch GetValueFontStretch(DependencyObject i) => i.Get<FontStretch>(ValueFontStretchProperty);
		public static void SetValueFontStretch(DependencyObject i, FontStretch v) => i.Set(ValueFontStretchProperty, v);
		public FontStretch ValueFontStretch
		{
			get { return (FontStretch)GetValue(ValueFontStretchProperty); }
			set { SetValue(ValueFontStretchProperty, value); }
		}

		public static double GetValueFontSize(DependencyObject i) => i.Get<double>(ValueFontSizeProperty);
		public static void SetValueFontSize(DependencyObject i, double v) => i.Set(ValueFontSizeProperty, v);
		public double ValueFontSize
		{
			get { return (double)GetValue(ValueFontSizeProperty); }
			set { SetValue(ValueFontSizeProperty, value); }
		}

		public static AbstractMaterialDescriptor GetValueForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(ValueForegroundProperty);
		public static void SetValueForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(ValueForegroundProperty, v);
		public AbstractMaterialDescriptor ValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(ValueForegroundProperty); }
			set { SetValue(ValueForegroundProperty, value); }
		}
	}
}
