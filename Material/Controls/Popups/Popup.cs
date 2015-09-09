using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.Popups
{
	public class Popup : FlexControl
	{
		public static readonly RoutedEvent PopupRequestCloseEvent = EM.Register<Popup, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler PopupRequestClose
		{
			add { AddHandler(PopupRequestCloseEvent, value); }
			remove { RemoveHandler(PopupRequestCloseEvent, value); }
		}


	}
}
