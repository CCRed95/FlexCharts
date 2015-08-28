using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primatives
{
	public interface IXAxisContract
	{
		FontFamily XAxisFontFamily { get; set; }
		FontStyle XAxisFontStyle { get; set; }
		FontWeight XAxisFontWeight { get; set; }
		FontStretch XAxisFontStretch { get; set; }
		double XAxisFontSize { get; set; }
		AbstractMaterialDescriptor XAxisForeground { get; set; }
	}
	public abstract class XAxisPrimative : TextualPrimative, IXAxisContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Body1;

		public static readonly DependencyProperty XAxisFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(typeface.FontFamily));

		public static readonly DependencyProperty XAxisFontStyleProperty =
			DP.Attach<FontStyle>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(typeface.Style));

		public static readonly DependencyProperty XAxisFontWeightProperty =
			DP.Attach<FontWeight>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(typeface.Weight));

		public static readonly DependencyProperty XAxisFontStretchProperty =
			DP.Attach<FontStretch>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(typeface.Stretch));

		public static readonly DependencyProperty XAxisFontSizeProperty =
			DP.Attach<double>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty XAxisForegroundProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof(XAxisPrimative), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P500Descriptor));

		//TODO [SharedFont___Attribute] for attached ApplyTargetedTypset<T>(flextypeface) where T : FlexTextualPrimative
		public static FontFamily GetXAxisFontFamily(DependencyObject i) => i.Get<FontFamily>(XAxisFontFamilyProperty);
		public static void SetXAxisFontFamily(DependencyObject i, FontFamily v) => i.Set(XAxisFontFamilyProperty, v);
		public FontFamily XAxisFontFamily
		{
			get { return (FontFamily)GetValue(XAxisFontFamilyProperty); }
			set { SetValue(XAxisFontFamilyProperty, value); }
		}

		public static FontStyle GetXAxisFontStyle(DependencyObject i) => i.Get<FontStyle>(XAxisFontStyleProperty);
		public static void SetXAxisFontStyle(DependencyObject i, FontStyle v) => i.Set(XAxisFontStyleProperty, v);
		public FontStyle XAxisFontStyle
		{
			get { return (FontStyle)GetValue(XAxisFontStyleProperty); }
			set { SetValue(XAxisFontStyleProperty, value); }
		}

		public static FontWeight GetXAxisFontWeight(DependencyObject i) => i.Get<FontWeight>(XAxisFontWeightProperty);
		public static void SetXAxisFontWeight(DependencyObject i, FontWeight v) => i.Set(XAxisFontWeightProperty, v);
		public FontWeight XAxisFontWeight
		{
			get { return (FontWeight)GetValue(XAxisFontWeightProperty); }
			set { SetValue(XAxisFontWeightProperty, value); }
		}

		public static FontStretch GetXAxisFontStretch(DependencyObject i) => i.Get<FontStretch>(XAxisFontStretchProperty);
		public static void SetXAxisFontStretch(DependencyObject i, FontStretch v) => i.Set(XAxisFontStretchProperty, v);
		public FontStretch XAxisFontStretch
		{
			get { return (FontStretch)GetValue(XAxisFontStretchProperty); }
			set { SetValue(XAxisFontStretchProperty, value); }
		}

		public static double GetXAxisFontSize(DependencyObject i) => i.Get<double>(XAxisFontSizeProperty);
		public static void SetXAxisFontSize(DependencyObject i, double v) => i.Set(XAxisFontSizeProperty, v);
		public double XAxisFontSize
		{
			get { return (double)GetValue(XAxisFontSizeProperty); }
			set { SetValue(XAxisFontSizeProperty, value); }
		}

		public static AbstractMaterialDescriptor GetXAxisForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(XAxisForegroundProperty);
		public static void SetXAxisForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(XAxisForegroundProperty, v);
		public AbstractMaterialDescriptor XAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(XAxisForegroundProperty); }
			set { SetValue(XAxisForegroundProperty, value); }
		}

	}
}