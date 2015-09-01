using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using FlexCharts.Animation;

namespace FlexCharts.Extensions
{
	public static class AnimationExtensions
	{
		public static void beginAnimation(this FrameworkElement i, DependencyProperty dp, int ms, double to)
		{
			i.BeginAnimation(dp, new DoubleAnimation(to, new Duration(TimeSpan.FromMilliseconds(ms)))
			{
				AccelerationRatio = AnimationParameters.AccelerationRatio,
				DecelerationRatio = AnimationParameters.DecelerationRatio
			});
		}
	}
}
