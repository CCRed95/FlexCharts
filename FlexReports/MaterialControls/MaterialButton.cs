using System;
using System.Collections.Generic;
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
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.MaterialDesign;

namespace FlexReports.MaterialControls
{
	public enum SelectedVisualStyle
	{
		Line,
		Box,
		Circle
	}
	public class MaterialButton : ContentControl
	{
		#region Dependency Properties
		public static readonly DependencyProperty ActiveIndicatorSetProperty = DP.Register(
			new Meta<MaterialButton, MaterialSet>(MaterialPalette.Sets.BlueBrushSet));

		public static readonly DependencyProperty ActiveIndicatorWidthProperty = DP.Register(
			new Meta<MaterialButton, double>(6 ));

		public static readonly DependencyProperty IsSelectedProperty = DP.Register(
			new Meta<MaterialButton, bool>(false, IsSelectedChangedCallback));

		public static readonly DependencyProperty TextProperty = DP.Register(
			new Meta<MaterialButton, string>());

		public static readonly DependencyProperty SelectedIndentLengthProperty = DP.Register(
			new Meta<MaterialButton, double>(20));

		public static readonly DependencyProperty AnimationDurationProperty = DP.Register(
			new Meta<MaterialButton, Duration>(new Duration(TimeSpan.FromMilliseconds(200))));

		public static readonly DependencyProperty SelectedVisualStyleProperty = DP.Register(
			new Meta<MaterialButton, SelectedVisualStyle>(SelectedVisualStyle.Circle, SelectedVisualStyleChanged));

		private static void SelectedVisualStyleChanged(MaterialButton i, DPChangedEventArgs<SelectedVisualStyle> e)
		{
			//switch (i.SelectedVisualStyle)
			//{
			//	case SelectedVisualStyle.Line:
			//		i._indicator = new Rectangle();
			//		break;
			//	case SelectedVisualStyle.Circle:
			//		i._indicator = new Ellipse();
			//		i._indicator.VerticalAlignment = VerticalAlignment.Center;
			//		i._indicator.Margin = new Thickness(30, 0, 0, 0);
			//		BindingOperations.SetBinding(i._indicator, HeightProperty, new Binding("ActiveIndicatorWidth") { Source = i });
			//		break;
			//	case SelectedVisualStyle.Box:
			//		i._indicator = new Rectangle();
			//		break;
			//}
			//DockPanel.SetDock(i._indicator, Dock.Left);
			//BindingOperations.SetBinding(i._indicator, WidthProperty, new Binding("ActiveIndicatorWidth") { Source = i });
			//BindingOperations.SetBinding(i._indicator, Shape.FillProperty, new Binding("ActiveIndicatorSet")
			//{
			//	Source = i,
			//	Converter = i.bc,
			//	ConverterParameter = Intensity.P600
			//});
		}

		public static readonly DependencyProperty SelectedBackgroundProperty = DP.Register(
			new Meta<MaterialButton, Brush>(MaterialPalette.Grey800));
		

		public MaterialSet ActiveIndicatorSet
		{
			get { return (MaterialSet)GetValue(ActiveIndicatorSetProperty); }
			set { SetValue(ActiveIndicatorSetProperty, value); }
		}
		public double ActiveIndicatorWidth
		{
			get { return (double)GetValue(ActiveIndicatorWidthProperty); }
			set { SetValue(ActiveIndicatorWidthProperty, value); }
		}
		public bool IsSelected
		{
			get { return (bool)GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value); }
		}
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public double SelectedIndentLength
		{
			get { return (double)GetValue(SelectedIndentLengthProperty); }
			set { SetValue(SelectedIndentLengthProperty, value); }
		}
		public Duration AnimationDuration
		{
			get { return (Duration)GetValue(AnimationDurationProperty); }
			set { SetValue(AnimationDurationProperty, value); }
		}
		public SelectedVisualStyle SelectedVisualStyle
		{ 
			get { return (SelectedVisualStyle) GetValue(SelectedVisualStyleProperty); }
			set { SetValue(SelectedVisualStyleProperty, value); }
		}
		public Brush SelectedBackground
		{
			get { return (Brush) GetValue(SelectedBackgroundProperty); }
			set { SetValue(SelectedBackgroundProperty, value); }
		}
		#endregion

