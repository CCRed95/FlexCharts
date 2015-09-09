using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FlexCharts.Animation;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls
{
	public class MaterialDimmer : ContentControl
	{
		#region Dependency Properties

		public static readonly DependencyProperty IsDimmedProperty = DP.Register(
			new Meta<MaterialDimmer, bool>(false, IsDimmedChanged));
		
		public static readonly DependencyProperty DimPercentProperty = DP.Register(
			new Meta<MaterialDimmer, double>(0.6));

		public bool IsDimmed
		{
			get { return (bool)GetValue(IsDimmedProperty); }
			set { SetValue(IsDimmedProperty, value); }
		}
		
		public double DimPercent
		{
			get { return (double)GetValue(DimPercentProperty); }
			set { SetValue(DimPercentProperty, value); }
		}
		#endregion

		private static void IsDimmedChanged(MaterialDimmer i, DPChangedEventArgs<bool> e)
		{
			if (e.NewValue)
			{
				i.IsHitTestVisible = true;
				i._rectangle.BeginAnimation(OpacityProperty,
					new DoubleAnimation(i.DimPercent, new Duration(TimeSpan.FromMilliseconds(200)))
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio
					});
			}
			else
			{
				i.IsHitTestVisible = false;
				i._rectangle.BeginAnimation(OpacityProperty,
					new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)))
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio
					});
			}
		}

		#region Fields
		Grid _rectangle = new Grid()
		{
			Opacity = 0,
			Background = Brushes.Black
		};
		#endregion

		public MaterialDimmer()
		{
			IsHitTestVisible = false;
			Content = _rectangle;
		}

	}
}
