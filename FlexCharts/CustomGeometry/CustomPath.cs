using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;

namespace FlexCharts.CustomGeometry
{
	public class CustomPath : Shape
	{
		#region Dependency Properties
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<CustomPath, System.Windows.Media.Geometry>());

		public static readonly DependencyProperty MouseOverFillProperty = DP.Register(
			new Meta<CustomPath, Brush>());

		public System.Windows.Media.Geometry Data
		{
			get { return (System.Windows.Media.Geometry)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public Brush MouseOverFill
		{
			get { return (Brush)GetValue(MouseOverFillProperty); }
			set { SetValue(MouseOverFillProperty, value); }
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent ClickEvent = EM.Register<CustomPath, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler Click
		{
			add { AddHandler(ClickEvent, value); }
			remove { RemoveHandler(ClickEvent, value); }
		}
		#endregion

		#region Properties
		public GraphElementGeometry SourceSegmentGeometry { get; }

		public static CustomPath Empty => new CustomPath(null);

		protected override System.Windows.Media.Geometry DefiningGeometry => Data ?? System.Windows.Media.Geometry.Empty;
		#endregion

		#region Fields
		private Brush _tempFill;
		#endregion

		#region Constructors
		public CustomPath(GraphElementGeometry sourceSegmentGeometry)
		{
			SourceSegmentGeometry = sourceSegmentGeometry;
		}
		#endregion

		#region Methods
		protected virtual void OnClick()
		{
			RaiseEvent(new RoutedEventArgs(ClickEvent, this));
		}
		#endregion

		#region Overrided Methods
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			OnClick();
			OnMouseUp(e);
		}

		protected override void OnMouseEnter(MouseEventArgs e)
		{
			if (MouseOverFill != null)
			{
				_tempFill = Fill;
				Fill = MouseOverFill;
			}
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(MouseEventArgs e)
		{
			if (MouseOverFill != null)
			{
				Fill = _tempFill;
			}
			base.OnMouseLeave(e);
		}
		#endregion
	}
}