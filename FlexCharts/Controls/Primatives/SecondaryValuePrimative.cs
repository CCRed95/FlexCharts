using System;
using System.Collections.Generic;
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

	public class SecondaryValuePrimative : TextualPrimative, ISecondaryValueContract
	{
		internal static readonly FlexTypeface typeface = MaterialPalette.Typesets.Caption;

		public static readonly DependencyProperty SecondaryValueFontFamilyProperty =
			DP.Attach<FontFamily>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(typeface.FontFamily));

		public static readonly DependencyProperty SecondaryValueFontStyleProperty = 
			DP.Attach<FontStyle>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(typeface.Style));

		public static readonly DependencyProperty SecondaryValueFontWeightProperty = 
			DP.Attach<FontWeight>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(typeface.Weight));

		public static readonly DependencyProperty SecondaryValueFontStretchProperty = 
			DP.Attach<FontStretch>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(typeface.Stretch));

		public static readonly DependencyProperty SecondaryValueFontSizeProperty =
			DP.Attach<double>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(typeface.Size));

		public static readonly DependencyProperty SecondaryValueForegroundProperty = 
			DP.Attach<AbstractMaterialDescriptor>(typeof(SecondaryValuePrimative), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		//TODO [SharedFont___Attribute] for attached ApplyTargetedTypset<T>(flextypeface) where T : FlexTextualPrimative
		public static FontFamily GetValueFontFamily(DependencyObject i) => i.Get<FontFamily>(SecondaryValueFontFamilyProperty);
		public static void SetValueFontFamily(DependencyObject i, FontFamily v) => i.Set(SecondaryValueFontFamilyProperty, v);
		public FontFamily SecondaryValueFontFamily
		{
			get { return (FontFamily)GetValue(SecondaryValueFontFamilyProperty); }
			set { SetValue(SecondaryValueFontFamilyProperty, value); }
		}

		public static FontStyle GetValueFontStyle(DependencyObject i) => i.Get<FontStyle>(SecondaryValueFontStyleProperty);
		public static void SetValueFontStyle(DependencyObject i, FontStyle v) => i.Set(SecondaryValueFontStyleProperty, v);
		public FontStyle SecondaryValueFontStyle
		{
			get { return (FontStyle)GetValue(SecondaryValueFontStyleProperty); }
			set { SetValue(SecondaryValueFontStyleProperty, value); }
		}

		public static FontWeight GetValueFontWeight(DependencyObject i) => i.Get<FontWeight>(SecondaryValueFontWeightProperty);
		public static void SetValueFontWeight(DependencyObject i, FontWeight v) => i.Set(SecondaryValueFontWeightProperty, v);
		public FontWeight SecondaryValueFontWeight
		{
			get { return (FontWeight)GetValue(SecondaryValueFontWeightProperty); }
			set { SetValue(SecondaryValueFontWeightProperty, value); }
		}
		
		public static FontStretch GetValueFontStretch(DependencyObject i) => i.Get<FontStretch>(SecondaryValueFontStretchProperty);
		public static void SetValueFontStretch(DependencyObject i, FontStretch v) => i.Set(SecondaryValueFontStretchProperty, v);
		public FontStretch SecondaryValueFontStretch
		{
			get { return (FontStretch)GetValue(SecondaryValueFontStretchProperty); }
			set { SetValue(SecondaryValueFontStretchProperty, value); }
		}
		
		public static double GetValueFontSize(DependencyObject i) => i.Get<double>(SecondaryValueFontSizeProperty);
		public static void SetValueFontSize(DependencyObject i, double v) => i.Set(SecondaryValueFontSizeProperty, v);
		
		public double SecondaryValueFontSize
		{
			get { return (double)GetValue(SecondaryValueFontSizeProperty); }
			set { SetValue(SecondaryValueFontSizeProperty, value); }
		}

		public static AbstractMaterialDescriptor GetValueForeground(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(SecondaryValueForegroundProperty);
		public static void SetValueForeground(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(SecondaryValueForegroundProperty, v);
		public AbstractMaterialDescriptor SecondaryValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SecondaryValueForegroundProperty); }
			set { SetValue(SecondaryValueForegroundProperty, value); }
		}
	}
}
