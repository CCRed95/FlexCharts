using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.Indicators
{
	[ContentProperty("Source")]
	public class PerformanceDataTilePresenter : FlexControl
	{
		public static readonly DependencyProperty SourceProperty = DP.Register(
			new Meta<PerformanceDataTilePresenter, ObservableCollection<PerformanceData>>());
		public ObservableCollection<PerformanceData> Source
		{
			get { return (ObservableCollection<PerformanceData>) GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}

		static PerformanceDataTilePresenter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (PerformanceDataTilePresenter),
				new FrameworkPropertyMetadata(typeof (PerformanceDataTilePresenter)));

		}

		public PerformanceDataTilePresenter()
		{
			Source = new ObservableCollection<PerformanceData>();
		}
	}
}
