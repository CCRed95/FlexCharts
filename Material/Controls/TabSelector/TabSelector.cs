using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FlexCharts.Controls.Core;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.TabSelector
{
	//TODO tabselector style 
	[TemplatePart(Name = "PART_activeindicator", Type = typeof(Border))]
	public class TabSelector : FlexControl
	{
		public static readonly DependencyProperty TabsProperty = DP.Register(
			new Meta<TabSelector, ObservableCollection<TabSelectorItem>>());
		public ObservableCollection<TabSelectorItem> Tabs
		{
			get { return (ObservableCollection<TabSelectorItem>)GetValue(TabsProperty); }
			set { SetValue(TabsProperty, value); }
		}
		public TabSelectorItem SelectedItem { get; private set; }


		public static readonly RoutedEvent TabSelectedEvent = EM.Register<TabSelector, RoutedEventHandler>(EM.BUBBLE);
		public event RoutedEventHandler TabSelected
		{
			add { AddHandler(TabSelectedEvent, value); }
			remove { RemoveHandler(TabSelectedEvent, value); }
		}
		private Border PART_activeindicator;

		static TabSelector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TabSelector),
				new FrameworkPropertyMetadata(typeof(TabSelector)));
		}

		public TabSelector()
		{
			Tabs = new ObservableCollection<TabSelectorItem>();
			EventManager.RegisterClassHandler(typeof(TabSelector), TabSelectorItem.TabSelectedEvent, new RoutedEventHandler(OnTabSelected));
		}

		private void OnTabSelected(object s, RoutedEventArgs e)
		{
			SelectedItem = (TabSelectorItem)e.OriginalSource;
			var tabStep = ActualWidth / Tabs.Count;
			var leftMargin = 0.0;
			var trace = 0;
			foreach (var t in Tabs)
			{
				if (Equals(t, e.OriginalSource))
				{
					leftMargin = trace * tabStep;
				}
				else
				{
					t.IsSelected = false;
				}
				trace++;
			}
			PART_activeindicator.BeginAnimation(WidthProperty, new DoubleAnimation(
				tabStep, new Duration(TimeSpan.FromMilliseconds(300)))
			{

			});
			PART_activeindicator.BeginAnimation(MarginProperty, new ThicknessAnimation(
				new Thickness(leftMargin, 0, 0, 0), new Duration(TimeSpan.FromMilliseconds(300)))
			{
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },

			});
			//SelectedItem.DocumentTab.RequestViewTab();
			RaiseEvent(new RoutedEventArgs(TabSelectedEvent, e.OriginalSource));
		}

		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			if (Tabs?.Count > 0)
			{
				var tabStep = ActualWidth / Tabs.Count;
				var leftMargin = 0.0;
				var trace = 0;
				foreach (var t in Tabs)
				{
					if (t.IsSelected)
						leftMargin = trace
							* tabStep;
					trace++;
				}
				PART_activeindicator.unregisterAnimation(WidthProperty);
				PART_activeindicator.Width = tabStep;
				PART_activeindicator.unregisterAnimation(MarginProperty);
				PART_activeindicator.Margin = new Thickness(leftMargin, 0, 0, 0);
			}
			base.OnRenderSizeChanged(sizeInfo);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_activeindicator = GetTemplateChild<Border>(nameof(PART_activeindicator));
		}
	}
}