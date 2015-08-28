using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Data.Structures;

namespace FlexCharts.Extensions
{
	public static class ChartingExtensions
	{
		//public static double ValueSum(this IEnumerable<CategoricalDataPoint<double>> i)
		//{
		//	return i.Sum(x => x.Value);
		//}
		//public static double ValueMax(this IEnumerable<CategoricalDataPoint<double>> i)
		//{
		//	return i.Max(x => x.Value);
		//}
		//public static double ValueMin(this IEnumerable<CategoricalDataPoint<double>> i)
		//{
		//	return i.Min(x => x.Value);
		//}
		//public static CategoricalDataPoint<double> Max(this IEnumerable<CategoricalDataPoint<double>> i, out int index)
		//{
		//	var categoricalDataPoints = i as CategoricalDataPoint<double>[] ?? i.ToArray();
		//	if (!categoricalDataPoints.Any())
		//		throw new Exception("No elements in the IEnumerable<>.");
		//	var _index = 0;
		//	var _trace = 0;
		//	var max = categoricalDataPoints[0];
		//	foreach (var item in categoricalDataPoints)
		//	{
		//		if (item.Value > max.Value)
		//		{
		//			max = item;
		//			_index = _trace;
		//		}
		//		_trace++;
		//	}
		//	index = _index;
		//	return max;
		//}

		//public static double MaxSubsetSum(this List<CategoricalDoubleSeries> i)
		//{
		//	if (!i.Any())
		//		throw new Exception("No elements in the IEnumerable<>.");
		//	var subsetSumMax = i[0].SubsetSum();
		//	foreach (var dataSet in i)
		//	{
		//		var subsetSum = dataSet.SubsetSum();
		//		if (subsetSum > subsetSumMax)
		//		{
		//			subsetSumMax = subsetSum;
		//		}
		//	}
		//	return subsetSumMax;
		//}
		//public static double SubsetSum(this CategoricalDoubleSeries i)
		//{
		//	if (!i.Value.Any())
		//		throw new Exception("No elements in the IEnumerable<>.");
		//	return i.Value.Sum(dataPoint => dataPoint.Value);
		//}
		public static double Smallest(this Size i)
		{
			return i.Width < i.Height ? i.Width : i.Height;
		}
		public static Size SquareFit(this Size i)
		{
			return new Size(i.Smallest(), i.Smallest());
		}
	}
}
