using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Controls.Primatives
{
	public abstract class RingPrimative : FlexPrimative, IRingContract
	{
		//TODO ringWidthPercentage
		public static readonly DependencyProperty RingWidthPercentageProperty =
			DP.Attach<double>(typeof (RingPrimative), new FrameworkPropertyMetadata(.3));

		public static double GetRingWidthPercentage(DependencyObject i) => i.Get<double>(RingWidthPercentageProperty);
		public static void SetRingWidthPercentage(DependencyObject i, double v) => i.Set(RingWidthPercentageProperty, v);

		public double RingWidthPercentage
		{
			get { return (double) GetValue(RingWidthPercentageProperty); }
			set { SetValue(RingWidthPercentageProperty, value); }
		}
	}
}
