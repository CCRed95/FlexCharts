using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.Require;
using Material.Controls.Popups;

namespace Material.Controls
{
	public class PopupManager : ContentControl
	{
		public static readonly RoutedEvent PopupAddedEvent = EM.Register<PopupManager, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler PopupAdded
		{
			add { AddHandler(PopupAddedEvent, value); }
			remove { RemoveHandler(PopupAddedEvent, value); }
		}

		static PopupManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupManager), new FrameworkPropertyMetadata(typeof(PopupManager)));
			EventManager.RegisterClassHandler(typeof(PopupManager), PopupBase.PopupRequestCloseEvent, new RoutedEventHandler(LocalOnPopupRequestClose));
		}

		protected override void OnContentChanged(object oldContent, object newContent)
		{
			base.OnContentChanged(oldContent, newContent);
			RaiseEvent(new RoutedEventArgs(PopupAddedEvent));

		}

		public static void LocalOnPopupRequestClose(object i, RoutedEventArgs e)
		{
			var popupManager = i.RequireType<PopupManager>();
			popupManager.Content = null;
		}
	}
}
