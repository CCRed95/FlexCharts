using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FlexCharts.Animation;
using FlexCharts.Data.Structures;
using FlexCharts.MaterialDesign;

namespace FlexCharts.GenerationContext
{
	internal class ParetoChartVisualContext : AbstractVisualContext
	{
		internal List<ParetoChartCategoryVisualContext> CategoryVisuals = new List<ParetoChartCategoryVisualContext>();

		internal List<ParetoChartLineSegmentVisualContext> LineSegmentVisuals = new List<ParetoChartLineSegmentVisualContext>(); 

		internal AnimationAspect<Point, PathFigure, PointAnimation> PolyLineStartPointAnimationAspect { get; set; }
	}
	// TODO do these need to be explicitly defined? -> List<AbstractAnimationBase> AnimationAspects {get;set;} ? 
	// TODO Possibly one visualcontext|category class for all graphs?
	// TODO common based AnimationAspectBaseGroup, AnimateToBegin() calls all animatebegin methods in group
	// TODO MultiPropertyAnimationAspect -> animation for multiple properties on one IAnimatable with custom scheduling / storyboarding
	internal class ParetoChartCategoryVisualContext
	{
		internal CategoricalDataPointDouble CategoryDataPoint { get; set; }
		// TODO remobe this, replace with seperate collection
		//internal AnimationAspect<Point, PointAnimation> LineSegmentPointAnimationAspect { get; set; }

		internal MaterialSet CategoryMaterialSet { get; set; }

		internal Rectangle InactiveBarVisual { get; set; }

		//internal Rectangle ActiveBarVisual { get; set; }

		internal AnimationAspect<double, Transform, DoubleAnimation> ActiveBarRenderTransformScaleYAnimationAspect { get; set; }

		internal AnimationAspect<Thickness, Ellipse, ThicknessAnimation> DotMarginAnimationAspect { get; set; }

		internal Label AxisLabel { get; set; }

		internal AnimationAspect<Thickness, Label, ThicknessAnimation> BarLabelMarginAnimationAspect { get; set; }
	}
	internal class ParetoChartLineSegmentVisualContext
	{
		internal AnimationAspect<Point, LineSegment, PointAnimation> PointAnimationAspect { get; set; }
	}
}
