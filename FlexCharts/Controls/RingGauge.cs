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
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Primatives;
using FlexCharts.CustomGeometry;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls
{

	public class RingGauge : AbstractFlexChart<double>, ICircularContract, IStateSegmentContract, ISegmentContract //IRingAspect//
  {
		#region Dependency Properties
		#region			CircularContract
		public static readonly DependencyProperty CircleScaleProperty = DP.Add(CircularPrimative.CircleScaleProperty,
			new Meta<RingGauge, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty AngleOffsetProperty = DP.Add(CircularPrimative.AngleOffsetProperty,
			new Meta<RingGauge, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

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

		#region			StateSegmentContract
		public static readonly DependencyProperty ActiveFillProperty = DP.Add(StateSegmentPrimative.ActiveFillProperty,
			new Meta<RingGauge, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ActiveStrokeThicknessProperty = DP.Add(StateSegmentPrimative.ActiveStrokeThicknessProperty,
			new Meta<RingGauge, int> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ActiveStrokeProperty = DP.Add(StateSegmentPrimative.ActiveStrokeProperty,
			new Meta<RingGauge, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty InactiveFillProperty = DP.Add(StateSegmentPrimative.InactiveFillProperty,
			new Meta<RingGauge, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty InactiveStrokeThicknessProperty = DP.Add(StateSegmentPrimative.InactiveStrokeThicknessProperty,
			new Meta<RingGauge, int> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty InactiveStrokeProperty = DP.Add(StateSegmentPrimative.InactiveStrokeProperty,
			new Meta<RingGauge, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public AbstractMaterialDescriptor ActiveFill
		{
			get { return (AbstractMaterialDescriptor)GetValue(ActiveFillProperty); }
			set { SetValue(ActiveFillProperty, value); }
		}
		[Category("Charting")]
		public int ActiveStrokeThickness
		{
			get { return (int)GetValue(ActiveStrokeThicknessProperty); }
			set { SetValue(ActiveStrokeThicknessProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor ActiveStroke
		{
			get { return (AbstractMaterialDescriptor)GetValue(ActiveStrokeProperty); }
			set { SetValue(ActiveStrokeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor InactiveFill
		{
			get { return (AbstractMaterialDescriptor)GetValue(InactiveFillProperty); }
			set { SetValue(InactiveFillProperty, value); }
		}
		[Category("Charting")]
		public int InactiveStrokeThickness
		{
			get { return (int)GetValue(InactiveStrokeThicknessProperty); }
			set { SetValue(InactiveStrokeThicknessProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor InactiveStroke
		{
			get { return (AbstractMaterialDescriptor)GetValue(InactiveStrokeProperty); }
			set { SetValue(InactiveStrokeProperty, value); }
		}
		#endregion
		
		#region			SegmentContract
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty = DP.Add(SegmentPrimative.SegmentSpaceBackgroundProperty,
			new Meta<RingGauge, AbstractMaterialDescriptor> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SegmentWidthPercentageProperty = DP.Add(SegmentPrimative.SegmentWidthPercentageProperty,
			new Meta<RingGauge, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);


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

		public static readonly DependencyProperty RingForegroundProperty = DP.Register(
			new Meta<RingGauge, AbstractMaterialDescriptor>(MaterialPalette.Descriptors.P500Descriptor));

		public AbstractMaterialDescriptor RingForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(RingForegroundProperty); }
			set { SetValue(RingForegroundProperty, value); }
		}
		#endregion

		#region Properties
		//public override IMaterialProvider MaterialProvider { get; set; } = SequentialMaterialProvider.RainbowPaletteOrder;
		#endregion

		#region Fields
		protected readonly Grid _segments = new Grid
		{
			RenderTransformOrigin = new Point(.5, .5),
		};
		protected readonly Label _valueLabel = new Label
		{
			HorizontalContentAlignment = HorizontalAlignment.Center,
			VerticalContentAlignment = VerticalAlignment.Center,
		};
		#endregion

		#region Constructors
		static RingGauge()
		{
			TitleProperty.OverrideMetadata(typeof(RingGauge), new FrameworkPropertyMetadata("Ring Gauge"));
		}
		public RingGauge()
		{
			var rotateTransform = new RotateTransform(0, .5, .5);
			_segments.RenderTransform = rotateTransform;
			BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding("AngleOffset") { Source = this });

			_main.Children.Add(_segments);
			_main.Children.Add(_valueLabel);

			BindingOperations.SetBinding(_valueLabel, ContentProperty, new Binding("Data") { Source = this });
			BindingOperations.SetBinding(_valueLabel, FontFamilyProperty, new Binding("FontFamily") { Source = this });
			BindingOperations.SetBinding(_valueLabel, FontStyleProperty, new Binding("FontStyle") { Source = this });
			BindingOperations.SetBinding(_valueLabel, FontWeightProperty, new Binding("FontWeight") { Source = this });
			BindingOperations.SetBinding(_valueLabel, FontSizeProperty, new Binding("FontSize") { Source = this });
			BindingOperations.SetBinding(_valueLabel, ForegroundProperty, new Binding("Foreground") { Source = this });
		}
		#endregion

		#region Overrided Methods
		protected override void OnRender(DrawingContext drawingContext)
		{
			_segments.Children.Clear();

			var angle = Data.Map(0, 100, 0, 360);

			var radius = (_segments.RenderSize.Smallest() * CircleScale) / 2;
			var segmentWidth = radius * SegmentWidthPercentage;
			var inactivePath = new ArcPath(359.999, 0, segmentWidth, CircleScale, radius, _segments.RenderSize, null)
			{
				DataContext = this
			};
			var activePath = new ArcPath(angle, AngleOffset, segmentWidth, CircleScale, radius, _segments.RenderSize, Data)
			{
				DataContext = this
			};
			inactivePath.Fill = SegmentSpaceBackground.GetMaterial(FallbackMaterialSet);
			activePath.Fill = RingForeground.GetMaterial(FallbackMaterialSet);
			//inactivePath.SetBinding(Shape.FillProperty, new Binding("SegmentSpaceBackground"));
			//activePath.SetBinding(Shape.FillProperty, new Binding("RingForeground"));

			_segments.Children.Add(inactivePath);
			_segments.Children.Add(activePath);

			base.OnRender(drawingContext);
		}
		#endregion
	}
}