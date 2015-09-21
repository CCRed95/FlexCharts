using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using FlexCharts.Require;
using Material.Properties;

namespace Material.Static
{
	public static class Palette
	{
		public static DropShadowEffect shadowDelta1 => ResourceProvider.Extract<DropShadowEffect>();
		public static DropShadowEffect shadowDelta2 => ResourceProvider.Extract<DropShadowEffect>();
		public static DropShadowEffect shadowDelta3 => ResourceProvider.Extract<DropShadowEffect>();
		public static DropShadowEffect shadowDelta4 => ResourceProvider.Extract<DropShadowEffect>();
		public static DropShadowEffect shadowDelta5 => ResourceProvider.Extract<DropShadowEffect>();

		public static AccentedMaterialSet Red => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Pink => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Purple => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet DeepPurple => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Indigo => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Blue => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet LightBlue => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Cyan => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Teal => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Green => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet LightGreen => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Lime => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Yellow => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Amber => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet Orange => ResourceProvider.Extract<AccentedMaterialSet>();
		public static AccentedMaterialSet DeepOrange => ResourceProvider.Extract<AccentedMaterialSet>();
		public static MaterialSet Brown => ResourceProvider.Extract<MaterialSet>();
		public static MaterialSet Grey => ResourceProvider.Extract<MaterialSet>();
		public static MaterialSet BlueGrey => ResourceProvider.Extract<MaterialSet>();

		public static ReadOnlyCollection<AccentedMaterialSet> RecommendedThemeSets = new ReadOnlyCollection<AccentedMaterialSet>(
			new List<AccentedMaterialSet>
			{
				Red, Pink, Purple, DeepPurple, Indigo, Blue, LightBlue, Cyan, Teal, Green, Orange, DeepOrange
			}); 

	}

}
//public static DropShadowEffect shadowDelta1 => ResourceProvider.Extract<DropShadowEffect>();
		////palette[nameof(shadowDelta1)].RequireType<DropShadowEffect>();
		//public static DropShadowEffect shadowDelta2 => palette[nameof(shadowDelta2)].RequireType<DropShadowEffect>();
		//public static DropShadowEffect shadowDelta3 => palette[nameof(shadowDelta3)].RequireType<DropShadowEffect>();
		//public static DropShadowEffect shadowDelta4 => palette[nameof(shadowDelta4)].RequireType<DropShadowEffect>();
		//public static DropShadowEffect shadowDelta5 => palette[nameof(shadowDelta5)].RequireType<DropShadowEffect>();

		//public static AccentedMaterialSet Red => palette[nameof(Red)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Pink => palette[nameof(Pink)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Purple => palette[nameof(Purple)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet DeepPurple => palette[nameof(DeepPurple)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Indigo => palette[nameof(Indigo)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Blue => palette[nameof(Blue)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet LightBlue => palette[nameof(LightBlue)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Cyan => palette[nameof(Cyan)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Teal => palette[nameof(Teal)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Green => palette[nameof(Green)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet LightGreen => palette[nameof(LightGreen)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Lime => palette[nameof(Lime)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Yellow => palette[nameof(Yellow)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Amber => palette[nameof(Amber)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet Orange => palette[nameof(Orange)].RequireType<AccentedMaterialSet>();
		//public static AccentedMaterialSet DeepOrange => palette[nameof(DeepOrange)].RequireType<AccentedMaterialSet>();
		//public static MaterialSet Brown => palette[nameof(Brown)].RequireType<MaterialSet>();
		//public static MaterialSet Grey => palette[nameof(Grey)].RequireType<MaterialSet>();
		//public static MaterialSet BlueGrey => palette[nameof(BlueGrey)].RequireType<MaterialSet>();
