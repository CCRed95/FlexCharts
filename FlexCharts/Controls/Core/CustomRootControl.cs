using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;

namespace FlexCharts.Controls.Core
{
	[TemplatePart(Name = "PART_Content", Type = typeof(DockPanel))]
	[TemplatePart(Name = "PART_Title", Type = typeof(Label))]
	[TemplatePart(Name = "PART_Main", Type = typeof(Grid))]
	public class CustomRootControl : Control
	{
				#region Dependency Properties
		/// <summary>
		/// Identifies the <see cref="Title"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="Title"/> dependency property
		/// </returns>
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<CustomRootControl, string>("Abstract Flex Chart"));
		/// <summary>
		/// Identifies the <see cref="FallbackMaterialSet"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="FallbackMaterialSet"/> dependency property
		/// </returns>
		public static readonly DependencyProperty FallbackMaterialSetProperty = DP.Register(
			new Meta<CustomRootControl, MaterialSet>(MaterialPalette.Sets.GreyBrushSet));
		/// <summary>
		/// Identifies the <see cref="MaterialProvider"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="MaterialProvider"/> dependency property
		/// </returns>
		public static readonly DependencyProperty MaterialProviderProperty = DP.Register(
			new Meta<CustomRootControl, IMaterialProvider>(SequentialMaterialProvider.RainbowPaletteOrder) { Flags = FXR });
		/// <summary>
		/// Identifies the <see cref="SegmentForeground"/> dependency property
		/// </summary>
		/// <returns>
		/// The identifier for the <see cref="SegmentForeground"/> dependency property
		/// </returns>
		public static readonly DependencyProperty SegmentForegroundProperty = DP.Register(
			new Meta<CustomRootControl, AbstractMaterialDescriptor>(new LuminosityMaterialDescriptor(Luminosity.P500)));

		/// <summary>
    /// Gets or sets a string that specifies the chart's title
    /// </summary>
		[Category("Charting")]
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		/// <summary>
		/// Gets or sets a MaterialSet for MaterialDescriptors to source from that cannot be logically paired with the MaterialProvider
		/// </summary>
		[Category("Charting")]
		public MaterialSet FallbackMaterialSet
		{
			get { return (MaterialSet)GetValue(FallbackMaterialSetProperty); }
			set { SetValue(FallbackMaterialSetProperty, value); }
		}
		/// <summary>
		/// Gets or sets the MaterialProvider for the chart. Used during rendering to select material colors dynamically
		/// </summary>
		[Category("Charting")]
		public IMaterialProvider MaterialProvider
		{
			get { return (IMaterialProvider)GetValue(MaterialProviderProperty); }
			set { SetValue(MaterialProviderProperty, value); }
		}
		/// <summary>
		/// Gets or sets the MaterialDescriptor for selecting the main segment foreground
		/// </summary>
		[Category("Charting")]
		public AbstractMaterialDescriptor SegmentForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SegmentForegroundProperty); }
			set { SetValue(SegmentForegroundProperty, value); }
		}
		#endregion

		#region Fields
		protected const FrameworkPropertyMetadataOptions FXR = FrameworkPropertyMetadataOptions.AffectsRender;
		protected const FrameworkPropertyMetadataOptions FXM = FrameworkPropertyMetadataOptions.AffectsMeasure;
		protected const FrameworkPropertyMetadataOptions FXA = FrameworkPropertyMetadataOptions.AffectsArrange;
		protected const FrameworkPropertyMetadataOptions INH = FrameworkPropertyMetadataOptions.Inherits;
		
		#endregion
		protected DockPanel _content;
		protected Label _titlelabel;
		protected Grid _main;

		static CustomRootControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRootControl), new FrameworkPropertyMetadata(typeof(CustomRootControl)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			_content = GetTemplateChild("PART_Content") as DockPanel;
			_titlelabel = GetTemplateChild("PART_Title") as Label;
			_main = GetTemplateChild("PART_Main") as Grid;

			if (_content == null || _titlelabel == null || _main == null)
			{
				throw new NullReferenceException("Template parts not available");
			}
		}
	}
}
