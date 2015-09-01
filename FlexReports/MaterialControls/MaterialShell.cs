using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;

namespace FlexReports.MaterialControls
{
	public class MaterialShell : Window
	{
		public static readonly DependencyProperty MaterialThemeProperty = DP.Register(
			new Meta<MaterialShell, MaterialTheme>(new MaterialTheme()));
		public MaterialTheme MaterialTheme
		{
			get { return (MaterialTheme) GetValue(MaterialThemeProperty); }
			set { SetValue(MaterialThemeProperty, value); }
		}
		public static readonly DependencyProperty P000Property = DP.Register(
			new Meta<MaterialShell, SolidColorBrush>(new SolidColorBrush(Color.FromRgb(50,240,20))));
		public SolidColorBrush P000
		{
			get { return (SolidColorBrush) GetValue(P000Property); }
			set { SetValue(P000Property, value); }
		}
		protected void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;
		}

		protected void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ResizeMode != ResizeMode.NoResize;
		}

		protected void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.CloseWindow(this);
		}

		protected void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MaximizeWindow(this);
		}

		protected void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MinimizeWindow(this);
		}

		protected void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.RestoreWindow(this);
		}

		static MaterialShell()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialShell), new FrameworkPropertyMetadata(typeof(MaterialShell)));
		}
		public MaterialShell()
		{
			CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
			CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
			CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
			CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
		}
	}
}
