using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexReports.MaterialControls.FileExplorer
{
	public class FileExplorerHost : Control
	{
		public static readonly DependencyProperty FileListProperty = DP.Register(
			new Meta<FileExplorerHost, ObservableCollection<FileExplorerListItem>>());
		public ObservableCollection<FileExplorerListItem> FileList
		{
			get { return (ObservableCollection<FileExplorerListItem>)GetValue(FileListProperty); }
			set { SetValue(FileListProperty, value); }
		}
		public static readonly DependencyProperty ActiveDirectoryProperty = DP.Register(
			new Meta<FileExplorerHost, DirectoryInfo>(null, ActiveDirectoryChanged));

		private static void ActiveDirectoryChanged(FileExplorerHost i, DPChangedEventArgs<DirectoryInfo> e)
		{
			var rootDirectory = e.NewValue;
			
			if (!rootDirectory.Exists)
				rootDirectory.Create();

			i.FileList.Clear();

			foreach (var directory in rootDirectory.GetDirectories())
			{
				if (directory.IsAccessible())
				{
					i.FileList.Add(new DirectoryListItem { Directory = directory });
				}
			}
			foreach (var file in rootDirectory.GetFiles("*.flex"))
			{
				if (file.IsAccessible())
				{
					i.FileList.Add(new FileListItem { File = file });
				}
			}
		}

		public DirectoryInfo ActiveDirectory
		{
			get { return (DirectoryInfo)GetValue(ActiveDirectoryProperty); }
			set { SetValue(ActiveDirectoryProperty, value); }
		}

		public static readonly RoutedEvent RequestOpenFileEvent = EM.Register<FileExplorerHost, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler RequestOpenFile
		{
			add { AddHandler(RequestOpenFileEvent, value); }
			remove { RemoveHandler(RequestOpenFileEvent, value); }
		}
		
		static FileExplorerHost()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileExplorerHost), new FrameworkPropertyMetadata(typeof(FileExplorerHost)));
		}
		public FileExplorerHost()
		{
			FileList = new ObservableCollection<FileExplorerListItem>();
			EventManager.RegisterClassHandler(typeof(FileExplorerHost), FileExplorerListItem.FileExplorerItemSelectedEvent, new RoutedEventHandler(OnFileItemSelected));
		}

		public void OnFileItemSelected(object s, RoutedEventArgs e)
		{
			var directoryItem = e.OriginalSource as DirectoryListItem;
			if (directoryItem != null && directoryItem.Directory.IsAccessible())
			{
				ActiveDirectory = directoryItem.Directory;
			}
			var fileItem = e.OriginalSource as FileListItem;
			if (fileItem != null)
			{
				RaiseEvent(new RoutedEventArgs(RequestOpenFileEvent, fileItem));
			}
		}

		public void NavigateParentDirectory()
		{
			ActiveDirectory = ActiveDirectory.Parent;
		}
	}
}
