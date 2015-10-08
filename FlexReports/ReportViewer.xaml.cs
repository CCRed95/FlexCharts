using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using FlexCharts.Collections;
using FlexCharts.Documents;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Require;
using FlexReports.Data;
using Material;
using Material.Controls;
using Material.Controls.FileManager;
using Material.Controls.Popups;
using Material.Controls.Primitives;
using Material.Controls.TabSelector;
using Material.IO;
using Material.Static;

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for ReportViewer.xaml
	/// </summary>
	public partial class ReportViewer
	{
		//TODO ERROR CHECKING AND ROUTED EVENT ON FLEXDOCUMENTVIEWPORT
		//public static DirectoryInfo DataStorageDirectory =
		//	new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\FlexVIEW\UserConfig\" +
		//		System.Reflection.Assembly.GetExecutingAssembly().FullName);
		public static readonly DependencyProperty CurrentFileProperty = DP.Register(
			new Meta<ReportViewer, FileInfo>());
		public FileInfo CurrentFile
		{
			get { return (FileInfo)GetValue(CurrentFileProperty); }
			set { SetValue(CurrentFileProperty, value); }
		}
		public ReportViewer()
		{
			InitializeComponent();
			EventManager.RegisterClassHandler(typeof(ReportViewer), FlexDocumentViewport.DocumentLoadErrorEvent, 
				new RoutedDocumentLoadErrorEventHandler(OnDocumentLoadError));
			resetUI();
			Width = AppSettings.Instance.WindowSize.Width;
			Height = AppSettings.Instance.WindowSize.Height;
			SizeChanged += onSizeChanged;
			try
			{
				var theme = FlexEnum.FromName<RecommendedThemeSet>(AppSettings.Instance.Theme);
				ThemePrimitive.SetTheme(this, theme.Value);
			}
			catch
			{
				AppSettings.Instance.Theme = "Cyan";
			}
			foreach (var arg in from arg in Environment.GetCommandLineArgs()
													let fi = new FileInfo(arg)
													where fi.Exists
													where string.Equals(fi.Extension, ".FLEX",
													StringComparison.CurrentCultureIgnoreCase)
													select arg)
			{
				Loaded += (Sender, Args) =>
				{
					OpenDocument(arg);

				};
			}
		}
		private void OnDocumentLoadError(object o, RoutedDocumentLoadErrorEventArgs e)
		{
			PopupSpace.Content = new FileParseExceptionPopup { MoreInfo = e.ReferencedException.ToString() };
		}
		private void onSizeChanged(object s, SizeChangedEventArgs e)
		{
			if (WindowState == WindowState.Normal)
			{
				AppSettings.Instance.WindowSize = e.NewSize;
			}
		}
		private void resetUI()
		{
			LeftMenu.Width = 65;
			Dimmer.Opacity = 0;
			AppToolbar.Opacity = 1;
			LeftIconMenu.Width = 65;
			LeftTitleBar.Opacity = 0;
			LeftIconMenu.Width = 65;
			LeftTitleBar.Opacity = 0;
			LeftPanelItems.Opacity = 0;
		}
		private void toggleMenu(object s, RoutedEventArgs e)
		{
			if (MenuToggle.IsChecked != null && MenuToggle.IsChecked.Value)
			{
				expandMenu();
			}
			else
			{
				collapseMenu();
			}
		}
		private void expandMenu()
		{
			LeftMenu.animate(WidthProperty, 300, 360, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			Dimmer.animate(OpacityProperty, 300, .5);
			AppToolbar.animate(OpacityProperty, 300, .3, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftIconMenu.animate(WidthProperty, 300, 0, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftTitleBar.animate(OpacityProperty, 200, 1, 200, new CubicEase { EasingMode = EasingMode.EaseOut });
			LeftPanelItems.animate(OpacityProperty, 300, 1, 300, new CubicEase { EasingMode = EasingMode.EaseOut });
		}
		private void collapseMenu()
		{
			LeftMenu.animate(WidthProperty, 300, 65, 300, new CubicEase { EasingMode = EasingMode.EaseOut });
			Dimmer.animate(OpacityProperty, 300, 0, 300);
			AppToolbar.animate(OpacityProperty, 300, 1, 300, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftIconMenu.animate(WidthProperty, 300, 65, 300, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftTitleBar.animate(OpacityProperty, 200, 0, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			LeftPanelItems.animate(OpacityProperty, 300, 0, 100, new CubicEase { EasingMode = EasingMode.EaseOut });
		}
		private void quickCollapseMenu()
		{
			LeftMenu.animate(WidthProperty, 300, 65, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			Dimmer.animate(OpacityProperty, 300, 0, 0);
			AppToolbar.animate(OpacityProperty, 300, 1, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftIconMenu.animate(WidthProperty, 300, 65, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftTitleBar.animate(OpacityProperty, 100, 0, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			LeftPanelItems.animate(OpacityProperty, 150, 0, 100, new CubicEase { EasingMode = EasingMode.EaseOut });
		}
		private void RefreshDocument(object s, RoutedEventArgs e)
		{
			documentViewport.ReloadDocument();
		}
		private void SelectTheme(object s, RoutedEventArgs e)
		{
			PopupSpace.Content = new SelectThemePopup(themeSelected);
		}
		private void PrinterFriendly(object s, RoutedEventArgs e)
		{
			ThemePrimitive.SetDocumentTheme(this, DocumentThemes.PrinterFriendlyDocumentTheme);
		}
		private void ApplyLightTheme(object s, RoutedEventArgs e)
		{
			ThemePrimitive.SetDocumentTheme(this, DocumentThemes.LightDocumentTheme);
		}
		private void ApplyDarkTheme(object s, RoutedEventArgs e)
		{
			ThemePrimitive.SetDocumentTheme(this, DocumentThemes.DarkDocumentTheme);
		}
		private void themeSelected(AccentedMaterialSet theme)
		{
			ThemePrimitive.SetTheme(this, theme);
			AppSettings.Instance.Theme = theme.SerializationKey;
		}
		private void OnRequestOpenFile(object s, RoutedEventArgs e)
		{
			var fileInfo = e.OriginalSource.RequireType<FileListItem>().FileSystemItem;
			OpenDocument(fileInfo.FullName);
		}
		private void OpenDocument(string path)
		{
			CurrentFile = new FileInfo(path);
			documentViewport.DocumentFile = CurrentFile;
			MenuToggle.IsChecked = false;
			quickCollapseMenu();
		}
		private void OnTabSelected(object s, RoutedEventArgs e)
		{
			var tab = e.OriginalSource.RequireType<TabSelectorItem>().DocumentTab;
			documentViewport.Document.FocusTab(tab);
		}
	}
}
