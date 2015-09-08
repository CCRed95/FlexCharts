using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls
{
	public abstract class AbstractFileManagerListItem<T> : AbstractFileManagerListItem 
		where T : FileSystemInfo
	{
		public static readonly DependencyProperty FileSystemItemProperty = DP.Register(
			new Meta<AbstractFileManagerListItem<T>, T>());
		public T FileSystemItem
		{
			get { return (T) GetValue(FileSystemItemProperty); }
			set { SetValue(FileSystemItemProperty, value); }
		}

		public override FileSystemInfo FileSystemItemBase => FileSystemItem;
	}
}
