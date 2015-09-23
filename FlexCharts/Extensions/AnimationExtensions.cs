using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace FlexCharts.Extensions
{
	public static class AnimationExtensions
	{
		public static void animate(this IAnimatable i,
			DependencyProperty dp, 
			int ms, 
			double to, 
			int skewms = 0,
			IEasingFunction easing = null, 
			EventHandler onCompleted = null, 
			double? by = null,
			double? from = null)
		{
			var timeline = new DoubleAnimation(to, new Duration(TimeSpan.FromMilliseconds(ms)))
			{
				BeginTime = TimeSpan.FromMilliseconds(skewms),
				EasingFunction = easing
			};
			if (onCompleted != null) timeline.Completed += onCompleted;
			if (by != null) timeline.By = by;
			if (from != null) timeline.From = from;
			i.BeginAnimation(dp, timeline);
		}

		public static void unregisterAnimation<T>(this T i, DependencyProperty dp) 
			where T : DependencyObject, IAnimatable
		{
			var target = i.GetValue(dp);
			i.SetValue(dp, target);
			i.ApplyAnimationClock(dp, null);
		}
	}
}
