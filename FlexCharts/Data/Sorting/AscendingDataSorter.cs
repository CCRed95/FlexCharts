using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Data.Structures;

namespace FlexCharts.Data.Sorting
{
public class AscendingDataSorter : AbstractDataSorter<CategoricalDataPointDoubleList>
	{
		public override CategoricalDataPointDoubleList Sort(CategoricalDataPointDoubleList dataSet)
		{
			var s = dataSet.OrderBy(x => x.Value);
			var sorted = new CategoricalDataPointDoubleList();
			foreach (var i in s)
			{
				sorted.Add(i);
			}
			return sorted;
		}
	}
}
