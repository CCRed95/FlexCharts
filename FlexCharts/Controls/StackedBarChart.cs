using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FlexCharts.Animation;
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Primatives;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;
using FlexCharts.Require;

namespace FlexCharts.Controls
{
	public class StackedBarChart : AbstractFlexChart<CategoricalDataPointDoubleListList>,
		ISegmentContract, IBarTotalContract, IXAxisContract
	{
		#region Dependency Properties
		#region			BarTotalContract
		public static readonly DependencyProperty BarTotalFontFamilyProperty = DP.Add(BarTotalPrimative.BarTotalFontFamilyProperty,
			new Meta<StackedBarChart, FontFamily> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStyleProperty = DP.Add(BarTotalPrimative.BarTotalFontStyleProperty,
			new Meta<StackedBarChart, FontStyle> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontWeightProperty = DP.Add(BarTotalPrimative.BarTotalFontWeightProperty,
			new Meta<StackedBarChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontStretchProperty = DP.Add(BarTotalPrimative.BarTotalFontStretchProperty,
			new Meta<StackedBarChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalFontSizeProperty = DP.Add(BarTotalPrimative.BarTotalFontSizeProperty,
			new Meta<StackedBarChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty BarTotalForegroundProperty = DP.Add(BarTotalPrimative.BarTotalForegroundProperty,
			new Meta<StackedBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

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

		#region SegmentContract
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty = DP.Add(SegmentPrimative.SegmentSpaceBackgroundProperty,
			new Meta<StackedBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SegmentWidthPercentageProperty = DP.Add(SegmentPrimative.SegmentWidthPercentageProperty,
			new Meta<StackedBarChart, double> { Flags = INH }, DPExtOptions.ForceManualInherit);


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
		public static readonly DependencyProperty XAxisFontFamilyProperty = DP.Add(XAxisPrimative.XAxisFontFamilyProperty,
			new Meta<StackedBarChart, FontFamily> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontStyleProperty = DP.Add(XAxisPrimative.XAxisFontStyleProperty,
			new Meta<StackedBarChart, FontStyle> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontWeightProperty = DP.Add(XAxisPrimative.XAxisFontWeightProperty,
			new Meta<StackedBarChart, FontWeight> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontStretchProperty = DP.Add(XAxisPrimative.XAxisFontStretchProperty,
			new Meta<StackedBarChart, FontStretch> { Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisFontSizeProperty = DP.Add(XAxisPrimative.XAxisFontSizeProperty,
			new Meta<StackedBarChart, double> { Flags = INH | FXR }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty XAxisForegroundProperty = DP.Add(XAxisPrimative.XAxisForegroundProperty,
			new Meta<StackedBarChart, AbstractMaterialDescriptor> { Flags = INH }, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public FontFamily XAxisFontFamily
		{
			get { return (FontFamily)GetValue(XAxisFontFamilyProperty); }
			set { SetValue(XAxisFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle XAxisFontStyle
		{
			get { return (FontStyle)GetValue(XAxisFontStyleProperty); }
			set { SetValue(XAxisFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight XAxisFontWeight
		{
			get { return (FontWeight)GetValue(XAxisFontWeightProperty); }
			set { SetValue(XAxisFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch XAxisFontStretch
		{
			get { return (FontStretch)GetValue(XAxisFontStretchProperty); }
			set { SetValue(XAxisFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double XAxisFontSize
		{
			get { return (double)GetValue(XAxisFontSizeProperty); }
			set { SetValue(XAxisFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor XAxisForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(XAxisForegroundProperty); }
			set { SetValue(XAxisForegroundProperty, value); }
		}
		#endregion
		#endregion

		#region Properties
		//public override IMaterialProvider MaterialProvider { get; set; } = GradientMaterialProvider.MaterialHLbB;
		#endregion

		#region Fields
		//protected readonly Grid _categoryLabels = new Grid();
		protected readonly Grid _highlightGrid = new Grid();
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
		static StackedBarChart()
		{
			TitleProperty.OverrideMetadata(typeof(StackedBarChart), new FrameworkPropertyMetadata("Stacked Bar Chart"));
		}
		public StackedBarChart()
		{
			//_main.Children.Add(_categoryLabels);
			_main.Children.Add(_bars);
			_main.Children.Add(_xAxisGrid);
			_main.Children.Add(_highlightGrid);

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
			var animationOffset = 0;
			foreach (var d in Data)
			{
				var renderedShapeList = (List<Shape>)d.RenderedVisual;
				foreach (var i in renderedShapeList)
				{
					var renderedShape = (Shape)i;//.ShouldBeCastable<Shape>();
					renderedShape.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty,
						new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(600 + (animationOffset / 2))))
						{
							BeginTime = TimeSpan.FromMilliseconds(animationOffset),
							AccelerationRatio = AnimationParameters.AccelerationRatio,
							DecelerationRatio = AnimationParameters.DecelerationRatio,
						});

				}
				animationOffset += 20;
			}
		}
		#endregion

		#region Overrided Methods
		protected override void OnRender(DrawingContext drawingContext)
		{
			_bars.Children.Clear();
			_xAxisGrid.Children.Clear();
			_highlightGrid.Children.Clear();

			if (Data.Count < 1)
			{
				base.OnRender(drawingContext);
				return;
			}
			var total = Data.MaxSubcategoryTotal();

			var context = new ProviderContext(Data.Count);
			var barAvailableWidth = _bars.RenderSize.Width / Data.Count;
			var barActiveWidth = barAvailableWidth * SegmentWidthPercentage;
			var barLeftSpacing = (barAvailableWidth - barActiveWidth) / 2;
			var barLabelSize = RenderingExtensions.EstimateLabelRenderSize(BarTotalFontFamily, BarTotalFontSize);

			var xtrace = 0;
			foreach (var d in Data)
			{
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
					Foreground = MaterialPalette.White000, //BarTotalForeground.GetMaterial(MaterialPalette.Sets.GreyBrushSet),
					DataContext = this
				};
				BindingOperations.SetBinding(axisLabel, FontFamilyProperty, new Binding("XAxisFontFamily") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontStyleProperty, new Binding("XAxisFontStyle") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontWeightProperty, new Binding("XAxisFontWeight") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontSizeProperty, new Binding("XAxisFontSize") { Source = this });
				//BindingOperations.SetBinding(axisLabel, ForegroundProperty, new Binding("XAxisForeground") { Source = this });
				BindingOperations.SetBinding(axisLabel, FontStretchProperty, new Binding("XAxisFontStretch") { Source = this });

				_xAxisGrid.Children.Add(axisLabel);
				xtrace++;
			}
			var horizontalTrace = 0d;
			var xAxisHeight = _xAxisGrid.ActualHeight;
			var backHeight = _bars.RenderSize.Height - xAxisHeight;
			foreach (var d in Data)
			{
				var backRectangle = new Rectangle
				{
					Width = barActiveWidth,
					Height = backHeight,
					VerticalAlignment = VerticalAlignment.Bottom,
					HorizontalAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(horizontalTrace + barLeftSpacing, 0, 0, xAxisHeight)
				};
				backRectangle.MouseEnter += (s, e) => barMouseEnter(d);
				BindingOperations.SetBinding(backRectangle, Shape.FillProperty, new Binding("SegmentSpaceBackground") { Source = this });
				//backRectangle.Fill = SegmentSpaceBackground.GetMaterial() TODO remove above. make this work
				_bars.Children.Add(backRectangle);

				MaterialProvider.Reset(context);
				var verticalTrace = 0d;
				var pathBuffer = new List<Shape>();
				foreach (var sd in d.Value)
				{
					var materialSet = MaterialProvider.ProvideNext(context);
					var height = sd.Value.Map(0, total, 0, _bars.RenderSize.Height - xAxisHeight - barLabelSize.Height);
					var rectangle = new Rectangle
					{
						Width = barActiveWidth,
						Height = height + verticalTrace,
						Fill = SegmentForeground.GetMaterial(materialSet),
						VerticalAlignment = VerticalAlignment.Bottom,
						HorizontalAlignment = HorizontalAlignment.Left,
						Margin = new Thickness(horizontalTrace + barLeftSpacing, 0, 0, xAxisHeight)
					};
					rectangle.MouseEnter += (s, e) => barMouseEnter(d);
					rectangle.MouseLeave += (s, e) => barMouseLeave(s, e, d, sd);
					rectangle.RenderTransform = new ScaleTransform(1, (IsLoaded ? 1 : 0), .5, 1); //TODO get rid of all isloaded conditional sets
					rectangle.RenderTransformOrigin = new Point(.5, 1);

					sd.RenderedVisual = rectangle;
					pathBuffer.Add(rectangle);
					verticalTrace += height;
				}
				for (var x = pathBuffer.Count - 1; x >= 0; x--)
				{
					var path = pathBuffer[x];
					_bars.Children.Add(path);
				}
				var barLabel = new Label
				{
					Content = d.Value.CategoryTotal(),
					IsHitTestVisible = false,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Bottom,
					Width = barAvailableWidth,
					Foreground = BarTotalForeground.GetMaterial(MaterialPalette.Sets.GreenBrushSet),
					Margin = new Thickness(horizontalTrace, 0, 0, xAxisHeight + verticalTrace),
				};
				BindingOperations.SetBinding(barLabel, FontFamilyProperty, new Binding("BarTotalFontFamily") { Source = this });
				BindingOperations.SetBinding(barLabel, FontStyleProperty, new Binding("BarTotalFontStyle") { Source = this });
				BindingOperations.SetBinding(barLabel, FontWeightProperty, new Binding("BarTotalFontWeight") { Source = this });
				BindingOperations.SetBinding(barLabel, FontSizeProperty, new Binding("BarTotalFontSize") { Source = this });
				//BindingOperations.SetBinding(barLabel, ForegroundProperty, new Binding("BarTotalForeground") { Source = this });
				BindingOperations.SetBinding(barLabel, FontStretchProperty, new Binding("BarTotalFontStretch") { Source = this });
				d.RenderedVisual = pathBuffer;
				_bars.Children.Add(barLabel);
				horizontalTrace += barAvailableWidth;
			}
			base.OnRender(drawingContext);
		}

		private void barMouseEnter(CategoricalDataPointCategoricalDataPointDoubleList barinfo)
		{
			_highlightGrid.Children.Clear();
			var pathBuffer = barinfo.RenderedVisual.RequireType<List<Shape>>();
			var largestRectangle = pathBuffer.Last();
			var sdd = new Path()
			{
				Data = largestRectangle.RenderedGeometry,
				Stroke = Brushes.White,
				StrokeThickness = 2,
				VerticalAlignment = largestRectangle.VerticalAlignment,
				HorizontalAlignment = largestRectangle.HorizontalAlignment,
				Margin = largestRectangle.Margin
			};

			var tt = new ToolTipPath
			{
				IsHitTestVisible = false,
				Height = 100,
				Width = 180,
				Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)) { Opacity = .7 },
				ArrowDirection = ToolTipDirection.Left,
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Bottom,
				Margin = new Thickness(largestRectangle.Margin.Left + largestRectangle.Width + 10, 0, 0, largestRectangle.Height / 2)
			};
			BindingOperations.SetBinding(_highlightGrid, VisibilityProperty, new Binding("IsMouseOver") { Source = this, Converter = new BooleanToVisibilityConverter() });
			if (tt.Margin.Left + tt.Width > _highlightGrid.ActualWidth)
			{
				tt.ArrowDirection = ToolTipDirection.Right;
				tt.Margin = new Thickness(largestRectangle.Margin.Left - 10 - tt.Width, 0, 0, tt.Margin.Bottom);
			}

			_highlightGrid.Children.Add(sdd);
			_highlightGrid.Children.Add(tt);
		}
		private void barMouseLeave(object s, MouseEventArgs e, CategoricalDataPointCategoricalDataPointDoubleList barinfo, CategoricalDataPointDouble subbarinfo)
		{
			//subbarinfo.RenderedVisual.ShouldBeType<Rectangle>().Fill = Brushes.White;
		}
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			base.OnMouseDown(e);
		}

		//private void pathMouseEnter(object s, MouseEventArgs MouseEventArgs)
		//{
		//	_highlightGrid.Children.Clear();
		//	var customPath = s.ShouldBeType<CustomPath>();
		//	CategoricalDataPointList barData;
		//	if (!tryFindDataSet(customPath, out barData))
		//		return;
		//	var highlightPath = new Path
		//	{
		//		Data = barData.RenderedPathList.Last().Data.Clone(),
		//		Stroke = FlatUI.White,
		//		StrokeThickness = 2,
		//		Margin = customPath.Margin
		//	};
		//	_highlightGrid.Children.Add(highlightPath);
		//	var floatingBox = createFloatingBox(barData, customPath.Fill);
		//	floatingBox.Margin = new Thickness(customPath.Margin.Left + 40, 0, 0, customPath.Margin.Bottom + 40);

		//	//_highlightGrid.Children.Add(floatingBox);
		//	//foreach (var path in barData.RenderedPathList)
		//	//{
		//	//	path.Fill = Material.Grey;
		//	//}
		//}

		//private bool tryFindDataSet(CustomPath path, out CategoricalDataPointList data)
		//{
		//	foreach (var bar in Data)
		//	{
		//		foreach (var subBar in bar.Value)
		//		{
		//			if (Equals(subBar.RenderedPath, path))
		//			{
		//				data = bar;
		//				return true;
		//			}
		//		}
		//	}
		//	data = default(CategoricalDataPointList);
		//	return false;
		//}
		private void barClick(object s, RoutedEventArgs e)
		{

		}


		private Grid createFloatingBox(CategoricalDataPointList barData, Brush border)
		{
			var parentContainer = new Grid()
			{
				IsHitTestVisible = false,
				Width = 150,
				Height = 200,
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Bottom,
			};
			var container = new WrapPanel
			{
				Orientation = Orientation.Vertical,
			};
			parentContainer.Children.Add(new Border()
			{
				//Background = FlatUI.DarkGrayDark,
				BorderBrush = border,
				BorderThickness = new Thickness(2)
			});
			parentContainer.Children.Add(container);

			foreach (var dataPoint in barData.Value)
			{
				container.Children.Add(new Label
				{
					FontSize = 16,
					HorizontalContentAlignment = HorizontalAlignment.Center,
					VerticalContentAlignment = VerticalAlignment.Center,
					Content = $"{dataPoint.CategoryName} - {dataPoint.Value}",
					Foreground = dataPoint.RenderedVisual.RequireType<Shape>().Fill.RequireType<SolidColorBrush>()//.Lighten(.3)
				});
			}

			return parentContainer;
		}
		#endregion
	}
}
