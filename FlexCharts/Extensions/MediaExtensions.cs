using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FlexCharts.MaterialDesign;

namespace FlexCharts.Extensions
{
	public static class MediaExtensions
	{
		public static Color Darken(this Color o, double percent)
		{
			var i = o;
			i.R = o.R.ScaleDown(percent);
			i.G = o.G.ScaleDown(percent);
			i.B = o.B.ScaleDown(percent);
			return i;
		}

		public static Color Lighten(this Color o, double percent)
		{
			var i = o;
			i.R = o.R.ScaleUp(percent);
			i.G = o.G.ScaleUp(percent);
			i.B = o.B.ScaleUp(percent);
			return i;
		}

		public static SolidColorBrush Darken(this SolidColorBrush i, double percent)
		{
			return new SolidColorBrush(i.Color.Darken(percent));
		}

		public static SolidColorBrush Lighten(this SolidColorBrush i, double percent)
		{
			return new SolidColorBrush(i.Color.Lighten(percent));
		}

		/// <summary>
		/// Method to mix two <c>SolidColorBrush</c> objects at a given opacity
		/// </summary>
		/// <param name="i">
		/// Background <c>SolidColorBrush</c> object
		/// </param>
		/// <param name="foreground">
		/// Foreground <c>SolidColorBrush</c> object
		/// </param>
		/// <param name="opacity">
		/// Opacity value [0.0-1.0] of the overlayed foreground <c>SolidColorBrush</c> object
		/// </param>
		/// <returns>
		/// The mixed <c>SolidColorBrush</c> object
		/// </returns>
		public static SolidColorBrush Blend(this SolidColorBrush i, SolidColorBrush foreground, double opacity)
		{
			var MixedColor = i.Color.Blend(foreground.Color, opacity);
			return new SolidColorBrush(MixedColor);
		}

		/// <summary>
		/// Method to mix two <c>Color</c> objects at a given opacity
		/// </summary>
		/// <param name="i">
		/// Background <c>Color</c> object
		/// </param>
		/// <param name="foreground">
		/// Foreground <c>Color</c> object
		/// </param>
		/// <param name="opacity">
		/// Opacity value [0.0-1.0] of the overlayed foreground <c>Color</c> object
		/// </param>
		/// <returns>
		/// The mixed <c>Color</c> object
		/// </returns>
		public static Color Blend(this Color i, Color foreground, double opacity)
		{
			var difference = Color.Subtract(foreground, i);
			var opacityFlt = Convert.ToSingle(opacity);
			var delta = Color.Multiply(difference, opacityFlt);
			var result = Color.Add(i, delta);
			return result;
		}

		public static SolidColorBrush ToSCB(this Color i) => new SolidColorBrush(i);

		/// <summary>
		/// Method to create a <c>SolidColorBrush</c> object from a GreyScale value
		/// </summary>
		/// <param name="value">
		/// A GreyScale value [0-255] 
		/// </param>
		/// <returns>
		/// The created <c>SolidColorBrush</c> object
		/// </returns>
		public static SolidColorBrush GrayScale(byte value) =>
			new SolidColorBrush(Color.FromRgb(value, value, value));

		public static SolidColorBrush Interpolate(Color a, Color b, double p)
		{
			if (!(p >= 0 && p <= 1)) throw new Exception("color interpolate");
			var nR = (b.R - a.R) * p;
			var nG = (b.G - a.G) * p;
			var nB = (b.B - a.B) * p;

			var eR = Convert.ToByte(a.R + nR);
			var eG = Convert.ToByte(a.G + nG);
			var eB = Convert.ToByte(a.B + nB);

			return new SolidColorBrush(Color.FromRgb(eR, eG, eB));
		}
		public static SolidColorBrush Interpolate(SolidColorBrush a, SolidColorBrush b, double p)
		{
			if (!(p >= 0 && p <= 1)) throw new Exception("brush interpolate");
			var nR = (b.Color.R - a.Color.R) * p;
			var nG = (b.Color.G - a.Color.G) * p;
			var nB = (b.Color.B - a.Color.B) * p;

			var eR = Convert.ToByte(a.Color.R + nR);
			var eG = Convert.ToByte(a.Color.G + nG);
			var eB = Convert.ToByte(a.Color.B + nB);

			return new SolidColorBrush(Color.FromRgb(eR, eG, eB));
		}

		public static MaterialSet Interpolate(MaterialSet a, MaterialSet b, double p)
		{
			var materials = new List<Material>();
			var mc = a.Materials.Count.Smallest(b.Materials.Count);
			if(mc < 1)
				throw new Exception("materialset no materials to interpolate");

			for (var x = 0; x < mc; x++)
			{
				var materialA = a.Materials[x];
				var materialB = b.Materials[x];
				var colorMixed = Interpolate(materialA.Color, materialB.Color, p);
				if (materialA.Luminosity == null)
					throw new Exception("luminosity must not be null");
				if (!Equals(materialA.Luminosity, materialB.Luminosity))
					throw new Exception("luminosity must be the same.");
				materials.Add(new Material(colorMixed.Color, materialA.Luminosity, "interpolated"));
			}

			return new MaterialSet(materials.ToArray());
		}
	}
}
