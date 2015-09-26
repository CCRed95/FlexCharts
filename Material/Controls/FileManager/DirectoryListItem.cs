using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.EventHelpers;

namespace Material.Controls.FileManager
{
	public class DirectoryListItem : AbstractFileSystemListItem<DirectoryInfo>
	{
		private Button PART_delete;

		static DirectoryListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectoryListItem), new FrameworkPropertyMetadata(typeof(DirectoryListItem)));
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
