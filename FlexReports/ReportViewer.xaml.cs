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

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for ReportViewer.xaml
	/// </summary>
	public partial class ReportViewer
	{
		//private static readonly MaterialTheme purpleTheme = new MaterialTheme(MaterialPalette.Sets.PurpleBrushSet);
		
		public ReportViewer()
		{
			//MaterialTheme = new MaterialTheme();//MaterialPalette.Sets.PurpleBrushSet);
			InitializeComponent();
		}

		private void MenuExpand(object s, RoutedEventArgs e)
		{
			LeftMenu.beginAnimation(WidthProperty, 300, 360);
			Dimmer.beginAnimation(OpacityProperty, 300, .5);
			AppToolbar.beginAnimation(OpacityProperty, 300, 0);
			LeftPanelItems.beginAnimation(OpacityProperty, 300, 1);
			//LeftMenu.BeginAnimation(WidthProperty, new DoubleAnimation(500, new Duration(TimeSpan.FromMilliseconds(200))));
			//Dimmer.BeginAnimation(OpacityProperty, new DoubleAnimation(.7, new Duration(TimeSpan.FromMilliseconds(200))));
		}

		private void MenuCollapse(object s, RoutedEventArgs e)
		{
			LeftMenu.beginAnimation(WidthProperty, 300, 65);
			Dimmer.beginAnimation(OpacityProperty, 300, 0);
			AppToolbar.beginAnimation(OpacityProperty, 300, 1);
			LeftPanelItems.beginAnimation(OpacityProperty, 300, 0);
			//LeftMenu.BeginAnimation(WidthProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200))));
			//Dimmer.BeginAnimation(OpacityProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200))));
		}

		private Regex pathdataregex = new Regex("pathData=\"([^\"]*)");
		private DirectoryInfo dir = new DirectoryInfo(@"C:\Users\bfgevren\Downloads\material-design-icons-master\XML Drawables");
		//private void generateDrawableStyles()
		//{
		//	var xmlFiles = dir.GetFiles("*.xml");
		//	var styleSheet = "";
		//	foreach (var xmlFile in xmlFiles)
		//	{
		//		var filestream = new StreamReader(xmlFile.FullName);
		//		var xmlContents = filestream.ReadToEnd();
		//		var pathDataMatch = pathdataregex.Match(xmlContents);
		//		var parsedPathData = pathDataMatch.Groups[1].Value;
		//		var styleName = xmlFile.Name.Replace("_black_24dp","").Replace("ic_", "").Replace(".xml", "");
		//		var styleStr =
		//			$"<Style TargetType=\"Path\" x:Key=\"drawable{styleName}\" BasedOn=\"{{StaticResource drawable}}\"><Setter Property=\"Data\" Value=\"{parsedPathData}\"/></Style>";
  //      styleSheet += styleStr;

		//	}

		//}
		
	}
}
