using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.MaterialDesign.Providers
{
	public class SequentialMaterialProvider : IMaterialProvider
	{
		#region Properties
		public ReadOnlyCollection<MaterialSetOLD> MaterialSetSequence { get; }

		public CyclicalBehavior CyclicalMode { get; }

		public bool Reverse { get; set; }
		#endregion

		#region Fields
		private MirrorDirection mirrorDirection = MirrorDirection.Forward;
		private int currentIndex;
		#endregion

		#region Constructors
		public SequentialMaterialProvider(params MaterialSetOLD[] materialSetSequence)
			: this(CyclicalBehavior.Repeat, materialSetSequence)
		{ }

		public SequentialMaterialProvider(IList<MaterialSetOLD> materialSetSequence)
			: this(CyclicalBehavior.Repeat, materialSetSequence)
		{ }

		public SequentialMaterialProvider(CyclicalBehavior mode = CyclicalBehavior.Repeat,
			params MaterialSetOLD[] materialSetSequence) : this(mode, materialSetSequence.ToList())
		{ }

		public SequentialMaterialProvider(CyclicalBehavior mode, IList<MaterialSetOLD> materialSetSequence)
		{
			MaterialSetSequence = new ReadOnlyCollection<MaterialSetOLD>(materialSetSequence);
			CyclicalMode = mode;
		}
		#endregion

		#region Methods
		public MaterialSetOLD ProvideNext(ProviderContext context)
		{
			switch (CyclicalMode)
			{
				case CyclicalBehavior.Repeat:
					{
						if (currentIndex > MaterialSetSequence.Count - 1)
							currentIndex = 0;
						if (currentIndex < 0)
							currentIndex = MaterialSetSequence.Count - 1;

						var currentSet = MaterialSetSequence[currentIndex];
						if (Reverse)
							currentIndex--;
						else
							currentIndex++;
						return currentSet;
					}
				case CyclicalBehavior.Mirror:
					{
						if (currentIndex > MaterialSetSequence.Count - 1)
						{
							currentIndex = MaterialSetSequence.Count - 2;
							mirrorDirection = MirrorDirection.Backward;
						}
						else if (currentIndex < 0)
						{
							currentIndex = 1;
							mirrorDirection = MirrorDirection.Forward;
						}
						var currentSet = MaterialSetSequence[currentIndex];

						switch (mirrorDirection)
						{
							case MirrorDirection.Forward:
								currentIndex++;
								break;
							case MirrorDirection.Backward:
								currentIndex--;
								break;
						}
						return currentSet;
					}
				default:
					throw new NotSupportedException($"Cyclical Mode {CyclicalMode} is not supported.");
			}
		}

		public void Reset(ProviderContext context)
		{
			if (Reverse)
				currentIndex = context.CycleLength - 1;
			else
				currentIndex = 0;
		}
		#endregion

		#region Static Sequences
		public static SequentialMaterialProvider RainbowPaletteOrder = new SequentialMaterialProvider
		(
			MaterialPalette.Sets.RedBrushSet,
			MaterialPalette.Sets.PinkBrushSet,
			MaterialPalette.Sets.PurpleBrushSet,
			MaterialPalette.Sets.DeepPurpleBrushSet,
			MaterialPalette.Sets.IndigoBrushSet,
			MaterialPalette.Sets.BlueBrushSet,
			MaterialPalette.Sets.LightBlueBrushSet,
			MaterialPalette.Sets.CyanBrushSet,
			MaterialPalette.Sets.TealBrushSet,
			MaterialPalette.Sets.GreenBrushSet,
			MaterialPalette.Sets.LightGreenBrushSet,
			MaterialPalette.Sets.LimeBrushSet,
			MaterialPalette.Sets.YellowBrushSet,
			MaterialPalette.Sets.AmberBrushSet,
			MaterialPalette.Sets.OrangeBrushSet,
			MaterialPalette.Sets.DeepOrangeBrushSet
		);
		public static SequentialMaterialProvider RainbowRefractionOrder = new SequentialMaterialProvider
		(
			MaterialPalette.Sets.RedBrushSet,
			MaterialPalette.Sets.DeepOrangeBrushSet,
			MaterialPalette.Sets.OrangeBrushSet,
			MaterialPalette.Sets.AmberBrushSet,
			MaterialPalette.Sets.LimeBrushSet,
			MaterialPalette.Sets.YellowBrushSet,
			MaterialPalette.Sets.LightGreenBrushSet,
			MaterialPalette.Sets.GreenBrushSet,
			MaterialPalette.Sets.TealBrushSet,
			MaterialPalette.Sets.CyanBrushSet,
			MaterialPalette.Sets.LightBlueBrushSet,
			MaterialPalette.Sets.BlueBrushSet,
			MaterialPalette.Sets.IndigoBrushSet,
			MaterialPalette.Sets.DeepPurpleBrushSet,
			MaterialPalette.Sets.PurpleBrushSet,
			MaterialPalette.Sets.PinkBrushSet
		);
		public static SequentialMaterialProvider CoolColors = new SequentialMaterialProvider
		(
			MaterialPalette.Sets.PurpleBrushSet,
			MaterialPalette.Sets.DeepPurpleBrushSet,
			MaterialPalette.Sets.IndigoBrushSet,
			MaterialPalette.Sets.BlueBrushSet,
			MaterialPalette.Sets.LightBlueBrushSet,
			MaterialPalette.Sets.CyanBrushSet,
			MaterialPalette.Sets.TealBrushSet,
			MaterialPalette.Sets.GreenBrushSet
		);
		public static SequentialMaterialProvider CoolColorsReverse = new SequentialMaterialProvider
		(
			MaterialPalette.Sets.PurpleBrushSet,
			MaterialPalette.Sets.DeepPurpleBrushSet,
			MaterialPalette.Sets.IndigoBrushSet,
			MaterialPalette.Sets.BlueBrushSet,
			MaterialPalette.Sets.LightBlueBrushSet,
			MaterialPalette.Sets.CyanBrushSet,
			MaterialPalette.Sets.TealBrushSet,
			MaterialPalette.Sets.GreenBrushSet
		) {Reverse = true};
		#endregion
	}
}
