using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Structures;
using FlexCharts.MaterialDesign;

namespace FlexCharts.GenerationContext
{
	internal class NestedArcChartVisualContext : AbstractVisualContext
	{
		internal List<NestedArcCategoryVisualContext> CategoryVisuals = new List<NestedArcCategoryVisualContext>();
	}
	//TODO can these be grouped by function as 'aspects'?
	internal class NestedArcCategoryVisualContext
	{
		internal CategoricalDouble CategoryDataPoint { get; set; }

		internal MaterialSet CategoryMaterialSet { get; set; }

		internal CustomPath InactiveArcVisual { get; set; }

		internal CustomPath ActiveArcVisual { get; set; }

		internal Label CategoryLabel { get; set; }

		internal Label ValuePercentLabel { get; set; }

		internal Label ValueLabel { get; set; }
	}
}
