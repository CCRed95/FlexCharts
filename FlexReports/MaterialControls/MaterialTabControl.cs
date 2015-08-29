using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Require;

namespace FlexReports.MaterialControls
{
	public class MaterialTabControl : ItemsControl
	{
		public static readonly DependencyProperty TabItemsProperty = DP.Register(
			new Meta<MaterialTabControl, ObservableCollection<MaterialTabItem>>(null,
				ChangedCallback, AutoSubscriber));
		public ObservableCollection<MaterialTabItem> TabItems
		{
			get { return (ObservableCollection<MaterialTabItem>)GetValue(TabItemsProperty); }
			set { SetValue(TabItemsProperty, value); }
		}

		private static void ChangedCallback(MaterialTabControl i, DPChangedEventArgs<ObservableCollection<MaterialTabItem>> e)
		{
			foreach (var tab in e.NewValue)
			{
				tab.ClickEvent += i.TabClicked;
			}
		}

		private static ObservableCollection<MaterialTabItem> AutoSubscriber(MaterialTabControl i, ObservableCollection<MaterialTabItem> b)
		{
			b.CollectionChanged += i.TabCollectionChanged;
			return b;
		}

		private void TabClicked(MaterialTabItem s)
		{
			foreach (var tab in TabItems)
			{
				if (!Equals(s, tab))
				{
					tab.IsSelected = false;
				}
			}
			s.FlexTabItem.RequestSelect();
			RaiseTabChangeRequestedEvent(s);
		}
		
		public event TabChangeRequestedHandler TabChangeRequestedEvent;
		public delegate void TabChangeRequestedHandler(MaterialTabControl i, MaterialTabItem tab);
		public void RaiseTabChangeRequestedEvent(MaterialTabItem tab)
		{
			TabChangeRequestedEvent?.Invoke(this, tab);
		}


		private void TabCollectionChanged(object s, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems == null)
				return;
			foreach (var i in e.NewItems)
			{
				i.RequireType<MaterialTabItem>().ClickEvent += TabClicked;
			}
		}

		static MaterialTabControl()
		{

		}
		public MaterialTabControl()
		{
			TabItems = new ObservableCollection<MaterialTabItem>();
			ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(UniformGrid)));
			BindingOperations.SetBinding(this, ItemsSourceProperty, new Binding("TabItems") { Source = this });
			Loaded += OnLoad;
		}

		private void OnLoad(object Sender, RoutedEventArgs Args)
		{
			DependencyObject dependencyObject = this;
			while (dependencyObject.GetType() != typeof(UniformGrid))
			{
				dependencyObject = VisualTreeHelper.GetChild(dependencyObject, 0);
			}
			BindingOperations.SetBinding(dependencyObject, UniformGrid.ColumnsProperty, new Binding("TabItems.Count") { Source = this });
		}
	}
}
