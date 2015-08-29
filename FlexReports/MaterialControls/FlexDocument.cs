using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Require;

namespace FlexReports.MaterialControls
{
	public class FlexDocument : ContentControl
	{
		public static readonly DependencyProperty TabsProperty = DP.Register(
			new Meta<FlexDocument, ObservableCollection<FlexTabItem>>(null,
				TabsChanged, TabsCoerce));
		public ObservableCollection<FlexTabItem> Tabs
		{
			get { return (ObservableCollection<FlexTabItem>) GetValue(TabsProperty); }
			set { SetValue(TabsProperty, value); }
		}

		private static ObservableCollection<FlexTabItem> TabsCoerce(FlexDocument i, ObservableCollection<FlexTabItem> b)
		{
			foreach (var s in b)
			{
				s.SelectRequestedEvent += i.TabSelectRequestedEvent;
			}
			b.CollectionChanged += i.TabCollectionChanged;
			return b;
		}

		private void TabSelectRequestedEvent(FlexTabItem FlexTabItem)
		{
			Content = FlexTabItem;
		}

		private static void TabsChanged(FlexDocument i, DPChangedEventArgs<ObservableCollection<FlexTabItem>> e)
		{
			if (e.NewValue?.Count > 0)
			{
				i.Content = e.NewValue[0];
			}
		}

		public FlexDocument()
		{
			Tabs = new ObservableCollection<FlexTabItem>();
		}

		private void TabCollectionChanged(object s, NotifyCollectionChangedEventArgs e)
		{
			if (Tabs?.Count > 0)
			{
				Content = Tabs[0];
			}
			foreach (var x in e.NewItems)
			{
				x.RequireType<FlexTabItem>().SelectRequestedEvent += TabSelectRequestedEvent;
			}
		}
	}
}