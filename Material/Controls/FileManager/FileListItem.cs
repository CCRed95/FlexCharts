using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Material.Controls.FileManager
{
	public class FileListItem : AbstractFileSystemListItem<FileInfo>
	{
		private Button PART_delete;

		static FileListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileListItem), new FrameworkPropertyMetadata(typeof(FileListItem)));
		}
		
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_delete = GetTemplateChild<Button>(nameof(PART_delete));
			PART_delete.Click += onDeleteClick;
		}

		private void onDeleteClick(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(DeleteFileEvent));
		}
	}
}