using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign.Providers
{
	public class AlternatingMaterialProvider : IMaterialProvider
	{
		#region Properties
		public MaterialSetOLD MaterialSet1 { get; }

		public MaterialSetOLD MaterialSet2 { get; }
		#endregion

		#region Fields
		private int currentIndex;
		#endregion

		#region Constructors

		public AlternatingMaterialProvider(MaterialSetOLD materialSet1, MaterialSetOLD materialSet2)
		{
			MaterialSet1 = materialSet1;
			MaterialSet2 = materialSet2;
		}
		#endregion

		#region Methods
		public MaterialSetOLD ProvideNext(ProviderContext context)
		{
			var materialSet = currentIndex % 2 == 0 ? MaterialSet1 : MaterialSet2;
			currentIndex++;
			return materialSet;
		}

		public void Reset(ProviderContext context)
		{
			currentIndex = 0;
		}
		#endregion

		#region Static Sequences

		public static AlternatingMaterialProvider AltGP =
			new AlternatingMaterialProvider(MaterialPalette.Sets.GreenBrushSet, MaterialPalette.Sets.PinkBrushSet);

		#endregion
	}
}

