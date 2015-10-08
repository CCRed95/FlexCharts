using System;
using System.Windows.Data;
using System.Windows.Markup;
namespace Material.Static
{
	public class ThemeExtension : MarkupExtension
	{
		private const string rootPath = "(ThemePrimitive.DocumentTheme).";
		private DocumentThemeBindingItem Element { get; }

		public ThemeExtension(DocumentThemeBindingItem element)
		{
			Element = element;
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var e = Element.ToString();
			return new Binding(rootPath + e) {RelativeSource = new RelativeSource(RelativeSourceMode.Self)}.ProvideValue(serviceProvider);
			//return new Binding(rootPath + e).ProvideValue(serviceProvider);
		}
	}
	//public class MaterialInverterExtension : MarkupExtension
	//{
	//	private const string rootPath = "(ThemePrimitive.DocumentTheme).";
	//	private DocumentThemeBindingItem Element { get; }

	//	public MaterialInverterExtension(DocumentThemeBindingItem element)
	//	{
	//		Element = element;
	//	}
	//	public override object ProvideValue(IServiceProvider serviceProvider)
	//	{
	//		var e = Element.ToString();
	//		return new Binding(rootPath + e) {RelativeSource = new RelativeSource(RelativeSourceMode.Self)}.ProvideValue(serviceProvider);
	//	}
	//}
}
