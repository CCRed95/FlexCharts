using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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
		#region Dependency Properties
		public static readonly DependencyProperty ActiveDirectoryProperty = DP.Register(
			new Meta<FileManager, DirectoryInfo>(new DirectoryInfo(FileManagerSettings.Instance.LastDirectory), ActiveDirectoryChanged));

		public static readonly DependencyProperty FileListProperty = DP.Register(
			new Meta<FileManager, ObservableCollection<AbstractFileManagerListItem>>());

		public static readonly DependencyPropertyKey IsCurrentDirectoryFavoritedPropertyKey = DP.RegisterReadOnly(new Meta<FileManager, bool>());
		public static readonly DependencyProperty IsCurrentDirectoryFavoritedProperty = IsCurrentDirectoryFavoritedPropertyKey.DependencyProperty;

		public static readonly DependencyPropertyKey HasParentDirectoryPropertyKey = DP.RegisterReadOnly(new Meta<FileManager, bool>());
		public static readonly DependencyProperty HasParentDirectoryProperty = HasParentDirectoryPropertyKey.DependencyProperty;
		public bool HasParentDirectory
		{
			get { return (bool)GetValue(HasParentDirectoryProperty); }
			protected set { SetValue(HasParentDirectoryPropertyKey, value); }
		}

		public DirectoryInfo ActiveDirectory
		{
			get { return (DirectoryInfo)GetValue(ActiveDirectoryProperty); }
			set { SetValue(ActiveDirectoryProperty, value); }
		}
		public ObservableCollection<AbstractFileManagerListItem> FileList
		{
			get { return (ObservableCollection<AbstractFileManagerListItem>)GetValue(FileListProperty); }
			set { SetValue(FileListProperty, value); }
		}
		public bool IsCurrentDirectoryFavorited
		{
			get { return (bool)GetValue(IsCurrentDirectoryFavoritedProperty); }
			protected set { SetValue(IsCurrentDirectoryFavoritedPropertyKey, value); }
		}
		#endregion

		#region Dependency Callbacks
		private static void ActiveDirectoryChanged(FileManager i, DPChangedEventArgs<DirectoryInfo> e)
		{
			i.RaiseEvent(new RoutedEventArgs(DirectoryChangedEvent, e.NewValue));
			FileManagerSettings.Instance.LastDirectory = e.NewValue.FullName;
			i.refresh();
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent RequestOpenFileEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);
		public static readonly RoutedEvent DirectoryChangedEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler RequestOpenFile
		{
			add { AddHandler(RequestOpenFileEvent, value); }
			remove { RemoveHandler(RequestOpenFileEvent, value); }
		}
		public event RoutedEventHandler DirectoryChanged
		{
			add { AddHandler(DirectoryChangedEvent, value); }
			remove { RemoveHandler(DirectoryChangedEvent, value); }
		}
		#endregion

		#region Fields
		private Button PART_directoryup;
		private Button PART_home;
		private Button PART_favorites;
		private Button PART_refresh;
		private Button PART_selectdisk;
		private PopupManager PART_popupmanager;
		private ToggleButton PART_favoritetoggle;
		#endregion

		#region Constructors
		static FileManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileManager), new FrameworkPropertyMetadata(typeof(FileManager)));
		}
		public FileManager()
		{
			FileList = new ObservableCollection<AbstractFileManagerListItem>();
			EventManager.RegisterClassHandler(typeof(FileManager), AbstractFileSystemListItem.SelectedEvent, new RoutedEventHandler(OnFileItemSelected));
			EventManager.RegisterClassHandler(typeof(FileManager), AbstractFileSystemListItem.DeleteFileEvent, new RoutedEventHandler(OnDeleteRequested));
			EventManager.RegisterClassHandler(typeof(FileManager), ConfirmDeleteFilePopup.DeleteFileConfirmedEvent, new RoutedConfirmDeleteEventHandler(OnDeleteConfirmed));
			EventManager.RegisterClassHandler(typeof(FileManager), DriveListItem.DriveSelectedEvent, new RoutedSelectDriveEventHandler(driveSelected));
			EventManager.RegisterClassHandler(typeof(FileManager), FavoritesListItem.FavoriteSelectedEvent, new RoutedFavoriteSelectedEventHandler(favoriteSelected));
			Loaded += (s, e) => refresh();
		}
		#endregion

		#region Overriden Members
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_directoryup = GetTemplateChild<Button>(nameof(PART_directoryup));
			PART_home = GetTemplateChild<Button>(nameof(PART_home));
			PART_favorites = GetTemplateChild<Button>(nameof(PART_favorites));
			PART_refresh = GetTemplateChild<Button>(nameof(PART_refresh));
			PART_selectdisk = GetTemplateChild<Button>(nameof(PART_selectdisk));
			PART_popupmanager = GetTemplateChild<PopupManager>(nameof(PART_popupmanager));
			PART_favoritetoggle = GetTemplateChild<ToggleButton>(nameof(PART_favoritetoggle));
			PART_directoryup.Click += directoryUp;
			PART_home.Click += homeClicked;
			PART_favorites.Click += favoritesClicked;
			PART_refresh.Click += refreshClicked;
			PART_selectdisk.Click += selectdiskClicked;
			PART_favoritetoggle.Checked += addToFavorites;
			PART_favoritetoggle.Unchecked += removeFromFavorites;
		}
		#endregion

		#region Methods
		private void refresh()
		{
			var rootDirectory = ActiveDirectory;

			if (!rootDirectory.Exists)
				rootDirectory.Create();

			FileList.Clear();
			var nonHiddenDirectories = rootDirectory.GetDirectories().Select(f => f)
										.Where(f => (f.Attributes & FileAttributes.Hidden) == 0);
			foreach (var directory in nonHiddenDirectories)
			{
				if (directory.IsAccessible())
				{
					FileList.Add(new DirectoryListItem { FileSystemItem = directory });
				}
			}
			var visibleFiles = rootDirectory.GetFiles("*.flex").Select(f => f)
										.Where(f => (f.Attributes & FileAttributes.Hidden) == 0);
			foreach (var file in visibleFiles)
			{
				if (file.IsAccessible())
				{
					FileList.Add(new FileListItem { FileSystemItem = file });
				}
			}
			var isfound = false;
			foreach (var x in FileManagerSettings.Instance.Favorites)
			{
				if (x == ActiveDirectory.FullName)
				{
					isfound = true;
				}
			}
			IsCurrentDirectoryFavorited = isfound;
			HasParentDirectory = (ActiveDirectory.Parent != null && ActiveDirectory.Parent.Exists);
		}

		private void driveSelected(object i, RoutedSelectDriveEventArgs e)
		{
			ActiveDirectory = e.SelectedDrive.RootDirectory;
		}

		private void favoriteSelected(object s, RoutedFavoriteSelectedEventArgs e)
		{
			ActiveDirectory = e.SelectedFavorite;
		}

		private void OnDeleteRequested(object s, RoutedEventArgs e)
		{
			var fsi = e.OriginalSource.RequireType<AbstractFileSystemListItem>();
			if (FileManagerSettings.Instance.ConfirmDelete)
			{
				PART_popupmanager.Content = new ConfirmDeleteFilePopup(fsi);
			}
			else
			{
				FileList.Remove(fsi);
				//fsi.FileSystemItemBase.Delete();
			}
		}

		private void OnDeleteConfirmed(object s, RoutedConfirmDeleteEventArgs e)
		{
			FileManagerSettings.Instance.ConfirmDelete = !e.DontAskAgain;
			FileList.Remove(e.FileListItem);
			//e.FileListItem.FileSystemItemBase.Delete();
		}

		private void OnFileItemSelected(object s, RoutedEventArgs e)
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

		private void removeFromFavorites(object s, RoutedEventArgs e)
		{
			FileManagerSettings.Instance.Favorites.Remove(ActiveDirectory.FullName);
			IsCurrentDirectoryFavorited = false;
		}

		private void addToFavorites(object s, RoutedEventArgs e)
		{
			if (!FileManagerSettings.Instance.Favorites.Contains(ActiveDirectory.FullName))
			{
				FileManagerSettings.Instance.Favorites.Add(ActiveDirectory.FullName);
				IsCurrentDirectoryFavorited = true;
			}
		}

		private void favoritesClicked(object s, RoutedEventArgs e)
		{
			PART_popupmanager.Content = new FavoritesPopup(FileManagerSettings.Instance.Favorites.ToDirectoryBinders());
		}

		private void selectdiskClicked(object s, RoutedEventArgs e)
		{
			PART_popupmanager.Content = new SelectDrivePopup();
		}

		private void refreshClicked(object s, RoutedEventArgs e)
		{
			refresh();
		}

		private void homeClicked(object s, RoutedEventArgs e)
		{
			ActiveDirectory = new DirectoryInfo(FileManagerSettings.Instance.HomeDirectory);
		}

		private void directoryUp(object s, RoutedEventArgs e)
		{
			ActiveDirectory = ActiveDirectory.Parent;
		}
		#endregion
	}
	public static class CollectionExtensions
	{
		public static IEnumerable<DirectoryBinder> ToDirectoryBinders(this IEnumerable<string> s)
		{
			var directories = new Collection<DirectoryBinder>();
			foreach (var i in s)
			{
				directories.Add(new DirectoryBinder(new DirectoryInfo(i)));
			}
			return directories;
		}
	}
}
