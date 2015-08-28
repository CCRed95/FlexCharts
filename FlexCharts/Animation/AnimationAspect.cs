using System;
using System.Windows;
using System.Windows.Media.Animation;
using FlexCharts.Helpers;

namespace FlexCharts.Animation
{
	public class AnimationAspect<T, D, A> where D : DependencyObject, IAnimatable where A : AnimationTimeline, new()
	{
		public Duration Duration { get; set; } = AnimationParameters.TimelineDuration;
		public TimeSpan BeginTime { get; set; } = TimeSpan.Zero;

		public double AccelerationRatio { get; set; } = AnimationParameters.AccelerationRatio;
		public double DecelerationRatio { get; set; } = AnimationParameters.DecelerationRatio;

		public D AnimationTarget { get; }
		public DependencyProperty AnimationProperty { get; }

		public T CollapsedState { get; set; }
		public T FinalState { get; set; }

		protected DependencyProperty reflectedToProperty;
		protected DependencyProperty reflectedFromProperty;

		public AnimationAspect(D animationTarget, DependencyProperty animationProperty,
			 T collapsedState, T finalState, AnimationState defaultState)
		{
			AnimationTarget = animationTarget;
			AnimationProperty = animationProperty;
			CollapsedState = collapsedState;
			FinalState = finalState;

			reflectedFromProperty = ReflectionHelper.GetDependencyProperty("From", typeof(A), true);
			reflectedToProperty = ReflectionHelper.GetDependencyProperty("To", typeof(A), true);

			animationTarget.SetValue(animationProperty, defaultState == AnimationState.Collapsed ? collapsedState : finalState);
		}

		public void AnimateTo(AnimationState animationState)
		{
			var animationTimeline = new A
			{
				BeginTime = BeginTime,
				Duration = Duration,
				AccelerationRatio = AccelerationRatio,
				DecelerationRatio = DecelerationRatio
			};
			animationTimeline.SetValue(reflectedFromProperty, animationState == AnimationState.Collapsed ? FinalState : CollapsedState);
			animationTimeline.SetValue(reflectedToProperty, animationState == AnimationState.Collapsed ? CollapsedState : FinalState);

			AnimationTarget.BeginAnimation(AnimationProperty, animationTimeline);
		}
	}
}