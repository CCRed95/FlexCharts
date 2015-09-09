using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlexChartsDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//Loaded += OnLoaded;
		}

		//private void OnLoaded(object s, RoutedEventArgs e)
		//{
		//	analyzeMaterialSet(MaterialPalette.Sets.PinkBrushSet);
		//}

		//private void analyzeMaterialSet(MaterialSet materialSet)
		//{
		//	var datastr = "";
		//	foreach (var material in materialSet.Materials)
		//	{
		//		var hsb = RgbToHsb(material.Color);
		//		datastr += $"{material.BrushFamily}, {material.Luminosity},  {hsb.H}, {hsb.S}, {hsb.B}|";
		//	}
		//}
		//private struct HsbColor
		//{
		//	public double A;
		//	public double H;
		//	public double S;
		//	public double B;
		//}
		//private static HsbColor RgbToHsb(Color rgbColor)
		//{
		//	/* Hue values range between 0 and 360. All 
		//	 * other values range between 0 and 1. */

		//	// Create HSB color object
		//	var hsbColor = new HsbColor();

		//	// Get RGB color component values
		//	var r = (int)rgbColor.R;
		//	var g = (int)rgbColor.G;
		//	var b = (int)rgbColor.B;
		//	var a = (int)rgbColor.A;

		//	// Get min, max, and delta values
		//	double min = Math.Min(Math.Min(r, g), b);
		//	double max = Math.Max(Math.Max(r, g), b);
		//	double delta = max - min;

		//	if (max == 0.0)
		//	{
		//		hsbColor.H = 0.0;
		//		hsbColor.S = 0.0;
		//		hsbColor.B = 0.0;
		//		hsbColor.A = a;
		//		return hsbColor;
		//	}

		//	/* Now we process the normal case. */

		//	// Set HSB Alpha value
		//	var alpha = (double)a;
		//	hsbColor.A = alpha / 255;

		//	// Set HSB Hue value
		//	if (r == max) hsbColor.H = (g - b) / delta;
		//	else if (g == max) hsbColor.H = 2 + (b - r) / delta;
		//	else if (b == max) hsbColor.H = 4 + (r - g) / delta;
		//	hsbColor.H *= 60;
		//	if (hsbColor.H < 0.0) hsbColor.H += 360;

		//	// Set other HSB values
		//	hsbColor.S = delta / max;
		//	hsbColor.B = max / 255;

		//	// Set return value
		//	return hsbColor;
		//}


		//private static Color HsbToRgb(HsbColor hsbColor)
		//{
		//	// Initialize
		//	var rgbColor = new Color();

		//	/* Gray (zero saturation) is a special case.We simply
		//	 * set RGB values to HSB Brightness value and exit. */

		//	// Gray: Set RGB and return
		//	if (hsbColor.S == 0.0)
		//	{
		//		rgbColor.A = (byte)(hsbColor.A * 255);
		//		rgbColor.R = (byte)(hsbColor.B * 255);
		//		rgbColor.G = (byte)(hsbColor.B * 255);
		//		rgbColor.B = (byte)(hsbColor.B * 255);
		//		return rgbColor;
		//	}

		//	/* Now we process the normal case. */

		//	var h = (hsbColor.H == 360) ? 0 : hsbColor.H / 60;
		//	var i = (int)(Math.Truncate(h));
		//	var f = h - i;

		//	var p = hsbColor.B * (1.0 - hsbColor.S);
		//	var q = hsbColor.B * (1.0 - (hsbColor.S * f));
		//	var t = hsbColor.B * (1.0 - (hsbColor.S * (1.0 - f)));

		//	double r, g, b;
		//	switch (i)
		//	{
		//		case 0:
		//			r = hsbColor.B;
		//			g = t;
		//			b = p;
		//			break;

		//		case 1:
		//			r = q;
		//			g = hsbColor.B;
		//			b = p;
		//			break;

		//		case 2:
		//			r = p;
		//			g = hsbColor.B;
		//			b = t;
		//			break;

		//		case 3:
		//			r = p;
		//			g = q;
		//			b = hsbColor.B;
		//			break;

		//		case 4:
		//			r = t;
		//			g = p;
		//			b = hsbColor.B;
		//			break;

		//		default:
		//			r = hsbColor.B;
		//			g = p;
		//			b = q;
		//			break;
		//	}

		//	// Set WPF Color object
		//	rgbColor.A = (byte)(hsbColor.A * 255);
		//	rgbColor.R = (byte)(r * 255);
		//	rgbColor.G = (byte)(g * 255);
		//	rgbColor.B = (byte)(b * 255);

		//	// Set return value
		//	return rgbColor;
		//}

	}
}
