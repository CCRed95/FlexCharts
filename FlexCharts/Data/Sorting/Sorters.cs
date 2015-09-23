using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Sorting
{
	public static class Sorters
	{
		public static AscendingDataSorter Ascending = new AscendingDataSorter();
		public static DescendingDataSorter Descending = new DescendingDataSorter();
	}
}
