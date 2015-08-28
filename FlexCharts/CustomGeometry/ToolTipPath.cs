using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using FlexCharts.Helpers.DependencyHelpers;

namespace FlexCharts.CustomGeometry
{
	public enum ToolTipDirection
	{
		Left, Top, Right, Bottom
	}
	public class TrianglePoints
	{
		public Point P1 { get; set; }
		public Point P2 { get; set; }
		public Point P3 { get; set; }

		public TrianglePoints() { }
		public TrianglePoints(Point p1, Point p2, Point p3)
		{
			P1 = p1;
			P2 = p2;
			P3 = p3;
		}
	}
	public class ToolTipGeometry
	{
		public Rect Body { get; set; }
		public TrianglePoints Arrow { get; set; }
		public ToolTipGeometry() { }

		public ToolTipGeometry(Rect body, TrianglePoints arrow)
		{
			Body = body;
			Arrow = arrow;
		}
	}
	public class ToolTipPath : Shape
	{
		#region Dependency Properties
		public static readonly DependencyProperty DataProperty = DP.Register(
			new Meta<ToolTipPath, Geometry>());

		[Category("Charting")]
		public Geometry Data
		{
			get { return (Geometry)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public static readonly DependencyProperty ArrowDirectionProperty = DP.Register(
			new Meta<ToolTipPath, ToolTipDirection>(ToolTipDirection.Bottom));
		[Category("Charting")]
		public ToolTipDirection ArrowDirection
		{
			get { return (ToolTipDirection)GetValue(ArrowDirectionProperty); }
			set { SetValue(ArrowDirectionProperty, value); }
		}

		public static readonly DependencyProperty ArrowBaseLengthProperty = DP.Register(
			new Meta<ToolTipPath, double>(18));
		[Category("Charting")]
		public double ArrowBaseLength
		{
			get { return (double)GetValue(ArrowBaseLengthProperty); }
			set { SetValue(ArrowBaseLengthProperty, value); }
		}

		public static readonly DependencyProperty ArrowPointHeightProperty = DP.Register(
			new Meta<ToolTipPath, double>(20));
		[Category("Charting")]
		public double ArrowPointHeight
		{
			get { return (double)GetValue(ArrowPointHeightProperty); }
			set { SetValue(ArrowPointHeightProperty, value); }
		}
		#endregion

		#region Properties
		public static ToolTipPath Empty => new ToolTipPath();

		protected override Geometry DefiningGeometry => CalculateToolTipPath();
		#endregion

		#region Constructors
		public ToolTipPath() { }
		#endregion

		#region Methods
		public Geometry CalculateToolTipPath()
		{
			if (ArrowDirection == ToolTipDirection.Top || ArrowDirection == ToolTipDirection.Bottom)
			{
				if (Width - ArrowBaseLength <= 0 || Height - ArrowPointHeight <= 0)
					return Geometry.Empty;
			}
			else
			{
				if (Width - ArrowPointHeight <= 0 || Height - ArrowBaseLength <= 0)
					return Geometry.Empty;
			}
			var geometry = calculateToolTipGeometry();

			return new CombinedGeometry()
			{
				Geometry1 = new RectangleGeometry(geometry.Body),
				Geometry2 = new PathGeometry()
				{
					Figures = new PathFigureCollection()
					{
						new PathFigure
						{
							StartPoint = geometry.Arrow.P1,
							Segments = new PathSegmentCollection
							{
								new LineSegment
								{
									Point = geometry.Arrow.P2
								},
								new LineSegment
								{
									Point = geometry.Arrow.P3
								}
							}
						}
					}
				}
			};
		}

		private ToolTipGeometry calculateToolTipGeometry()
		{
			var total = RenderSize;
			var body = new Rect();
			var arrow = new TrianglePoints();
			if (ArrowDirection == ToolTipDirection.Left)
			{
				var startY = (total.Height - ArrowBaseLength) / 2;
				var point1 = new Point(ArrowPointHeight, startY);
				var point2 = new Point(ArrowPointHeight, startY + ArrowBaseLength);
				var point3 = new Point(0, startY + (ArrowBaseLength / 2));
				arrow = new TrianglePoints(point1, point2, point3);
				body = new Rect(new Point(ArrowPointHeight, 0), new Point(total.Width, total.Height));
			}
			if (ArrowDirection == ToolTipDirection.Top)
			{
				var startX = (total.Width - ArrowBaseLength) / 2;
				var point1 = new Point(startX, ArrowPointHeight);
				var point2 = new Point(startX + ArrowBaseLength, ArrowPointHeight);
				var point3 = new Point(startX + (ArrowBaseLength / 2), 0);
				arrow = new TrianglePoints(point1, point2, point3);
				body = new Rect(new Point(0, ArrowPointHeight), new Point(total.Width, total.Height));
			}
			if (ArrowDirection == ToolTipDirection.Right)
			{
				var startY = (total.Height - ArrowBaseLength) / 2;
				var point1 = new Point(total.Width - ArrowPointHeight, startY);
				var point2 = new Point(total.Width - ArrowPointHeight, startY + ArrowBaseLength);
				var point3 = new Point(total.Width, startY + (ArrowBaseLength / 2));
				arrow = new TrianglePoints(point1, point2, point3);
				body = new Rect(new Point(0, 0), new Point(total.Width - ArrowPointHeight, total.Height));
			}
			if (ArrowDirection == ToolTipDirection.Bottom)
			{
				var startX = (total.Width - ArrowBaseLength) / 2;
				var point1 = new Point(startX, Height - ArrowPointHeight);
				var point2 = new Point(startX + ArrowBaseLength, total.Height - ArrowPointHeight);
				var point3 = new Point(startX + (ArrowBaseLength / 2), total.Height);
				arrow = new TrianglePoints(point1, point2, point3);
				body = new Rect(new Point(0, 0), new Point(total.Width, total.Height - ArrowPointHeight));
			}
			return new ToolTipGeometry(body, arrow);
		}

		#endregion
	}

}
