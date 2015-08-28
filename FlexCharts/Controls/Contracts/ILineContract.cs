using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Contracts
{
	public interface ILineContract
	{
		AbstractMaterialDescriptor LineStroke { get; set; }
		double LineStrokeThickness { get; set; }
	}
}
