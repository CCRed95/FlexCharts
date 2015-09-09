using System.IO;
using System.Windows;

namespace Material.Controls.FileManager
{
	public class DirectoryListItem : AbstractFileManagerListItem<DirectoryInfo>
	{
		static DirectoryListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectoryListItem), new FrameworkPropertyMetadata(typeof(DirectoryListItem)));
		}
	}
}
