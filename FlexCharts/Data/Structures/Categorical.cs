using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Data.Structures
{
	public abstract class Categorical<T> : DependencyObject where T : new()
	{
		public static readonly DependencyProperty CategoryNameProperty = DP.Register(
			new Meta<Categorical<T>, string>());

		public static readonly DependencyProperty ValueProperty = DP.Register(
			new Meta<Categorical<T>, T>());

		public string CategoryName
		{
			get { return (string)GetValue(CategoryNameProperty); }
			set { SetValue(CategoryNameProperty, value); }
		}
		public T Value
		{
			get { return (T)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		protected Categorical()
		{
			Value = new T();
		} 

		protected Categorical(string categoryName, T value)
		{
			CategoryName = categoryName;
			Value = value;
		} 

		//TODO get rid of this. everything should use visualcontexts
		public object RenderedVisual { get; set; }
	}
}
