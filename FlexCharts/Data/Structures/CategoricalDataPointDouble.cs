using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Structures
{
	public class CategoricalDataPointDouble : CategoricalDataPoint<double>
	{
		public CategoricalDataPointDouble() { }

		public CategoricalDataPointDouble(string categoryName, double value)
		{
			CategoryName = categoryName;
			Value = value;
		}
	}
}

