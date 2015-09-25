using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls
{
	public class Icon : Control 
	{
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<Icon, Geometry>());
		public Geometry Data
		{
			get { return (Geometry) GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public static readonly DependencyProperty ScaleProperty = DP.Register(
			new Meta<Icon, double>(.8));
		public double Scale
		{
			get { return (double) GetValue(ScaleProperty); }
			set { SetValue(ScaleProperty, value); }
		}
		static Icon()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (Icon), new FrameworkPropertyMetadata(typeof (Icon)));
		}
	}
}
