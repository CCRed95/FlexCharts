namespace FlexCharts.MaterialDesign.Descriptors
{
	public class LuminosityMaterialDescriptor : AbstractMaterialDescriptor
	{
		public Luminosity Luminosity { get; set; }

		public override Material GetMaterial(MaterialSet materialSet)
		{
			return materialSet.GetMaterial(Luminosity).WithOpacity(Opacity);
		}

		public LuminosityMaterialDescriptor(Luminosity luminosity, double opacity = 1.0)
		{
			Luminosity = luminosity;
			Opacity = opacity;
		}
	}
}