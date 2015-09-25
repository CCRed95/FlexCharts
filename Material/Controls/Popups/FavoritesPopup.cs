using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using Material.Controls.FileManager;

namespace Material.Controls.Popups
{
	public class FavoritesPopup : PopupBase
	{
		public static readonly DependencyProperty FavoritesProperty = DP.Register(
			new Meta<FavoritesPopup, ObservableCollection<DirectoryBinder>>());

		public ObservableCollection<DirectoryBinder> Favorites
		{
			get { return (ObservableCollection<DirectoryBinder>) GetValue(FavoritesProperty); }
			set { SetValue(FavoritesProperty, value); }
		}
		private Button PART_buttoncancel;

		static FavoritesPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FavoritesPopup),
				new FrameworkPropertyMetadata(typeof (FavoritesPopup)));
		}

		public FavoritesPopup(DirectoryCollection s)
		{
			Favorites = new ObservableCollection<DirectoryBinder>(s);
			//Favorites[0].FullName
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_buttoncancel = GetTemplateChild<Button>(nameof(PART_buttoncancel));
			PART_buttoncancel.Click += onCancelClicked;
		}

		private void onCancelClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
	}
}
