using System;
using System.Windows;
using System.Windows.Controls;

namespace FlexCharts.Controls.Core
{
	public class FlexControl : Control
	{
		protected T GetTemplateChild<T>(string name) where T : DependencyObject
		{
			var templateChild = GetTemplateChild(name) as T;
			if (templateChild == null)
				throw new NullReferenceException($"TemplateChild {name} as {typeof(T)}");
			return templateChild;
		}
	}
}
