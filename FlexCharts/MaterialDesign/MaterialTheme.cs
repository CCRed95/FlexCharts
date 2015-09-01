using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.MaterialDesign
{
	public class MaterialTheme : Freezable
	{
		public static readonly DependencyProperty P050Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink050));
		public SolidColorBrush P050
		{
			get { return (SolidColorBrush) GetValue(P050Property); }
			set { SetValue(P050Property, value); }
		}
		public static readonly DependencyProperty P100Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink100));
		public SolidColorBrush P100
		{
			get { return (SolidColorBrush) GetValue(P100Property); }
			set { SetValue(P100Property, value); }
		}
		public static readonly DependencyProperty P200Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink200));
		public SolidColorBrush P200
		{
			get { return (SolidColorBrush) GetValue(P200Property); }
			set { SetValue(P200Property, value); }
		}
		public static readonly DependencyProperty P300Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink300));
		public SolidColorBrush P300
		{
			get { return (SolidColorBrush) GetValue(P300Property); }
			set { SetValue(P300Property, value); }
		}
		public static readonly DependencyProperty P400Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink400));
		public SolidColorBrush P400
		{
			get { return (SolidColorBrush) GetValue(P400Property); }
			set { SetValue(P400Property, value); }
		}
		public static readonly DependencyProperty P500Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink500));
		public SolidColorBrush P500
		{
			get { return (SolidColorBrush) GetValue(P500Property); }
			set { SetValue(P500Property, value); }
		}
		public static readonly DependencyProperty P600Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink600));
		public SolidColorBrush P600
		{
			get { return (SolidColorBrush) GetValue(P600Property); }
			set { SetValue(P600Property, value); }
		}
		public static readonly DependencyProperty P700Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink700));
		public SolidColorBrush P700
		{
			get { return (SolidColorBrush) GetValue(P700Property); }
			set { SetValue(P700Property, value); }
		}
		public static readonly DependencyProperty P800Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink800));
		public SolidColorBrush P800
		{
			get { return (SolidColorBrush) GetValue(P800Property); }
			set { SetValue(P800Property, value); }
		}
		public static readonly DependencyProperty P900Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink900));
		public SolidColorBrush P900
		{
			get { return (SolidColorBrush) GetValue(P900Property); }
			set { SetValue(P900Property, value); }
		}

		//public MaterialTheme(MaterialSet set)
		//{
		//	P050 = set.GetMaterial(Luminosity.P050);
		//	P100 = set.GetMaterial(Luminosity.P100);
		//	P200 = set.GetMaterial(Luminosity.P200);
		//	P300 = set.GetMaterial(Luminosity.P300);
		//	P400 = set.GetMaterial(Luminosity.P400);
		//	P500 = set.GetMaterial(Luminosity.P500);
		//	P600 = set.GetMaterial(Luminosity.P600);
		//	P700 = set.GetMaterial(Luminosity.P700);
		//	P800 = set.GetMaterial(Luminosity.P800);
		//	P900 = set.GetMaterial(Luminosity.P900);
		//}
		protected override Freezable CreateInstanceCore()
		{
			return new MaterialTheme();
		}
	}
}
