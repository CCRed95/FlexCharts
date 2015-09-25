using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace ShippingRecord.Controls
{
	public class PalletScanData : DependencyObject
	{
		public static readonly DependencyProperty PalletUPCProperty = DP.Register(
			new Meta<PalletScanData, string>());
		public static readonly DependencyProperty PalletSerialNumberProperty = DP.Register(
			new Meta<PalletScanData, string>());

		public string PalletUPC
		{
			get { return (string) GetValue(PalletUPCProperty); }
			set { SetValue(PalletUPCProperty, value); }
		}
		public string PalletSerialNumber
		{
			get { return (string) GetValue(PalletSerialNumberProperty); }
			set { SetValue(PalletSerialNumberProperty, value); }
		}

		public PalletScanData(string palletUPC, string palletSerialNumber)
		{
			PalletUPC = palletUPC;
			PalletSerialNumber = palletSerialNumber;
		}
	}
}
