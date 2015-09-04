using System.Windows;
using System.Windows.Controls;

namespace Material.Controls
{
	public class FileManager : Control
	{
		static FileManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FileManager), new FrameworkPropertyMetadata(typeof(FileManager)));
		}
	}
}
