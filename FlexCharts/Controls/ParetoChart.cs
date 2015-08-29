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
using FlexCharts.Data.Filtering;
using FlexCharts.Data.Sorting;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.GenerationContext;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexCharts.Controls
{
	public class ParetoChart : AbstractFlexChart<DoubleSeries>,
		IDotContract, ILineContract, IBarTotalContract, ISegmentContract
	// TODO should be valuecontract instead of bartotalcontract?
	{
		#region Dependency Properties
		#region			DotContract
		public static readonly DependencyProperty DotRadiusProperty = DP.Add(DotPrimitive.DotRadiusProperty,
			new Meta<ParetoChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotFillProperty = DP.Add(DotPrimitive.DotFillProperty,
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotStrokeProperty = DP.Add(DotPrimitive.DotStrokeProperty,
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty DotStrokeThicknessProperty = DP.Add(DotPrimitive.DotStrokeThicknessProperty,
			new Meta<ParetoChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);

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
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty LineStrokeThicknessProperty =
			DP.Add(LinePrimitive.LineStrokeThicknessProperty,
				new Meta<ParetoChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);


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

		#region			BarTotalContract
		public static readonly DependencyProperty BarTotalFontFamilyProperty =
			DP.Add(BarTotalPrimitive.BarTotalFontFamilyProperty,
				new Meta<ParetoChart, FontFamily> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStyleProperty =
			DP.Add(BarTotalPrimitive.BarTotalFontStyleProperty,
				new Meta<ParetoChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontWeightProperty =
			DP.Add(BarTotalPrimitive.BarTotalFontWeightProperty,
				new Meta<ParetoChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStretchProperty =
			DP.Add(BarTotalPrimitive.BarTotalFontStretchProperty,
				new Meta<ParetoChart, FontStretch> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontSizeProperty = DP.Add(
			BarTotalPrimitive.BarTotalFontSizeProperty,
			new Meta<ParetoChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalForegroundProperty =
			DP.Add(BarTotalPrimitive.BarTotalForegroundProperty,
				new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);


		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily BarTotalFontFamily
		{
			get { return (FontFamily)GetValue(BarTotalFontFamilyProperty); }
			set { SetValue(BarTotalFontFamilyProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle BarTotalFontStyle
		{
			get { return (FontStyle)GetValue(BarTotalFontStyleProperty); }
			set { SetValue(BarTotalFontStyleProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight BarTotalFontWeight
		{
			get { return (FontWeight)GetValue(BarTotalFontWeightProperty); }
			set { SetValue(BarTotalFontWeightProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch BarTotalFontStretch
		{
			get { return (FontStretch)GetValue(BarTotalFontStretchProperty); }
			set { SetValue(BarTotalFontStretchProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double BarTotalFontSize
		{
			get { return (double)GetValue(BarTotalFontSizeProperty); }
			set { SetValue(BarTotalFontSizeProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor BarTotalForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(BarTotalForegroundProperty); }
			set { SetValue(BarTotalForegroundProperty, value); }
		}
		#endregion

		#region			SegmentContract
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty =
			DP.Add(SegmentPrimitive.SegmentSpaceBackgroundProperty,
				new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SegmentWidthPercentageProperty =
			DP.Add(SegmentPrimitive.SegmentWidthPercentageProperty,
				new Meta<ParetoChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);


		[Category("Charting")]
		public AbstractMaterialDescriptor SegmentSpaceBackground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SegmentSpaceBackgroundProperty); }
			set { SetValue(SegmentSpaceBackgroundProperty, value); }
		}
		[Category("Charting")]
		public double SegmentWidthPercentage
		{
			get { return (double)GetValue(SegmentWidthPercentageProperty); }
			set { SetValue(SegmentWidthPercentageProperty, value); }
		}
		#endregion

		#region			XAxisContract
		public static readonly DependencyProperty XAxisFontFamilyProperty = DP.Add(XAxisPrimitive.XAxisFontFamilyProperty,
			new Meta<ParetoChart, FontFamily> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontStyleProperty = DP.Add(XAxisPrimitive.XAxisFontStyleProperty,
			new Meta<ParetoChart, FontStyle> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontWeightProperty = DP.Add(XAxisPrimitive.XAxisFontWeightProperty,
			new Meta<ParetoChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontStretchProperty = DP.Add(XAxisPrimitive.XAxisFontStretchProperty,
			new Meta<ParetoChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontSizeProperty = DP.Add(XAxisPrimitive.XAxisFontSizeProperty,
			new Meta<ParetoChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisForegroundProperty = DP.Add(XAxisPrimitive.XAxisForegroundProperty,
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily XAxisFontFamily
		{
			get { return (FontFamily)GetValue(XAxisFontFamilyProperty); }
			set { SetValue(XAxisFontFamilyProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle XAxisFontStyle
		{
			get { return (FontStyle)GetValue(XAxisFontStyleProperty); }
			set { SetValue(XAxisFontStyleProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight XAxisFontWeight
		{
			get { return (FontWeight)GetValue(XAxisFontWeightProperty); }
			set { SetValue(XAxisFontWeightProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch XAxisFontStretch
		{
			get { return (FontStretch)GetValue(XAxisFontStretchProperty); }
			set { SetValue(XAxisFontStretchProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double XAxisFontSize
		{
			get { return (double)GetValue(XAxisFontSizeProperty); }
			set { SetValue(XAxisFontSizeProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor XAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(XAxisForegroundProperty); }
			set { SetValue(XAxisForegroundProperty, value); }
		}
		#endregion
		#endregion

		#region Fields
		internal ParetoChartVisualContext visualContext;

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

		static ParetoChart()
		{
			//DataFilterProperty.OverrideMetadata(typeof (ParetoChart), new FrameworkPropertyMetadata(LiteralDataFilter.DialKCategoryFilter));
			DataSorterProperty.OverrideMetadata(typeof(ParetoChart), new FrameworkPropertyMetadata(new DescendingDataSorter()));
			TitleProperty.OverrideMetadata(typeof(ParetoChart), new FrameworkPropertyMetadata("Pareto Chart"));
		}

		public ParetoChart()
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
				categoryVisual.ActiveBarRenderTransformScaleYAnimationAspect?.AnimateTo(animationState);
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
				categoryVisual.ActiveBarRenderTransformScaleYAnimationAspect?.AnimateTo(animationState);
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
			visualContext = new ParetoChartVisualContext();

			_bars.Children.Clear();
			_barLabels.Children.Clear();
			_lineVisual.Children.Clear();
			_xAxisGrid.Children.Clear();
			//_highlightGrid.Children.Clear();

			var max = Data.MaxValue();

			var context = new ProviderContext(Data.Count);
			var barAvailableWidth = (_bars.RenderSize.Width) / Data.Count;
			var barActiveWidth = barAvailableWidth * SegmentWidthPercentage;
			var barLeftSpacing = (barAvailableWidth - barActiveWidth) / 2;
			var barLabelSize = RenderingExtensions.EstimateLabelRenderSize(BarTotalFontFamily, BarTotalFontSize);

			MaterialProvider.Reset(context);

			#region X-Axis Label Generation

			var xtrace = 0;
			foreach (var d in Data)
			{
				var material = MaterialProvider.ProvideNext(context);
				var categoryVisualContext = new ParetoChartCategoryVisualContext();
				var axisLabel = new Label
				{
					Content = d.CategoryName,
					IsHitTestVisible = false,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Bottom,
					Width = barAvailableWidth,
					Margin = new Thickness(barAvailableWidth * xtrace, 0, 0, 0),
					DataContext = this,
					Foreground = XAxisForeground.GetMaterial(material)

				};
				BindingOperations.SetBinding(axisLabel, FontFamilyProperty, new Binding("XAxisFontFamily") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontStyleProperty, new Binding("XAxisFontStyle") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontWeightProperty, new Binding("XAxisFontWeight") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontSizeProperty, new Binding("XAxisFontSize") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontStretchProperty, new Binding("XAxisFontStretch") { Source = this });
				categoryVisualContext.AxisLabel = axisLabel;
				_xAxisGrid.Children.Add(axisLabel);
				visualContext.CategoryVisuals.Add(categoryVisualContext);
				xtrace++;
			}

			#endregion

			MaterialProvider.Reset(context);
			var horizontalTrace = 0d;
			var xAxisHeight = barLabelSize.Height; //_xAxisGrid.ActualHeight;
			var backHeight = _bars.RenderSize.Height - xAxisHeight;
			var trace = 0;
			foreach (var d in Data)
			{
				var currentCategoryVisualContext = visualContext.CategoryVisuals[trace];
				currentCategoryVisualContext.CategoryDataPoint = d;
				//if (barActiveWidth <= 0 || backHeight <= 0) return; //TODO fix
				var material = MaterialProvider.ProvideNext(context);
				currentCategoryVisualContext.CategoryMaterialSet = material;

				var backRectangle = new Rectangle
				{
					Width = barActiveWidth,
					Height = Math.Abs(backHeight),
					VerticalAlignment = VerticalAlignment.Bottom,
					HorizontalAlignment = HorizontalAlignment.Left,
					Fill = SegmentSpaceBackground.GetMaterial(material),
					Margin = new Thickness(horizontalTrace + barLeftSpacing, 0, 0, xAxisHeight)
				};


				currentCategoryVisualContext.InactiveBarVisual = backRectangle;
				_bars.Children.Add(backRectangle);

				var height = d.Value.Map(0, max, 0, _bars.RenderSize.Height - xAxisHeight - barLabelSize.Height);
				var rectangle = new Rectangle
				{
					Width = barActiveWidth,
					Height = Math.Abs(height),
					Fill = SegmentForeground.GetMaterial(material),
					VerticalAlignment = VerticalAlignment.Bottom,
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(horizontalTrace + barLeftSpacing, 0, 0, xAxisHeight),
					RenderTransform = new ScaleTransform(1, 0, .5, 1),
					RenderTransformOrigin = new Point(.5, 1)
				};


				currentCategoryVisualContext.ActiveBarRenderTransformScaleYAnimationAspect =
					new AnimationAspect<double, Transform, DoubleAnimation>(rectangle.RenderTransform,
						ScaleTransform.ScaleYProperty, 0, 1, animationState)
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
						Duration = TimeSpan.FromMilliseconds(800)
					};

				//TODO replace .RenderedVisual pairing method completely
				d.RenderedVisual = rectangle;
				_bars.Children.Add(rectangle);

				#region Bar Value Label Generation

				var beginBarLabelMargin = new Thickness(horizontalTrace, 0, 0, xAxisHeight);
				var actualBarLabelMargin = new Thickness(horizontalTrace, 0, 0, xAxisHeight + height);

				var barLabel = new Label
				{
					Content = d.Value,
					IsHitTestVisible = false,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Bottom,
					Width = barAvailableWidth,
					Foreground = BarTotalForeground.GetMaterial(material)
				};
				BindingOperations.SetBinding(barLabel, FontFamilyProperty, new Binding("BarTotalFontFamily") { Source = this });
				BindingOperations.SetBinding(barLabel, FontStyleProperty, new Binding("BarTotalFontStyle") { Source = this });
				BindingOperations.SetBinding(barLabel, FontWeightProperty, new Binding("BarTotalFontWeight") { Source = this });
				BindingOperations.SetBinding(barLabel, FontSizeProperty, new Binding("BarTotalFontSize") { Source = this });
				BindingOperations.SetBinding(barLabel, FontStretchProperty, new Binding("BarTotalFontStretch") { Source = this });

				currentCategoryVisualContext.BarLabelMarginAnimationAspect = new AnimationAspect
					<Thickness, Label, ThicknessAnimation>(
					barLabel, MarginProperty, beginBarLabelMargin, actualBarLabelMargin, animationState)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio,
					Duration = TimeSpan.FromMilliseconds(800)
				};

				#endregion

				_barLabels.Children.Add(barLabel);
				horizontalTrace += barAvailableWidth;
				trace++;
			}
			var total = Data.SumValue();
			var availableLineGraphSize = new Size(_bars.ActualWidth - (DotRadius * 2),
				_bars.ActualHeight - (DotRadius * 2) - xAxisHeight);
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
				var currentCategoryVisualContext = visualContext.CategoryVisuals[pttrace];
				var nextPoint = new Point(startX + (barAvailableWidth * pttrace), verticalpttrace + xAxisHeight);
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

					visualContext.LineSegmentVisuals.Add(new ParetoChartLineSegmentVisualContext
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

				var beginDotMargin = new Thickness(nextPoint.X, 0, 0, xAxisHeight);
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

				currentCategoryVisualContext.DotMarginAnimationAspect =
					new AnimationAspect<Thickness, Ellipse, ThicknessAnimation>(dot, MarginProperty,
						beginDotMargin, actualDotMargin, animationState)
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
						Duration = TimeSpan.FromMilliseconds(800)
					};

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
				Margin = new Thickness(DotRadius, 0, 0, xAxisHeight + DotRadius),
				Stroke = LineStroke.GetMaterial(FallbackMaterialSet),
			};
			BindingOperations.SetBinding(path, Shape.StrokeThicknessProperty, new Binding("LineStrokeThickness") { Source = this });

			_lineVisual.Children.Add(path);
			base.OnRender(drawingContext);
		}

		#endregion
	}
}