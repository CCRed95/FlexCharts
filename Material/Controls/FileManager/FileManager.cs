using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Controls.Core;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.FileManager
{
	public class FileManager : FlexControl
	{
		public static readonly DependencyProperty FileListProperty = DP.Register(
			new Meta<FileManager, ObservableCollection<AbstractFileManagerListItem>>());

		public ObservableCollection<AbstractFileManagerListItem> FileList
		{ 
			get { return (ObservableCollection<AbstractFileManagerListItem>)GetValue(FileListProperty); }
			set { SetValue(FileListProperty, value); }
		}
		private static DirectoryInfo defaultDirectory =
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
		}

		public DirectoryInfo ActiveDirectory
		{
			get { return (DirectoryInfo)GetValue(ActiveDirectoryProperty); }
			set { SetValue(ActiveDirectoryProperty, value); }
		}

		public static readonly RoutedEvent RequestOpenFileEvent = EM.Register<FileManager, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler RequestOpenFile
		{
			add { AddHandler(RequestOpenFileEvent, value); }
			remove { RemoveHandler(RequestOpenFileEvent, value); }
		}
		private Button PART_directoryup;

		static FileManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileManager), new FrameworkPropertyMetadata(typeof(FileManager)));
		}
		public FileManager()
		{
			FileList = new ObservableCollection<AbstractFileManagerListItem>();
			EventManager.RegisterClassHandler(typeof(FileManager), AbstractFileManagerListItem.SelectedEvent, new RoutedEventHandler(OnFileItemSelected));
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
			PART_directoryup.Click += directoryUp;
		}

		private void directoryUp(object s, RoutedEventArgs e)
		{
			ActiveDirectory = ActiveDirectory.Parent;
		}
	}
}
