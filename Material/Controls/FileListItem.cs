using System.IO;
using System.Windows;
namespace Material.Controls
{
	public class FileListItem : AbstractFileManagerListItem<FileInfo>
	{
		static FileListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileListItem), new FrameworkPropertyMetadata(typeof(FileListItem)));
		}
	}
}