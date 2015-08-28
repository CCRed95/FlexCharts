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

	public interface ISecondaryValueContract
	{
		FontFamily SecondaryValueFontFamily { get; set; }
		FontStyle SecondaryValueFontStyle { get; set; }
		FontWeight SecondaryValueFontWeight { get; set; }
		FontStretch SecondaryValueFontStretch { get; set; }
		double SecondaryValueFontSize { get; set; }
		AbstractMaterialDescriptor SecondaryValueForeground { get; set; }
	}
}
