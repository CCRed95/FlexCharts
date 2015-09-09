using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;

namespace Material
{
	public class MaterialSet : Freezable
	{
		public static readonly DependencyProperty P050Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey050));

		public static readonly DependencyProperty P100Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey100));

		public static readonly DependencyProperty P200Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey200));

		public static readonly DependencyProperty P300Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey300));

		public static readonly DependencyProperty P400Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey400));

		public static readonly DependencyProperty P500Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey500));

		public static readonly DependencyProperty P600Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey600));

		public static readonly DependencyProperty P700Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey700));

		public static readonly DependencyProperty P800Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey800));

		public static readonly DependencyProperty P900Property = DP.Register(
			new Meta<MaterialSet, SolidColorBrush>(MaterialPalette.Grey900));

		public SolidColorBrush P050
		{
			get { return (SolidColorBrush)GetValue(P050Property); }
			set { SetValue(P050Property, value); }
		}
		public SolidColorBrush P100
		{
			get { return (SolidColorBrush)GetValue(P100Property); }
			set { SetValue(P100Property, value); }
		}
		public SolidColorBrush P200
		{
			get { return (SolidColorBrush)GetValue(P200Property); }
			set { SetValue(P200Property, value); }
		}
		public SolidColorBrush P300
		{
			get { return (SolidColorBrush)GetValue(P300Property); }
			set { SetValue(P300Property, value); }
		}
		public SolidColorBrush P400
		{
			get { return (SolidColorBrush)GetValue(P400Property); }
			set { SetValue(P400Property, value); }
		}
		public SolidColorBrush P500
		{
			get { return (SolidColorBrush)GetValue(P500Property); }
			set { SetValue(P500Property, value); }
		}
		public SolidColorBrush P600
		{
			get { return (SolidColorBrush)GetValue(P600Property); }
			set { SetValue(P600Property, value); }
		}
		public SolidColorBrush P700
		{
			get { return (SolidColorBrush)GetValue(P700Property); }
			set { SetValue(P700Property, value); }
		}
		public SolidColorBrush P800
		{
			get { return (SolidColorBrush)GetValue(P800Property); }
			set { SetValue(P800Property, value); }
		}
		public SolidColorBrush P900
		{
			get { return (SolidColorBrush)GetValue(P900Property); }
			set { SetValue(P900Property, value); }
		}
		
		protected override Freezable CreateInstanceCore()
		{
			return new MaterialSet();
		}

		public virtual Dictionary<Luminosity, DependencyProperty> LuinosityPairs { get; } = new Dictionary<Luminosity, DependencyProperty>()
		{
			[Luminosity.P050] = P050Property,
			[Luminosity.P100] = P100Property,
			[Luminosity.P200] = P200Property,
			[Luminosity.P300] = P300Property,
			[Luminosity.P400] = P400Property,
			[Luminosity.P500] = P500Property,
			[Luminosity.P600] = P600Property,
			[Luminosity.P700] = P700Property,
			[Luminosity.P800] = P800Property,
			[Luminosity.P900] = P900Property,
		};

		public SolidColorBrush FromLuminosity(Luminosity l)
		{
			if (LuinosityPairs.ContainsKey(l))
			{
				return (SolidColorBrush)GetValue(LuinosityPairs[l]);
			}
			throw new NotSupportedException($"Luminosity {l} not supported");
		} 
	}
}
