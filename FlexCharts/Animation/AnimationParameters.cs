using System;
using System.Windows;

namespace FlexCharts.Animation
{
	public static class AnimationParameters
	{
		public static Duration TimelineDuration { get; set; } = 
			new Duration(TimeSpan.FromMilliseconds(700));
		public static double AccelerationRatio { get; } = 0.4;
		public static double DecelerationRatio { get; } = 0.3;
	}
}
