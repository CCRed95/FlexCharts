
namespace FlexCharts.MaterialDesign.Descriptors
{
	public class LiteralMaterialDescriptor : AbstractMaterialDescriptor
	{
		public Material LiteralMaterial { get; set; }

		public override Material GetMaterial(MaterialSet materialSet) => LiteralMaterial.WithOpacity(Opacity);

		public LiteralMaterialDescriptor(Material literalMaterial, double opacity = 1.0)
		{
			LiteralMaterial = literalMaterial;
			Opacity = opacity;
		}
	}
	public class fag { }
}
