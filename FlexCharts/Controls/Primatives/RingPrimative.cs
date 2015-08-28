using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primatives
{
	public interface IRingContract
	{
		double RingWidth { get; set; }
	}
	public abstract class RingPrimative : FlexPrimative, IRingContract
	{
		//TODO ringWidthPercentage
		public static readonly DependencyProperty RingWidthProperty =
			DP.Attach<double>(typeof (RingPrimative), new FrameworkPropertyMetadata(40.0));

		public static double GetRingWidth(DependencyObject i) => i.Get<double>(RingWidthProperty);
		public static void SetRingWidth(DependencyObject i, double v) => i.Set(RingWidthProperty, v);

		public double RingWidth
		{
			get { return (double) GetValue(RingWidthProperty); }
			set { SetValue(RingWidthProperty, value); }
		}
	}
}
