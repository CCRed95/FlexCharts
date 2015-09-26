using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using FlexCharts.Collections;
using FlexCharts.Documents;
using FlexCharts.Extensions;
using FlexCharts.Require;
using FlexReports.Data;
using Material;
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
		public ReportViewer()
		{
			InitializeComponent();
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
		}


		private void onSizeChanged(object s, SizeChangedEventArgs e)
		{
			AppSettings.Instance.WindowSize = e.NewSize;
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

		private void SelectTheme(object s, RoutedEventArgs e)
		{
			PopupSpace.Content = new SelectThemePopup(themeSelected);
		}

		private void themeSelected(AccentedMaterialSet theme)
		{
			ThemePrimitive.SetTheme(this, theme);
			AppSettings.Instance.Theme = theme.SerializationKey;
		}

		private void OnRequestOpenFile(object s, RoutedEventArgs e)
		{
			try
			{
				var fileInfo = e.OriginalSource.RequireType<FileListItem>().FileSystemItem;
				var parsedDocument = FlexDocumentReader.ParseDocument(fileInfo.FullName);
				documentViewport.Document = parsedDocument;
				MenuToggle.IsChecked = false;
				quickCollapseMenu();

			}
			catch (Exception ex)
			{
				PopupSpace.Content = new FileParseExceptionPopup { MoreInfo = ex.ToString() };
			}
		}

		private void OnTabSelected(object s, RoutedEventArgs e)
		{
			var tab = e.OriginalSource.RequireType<TabSelectorItem>().DocumentTab;
			documentViewport.Document.FocusTab(tab);
			//tab.RequestViewTab();
		}
	}
}
