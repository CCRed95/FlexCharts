using System;
using System.IO;
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
	[TemplatePart(Name = "PART_root", Type = typeof(Viewbox))]
	public class FlexDocumentViewport : FlexControl
	{
		#region Constants
		public const double zoomMin = 0.3;
		public const double zoomMax = 0.95;
		#endregion

		#region Dependency Properties
		public static readonly DependencyProperty DocumentFileProperty = DP.Register(
			new Meta<FlexDocumentViewport, FileInfo>(null, DocumentFileChanged));

		public static readonly DependencyProperty DocumentProperty = DP.Register(
			new Meta<FlexDocumentViewport, FlexDocument>(null, DocumentChanged));

		private static readonly double defaultZoomOrigin = FlexDocumentViewportSettings.Instance.Zoom;

		public static readonly DependencyProperty ZoomOffsetProperty = DP.Register(
			new Meta<FlexDocumentViewport, double>(defaultZoomOrigin, ZoomOffsetChanged));

		public FileInfo DocumentFile
		{
			get { return (FileInfo)GetValue(DocumentFileProperty); }
			set { SetValue(DocumentFileProperty, value); }
		}
		public FlexDocument Document
		{
			get { return (FlexDocument)GetValue(DocumentProperty); }
			set { SetValue(DocumentProperty, value); }
		}
		public double ZoomOffset
		{
			get { return (double)GetValue(ZoomOffsetProperty); }
			set { SetValue(ZoomOffsetProperty, value); }
		}
		protected static readonly DependencyPropertyKey HasContentPropertyKey = DP.RegisterReadOnly(
			new Meta<FlexDocumentViewport, bool>());

		public static readonly DependencyProperty HasContentProperty = HasContentPropertyKey.DependencyProperty;

		public bool HasContent
		{
			get { return (bool)GetValue(HasContentProperty); }
			protected set { SetValue(HasContentPropertyKey, value); }
		}
		#endregion

		#region Dependency Callbacks
		private static void DocumentChanged(FlexDocumentViewport i, DPChangedEventArgs<FlexDocument> e)
		{
			i.ZoomOffset = FlexDocumentViewportSettings.Instance.Zoom;
			i.RaiseEvent(new RoutedEventArgs(DocumentAddedEvent));
		}
		private static void DocumentFileChanged(FlexDocumentViewport i, DPChangedEventArgs<FileInfo> e)
		{
			i.loadDocument(e.NewValue);
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
		public static readonly RoutedEvent DocumentLoadErrorEvent =
			EM.Register<FlexDocumentViewport, RoutedDocumentLoadErrorEventHandler>(EM.BUBBLE);
		public event RoutedDocumentLoadErrorEventHandler DocumentLoadError
		{
			add { AddHandler(DocumentLoadErrorEvent, value); }
			remove { RemoveHandler(DocumentLoadErrorEvent, value); }
		}
		#endregion

		#region Fields
		private Viewbox PART_root;
		private ScrollViewer PART_scroll;
		private Point? lastCenterPositionOnTarget;
		private Point? lastMousePositionOnTarget;
		private bool applyZoomOffsetOnTemplate;
		#endregion

		#region Constructors
		static FlexDocumentViewport()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexDocumentViewport),
				new FrameworkPropertyMetadata(typeof(FlexDocumentViewport)));
		}
		public FlexDocumentViewport()
		{
			EventManager.RegisterClassHandler(typeof(FlexDocumentViewport), FlexContentControl.ContentChangedEvent,
				new RoutedEventHandler(OnContentChanged));
			EventManager.RegisterClassHandler(typeof(FlexDocumentViewport), FlexDocument.DocumentTabVisualChangedEvent,
				new RoutedEventHandler(OnDocumentTabVisualChanged));
			Loaded += (Sender, Args) =>
			{
				ZoomOffset = defaultZoomOrigin;
			};
		}
		#endregion

		#region Overriden Members
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_root = GetTemplateChild<Viewbox>(nameof(PART_root));
			PART_scroll = GetTemplateChild<ScrollViewer>(nameof(PART_scroll));
			PART_scroll.ScrollChanged += OnScrollViewerScrollChanged;
			PART_scroll.PreviewMouseWheel += OnPreviewMouseWheel;
			PART_scroll.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
			if (applyZoomOffsetOnTemplate)
			{
				ZoomOffsetChanged(this, null);
			}
			//PART_scroll.ValueChanged += OnSliderValueChanged;
		}

		#endregion

		#region Methods
		private void OnContentChanged(object s, RoutedEventArgs e)
		{
			PART_scroll.ScrollToTop();
		}
		private void OnDocumentTabVisualChanged(object s, RoutedEventArgs e)
		{
			PART_scroll.ScrollToTop();
		}
		public void ReloadDocument(bool preserveTab = true)
		{
			loadDocument(DocumentFile);
		}

		private void loadDocument(FileInfo fileInfo)
		{
			try
			{
				Document = FlexDocumentReader.ParseDocument(fileInfo.FullName);
				HasContent = true;
			}
			catch (Exception ex)
			{
				RaiseEvent(new RoutedDocumentLoadErrorEventArgs(fileInfo, ex, DocumentLoadErrorEvent));
				HasContent = false;
				Document = null;
			}
		}
		#endregion
		void OnMouseLeftButtonDown(object s, MouseButtonEventArgs e)
		{
			var currentPosition = e.GetPosition(PART_scroll);
			if (currentPosition.X <= PART_scroll.ViewportWidth &&
				currentPosition.Y < PART_scroll.ViewportHeight)
			{
				Mouse.Capture(PART_scroll);
			}
		}

		void OnPreviewMouseWheel(object s, MouseWheelEventArgs e)
		{
			lastMousePositionOnTarget = Mouse.GetPosition(PART_root);
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				var zoomDelta = (e.Delta / 2000.0);
				if (ZoomOffset + zoomDelta >= zoomMin && ZoomOffset + zoomDelta <= zoomMax)
				{
					ZoomOffset += zoomDelta;
					//if (e.Delta > 0)
					//{
					//	ZoomOffset += .05;
					//}
					//if (e.Delta < 0)
					//{
					//	ZoomOffset -= .05;
					//}
				}
				e.Handled = true;
			}
		}

		private static void ZoomOffsetChanged(FlexDocumentViewport i, DPChangedEventArgs<double> e)
		{
			FlexDocumentViewportSettings.Instance.Zoom = i.ZoomOffset;
			if (i.PART_scroll == null || i.PART_root == null)
			{
				i.applyZoomOffsetOnTemplate = true;
			}
			else
			{
				i.applyZoomOffsetOnTemplate = false;
				var centerOfViewport = new Point(i.PART_scroll.ViewportWidth / 2,
																			 i.PART_scroll.ViewportHeight / 2);
				i.lastCenterPositionOnTarget = i.PART_scroll.TranslatePoint(centerOfViewport, i.PART_root);
			}
		}

		void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
			{
				Point? targetBefore = null;
				Point? targetNow = null;

				if (!lastMousePositionOnTarget.HasValue)
				{
					if (lastCenterPositionOnTarget.HasValue)
					{
						var centerOfViewport = new Point(PART_scroll.ViewportWidth / 2,
																						 PART_scroll.ViewportHeight / 2);
						Point centerOfTargetNow =
									PART_scroll.TranslatePoint(centerOfViewport, PART_root);

						targetBefore = lastCenterPositionOnTarget;
						targetNow = centerOfTargetNow;
					}
				}
				else
				{
					targetBefore = lastMousePositionOnTarget;
					targetNow = Mouse.GetPosition(PART_root);

					lastMousePositionOnTarget = null;
				}

				if (targetBefore.HasValue)
				{
					double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
					double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

					double multiplicatorX = e.ExtentWidth / PART_root.Width;
					double multiplicatorY = e.ExtentHeight / PART_root.Height;

					double newOffsetX = PART_scroll.HorizontalOffset -
															dXInTargetPixels * multiplicatorX;
					double newOffsetY = PART_scroll.VerticalOffset -
															dYInTargetPixels * multiplicatorY;

					if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
					{
						return;
					}

					PART_scroll.ScrollToHorizontalOffset(newOffsetX);
					PART_scroll.ScrollToVerticalOffset(newOffsetY);
				}
			}
		}
	}
}
/*
PART_scroll.MouseMove += OnMouseMove;
PART_scroll.MouseLeftButtonUp += OnMouseLeftButtonUp;
			PART_scroll.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
		void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			PART_scroll.Cursor = Cursors.Arrow;
			PART_scroll.ReleaseMouseCapture();
			lastDragPoint = null;
		}

	void OnMouseMove(object s, MouseEventArgs e)
		{
			if (lastDragPoint.HasValue)
			{
				var currentPosition = e.GetPosition(PART_scroll);
				var delta = new Point(currentPosition.X - lastDragPoint.Value.X,
					currentPosition.Y - lastDragPoint.Value.Y);
				lastDragPoint = currentPosition;

				PART_scroll.ScrollToHorizontalOffset(PART_scroll.HorizontalOffset - delta.X);
				PART_scroll.ScrollToVerticalOffset(PART_scroll.VerticalOffset - delta.Y);
			}
		}
	*/
