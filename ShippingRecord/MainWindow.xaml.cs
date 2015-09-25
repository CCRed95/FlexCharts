using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using Material;
using Material.Controls.Popups;
using Material.Controls.Primitives;
using ShippingRecord.Controls;

namespace ShippingRecord
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			EventManager.RegisterClassHandler(typeof(MainWindow), ShippingRecordCreatorPopup.PalletInputCompleteEvent,
				new RoutedPalletCompletedEventHandler(onShippingRecordCompleted));
			Loaded += OnLoaded;
		}

		private void onShippingRecordCompleted(object s, RoutedPalletCompletedEventArgs e)
		{
			var writeTime = DateTime.Now.ToString("dddd, MMMM d, yyyy HH mm ss");
			var path = packingSlipDirectory.FullName + writeTime + ".txt";
			try
			{
				using (var w = new StreamWriter(path, true))
				{
					w.WriteLine("FlexVIEW Shipping Record: " + writeTime);
					foreach (var i in e.ScanData)
					{
						w.WriteLine($"{i.PalletUPC}\t|\t{i.PalletSerialNumber}");
					}
					w.Flush();
					w.Close();
				}
				popupSpace.Content = new MessagePopup
				{
					Title = "Pallet Data Logged.",
					Message = "The pallet data has been written to a log file."
				};
			}
			catch//(Exception ex)
			{
				//throw;
				popupSpace.Content = new ErrorPopup
				{
					Title = "File IO Error.",
					Message = $"Could not write data to a log file (path:{path})"
				};
			}
		}

		private void OnLoaded(object s, RoutedEventArgs e)
		{
			if (!packingSlipDirectory.Exists)
				packingSlipDirectory.Create();
		}

		private static readonly DirectoryInfo packingSlipDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PackingSlips\");

		private void createReport(object s, RoutedEventArgs e)
		{
			popupSpace.Content = new ShippingRecordCreatorPopup();
		}

		private void SelectTheme(object s, RoutedEventArgs e)
		{
			popupSpace.Content = new SelectThemePopup(themeSelected);
		}

		private void themeSelected(AccentedMaterialSet theme)
		{
			ThemePrimitive.SetTheme(this, theme);
		}
	}

}