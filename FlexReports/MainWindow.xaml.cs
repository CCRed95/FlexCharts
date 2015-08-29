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
	public partial class MainWindow : Window
	{


		private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
		}

		private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
		}

		private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.CloseWindow(this);
		}

		private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MaximizeWindow(this);
		}

		private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MinimizeWindow(this);
		}

		private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.RestoreWindow(this);
		}

		public static readonly DependencyProperty TitleBarThemeProperty = DP.Register(
			new Meta<MainWindow, MaterialSet>(MaterialPalette.Sets.BlueBrushSet));

		public MaterialSet TitleBarTheme
		{
			get { return (MaterialSet)GetValue(TitleBarThemeProperty); }
			set { SetValue(TitleBarThemeProperty, value); }
		}
		public static readonly DependencyProperty DocumentScaleProperty = DP.Register(
			new Meta<MainWindow, double>(1));
		public double DocumentScale
		{
			get { return (double)GetValue(DocumentScaleProperty); }
			set { SetValue(DocumentScaleProperty, value); }
		}
		private static DirectoryInfo directoryInfo;

		static MainWindow()
		{
			ForegroundProperty.OverrideMetadata(typeof(MainWindow),
				new FrameworkPropertyMetadata(Brushes.White));
		}
		public MainWindow()
		{
				InitializeComponent();
			this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, this.OnCloseWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, this.OnMaximizeWindow, this.OnCanResizeWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, this.OnMinimizeWindow, this.OnCanMinimizeWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, this.OnRestoreWindow, this.OnCanResizeWindow));
			//Loaded += onLoad;
			//var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\FlexDocuments";
			//directoryInfo = new DirectoryInfo(path);
			////documentPanel.SizeChanged += onDocumentPanelSizeChanged;
		}

		//private void onDocumentPanelSizeChanged(object s, SizeChangedEventArgs e)
		//{
		//	//scaleDocument(e.NewSize);
		//}

		//private void scaleDocument(Size s)
		//{
		//	//var newWidth = s.Width;
		//	////var pageWidth = newWidth / documentPanel.Columns;
		//	////if (documentPanel.Children.Count < 1) return;
		//	//var documentWidth = documentPanel.Children[0].RequireType<FlexDocument>().Width;
		//	//var scale = pageWidth / documentWidth;
		//	//var xscale = scale * .95;
		//	//DocumentScale = xscale;
		//}

		//private void onLoad(object s, RoutedEventArgs e)
		//{
		//	populateDirectory();
		//}

		//private void populateDirectory()
		//{
		//	recentReports.Children.Clear();
		//	if (!directoryInfo.Exists)
		//	{
		//		directoryInfo.Create();
		//	}
		//	var files = directoryInfo.GetFiles("*.flex", SearchOption.TopDirectoryOnly).ToList();
		//	foreach (var file in files)
		//	{
		//		var mfb = new MaterialFileButton
		//		{
		//			File = file,
		//			Text = file.Name
		//		};
		//		mfb.Click += OpenFileClicked;
		//		recentReports.Children.Add(mfb);
		//	}
		//}

		//private void OpenFileClicked(object s, RoutedEventArgs e)
		//{
		//	try
		//	{
		//		//var sender = s.RequireType<MaterialFileButton>();
		//		//var parsedDocument = FlexChartConfigReader.ParseDocument(sender.File.FullName);
		//		//parsedDocument.VerticalAlignment = VerticalAlignment.Top;
		//		//parsedDocument.Margin = new Thickness(0, 20, 0, 0);
		//		//parsedDocument.Effect = MaterialPalette.Shadows.ShadowDelta5;
		//		//documentPanel.FlexDocument = parsedDocument;
		//		////var zindex = DocumentTabMenu.GetZIndex();
		//		//parsedDocument.SetZIndex(1);
		//		//DocumentTabMenu.TabItems.Clear();
		//		//foreach (var tab in parsedDocument.Tabs)
		//		//{
		//		//	var mti = new MaterialTabItem(tab) { Text = tab.Title };
		//		//	DocumentTabMenu.TabItems.Add(mti);
		//		//}
		//		//if (DocumentTabMenu.TabItems.Count > 0)
		//		//{
		//		//	DocumentTabMenu.TabItems.First().IsSelected = true;
		//		//}
		//	}
		//	catch
		//	{
		//		postInvalidDocument();
		//	}
		//	foreach (var i in recentReports.Children)
		//	{
		//		if (!Equals(i, s))
		//		{
		//			i.RequireType<MaterialFileButton>().IsSelected = false;
		//		}
		//	}

		//	//DocumentTabMenu.SetZIndex(2);
		//}

		//private void ColorPalatteClicked(object sender, RoutedEventArgs e)
		//{
		//	dimmer.IsDimmed = true;
		//	PopupSpace.Children.Clear();
		//	var card = new StackPanel
		//	{
		//		Width = 500,
		//		Height = 300,
		//		Background = MaterialPalette.White000,
		//		Effect = MaterialPalette.Shadows.ShadowDelta5

		//	};
		//	//
		//	var title = new Label
		//	{
		//		Style = (Style)FindResource("Text16p"),
		//		Padding = new Thickness(5, 20, 5, 20),
		//		Foreground = MaterialPalette.Black000,
		//		Content = "Choose a UI Theme"
		//	};

		//	//DockPanel.SetDock(title, Dock.Top);
		//	card.Children.Add(title);
		//	var innerCard = new WrapPanel
		//	{
		//		Orientation = Orientation.Horizontal,
		//		Margin = new Thickness(30, 0, 30, 20)
		//	};
		//	//DockPanel.SetDock(innerCard, Dock.Bottom);
		//	PopupSpace.Children.Add(card);
		//	card.Children.Add(innerCard);


		//	foreach (var set in MaterialPalette.Sets.AllSets)
		//	{
		//		var el = new Ellipse
		//		{
		//			Height = 50,
		//			Width = 50,
		//			Margin = new Thickness(5),
		//			Fill = set.GetMaterial(Luminosity.P500),
		//			HorizontalAlignment = HorizontalAlignment,
		//			Tag = set
		//		};
		//		el.MouseUp += ElOnMouseUp;
		//		el.MouseEnter += ElOnMouseEnter;
		//		el.MouseLeave += ElOnMouseLeave;
		//		el.MouseLeftButtonDown += ElOnMouseLeftButtonDown;
		//		innerCard.Children.Add(el);
		//	}


		//}

		//private void postInvalidDocument()
		//{
		//	dimmer.IsDimmed = true;
		//	PopupSpace.Children.Clear();
		//	var card = new DockPanel
		//	{
		//		Width = 300,
		//		Height = 120,
		//		Background = MaterialPalette.White000,
		//		Effect = MaterialPalette.Shadows.ShadowDelta5

		//	};
		//	//
		//	var title = new Label
		//	{
		//		Style = (Style)FindResource("Text16p"),
		//		Padding = new Thickness(5, 20, 5, 20),
		//		Foreground = MaterialPalette.Black000,
		//		Content = "Invalid Document Format."
		//	};
		//	var b = new Button()
		//	{
		//		Width = 300,
		//		FontSize = 14,
		//		Style = (Style)FindResource("FlatButtonBase"),
		//		Content = "OKAY",
		//		Foreground = MaterialPalette.RedA400
		//	};
		//	b.Click += CloseInvalidDocument;
		//	title.DockTop();
		//	b.DockBottom();
		//	card.Children.Add(title);
		//	card.Children.Add(b);

		//	PopupSpace.Children.Add(card);
		//}

		//private void CloseInvalidDocument(object Sender, RoutedEventArgs Args)
		//{
		//	dimmer.IsDimmed = false;
		//	PopupSpace.Children.Clear();
		//}

		//private void ElOnMouseLeftButtonDown(object s, MouseButtonEventArgs e)
		//{
		//	var el = s.RequireType<Ellipse>();
		//	var cp = el.Tag.RequireType<MaterialSet>();
		//	el.Fill = cp.GetMaterial(Luminosity.P700);
		//}
		//private void ElOnMouseLeave(object s, MouseEventArgs e)
		//{
		//	var el = s.RequireType<Ellipse>();
		//	var cp = el.Tag.RequireType<MaterialSet>();
		//	el.Fill = cp.GetMaterial(Luminosity.P500);
		//}
		//private void ElOnMouseEnter(object s, MouseEventArgs e)
		//{
		//	var el = s.RequireType<Ellipse>();
		//	var cp = el.Tag.RequireType<MaterialSet>();
		//	el.Fill = cp.GetMaterial(Luminosity.P600);
		//}
		//private void ElOnMouseUp(object s, MouseButtonEventArgs e)
		//{
		//	var el = s.RequireType<Ellipse>();
		//	var cp = el.Tag.RequireType<MaterialSet>();
		//	el.Fill = cp.GetMaterial(Luminosity.P600);
		//	dimmer.IsDimmed = false;
		//	PopupSpace.Children.Clear();
		//	TitleBarTheme = cp;
		//}

		//private void TabChangeRequested(MaterialTabControl i, MaterialTabItem tab)
		//{


		//}

	}

}
