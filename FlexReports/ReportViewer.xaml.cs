using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexReports.Data;
using FlexReports.MaterialControls;

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for ReportViewer.xaml
	/// </summary>
	public partial class ReportViewer
	{
		public static readonly DependencyProperty FileExplorerItemsProperty = DP.Register(
			new Meta<ReportViewer, ObservableCollection<FileSystemInfoDataSource>>());
		public ObservableCollection<FileSystemInfoDataSource> FileExplorerItems
		{
			get { return (ObservableCollection<FileSystemInfoDataSource>) GetValue(FileExplorerItemsProperty); }
			set { SetValue(FileExplorerItemsProperty, value); }
		}
		public ReportViewer()
		{
			FileExplorerItems = new ObservableCollection<FileSystemInfoDataSource>(new List<FileSystemInfoDataSource>
			{
				new FileSystemInfoDataSource(new DirectoryInfo(@"C:\Users\bfgevren\Documents\FlexDocuments\August 23 - August 29, 2015")),
				new FileSystemInfoDataSource(new FileInfo(@"C:\Users\bfgevren\Documents\FlexDocuments\flexdoc.flex")),
			});

			InitializeComponent();
			LeftMenu.Width = 65;
			Dimmer.Opacity = 0;
			AppToolbar.Opacity = 1;
			LeftIconMenu.Width = 65;
			LeftTitleBar.Opacity = 0;
			LeftIconMenu.Width = 65;
			LeftTitleBar.Opacity = 0;
			LeftPanelItems.Opacity = 0;
			Loaded += OnLoaded;
		}
		private static DirectoryInfo rootDirectory = new DirectoryInfo(@"C:\Users\bfgevren\Documents\FlexDocuments");

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			LeftPanelItems.Children.Clear();
			foreach (var directory in rootDirectory.GetDirectories())
			{
				LeftPanelItems.Children.Add(new DirectoryListItem { Directory = directory });
			}
			foreach (var file in rootDirectory.GetFiles("*.flex"))
			{
				LeftPanelItems.Children.Add(new FileListItem { File = file });
			}
		}

		private void MenuExpand(object s, RoutedEventArgs e)
		{
			LeftMenu.animate(WidthProperty, 300, 360, 0, new CubicEase {EasingMode = EasingMode.EaseOut});
			Dimmer.animate(OpacityProperty, 300, .5);
			AppToolbar.animate(OpacityProperty, 300, .3, 0, new CubicEase {EasingMode = EasingMode.EaseOut});
			
			LeftIconMenu.animate(WidthProperty, 300, 0, 0, new CubicEase {EasingMode = EasingMode.EaseOut});
			
			LeftTitleBar.animate(OpacityProperty, 200, 1, 200, new CubicEase {EasingMode = EasingMode.EaseOut});
			LeftPanelItems.animate(OpacityProperty, 300, 1, 300, new CubicEase {EasingMode = EasingMode.EaseOut});
		}

		private void MenuCollapse(object s, RoutedEventArgs e)
		{
			LeftMenu.animate(WidthProperty, 300, 65, 300, new CubicEase {EasingMode = EasingMode.EaseOut});
			Dimmer.animate(OpacityProperty, 300, 0, 300);
			AppToolbar.animate(OpacityProperty, 300, 1, 300, new CubicEase {EasingMode = EasingMode.EaseOut});
			
			LeftIconMenu.animate(WidthProperty, 300, 65, 300, new CubicEase {EasingMode = EasingMode.EaseOut});
			
			LeftTitleBar.animate(OpacityProperty, 200, 0, 0, new CubicEase {EasingMode = EasingMode.EaseOut});
			LeftPanelItems.animate(OpacityProperty, 300, 0, 100, new CubicEase {EasingMode = EasingMode.EaseOut});

			//LeftMenu.animate(WidthProperty, 300, 65);
			//Dimmer.animate(OpacityProperty, 300, 0);
			//AppToolbar.animate(OpacityProperty, 300, 1);
			//LeftPanelItems.animate(OpacityProperty, 300, 0);
			//LeftIconMenu.animate(WidthProperty, 300, 65);
			//LeftTitleBar.animate(OpacityProperty, 300, 0);
		}

		private void SelectTheme(object s, RoutedEventArgs e)
		{
			PopupSpace.Content = new SelectThemePopup(themeSelected);
		}

		private void themeSelected(MaterialTheme theme)
		{
			ThemePrimitive.SetTheme(this, theme);
		}

		private void TransitionTheme(object s, RoutedEventArgs e)
		{

		}
	}
}
