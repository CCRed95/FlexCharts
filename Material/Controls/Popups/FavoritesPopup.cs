using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using Material.Controls.FileManager;

namespace Material.Controls.Popups
{
	public delegate void RoutedFavoriteSelectedEventHandler(object i, RoutedFavoriteSelectedEventArgs e);

	//TODO make a generic RoutedEventArgs<T> for all these. generic delegate also?
	public class RoutedFavoriteSelectedEventArgs : RoutedEventArgs
	{
		public DirectoryInfo SelectedFavorite { get; }
		public RoutedFavoriteSelectedEventArgs(DirectoryInfo selectedFavorite, RoutedEvent routedEvent) : base(routedEvent)
		{
			SelectedFavorite = selectedFavorite;
		}
		public RoutedFavoriteSelectedEventArgs(DirectoryInfo selectedFavorite, RoutedEvent routedEvent, object source) : base(routedEvent, source)
		{
			SelectedFavorite = selectedFavorite;
		}
	}
	public class FavoritesPopup : PopupBase
	{
		public static readonly DependencyProperty FavoritesProperty = DP.Register(
			new Meta<FavoritesPopup, ObservableCollection<DirectoryBinder>>());
		//TODO readonly on all popups
		public ObservableCollection<DirectoryBinder> Favorites
		{
			get { return (ObservableCollection<DirectoryBinder>)GetValue(FavoritesProperty); }
			set { SetValue(FavoritesProperty, value); }
		}
		private Button PART_buttoncancel;

		static FavoritesPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FavoritesPopup),
				new FrameworkPropertyMetadata(typeof(FavoritesPopup)));
		}

		public FavoritesPopup(IEnumerable<DirectoryBinder> s)
		{
			Favorites = new ObservableCollection<DirectoryBinder>(s);
			EventManager.RegisterClassHandler(typeof(FavoritesPopup), FavoritesListItem.FavoriteSelectedEvent, new RoutedFavoriteSelectedEventHandler(favoritesSelected));
		}

		private void favoritesSelected(object s, RoutedFavoriteSelectedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
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
