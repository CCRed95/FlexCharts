using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using FlexCharts.Controls.Primitives;
using FlexCharts.Controls.Primitives.TextAttributes;

namespace FlexCharts.Extensions
{
	public static class BindingExtensions
	{
		public static void BindTextualPrimitive<T>(this DependencyObject target, DependencyObject source) where T : TextualPrimitive
		{
			var fontProperty = GetTextualProperty<T>(TextualRole.Font);
			var styleProperty = GetTextualProperty<T>(TextualRole.Style);
			var weightProperty = GetTextualProperty<T>(TextualRole.Weight);
			var sizeProperty = GetTextualProperty<T>(TextualRole.Size);
			var stetchProperty = GetTextualProperty<T>(TextualRole.Stretch);

			BindingOperations.SetBinding(target, TextElement.FontFamilyProperty, new Binding(fontProperty.Name) { Source = source });
			BindingOperations.SetBinding(target, TextElement.FontStyleProperty, new Binding(styleProperty.Name) { Source = source });
			BindingOperations.SetBinding(target, TextElement.FontWeightProperty, new Binding(weightProperty.Name) { Source = source });
			BindingOperations.SetBinding(target, TextElement.FontSizeProperty, new Binding(sizeProperty.Name) { Source = source });
			BindingOperations.SetBinding(target, TextElement.FontStretchProperty, new Binding(stetchProperty.Name) { Source = source });
		}

		public static DependencyProperty GetTextualProperty<T>(TextualRole role) where T : TextualPrimitive
		{
			var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
			foreach (var dependencyProperty in from field in fields let attributes = field.GetCustomAttributes()
																				 from attribute in attributes let dependencyProperty = field.GetValue(null) as DependencyProperty
																				 where dependencyProperty != null let textualRoleProperty = attribute as TextualRolePropertyAttribute
																				 where textualRoleProperty?.Role == role select dependencyProperty) {
				return dependencyProperty;
			}
			throw new Exception("cant find textualrole property");
		}
	}
}
