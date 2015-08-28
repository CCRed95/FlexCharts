using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Layout;

namespace FlexCharts.CustomGeometry
{

	public class RingSegmentGeometry : GraphElementGeometry
	{
		#region Dependency Properties
		public static readonly DependencyProperty ArcAngleProperty = DP.Register(
			new Meta<RingSegmentGeometry, double>());
		public static readonly DependencyProperty PolarOffsetProperty = DP.Register(
			new Meta<RingSegmentGeometry, double>());
		public static readonly DependencyProperty RenderSizeProperty = DP.Register(
			new Meta<RingSegmentGeometry, Size>());
		public static readonly DependencyProperty RingWidthProperty = DP.Register(
			new Meta<RingSegmentGeometry, double>());
		
		public double ArcAngle
		{
			get { return (double)GetValue(ArcAngleProperty); }
			set { SetValue(ArcAngleProperty, value); }
		}
		public double PolarOffset
		{
			get { return (double)GetValue(PolarOffsetProperty); }
			set { SetValue(PolarOffsetProperty, value); }
		}
		public Size RenderSize
		{
			get { return (Size)GetValue(RenderSizeProperty); }
			set { SetValue(RenderSizeProperty, value); }
		}
		public double RingWidth
		{
			get { return (double)GetValue(RingWidthProperty); }
			set { SetValue(RingWidthProperty, value); }
		}
		#endregion

		#region Constructors
		public RingSegmentGeometry(double arcAngle, double polarOffset, Size renderSize, 
			double ringWidth, CategoricalDataPointDouble dataSource) : base(dataSource)
		{
			ArcAngle = arcAngle;
			PolarOffset = polarOffset;
			RenderSize = renderSize;
			RingWidth = ringWidth;
			DataSource = dataSource;
		}
		#endregion

		#region Methods
		private double outerRadius
		{
			get
			{
				if (RenderSize.Width < RenderSize.Height) return RenderSize.Width / 2;
				return RenderSize.Height / 2;
			}
		}
		private double innerRadius => outerRadius - RingWidth;

		private Size outerSize => new Size(outerRadius, outerRadius);
		private Size innerSize => new Size(innerRadius, innerRadius);

		public double CalculateAngularOffset()
		{
			var angle = PolarOffset + (ArcAngle / 2) - 90;
			return angle;
		}

		public override CustomPath CalculatePath()
		{
			var startOuterPolar = new PolarPoint(PolarOffset, outerRadius);
			var endOuterPolar = new PolarPoint(PolarOffset + ArcAngle, outerRadius);
			var startInnerPolar = new PolarPoint(PolarOffset, outerRadius - RingWidth);
			var endInnerPolar = new PolarPoint(PolarOffset + ArcAngle, outerRadius - RingWidth);

			return new CustomPath(this)
			{
				Data = new PathGeometry
				{
					Figures = new PathFigureCollection
					{
						new PathFigure
						{
							StartPoint = startOuterPolar.ToCartesian().LocalizeInPolarSpace(RenderSize),
							Segments = new PathSegmentCollection
							{
								new ArcSegment
								{
									Size = outerSize,
									Point = endOuterPolar.ToCartesian().LocalizeInPolarSpace(RenderSize),
									IsLargeArc = ArcAngle > 180
								},
								new LineSegment
								{
									Point = endInnerPolar.ToCartesian().LocalizeInPolarSpace(RenderSize)
								},
								new ArcSegment
								{
									Size = innerSize,
									Point = startInnerPolar.ToCartesian().LocalizeInPolarSpace(RenderSize),
									SweepDirection = SweepDirection.Clockwise,
									IsLargeArc = ArcAngle > 180
								}
							}
						}
					}
				}
			};
		}
		#endregion
	}
}
