using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using FlexCharts.Data.Filtering;
using FlexCharts.Data.Sorting;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexCharts.Controls.Core
{
	[ContentProperty("Data")]
	public abstract class AbstractFlexChart<T> : AbstractFlexChart
		where T : new()
	{
		#region Dependency Properties
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, T>(default(T), DataChangedCallback));

		public static readonly DependencyProperty DataFilterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, AbstractDataFilter<T>>(new EmptyDataFilter<T>(), DataFilterChanged) { Flags = FXR });

		public static readonly DependencyProperty DataSorterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, DataSorter<T>>(new EmptyDataSorter<T>(), DataSorterChanged) { Flags = FXR });

		protected static readonly DependencyPropertyKey FilteredDataPropertyKey = DP.RegisterReadOnly(
			new Meta<AbstractFlexChart<T>, T>(default(T), DataFilteredCallback){ Flags = FXR });//

		public static readonly DependencyProperty FilteredDataProperty = FilteredDataPropertyKey.DependencyProperty;

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
		public DataSorter<T> DataSorter
		{
			get { return (DataSorter<T>)GetValue(DataSorterProperty); }
			set { SetValue(DataSorterProperty, value); }
		}
		[Category("Charting")]
		public T FilteredData
		{
			get { return (T)GetValue(FilteredDataProperty); }
			protected set { SetValue(FilteredDataPropertyKey, value); }
		}
		#endregion

		#region Dependency Property Callbacks
		private static void DataFilterChanged(AbstractFlexChart<T> i, DPChangedEventArgs<AbstractDataFilter<T>> e)
		{
			i.FilteredData = i.DataFilter.Filter(i.DataSorter.Sort(i.Data));
		}
		private static void DataSorterChanged(AbstractFlexChart<T> i, DPChangedEventArgs<DataSorter<T>> e)
		{
			i.FilteredData = i.DataFilter.Filter(i.DataSorter.Sort(i.Data));
		}
		private static void DataChangedCallback(AbstractFlexChart<T> i, DPChangedEventArgs<T> e)
		{
			i.FilteredData = i.DataFilter.Filter(i.DataSorter.Sort(e.NewValue));
			i.OnDataChanged(e);
			
		}
		public virtual void OnDataChanged(DPChangedEventArgs<T> e)
		{

		}
		private static void DataFilteredCallback(AbstractFlexChart<T> i, DPChangedEventArgs<T> e)
		{
			i.OnDataFiltered(e);
		}
		public virtual void OnDataFiltered(DPChangedEventArgs<T> e)
		{

		}

		#endregion

		#region Routed Events

		public static readonly RoutedEvent SegmentClickedEvent = EM.Register<AbstractFlexChart<T>, RoutedEventHandler>(EM.BUBBLE);

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
			//if (!IsLoaded || FilteredData == null)
			//	FilteredData = DataFilter.Filter(DataSorter.Sort(Data));

			base.OnRender(drawingContext);
		}
	}
}