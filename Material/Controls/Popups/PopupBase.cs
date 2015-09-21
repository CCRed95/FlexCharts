using System.Windows;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.Popups
{
	public class PopupBase : FlexControl
	{
		public static readonly RoutedEvent PopupRequestCloseEvent = EM.Register<PopupBase, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler PopupRequestClose
		{
			add { AddHandler(PopupRequestCloseEvent, value); }
			remove { RemoveHandler(PopupRequestCloseEvent, value); }
		}

		public PopupBase()
		{
			Loaded += (s, e) => Focus();
		}

	}
}
