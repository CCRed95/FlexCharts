using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexReports.MaterialControls.FileExplorer;

namespace Material.Controls
{
	public class FileManager : Control
	{
		public static readonly DependencyProperty FileListProperty = DP.Register(
			new Meta<FileManager, ObservableCollection<AbstractFileManagerListItem>>());

		public ObservableCollection<AbstractFileManagerListItem> FileList
		{ 
			get { return (ObservableCollection<AbstractFileManagerListItem>)GetValue(FileListProperty); }
			set { SetValue(FileListProperty, value); }
		}
		public static readonly DependencyProperty ActiveDirectoryProperty = DP.Register(
			new Meta<FileManager, DirectoryInfo>(null, ActiveDirectoryChanged));

		private static void ActiveDirectoryChanged(FileManager i, DPChangedEventArgs<DirectoryInfo> e)
		{
			var rootDirectory = e.NewValue;
			
			if (!rootDirectory.Exists)
				rootDirectory.Create();

			i.FileList.Clear();

			foreach (var directory in rootDirectory.GetDirectories())
			{
				i.FileList.Add(new DirectoryListItem { FileSystemItem  = directory });
			}
			foreach (var file in rootDirectory.GetFiles("*.flex"))
			{
				i.FileList.Add(new FileListItem { FileSystemItem = file });
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
	}
}
