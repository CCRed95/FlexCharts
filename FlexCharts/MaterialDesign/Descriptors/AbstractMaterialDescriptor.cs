using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Markup.TypeConverters;

namespace FlexCharts.MaterialDesign.Descriptors
{
	[TypeConverter(typeof(DescriptorConverter))]
	public abstract class AbstractMaterialDescriptor
	{
		public double Opacity { get; set; } = 1.0;
		public abstract Material GetMaterial(MaterialSet materialSet);
	}
}
