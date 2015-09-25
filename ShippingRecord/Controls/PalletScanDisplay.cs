using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;
using ShippingRecord.Validators;

namespace ShippingRecord.Controls
{
	public class PalletScanDisplay : FlexControl
	{
		public static readonly DependencyProperty SerialProperty = DP.Register(
			new Meta<PalletScanDisplay, string>());
		public string Serial
		{
			get { return (string)GetValue(SerialProperty); }
			set { SetValue(SerialProperty, value); }
		}
		public static readonly DependencyProperty UPCProperty = DP.Register(
			new Meta<PalletScanDisplay, string>("", onUPCChanged));

		private static void onUPCChanged(PalletScanDisplay i, DPChangedEventArgs<string> e)
		{
			i.updateIcon();
		}

		public string UPC
		{
			get { return (string)GetValue(UPCProperty); }
			set { SetValue(UPCProperty, value); }
		}
		private Viewbox PART_steamlinklogo;
		private Viewbox PART_controllericon;

		static PalletScanDisplay()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PalletScanDisplay), new FrameworkPropertyMetadata(typeof(PalletScanDisplay)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_steamlinklogo = GetTemplateChild<Viewbox>(nameof(PART_steamlinklogo));
			PART_controllericon = GetTemplateChild<Viewbox>(nameof(PART_controllericon));
			updateIcon();
		}

		private void updateIcon()
		{
			if (PART_steamlinklogo == null || PART_controllericon == null)
				return;
			var upcType = UPCValidator.GetUPCType(UPC);
			if (upcType == UPCType.Controller)
			{
				PART_steamlinklogo.Visibility = Visibility.Hidden;
				PART_controllericon.Visibility = Visibility.Visible;
			}
			else if (upcType == UPCType.Steamlink)
			{
				PART_steamlinklogo.Visibility = Visibility.Visible;
				PART_controllericon.Visibility = Visibility.Hidden;
			}
			else
			{
				PART_steamlinklogo.Visibility = Visibility.Hidden;
				PART_controllericon.Visibility = Visibility.Hidden;
			}
		}
	}
}
