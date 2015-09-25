using System.Runtime.CompilerServices;
using FlexCharts.Collections;

namespace Material.Static
{
	public class RecommendedThemeSet : FlexEnum<MaterialSet>
	{
		protected RecommendedThemeSet(MaterialSet value, [CallerMemberName]string fieldName = null, [CallerLineNumber]int line = 0) : base(value, fieldName, line)
		{
		}
		public static RecommendedThemeSet Red = new RecommendedThemeSet(Palette.Red);
		public static RecommendedThemeSet Pink = new RecommendedThemeSet(Palette.Pink);
		public static RecommendedThemeSet Purple = new RecommendedThemeSet(Palette.Purple);
		public static RecommendedThemeSet DeepPurple = new RecommendedThemeSet(Palette.DeepPurple);
		public static RecommendedThemeSet Indigo = new RecommendedThemeSet(Palette.Indigo);
		public static RecommendedThemeSet Blue = new RecommendedThemeSet(Palette.Blue);
		public static RecommendedThemeSet LightBlue = new RecommendedThemeSet(Palette.LightBlue);
		public static RecommendedThemeSet Cyan = new RecommendedThemeSet(Palette.Cyan);
		public static RecommendedThemeSet Teal = new RecommendedThemeSet(Palette.Teal);
		public static RecommendedThemeSet Green = new RecommendedThemeSet(Palette.Green);
		public static RecommendedThemeSet Orange = new RecommendedThemeSet(Palette.Orange);
		public static RecommendedThemeSet DeepOrange = new RecommendedThemeSet(Palette.DeepOrange);
	}
}