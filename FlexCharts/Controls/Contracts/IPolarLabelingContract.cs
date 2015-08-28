using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Controls.Contracts
{
	public interface IPolarLabelingContract
	{
		double HorizontalLabelPositionSkew { get; set; }
		double OuterLabelPositionScale { get; set; }
	}
}
