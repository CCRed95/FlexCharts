using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;
using FlexReports.MaterialControls;

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
			Loaded += OnLoaded;
		}
		private static DirectoryInfo rootDirectory = new DirectoryInfo(@"C:\Users\bfgevren\Documents\FlexDocuments");

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			foreach (var directory in rootDirectory.GetDirectories())
			{
				LeftPanelItems.Children.Add(new DirectoryListItem { Directory = directory });
			}
			foreach (var file in rootDirectory.GetFiles("*.flex"))
			{
				//LeftPanelItems.Children.Add(new DirectoryListItem { Directory = directory });
			}

		}

		private void MenuExpand(object s, RoutedEventArgs e)
		{
			LeftMenu.beginAnimation(WidthProperty, 300, 360);
			Dimmer.beginAnimation(OpacityProperty, 300, .5);
			AppToolbar.beginAnimation(OpacityProperty, 300, 0);
			LeftPanelItems.beginAnimation(OpacityProperty, 300, 1);
			LeftIconMenu.beginAnimation(WidthProperty, 300, 0);
			LeftTitleBar.beginAnimation(OpacityProperty, 300, 1);
		}

		private void MenuCollapse(object s, RoutedEventArgs e)
		{
			LeftMenu.beginAnimation(WidthProperty, 300, 65);
			Dimmer.beginAnimation(OpacityProperty, 300, 0);
			AppToolbar.beginAnimation(OpacityProperty, 300, 1);
			LeftPanelItems.beginAnimation(OpacityProperty, 300, 0);
			LeftIconMenu.beginAnimation(WidthProperty, 300, 65);
			LeftTitleBar.beginAnimation(OpacityProperty, 300, 0);
		}

		private void SelectTheme(object s, RoutedEventArgs e)
		{
			PopupSpace.Content = new ThemeSelector(themeSelected);
		}

		private void themeSelected(MaterialTheme theme)
		{
			ThemePrimitive.SetTheme(this, theme);

		}
	}
}
