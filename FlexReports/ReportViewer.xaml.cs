using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlexCharts.Controls;
using FlexCharts.Require;

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for ReportViewer.xaml
	/// </summary>
	public partial class ReportViewer
	{
		public ReportViewer()
		{
			InitializeComponent();
		}

		private void MenuExpand(object s, RoutedEventArgs e)
		{
			LeftMenu.BeginAnimation(WidthProperty, new DoubleAnimation(500, new Duration(TimeSpan.FromMilliseconds(200))));
			Dimmer.BeginAnimation(OpacityProperty, new DoubleAnimation(.6, new Duration(TimeSpan.FromMilliseconds(200))));
		}

		private void MenuCollapse(object s, RoutedEventArgs e)
		{
			LeftMenu.BeginAnimation(WidthProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200))));
			Dimmer.BeginAnimation(OpacityProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200))));
		}
	}
}
