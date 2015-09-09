using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FlexCharts.Documents;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;
using FlexReports.Data;
using FlexReports.MaterialControls;
using FlexReports.MaterialControls.Popups;

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
			resetUI();
			Loaded += OnLoaded;
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
			//LeftPanelItems.Opacity = 0;
		}

		private static readonly DirectoryInfo rootDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\FlexDocuments");

		private void OnLoaded(object s, RoutedEventArgs e)
		{
			//LeftPanelItems.ActiveDirectory = rootDirectory;
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
			//LeftPanelItems.animate(OpacityProperty, 300, 1, 300, new CubicEase { EasingMode = EasingMode.EaseOut });
		}

		private void collapseMenu()
		{
			LeftMenu.animate(WidthProperty, 300, 65, 300, new CubicEase { EasingMode = EasingMode.EaseOut });
			Dimmer.animate(OpacityProperty, 300, 0, 300);
			AppToolbar.animate(OpacityProperty, 300, 1, 300, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftIconMenu.animate(WidthProperty, 300, 65, 300, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftTitleBar.animate(OpacityProperty, 200, 0, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			//LeftPanelItems.animate(OpacityProperty, 300, 0, 100, new CubicEase { EasingMode = EasingMode.EaseOut });
		}

		private void quickCollapseMenu()
		{
			LeftMenu.animate(WidthProperty, 300, 65, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			Dimmer.animate(OpacityProperty, 300, 0, 0);
			AppToolbar.animate(OpacityProperty, 300, 1, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftIconMenu.animate(WidthProperty, 300, 65, 0, new CubicEase { EasingMode = EasingMode.EaseOut });

			LeftTitleBar.animate(OpacityProperty, 100, 0, 0, new CubicEase { EasingMode = EasingMode.EaseOut });
			//LeftPanelItems.animate(OpacityProperty, 150, 0, 100, new CubicEase { EasingMode = EasingMode.EaseOut });
		}

		private void SelectTheme(object s, RoutedEventArgs e)
		{
			PopupSpace.Content = new SelectThemePopup(themeSelected);
		}

		private void themeSelected(MaterialTheme theme)
		{
			ThemePrimitive.SetTheme(this, theme);
		}

		private void parentDirectory(object s, RoutedEventArgs e)
		{
			//LeftPanelItems.NavigateParentDirectory();
		}

		private void viewDocumentCode(object s, RoutedEventArgs e)
		{
			documentViewport.ViewCodeBehind();
		}

		//private void OnRequestOpenFile(object s, RoutedEventArgs e)
		//{
		//	try
		//	{
		//		var fileInfo = e.OriginalSource.RequireType<FileListItem>().File;
		//		var parsedDocument = FlexDocumentReader.ParseDocument(fileInfo.FullName);
		//		documentViewport.Document = parsedDocument;
		//		MenuToggle.IsChecked = false;
		//		quickCollapseMenu();
			
		//	}
		//	catch(Exception ex)
		//	{
		//		PopupSpace.Content = new FileParseExceptionPopup {MoreInfo = ex.ToString()};
		//	}
		//}
	}
}
