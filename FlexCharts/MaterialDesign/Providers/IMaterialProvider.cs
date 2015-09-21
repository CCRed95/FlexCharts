using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign.Providers
{
	public interface IMaterialProvider
	{
		MaterialSetOLD ProvideNext(ProviderContext context);
		void Reset(ProviderContext context);
	}
}
