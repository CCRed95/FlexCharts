using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.Extensions
{
	public static class InvocationExtensions
	{
		public static void TryInvoke<D, T>(this PropertyChange<D, T> i, DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) where D : DependencyObject
		{
			i?.Invoke((D)dependencyObject, new DPChangedEventArgs<T>(e));
		}
		public static object TryInvoke<D, T>(this PropertyCoerce<D, T> i, DependencyObject dependencyObject, object baseValue) where D : DependencyObject
		{
			if (i == null) return (T)baseValue;
			return i.Invoke((D)dependencyObject, (T)baseValue);
		}
		public static bool TryInvoke<T>(this PropertyValidate<T> i, object value)
		{
			return i == null || i.Invoke((T)value);
		}
	}
}
