using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.Require;

namespace FlexCharts.Markup.TypeConverters
{ 
	public class DescriptorConverter : TypeConverter
	{
		public Type TargetType => typeof(AbstractMaterialDescriptor);


		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string) || TargetType.IsAssignableFrom(sourceType))
				return true;
			return false;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) || destinationType == TargetType)
				return true;
			return false;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				var strVal = value.RequireType<string>().Trim();

				if (strVal.StartsWith("->"))
				{
					var postString = strVal.Substring(2);
					var materialString = postString;
					var opacity = 1.0;
					if (postString.Contains(','))
					{
						var seperatorIndex = postString.IndexOf(','); // postString.Length - 
						materialString = postString.Substring(0, seperatorIndex);
						var opacitystr = postString.Substring(seperatorIndex + 1);
						opacity = Convert.ToDouble(opacitystr);
					}
					var fields = typeof(MaterialPalette).GetFields(BindingFlags.Public | BindingFlags.Static);

					var parsedMaterial = MaterialPalette.Black000;
					foreach (var field in fields.Where(field => field.Name == materialString))
					{
						parsedMaterial = field.GetValue(null).RequireType<Material>();
					}
					return new LiteralMaterialDescriptor(parsedMaterial, opacity);
					//var materialString = ;
					
				}
				else
				{
					var luminosityStr = strVal.Substring(0, 4);
					var lum = Luminosity.Parse(luminosityStr);

					var opacity = strVal.Substring(4);
					if (!opacity.StartsWith("O"))
						return new LuminosityMaterialDescriptor(lum);
					var ostr = opacity.Substring(1);
					var oval = Convert.ToInt32(ostr);
					return new LuminosityMaterialDescriptor(lum, ((double)oval) / 100);
				}
			}
			catch
			{
				throw new Exception("convertfrom failed");
			}
		}


		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			try
			{
				//{
				//	destinationType.ShouldNotBeNull();
				//	value.ShouldNotBeNull();
				//	var strValue = ConvertToInvariantString(context, value);
				//	if (destinationType == typeof(string)) return value.ToString();
				//	if (destinationType == typeof(InstanceDescriptor))
				//	{
				//		var info = TargetType.GetField(strValue);
				//		if (info != null) return new InstanceDescriptor(info, null);
				//	}
				//	if (destinationType == TargetType)
				//		return FlexEnum.Parse(TargetType, strValue);
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
		//		return FlexEnum.IsDefined(TargetType, value);
		//	}
		//	catch
		//	{
		//		throw new Exception("isvalid failed");
		//	}

		//}
	}
}
