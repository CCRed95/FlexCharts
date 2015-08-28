using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Data.Structures;

namespace FlexCharts.Data.Sorting
{
public class AscendingDataSorter : AbstractDataSorter<DoubleSeries>
	{
		public override DoubleSeries Sort(DoubleSeries dataSet)
		{
			var s = dataSet.OrderBy(x => x.Value);
			var sorted = new DoubleSeries();
			foreach (var i in s)
			{
				sorted.Add(i);
			}
			return sorted;
		}
	}
}
