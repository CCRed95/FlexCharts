using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls
{
	//[ContentProperty("Content")]
	public class PopupManager : ContentControl
	{
		static PopupManager()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupManager), new FrameworkPropertyMetadata(typeof(PopupManager)));
			EventManager.RegisterClassHandler(typeof(PopupManager), ThemeSelector.PopupRequestCloseEvent, new RoutedEventHandler(LocalOnPopupRequestClose));
		}

		internal static void LocalOnPopupRequestClose(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