		#region Dependency Property Callbacks
		private static void IsSelectedChangedCallback(MaterialButton i, DPChangedEventArgs<bool> e)
		{
			if (e.NewValue)
			{
				i._back.BeginAnimation(OpacityProperty, new DoubleAnimation(1, i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});
				i._indicator.BeginAnimation(WidthProperty, new DoubleAnimation(i.ActiveIndicatorWidth, i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});

				i._text.BeginAnimation(MarginProperty, new ThicknessAnimation(
					new Thickness(i.Padding.Left + i.SelectedIndentLength, i.Padding.Top, i.Padding.Right, i.Padding.Bottom), i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});
			}
			else
			{
				i._back.BeginAnimation(OpacityProperty, new DoubleAnimation(0, i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});
				i._indicator.BeginAnimation(WidthProperty, new DoubleAnimation(0, i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});

				i._text.BeginAnimation(MarginProperty, new ThicknessAnimation(i.Padding, i.AnimationDuration)
				{
					AccelerationRatio = AnimationParameters.AccelerationRatio,
					DecelerationRatio = AnimationParameters.DecelerationRatio
				});
			}
		}
		#endregion

		#region Routed Events
		public static readonly RoutedEvent ClickEvent = EM.Register<MaterialButton, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler Click
		{
			add { AddHandler(ClickEvent, value); }
			remove { RemoveHandler(ClickEvent, value); }
		}
		#endregion

		#region Fields

		private readonly MaterialSetToBrushConverter materialConverter = new MaterialSetToBrushConverter();
		protected Grid _content = new Grid();
		protected DockPanel _main = new DockPanel();
		protected Rectangle _back = new Rectangle()
		{
			Opacity = 0
		};
		protected Label _text = new Label()
		{
			VerticalContentAlignment = VerticalAlignment.Center,
			HorizontalContentAlignment = HorizontalAlignment.Left
		};
		protected Shape _indicator = new Rectangle
		{
			Fill = Brushes.Transparent,
			Width = 0
		};
		#endregion

		#region Constructors
		static MaterialButton()
		{
			//PaddingProperty.OverrideMetadata(typeof (MaterialListButton), new FrameworkPropertyMetadata(new Thickness()));
		}

		public MaterialButton()
		{
			BindingOperations.SetBinding(_text, MarginProperty, new Binding("Padding") { Source = this });

			BindingOperations.SetBinding(_text, ContentProperty, new Binding("Text") { Source = this });
			BindingOperations.SetBinding(_text, FontFamilyProperty, new Binding("FontFamily") { Source = this });
			BindingOperations.SetBinding(_text, FontStyleProperty, new Binding("FontStyle") { Source = this });
			BindingOperations.SetBinding(_text, FontWeightProperty, new Binding("FontWeight") { Source = this });
			BindingOperations.SetBinding(_text, FontSizeProperty, new Binding("FontSize") { Source = this });
			BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("Foreground") { Source = this });

			Content = _content;
			_content.Children.Add(_back);
			_content.Children.Add(_main);
			
			BindingOperations.SetBinding(_back, Shape.FillProperty, new Binding("SelectedBackground") { Source = this});

			BindingOperations.SetBinding(_indicator, Shape.FillProperty, new Binding("ActiveIndicatorSet")
			{
				Source = this,
				Converter = materialConverter,
				ConverterParameter = Luminosity.P600
			});

			DockPanel.SetDock(_indicator, Dock.Right);
			DockPanel.SetDock(_text, Dock.Left);

			_main.Children.Add(_indicator);
			_main.Children.Add(_text);
		}
		#endregion

		#region Methods
		protected virtual void OnClick()
		{
			IsSelected = !IsSelected;
			RaiseEvent(new RoutedEventArgs(ClickEvent, this));
		}
		#endregion

		#region Overrided Methods
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			OnClick();
			OnMouseUp(e);
		}

		protected override void OnMouseEnter(MouseEventArgs e)
		{
			BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("ActiveIndicatorSet")
			{
				Source = this,
				Converter = materialConverter,
				ConverterParameter = Luminosity.P100
			});
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(MouseEventArgs e)
		{
			if (IsSelected)
			{
				BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("ActiveIndicatorSet")
				{
					Source = this,
					Converter = materialConverter,
					ConverterParameter = Luminosity.P200
				});
			}
			else
			{
				BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("Foreground") { Source = this });
			}

			base.OnMouseLeave(e);
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			
			base.OnRender(drawingContext);
		}

		#endregion
	}
}
