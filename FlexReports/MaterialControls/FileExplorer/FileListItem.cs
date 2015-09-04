using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls.FileExplorer
{
	public class FileListItem : FileExplorerListItem
	{
		public static readonly DependencyProperty FileProperty = DP.Register(
			new Meta<FileListItem, FileInfo>(null, FileChanged));

		private static void FileChanged(FileListItem i, DPChangedEventArgs<FileInfo> e)
		{
			//if (e.NewValue != null)
			//{
			//	i.Description = $"Contains {e.NewValue.GetFiles().Count()} Files";
			//}
			//else
			//{
			//	i.Description = $"Null Directory!";
			//}
		}

		public FileInfo File
		{
			get { return (FileInfo)GetValue(FileProperty); }
			set { SetValue(FileProperty, value); }
		}
		static FileListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileListItem), new FrameworkPropertyMetadata(typeof(FileListItem)));
			DescriptionProperty.OverrideMetadata(typeof(FileListItem), new FrameworkPropertyMetadata("File Description"));
		}

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			RaiseEvent(new RoutedEventArgs(FileExplorerItemSelectedEvent));
		}
	}
}
