using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using FlexCharts.Controls.Core;
using FlexCharts.Data.Filtering;
using FlexCharts.Data.Sorting;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexCharts.Controls
{
	[ContentProperty("Data")]
	public abstract class AbstractFlexChart<T> : CustomRootControl// : AbstractFlexChart
		where T : new()
	{
		#region Dependency Properties

		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, T>(default(T), DataChangedCallback, DataCoerceCallback));

		public static readonly DependencyProperty DataFilterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, AbstractDataFilter<T>>(new EmptyDataFilter<T>()) {Flags = FXR});

		public static readonly DependencyProperty DataSorterProperty = DP.Register(
			new Meta<AbstractFlexChart<T>, AbstractDataSorter<T>>(new EmptyDataSorter<T>()) {Flags = FXR});

		[Category("Charting")]
		public T Data
		{
			get { return (T) GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		[Category("Charting")]
		public AbstractDataFilter<T> DataFilter
		{
			get { return (AbstractDataFilter<T>) GetValue(DataFilterProperty); }
			set { SetValue(DataFilterProperty, value); }
		}
		[Category("Charting")]
		public AbstractDataSorter<T> DataSorter
		{
			get { return (AbstractDataSorter<T>) GetValue(DataSorterProperty); }
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