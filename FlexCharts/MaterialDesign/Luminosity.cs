﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Collections;
using FlexCharts.Markup.TypeConverters;

namespace FlexCharts.MaterialDesign
{
	public class LuminosityConverter : FlexEnumConverter<Luminosity>
	{

	}
	[TypeConverter(typeof(LuminosityConverter))]
	public class Luminosity : FlexEnum<string>
	{
		//public static Luminosity Parse(string luminosity) => FromValue<Luminosity>(luminosity);
		public static Luminosity Parse(string name) => FromName<Luminosity>(name);

		protected Luminosity(string value, [CallerMemberName] string afn = null, [CallerLineNumber] int line = 0) : base(value, afn, line) { }

		public static readonly Luminosity P050 = new Luminosity("050");
		public static readonly Luminosity P100 = new Luminosity("100");
		public static readonly Luminosity P200 = new Luminosity("200");
		public static readonly Luminosity P300 = new Luminosity("300");
		public static readonly Luminosity P400 = new Luminosity("400");
		public static readonly Luminosity P500 = new Luminosity("500");
		public static readonly Luminosity P600 = new Luminosity("600");
		public static readonly Luminosity P700 = new Luminosity("700");
		public static readonly Luminosity P800 = new Luminosity("800");
		public static readonly Luminosity P900 = new Luminosity("900");
		public static readonly Luminosity A100 = new Luminosity("A100");
		public static readonly Luminosity A200 = new Luminosity("A200");
		public static readonly Luminosity A400 = new Luminosity("A400");
		public static readonly Luminosity A700 = new Luminosity("A700");

	}
}