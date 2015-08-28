using System.Collections.Generic;
using System.Linq;
using FlexCharts.Data.Collections;

namespace FlexCharts.Data.Structures
{
	public class DoubleSeries : Series<CategoricalDouble>
	{
		public double MaxValue() => this.Max(x => x.Value);
		public double MinValue() => this.Min(x => x.Value);
		public double SumValue() => this.Sum(x => x.Value);
	}

	//	public CategoricalDouble CategoryMax()
		//	{
		//		if (Count < 1)
		//			return null;

		//		var max = this[0];
		//		foreach (var i in this)
		//		{
		//			if (i.Value > max.Value)
		//			{
		//				max = i;
		//			}
		//		}
		//		return max;
		//	}
		//	public double CategoryTotal()
		//	{
		//		if (Count < 1)
		//			return 0;

		//		var total = 0d;
		//		foreach (var i in this)
		//		{
		//			total += i.Value;
		//		}
		//		return total;
		//	}


		//}
	}