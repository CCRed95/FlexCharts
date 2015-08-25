using System.Windows;

namespace FlexCharts.Helpers.DependencyHelpers
{
	public class Meta<D, T> where D : DependencyObject
	{
		public T DefaultValue { get; }
		public FrameworkPropertyMetadataOptions Flags { get; set; } = FrameworkPropertyMetadataOptions.None;
		public PropertyChange<D, T> ChangedCallback { get; }
		public PropertyCoerce<D, T> CoerceCallback { get; }

		public Meta(T defaultValue = default(T),
			PropertyChange<D, T> changedCallback = null,
			PropertyCoerce<D, T> coerceCallback = null)
		{
			DefaultValue = defaultValue;
			ChangedCallback = changedCallback;
			CoerceCallback = coerceCallback;
		}		
	}
}
