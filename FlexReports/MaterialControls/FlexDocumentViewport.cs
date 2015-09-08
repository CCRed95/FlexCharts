using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Controls.Core;
using FlexCharts.Documents;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexReports.MaterialControls
{
	[TemplatePart(Name = "PART_root", Type = typeof(Viewbox))]
	public class FlexDocumentViewport : FlexControl
	{
		public static readonly RoutedEvent DocumentAddedEvent = EM.Register<FlexDocumentViewport, RoutedEventHandler>(EM.BUBBLE);
		public event RoutedEventHandler DocumentAdded
		{
			add { AddHandler(DocumentAddedEvent, value); }
			remove { RemoveHandler(DocumentAddedEvent, value); }
		}

		public static readonly DependencyProperty DocumentProperty = DP.Register(
			new Meta<FlexDocumentViewport, FlexDocument>(null, DocumentChanged));

		private static void DocumentChanged(FlexDocumentViewport i, DPChangedEventArgs<FlexDocument> e)
		{
			i.RaiseEvent(new RoutedEventArgs(DocumentAddedEvent));
		}
		

		public FlexDocument Document
		{
			get { return (FlexDocument)GetValue(DocumentProperty); }
			set { SetValue(DocumentProperty, value); }
		}
		private Viewbox PART_root;
		public FlexDocumentViewport()
		{
			EventManager.RegisterClassHandler(typeof (FlexDocumentViewport), FlexContentControl.ContentChangedEvent,
				new RoutedEventHandler(OnContentChanged));
		}

		private void OnContentChanged(object s, RoutedEventArgs e)
		{
			
		}

		static FlexDocumentViewport()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexDocumentViewport),
				new FrameworkPropertyMetadata(typeof(FlexDocumentViewport)));

		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_root = GetTemplateChild<Viewbox>(nameof(PART_root));
		}
	}
}
