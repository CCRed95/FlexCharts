using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using Material.Controls.ScannerIO.Validation;

namespace Material.Controls.ScannerIO
{
	public class HIDBarcodeScannerInput : TextBox
	{
		#region Dependency Properties
		public static readonly DependencyProperty EmulatorCommandEndKeyProperty = DP.Register(new Meta<HIDBarcodeScannerInput, Key>(Key.Enter));

		public static readonly DependencyProperty InputValidatorProperty = DP.Register(new Meta<HIDBarcodeScannerInput, AbstractValidator<string>>(new EmptyValidator<string>()));

		public static readonly DependencyPropertyKey IsInputValidPropertyKey = DP.RegisterReadOnly(new Meta<HIDBarcodeScannerInput, ValidatorResult>());
		public static readonly DependencyProperty IsInputValidProperty = IsInputValidPropertyKey.DependencyProperty;

		public static readonly DependencyPropertyKey HasCommandPropertyKey = DP.RegisterReadOnly(new Meta<HIDBarcodeScannerInput, bool>());
		public static readonly DependencyProperty HasCommandProperty = HasCommandPropertyKey.DependencyProperty;

		public Key EmulatorCommandEndKey
		{
			get { return (Key)GetValue(EmulatorCommandEndKeyProperty); }
			set { SetValue(EmulatorCommandEndKeyProperty, value); }
		}
		public AbstractValidator<string> InputValidator
		{
			get { return (AbstractValidator<string>)GetValue(InputValidatorProperty); }
			set { SetValue(InputValidatorProperty, value); }
		}
		public ValidatorResult IsInputValid
		{
			get { return (ValidatorResult)GetValue(IsInputValidProperty); }
			protected set { SetValue(IsInputValidPropertyKey, value); }
		}
		public bool HasCommand
		{
			get { return (bool)GetValue(HasCommandProperty); }
			protected set { SetValue(HasCommandPropertyKey, value); }
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent ScannerInputEvent = EM.Register<HIDBarcodeScannerInput, RoutedBarcodeInputEventHandler>(EM.BUBBLE);

		public event RoutedBarcodeInputEventHandler ScannerInput
		{
			add { AddHandler(ScannerInputEvent, value); }
			remove { RemoveHandler(ScannerInputEvent, value); }
		}
		public static readonly RoutedEvent ValidScannerInputEvent = EM.Register<HIDBarcodeScannerInput, RoutedBarcodeInputEventHandler>(EM.BUBBLE);

		public event RoutedBarcodeInputEventHandler ValidScannerInput
		{
			add { AddHandler(ValidScannerInputEvent, value); }
			remove { RemoveHandler(ValidScannerInputEvent, value); }
		}
		public static readonly RoutedEvent InvalidScannerInputEvent = EM.Register<HIDBarcodeScannerInput, RoutedBarcodeInputEventHandler>(EM.BUBBLE);

		public event RoutedBarcodeInputEventHandler InvalidScannerInput
		{
			add { AddHandler(InvalidScannerInputEvent, value); }
			remove { RemoveHandler(InvalidScannerInputEvent, value); }
		}
		#endregion

		public bool AutoFocus { get; set; } = true;
		#region Fields 
		private bool isCommandInputCompleted;
		#endregion
		static HIDBarcodeScannerInput()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(HIDBarcodeScannerInput),
				new FrameworkPropertyMetadata(typeof(HIDBarcodeScannerInput)));
		}
		public HIDBarcodeScannerInput()
		{
			Loaded += OnLoaded;
			KeyDown += OnKeyDown;
		}

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			Dispatcher.BeginInvoke(new Action(() =>
				 {
					 Focusable = true;
					 IsEnabled = true;
					 if (AutoFocus)
					 {
						 Focus();
						 Keyboard.Focus(this);
					 }

				 }));
		}

		private void OnKeyDown(object s, KeyEventArgs e)
		{
			if (isCommandInputCompleted)
			{
				isCommandInputCompleted = false;
				Text = "";
			}
			if (e.Key == EmulatorCommandEndKey)
			{
				onCommandEnd(Text);
			}
		}

		private void onCommandEnd(string s)
		{
			isCommandInputCompleted = true;
			HasCommand = true;
			IsInputValid = InputValidator.IsValid(s);
			RaiseEvent(new RoutedBarcodeInputEventArgs(s, ScannerInputEvent));
			if (IsInputValid == ValidatorResult.PASSED)
			{
				RaiseEvent(new RoutedBarcodeInputEventArgs(s, ValidScannerInputEvent));
			}
			else
			{
				RaiseEvent(new RoutedBarcodeInputEventArgs(s, InvalidScannerInputEvent));
			}
		}
	}
}
