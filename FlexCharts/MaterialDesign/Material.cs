using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FlexCharts.Markup.TypeConverters;

namespace FlexCharts.MaterialDesign
{
	[TypeConverter(typeof(MaterialConverter))]
	public class Material
	{
		public Color Color { get; }
		public SolidColorBrush Brush { get; }
		public Luminosity Luminosity { get; }
		public string BrushFamily { get; }

		public static implicit operator Color(Material d)
		{
			return d.Color;
		}
		public static implicit operator SolidColorBrush(Material d)
		{
			return d.Brush;
		}
		// TODO dont use callermembername. this should all be staticly typed using the other contructor.
		public Material(Color color, [CallerMemberName] string cmn = null)
		{
			Color = color;
			Brush = new SolidColorBrush(color);
			if (cmn == null)
				throw new Exception("CallerMemberName not assigned.");
			var brushName = "";
			var intensityStr = "";
			var hasEncounteredDigit = false;

			foreach (var c in cmn.ToCharArray())
			{
				if (!char.IsLetterOrDigit(c))
					throw new Exception("Improper naming convension for auto brush");

				if (char.IsDigit(c))
				{
					hasEncounteredDigit = true;
					intensityStr += c;
				}
				if (char.IsLetter(c))
				{
					if(hasEncounteredDigit)
						throw new Exception("Improper naming convension for auto brush ([Letter]*A?[Digit]*");
					brushName += c;
				}
			}
			BrushFamily = brushName;
			Luminosity = brushName.EndsWith("A") ? Luminosity.Parse("A" + intensityStr) : Luminosity.Parse("P" + intensityStr);
		}

		public Material(Color color, Luminosity luminosity, string brushFamily)
		{
			Color = color;
			Luminosity = luminosity;
			BrushFamily = brushFamily;
			Brush = new SolidColorBrush(color);
		}

		public Material WithOpacity(double opacity)
		{
			var opacityByte = Convert.ToByte(byte.MaxValue * opacity);
			return new Material(Color.FromArgb(opacityByte, Color.R, Color.G, Color.B));
		}
	}
}
