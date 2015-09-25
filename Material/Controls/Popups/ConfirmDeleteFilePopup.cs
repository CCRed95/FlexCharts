using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using Material.Controls.FileManager;

namespace Material.Controls.Popups
{
	public delegate void RoutedConfirmDeleteEventHandler(object a, RoutedConfirmDeleteEventArgs e);

	public class RoutedConfirmDeleteEventArgs : RoutedEventArgs
	{
		public bool DontAskAgain { get; }
		public AbstractFileManagerListItem FileListItem { get; }
		public RoutedConfirmDeleteEventArgs(bool dontAskAgain, AbstractFileManagerListItem fileListItem)
		{
			DontAskAgain = dontAskAgain;
			FileListItem = fileListItem;
		}
		public RoutedConfirmDeleteEventArgs(bool dontAskAgain, AbstractFileManagerListItem fileListItem, RoutedEvent routedEvent) : base(routedEvent)
		{
			DontAskAgain = dontAskAgain;
			FileListItem = fileListItem;
		}
		public RoutedConfirmDeleteEventArgs(bool dontAskAgain, AbstractFileManagerListItem fileListItem, RoutedEvent routedEvent, object source) : base(routedEvent, source)
		{
			DontAskAgain = dontAskAgain;
			FileListItem = fileListItem;
		}
	}
	public class ConfirmDeleteFilePopup : PopupBase
	{
		public static readonly DependencyProperty FileListItemProperty = DP.Register(
			new Meta<ConfirmDeleteFilePopup, AbstractFileManagerListItem>());
		public AbstractFileManagerListItem FileListItem
		{
			get { return (AbstractFileManagerListItem)GetValue(FileListItemProperty); }
			set { SetValue(FileListItemProperty, value); }
		}

		public static readonly RoutedEvent DeleteFileConfirmedEvent = EM.Register<ConfirmDeleteFilePopup, RoutedConfirmDeleteEventHandler>(EM.BUBBLE);

		public event RoutedConfirmDeleteEventHandler DeleteFileConfirmed
		{
			add { AddHandler(DeleteFileConfirmedEvent, value); }
			remove { RemoveHandler(DeleteFileConfirmedEvent, value); }
		}

		protected Button PART_buttondelete;
		protected Button PART_buttoncancel;
		protected CheckBox PART_dontaskmeagaintoggle;

		static ConfirmDeleteFilePopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ConfirmDeleteFilePopup), new FrameworkPropertyMetadata(typeof(ConfirmDeleteFilePopup)));
		}

		public ConfirmDeleteFilePopup(AbstractFileManagerListItem fileListItem)
		{
			FileListItem = fileListItem;
		}
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_buttondelete = GetTemplateChild<Button>(nameof(PART_buttondelete));
			PART_buttoncancel = GetTemplateChild<Button>(nameof(PART_buttoncancel));
			PART_dontaskmeagaintoggle = GetTemplateChild<CheckBox>(nameof(PART_dontaskmeagaintoggle));
			PART_buttondelete.Click += deleteClicked;
			PART_buttoncancel.Click += cancelClicked;
		}

		private void cancelClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}

		private void deleteClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedConfirmDeleteEventArgs(PART_dontaskmeagaintoggle.IsChecked.GetValueOrDefault(false), 
				FileListItem, DeleteFileConfirmedEvent));
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
	}
}
