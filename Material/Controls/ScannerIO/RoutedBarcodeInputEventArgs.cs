using System.Windows;

namespace Material.Controls.ScannerIO
{
	public delegate void RoutedBarcodeInputEventHandler(object sender, RoutedBarcodeInputEventArgs e);

	public class RoutedBarcodeInputEventArgs : RoutedEventArgs
	{
		public string TextScanned { get; }

		public RoutedBarcodeInputEventArgs(string textScanned)
		{
			TextScanned = textScanned;
		}
		public RoutedBarcodeInputEventArgs(string textScanned, RoutedEvent routedEvent) : base(routedEvent)
		{
			TextScanned = textScanned;
		}
		public RoutedBarcodeInputEventArgs(string textScanned, RoutedEvent routedEvent, object source) : base(routedEvent, source)
		{
			TextScanned = textScanned;
		}
	}
}
