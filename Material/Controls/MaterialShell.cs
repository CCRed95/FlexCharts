using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Material.Controls
{
	public class MaterialShell : Window
	{
		private Grid ShellOverlayRoot;
		public Grid GetShellOverlayRoot => ShellOverlayRoot;

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
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			ShellOverlayRoot = GetTemplateChild<Grid>(nameof(ShellOverlayRoot));
		}
		public T GetTemplateChild<T>(string name) where T : DependencyObject
		{
			var templateChild = GetTemplateChild(name) as T;
			if (templateChild == null)
				throw new NullReferenceException($"TemplateChild {name} as {typeof(T)}");
			return templateChild;
		}
	}
}
