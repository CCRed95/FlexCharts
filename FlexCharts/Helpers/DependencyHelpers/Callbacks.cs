using System.Windows;

namespace FlexCharts.Helpers.DependencyHelpers
{
	public delegate void PropertyChange<in D, T>(D i, DPChangedEventArgs<T> e)
		where D : DependencyObject;

	public delegate T PropertyCoerce<in D, T>(D i, T baseValue)
		where D : DependencyObject;

	public delegate bool PropertyValidate<in T>(T value);
}
