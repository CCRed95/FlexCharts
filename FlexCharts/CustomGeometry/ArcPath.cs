using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.Layout;

namespace FlexCharts.CustomGeometry
{
	public class ArcPath : Shape
	{
		#region Dependency Properties
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<ArcPath, Geometry>()); 

		public static readonly DependencyProperty MouseOverFillProperty = DP.Register(
			new Meta<ArcPath, Brush>());

		public static readonly DependencyProperty ArcAngleProperty = DP.Register(
			new Meta<ArcPath, double>());

		public static readonly DependencyProperty PolarOffsetProperty = DP.Register(
			new Meta<ArcPath, double>());

		public static readonly DependencyProperty RingWidthProperty = DP.Register(
			new Meta<ArcPath, double>());
		
		public static readonly DependencyProperty RingScaleProperty = DP.Register(
			new Meta<ArcPath, double>(0.8));

		public static readonly DependencyProperty ActualRenderSizeProperty = DP.Register(
			new Meta<ArcPath, Size>());

		public static readonly DependencyProperty DataPointProperty = DP.Register(
			new Meta<ArcPath, object>());

		public static readonly DependencyProperty RadiusProperty = DP.Register(
			new Meta<ArcPath, double>());

		[Category("Charting")]
		public double ArcAngle
		{
			get { return (double)GetValue(ArcAngleProperty); }
			set { SetValue(ArcAngleProperty, value); }
		}
		[Category("Charting")]
		public double PolarOffset
		{
			get { return (double)GetValue(PolarOffsetProperty); }
			set { SetValue(PolarOffsetProperty, value); }
		}
		[Category("Charting")]
		public double RingWidth
		{
			get { return (double)GetValue(RingWidthProperty); }
			set { SetValue(RingWidthProperty, value); }
		}
		[Category("Charting")]
		public Geometry Data
		{
			get { return (Geometry) GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		[Category("Charting")]
		public Brush MouseOverFill
		{
			get { return (Brush)GetValue(MouseOverFillProperty); }
			set { SetValue(MouseOverFillProperty, value); }
		}
		[Category("Charting")]
		public double RingScale
		{
			get { return (double) GetValue(RingScaleProperty); }
			set { SetValue(RingScaleProperty, value); }
		}
		[Category("Charting")]
		public Size ActualRenderSize
		{
			get { return (Size) GetValue(ActualRenderSizeProperty); }
			set { SetValue(ActualRenderSizeProperty, value); } 
		}
		[Category("Charting")]
		public object DataPoint
		{
			get { return GetValue(DataPointProperty); }
			set { SetValue(DataPointProperty, value); }
		}
		[Category("Charting")]
		public double Radius
		{
			get { return (double) GetValue(RadiusProperty); }
			set { SetValue(RadiusProperty, value); }
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent ClickEvent = EM.Register<ArcPath, RoutedEventHandler>();

		public event RoutedEventHandler Click
		{
			add { AddHandler(ClickEvent, value); }
			remove { RemoveHandler(ClickEvent, value); }
		}
		#endregion

		#region Properties
		public Guid Guid { get; } = Guid.NewGuid();

		public static ArcPath Empty => new ArcPath();

		protected override Geometry DefiningGeometry => CalculateArcPath(RenderSize, Radius, RingWidth, ArcAngle, PolarOffset);
		#endregion

		#region Fields
		private Brush _tempFill;
		#endregion

		#region Constructors
		public ArcPath() { }

		public ArcPath(double arcAngle, double polarOffset, double ringWidth, double ringScale, double radius, Size actualRenderSize, object dataPoint)
		{
			ArcAngle = arcAngle;
			PolarOffset = polarOffset;
			RingWidth = ringWidth;
			RingScale = ringScale;
			Radius = radius;
			ActualRenderSize = actualRenderSize;
			DataPoint = dataPoint;
		}
		#endregion

		#region Methods
		protected virtual void OnClick()
		{
			RaiseEvent(new RoutedEventArgs(ClickEvent, this));
		}
		public double CalculateAngularOffset()
		{
			var angle = PolarOffset + (ArcAngle / 2) - 90;
			return angle;
		}
		public static Geometry CalculateArcPath(Size size, double radius, double arcWidth, double angle, double offsetAngle)
		{
			if (radius <= 0 || arcWidth <= 0 || radius - arcWidth < 0)
				return Geometry.Empty;

			var startOuterPolar = new PolarPoint(offsetAngle, radius);
			var endOuterPolar = new PolarPoint(offsetAngle + angle, radius);
			var startInnerPolar = new PolarPoint(offsetAngle, radius - arcWidth);
			var endInnerPolar = new PolarPoint(offsetAngle + angle, radius - arcWidth);

			var isLargeArc = angle > 180;

			var startOuter = startOuterPolar.ToCartesian().LocalizeInPolarSpace(size);
			var endOuter = endOuterPolar.ToCartesian().LocalizeInPolarSpace(size);
			var startInner = startInnerPolar.ToCartesian().LocalizeInPolarSpace(size);
			var endInner = endInnerPolar.ToCartesian().LocalizeInPolarSpace(size);

			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = startOuter,
						Segments = new PathSegmentCollection
						{
							new ArcSegment
							{
								Size = new Size(radius, radius),
								Point = endOuter,
								IsLargeArc = isLargeArc
							},
							new LineSegment
							{
								Point = endInner
							},
							new ArcSegment
							{
								Size = new Size(radius - arcWidth, radius - arcWidth),
								Point = startInner,
								SweepDirection = SweepDirection.Clockwise,
								IsLargeArc = isLargeArc
							}
						}
					}
				}
			};
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

		public bool CheckEquality(ArcPath other)
		{
			return Guid == other.Guid;
		}
	}
}