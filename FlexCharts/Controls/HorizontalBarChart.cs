using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Core;
using FlexCharts.Controls.Primitives;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.GenerationContext;
using FlexCharts.Helpers;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;

namespace FlexCharts.Controls
{
	[TemplatePart(Name = "PART_content", Type = typeof(DockPanel))]
	[TemplatePart(Name = "PART_title", Type = typeof(Label))]
	[TemplatePart(Name = "PART_main", Type = typeof(DockPanel))]
	[TemplatePart(Name = "PART_yaxis", Type = typeof(UniformGrid))]
	[TemplatePart(Name = "PART_bars", Type = typeof(UniformGrid))]
	public class HorizontalBarChart : AbstractFlexChart<DoubleSeries>, ISegmentContract, IBarTotalContract, IYAxisContract
	{
		#region Dependency Properties
		#region			BarTotalContract
		public static readonly DependencyProperty BarTotalFontFamilyProperty = DP.Add(BarTotalPrimitive.BarTotalFontFamilyProperty,
			new Meta<HorizontalBarChart, FontFamily> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStyleProperty = DP.Add(BarTotalPrimitive.BarTotalFontStyleProperty,
			new Meta<HorizontalBarChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontWeightProperty = DP.Add(BarTotalPrimitive.BarTotalFontWeightProperty,
			new Meta<HorizontalBarChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStretchProperty = DP.Add(BarTotalPrimitive.BarTotalFontStretchProperty,
			new Meta<HorizontalBarChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontSizeProperty = DP.Add(BarTotalPrimitive.BarTotalFontSizeProperty,
			new Meta<HorizontalBarChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalForegroundProperty = DP.Add(BarTotalPrimitive.BarTotalForegroundProperty,
			new Meta<HorizontalBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

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

		#region SegmentContract
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty = DP.Add(SegmentPrimitive.SegmentSpaceBackgroundProperty,
			new Meta<HorizontalBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SegmentWidthPercentageProperty = DP.Add(SegmentPrimitive.SegmentWidthPercentageProperty,
			new Meta<HorizontalBarChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);


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

		#region			YAxisContract
		public static readonly DependencyProperty YAxisFontFamilyProperty = DP.Add(YAxisPrimitive.YAxisFontFamilyProperty,
			new Meta<HorizontalBarChart, FontFamily> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty YAxisFontStyleProperty = DP.Add(YAxisPrimitive.YAxisFontStyleProperty,
			new Meta<HorizontalBarChart, FontStyle> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty YAxisFontWeightProperty = DP.Add(YAxisPrimitive.YAxisFontWeightProperty,
			new Meta<HorizontalBarChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty YAxisFontStretchProperty = DP.Add(YAxisPrimitive.YAxisFontStretchProperty,
			new Meta<HorizontalBarChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty YAxisFontSizeProperty = DP.Add(YAxisPrimitive.YAxisFontSizeProperty,
			new Meta<HorizontalBarChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty YAxisForegroundProperty = DP.Add(YAxisPrimitive.YAxisForegroundProperty,
			new Meta<HorizontalBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontFamilyConverter))]
		public FontFamily YAxisFontFamily
		{
			get { return (FontFamily)GetValue(YAxisFontFamilyProperty); }
			set { SetValue(YAxisFontFamilyProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStyleConverter))]
		public FontStyle YAxisFontStyle
		{
			get { return (FontStyle)GetValue(YAxisFontStyleProperty); }
			set { SetValue(YAxisFontStyleProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontWeightConverter))]
		public FontWeight YAxisFontWeight
		{
			get { return (FontWeight)GetValue(YAxisFontWeightProperty); }
			set { SetValue(YAxisFontWeightProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontStretchConverter))]
		public FontStretch YAxisFontStretch
		{
			get { return (FontStretch)GetValue(YAxisFontStretchProperty); }
			set { SetValue(YAxisFontStretchProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		[TypeConverter(typeof(FontSizeConverter))]
		public double YAxisFontSize
		{
			get { return (double)GetValue(YAxisFontSizeProperty); }
			set { SetValue(YAxisFontSizeProperty, value); }
		}
		[Bindable(true), Category("Charting")]
		public AbstractMaterialDescriptor YAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(YAxisForegroundProperty); }
			set { SetValue(YAxisForegroundProperty, value); }
		}
		#endregion
		#endregion

		#region Fields
		private HorizontalBarChartVisualContext visualContext = new HorizontalBarChartVisualContext();

		protected DockPanel PART_content;
		protected Label PART_title;
		protected DockPanel PART_main;
		protected UniformGrid PART_yaxis;
		protected UniformGrid PART_bars;
		#endregion

		#region Constructors
		static HorizontalBarChart()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(HorizontalBarChart), new FrameworkPropertyMetadata(typeof(HorizontalBarChart)));
			TitleProperty.OverrideMetadata(typeof(HorizontalBarChart), new FrameworkPropertyMetadata("Horizontal Bar Chart"));
		}
		public HorizontalBarChart()
		{
			
			//BindingOperations.SetBinding(_YAxisGrid, UniformGrid.RowsProperty, new Binding("Data.Count") {Source = this});
			//BindingOperations.SetBinding(_bars, UniformGrid.RowsProperty, new Binding("Data.Count") {Source = this});
			
			Loaded += onLoad;
		}
		#endregion

		#region Methods
		private void onLoad(object s, RoutedEventArgs e)
		{
			animateBarReveal();
		}

		private void animateBarReveal()
		{
			//var animationOffset = 0;
			//foreach (var d in Data)
			//{
			//	var renderedShapeList = (List<Shape>)d.RenderedVisual;
			//	foreach (var i in renderedShapeList)
			//	{
			//		var renderedShape = (Shape)i;//.ShouldBeCastable<Shape>();
			//		renderedShape.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty,
			//			new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(600 + (animationOffset / 2))))
			//			{
			//				BeginTime = TimeSpan.FromMilliseconds(animationOffset),
			//				AccelerationRatio = AnimationParameters.AccelerationRatio,
			//				DecelerationRatio = AnimationParameters.DecelerationRatio,
			//			});

			//	}
			//	animationOffset += 20;
			//}
		}
		#endregion

		#region Overrided Methods
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_content = GetTemplateChild<DockPanel>(nameof(PART_content));
			PART_title = GetTemplateChild<Label>(nameof(PART_title));
			PART_main = GetTemplateChild<DockPanel>(nameof(PART_main));
			PART_yaxis = GetTemplateChild<UniformGrid>(nameof(PART_yaxis));
			PART_bars = GetTemplateChild<UniformGrid>(nameof(PART_bars));
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			visualContext = new HorizontalBarChartVisualContext();

			PART_bars.Rows = Data.Count;
			PART_yaxis.Rows = Data.Count;

			PART_bars.Children.Clear();
			PART_yaxis.Children.Clear();

			if (Data.Count < 1)
			{
				base.OnRender(drawingContext);
				return;
			}

			var total = Data.MaxValue();

			var context = new ProviderContext(Data.Count);
			MaterialProvider.Reset(context);

			var maxYAxisTextLength = Data.Select(d => RenderingExtensions.EstimateLabelRenderSize(
				YAxisFontFamily, YAxisFontSize, d.CategoryName))
				.Select(renderSize => renderSize.Width).Concat(new[] {0.0}).Max();

			PART_yaxis.Width = maxYAxisTextLength;

			var maxValueTextLength = Data.Select(d => RenderingExtensions.EstimateLabelRenderSize(
				BarTotalFontFamily, BarTotalFontSize, d.Value.ToString(CultureInfo.InvariantCulture)))
				.Select(renderSize => renderSize.Width).Concat(new[] {0.0}).Max();

			var totalAvailableVerticalSpace = PART_bars.ActualHeight / Data.Count;
			var totalAvailableHorizontalExpanse = PART_bars.ActualWidth;
			var totalAvailableHorizontalSpace = totalAvailableHorizontalExpanse - maxValueTextLength;
			var actualBarHeight = totalAvailableVerticalSpace * SegmentWidthPercentage;
			foreach (var d in Data)
			{
				var barContext = new HorizontalBarChartSegmentVisualContext();
				var barWidth = d.Value.Map(0, total, 0, totalAvailableHorizontalSpace);
				var materialSet = MaterialProvider.ProvideNext(context);

				var barGrid = new Grid();

				var bar = new Rectangle
				{
					Fill = SegmentForeground.GetMaterial(materialSet),
					Height = actualBarHeight,
					Width = barWidth,
					HorizontalAlignment = HorizontalAlignment.Left
				};
				barGrid.Children.Add(bar);
				barContext.ActiveBar = bar;

				var barSpaceBackground = new Rectangle
				{
					Fill = SegmentSpaceBackground.GetMaterial(materialSet),
					Height = actualBarHeight,
					Width = totalAvailableHorizontalExpanse,
					HorizontalAlignment = HorizontalAlignment.Left
				};
				barGrid.Children.Add(barSpaceBackground);
				barContext.InactiveBar = barSpaceBackground;

				var barLabel = new Label
				{
					Content = d.Value,
					IsHitTestVisible = false,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Top,
					Width = maxValueTextLength,
					Foreground = BarTotalForeground.GetMaterial(materialSet),
					Margin = new Thickness(barWidth, 0, 0, 0),
				};
				barLabel.BindTextualPrimitive<BarTotalPrimitive>(this);
				barGrid.Children.Add(barLabel);
				barContext.BarLabel = barLabel;

				PART_bars.Children.Add(barGrid);

				var yaxisLabel = new Label
				{
					Content = d.CategoryName,
					IsHitTestVisible = false,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Top,
					Width = maxYAxisTextLength,
					Foreground = YAxisForeground.GetMaterial(materialSet),
					Margin = new Thickness(0, 0, 0, 0),
				};
				yaxisLabel.BindTextualPrimitive<YAxisPrimitive>(this);
				PART_yaxis.Children.Add(yaxisLabel);

				visualContext.BarVisuals.Add(barContext);
			}
		}
		#endregion
	}
}