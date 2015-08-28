using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Extensions;

namespace FlexCharts.MaterialDesign.Providers
{
	public class GradientMaterialProvider : IMaterialProvider
	{
		private int currentIndex;

		public List<GradientMaterialStop> GradientStepData { get; }
		public void Reset()
		{
			currentIndex = 0;
		}

		public void Reset(ProviderContext context)
		{
			currentIndex = 0;
		}

		public GradientMaterialProvider(List<GradientMaterialStop> gradientStepData)
		{
			GradientStepData = gradientStepData;
		}

		public MaterialSet ProvideNext(ProviderContext context)
		{

			if (currentIndex > context.CycleLength) currentIndex = 0;

			var position = 1.0 / context.CycleLength * currentIndex;
			var gradientStepSpan = GradientStepData.Sum(step => step.Offset);
			var additivestepPercentage = 0d;
			MaterialSet interpolatedMaterialSet = MaterialPalette.Sets.BrownBrushSet;
			if (position >= 1)
			{
				currentIndex++;
				return GradientStepData.Last().MaterialSet;
			}
			for (var x = 0; x <= GradientStepData.Count - 2; x++)
			{
				var stepPercentage = GradientStepData[x].Offset / gradientStepSpan;
				var stepProgression = position - additivestepPercentage;
				var stepProgressionPercentage = stepProgression / stepPercentage;

				if (position >= additivestepPercentage && position < (additivestepPercentage + stepPercentage))
				{
					interpolatedMaterialSet = MediaExtensions.Interpolate(GradientStepData[x].MaterialSet,
						GradientStepData[x + 1].MaterialSet, stepProgressionPercentage);
					break;
				}
				additivestepPercentage += stepPercentage;
			}
			currentIndex++;
			return interpolatedMaterialSet;
		}

		public static GradientMaterialProvider MaterialRYG => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(MaterialPalette.Sets.RedBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.YellowBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.GreenBrushSet, 0)
			});
		public static GradientMaterialProvider MaterialHLbB => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(MaterialPalette.Sets.PinkBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.PurpleBrushSet ),
				new GradientMaterialStop(MaterialPalette.Sets.DeepPurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.BlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightBlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.TealBrushSet, 0),
			});
		public static GradientMaterialProvider RainbowPaletteOrder => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(MaterialPalette.Sets.RedBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.PinkBrushSet ),
				new GradientMaterialStop(MaterialPalette.Sets.PurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.DeepPurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.IndigoBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.BlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightBlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.CyanBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.TealBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.GreenBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightGreenBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LimeBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.YellowBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.AmberBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.OrangeBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.DeepOrangeBrushSet, 0)
			});
		public static GradientMaterialProvider RainbowRefractionOrder => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(MaterialPalette.Sets.RedBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.DeepOrangeBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.OrangeBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.AmberBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LimeBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.YellowBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightGreenBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.GreenBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.TealBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.CyanBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightBlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.BlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.IndigoBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.DeepPurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.PurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.PinkBrushSet, 0)
			});
		
		public static GradientMaterialProvider CoolColors => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(MaterialPalette.Sets.PurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.DeepPurpleBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.IndigoBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.BlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.LightBlueBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.CyanBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.TealBrushSet),
				new GradientMaterialStop(MaterialPalette.Sets.GreenBrushSet, 0),
			});

		//public static ComplexGradientBrushProvider MaterialPBDark => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Pink.Darken(.4)),
		//		new ComplexGradientStep(Material.Teal.Lighten(.05), 0)
		//	})
		//{ ProviderFunction = new DarkenBrushFunction { DarkenPercentage = 0 } };
		//public static ComplexGradientBrushProvider MaterialBPDark => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Blue.Darken(.2)),
		//		new ComplexGradientStep(Material.Pink, 0)
		//	})
		//{ ProviderFunction = new DarkenBrushFunction { DarkenPercentage = .1 } };
		//public static ComplexGradientBrushProvider MaterialGB => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Green),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Indigo, 0)
		//	})
		//{ ProviderFunction = new LightenBrushFunction { LightenPercentage = .3 } };
		//public static ComplexGradientBrushProvider MaterialBG => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.Green, 0)
		//	})
		//{ ProviderFunction = new LightenBrushFunction { LightenPercentage = .3 } };

		//public static ComplexGradientBrushProvider MaterialRainbow => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Red),
		//		new ComplexGradientStep(Material.DeepOrange),
		//		new ComplexGradientStep(Material.Orange),
		//		new ComplexGradientStep(Material.Amber),
		//		new ComplexGradientStep(Material.Yellow),
		//		new ComplexGradientStep(Material.Lime),
		//		new ComplexGradientStep(Material.LightGreen),
		//		new ComplexGradientStep(Material.Green),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.Cyan),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Blue),
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.DeepPurple),
		//		new ComplexGradientStep(Material.Purple),
		//		new ComplexGradientStep(Material.Pink),
		//		new ComplexGradientStep(Material.Red, 0)
		//	});
		//public static ComplexGradientBrushProvider MaterialCoolColors => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Blue),
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.DeepPurple),
		//		new ComplexGradientStep(Material.Purple),
		//		new ComplexGradientStep(Material.Pink.Darken(.15), 0)
		//	});
	}
}
