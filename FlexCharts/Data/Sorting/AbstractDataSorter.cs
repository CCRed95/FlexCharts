using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Sorting
{
	public abstract class AbstractDataSorter<T>
	{
		public abstract T Sort(T dataSet);
	}
}
