using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls
{
public class FlexTabItem : Grid
	{
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<FlexTabItem, string>("Tab Item"));
		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public void RequestSelect() => RaiseSelectRequestedEvent();

		public event SelectRequestedHandler SelectRequestedEvent;
		public delegate void SelectRequestedHandler(FlexTabItem i);

		private void RaiseSelectRequestedEvent()
		{
			SelectRequestedEvent?.Invoke(this);

		}
	}
}