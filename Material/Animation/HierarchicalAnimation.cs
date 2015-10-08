using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.SqlServer.Server;

namespace Material.Animation
{
	public class HierarchicalAnimation : Behavior<ItemsControl>
	{
		public double From { get; set; }
		public double To { get; set; }
		public Duration Duration { get; set; }
		public TimeSpan BeginTime { get; set; }
		public TimeSpan OffsetTime { get; set; }
		public RoutedEvent RoutedEvent { get; set; }

		public DependencyProperty TargetProperty { get; set; }
		public string TargetName { get; set; }

		public HierarchicalAnimation() { }

		protected override void OnAttached()
		{
			AssociatedObject.AddHandler(RoutedEvent, new RoutedEventHandler(onRoutedEvent));
		}

		private void onRoutedEvent(object s, RoutedEventArgs e)
		{
			var currentOffset = TimeSpan.Zero;
			foreach (var i in AssociatedObject.Items)
			{
				var container = (ContentPresenter)AssociatedObject.ItemContainerGenerator.ContainerFromItem(i);
				var targetObject = container.ContentTemplate.FindName(TargetName, container) as Animatable;
				if (targetObject != null)
				{
					targetObject.BeginAnimation(TargetProperty,
						new DoubleAnimation(From, To, Duration)
						{
							BeginTime = currentOffset
						});
					currentOffset += OffsetTime;
				}
			}
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
		}
	}
}
