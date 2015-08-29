using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexReports.MaterialControls
{
	public class DocumentViewport : ItemsControl
	{
		public static readonly DependencyProperty FlexDocumentProperty = DP.Register(
			new Meta<DocumentViewport, FlexDocument>(null, FlexDocumentChanged, FlexDocumentCoerce));

		private static void FlexDocumentChanged(DocumentViewport i, DPChangedEventArgs<FlexDocument> e)
		{
			i.Documents?.Clear();
			i.Documents?.Add(e.NewValue);
		}

		public FlexDocument FlexDocument
		{
			get { return (FlexDocument)GetValue(FlexDocumentProperty); }
			set { SetValue(FlexDocumentProperty, value); }
		}
		private static FlexDocument FlexDocumentCoerce(DocumentViewport i, FlexDocument b)
		{
			b.LayoutTransform = i.transformGroup;
			return b;
		}

		public static readonly DependencyProperty DocumentsProperty = DP.Register(
 			new Meta<DocumentViewport, ObservableCollection<FlexDocument>>());
		public ObservableCollection<FlexDocument> Documents
		{
			get { return (ObservableCollection<FlexDocument>)GetValue(DocumentsProperty); }
			set { SetValue(DocumentsProperty, value); }
		}

		public static readonly DependencyProperty ZoomScaleProperty = DP.Register(
 			new Meta<DocumentViewport, double>(1));
		public double ZoomScale
		{
			get { return (double)GetValue(ZoomScaleProperty); }
			set { SetValue(ZoomScaleProperty, value); }
		}
		public static readonly DependencyProperty VerticalScrollOffsetProperty = DP.Register(
			new Meta<DocumentViewport, double>());
		public double VerticalScrollOffset
		{
			get { return (double)GetValue(VerticalScrollOffsetProperty); }
			set { SetValue(VerticalScrollOffsetProperty, value); }
		}

		private readonly ScaleTransform scaleTransform = new ScaleTransform();
		private readonly TranslateTransform translateTransform = new TranslateTransform();
		private readonly TransformGroup transformGroup = new TransformGroup();

		static DocumentViewport()
		{
			BackgroundProperty.OverrideMetadata(typeof(DocumentViewport), new FrameworkPropertyMetadata(Brushes.Transparent));
			//	ContentProperty.OverrideMetadata(typeof(DocumentViewport), new FrameworkPropertyMetadata( null, new PropertyChangedCallback(sOnContentChanged)));
		}
		public DocumentViewport()
		{
			transformGroup.Children.Add(scaleTransform);
			transformGroup.Children.Add(translateTransform);
			FlexDocument = new FlexDocument();
			Documents = new ObservableCollection<FlexDocument>();
			ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(Grid)));
			BindingOperations.SetBinding(this, ItemsSourceProperty, new Binding("Documents") { Source = this });
		}


		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl))
			{
				var delta = e.Delta;
				var value = delta / 3000.0;
				var scalex = scaleTransform.ScaleX + value;
				var scaley = scaleTransform.ScaleY + value;
				if (scaley > .05 && scalex > .05 && scaley < 2 && scalex < 2)
				{
					scaleTransform.ScaleX = scalex;
					scaleTransform.ScaleY = scaley;
				}
			}
			else
			{
				var delta = e.Delta;
				var value = delta / 10.0;
				var scalex = FlexDocument.Margin.Top + value;

				FlexDocument.Margin = new Thickness(0, scalex, 0, 0);

			}
			base.OnMouseWheel(e);
		}
	}
}
