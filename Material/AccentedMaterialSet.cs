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
	public class AccentedMaterialSet : MaterialSet
	{
		public static readonly DependencyProperty A100Property = DP.Register(
			new Meta<AccentedMaterialSet, SolidColorBrush>());

		public static readonly DependencyProperty A200Property = DP.Register(
			new Meta<AccentedMaterialSet, SolidColorBrush>());

		public static readonly DependencyProperty A400Property = DP.Register(
			new Meta<AccentedMaterialSet, SolidColorBrush>());

		public static readonly DependencyProperty A700Property = DP.Register(
			new Meta<AccentedMaterialSet, SolidColorBrush>());

		public SolidColorBrush A100
		{
			get { return (SolidColorBrush)GetValue(A100Property); }
			set { SetValue(A100Property, value); }
		}
		public SolidColorBrush A200
		{
			get { return (SolidColorBrush)GetValue(A200Property); }
			set { SetValue(A200Property, value); }
		}
		public SolidColorBrush A400
		{
			get { return (SolidColorBrush)GetValue(A400Property); }
			set { SetValue(A400Property, value); }
		}
		public SolidColorBrush A700
		{
			get { return (SolidColorBrush)GetValue(A700Property); }
			set { SetValue(A700Property, value); }
		}
		public override Dictionary<Luminosity, DependencyProperty> LuinosityPairs { get; } = new Dictionary<Luminosity, DependencyProperty>
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
			[Luminosity.A100] = A100Property,
			[Luminosity.A200] = A200Property,
			[Luminosity.A400] = A400Property,
			[Luminosity.A700] = A700Property
		};
	}
}
