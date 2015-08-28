using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primatives
{
	public abstract class FocusableSegmentPrimative : FlexPrimative, IFocusableSegmentContract
	{
		public static readonly DependencyProperty FocusedSegmentProperty =
			DP.Attach<Shape>(typeof (FocusableSegmentPrimative), new FrameworkPropertyMetadata());

		public static Shape GetFocusedSegment(DependencyObject i) => i.Get<Shape>(FocusedSegmentProperty);
		public static void SetFocusedSegment(DependencyObject i, Shape v) => i.Set(FocusedSegmentProperty, v);

		public Shape FocusedSegment
		{
			get { return (Shape) GetValue(FocusedSegmentProperty); }
			set { SetValue(FocusedSegmentProperty, value); }
		}
	}
}
