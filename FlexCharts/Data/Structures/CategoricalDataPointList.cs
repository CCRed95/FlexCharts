using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.CustomGeometry;

namespace FlexCharts.Data.Structures
{
	public class CategoricalDataPointList : CategoricalDataPoint<List<CategoricalDataPointDouble>>
	{
		public List<CustomPath> RenderedPathList { get; set; }

		public CategoricalDataPointList() { }

		public CategoricalDataPointList(string categoryName, List<CategoricalDataPointDouble> value)
		{
			CategoryName = categoryName;
			Value = value;
		}
	}
}
