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
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FlexCharts.Animation;
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Primitives;
using FlexCharts.Data.Sorting;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.GenerationContext;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexCharts.Controls
{
	public class LineGraph : AbstractFlexChart<DoubleSeries>, IDotContract, ILineContract
	{
		#region Dependency Properties
		#region			DotContract
		public static readonly DependencyProperty DotRadiusProperty = DP.Add(DotPrimitive.DotRadiusProperty,
			new Meta<LineGraph, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotFillProperty = DP.Add(DotPrimitive.DotFillProperty,
			new Meta<LineGraph, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotStrokeProperty = DP.Add(DotPrimitive.DotStrokeProperty,
			new Meta<LineGraph, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotStrokeThicknessProperty = DP.Add(DotPrimitive.DotStrokeThicknessProperty,
			new Meta<LineGraph, double> { Flags = INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public double DotRadius
		{
			get { return (double)GetValue(DotRadiusProperty); }
			set { SetValue(DotRadiusProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor DotFill
		{
			get { return (AbstractMaterialDescriptor)GetValue(DotFillProperty); }
			set { SetValue(DotFillProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor DotStroke
		{
			get { return (AbstractMaterialDescriptor)GetValue(DotStrokeProperty); }
			set { SetValue(DotStrokeProperty, value); }
		}
		[Category("Charting")]
		public double DotStrokeThickness
		{
			get { return (double)GetValue(DotStrokeThicknessProperty); }
			set { SetValue(DotStrokeThicknessProperty, value); }
		}
		#endregion

		#region			LineContract
		public static readonly DependencyProperty LineStrokeProperty = DP.Add(LinePrimitive.LineStrokeProperty,
			new Meta<LineGraph, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty LineStrokeThicknessProperty =
			DP.Add(LinePrimitive.LineStrokeThicknessProperty,
				new Meta<LineGraph, double> { Flags = INH }, DPExtOptions.ForceManualInherit);


		[Category("Charting")]
		public AbstractMaterialDescriptor LineStroke
		{
			get { return (AbstractMaterialDescriptor)GetValue(LineStrokeProperty); }
			set { SetValue(LineStrokeProperty, value); }
		}
		[Category("Charting")]
		public double LineStrokeThickness
		{
			get { return (double)GetValue(LineStrokeThicknessProperty); }
			set { SetValue(LineStrokeThicknessProperty, value); }
		}

		#endregion
		#endregion

		#region Fields
		internal LineGraphVisualContext visualContext;

		internal AnimationState animationState = AnimationState.Collapsed;

		protected readonly Grid _barLabels = new Grid();
		protected readonly Grid _lineVisual = new Grid();
		//protected readonly Grid _highlightGrid = new Grid();
		protected readonly Grid _xAxisGrid = new Grid()
		{
			VerticalAlignment = VerticalAlignment.Bottom
		};
		protected readonly Grid _bars = new Grid
		{
			RenderTransformOrigin = new Point(.5, .5),
		};
		#endregion

		#region Constructors

		static LineGraph()
		{
			//DataFilterProperty.OverrideMetadata(typeof (LineGraph), new FrameworkPropertyMetadata(LiteralDataFilter.DialKCategoryFilter));
			DataSorterProperty.OverrideMetadata(typeof(LineGraph), new FrameworkPropertyMetadata(new DescendingDataSorter()));
			TitleProperty.OverrideMetadata(typeof(LineGraph), new FrameworkPropertyMetadata("Pareto Chart"));
		}

		public LineGraph()
		{
			_main.Children.Add(_bars);
			_main.Children.Add(_xAxisGrid);
			_main.Children.Add(_barLabels);
			_main.Children.Add(_lineVisual);
			//_main.Children.Add(_highlightGrid);
			Loaded += onLoad;
			
		}

		#endregion

		#region Methods

		private void onLoad(object s, RoutedEventArgs e)
		{
			if (Data?.Count > 0)
			{
				BeginRevealAnimation();
			}
			
		}

		//TODO null checks on all visualContext methods
		public void BeginRevealAnimation()
		{
			if (visualContext == null) return;
			animationState = AnimationState.Final;
			//visualContext.PolyLineStartPointAnimationAspect.BeginTime = TimeSpan.FromMilliseconds(400);
			visualContext.PolyLineStartPointAnimationAspect?.AnimateTo(animationState);
			//	var animationOffset = 0;
			foreach (var categoryVisual in visualContext.CategoryVisuals)
			{
				//categoryVisual.ActiveBarRenderTransformScaleYAnimationAspect.BeginTime = TimeSpan.FromMilliseconds(animationOffset);
				//categoryVisual.ActiveBarRenderTransformScaleYAnimationAspect?.AnimateTo(animationState);
				//categoryVisual.DotMarginAnimationAspect.BeginTime = TimeSpan.FromMilliseconds(400);
				categoryVisual.DotMarginAnimationAspect?.AnimateTo(animationState);
				//categoryVisual.BarLabelMarginAnimationAspect.BeginTime = TimeSpan.FromMilliseconds(400);
				categoryVisual.BarLabelMarginAnimationAspect?.AnimateTo(animationState);
				//	animationOffset += 55;
			}
			foreach (var lineSegmentVisual in visualContext.LineSegmentVisuals)
			{
				//lineSegmentVisual.PointAnimationAspect.BeginTime = TimeSpan.FromMilliseconds(400);
				lineSegmentVisual.PointAnimationAspect?.AnimateTo(animationState);
			}
		}

		public void BeginCollapseAnimation()
		{
			if (visualContext == null) return;
			animationState = AnimationState.Collapsed;
			visualContext.PolyLineStartPointAnimationAspect?.AnimateTo(animationState);
			foreach (var categoryVisual in visualContext.CategoryVisuals)
			{
				categoryVisual.DotMarginAnimationAspect?.AnimateTo(animationState);
				categoryVisual.BarLabelMarginAnimationAspect?.AnimateTo(animationState);
				;
				//categoryVisual.ActiveBarRenderTransformScaleYAnimationAspect?.AnimateTo(animationState);
			}
			foreach (var lineSegmentVisual in visualContext.LineSegmentVisuals)
			{
				lineSegmentVisual.PointAnimationAspect?.AnimateTo(animationState);
			}
		}

		// TODO find a better way to ensure render() call corresponds with animation and bar rendering states, defaults, etc.
		// TODO if bars are shoinwg -> first collapse, then render pass, then reveal animation
		public override void OnDataChanged(DPChangedEventArgs<DoubleSeries> e)
		{
			var oldValueValid = IsValidGraphData(e.OldValue);
			var newValueValid = IsValidGraphData(e.NewValue);
			if (oldValueValid)
			{
				// good -> good
				if (newValueValid)
				{
					//TODO check new and old datasets to see if number of columbns is different. if so, may...
					// TODO ...require background visuals for bars to animate to correct number.
					BeginCollapseAnimation();
					var dispatcherTimer = new DispatcherTimer()
					{
						Interval = TimeSpan.FromMilliseconds(1000)
					};
					dispatcherTimer.Tick += (s, a) =>
					{
						s.RequireType<DispatcherTimer>().Stop();
						//pc.animationState = AnimationState.Final;
						InvalidateMeasure();
						InvalidateVisual();
						BeginRevealAnimation();
					};
					dispatcherTimer.Start();
					//TODO fadeout first
				}
				else
				{
					BeginCollapseAnimation();
				}
			}
			else
			{
				if (newValueValid)
				{
					animationState = AnimationState.Final;
					InvalidateVisual();
					BeginRevealAnimation();
				}
			}

			base.OnDataChanged(e);
		}

		protected static bool IsValidGraphData(object dataPointList)
		{
			var data = dataPointList as DoubleSeries;
			return data?.Count > 1;
		}

		#endregion

		#region Overrided Methods

		protected override void OnRender(DrawingContext drawingContext)
		{
			if (Data.Count < 1)
			{
				base.OnRender(drawingContext);
				return;
			}
			visualContext = new LineGraphVisualContext();

			_bars.Children.Clear();
			_barLabels.Children.Clear();
			_lineVisual.Children.Clear();
			_xAxisGrid.Children.Clear();
			//_highlightGrid.Children.Clear();

			var max = Data.MaxValue();

			var context = new ProviderContext(Data.Count);
			var barAvailableWidth = (_bars.RenderSize.Width) / Data.Count;
			MaterialProvider.Reset(context);

			MaterialProvider.Reset(context);
			var total = Data.SumValue();
			var availableLineGraphSize = new Size(_bars.ActualWidth - (DotRadius * 2),
				_bars.ActualHeight - (DotRadius * 2));
			var startX = (barAvailableWidth / 2) - DotRadius;

			var verticalpttrace = 0d;
			var pttrace = 0;

			var pathSegments = new PathSegmentCollection();
			var pathFigure = new PathFigure
			{
				Segments = pathSegments
			};
			MaterialProvider.Reset(context);

			var isFirstPoint = true;
			foreach (var d in Data)
			{
				var material = MaterialProvider.ProvideNext(context);
				var nextPoint = new Point(startX + (barAvailableWidth * pttrace), verticalpttrace + 0);
				var baseAnimationPoint = new Point(nextPoint.X, 0).LocalizeInCartesianSpace(_lineVisual);
				var actualNextPoint = nextPoint.LocalizeInCartesianSpace(_lineVisual);

				// TODO get rid of this
				var plottedPoint = IsLoaded ? actualNextPoint : baseAnimationPoint;

				if (isFirstPoint)
				{
					visualContext.PolyLineStartPointAnimationAspect = new AnimationAspect<Point, PathFigure, PointAnimation>(
						pathFigure, PathFigure.StartPointProperty, baseAnimationPoint, actualNextPoint, animationState)
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
						Duration = TimeSpan.FromMilliseconds(800),
					};
					isFirstPoint = false;
				}
				else
				{
					var lineSegment = new LineSegment(plottedPoint, true) { IsSmoothJoin = true };
					pathSegments.Add(lineSegment);

					visualContext.LineSegmentVisuals.Add(new LineGraphLineSegmentVisualContext
					{
						PointAnimationAspect =
							new AnimationAspect<Point, LineSegment, PointAnimation>(lineSegment, LineSegment.PointProperty,
								baseAnimationPoint, actualNextPoint, animationState)
							{
								AccelerationRatio = AnimationParameters.AccelerationRatio,
								DecelerationRatio = AnimationParameters.DecelerationRatio,
								Duration = TimeSpan.FromMilliseconds(800)
							}
					});
				}

				var beginDotMargin = new Thickness(nextPoint.X, 0, 0, 0);
				var actualDotMargin = new Thickness(nextPoint.X, 0, 0, nextPoint.Y);

				var dot = new Ellipse
				{
					Width = (DotRadius * 2),
					Height = (DotRadius * 2),
					VerticalAlignment = VerticalAlignment.Bottom,
					HorizontalAlignment = HorizontalAlignment.Left,
					Fill = DotFill.GetMaterial(material),
					Stroke = DotStroke.GetMaterial(material),
				};
				BindingOperations.SetBinding(dot, Shape.StrokeThicknessProperty, new Binding("DotStrokeThickness") { Source = this });

				//currentCategoryVisualContext.DotMarginAnimationAspect =
				//	new AnimationAspect<Thickness, Ellipse, ThicknessAnimation>(dot, MarginProperty,
				//		beginDotMargin, actualDotMargin, animationState)
				//	{
				//		AccelerationRatio = AnimationParameters.AccelerationRatio,
				//		DecelerationRatio = AnimationParameters.DecelerationRatio,
				//		Duration = TimeSpan.FromMilliseconds(800)
				//	};

				_lineVisual.Children.Add(dot);
				Panel.SetZIndex(dot, 50);
				verticalpttrace += d.Value.Map(0, total, 0, availableLineGraphSize.Height);
				pttrace++;
			}

			var path = new Path
			{
				VerticalAlignment = VerticalAlignment.Bottom,
				HorizontalAlignment = HorizontalAlignment.Left,
				Data = new PathGeometry
				{
					Figures = new PathFigureCollection
					{
						pathFigure
					}
				},
				Margin = new Thickness(DotRadius, 0, 0, 0 + DotRadius),
				Stroke = LineStroke.GetMaterial(FallbackMaterialSet),
			};
			BindingOperations.SetBinding(path, Shape.StrokeThicknessProperty, new Binding("LineStrokeThickness") { Source = this });

			_lineVisual.Children.Add(path);
			base.OnRender(drawingContext);
		}

		#endregion
	}
}