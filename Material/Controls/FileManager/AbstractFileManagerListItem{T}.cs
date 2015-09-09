using System.IO;
using System.Windows;
using System.Windows.Input;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.FileManager
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

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			if (IsEnabled)
			{
				RaiseEvent(new RoutedEventArgs(SelectedEvent));
			}
		}
	}
}
