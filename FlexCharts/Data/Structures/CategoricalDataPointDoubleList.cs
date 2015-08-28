using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Structures
{
	public class CategoricalDataPointDoubleList : List<CategoricalDataPointDouble> // TODO used to be flexlist.
	{
		public CategoricalDataPointDouble CategoryMax()
		{
			if (Count < 1)
				return null;

			var max = this[0];
			foreach (var i in this)
			{
				if (i.Value > max.Value)
				{
					max = i;
				}
			}
			return max;
		}
		public double CategoryTotal()
		{
			if (Count < 1)
				return 0;

			var total = 0d;
			foreach (var i in this)
			{
				total += i.Value;
			}
			return total;
		}

		
	}
}