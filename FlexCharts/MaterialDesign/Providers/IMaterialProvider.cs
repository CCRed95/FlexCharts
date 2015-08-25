using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign.Providers
{
	public interface IMaterialProvider
	{
		MaterialSet ProvideNext(ProviderContext context);
		void Reset(ProviderContext context);
	}
}
