using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace FlexCharts.GenerationContext
{
	internal class HorizontalBarChartVisualContext
	{
		internal List<HorizontalBarChartSegmentVisualContext> BarVisuals { get; set; } = new List<HorizontalBarChartSegmentVisualContext>();
	}
	internal class HorizontalBarChartSegmentVisualContext
	{
		internal Rectangle InactiveBar { get; set; }
		internal Rectangle ActiveBar { get; set; }
		internal Label BarLabel { get; set; }
		internal Label YAxisLabel { get; set; }
	}
}
