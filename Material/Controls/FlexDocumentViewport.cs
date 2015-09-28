using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using FlexCharts.Controls.Core;
using FlexCharts.Documents;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.Extensions;

namespace Material.Controls
{
	[TemplatePart(Name = "PART_root", Type = typeof (Viewbox))]
	public class FlexDocumentViewport : FlexControl
	{
		#region Constants
		public const double zoomMin = 0.4;
		public const double zoomMax = 2.0;

		public const double defaultZoomOffset = 0.75;
		public const double defaultVerticalScrollOffset = 25;
		#endregion

		#region Dependency Properties

		public static readonly DependencyProperty DocumentProperty = DP.Register(
			new Meta<FlexDocumentViewport, FlexDocument>(null, DocumentChanged));

		public static readonly DependencyProperty ZoomOffsetProperty = DP.Register(
			new Meta<FlexDocumentViewport, double>(defaultZoomOffset));

		public static readonly DependencyProperty VerticalScrollOffsetProperty = DP.Register(
			new Meta<FlexDocumentViewport, double>(defaultVerticalScrollOffset));

		public FlexDocument Document
		{
			get { return (FlexDocument) GetValue(DocumentProperty); }
			set { SetValue(DocumentProperty, value); }
		}
		public double ZoomOffset
		{
			get { return (double) GetValue(ZoomOffsetProperty); }
			set { SetValue(ZoomOffsetProperty, value); }
		}
		public double VerticalScrollOffset
		{
			get { return (double) GetValue(VerticalScrollOffsetProperty); }
			set { SetValue(VerticalScrollOffsetProperty, value); }
		}

		#endregion

		#region Dependency Callbacks

		private static void DocumentChanged(FlexDocumentViewport i, DPChangedEventArgs<FlexDocument> e)
		{
			i.unregisterAnimation(VerticalScrollOffsetProperty);
			i.unregisterAnimation(ZoomOffsetProperty);
			i.VerticalScrollOffset = defaultVerticalScrollOffset;
			i.ZoomOffset = defaultZoomOffset;
			i.RaiseEvent(new RoutedEventArgs(DocumentAddedEvent));
		}

		#endregion

		#region Routed Events

		public static readonly RoutedEvent DocumentAddedEvent =
			EM.Register<FlexDocumentViewport, RoutedEventHandler>(EM.BUBBLE);
		public event RoutedEventHandler DocumentAdded
		{
			add { AddHandler(DocumentAddedEvent, value); }
			remove { RemoveHandler(DocumentAddedEvent, value); }
		}

		#endregion

		#region Properties
		public bool HasContent => Document != null;
		#endregion

		#region Fields

		private Viewbox PART_root;
		private double? lastTarget;
		private double? lastZoomTarget;

		#endregion

		#region Constructors
		static FlexDocumentViewport()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FlexDocumentViewport),
				new FrameworkPropertyMetadata(typeof (FlexDocumentViewport)));

		}

		public FlexDocumentViewport()
		{
			EventManager.RegisterClassHandler(typeof (FlexDocumentViewport), FlexContentControl.ContentChangedEvent,
				new RoutedEventHandler(OnContentChanged));
			EventManager.RegisterClassHandler(typeof (FlexDocumentViewport), FlexDocument.DocumentTabVisualChangedEvent,
				new RoutedEventHandler(OnDocumentTabVisualChanged));
		}

		private void OnDocumentTabVisualChanged(object s, RoutedEventArgs e)
		{
			this.unregisterAnimation(VerticalScrollOffsetProperty);
			this.unregisterAnimation(ZoomOffsetProperty);
			VerticalScrollOffset = defaultVerticalScrollOffset;
			ZoomOffset = defaultZoomOffset;
		}
		#endregion

		#region Overriden Members

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			base.OnMouseWheel(e);
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				if (lastZoomTarget == null)
				{
					lastZoomTarget = ZoomOffset;
				}
				var possibleTarget = lastZoomTarget + (e.Delta / 2000.0);
				if (possibleTarget >= zoomMin && possibleTarget <= zoomMax)
				{
					lastZoomTarget = possibleTarget;
					//PART_root.RenderTransformOrigin = getActualRenderingOrigin();
					BeginAnimation(ZoomOffsetProperty, new DoubleAnimation(lastZoomTarget
						.GetValueOrDefault(defaultZoomOffset), new Duration(TimeSpan.FromMilliseconds(150))));
				}
			}
			else
			{
				if (lastTarget == null)
				{
					lastTarget = VerticalScrollOffset;
				}
				lastTarget = lastTarget + (e.Delta / 2.0);
				BeginAnimation(VerticalScrollOffsetProperty,
					new DoubleAnimation(lastTarget.GetValueOrDefault(defaultVerticalScrollOffset),
						new Duration(TimeSpan.FromMilliseconds(150))));
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_root = GetTemplateChild<Viewbox>(nameof(PART_root));
		}

		#endregion

		#region Methods
		private void OnContentChanged(object s, RoutedEventArgs e)
		{
			
		}

		//private Point getActualRenderingOrigin()
		//{
		//	var viewportCenter = new Point(ActualWidth / 2, ActualHeight / 2);
		//	var viewportHeight = ActualHeight;
		//	var documentHeight = Document.ActualHeight * Zo;
		//	var midScale = viewportHeight / documentHeight;
		//	var topScale = 1 - midScale;
		//	return new Point(.5, topScale);
		//}

		#endregion
	}
}