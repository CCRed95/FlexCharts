using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexCharts.Documents
{
	public class FlexDocumentTab : Grid
	{
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<FlexDocumentTab, string>("Title"));
		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		//public static readonly RoutedEvent ViewTabRequestedEvent = EM.Register<FlexDocumentTab, RoutedEventHandler>(EM.BUBBLE);

		//public event RoutedEventHandler ViewTabRequested
		//{
		//	add { AddHandler(ViewTabRequestedEvent, value); }
		//	remove { RemoveHandler(ViewTabRequestedEvent, value); }
		//}

		//public void RequestViewTab()
		//{
		//	RaiseEvent(new RoutedEventArgs(ViewTabRequestedEvent));
		//}
	}
}
