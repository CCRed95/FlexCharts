using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Contracts
{
	public interface IStateSegmentContract
	{
		AbstractMaterialDescriptor ActiveFill { get; set; }
		int ActiveStrokeThickness { get; set; }
		AbstractMaterialDescriptor ActiveStroke { get; set; }
		AbstractMaterialDescriptor InactiveFill { get; set; }
		int InactiveStrokeThickness { get; set; }
		AbstractMaterialDescriptor InactiveStroke { get; set; }
	}
}
