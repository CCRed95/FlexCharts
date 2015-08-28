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
using FlexCharts.Controls.Primatives;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Layout;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexCharts.Controls
{
	//TODO custom [AspectOwnerAttribute(typeof(IAspect))]
	// TODO better label/size rendering with predictive text rendering 
	public class RingChart : AbstractFlexChart<CategoricalDataPointDoubleList>, ICircularContract, IRingContract, IPolarLabelingContract, IFocusableSegmentContract
	{
		#region Dependency Properties
		#region			CircularContract
		public static readonly DependencyProperty CircleScaleProperty = DP.Add(CircularPrimative.CircleScaleProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty AngleOffsetProperty = DP.Add(CircularPrimative.AngleOffsetProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

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

		#region			ValueContract
		public static readonly DependencyProperty ValueFontFamilyProperty = DP.Add(ValuePrimative.ValueFontFamilyProperty,
			new Meta<ParetoChart, FontFamily> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStyleProperty = DP.Add(ValuePrimative.ValueFontStyleProperty,
			new Meta<ParetoChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontWeightProperty = DP.Add(ValuePrimative.ValueFontWeightProperty,
			new Meta<ParetoChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStretchProperty = DP.Add(ValuePrimative.ValueFontStretchProperty,
			new Meta<ParetoChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontSizeProperty = DP.Add(ValuePrimative.ValueFontSizeProperty,
			new Meta<ParetoChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueForegroundProperty = DP.Add(ValuePrimative.ValueForegroundProperty,
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);


		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily ValueFontFamily
		{
			get { return (FontFamily)GetValue(ValueFontFamilyProperty); }
			set { SetValue(ValueFontFamilyProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle ValueFontStyle
		{
			get { return (FontStyle)GetValue(ValueFontStyleProperty); }
			set { SetValue(ValueFontStyleProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight ValueFontWeight
		{
			get { return (FontWeight)GetValue(ValueFontWeightProperty); }
			set { SetValue(ValueFontWeightProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch ValueFontStretch
		{
			get { return (FontStretch)GetValue(ValueFontStretchProperty); }
			set { SetValue(ValueFontStretchProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double ValueFontSize
		{
			get { return (double)GetValue(ValueFontSizeProperty); }
			set { SetValue(ValueFontSizeProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor ValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(ValueForegroundProperty); }
			set { SetValue(ValueForegroundProperty, value); }
		}
		#endregion

		#region			FocusableSegmentContract
		public static readonly DependencyProperty FocusedSegmentProperty = DP.Add(FocusableSegmentPrimative.FocusedSegmentProperty,
			new Meta<RingChart, Shape>(null, FocusedSegmentChanged) { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public Shape FocusedSegment
		{
			get { return (Shape)GetValue(FocusedSegmentProperty); }
			set { SetValue(FocusedSegmentProperty, value); }
		}
		#endregion

		#region			RingContract
		public static readonly DependencyProperty RingWidthProperty = DP.Add(RingPrimative.RingWidthProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public double RingWidth
		{
			get { return (double)GetValue(RingWidthProperty); }
			set { SetValue(RingWidthProperty, value); }
		}
		#endregion

		#region			PolarLabelingContract
		public static readonly DependencyProperty HorizontalLabelPositionSkewProperty = DP.Add(PolarLabelingPrimative.HorizontalLabelPositionSkewProperty,
			new Meta<RingChart, double> {Flags = FXR | INH}, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty OuterLabelPositionScaleProperty = DP.Add(PolarLabelingPrimative.OuterLabelPositionScaleProperty,
			new Meta<RingChart, double> {Flags = FXR | INH}, DPExtOptions.ForceManualInherit);
		
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
		#endregion

		#region Dependency Property Callbacks
		private static void FocusedSegmentChanged(RingChart i, DPChangedEventArgs<Shape> e)
		{
			i.animateSegmentRefocus();
		}
		#endregion

		#region Properties
		//public override IMaterialProvider MaterialProvider { get; set; } = GradientMaterialProvider.MaterialRYG;

		//public override AbstractDataSorter<CategoricalDataPointDoubleList> DataSorter { get; set; } = new DescendingDataSorter();
		#endregion

		#region Fields
		protected readonly Grid _categoryLabels = new Grid();
		protected readonly Grid _segments = new Grid
		{
			RenderTransformOrigin = new Point(.5, .5),
		};
		private readonly Label _focusedSegmentValueLabel = new Label
		{
			IsHitTestVisible = false,
			HorizontalContentAlignment = HorizontalAlignment.Center,
			VerticalContentAlignment = VerticalAlignment.Center
		};
		#endregion

		#region Constructors
		static RingChart()
		{
			TitleProperty.OverrideMetadata(typeof(RingChart), new FrameworkPropertyMetadata("Ring Chart"));
		}
		public RingChart()
		{
			var rotateTransform = new RotateTransform(0, .5, .5);
			_segments.RenderTransform = rotateTransform;
			BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding("AngleOffset") { Source = this });

			_main.Children.Add(_segments);
			_main.Children.Add(_focusedSegmentValueLabel);
			_main.Children.Add(_categoryLabels);

			BindingOperations.SetBinding(_focusedSegmentValueLabel, FontFamilyProperty, new Binding("ValueFontFamily") { Source = this });
			BindingOperations.SetBinding(_focusedSegmentValueLabel, FontStyleProperty, new Binding("ValueFontStyle") { Source = this });
			BindingOperations.SetBinding(_focusedSegmentValueLabel, FontWeightProperty, new Binding("ValueFontWeight") { Source = this });
			BindingOperations.SetBinding(_focusedSegmentValueLabel, FontSizeProperty, new Binding("ValueFontSize") { Source = this });
			BindingOperations.SetBinding(_focusedSegmentValueLabel, ForegroundProperty, new Binding("ValueForeground") { Source = this });
			
			_focusedSegmentValueLabel.DataContext = this;
			_focusedSegmentValueLabel.SetBinding(ContentProperty, new Binding("FocusedSegment.DataPoint.Value"));

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
			CategoricalDataPointDouble[] maxrsp = { Data[0] };
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
				s.RequireType<DispatcherTimer>().Stop();
				animateAngularOffset();
			};
			ringSpinTimer.Start();
		}

		private void animateTextSwap()
		{
			_categoryLabels.BeginAnimation(OpacityProperty, new DoubleAnimationUsingKeyFrames
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

		private void renderCategoryLabels()
		{
			if (FocusedSegment == null)
			{
				return;
			}
			_categoryLabels.Children.Clear();
			var diameter = _segments.RenderSize.Smallest() * CircleScale;

			var outerLabelRadius = (diameter / 2) * OuterLabelPositionScale;
			var overlayedLabelRadius = (diameter / 2) - (RingWidth / 2);

			var targetAngularOffset = FocusedSegment.RequireType<ArcPath>().CalculateAngularOffset();

			foreach (var d in Data)
			{
				var categoryNameLabel = positionLabel(d, outerLabelRadius, targetAngularOffset, true);

				categoryNameLabel.Content = d.CategoryName;
				BindingOperations.SetBinding(categoryNameLabel, FontFamilyProperty, new Binding("ValueFontFamily") { Source = this });
				BindingOperations.SetBinding(categoryNameLabel, FontStyleProperty, new Binding("ValueFontStyle") { Source = this });
				BindingOperations.SetBinding(categoryNameLabel, FontWeightProperty, new Binding("ValueFontWeight") { Source = this });
				BindingOperations.SetBinding(categoryNameLabel, FontSizeProperty, new Binding("ValueFontSize") { Source = this });
				BindingOperations.SetBinding(categoryNameLabel, ForegroundProperty, new Binding("ValueForeground") { Source = this });
				//categoryNameLabel.Foreground = d.RenderedVisual.ShouldBeType<ArcPath>().Fill.ShouldBeType<SolidColorBrush>().Lighten(.25);
				_categoryLabels.Children.Add(categoryNameLabel);


				var valueLabel = positionLabel(d, overlayedLabelRadius, targetAngularOffset);

				valueLabel.Content = d.Value;
				BindingOperations.SetBinding(valueLabel, FontFamilyProperty, new Binding("ValueFontFamily") { Source = this });
				BindingOperations.SetBinding(valueLabel, FontStyleProperty, new Binding("ValueFontStyle") { Source = this });
				BindingOperations.SetBinding(valueLabel, FontWeightProperty, new Binding("ValueFontWeight") { Source = this });
				BindingOperations.SetBinding(valueLabel, FontSizeProperty, new Binding("ValueFontSize") { Source = this });
				BindingOperations.SetBinding(valueLabel, ForegroundProperty, new Binding("ValueForeground") { Source = this });

				_categoryLabels.Children.Add(valueLabel);
			}
		}

		private Label positionLabel(CategoricalDataPointDouble d, double radius, double targetAngularOffset, bool horizontalPositionSkew = false)
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

			var horizontalLabelSkew = horizontalPositionSkew ? Math.Cos(CoordinateHelpers.ToRadian(actualLabelAngle)) * HorizontalLabelPositionSkew : 0;

			var labelRadius = radius;
			var polarPoint = new PolarPoint(actualLabelAngle, labelRadius);
			var labelCoordinate = polarPoint.ToCartesian();
			categoryLabel.Margin = new Thickness(labelCoordinate.X + horizontalLabelSkew, -labelCoordinate.Y, -labelCoordinate.X - horizontalLabelSkew, labelCoordinate.Y);
			return categoryLabel;
		}
		#endregion

		#region Overrided Methods
		protected override void OnRender(DrawingContext drawingContext)
		{
			_segments.Children.Clear();

			var context  = new ProviderContext(Data.Count);
			MaterialProvider.Reset(context);

			var radius = (_segments.RenderSize.Smallest() * CircleScale) / 2;

			var total = Data.ValueSum();
			var angleTrace = 0d;

			foreach (var d in Data)
			{
				var degrees = (d.Value / total) * 360;
				var activePath = new ArcPath(degrees, angleTrace, RingWidth, CircleScale, radius, _segments.RenderSize, d);
				var materialSet = MaterialProvider.ProvideNext(context);
				activePath.Fill = materialSet.GetMaterial(Luminosity.P500);
				activePath.MouseOverFill = materialSet.GetMaterial(Luminosity.P700);
				activePath.DataContext = this;
				//path.SetBinding(Shape.StrokeProperty, ewn Binding("SegmentStroke"));
				//path.SetBinding(Shape.StrokeThicknessProperty, new Binding("SegmentStrokeThickness"));
				activePath.Click += segmentClicked;

				_segments.Children.Add(activePath);

				d.RenderedVisual = activePath;

				angleTrace += degrees;
			}
			renderCategoryLabels();
			base.OnRender(drawingContext);
		}

		private void segmentClicked(object s, RoutedEventArgs e)
		{
			FocusedSegment = s.RequireType<ArcPath>();
			//OnSegmentClicked();
		}


		#endregion
	}
}
