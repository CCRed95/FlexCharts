using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using Material.Controls.Popups;
using Material.Controls.ScannerIO;

namespace ShippingRecord.Controls
{
	public delegate void RoutedPalletCompletedEventHandler(object a, RoutedPalletCompletedEventArgs e);

	public class RoutedPalletCompletedEventArgs : RoutedEventArgs
	{
		public ObservableCollection<PalletScanData> ScanData { get; }
		public RoutedPalletCompletedEventArgs(ObservableCollection<PalletScanData> caseSerials)
		{
			ScanData = caseSerials;
		}
		public RoutedPalletCompletedEventArgs(ObservableCollection<PalletScanData> caseSerials, RoutedEvent routedEvent) : base(routedEvent)
		{
			ScanData = caseSerials;
		}
		public RoutedPalletCompletedEventArgs(ObservableCollection<PalletScanData> caseSerials, RoutedEvent routedEvent, object source) : base(routedEvent, source)
		{
			ScanData = caseSerials;
		}
	}
	public class ShippingRecordCreatorPopup : PopupBase
	{
		public static readonly DependencyProperty ScanDataProperty = DP.Register(
			new Meta<ShippingRecordCreatorPopup, ObservableCollection<PalletScanData>>());
		public ObservableCollection<PalletScanData> ScanData
		{
			get { return (ObservableCollection<PalletScanData>)GetValue(ScanDataProperty); }
			set { SetValue(ScanDataProperty, value); }
		}

		public static readonly RoutedEvent PalletInputCompleteEvent = EM.Register<ShippingRecordCreatorPopup, RoutedPalletCompletedEventHandler>(EM.BUBBLE);

		public event RoutedPalletCompletedEventHandler PalletInputComplete
		{
			add { AddHandler(PalletInputCompleteEvent, value); }
			remove { RemoveHandler(PalletInputCompleteEvent, value); }
		}

		private Grid PART_hidcontainer;
		private Button PART_buttoncancel;
		private HIDBarcodeScannerInput PART_upc;
		private HIDBarcodeScannerInput PART_palletid;
		private Label PART_scanpalletidtitle;
		private Button PART_buttonlog;
		private ScrollViewer PART_scroll;

		static ShippingRecordCreatorPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ShippingRecordCreatorPopup), new FrameworkPropertyMetadata(typeof(ShippingRecordCreatorPopup)));
		}

		public ShippingRecordCreatorPopup()
		{
			ScanData = new ObservableCollection<PalletScanData>();
			Loaded += OnLoaded;
		}

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			PART_upc.Focus();
			Keyboard.Focus(PART_upc);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_hidcontainer = GetTemplateChild<Grid>(nameof(PART_hidcontainer));
			PART_buttoncancel = GetTemplateChild<Button>(nameof(PART_buttoncancel));
			PART_upc = GetTemplateChild<HIDBarcodeScannerInput>(nameof(PART_upc));
			PART_palletid = GetTemplateChild<HIDBarcodeScannerInput>(nameof(PART_palletid));
			PART_scanpalletidtitle = GetTemplateChild<Label>(nameof(PART_scanpalletidtitle));
			PART_buttonlog = GetTemplateChild<Button>(nameof(PART_buttonlog));
			PART_scroll = GetTemplateChild<ScrollViewer>(nameof(PART_scroll));
			PART_buttoncancel.Click += cancelClicked;
			PART_upc.ValidScannerInput += onValidUPCScanned;
			PART_palletid.ValidScannerInput += onValidPalletScanned;
			PART_buttonlog.Click += onLogButtonClicked;
		}

		private void onLogButtonClicked(object Sender, RoutedEventArgs Args)
		{
			RaiseEvent(new RoutedPalletCompletedEventArgs(ScanData, PalletInputCompleteEvent));
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}

		private void onValidPalletScanned(object s, RoutedBarcodeInputEventArgs e)
		{
			ScanData.Add(new PalletScanData(PART_upc.Text, PART_palletid.Text));
			PART_scroll.ScrollToEnd();
			PART_palletid.animate(OpacityProperty, 300, 0);
			PART_upc.animate(OpacityProperty, 300, 1, 300);
			PART_palletid.Visibility = Visibility.Hidden;
			PART_upc.Focus();
			Keyboard.Focus(PART_upc);
			PART_scanpalletidtitle.Visibility = Visibility.Hidden;
			PART_palletid.Clear();
			PART_upc.Clear();
		}

		private void onValidUPCScanned(object s, RoutedBarcodeInputEventArgs e)
		{
			PART_upc.animate(OpacityProperty, 300, 0);
			PART_palletid.animate(OpacityProperty, 300, 1, 300);
			PART_palletid.Visibility = Visibility.Visible;
			PART_palletid.Focus();
			Keyboard.Focus(PART_palletid);
			PART_scanpalletidtitle.Visibility = Visibility.Visible;
			//.BeginAnimation(MarginProperty,
			//	new ThicknessAnimation(new Thickness(-PART_upc.ActualWidth, 0, 0, 0), new Duration(TimeSpan.FromMilliseconds(2300)))
			//	{
			//		BeginTime = TimeSpan.FromMilliseconds(300),
			//		EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = .5 }
			//	});
		}

		private void cancelClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
	}
}
