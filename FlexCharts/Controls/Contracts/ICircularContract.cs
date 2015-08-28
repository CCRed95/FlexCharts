using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Controls.Contracts
{
	public interface ICircularContract
	{
		double CircleScale { get; set; }
		double AngleOffset { get; set; }
	}
}
