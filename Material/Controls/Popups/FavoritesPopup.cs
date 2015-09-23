using System.Collections.ObjectModel;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.Popups
{
	public class FavoritesPopup : PopupBase
	{
		public static readonly DependencyProperty FavoritesProperty = DP.Register(
			new Meta<FavoritesPopup, ObservableCollection<string>>());
		public ObservableCollection<string> Favorites
		{
			get { return (ObservableCollection<string>) GetValue(FavoritesProperty); }
			set { SetValue(FavoritesProperty, value); }
		}
		static FavoritesPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FavoritesPopup),
				new FrameworkPropertyMetadata(typeof (FavoritesPopup)));
		}
	}
}
