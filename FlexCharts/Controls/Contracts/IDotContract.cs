using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Contracts
{
	public interface IDotContract
	{
		double DotRadius { get; set; }
		AbstractMaterialDescriptor DotFill { get; set; }
		AbstractMaterialDescriptor DotStroke { get; set; }
		double DotStrokeThickness { get; set; }
	}
}
