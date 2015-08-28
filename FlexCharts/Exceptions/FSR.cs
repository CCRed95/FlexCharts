using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FlexCharts.Exceptions
{
	public partial class FSR
	{
		public static class Conversion
		{
			public static string CannotConvert(object value, Type targetType)
				=> $"Cannot convert {value.GetType()} object \"{value}\" to Type {targetType}.";

			public static string CannotDirectCast(object value, Type targetType)
				=> $"Cannot direct cast {value.GetType()} object \"{value}\" to Type {targetType}.";
		}

		public static class DP
		{
			public static string AutoCallerNameNotAssigned()
				=> $"The DependencyProperty field name param AutoFieldName was not automatically assigned.";

			public static string AutoCallerNameNotValid(string name)
				=> $"The DependencyProperty field name param AutoFieldName \"{name}\" is not valid. The caller name must be in -property naming convension.";
		}

		public static class Reflection
		{
			public static string CannotFindDependencyProperty(DependencyObject parent, string name, bool caseSensitive)
				=> $"Cannot find DependencyProperty field {name} in the parent object {parent} with case sensitivity = {caseSensitive}.";

			public static string CannotFindFieldInfoWithName(string name, bool caseSensitive)
				=> $"Cannot find Field Info with Name \"{name}\" in the FieldInfo array with case sensitivity = {caseSensitive}.";

			public static string PropertyNotAssignable(DependencyProperty property, Type type)
				=> $"The type {type} is not assignable to dependencyProperty property {property}.";
		}

		public static class Collections
		{
			public static string InvalidCast(object value, Type type)
				=> $"Cannot cast object {value} to type {type}.";

			public static string CannotAddToReadOnly(object value)
				=> $"Cannot add object {value} to collection as it is read only.";

			public static string CannotInsertIntoReadOnly(object value)
				=> $"Cannot insert object {value} into collection as it is read only.";

			public static string CannotRemoveFromReadOnly(object value)
				=> $"Cannot remove object {value} from collection as it is read only.";

			public static string CannotRemoveAtFromReadOnly(int index)
				=> $"Cannot remove object at index {index} from collection as it is read only.";

			public static string CannotRemoveNotFound(object value)
				=> $"Cannot remove object {value} from collection as it cannot be found.";

			public static string IndexOutOfRange(int index)
				=> $"The index {index} is outside the bounds of the collection.";
		}
	}
}
