using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Extensions;

namespace FlexCharts.Documents
{
	[ContentProperty("Tabs")]
	[TemplatePart(Name="PART_document", Type=typeof(Grid))]
	public class FlexDocument : FlexControl
	{
		private Grid PART_document;
		public static readonly DependencyProperty TabsProperty = DP.Register(
			new Meta<FlexDocument, ObservableCollection<FlexDocumentTab>>(null, OnTabsChanged));

		private static void OnTabsChanged(FlexDocument i, DPChangedEventArgs<ObservableCollection<FlexDocumentTab>> e)
		{
			i.resetDocument();
		}

		public ObservableCollection<FlexDocumentTab> Tabs
		{
			get { return (ObservableCollection<FlexDocumentTab>) GetValue(TabsProperty); }
			set { SetValue(TabsProperty, value); }
		}

		static FlexDocument()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (FlexDocument), new FrameworkPropertyMetadata(typeof (FlexDocument)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_document = GetTemplateChild<Grid>(nameof(PART_document));
			resetDocument();
		}

		private void resetDocument()
		{
			if (PART_document == null)
				return;
				//	throw new NullReferenceException("PART_document null.");
			PART_document.Children.Clear();

			if (Tabs == null)
				throw new NullReferenceException("Tabs null.");
			if (Tabs.Count >= 1)
				PART_document.Children.Add(Tabs[0]);
		}
		public FlexDocument()
		{
			Tabs = new ObservableCollection<FlexDocumentTab>();
			//EventManager.RegisterClassHandler(typeof (FlexDocument), FlexDocumentTab.ViewTabRequestedEvent,
			//	new RoutedEventHandler(OnTabViewChangeRequested));
		}

		public void FocusTab(FlexDocumentTab t)
		{
			//PART_document.Children[0].RenderTransformOrigin = new Point(.5, .5);
			//PART_document.Children[0].RenderTransform = new ScaleTransform(1, 1,.5,.5);
			//PART_document.Children[0].RenderTransform.animate(ScaleTransform.ScaleXProperty, 200, 0);
			//PART_document.Children[0].RenderTransform.animate(ScaleTransform.ScaleYProperty, 200, 0, onCompleted:onCompleted);
			//PART_document.Children[0].animate(OpacityProperty, 100, 0);

			PART_document.Children.Clear();
			PART_document.Children.Add(t);
			//t.animate(OpacityProperty, 300, 1, from:0, skewms:100);
		}

		private void onCompleted(object s, EventArgs e)
		{
			PART_document.Children.RemoveAt(0);
		}

		//private void OnTabViewChangeRequested(object s, RoutedEventArgs e)
		//{
		//	//var src = e.OriginalSource;
		//	//PART_document.Children.Clear();

		//	//if (Tabs == null)
		//	//	throw new NullReferenceException("Tabs null.");
		//	//if (Tabs.Count >= 1)
		//	//	PART_document.Children.Add(Tabs[0]);
		//}
	}
}
