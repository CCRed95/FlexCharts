using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using FlexCharts.Controls.Primatives;
using FlexCharts.Data.Filtering;
using FlexCharts.Data.Sorting;
using FlexCharts.Extensions;
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
		public static readonly DependencyProperty TitleContentProperty = DP.Register(
			new Meta<AbstractFlexChart, string>("Abstract Flex Chart"));

		[Category("Charting")]
		public string TitleContent
		{
			get { return (string)GetValue(TitleContentProperty); }
			set { SetValue(TitleContentProperty, value); }
		}

		public static readonly DependencyProperty FallbackMaterialSetProperty = DP.Register(
			new Meta<AbstractFlexChart, MaterialSet>(MaterialPalette.Sets.LightBlueBrushSet));
		public MaterialSet FallbackMaterialSet
		{
			get { return (MaterialSet) GetValue(FallbackMaterialSetProperty); }
			set { SetValue(FallbackMaterialSetProperty, value); }
		}

		public static readonly DependencyProperty MaterialProviderProperty = DP.Register(
			new Meta<AbstractFlexChart, IMaterialProvider>(SequentialMaterialProvider.RainbowPaletteOrder) {Flags = FXR});
		public IMaterialProvider MaterialProvider
		{
			get { return (IMaterialProvider) GetValue(MaterialProviderProperty); }
			set { SetValue(MaterialProviderProperty, value); }
		}


		public static readonly DependencyProperty SegmentForegroundProperty = DP.Register(
			new Meta<AbstractFlexChart, AbstractMaterialDescriptor>(new LuminosityMaterialDescriptor(Luminosity.P500)));
		public AbstractMaterialDescriptor SegmentForeground
		{
			get { return (AbstractMaterialDescriptor) GetValue(SegmentForegroundProperty); }
			set { SetValue(SegmentForegroundProperty, value); }
		}

		#region Fields
		protected const FrameworkPropertyMetadataOptions FXR = FrameworkPropertyMetadataOptions.AffectsRender;
		protected const FrameworkPropertyMetadataOptions FXM = FrameworkPropertyMetadataOptions.AffectsMeasure;
		protected const FrameworkPropertyMetadataOptions FXA = FrameworkPropertyMetadataOptions.AffectsArrange;
		protected const FrameworkPropertyMetadataOptions INH = FrameworkPropertyMetadataOptions.Inherits;

		protected readonly DockPanel _content = new DockPanel
		{
			Background = Brushes.Transparent
		};
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

			BindingOperations.SetBinding(_main, MarginProperty, new Binding("Padding") { Source = this });

			BindingOperations.SetBinding(_titleLabel, ContentProperty, new Binding("TitleContent") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontFamilyProperty, new Binding("FontFamily") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontStyleProperty, new Binding("FontStyle") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontWeightProperty, new Binding("FontWeight") { Source = this });
			BindingOperations.SetBinding(_titleLabel, FontSizeProperty, new Binding("FontSize") { Source = this });
			BindingOperations.SetBinding(_titleLabel, ForegroundProperty, new Binding("Foreground") { Source = this });
		}
	}
	public abstract class AbstractFlexChart<T> : AbstractFlexChart//, IDataAspect<T>
		where T : new()
	{
		#region Dependency Properties
		#region			DataAspect<T>
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, T>(default(T), DataChangedCallback, DataCoerceCallback));

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

		[Category("Charting")]
		public T Data
		{
			get { return (T)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		#endregion

		public static readonly DependencyProperty DataFilterProperty = DP.Register(
			new Meta<AbstractFlexChart, AbstractDataFilter<T>>(new EmptyDataFilter<T>()) {Flags = FXR});
		public AbstractDataFilter<T> DataFilter
		{
			get { return (AbstractDataFilter<T>) GetValue(DataFilterProperty); }
			set { SetValue(DataFilterProperty, value); }
		}

		public static readonly DependencyProperty DataSorterProperty = DP.Register(
			new Meta<AbstractFlexChart, AbstractDataSorter<T>>(new EmptyDataSorter<T>()) {Flags = FXR});
		public AbstractDataSorter<T> DataSorter
		{
			get { return (AbstractDataSorter<T>) GetValue(DataSorterProperty); }
			set { SetValue(DataSorterProperty, value); }
		}

		#region			TitleAspect
		
		//TODO assign to aspect
		//public static readonly DependencyProperty SegmentStrokeProperty = DP.Register(
		//	new Meta<AbstractFlexChart<T>, Brush>(FlatUI.White));

		//public static readonly DependencyProperty SegmentStrokeThicknessProperty = DP.Register(
		//	new Meta<AbstractFlexChart<T>, int>(2));

		//[Category("Charting")]
		//public Brush SegmentStroke
		//{
		//	get { return (Brush)GetValue(SegmentStrokeProperty); }
		//	set { SetValue(SegmentStrokeProperty, value); }
		//}
		//[Category("Charting")]
		//public int SegmentStrokeThickness
		//{
		//	get { return (int)GetValue(SegmentStrokeThicknessProperty); }
		//	set { SetValue(SegmentStrokeThicknessProperty, value); }
		//}
		#endregion
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
		//private static object CoerceValueCallback(DependencyObject O, object BaseValue)
		//{
		//	var data = BaseValue.RequireType<T>();
		//	var sorter = new DescendingDataSorter();
		//	return sorter.Sort(data);
		//}

		#region Properties

		//public virtual AbstractDataFilter<T> DataFilter { get; set; } = new EmptyDataFilter<T>();

		//public abstract IMaterialProvider MaterialProvider { get; set; }

		//public virtual AbstractDataSorter<T> DataSorter { get; set; } = new EmptyDataSorter<T>();
		//public IMaterialProvider MaterialProvider
		//{
		//	get { return (IMaterialProvider) GetValue(MaterialProviderProperty); }
		//	set { SetValue(MaterialProviderProperty, value); }
		//}

		#endregion



		#region Constructors
		protected AbstractFlexChart()
		{
			Data = new T();
		}
		#endregion
		public void ApplyTargetedTypeface<TP>(FlexTypeface typeface) where TP : TextualPrimative
		{
			var type = typeof(TP);
			throw new NotImplementedException();
		}
	}
}
