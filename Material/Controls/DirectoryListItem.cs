using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Material.Controls
{
	public class DirectoryListItem : AbstractFileManagerListItem<DirectoryInfo>
	{
		static DirectoryListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectoryListItem), new FrameworkPropertyMetadata(typeof(DirectoryListItem)));
		}
	}
}
