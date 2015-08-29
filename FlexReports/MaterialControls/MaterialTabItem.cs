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
using FlexCharts.MaterialDesign;

namespace FlexReports.MaterialControls
{
	public class MaterialTabItem : ContentControl
	{
		#region Dependency Properties
		public static readonly DependencyProperty TextProperty = DP.Register(
			new Meta<MaterialTabItem, string>());

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty IsSelectedProperty = DP.Register(
			new Meta<MaterialTabItem, bool>(false, IsSelectedChanged));
		public FlexTabItem FlexTabItem { get; }
		private static void IsSelectedChanged(MaterialTabItem i, DPChangedEventArgs<bool> e)
		{
			if (e.NewValue)
			{
				i._indicator.BeginAnimation(HeightProperty,
					new DoubleAnimation(0, i.ActiveIndicatorHeight, 
					new Duration(TimeSpan.FromMilliseconds(200)))
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio
					});
			}
			else
			{
				i._indicator.BeginAnimation(HeightProperty,
					new DoubleAnimation(i.ActiveIndicatorHeight, 0, 
					new Duration(TimeSpan.FromMilliseconds(200)))
					{
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio
					});
			}
		}

		public bool IsSelected
		{
			get { return (bool) GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value); }
		}

		public static readonly DependencyProperty ActiveIndicatorHeightProperty = DP.Register(
			new Meta<MaterialTabItem, double>(3));
		public double ActiveIndicatorHeight
		{
			get { return (double) GetValue(ActiveIndicatorHeightProperty); }
			set { SetValue(ActiveIndicatorHeightProperty, value); }
		}
		#endregion
		
		#region Events
		public event ClickHandler ClickEvent;
		public delegate void ClickHandler(MaterialTabItem i);
		public void RaiseClickEvent()
		{
			ClickEvent?.Invoke(this);
		}

		//public static readonly RoutedEvent ClickEvent = EM.Register<MaterialTabItem, RoutedEventHandler>();

		//public event RoutedEventHandler Click
		//{
		//	add { AddHandler(ClickEvent, value); }
		//	remove { RemoveHandler(ClickEvent, value); }
		//}
		#endregion

		#region Fields
		protected Grid _content = new Grid();
		protected Rectangle _indicator = new Rectangle()
		{
			Fill = MaterialPalette.YellowA400,
			VerticalAlignment = VerticalAlignment.Bottom
		};
		protected Label _text = new Label()
		{
			Background = Brushes.Transparent,
			VerticalContentAlignment = VerticalAlignment.Center,
			HorizontalContentAlignment = HorizontalAlignment.Center
		};
		#endregion

		#region Consructors
		static MaterialTabItem()
		{

			//PaddingProperty.OverrideMetadata(typeof (MaterialTabItem), new FrameworkPropertyMetadata(new Thickness(0,0,0,10)));
		}

		public MaterialTabItem(FlexTabItem flexTabItem)
		{
			FlexTabItem = flexTabItem;
			Content = _content;
			_content.Children.Add(_text);
			_content.Children.Add(_indicator);

			BindingOperations.SetBinding(_text, MarginProperty, new Binding("Padding") { Source = this });

			BindingOperations.SetBinding(_text, ContentProperty, new Binding("Text") { Source = this });
			BindingOperations.SetBinding(_text, FontFamilyProperty, new Binding("FontFamily") { Source = this });
			BindingOperations.SetBinding(_text, FontStyleProperty, new Binding("FontStyle") { Source = this });
			BindingOperations.SetBinding(_text, FontWeightProperty, new Binding("FontWeight") { Source = this });
			BindingOperations.SetBinding(_text, FontSizeProperty, new Binding("FontSize") { Source = this });
			BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("Foreground") { Source = this });

			//_text.DockTop();
			//_indicator.DockBottom();
			
		}
		#endregion

		#region Methods
		protected virtual void OnClick()
		{
			if (!IsSelected)
			{
				IsSelected = true;
			}
			//RaiseEvent(new RoutedEventArgs(ClickEvent, this));
		}
		#endregion

		#region Overrided Methods
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			OnClick();
			RaiseClickEvent();
			OnMouseUp(e);
		}

		//protected override void OnMouseEnter(MouseEventArgs e)
		//{
		//	BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("ActiveIndicatorSet")
		//	{
		//		Source = this,
		//		Converter = materialConverter,
		//		ConverterParameter = Luminosity.P100
		//	});
		//	base.OnMouseEnter(e);
		//}

		//protected override void OnMouseLeave(MouseEventArgs e)
		//{
		//	if (IsSelected)
		//	{
		//		BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("ActiveIndicatorSet")
		//		{
		//			Source = this,
		//			Converter = materialConverter,
		//			ConverterParameter = Luminosity.P200
		//		});
		//	}
		//	else
		//	{
		//		BindingOperations.SetBinding(_text, ForegroundProperty, new Binding("Foreground") { Source = this });
		//	}

		//	base.OnMouseLeave(e);
		//}

		protected override void OnRender(DrawingContext drawingContext)
		{

			base.OnRender(drawingContext);
		}

		#endregion
	}
}
