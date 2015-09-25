using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Effects;

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
