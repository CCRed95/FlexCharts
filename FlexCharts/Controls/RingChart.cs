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
	//TODO custom [AspectOwnerAttribute(typeof(IAspect))]
	// TODO better label/size rendering with predictive text rendering 
	public class RingChart : AbstractFlexChart<DoubleSeries>, ICircularContract, IRingContract, IPolarLabelingContract, IFocusableSegmentContract, IBarTotalContract
	{
		#region Dependency Properties
		#region			CircularContract
		public static readonly DependencyProperty CircleScaleProperty = DP.Add(CircularPrimitive.CircleScaleProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty AngleOffsetProperty = DP.Add(CircularPrimitive.AngleOffsetProperty,
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

		#region			BarTotalContract
		public static readonly DependencyProperty BarTotalFontFamilyProperty = DP.Add(BarTotalPrimitive.BarTotalFontFamilyProperty,
			new Meta<RingChart, FontFamily> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStyleProperty = DP.Add(BarTotalPrimitive.BarTotalFontStyleProperty,
			new Meta<RingChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontWeightProperty = DP.Add(BarTotalPrimitive.BarTotalFontWeightProperty,
			new Meta<RingChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStretchProperty = DP.Add(BarTotalPrimitive.BarTotalFontStretchProperty,
			new Meta<RingChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontSizeProperty = DP.Add(BarTotalPrimitive.BarTotalFontSizeProperty,
			new Meta<RingChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalForegroundProperty = DP.Add(BarTotalPrimitive.BarTotalForegroundProperty,
			new Meta<RingChart, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

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

		#region			ValueContract
		public static readonly DependencyProperty ValueFontFamilyProperty = DP.Add(ValuePrimitive.ValueFontFamilyProperty,
			new Meta<ParetoChart, FontFamily> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStyleProperty = DP.Add(ValuePrimitive.ValueFontStyleProperty,
			new Meta<ParetoChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontWeightProperty = DP.Add(ValuePrimitive.ValueFontWeightProperty,
			new Meta<ParetoChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStretchProperty = DP.Add(ValuePrimitive.ValueFontStretchProperty,
			new Meta<ParetoChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontSizeProperty = DP.Add(ValuePrimitive.ValueFontSizeProperty,
			new Meta<ParetoChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueForegroundProperty = DP.Add(ValuePrimitive.ValueForegroundProperty,
			new Meta<ParetoChart, AbstractMaterialDescriptor> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);


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
		
		#region			SecondaryValueContract
		public static readonly DependencyProperty SecondaryValueFontFamilyProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontFamilyProperty,
			new Meta<RingChart, FontFamily>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontStyleProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontStyleProperty,
			new Meta<RingChart, FontStyle>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontWeightProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontWeightProperty,
			new Meta<RingChart, FontWeight>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontStretchProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontStretchProperty,
			new Meta<RingChart, FontStretch>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontSizeProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontSizeProperty,
			new Meta<RingChart, double>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueForegroundProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueForegroundProperty,
			new Meta<RingChart, AbstractMaterialDescriptor>{ Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public FontFamily SecondaryValueFontFamily
		{
			get { return (FontFamily)GetValue(SecondaryValueFontFamilyProperty); }
			set { SetValue(SecondaryValueFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle SecondaryValueFontStyle
		{
			get { return (FontStyle)GetValue(SecondaryValueFontStyleProperty); }
			set { SetValue(SecondaryValueFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight SecondaryValueFontWeight
		{
			get { return (FontWeight)GetValue(SecondaryValueFontWeightProperty); }
			set { SetValue(SecondaryValueFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch SecondaryValueFontStretch
		{
			get { return (FontStretch)GetValue(SecondaryValueFontStretchProperty); }
			set { SetValue(SecondaryValueFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double SecondaryValueFontSize
		{
			get { return (double)GetValue(SecondaryValueFontSizeProperty); }
			set { SetValue(SecondaryValueFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor SecondaryValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SecondaryValueForegroundProperty); }
			set { SetValue(SecondaryValueForegroundProperty, value); }
		}
		#endregion

		#region			FocusableSegmentContract
		public static readonly DependencyProperty FocusedSegmentProperty = DP.Add(FocusableSegmentPrimitive.FocusedSegmentProperty,
			new Meta<RingChart, Shape>(null, FocusedSegmentChanged) { Flags = INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public Shape FocusedSegment
		{
			get { return (Shape)GetValue(FocusedSegmentProperty); }
			set { SetValue(FocusedSegmentProperty, value); }
		}
		#endregion

		#region			RingContract
		public static readonly DependencyProperty RingWidthPercentageProperty = DP.Add(RingPrimitive.RingWidthPercentageProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public double RingWidthPercentage
		{
			get { return (double)GetValue(RingWidthPercentageProperty); }
			set { SetValue(RingWidthPercentageProperty, value); }
		}
		#endregion

		#region			PolarLabelingContract
		public static readonly DependencyProperty HorizontalLabelPositionSkewProperty = DP.Add(PolarLabelingPrimitive.HorizontalLabelPositionSkewProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty OuterLabelPositionScaleProperty = DP.Add(PolarLabelingPrimitive.OuterLabelPositionScaleProperty,
			new Meta<RingChart, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

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
			_focusedSegmentValueLabel.BindTextualPrimitive<SecondaryValuePrimitive>(this);

			_focusedSegmentValueLabel.DataContext = this;
			_focusedSegmentValueLabel.SetBinding(ContentControl.ContentProperty, new Binding("FocusedSegment.DataPoint.Value"));

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

		private Label positionLabel(CategoricalDouble d, double radius, double targetAngularOffset, bool horizontalPositionSkew = false)
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
			_focusedSegmentValueLabel.Foreground = SecondaryValueForeground.GetMaterial(FallbackMaterialSet);
			_segments.Children.Clear();

			var context = new ProviderContext(Data.Count);
			MaterialProvider.Reset(context);

			var radius = (_segments.RenderSize.Smallest() * CircleScale) / 2;

			var total = Data.SumValue();
			var angleTrace = 0d;
			var actualRingWidth = radius * RingWidthPercentage; 
			foreach (var d in Data)
			{
				var materialSet = MaterialProvider.ProvideNext(context);
				var degrees = (d.Value / total) * 360;
				
				var activePath = new ArcPath(degrees, angleTrace, actualRingWidth, CircleScale, radius, _segments.RenderSize, d)
				{
					Fill = SegmentForeground.GetMaterial(materialSet),
					MouseOverFill = materialSet.GetMaterial(Luminosity.P700),
					DataContext = this
				};
				activePath.Click += segmentClicked;
				_segments.Children.Add(activePath); 
				d.RenderedVisual = activePath;
				angleTrace += degrees;
			}
			if (FocusedSegment == null)
			{
				return;
			}
			_categoryLabels.Children.Clear();
			var diameter = _segments.RenderSize.Smallest() * CircleScale;

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
				_categoryLabels.Children.Add(categoryNameLabel);

				var valueLabel = positionLabel(d, overlayedLabelRadius, targetAngularOffset);

				valueLabel.Content = d.Value;
				valueLabel.BindTextualPrimitive<ValuePrimitive>(this);
				valueLabel.Foreground = ValueForeground.GetMaterial(materialSet);
				_categoryLabels.Children.Add(valueLabel);
			}
			base.OnRender(drawingContext);
		}

		private void segmentClicked(object s, RoutedEventArgs e)
		{
			var arc = s.RequireType<ArcPath>();
			if (!arc.CheckEquality(FocusedSegment.RequireType<ArcPath>()))
			{
				FocusedSegment = arc;
			}
			
			//OnSegmentClicked();
		}


		#endregion
	}
}
