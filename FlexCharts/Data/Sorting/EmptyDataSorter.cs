using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Sorting
{
	public class EmptyDataSorter<T> : AbstractDataSorter<T>
	{
		public override T Sort(T dataSet) => dataSet;
	}
}
