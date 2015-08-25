using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign.Providers
{
	public class ProviderContext
	{
		public int CycleLength { get; }

		public ProviderContext(int cycleLength)
		{
			CycleLength = cycleLength;
		}
		public static ProviderContext Default => new ProviderContext(0);
	}
}
