using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexReports.MaterialControls
{
	public class MaterialButtonList : StackPanel
	{
		public static readonly DependencyProperty MaterialProviderProperty = DP.Register(
			new Meta<MaterialButtonList, IMaterialProvider>(SequentialMaterialProvider.RainbowPaletteOrder));
		public IMaterialProvider MaterialProvider
		{
			get { return (IMaterialProvider) GetValue(MaterialProviderProperty); }
			set { SetValue(MaterialProviderProperty, value); }
		}

		static MaterialButtonList()
		{
			OrientationProperty.OverrideMetadata(typeof (MaterialButtonList), new FrameworkPropertyMetadata(Orientation.Vertical));
		}

		protected override void OnVisualChildrenChanged(DependencyObject a, DependencyObject r)
		{
			var context = new ProviderContext(Children.Count);
			var materialSet = MaterialProvider.ProvideNext(context);
			a.RequireType<MaterialFileButton>().ActiveIndicatorSet = materialSet;
			base.OnVisualChildrenChanged(a, r);
		}

		protected override void OnRender(DrawingContext dc)
		{
			base.OnRender(dc);
		}
	}
}
