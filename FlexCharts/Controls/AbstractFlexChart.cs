using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using FlexCharts.Controls.Primitives;
using FlexCharts.Data.Filtering;
using FlexCharts.Data.Sorting;
using FlexCharts.Extensions;
using FlexCharts.Helpers;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;

namespace FlexCharts.Controls
{
	// TODO implement IAnimationreveal|collapseaspect here ( as abstract methods with no implementations? )
	
	public abstract class AbstractFlexChart : ContentControl
	{
		#region Dependency Properties
		/// <summary>
		/// Identifies the <see cref="Title"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="Title"/> dependency property
		/// </returns>
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<AbstractFlexChart, string>("Abstract Flex Chart"));
		/// <summary>
		/// Identifies the <see cref="FallbackMaterialSet"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="FallbackMaterialSet"/> dependency property
		/// </returns>
		public static readonly DependencyProperty FallbackMaterialSetProperty = DP.Register(
			new Meta<AbstractFlexChart, MaterialSet>(MaterialPalette.Sets.GreyBrushSet));
		/// <summary>
		/// Identifies the <see cref="MaterialProvider"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="MaterialProvider"/> dependency property
		/// </returns>
		public static readonly DependencyProperty MaterialProviderProperty = DP.Register(
			new Meta<AbstractFlexChart, IMaterialProvider>(SequentialMaterialProvider.RainbowPaletteOrder) { Flags = FXR });
		/// <summary>
		/// Identifies the <see cref="SegmentForeground"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="SegmentForeground"/> dependency property
		/// </returns>
		public static readonly DependencyProperty SegmentForegroundProperty = DP.Register(
			new Meta<AbstractFlexChart, AbstractMaterialDescriptor>(new LuminosityMaterialDescriptor(Luminosity.P500)));

		/// <summary>
    /// Gets or sets a string that specifies the chart's title
    /// </summary>
		[Category("Charting")]
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		/// <summary>
		/// Gets or sets a MaterialSet for MaterialDescriptors to source from that cannot be logically paired with the MaterialProvider
		/// </summary>
		[Category("Charting")]
		public MaterialSet FallbackMaterialSet
		{
			get { return (MaterialSet)GetValue(FallbackMaterialSetProperty); }
			set { SetValue(FallbackMaterialSetProperty, value); }
		}
		/// <summary>
		/// Gets or sets the MaterialProvider for the chart. Used during rendering to select material colors dynamically
		/// </summary>
		[Category("Charting")]
		public IMaterialProvider MaterialProvider
		{
			get { return (IMaterialProvider)GetValue(MaterialProviderProperty); }
			set { SetValue(MaterialProviderProperty, value); }
		}
		/// <summary>
		/// Gets or sets the MaterialDescriptor for selecting the main segment foreground
		/// </summary>
		[Category("Charting")]
		public AbstractMaterialDescriptor SegmentForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SegmentForegroundProperty); }
			set { SetValue(SegmentForegroundProperty, value); }
		}
		#endregion

		#region Fields
		protected const FrameworkPropertyMetadataOptions FXR = FrameworkPropertyMetadataOptions.AffectsRender;
		protected const FrameworkPropertyMetadataOptions FXM = FrameworkPropertyMetadataOptions.AffectsMeasure;
		protected const FrameworkPropertyMetadataOptions FXA = FrameworkPropertyMetadataOptions.AffectsArrange;
		protected const FrameworkPropertyMetadataOptions INH = FrameworkPropertyMetadataOptions.Inherits;

		protected readonly DockPanel _content = new DockPanel();
		protected readonly Grid _main = new Grid();
		protected readonly Label _titleLabel = new Label()
		{
			VerticalContentAlignment = VerticalAlignment.Center,
			HorizontalContentAlignment = HorizontalAlignment.Center
		};
		#endregion

		protected AbstractFlexChart()
		{
			Content = _content;
			_content.Children.Add(_titleLabel);
			_content.Children.Add(_main);
			_titleLabel.DockTop();
			_main.DockBottom();

			BindingOperations.SetBinding(_content, BackgroundProperty, new Binding("Background") { Source = this });
			BindingOperations.SetBinding(_main, MarginProperty, new Binding("Padding") { Source = this });

			BindingOperations.SetBinding(_titleLabel, ContentProperty, new Binding("Title") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontFamilyProperty, new Binding("FontFamily") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontStyleProperty, new Binding("FontStyle") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontWeightProperty, new Binding("FontWeight") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontSizeProperty, new Binding("FontSize") { Source = this });
			BindingOperations.SetBinding(_titleLabel, ForegroundProperty, new Binding("Foreground") { Source = this });
		}
	}
	[ContentProperty("Data")]
	public abstract class AbstractFlexChart<T> : AbstractFlexChart
		where T : new()
	{
		#region Dependency Properties
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, T>(default(T), DataChangedCallback, DataCoerceCallback));

		public static readonly DependencyProperty DataFilterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, AbstractDataFilter<T>>(new EmptyDataFilter<T>()) { Flags = FXR });

		public static readonly DependencyProperty DataSorterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, AbstractDataSorter<T>>(new EmptyDataSorter<T>()) { Flags = FXR });

		[Category("Charting")]
		public T Data
		{
			get { return (T)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		[Category("Charting")]
		public AbstractDataFilter<T> DataFilter
		{
			get { return (AbstractDataFilter<T>)GetValue(DataFilterProperty); }
			set { SetValue(DataFilterProperty, value); }
		}
		[Category("Charting")]
		public AbstractDataSorter<T> DataSorter
		{
			get { return (AbstractDataSorter<T>)GetValue(DataSorterProperty); }
			set { SetValue(DataSorterProperty, value); }
		}
		#endregion

		#region Dependency Property Callbacks
		private static T DataCoerceCallback(AbstractFlexChart<T> i, T v)
		{
			var s = i.DataSorter.Sort(v);
			return i.DataFilter.Filter(s);
		}
		private static void DataChangedCallback(AbstractFlexChart<T> i, DPChangedEventArgs<T> e)
		{
			i.OnDataChanged(e);
		}
		public virtual void OnDataChanged(DPChangedEventArgs<T> e)
		{

		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent SegmentClickedEvent = EM.Register<AbstractFlexChart<T>, RoutedEventHandler>();

		public event RoutedEventHandler SegmentClicked
		{
			add { AddHandler(SegmentClickedEvent, value); }
			remove { RemoveHandler(SegmentClickedEvent, value); }
		}
		#endregion

		#region Virtual Methods
		public virtual void OnSegmentClicked()
		{
			RaiseEvent(new RoutedEventArgs(SegmentClickedEvent, this));
		}
		#endregion

		#region Constructors
		protected AbstractFlexChart()
		{
			Data = new T();
		}
		#endregion

		protected override void OnRender(DrawingContext drawingContext)
		{
			if (!IsLoaded)
				Data = DataFilter.Filter(DataSorter.Sort(Data));
			
			base.OnRender(drawingContext);
		}
	}
}
