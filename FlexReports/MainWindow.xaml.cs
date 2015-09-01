using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;
using FlexReports.MaterialControls;

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow 
	{
		public static readonly DependencyProperty TestDataProperty = DP.Register(
			new Meta<MainWindow, string>("some stuff"));
		public string TestData
		{
			get { return (string) GetValue(TestDataProperty); }
			set { SetValue(TestDataProperty, value); }
		}
		public MainWindow()
		{
			InitializeComponent();
		}
	}

}
