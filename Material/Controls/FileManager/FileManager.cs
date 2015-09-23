using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using FlexCharts.Controls.Core;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.Require;
using Material.Controls.Popups;

namespace Material.Controls.FileManager
{
	public class FileManager : FlexControl
	{
		private StringCollection favorites = new StringCollection();
		public static readonly DependencyProperty FileListProperty = DP.Register(
			new Meta<FileManager, ObservableCollection<AbstractFileManagerListItem>>());

		public ObservableCollection<AbstractFileManagerListItem> FileList
		{
			get { return (ObservableCollection<AbstractFileManagerListItem>)GetValue(FileListProperty); }
			set { SetValue(FileListProperty, value); }
		}
		private static readonly DirectoryInfo defaultDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

		public static readonly DependencyProperty ActiveDirectoryProperty = DP.Register(
			new Meta<FileManager, DirectoryInfo>(defaultDirectory, ActiveDirectoryChanged));

		private static void ActiveDirectoryChanged(FileManager i, DPChangedEventArgs<DirectoryInfo> e)
		{
			var rootDirectory = e.NewValue;

			if (!rootDirectory.Exists)
				rootDirectory.Create();

			i.FileList.Clear();

			foreach (var directory in rootDirectory.GetDirectories())
			{
				if (directory.IsAccessible())
				{
					i.FileList.Add(new DirectoryListItem { FileSystemItem = directory });
				}
			}
			foreach (var file in rootDirectory.GetFiles("*.flex"))
			{
				if (file.IsAccessible())
				{
					i.FileList.Add(new FileListItem { FileSystemItem = file });
				}
			}

			i.IsCurrentDirectoryFavorited = i.favorites.Contains(i.ActiveDirectory.FullName);


		}

		public DirectoryInfo ActiveDirectory
		{
			get { return (DirectoryInfo)GetValue(ActiveDirectoryProperty); }
			set { SetValue(ActiveDirectoryProperty, value); }
		}

		public static readonly DependencyPropertyKey IsCurrentDirectoryFavoritedPropertyKey = DP.RegisterReadOnly(
			new Meta<FileManager, bool>());

		public static readonly DependencyProperty IsCurrentDirectoryFavoritedProperty =
			IsCurrentDirectoryFavoritedPropertyKey.DependencyProperty;

		public bool IsCurrentDirectoryFavorited
		{
			get { return (bool)GetValue(IsCurrentDirectoryFavoritedProperty); }
			protected set { SetValue(IsCurrentDirectoryFavoritedPropertyKey, value); }
		}

		public static readonly RoutedEvent RequestOpenFileEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler RequestOpenFile
		{
			add { AddHandler(RequestOpenFileEvent, value); }
			remove { RemoveHandler(RequestOpenFileEvent, value); }
		}
		private Button PART_directoryup;
		private Button PART_home;
		private Button PART_favorites;
		private Button PART_settings;
		private Button PART_selectdisk;
		private PopupManager PART_popupmanager;
		private ToggleButton PART_favoritetoggle;

		static FileManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileManager), new FrameworkPropertyMetadata(typeof(FileManager)));
		}
		public FileManager()
		{
			FileList = new ObservableCollection<AbstractFileManagerListItem>();
			EventManager.RegisterClassHandler(typeof(FileManager), AbstractFileManagerListItem.SelectedEvent, new RoutedEventHandler(OnFileItemSelected));
			EventManager.RegisterClassHandler(typeof(FileManager), AbstractFileManagerListItem.DeleteFileEvent, new RoutedEventHandler(OnDeleteRequested));

		}

		private void OnDeleteRequested(object s, RoutedEventArgs e)
		{
			e.OriginalSource.RequireType<AbstractFileManagerListItem>().FileSystemItemBase.Delete();
		}

		public void OnFileItemSelected(object s, RoutedEventArgs e)
		{
			var directoryItem = e.OriginalSource as DirectoryListItem;
			if (directoryItem != null)
			{
				ActiveDirectory = directoryItem.FileSystemItem;
			}
			var fileItem = e.OriginalSource as FileListItem;
			if (fileItem != null)
			{
				RaiseEvent(new RoutedEventArgs(RequestOpenFileEvent, fileItem));
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_directoryup = GetTemplateChild<Button>(nameof(PART_directoryup));
			PART_home = GetTemplateChild<Button>(nameof(PART_home));
			PART_favorites = GetTemplateChild<Button>(nameof(PART_favorites));
			PART_settings = GetTemplateChild<Button>(nameof(PART_settings));
			PART_selectdisk = GetTemplateChild<Button>(nameof(PART_selectdisk));
			PART_popupmanager = GetTemplateChild<PopupManager>(nameof(PART_popupmanager));
			PART_favoritetoggle = GetTemplateChild<ToggleButton>(nameof(PART_favoritetoggle));
			PART_directoryup.Click += directoryUp;
			PART_home.Click += homeClicked;
			PART_favorites.Click += favoritesClicked;
			PART_settings.Click += settingsClicked;
			PART_selectdisk.Click += selectdiskClicked;
			PART_favoritetoggle.Checked += addToFavorites;
			PART_favoritetoggle.Unchecked += removeToFavorites;
		}

		private void removeToFavorites(object s, RoutedEventArgs e)
		{
			favorites.Remove(ActiveDirectory.FullName);
			IsCurrentDirectoryFavorited = false;
		}

		private void addToFavorites(object s, RoutedEventArgs e)
		{
			favorites.Add(ActiveDirectory.FullName);
			IsCurrentDirectoryFavorited = true;
		}

		private void favoritesClicked(object s, RoutedEventArgs e)
		{
			PART_popupmanager.Content = new MessagePopup { Title = "favorites" };
		}

		private void selectdiskClicked(object s, RoutedEventArgs e)
		{
			PART_popupmanager.Content = new MessagePopup { Title = "select drive" };
		}

		private void settingsClicked(object s, RoutedEventArgs e)
		{
			PART_popupmanager.Content = new MessagePopup { Title = "settings" };
		}

		private void homeClicked(object s, RoutedEventArgs e)
		{
			ActiveDirectory = defaultDirectory;
		}

		private void directoryUp(object s, RoutedEventArgs e)
		{
			ActiveDirectory = ActiveDirectory.Parent;
		}
	}
}
