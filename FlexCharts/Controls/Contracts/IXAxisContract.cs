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
	public interface IXAxisContract
	{
		FontFamily XAxisFontFamily { get; set; }
		FontStyle XAxisFontStyle { get; set; }
		FontWeight XAxisFontWeight { get; set; }
		FontStretch XAxisFontStretch { get; set; }
		double XAxisFontSize { get; set; }
		AbstractMaterialDescriptor XAxisForeground { get; set; }
	}
}
