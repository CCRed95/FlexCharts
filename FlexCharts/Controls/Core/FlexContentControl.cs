using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.EventHelpers;

namespace FlexCharts.Controls.Core
{
	public class FlexContentControl : ContentControl
	{
		public static readonly RoutedEvent ContentChangedEvent = EM.Register<FlexContentControl, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler ContentChanged
		{
			add { AddHandler(ContentChangedEvent, value); }
			remove { RemoveHandler(ContentChangedEvent, value); }
		}
		protected override void OnContentChanged(object oldContent, object newContent)
		{
			base.OnContentChanged(oldContent, newContent);
			RaiseEvent(new RoutedEventArgs(ContentChangedEvent));
		}
	}
}
