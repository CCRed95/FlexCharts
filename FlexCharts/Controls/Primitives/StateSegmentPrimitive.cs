using System.Windows;
using FlexCharts.Controls.Contracts;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;

namespace FlexCharts.Controls.Primitives
{
	//TODO are stroke thickness properties double?
	public abstract class StateSegmentPrimitive : FlexPrimitive, IStateSegmentContract
	{
		public static readonly DependencyProperty ActiveFillProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		public static readonly DependencyProperty ActiveStrokeThicknessProperty =
			DP.Attach<int>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata());

		public static readonly DependencyProperty ActiveStrokeProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		public static readonly DependencyProperty InactiveFillProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));

		public static readonly DependencyProperty InactiveStrokeThicknessProperty =
			DP.Attach<int>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata());

		public static readonly DependencyProperty InactiveStrokeProperty =
			DP.Attach<AbstractMaterialDescriptor>(typeof (StateSegmentPrimitive), new FrameworkPropertyMetadata(MaterialPalette.Descriptors.P700Descriptor));



		public static AbstractMaterialDescriptor GetActiveFill(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(ActiveFillProperty);
		public static void SetActiveFill(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(ActiveFillProperty, v);
		public AbstractMaterialDescriptor ActiveFill
		{
			get { return (AbstractMaterialDescriptor) GetValue(ActiveFillProperty); }
			set { SetValue(ActiveFillProperty, value); }
		}

		public static int GetActiveStrokeThickness(DependencyObject i) => i.Get<int>(ActiveStrokeThicknessProperty);
		public static void SetActiveStrokeThickness(DependencyObject i, int v) => i.Set(ActiveStrokeThicknessProperty, v);
		public int ActiveStrokeThickness
		{
			get { return (int) GetValue(ActiveStrokeThicknessProperty); }
			set { SetValue(ActiveStrokeThicknessProperty, value); }
		}
		
		public static AbstractMaterialDescriptor GetActiveStroke(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(ActiveStrokeProperty);
		public static void SetActiveStroke(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(ActiveStrokeProperty, v);
		public AbstractMaterialDescriptor ActiveStroke
		{
			get { return (AbstractMaterialDescriptor) GetValue(ActiveStrokeProperty); }
			set { SetValue(ActiveStrokeProperty, value); }
		}
		
		public static AbstractMaterialDescriptor GetInactiveFill(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(InactiveFillProperty);
		public static void SetInactiveFill(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(InactiveFillProperty, v);
		public AbstractMaterialDescriptor InactiveFill
		{
			get { return (AbstractMaterialDescriptor) GetValue(InactiveFillProperty); }
			set { SetValue(InactiveFillProperty, value); }
		}
		
		public static int GetInactiveStrokeThickness(DependencyObject i) => i.Get<int>(InactiveStrokeThicknessProperty);
		public static void SetInactiveStrokeThickness(DependencyObject i, int v) => i.Set(InactiveStrokeThicknessProperty, v);
		public int InactiveStrokeThickness
		{
			get { return (int) GetValue(InactiveStrokeThicknessProperty); }
			set { SetValue(InactiveStrokeThicknessProperty, value); }
		}
		
		public static AbstractMaterialDescriptor GetInactiveStroke(DependencyObject i) => i.Get<AbstractMaterialDescriptor>(InactiveStrokeProperty);
		public static void SetInactiveStroke(DependencyObject i, AbstractMaterialDescriptor v) => i.Set(InactiveStrokeProperty, v);
		public AbstractMaterialDescriptor InactiveStroke
		{
			get { return (AbstractMaterialDescriptor) GetValue(InactiveStrokeProperty); }
			set { SetValue(InactiveStrokeProperty, value); }
		}
	}
}
