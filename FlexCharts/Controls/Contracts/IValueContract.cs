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
	public interface IValueContract
	{
		FontFamily ValueFontFamily { get; set; }
		FontStyle ValueFontStyle { get; set; }
		FontWeight ValueFontWeight { get; set; }
		FontStretch ValueFontStretch { get; set; }
		double ValueFontSize { get; set; }
		AbstractMaterialDescriptor ValueForeground { get; set; }
	}
}
