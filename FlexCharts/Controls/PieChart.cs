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
using FlexCharts.Controls.Core;
using FlexCharts.Controls.Primitives;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.Helpers;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Layout;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexCharts.Controls
{
	[TemplatePart(Name = "PART_content", Type = typeof(DockPanel))]
	[TemplatePart(Name = "PART_title", Type = typeof(Label))]
	[TemplatePart(Name = "PART_main", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_segments", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_categorylabels", Type = typeof(Grid))]
	public class PieChart : AbstractFlexChart<DoubleSeries>,
		IValueContract, IFocusableSegmentContract, IPolarLabelingContract, IBarTotalContract//, IStateSegmentContract
	{
		#region Dependency Properties
		#region			CircularContract
		public static readonly DependencyProperty CircleScaleProperty = DP.Add(CircularPrimitive.CircleScaleProperty,
			new Meta<PieChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty AngleOffsetProperty = DP.Add(CircularPrimitive.AngleOffsetProperty,
			new Meta<PieChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public double CircleScale
		{
			get { return (double)GetValue(CircleScaleProperty); }
			set { SetValue(CircleScaleProperty, value); }
		}
		public double AngleOffset
		{
			get { return (double)GetValue(AngleOffsetProperty); }
			set { SetValue(AngleOffsetProperty, value); }
		}
		#endregion

		#region			BarTotalContract
		public static readonly DependencyProperty BarTotalFontFamilyProperty = DP.Add(BarTotalPrimitive.BarTotalFontFamilyProperty,
			new Meta<PieChart, FontFamily> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStyleProperty = DP.Add(BarTotalPrimitive.BarTotalFontStyleProperty,
			new Meta<PieChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontWeightProperty = DP.Add(BarTotalPrimitive.BarTotalFontWeightProperty,
			new Meta<PieChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStretchProperty = DP.Add(BarTotalPrimitive.BarTotalFontStretchProperty,
			new Meta<PieChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontSizeProperty = DP.Add(BarTotalPrimitive.BarTotalFontSizeProperty,
			new Meta<PieChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalForegroundProperty = DP.Add(BarTotalPrimitive.BarTotalForegroundProperty,
			new Meta<PieChart, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public FontFamily BarTotalFontFamily
		{
			get { return (FontFamily)GetValue(BarTotalFontFamilyProperty); }
			set { SetValue(BarTotalFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle BarTotalFontStyle
		{
			get { return (FontStyle)GetValue(BarTotalFontStyleProperty); }
			set { SetValue(BarTotalFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight BarTotalFontWeight
		{
			get { return (FontWeight)GetValue(BarTotalFontWeightProperty); }
			set { SetValue(BarTotalFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch BarTotalFontStretch
		{
			get { return (FontStretch)GetValue(BarTotalFontStretchProperty); }
			set { SetValue(BarTotalFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double BarTotalFontSize
		{
			get { return (double)GetValue(BarTotalFontSizeProperty); }
			set { SetValue(BarTotalFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor BarTotalForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(BarTotalForegroundProperty); }
			set { SetValue(BarTotalForegroundProperty, value); }
		}
		#endregion

		#region			ValueContact
		public static readonly DependencyProperty ValueFontFamilyProperty = DP.Add(ValuePrimitive.ValueFontFamilyProperty,
			new Meta<PieChart, FontFamily> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStyleProperty = DP.Add(ValuePrimitive.ValueFontStyleProperty,
			new Meta<PieChart, FontStyle> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontWeightProperty = DP.Add(ValuePrimitive.ValueFontWeightProperty,
			new Meta<PieChart, FontWeight> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStretchProperty = DP.Add(ValuePrimitive.ValueFontStretchProperty,
			new Meta<PieChart, FontStretch> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontSizeProperty = DP.Add(ValuePrimitive.ValueFontSizeProperty,
			new Meta<PieChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueForegroundProperty = DP.Add(ValuePrimitive.ValueForegroundProperty,
			new Meta<PieChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public FontFamily ValueFontFamily
		{
			get { return (FontFamily)GetValue(ValueFontFamilyProperty); }
			set { SetValue(ValueFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle ValueFontStyle
		{
			get { return (FontStyle)GetValue(ValueFontStyleProperty); }
			set { SetValue(ValueFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight ValueFontWeight
		{
			get { return (FontWeight)GetValue(ValueFontWeightProperty); }
			set { SetValue(ValueFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch ValueFontStretch
		{
			get { return (FontStretch)GetValue(ValueFontStretchProperty); }
			set { SetValue(ValueFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double ValueFontSize
		{
			get { return (double)GetValue(ValueFontSizeProperty); }
			set { SetValue(ValueFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor ValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(ValueForegroundProperty); }
			set { SetValue(ValueForegroundProperty, value); }
		}
		#endregion

		#region			SegmentFocusableContract
		public static readonly DependencyProperty FocusedSegmentProperty = DP.Add(FocusableSegmentPrimitive.FocusedSegmentProperty,
			new Meta<PieChart, Shape>(null, FocusedSegmentChanged) { Flags = INH });

		[Category("Charting")]
		public Shape FocusedSegment
		{
			get { return (Shape)GetValue(FocusedSegmentProperty); }
			set { SetValue(FocusedSegmentProperty, value); }
		}
		#endregion

		#region			PolarLabelingContract
		public static readonly DependencyProperty HorizontalLabelPositionSkewProperty = DP.Add(PolarLabelingPrimitive.HorizontalLabelPositionSkewProperty,
			new Meta<PieChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty OuterLabelPositionScaleProperty = DP.Add(PolarLabelingPrimitive.OuterLabelPositionScaleProperty,
			new Meta<PieChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public double HorizontalLabelPositionSkew
		{
			get { return (double)GetValue(HorizontalLabelPositionSkewProperty); }
			set { SetValue(HorizontalLabelPositionSkewProperty, value); }
		}
		[Category("Charting")]
		public double OuterLabelPositionScale
		{
			get { return (double)GetValue(OuterLabelPositionScaleProperty); }
			set { SetValue(OuterLabelPositionScaleProperty, value); }
		}
		#endregion

		//#region			StateSegmentContract
		//public static readonly DependencyProperty ActiveFillProperty = DP.Add(StateSegmentPrimative.ActiveFillProperty,
		//	new Meta<PieChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		//public static readonly DependencyProperty ActiveStrokeThicknessProperty = DP.Add(StateSegmentPrimative.ActiveStrokeThicknessProperty,
		//	new Meta<PieChart, int> { Flags = INH }, DPExtOptions.ForceManualInherit);

		//public static readonly DependencyProperty ActiveStrokeProperty = DP.Add(StateSegmentPrimative.ActiveStrokeProperty,
		//	new Meta<PieChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		//public static readonly DependencyProperty InactiveFillProperty = DP.Add(StateSegmentPrimative.InactiveFillProperty,
		//	new Meta<PieChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		//public static readonly DependencyProperty InactiveStrokeThicknessProperty = DP.Add(StateSegmentPrimative.InactiveStrokeThicknessProperty,
		//	new Meta<PieChart, int> { Flags = INH }, DPExtOptions.ForceManualInherit);

		//public static readonly DependencyProperty InactiveStrokeProperty = DP.Add(StateSegmentPrimative.InactiveStrokeProperty,
		//	new Meta<PieChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		//[Category("Charting")]
		//public AbstractMaterialDescriptor ActiveFill
		//{
		//	get { return (AbstractMaterialDescriptor)GetValue(ActiveFillProperty); }
		//	set { SetValue(ActiveFillProperty, value); }
		//}
		//[Category("Charting")]
		//public int ActiveStrokeThickness
		//{
		//	get { return (int)GetValue(ActiveStrokeThicknessProperty); }
		//	set { SetValue(ActiveStrokeThicknessProperty, value); }
		//}
		//[Category("Charting")]
		//public AbstractMaterialDescriptor ActiveStroke
		//{
		//	get { return (AbstractMaterialDescriptor)GetValue(ActiveStrokeProperty); }
		//	set { SetValue(ActiveStrokeProperty, value); }
		//}
		//[Category("Charting")]
		//public AbstractMaterialDescriptor InactiveFill
		//{
		//	get { return (AbstractMaterialDescriptor)GetValue(InactiveFillProperty); }
		//	set { SetValue(InactiveFillProperty, value); }
		//}
		//[Category("Charting")]
		//public int InactiveStrokeThickness
		//{
		//	get { return (int)GetValue(InactiveStrokeThicknessProperty); }
		//	set { SetValue(InactiveStrokeThicknessProperty, value); }
		//}
		//[Category("Charting")]
		//public AbstractMaterialDescriptor InactiveStroke
		//{
		//	get { return (AbstractMaterialDescriptor)GetValue(InactiveStrokeProperty); }
		//	set { SetValue(InactiveStrokeProperty, value); }
		//}
		//#endregion
		#endregion

		#region Dependency Property Callbacks
		private static void FocusedSegmentChanged(PieChart i, DPChangedEventArgs<Shape> e)
		{
			i.animateSegmentRefocus();
		}
		#endregion

		#region Fields
		protected DockPanel PART_content;
		protected Label PART_title;
		protected Grid PART_main;
		protected Grid PART_segments;
		protected Grid PART_categorylabels;
		#endregion

		#region Constructors
		static PieChart()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PieChart), new FrameworkPropertyMetadata(typeof(PieChart)));
			TitleProperty.OverrideMetadata(typeof(PieChart), new FrameworkPropertyMetadata("Pie Chart"));
		}

		public PieChart()
		{
			//var rotateTransform = new RotateTransform(0, .5, .5);
			//_segments.RenderTransform = rotateTransform;
			//BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding("AngleOffset") { Source = this });
			//_main.Children.Add(_segments);
			//_main.Children.Add(_categoryLabels);

			Loaded += onLoaded;
		}
		#endregion

		#region Methods
		private void onLoaded(object i, RoutedEventArgs e)
		{
			focusLargestDataPoint();
		}

		private void focusLargestDataPoint()
		{
			if (Data.Count < 1) return;
			CategoricalDouble[] maxrsp = { Data[0] };
			foreach (var d in Data.Where(d =>
				d.RenderedVisual.RequireType<ArcPath>().ArcAngle > maxrsp[0].RenderedVisual.RequireType<ArcPath>().ArcAngle))
			{
				maxrsp[0] = d;
			}

			FocusedSegment = maxrsp[0].RenderedVisual.RequireType<ArcPath>();
		}

		private void animateSegmentRefocus()
		{
			animateTextSwap();
			var ringSpinTimer = new DispatcherTimer
			{
				Interval = TimeSpan.FromMilliseconds(200)
			};
			ringSpinTimer.Tick += (s, e) =>
			{
				ringSpinTimer.Stop();
				animateAngularOffset();
			};
			ringSpinTimer.Start();
		}

		private void animateTextSwap()
		{
			PART_categorylabels.BeginAnimation(OpacityProperty, new DoubleAnimationUsingKeyFrames
			{
				KeyFrames = new DoubleKeyFrameCollection
				{
					new SplineDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))),
					new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(100))),
					new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(900))),
					new SplineDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(1000)))
				},
				AccelerationRatio = AnimationParameters.AccelerationRatio,
				DecelerationRatio = AnimationParameters.DecelerationRatio
			});
		}

		private void animateAngularOffset()
		{
			var angle = FocusedSegment.RequireType<ArcPath>().CalculateAngularOffset();
			BeginAnimation(AngleOffsetProperty, new DoubleAnimation(angle,
				new Duration(TimeSpan.FromMilliseconds(600)))
			{
				AccelerationRatio = AnimationParameters.AccelerationRatio,
				DecelerationRatio = AnimationParameters.DecelerationRatio
			});
		}

		//private void renderCategoryLabels()
		//{
		//	if (FocusedSegment == null)
		//	{
		//		return;
		//	}
		//	var context = new ProviderContext(Data.Count);
		//	MaterialProvider.Reset(context);
		//	_categoryLabels.Children.Clear();
		//	var diameter = _segments.RenderSize.Smallest() * CircleScale;

		//	var outerLabelRadius = (diameter / 2) * OuterLabelPositionScale;
		//	var overlayedLabelRadius = (diameter / 2) * .7;

		//	var targetAngularOffset = FocusedSegment.RequireType<ArcPath>().CalculateAngularOffset();

		//	foreach (var d in Data)
		//	{
		//		var materialSet = MaterialProvider.ProvideNext(context);
		//		var categoryNameLabel = positionLabel(d, outerLabelRadius, targetAngularOffset, true);

		//		categoryNameLabel.Content = d.CategoryName;
		//		categoryNameLabel.BindTextualPrimitive<BarTotalPrimitive>(this);
		//		categoryNameLabel.Foreground = BarTotalForeground.GetMaterial(materialSet);
		//		_categoryLabels.Children.Add(categoryNameLabel);


		//		var valueLabel = positionLabel(d, overlayedLabelRadius, targetAngularOffset);

		//		valueLabel.Content = d.Value;
		//		valueLabel.BindTextualPrimitive<ValuePrimitive>(this);
		//		valueLabel.Foreground = ValueForeground.GetMaterial(materialSet);
		//		_categoryLabels.Children.Add(valueLabel);
		//	}
		//}

		private Label positionLabel(CategoricalDouble d, double radius, double targetAngularOffset,
			bool horizontalPositionSkew = false)
		{
			var categoryLabel = new Label
			{
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center,
				IsHitTestVisible = false
			};

			var pretransformedOffset = d.RenderedVisual.RequireType<ArcPath>().PolarOffset;
			var arcAngle = d.RenderedVisual.RequireType<ArcPath>().ArcAngle;
			var pretransformedLabelAngle = pretransformedOffset + (arcAngle / 2);
			var actualLabelAngle = pretransformedLabelAngle - targetAngularOffset;

			var horizontalLabelSkew = horizontalPositionSkew
				? Math.Cos(CoordinateHelpers.ToRadian(actualLabelAngle)) * HorizontalLabelPositionSkew
				: 0;

			var labelRadius = radius;
			var polarPoint = new PolarPoint(actualLabelAngle, labelRadius);
			var labelCoordinate = polarPoint.ToCartesian();
			categoryLabel.Margin = new Thickness(labelCoordinate.X + horizontalLabelSkew, -labelCoordinate.Y,
				-labelCoordinate.X - horizontalLabelSkew, labelCoordinate.Y);
			return categoryLabel;
		}

		#endregion

		#region Overrided Methods
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_content = GetTemplateChild<DockPanel>(nameof(PART_content));
			PART_title = GetTemplateChild<Label>(nameof(PART_title));
			PART_main = GetTemplateChild<Grid>(nameof(PART_main));
			PART_segments = GetTemplateChild<Grid>(nameof(PART_segments));
			PART_categorylabels = GetTemplateChild<Grid>(nameof(PART_categorylabels));
		}
		protected override void OnRender(DrawingContext drawingContext)
		{
			PART_segments.Children.Clear();

			var context = new ProviderContext(Data.Count);
			MaterialProvider.Reset(context);

			var radius = (PART_segments.RenderSize.Smallest() * CircleScale) / 2;

			var total = Data.SumValue();
			var angleTrace = 0d;
			var actualRingWidth = radius;
			foreach (var d in Data)
			{
				var materialSet = MaterialProvider.ProvideNext(context);
				var degrees = (d.Value / total) * 360;

				var activePath = new ArcPath(degrees, angleTrace, actualRingWidth, CircleScale, radius, PART_segments.RenderSize, d)
				{
					Fill = SegmentForeground.GetMaterial(materialSet),
					MouseOverFill = materialSet.GetMaterial(Luminosity.P700),
					DataContext = this
				};
				activePath.Click += segmentClicked;
				PART_segments.Children.Add(activePath);
				d.RenderedVisual = activePath;
				angleTrace += degrees;
			}
			if (FocusedSegment == null)
			{
				return;
			}
			PART_categorylabels.Children.Clear();
			var diameter = PART_segments.RenderSize.Smallest() * CircleScale;

			var outerLabelRadius = (diameter / 2) * OuterLabelPositionScale;
			var overlayedLabelRadius = (diameter / 2) - (actualRingWidth / 2);

			var targetAngularOffset = FocusedSegment.RequireType<ArcPath>().CalculateAngularOffset();
			MaterialProvider.Reset(context);
			foreach (var d in Data)
			{
				var materialSet = MaterialProvider.ProvideNext(context);

				var categoryNameLabel = positionLabel(d, outerLabelRadius, targetAngularOffset, true);

				categoryNameLabel.Content = d.CategoryName;
				categoryNameLabel.BindTextualPrimitive<BarTotalPrimitive>(this);
				categoryNameLabel.Foreground = BarTotalForeground.GetMaterial(materialSet);
				PART_categorylabels.Children.Add(categoryNameLabel);

				var valueLabel = positionLabel(d, overlayedLabelRadius, targetAngularOffset);

				valueLabel.Content = d.Value;
				valueLabel.BindTextualPrimitive<ValuePrimitive>(this);
				valueLabel.Foreground = ValueForeground.GetMaterial(materialSet);
				PART_categorylabels.Children.Add(valueLabel);
			}
			base.OnRender(drawingContext);

			//var context = new ProviderContext(Data.Count);
			//MaterialProvider.Reset(context);

			//var radius = (PART_segments.RenderSize.Smallest() * CircleScale) / 2;

			//var total = Data.SumValue();
			//var angleTrace = 0d;

			//foreach (var d in Data)
			//{
			//	var materialSet = MaterialProvider.ProvideNext(context);

			//	var degrees = (d.Value / total) * 360;
			//	//TODO PiePath
			//	var activePath = new ArcPath(degrees, angleTrace, radius, CircleScale, radius, PART_segments.RenderSize, d)
			//	{
			//		Fill = SegmentForeground.GetMaterial(materialSet),
			//		MouseOverFill = materialSet.GetMaterial(Luminosity.P700),
			//		DataContext = this
			//	};

			//	// TODO FIX this
			//	//activePath.SetBinding(Shape.StrokeProperty, new Binding("SegmentStroke"));
			//	//activePath.SetBinding(Shape.StrokeThicknessProperty, new Binding("SegmentStrokeThickness"));
			//	activePath.Click += segmentClicked;

			//	PART_segments.Children.Add(activePath);

			//	d.RenderedVisual = activePath;

			//	angleTrace += degrees;
			//}
			//renderCategoryLabels();
			//base.OnRender(drawingContext);
		}

		private void segmentClicked(object s, RoutedEventArgs e)
		{
			FocusedSegment = s.RequireType<ArcPath>();
			OnSegmentClicked();
		}

		public override void OnSegmentClicked()
		{

			base.OnSegmentClicked();
		}

		#endregion
	}
}
