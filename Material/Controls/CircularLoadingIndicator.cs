using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Controls.Core;

namespace Material.Controls
{
	public class CircularLoadingIndicator : FlexControl
	{
		static CircularLoadingIndicator()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (CircularLoadingIndicator),
				new FrameworkPropertyMetadata(typeof (CircularLoadingIndicator)));
		}
	}
}
