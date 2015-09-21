using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.Popups
{
	[TemplatePart(Name="PART_buttonok", Type=typeof(Button))]
	public class MessagePopup : PopupBase
	{
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<MessagePopup, string>("Title"));
		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public static readonly DependencyProperty MessageProperty = DP.Register(
			new Meta<MessagePopup, string>("Message Body"));
		public string Message
		{
			get { return (string) GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}

		private Button PART_buttonok;

		static MessagePopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (MessagePopup),
				new FrameworkPropertyMetadata(typeof (MessagePopup)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_buttonok = GetTemplateChild<Button>(nameof(PART_buttonok));
			PART_buttonok.Click += OkayClicked;
		}

		private void OkayClicked(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
	}
}
