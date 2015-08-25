using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FlexCharts.Collections;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;

namespace FlexCharts.Markup.TypeConverters
{
	public class MaterialConverter : TypeConverter
	{
		public Type TargetType => typeof (Material);

		protected virtual IComparer Comparer => FlexInvariantComparar.Default;

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (TargetType.IsAssignableFrom(sourceType) || TargetType == typeof(string))
				return true;
			return false;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof (InstanceDescriptor) || destinationType == typeof (Brush) ||
			    destinationType == typeof (Color) || destinationType == TargetType)
				return true;
			return false;
		}
		private BrushConverter bc = new BrushConverter();
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				throw new NotImplementedException();
				//return bc.ConvertFrom(context, culture, value)
			}
			catch
			{
				throw new Exception("convertfrom failed");
			}
		}
		
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
			Type destinationType)
		{
			try
			{
				destinationType.RequireNotNull();
				value.RequireNotNull();
				
				if (destinationType == typeof (Brush))
				{
					return value.RequireType<Material>().Brush;
				}
				if (destinationType == typeof (Color))
				{
					return value.RequireType<Material>().Color;
				}
				if (destinationType == typeof (string)) return value.ToString();
				if (destinationType == typeof (InstanceDescriptor))
				{
					var strValue = ConvertToInvariantString(context, value);
					var info = TargetType.GetField(strValue);
					if (info != null) return new InstanceDescriptor(info, null);
				}
				throw new Exception("convertto failed");
			}
			catch
			{
				throw new Exception("convertto failed unknown");
			}
		}

		//public override bool IsValid(ITypeDescriptorContext context, object value)
		//{
		//	try
		//	{
		//		return true;
		//	}
		//	catch
		//	{
		//		throw new Exception("isvalid failed");
		//	}

		//}
	}
}