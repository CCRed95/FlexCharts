using System.IO;
using System.Windows;
using System.Windows.Input;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using Material.Controls.Popups;

namespace Material.Controls.FileManager
{
	public class FavoritesListItem : AbstractFileManagerListItem
	{
		public static readonly DependencyProperty DirectoryProperty = DP.Register(
			new Meta<FavoritesListItem, DirectoryInfo>());
		public DirectoryInfo Directory
		{
			get { return (DirectoryInfo) GetValue(DirectoryProperty); }
			set { SetValue(DirectoryProperty, value); }
		}

		public static readonly RoutedEvent FavoriteSelectedEvent = EM.Register<DriveListItem, RoutedFavoriteSelectedEventHandler>(EM.BUBBLE);
		public event RoutedFavoriteSelectedEventHandler FavoriteSelected
		{
			add { AddHandler(FavoriteSelectedEvent, value); }
			remove { RemoveHandler(FavoriteSelectedEvent, value); }
		}

		static FavoritesListItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FavoritesListItem), new FrameworkPropertyMetadata(typeof (FavoritesListItem)));
		}
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonUp(e);
			RaiseEvent(new RoutedFavoriteSelectedEventArgs(Directory, FavoriteSelectedEvent));
		}
	}
}
