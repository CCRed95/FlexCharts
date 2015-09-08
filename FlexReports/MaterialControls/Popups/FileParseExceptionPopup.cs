using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls.Popups
{
	[TemplatePart(Name="PART_buttonok", Type=typeof(Button))]
	[TemplatePart(Name="PART_buttonmoreinfo", Type=typeof(Button))]
	public class FileParseExceptionPopup : Popup
	{
		public static readonly DependencyProperty MoreInfoProperty = DP.Register(
			new Meta<FileParseExceptionPopup, string>());
		public string MoreInfo
		{
			get { return (string) GetValue(MoreInfoProperty); }
			set { SetValue(MoreInfoProperty, value); }
		}

		private Button PART_buttonok;
		private Button PART_buttonmoreinfo;

		static FileParseExceptionPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FileParseExceptionPopup),
				new FrameworkPropertyMetadata(typeof (FileParseExceptionPopup)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_buttonok = GetTemplateChild<Button>(nameof(PART_buttonok));
			PART_buttonmoreinfo = GetTemplateChild<Button>(nameof(PART_buttonmoreinfo));
			PART_buttonok.Click += OkayClicked;
			PART_buttonmoreinfo.Click += MoreInfoClicked;
		}

		private void OkayClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
		private void MoreInfoClicked(object s, RoutedEventArgs e)
		{
			MessageBox.Show($"More Info: {MoreInfo}");
		}
	}
}
