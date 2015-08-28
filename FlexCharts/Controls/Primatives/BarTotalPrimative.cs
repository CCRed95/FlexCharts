using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primatives
{
	public abstract class BarTotalPrimative : TextualPrimative, IBarTotalContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Body1;

		public static readonly DependencyProperty BarTotalFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(typeface.FontFamily));

		public static readonly DependencyProperty BarTotalFontStyleProperty =
			DP.Attach<FontStyle>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(typeface.Style));

		public static readonly DependencyProperty BarTotalFontWeightProperty =
			DP.Attach<FontWeight>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(typeface.Weight));

		public static readonly DependencyProperty BarTotalFontStretchProperty =
			DP.Attach<FontStretch>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(typeface.Stretch));

		public static readonly DependencyProperty BarTotalFontSizeProperty =
			DP.Attach<double>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty BarTotalForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(BarTotalPrimative), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P400Descriptor));

		[TypeConverter(typeof(FontFamilyConverter))]
		public static FontFamily GetBarTotalFontFamily(DependencyObject i) => i.Get<FontFamily>(BarTotalFontFamilyProperty);
		[TypeConverter(typeof(FontFamilyConverter))]
		public static void SetBarTotalFontFamily(DependencyObject i, FontFamily v) => i.Set(BarTotalFontFamilyProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily BarTotalFontFamily
		{
			get { return (FontFamily)GetValue(BarTotalFontFamilyProperty); }
			set { SetValue(BarTotalFontFamilyProperty, value); }
		}
		[TypeConverter(typeof(FontStyleConverter))]
		public static FontStyle GetBarTotalFontStyle(DependencyObject i) => i.Get<FontStyle>(BarTotalFontStyleProperty);
		[TypeConverter(typeof(FontStyleConverter))]
		public static void SetBarTotalFontStyle(DependencyObject i, FontStyle v) => i.Set(BarTotalFontStyleProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle BarTotalFontStyle
		{
			get { return (FontStyle)GetValue(BarTotalFontStyleProperty); }
			set { SetValue(BarTotalFontStyleProperty, value); }
		}
		[TypeConverter(typeof(FontWeightConverter))]
		public static FontWeight GetBarTotalFontWeight(DependencyObject i) => i.Get<FontWeight>(BarTotalFontWeightProperty);
		[TypeConverter(typeof(FontWeightConverter))]
		public static void SetBarTotalFontWeight(DependencyObject i, FontWeight v) => i.Set(BarTotalFontWeightProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight BarTotalFontWeight
		{
			get { return (FontWeight)GetValue(BarTotalFontWeightProperty); }
			set { SetValue(BarTotalFontWeightProperty, value); }
		}
		[TypeConverter(typeof(FontStretchConverter))]
		public static FontStretch GetBarTotalFontStretch(DependencyObject i) => i.Get<FontStretch>(BarTotalFontStretchProperty);
		[TypeConverter(typeof(FontStretchConverter))]
		public static void SetBarTotalFontStretch(DependencyObject i, FontStretch v) => i.Set(BarTotalFontStretchProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch BarTotalFontStretch
		{
			get { return (FontStretch)GetValue(BarTotalFontStretchProperty); }
			set { SetValue(BarTotalFontStretchProperty, value); }
		}
		[TypeConverter(typeof(FontSizeConverter))]
		public static double GetBarTotalFontSize(DependencyObject i) => i.Get<double>(BarTotalFontSizeProperty);
		[TypeConverter(typeof(FontSizeConverter))]
		public static void SetBarTotalFontSize(DependencyObject i, double v) => i.Set(BarTotalFontSizeProperty, v);
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double BarTotalFontSize
		{
			get { return (double)GetValue(BarTotalFontSizeProperty); }
			set { SetValue(BarTotalFontSizeProperty, value); }
		}

		public static AbstractMaterialDescriptor GetBarTotalForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(BarTotalForegroundProperty);
		public static void SetBarTotalForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(BarTotalForegroundProperty, v);
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor BarTotalForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(BarTotalForegroundProperty); }
			set { SetValue(BarTotalForegroundProperty, value); }
		}
	}
}
