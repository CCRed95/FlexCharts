using System;
using System.Collections.Generic;
using System.Windows.Markup;
using FlexCharts.CustomGeometry;

namespace FlexCharts.Data.Structures
{
	[ContentProperty("Value")]
	public class CategoricalDoubleSeries : Categorical<DoubleSeries>
	{
		public List<CustomPath> RenderedPathList { get; set; }

		public CategoricalDoubleSeries() { }

		public CategoricalDoubleSeries(string categoryName, DoubleSeries value) : 
			base(categoryName, value) { }
	}
}
 