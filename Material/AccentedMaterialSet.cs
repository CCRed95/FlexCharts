using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;

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
	}
}
