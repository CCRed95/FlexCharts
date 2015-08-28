using System.Windows;
using System.Windows.Media;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Contracts
{
	public interface IYAxisContract
	{
		FontFamily YAxisFontFamily { get; set; }
		FontStyle YAxisFontStyle { get; set; }
		FontWeight YAxisFontWeight { get; set; }
		FontStretch YAxisFontStretch { get; set; }
		double YAxisFontSize { get; set; }
		AbstractMaterialDescriptor YAxisForeground { get; set; }
	}
}