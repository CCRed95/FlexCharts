using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Data.Structures
{
	//TODO used to be FlexList
	public class CategoricalDataPointDoubleListList : List<CategoricalDataPointCategoricalDataPointDoubleList>
	{
		public CategoricalDataPointCategoricalDataPointDoubleList MaxSubcategoryMax()
		{
			if (Count < 1)
				return null;

			var max = this[0];
			foreach (var i in this)
			{
				if (i.Value.CategoryMax().Value > max.Value.CategoryMax().Value)
				{
					max = i;
				}
			}
			return max;
		}
		public double MaxSubcategoryTotal()
		{
			if (Count < 1)
				return 0;

			var max = this[0].Value.CategoryTotal();
			foreach (var i in this)
			{
				var sct = i.Value.CategoryTotal();
				if (sct > max)
				{
					max = sct;
				}
			}
			return max;
		}
	}
}
