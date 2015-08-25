using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Collections
{
	public abstract class FlexEnum
	{
		protected object baseValue { get; }
		protected string autoFieldName { get; }
		protected int lineNumber { get; }
		protected static BindingFlags discoveryFlags => BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

		public string Name => autoFieldName;

		public static bool IsDefined(Type type, object value)
		{
			// TODO or isinstanceof(?
			if (!typeof(FlexEnum).IsAssignableFrom(type))
				throw new Exception($"Cannot check if isdefined in non-FlexEnum type {type} with val {value}.");

			if (value.GetType().IsInstanceOfType(type))
			{
				return true;
			}

			var name = value as string;
			if (name == null)
				return false;

			var discoveredFields = type.GetFields(discoveryFlags).Select(f => f.GetValue(null));
			return discoveredFields.OfType<FlexEnum>().Any(flexEnumValue => flexEnumValue.autoFieldName == name);
		}

		public static bool TryParse(Type type, string name, out FlexEnum flexEnum)
		{
			try
			{
				flexEnum = Parse(type, name);
				return true;
			}
			catch
			{
				flexEnum = default(FlexEnum);
				return false;
			}
		}

		public static FlexEnum Parse(Type type, string name, bool caseSensitive = true)
		{
			if (!typeof(FlexEnum).IsAssignableFrom(type))
				throw new Exception($"Cannot parse non-FlexEnum type {type} with string {name}.");
			var discoveredFields = type.GetFields(discoveryFlags).Select(f => f.GetValue(null));
			foreach (var flexEnumValue in discoveredFields.OfType<FlexEnum>())
			{
				if (!caseSensitive)
				{
					if (string.Equals(flexEnumValue.autoFieldName, name, StringComparison.CurrentCultureIgnoreCase))
					{
						return flexEnumValue;
					}
				}
				if (flexEnumValue.autoFieldName != name) continue;
				return flexEnumValue;
			}
			throw new Exception($"Cannot parse FlexEnum \"{name}\" in type {type}.");
		}

		protected FlexEnum(object value, string fieldName, int line)
		{
			baseValue = value;
			autoFieldName = fieldName;
			lineNumber = line;
		}

		public static IEnumerable<E> Enumerate<E>() where E : FlexEnum =>
			typeof(E).GetFields(discoveryFlags).Select(f => f.GetValue(null)).Cast<E>();

		//TODO Fix!! shouldnt be returning defaults if not found!
		public static E FromValue<E>(object value) where E : FlexEnum =>
			Enumerate<E>().FirstOrDefault(i => i.baseValue.Equals(value));

		public static E FromName<E>(string value) where E : FlexEnum =>
			Enumerate<E>().FirstOrDefault(i => i.autoFieldName.Equals(value));

		public int CompareTo(object obj) => Compare(autoFieldName, ((FlexEnum)obj).autoFieldName, StringComparison.Ordinal);

		public static bool operator >(FlexEnum left, FlexEnum right)
		{
			return left.lineNumber > right.lineNumber;
		}

		public static bool operator <(FlexEnum left, FlexEnum right)
		{
			return left.lineNumber < right.lineNumber;
		}
	}
	public abstract class FlexEnum<T> : FlexEnum, IComparable
	{
		public T Value { get; }

		protected FlexEnum(T value, string fieldName, int line) : base(value, fieldName, line)
		{
			Value = value;
		}

		public override string ToString() => autoFieldName;

		public override bool Equals(object obj)
		{
			var enumeration = obj as FlexEnum<T>;
			if (enumeration == null) return false;
			return GetType() == obj.GetType() && Value.Equals(enumeration.Value);
		}

		public override int GetHashCode() => autoFieldName.GetHashCode();
	}
}
