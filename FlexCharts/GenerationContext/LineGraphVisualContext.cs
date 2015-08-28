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
	class LineGraphVisualContext : AbstractVisualContext
	{
		internal List<LineGraphCategoryVisualContext> CategoryVisuals = new List<LineGraphCategoryVisualContext>();

		internal List<LineGraphLineSegmentVisualContext> LineSegmentVisuals = new List<LineGraphLineSegmentVisualContext>(); 

		internal AnimationAspect<Point, PathFigure, PointAnimation> PolyLineStartPointAnimationAspect { get; set; }
	}
	internal class LineGraphCategoryVisualContext
	{
		internal CategoricalDouble CategoryDataPoint { get; set; }

		internal MaterialSet CategoryMaterialSet { get; set; }
		
		internal AnimationAspect<Thickness, Ellipse, ThicknessAnimation> DotMarginAnimationAspect { get; set; }

		internal Label AxisLabel { get; set; }

		internal AnimationAspect<Thickness, Label, ThicknessAnimation> BarLabelMarginAnimationAspect { get; set; }
	}
	internal class LineGraphLineSegmentVisualContext
	{
		internal AnimationAspect<Point, LineSegment, PointAnimation> PointAnimationAspect { get; set; }
	}
}
