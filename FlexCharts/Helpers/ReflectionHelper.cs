using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlexCharts.Helpers
{
	public static class ReflectionHelper
	{
		public static DependencyProperty GetDependencyProperty(string name, DependencyObject parent, bool caseSensitive = false)
		{
			const string prop = "Property";
			var propertyName = name;
			if (!propertyName.ToLower().EndsWith(prop.ToLower()))
			{
				propertyName += prop;
			}
			var fieldInfoArray = parent.GetType().GetFields();
			foreach (var fieldInfo in fieldInfoArray)
			{
				if (caseSensitive)
				{
					if (fieldInfo.Name != propertyName) continue;
					var dependencyPropertyField = (DependencyProperty)fieldInfo.GetValue(parent);
					return dependencyPropertyField;
				}
				else
				{
					if (!string.Equals(fieldInfo.Name, propertyName, StringComparison.CurrentCultureIgnoreCase)) continue;
					var dependencyPropertyField = (DependencyProperty)fieldInfo.GetValue(parent);
					return dependencyPropertyField;
				}
			}
			throw new Exception("FSR.Reflection.CannotFindDependencyProperty(parent, name, caseSensitive)");
		}

		public static DependencyProperty GetDependencyProperty(string name, Type parent, bool caseSensitive = false)
		{
			const string prop = "Property";
			var propertyName = name;
			if (!propertyName.ToLower().EndsWith(prop.ToLower()))
			{
				propertyName += prop;
			}
			var fieldInfoArray = parent.GetFields();
			foreach (var fieldInfo in fieldInfoArray)
			{
				if (caseSensitive)
				{
					if (fieldInfo.Name != propertyName) continue;
					var dependencyPropertyField = (DependencyProperty)fieldInfo.GetValue(null);
					return dependencyPropertyField;
				}
				else
				{
					if (!string.Equals(fieldInfo.Name, propertyName, StringComparison.CurrentCultureIgnoreCase)) continue;
					var dependencyPropertyField = (DependencyProperty)fieldInfo.GetValue(null);
					return dependencyPropertyField;
				}
			}
			throw new Exception("FSR.Reflection.CannotFindDependencyProperty(null, name, caseSensitive)");
		}


		public static FieldInfo GetFieldInfoByName(FieldInfo[] fieldArray, string name, bool caseSensitive = false)
		{
			foreach (var field in fieldArray)
			{
				if (caseSensitive)
				{
					if (field.Name == name) return field;
				}
				else
				{
					if (string.Equals(field.Name, name, StringComparison.CurrentCultureIgnoreCase)) return field;
				}
			}
			throw new Exception("FSR.Reflection.CannotFindFieldInfoWithName(name, caseSensitive)");
		}

		public static bool TryGetObjectFromRuntimeField(FieldInfo runtimeFieldInfo, DependencyObject parent, out DependencyObject runtimeObject)
		{
			try
			{
				var runtimeFieldValue = runtimeFieldInfo.GetValue(parent);
				runtimeObject = (DependencyObject)runtimeFieldValue;
				return true;
			}
			catch
			{
				runtimeObject = default(DependencyObject);
				return false;
			}
		}
	}
}
