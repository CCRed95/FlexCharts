using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlexCharts.Documents;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.TabSelector
{
	public class TabSelectorItem : Button
	{
		public static readonly DependencyProperty IsSelectedProperty = DP.Register(
			new Meta<TabSelectorItem, bool>());
		public bool IsSelected
		{
			get { return (bool) GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value); }
		}
		public static readonly RoutedEvent TabSelectedEvent = EM.Register<TabSelectorItem, RoutedEventHandler>(EM.BUBBLE);
		public event RoutedEventHandler TabSelected
		{
			add { AddHandler(TabSelectedEvent, value); }
			remove { RemoveHandler(TabSelectedEvent, value); }
		}
		public FlexDocumentTab DocumentTab { get; }
		static TabSelectorItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (TabSelectorItem),
				new FrameworkPropertyMetadata(typeof (TabSelectorItem)));
		}

		public TabSelectorItem(FlexDocumentTab tab)
		{
			DocumentTab = tab;
			Content = DocumentTab.Title;
		}

		protected override void OnClick()
		{
			base.OnClick();
			IsSelected = true;
			if (IsEnabled)
			{
				RaiseEvent(new RoutedEventArgs(TabSelectedEvent));
				//DocumentTab.RequestViewTab();
			}
				
		}
	}

}
