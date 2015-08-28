using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Contracts
{
	public interface IBarTotalContract
	{
		FontFamily BarTotalFontFamily { get; set; }
		FontStyle BarTotalFontStyle { get; set; }
		FontWeight BarTotalFontWeight { get; set; }
		FontStretch BarTotalFontStretch { get; set; }
		double BarTotalFontSize { get; set; }
		AbstractMaterialDescriptor BarTotalForeground { get; set; }
	}
}
