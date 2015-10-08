using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlexCharts.Helpers.DependencyHelpers;
using Material.Static;

namespace MaterialDesignDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public static readonly DependencyProperty SourceProperty = DP.Register(
			new Meta<MainWindow, ObservableCollection<CardData>>());
		public ObservableCollection<CardData> Source
		{
			get { return (ObservableCollection<CardData>)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}
		public MainWindow()
		{
			InitializeComponent();		
			Source = new ObservableCollection<CardData>
			{
				new CardData {Content="A"},
				new CardData {Content="B"},
				new CardData {Content="C"},
				new CardData {Content="D"},
				new CardData {Content="E"},
				new CardData {Content="F"},
				new CardData {Content="G"},
				new CardData {Content="H"}
			};
		}
	}
	public class CardData : DependencyObject
	{
		public static readonly DependencyProperty ContentProperty = DP.Register(
			new Meta<CardData, string>());
		public string Content
		{
			get { return (string)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

	}
}
/*new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },
				new Border {Margin=new Thickness(10), Background=Palette.Blue.P600, Width=rs, Height=rs },*/
