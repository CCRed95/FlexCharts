using System.Windows;
using System.Windows.Shapes;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primitives
{
	public abstract class FocusableSegmentPrimitive : FlexPrimitive, IFocusableSegmentContract
	{
		public static readonly DependencyProperty FocusedSegmentProperty =
			DP.Attach<Shape>(typeof (FocusableSegmentPrimitive), new FrameworkPropertyMetadata());

		public static Shape GetFocusedSegment(DependencyObject i) => i.Get<Shape>(FocusedSegmentProperty);
		public static void SetFocusedSegment(DependencyObject i, Shape v) => i.Set(FocusedSegmentProperty, v);

		public Shape FocusedSegment
		{
			get { return (Shape) GetValue(FocusedSegmentProperty); }
			set { SetValue(FocusedSegmentProperty, value); }
		}
	}
}
