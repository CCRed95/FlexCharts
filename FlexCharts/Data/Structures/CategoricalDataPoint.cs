using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Data.Structures
{
	public abstract class CategoricalDataPoint<T> : DependencyObject
	{
		
		public static readonly DependencyProperty ValueProperty = DP.Register(
			new Meta<CategoricalDataPoint<T>, T>());
		public static readonly DependencyProperty CategoryNameProperty = DP.Register(
			new Meta<CategoricalDataPoint<T>, string>());

		public T Value
		{
			get { return (T)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}
		public string CategoryName
		{
			get { return (string)GetValue(CategoryNameProperty); }
			set { SetValue(CategoryNameProperty, value); }
		}
		//TODO By Friday get rid of this. everything should use visualcontexts
		public object RenderedVisual { get; set; }
	}
}
