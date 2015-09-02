using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shapes;
using FlexCharts.Helpers.EventHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.Require;

namespace FlexReports.MaterialControls
{
	[TemplatePart(Name = "PART_bubbles", Type = typeof(UniformGrid))]
	public partial class ThemeSelector : Control
	{
		public static readonly RoutedEvent PopupRequestCloseEvent = EM.Register<ThemeSelector, RoutedEventHandler>();

		public event RoutedEventHandler PopupRequestClose
		{
			add { AddHandler(PopupRequestCloseEvent, value); }
			remove { RemoveHandler(PopupRequestCloseEvent, value); }
		}

		public event ThemeSelectedHandler ThemeSelected;
		public delegate void ThemeSelectedHandler(MaterialTheme e);
		public void RaiseThemeSelectedEvent(MaterialTheme e)
		{
			ThemeSelected?.Invoke(e);
		}

		private ReadOnlyCollection<MaterialTheme> themeSource = MaterialThemes.AllThemes;
		protected UniformGrid PART_bubbles;

		static ThemeSelector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ThemeSelector), new FrameworkPropertyMetadata(typeof(ThemeSelector)));
		}
		public ThemeSelector() { }

		public ThemeSelector(ThemeSelectedHandler callback)
		{
			ThemeSelected += callback;
		}
		#region Overrided Methods
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_bubbles = GetTemplateChild<UniformGrid>(nameof(PART_bubbles));
			loadBubbles();
		}

		private void loadBubbles()
		{
			PART_bubbles.Children.Clear();
			foreach (var theme in themeSource)
			{
				var bubbles = new Ellipse
				{
					Width = 50,
					Height = 50,
					Tag = theme,
					Fill = theme.P500,
					Effect = MaterialPalette.Shadows.ShadowDelta2,
				};
				bubbles.MouseUp += bubbleClicked;
				PART_bubbles.Children.Add(bubbles);
			}

		}

		private void closePopup(object s, RoutedEventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(PopupRequestCloseEvent));
		}
		private void bubbleClicked(object s, MouseButtonEventArgs e)
		{
			RaiseThemeSelectedEvent(s.RequireType<Ellipse>().Tag.RequireType<MaterialTheme>());
		}

		#endregion
		public T GetTemplateChild<T>(string name) where T : DependencyObject
		{
			var templateChild = GetTemplateChild(name) as T;
			if (templateChild == null)
				throw new NullReferenceException($"TemplateChild {name} as {typeof(T)}");
			return templateChild;
		}
	}
}
