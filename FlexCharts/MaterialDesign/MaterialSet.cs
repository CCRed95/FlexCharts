using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign
{
	public class MaterialSet
	{
		public ReadOnlyCollection<Material> Materials { get; }
		
		public Material GetMaterial(Luminosity i)
		{
			foreach (var m in Materials.Where(m => m.Luminosity == i))
			{
				return m;
			}
			throw new Exception($"Material with luminosity {i} cannot be found in this MaterialSet.");
		}
		public Material GetMaterialWithOpacity(Luminosity i, double opacity)
		{
			var material = GetMaterial(i);
			return material.WithOpacity(opacity);
		}

		public MaterialSet(ReadOnlyCollection<Material> materials)
		{
			Materials = materials;
		}
		public MaterialSet(params Material[] materials)
		{
			Materials = new ReadOnlyCollection<Material>(materials.ToList());
		}
	}
}
