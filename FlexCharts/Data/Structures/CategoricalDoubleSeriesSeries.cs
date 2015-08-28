using System.Collections.Generic;
using System.Linq;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Collections;

namespace FlexCharts.Data.Structures
{
	public class CategoricalDoubleSeriesSeries : Series<CategoricalDoubleSeries>
	{
		public double MaxSubsetSum() => this.Max(x => x.Value.SumValue());
	}
}
