using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Data.Structures;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.CustomGeometry
{
	public abstract class GraphElementGeometry : DependencyObject
	{
		public static readonly DependencyProperty DataSourceProperty = DP.Register(
			new Meta<GraphElementGeometry, CategoricalDouble>());
		public CategoricalDouble DataSource
		{
			get { return (CategoricalDouble)GetValue(DataSourceProperty); }
			set { SetValue(DataSourceProperty, value); }
		}

		protected GraphElementGeometry(CategoricalDouble dataSource)
		{
			DataSource = dataSource;
		}

		public virtual CustomPath CalculatePath() => new CustomPath(null);
	}
}
