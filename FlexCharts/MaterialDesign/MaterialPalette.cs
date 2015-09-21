using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.Require;

namespace FlexCharts.MaterialDesign
{
	public static class MaterialPalette
	{
		
		#region Materials
		public static readonly Material White000 = new Material(Colors.c_White);
		public static readonly Material Black000 = new Material(Colors.c_Black);
		public static readonly Material Transparent000 = new Material(Colors.c_Transparent);

		public static readonly Material Red050 = new Material(Colors.c_Red050);
		public static readonly Material Red100 = new Material(Colors.c_Red100);
		public static readonly Material Red200 = new Material(Colors.c_Red200);
		public static readonly Material Red300 = new Material(Colors.c_Red300);
		public static readonly Material Red400 = new Material(Colors.c_Red400);
		public static readonly Material Red500 = new Material(Colors.c_Red500);
		public static readonly Material Red600 = new Material(Colors.c_Red600);
		public static readonly Material Red700 = new Material(Colors.c_Red700);
		public static readonly Material Red800 = new Material(Colors.c_Red800);
		public static readonly Material Red900 = new Material(Colors.c_Red900);
		public static readonly Material RedA100 = new Material(Colors.c_RedA100);
		public static readonly Material RedA200 = new Material(Colors.c_RedA200);
		public static readonly Material RedA400 = new Material(Colors.c_RedA400);
		public static readonly Material RedA700 = new Material(Colors.c_RedA700);

		public static readonly Material Pink050 = new Material(Colors.c_Pink050);
		public static readonly Material Pink100 = new Material(Colors.c_Pink100);
		public static readonly Material Pink200 = new Material(Colors.c_Pink200);
		public static readonly Material Pink300 = new Material(Colors.c_Pink300);
		public static readonly Material Pink400 = new Material(Colors.c_Pink400);
		public static readonly Material Pink500 = new Material(Colors.c_Pink500);
		public static readonly Material Pink600 = new Material(Colors.c_Pink600);
		public static readonly Material Pink700 = new Material(Colors.c_Pink700);
		public static readonly Material Pink800 = new Material(Colors.c_Pink800);
		public static readonly Material Pink900 = new Material(Colors.c_Pink900);
		public static readonly Material PinkA100 = new Material(Colors.c_PinkA100);
		public static readonly Material PinkA200 = new Material(Colors.c_PinkA200);
		public static readonly Material PinkA400 = new Material(Colors.c_PinkA400);
		public static readonly Material PinkA700 = new Material(Colors.c_PinkA700);

		public static readonly Material Purple050 = new Material(Colors.c_Purple050);
		public static readonly Material Purple100 = new Material(Colors.c_Purple100);
		public static readonly Material Purple200 = new Material(Colors.c_Purple200);
		public static readonly Material Purple300 = new Material(Colors.c_Purple300);
		public static readonly Material Purple400 = new Material(Colors.c_Purple400);
		public static readonly Material Purple500 = new Material(Colors.c_Purple500);
		public static readonly Material Purple600 = new Material(Colors.c_Purple600);
		public static readonly Material Purple700 = new Material(Colors.c_Purple700);
		public static readonly Material Purple800 = new Material(Colors.c_Purple800);
		public static readonly Material Purple900 = new Material(Colors.c_Purple900);
		public static readonly Material PurpleA100 = new Material(Colors.c_PurpleA100);
		public static readonly Material PurpleA200 = new Material(Colors.c_PurpleA200);
		public static readonly Material PurpleA400 = new Material(Colors.c_PurpleA400);
		public static readonly Material PurpleA700 = new Material(Colors.c_PurpleA700);

		public static readonly Material DeepPurple050 = new Material(Colors.c_DeepPurple050);
		public static readonly Material DeepPurple100 = new Material(Colors.c_DeepPurple100);
		public static readonly Material DeepPurple200 = new Material(Colors.c_DeepPurple200);
		public static readonly Material DeepPurple300 = new Material(Colors.c_DeepPurple300);
		public static readonly Material DeepPurple400 = new Material(Colors.c_DeepPurple400);
		public static readonly Material DeepPurple500 = new Material(Colors.c_DeepPurple500);
		public static readonly Material DeepPurple600 = new Material(Colors.c_DeepPurple600);
		public static readonly Material DeepPurple700 = new Material(Colors.c_DeepPurple700);
		public static readonly Material DeepPurple800 = new Material(Colors.c_DeepPurple800);
		public static readonly Material DeepPurple900 = new Material(Colors.c_DeepPurple900);
		public static readonly Material DeepPurpleA100 = new Material(Colors.c_DeepPurpleA100);
		public static readonly Material DeepPurpleA200 = new Material(Colors.c_DeepPurpleA200);
		public static readonly Material DeepPurpleA400 = new Material(Colors.c_DeepPurpleA400);
		public static readonly Material DeepPurpleA700 = new Material(Colors.c_DeepPurpleA700);

		public static readonly Material Indigo050 = new Material(Colors.c_Indigo050);
		public static readonly Material Indigo100 = new Material(Colors.c_Indigo100);
		public static readonly Material Indigo200 = new Material(Colors.c_Indigo200);
		public static readonly Material Indigo300 = new Material(Colors.c_Indigo300);
		public static readonly Material Indigo400 = new Material(Colors.c_Indigo400);
		public static readonly Material Indigo500 = new Material(Colors.c_Indigo500);
		public static readonly Material Indigo600 = new Material(Colors.c_Indigo600);
		public static readonly Material Indigo700 = new Material(Colors.c_Indigo700);
		public static readonly Material Indigo800 = new Material(Colors.c_Indigo800);
		public static readonly Material Indigo900 = new Material(Colors.c_Indigo900);
		public static readonly Material IndigoA100 = new Material(Colors.c_IndigoA100);
		public static readonly Material IndigoA200 = new Material(Colors.c_IndigoA200);
		public static readonly Material IndigoA400 = new Material(Colors.c_IndigoA400);
		public static readonly Material IndigoA700 = new Material(Colors.c_IndigoA700);

		public static readonly Material Blue050 = new Material(Colors.c_Blue050);
		public static readonly Material Blue100 = new Material(Colors.c_Blue100);
		public static readonly Material Blue200 = new Material(Colors.c_Blue200);
		public static readonly Material Blue300 = new Material(Colors.c_Blue300);
		public static readonly Material Blue400 = new Material(Colors.c_Blue400);
		public static readonly Material Blue500 = new Material(Colors.c_Blue500);
		public static readonly Material Blue600 = new Material(Colors.c_Blue600);
		public static readonly Material Blue700 = new Material(Colors.c_Blue700);
		public static readonly Material Blue800 = new Material(Colors.c_Blue800);
		public static readonly Material Blue900 = new Material(Colors.c_Blue900);
		public static readonly Material BlueA100 = new Material(Colors.c_BlueA100);
		public static readonly Material BlueA200 = new Material(Colors.c_BlueA200);
		public static readonly Material BlueA400 = new Material(Colors.c_BlueA400);
		public static readonly Material BlueA700 = new Material(Colors.c_BlueA700);

		public static readonly Material LightBlue050 = new Material(Colors.c_LightBlue050);
		public static readonly Material LightBlue100 = new Material(Colors.c_LightBlue100);
		public static readonly Material LightBlue200 = new Material(Colors.c_LightBlue200);
		public static readonly Material LightBlue300 = new Material(Colors.c_LightBlue300);
		public static readonly Material LightBlue400 = new Material(Colors.c_LightBlue400);
		public static readonly Material LightBlue500 = new Material(Colors.c_LightBlue500);
		public static readonly Material LightBlue600 = new Material(Colors.c_LightBlue600);
		public static readonly Material LightBlue700 = new Material(Colors.c_LightBlue700);
		public static readonly Material LightBlue800 = new Material(Colors.c_LightBlue800);
		public static readonly Material LightBlue900 = new Material(Colors.c_LightBlue900);
		public static readonly Material LightBlueA100 = new Material(Colors.c_LightBlueA100);
		public static readonly Material LightBlueA200 = new Material(Colors.c_LightBlueA200);
		public static readonly Material LightBlueA400 = new Material(Colors.c_LightBlueA400);
		public static readonly Material LightBlueA700 = new Material(Colors.c_LightBlueA700);

		public static readonly Material Cyan050 = new Material(Colors.c_Cyan050);
		public static readonly Material Cyan100 = new Material(Colors.c_Cyan100);
		public static readonly Material Cyan200 = new Material(Colors.c_Cyan200);
		public static readonly Material Cyan300 = new Material(Colors.c_Cyan300);
		public static readonly Material Cyan400 = new Material(Colors.c_Cyan400);
		public static readonly Material Cyan500 = new Material(Colors.c_Cyan500);
		public static readonly Material Cyan600 = new Material(Colors.c_Cyan600);
		public static readonly Material Cyan700 = new Material(Colors.c_Cyan700);
		public static readonly Material Cyan800 = new Material(Colors.c_Cyan800);
		public static readonly Material Cyan900 = new Material(Colors.c_Cyan900);
		public static readonly Material CyanA100 = new Material(Colors.c_CyanA100);
		public static readonly Material CyanA200 = new Material(Colors.c_CyanA200);
		public static readonly Material CyanA400 = new Material(Colors.c_CyanA400);
		public static readonly Material CyanA700 = new Material(Colors.c_CyanA700);

		public static readonly Material Teal050 = new Material(Colors.c_Teal050);
		public static readonly Material Teal100 = new Material(Colors.c_Teal100);
		public static readonly Material Teal200 = new Material(Colors.c_Teal200);
		public static readonly Material Teal300 = new Material(Colors.c_Teal300);
		public static readonly Material Teal400 = new Material(Colors.c_Teal400);
		public static readonly Material Teal500 = new Material(Colors.c_Teal500);
		public static readonly Material Teal600 = new Material(Colors.c_Teal600);
		public static readonly Material Teal700 = new Material(Colors.c_Teal700);
		public static readonly Material Teal800 = new Material(Colors.c_Teal800);
		public static readonly Material Teal900 = new Material(Colors.c_Teal900);
		public static readonly Material TealA100 = new Material(Colors.c_TealA100);
		public static readonly Material TealA200 = new Material(Colors.c_TealA200);
		public static readonly Material TealA400 = new Material(Colors.c_TealA400);
		public static readonly Material TealA700 = new Material(Colors.c_TealA700);

		public static readonly Material Green050 = new Material(Colors.c_Green050);
		public static readonly Material Green100 = new Material(Colors.c_Green100);
		public static readonly Material Green200 = new Material(Colors.c_Green200);
		public static readonly Material Green300 = new Material(Colors.c_Green300);
		public static readonly Material Green400 = new Material(Colors.c_Green400);
		public static readonly Material Green500 = new Material(Colors.c_Green500);
		public static readonly Material Green600 = new Material(Colors.c_Green600);
		public static readonly Material Green700 = new Material(Colors.c_Green700);
		public static readonly Material Green800 = new Material(Colors.c_Green800);
		public static readonly Material Green900 = new Material(Colors.c_Green900);
		public static readonly Material GreenA100 = new Material(Colors.c_GreenA100);
		public static readonly Material GreenA200 = new Material(Colors.c_GreenA200);
		public static readonly Material GreenA400 = new Material(Colors.c_GreenA400);
		public static readonly Material GreenA700 = new Material(Colors.c_GreenA700);

		public static readonly Material LightGreen050 = new Material(Colors.c_LightGreen050);
		public static readonly Material LightGreen100 = new Material(Colors.c_LightGreen100);
		public static readonly Material LightGreen200 = new Material(Colors.c_LightGreen200);
		public static readonly Material LightGreen300 = new Material(Colors.c_LightGreen300);
		public static readonly Material LightGreen400 = new Material(Colors.c_LightGreen400);
		public static readonly Material LightGreen500 = new Material(Colors.c_LightGreen500);
		public static readonly Material LightGreen600 = new Material(Colors.c_LightGreen600);
		public static readonly Material LightGreen700 = new Material(Colors.c_LightGreen700);
		public static readonly Material LightGreen800 = new Material(Colors.c_LightGreen800);
		public static readonly Material LightGreen900 = new Material(Colors.c_LightGreen900);
		public static readonly Material LightGreenA100 = new Material(Colors.c_LightGreenA100);
		public static readonly Material LightGreenA200 = new Material(Colors.c_LightGreenA200);
		public static readonly Material LightGreenA400 = new Material(Colors.c_LightGreenA400);
		public static readonly Material LightGreenA700 = new Material(Colors.c_LightGreenA700);

		public static readonly Material Lime050 = new Material(Colors.c_Lime050);
		public static readonly Material Lime100 = new Material(Colors.c_Lime100);
		public static readonly Material Lime200 = new Material(Colors.c_Lime200);
		public static readonly Material Lime300 = new Material(Colors.c_Lime300);
		public static readonly Material Lime400 = new Material(Colors.c_Lime400);
		public static readonly Material Lime500 = new Material(Colors.c_Lime500);
		public static readonly Material Lime600 = new Material(Colors.c_Lime600);
		public static readonly Material Lime700 = new Material(Colors.c_Lime700);
		public static readonly Material Lime800 = new Material(Colors.c_Lime800);
		public static readonly Material Lime900 = new Material(Colors.c_Lime900);
		public static readonly Material LimeA100 = new Material(Colors.c_LimeA100);
		public static readonly Material LimeA200 = new Material(Colors.c_LimeA200);
		public static readonly Material LimeA400 = new Material(Colors.c_LimeA400);
		public static readonly Material LimeA700 = new Material(Colors.c_LimeA700);

		public static readonly Material Yellow050 = new Material(Colors.c_Yellow050);
		public static readonly Material Yellow100 = new Material(Colors.c_Yellow100);
		public static readonly Material Yellow200 = new Material(Colors.c_Yellow200);
		public static readonly Material Yellow300 = new Material(Colors.c_Yellow300);
		public static readonly Material Yellow400 = new Material(Colors.c_Yellow400);
		public static readonly Material Yellow500 = new Material(Colors.c_Yellow500);
		public static readonly Material Yellow600 = new Material(Colors.c_Yellow600);
		public static readonly Material Yellow700 = new Material(Colors.c_Yellow700);
		public static readonly Material Yellow800 = new Material(Colors.c_Yellow800);
		public static readonly Material Yellow900 = new Material(Colors.c_Yellow900);
		public static readonly Material YellowA100 = new Material(Colors.c_YellowA100);
		public static readonly Material YellowA200 = new Material(Colors.c_YellowA200);
		public static readonly Material YellowA400 = new Material(Colors.c_YellowA400);
		public static readonly Material YellowA700 = new Material(Colors.c_YellowA700);

		public static readonly Material Amber050 = new Material(Colors.c_Amber050);
		public static readonly Material Amber100 = new Material(Colors.c_Amber100);
		public static readonly Material Amber200 = new Material(Colors.c_Amber200);
		public static readonly Material Amber300 = new Material(Colors.c_Amber300);
		public static readonly Material Amber400 = new Material(Colors.c_Amber400);
		public static readonly Material Amber500 = new Material(Colors.c_Amber500);
		public static readonly Material Amber600 = new Material(Colors.c_Amber600);
		public static readonly Material Amber700 = new Material(Colors.c_Amber700);
		public static readonly Material Amber800 = new Material(Colors.c_Amber800);
		public static readonly Material Amber900 = new Material(Colors.c_Amber900);
		public static readonly Material AmberA100 = new Material(Colors.c_AmberA100);
		public static readonly Material AmberA200 = new Material(Colors.c_AmberA200);
		public static readonly Material AmberA400 = new Material(Colors.c_AmberA400);
		public static readonly Material AmberA700 = new Material(Colors.c_AmberA700);

		public static readonly Material Orange050 = new Material(Colors.c_Orange050);
		public static readonly Material Orange100 = new Material(Colors.c_Orange100);
		public static readonly Material Orange200 = new Material(Colors.c_Orange200);
		public static readonly Material Orange300 = new Material(Colors.c_Orange300);
		public static readonly Material Orange400 = new Material(Colors.c_Orange400);
		public static readonly Material Orange500 = new Material(Colors.c_Orange500);
		public static readonly Material Orange600 = new Material(Colors.c_Orange600);
		public static readonly Material Orange700 = new Material(Colors.c_Orange700);
		public static readonly Material Orange800 = new Material(Colors.c_Orange800);
		public static readonly Material Orange900 = new Material(Colors.c_Orange900);
		public static readonly Material OrangeA100 = new Material(Colors.c_OrangeA100);
		public static readonly Material OrangeA200 = new Material(Colors.c_OrangeA200);
		public static readonly Material OrangeA400 = new Material(Colors.c_OrangeA400);
		public static readonly Material OrangeA700 = new Material(Colors.c_OrangeA700);

		public static readonly Material DeepOrange050 = new Material(Colors.c_DeepOrange050);
		public static readonly Material DeepOrange100 = new Material(Colors.c_DeepOrange100);
		public static readonly Material DeepOrange200 = new Material(Colors.c_DeepOrange200);
		public static readonly Material DeepOrange300 = new Material(Colors.c_DeepOrange300);
		public static readonly Material DeepOrange400 = new Material(Colors.c_DeepOrange400);
		public static readonly Material DeepOrange500 = new Material(Colors.c_DeepOrange500);
		public static readonly Material DeepOrange600 = new Material(Colors.c_DeepOrange600);
		public static readonly Material DeepOrange700 = new Material(Colors.c_DeepOrange700);
		public static readonly Material DeepOrange800 = new Material(Colors.c_DeepOrange800);
		public static readonly Material DeepOrange900 = new Material(Colors.c_DeepOrange900);
		public static readonly Material DeepOrangeA100 = new Material(Colors.c_DeepOrangeA100);
		public static readonly Material DeepOrangeA200 = new Material(Colors.c_DeepOrangeA200);
		public static readonly Material DeepOrangeA400 = new Material(Colors.c_DeepOrangeA400);
		public static readonly Material DeepOrangeA700 = new Material(Colors.c_DeepOrangeA700);

		public static readonly Material Brown050 = new Material(Colors.c_Brown050);
		public static readonly Material Brown100 = new Material(Colors.c_Brown100);
		public static readonly Material Brown200 = new Material(Colors.c_Brown200);
		public static readonly Material Brown300 = new Material(Colors.c_Brown300);
		public static readonly Material Brown400 = new Material(Colors.c_Brown400);
		public static readonly Material Brown500 = new Material(Colors.c_Brown500);
		public static readonly Material Brown600 = new Material(Colors.c_Brown600);
		public static readonly Material Brown700 = new Material(Colors.c_Brown700);
		public static readonly Material Brown800 = new Material(Colors.c_Brown800);
		public static readonly Material Brown900 = new Material(Colors.c_Brown900);

		public static readonly Material Grey050 = new Material(Colors.c_Grey050);
		public static readonly Material Grey100 = new Material(Colors.c_Grey100);
		public static readonly Material Grey200 = new Material(Colors.c_Grey200);
		public static readonly Material Grey300 = new Material(Colors.c_Grey300);
		public static readonly Material Grey400 = new Material(Colors.c_Grey400);
		public static readonly Material Grey500 = new Material(Colors.c_Grey500);
		public static readonly Material Grey600 = new Material(Colors.c_Grey600);
		public static readonly Material Grey700 = new Material(Colors.c_Grey700);
		public static readonly Material Grey800 = new Material(Colors.c_Grey800);
		public static readonly Material Grey900 = new Material(Colors.c_Grey900);

		public static readonly Material BlueGrey050 = new Material(Colors.c_BlueGrey050);
		public static readonly Material BlueGrey100 = new Material(Colors.c_BlueGrey100);
		public static readonly Material BlueGrey200 = new Material(Colors.c_BlueGrey200);
		public static readonly Material BlueGrey300 = new Material(Colors.c_BlueGrey300);
		public static readonly Material BlueGrey400 = new Material(Colors.c_BlueGrey400);
		public static readonly Material BlueGrey500 = new Material(Colors.c_BlueGrey500);
		public static readonly Material BlueGrey600 = new Material(Colors.c_BlueGrey600);
		public static readonly Material BlueGrey700 = new Material(Colors.c_BlueGrey700);
		public static readonly Material BlueGrey800 = new Material(Colors.c_BlueGrey800);
		public static readonly Material BlueGrey900 = new Material(Colors.c_BlueGrey900);
		#endregion

		public class Colors
		{
			public static readonly Color c_Transparent = Color.FromArgb(0, 255, 255, 255);
			public static readonly Color c_White = Color.FromRgb(255, 255, 255);
			public static readonly Color c_Black = Color.FromRgb(0, 0, 0);
			public static readonly Color c_Red050 = Color.FromRgb(255, 235, 238);
			public static readonly Color c_Red100 = Color.FromRgb(255, 205, 210);
			public static readonly Color c_Red200 = Color.FromRgb(239, 154, 154);
			public static readonly Color c_Red300 = Color.FromRgb(229, 115, 115);
			public static readonly Color c_Red400 = Color.FromRgb(239, 83, 80);
			public static readonly Color c_Red500 = Color.FromRgb(244, 67, 54);
			public static readonly Color c_Red600 = Color.FromRgb(229, 57, 53);
			public static readonly Color c_Red700 = Color.FromRgb(211, 47, 47);
			public static readonly Color c_Red800 = Color.FromRgb(198, 40, 40);
			public static readonly Color c_Red900 = Color.FromRgb(183, 28, 28);
			public static readonly Color c_Pink050 = Color.FromRgb(252, 228, 236);
			public static readonly Color c_Pink100 = Color.FromRgb(248, 187, 208);
			public static readonly Color c_Pink200 = Color.FromRgb(244, 143, 177);
			public static readonly Color c_Pink300 = Color.FromRgb(240, 98, 146);
			public static readonly Color c_Pink400 = Color.FromRgb(236, 64, 122);
			public static readonly Color c_Pink500 = Color.FromRgb(233, 30, 99);
			public static readonly Color c_Pink600 = Color.FromRgb(216, 27, 96);
			public static readonly Color c_Pink700 = Color.FromRgb(194, 24, 91);
			public static readonly Color c_Pink800 = Color.FromRgb(173, 20, 87);
			public static readonly Color c_Pink900 = Color.FromRgb(136, 14, 79);
			public static readonly Color c_Purple050 = Color.FromRgb(243, 229, 245);
			public static readonly Color c_Purple100 = Color.FromRgb(225, 190, 231);
			public static readonly Color c_Purple200 = Color.FromRgb(206, 147, 216);
			public static readonly Color c_Purple300 = Color.FromRgb(186, 104, 200);
			public static readonly Color c_Purple400 = Color.FromRgb(171, 71, 188);
			public static readonly Color c_Purple500 = Color.FromRgb(156, 39, 176);
			public static readonly Color c_Purple600 = Color.FromRgb(142, 36, 170);
			public static readonly Color c_Purple700 = Color.FromRgb(123, 31, 162);
			public static readonly Color c_Purple800 = Color.FromRgb(106, 27, 154);
			public static readonly Color c_Purple900 = Color.FromRgb(74, 20, 140);
			public static readonly Color c_DeepPurple050 = Color.FromRgb(237, 231, 246);
			public static readonly Color c_DeepPurple100 = Color.FromRgb(209, 196, 233);
			public static readonly Color c_DeepPurple200 = Color.FromRgb(179, 157, 219);
			public static readonly Color c_DeepPurple300 = Color.FromRgb(149, 117, 205);
			public static readonly Color c_DeepPurple400 = Color.FromRgb(126, 87, 194);
			public static readonly Color c_DeepPurple500 = Color.FromRgb(103, 58, 183);
			public static readonly Color c_DeepPurple600 = Color.FromRgb(94, 53, 177);
			public static readonly Color c_DeepPurple700 = Color.FromRgb(81, 45, 168);
			public static readonly Color c_DeepPurple800 = Color.FromRgb(69, 39, 160);
			public static readonly Color c_DeepPurple900 = Color.FromRgb(49, 27, 146);
			public static readonly Color c_Indigo050 = Color.FromRgb(232, 234, 246);
			public static readonly Color c_Indigo100 = Color.FromRgb(197, 202, 233);
			public static readonly Color c_Indigo200 = Color.FromRgb(159, 168, 218);
			public static readonly Color c_Indigo300 = Color.FromRgb(121, 134, 203);
			public static readonly Color c_Indigo400 = Color.FromRgb(92, 107, 192);
			public static readonly Color c_Indigo500 = Color.FromRgb(63, 81, 181);
			public static readonly Color c_Indigo600 = Color.FromRgb(57, 73, 171);
			public static readonly Color c_Indigo700 = Color.FromRgb(48, 63, 159);
			public static readonly Color c_Indigo800 = Color.FromRgb(40, 53, 147);
			public static readonly Color c_Indigo900 = Color.FromRgb(26, 35, 126);
			public static readonly Color c_Blue050 = Color.FromRgb(227, 242, 253);
			public static readonly Color c_Blue100 = Color.FromRgb(187, 222, 251);
			public static readonly Color c_Blue200 = Color.FromRgb(144, 202, 249);
			public static readonly Color c_Blue300 = Color.FromRgb(100, 181, 246);
			public static readonly Color c_Blue400 = Color.FromRgb(66, 165, 245);
			public static readonly Color c_Blue500 = Color.FromRgb(33, 150, 243);
			public static readonly Color c_Blue600 = Color.FromRgb(30, 136, 229);
			public static readonly Color c_Blue700 = Color.FromRgb(25, 118, 210);
			public static readonly Color c_Blue800 = Color.FromRgb(21, 101, 192);
			public static readonly Color c_Blue900 = Color.FromRgb(13, 71, 161);
			public static readonly Color c_LightBlue050 = Color.FromRgb(225, 245, 254);
			public static readonly Color c_LightBlue100 = Color.FromRgb(179, 229, 252);
			public static readonly Color c_LightBlue200 = Color.FromRgb(129, 212, 250);
			public static readonly Color c_LightBlue300 = Color.FromRgb(79, 195, 247);
			public static readonly Color c_LightBlue400 = Color.FromRgb(41, 182, 246);
			public static readonly Color c_LightBlue500 = Color.FromRgb(3, 169, 244);
			public static readonly Color c_LightBlue600 = Color.FromRgb(3, 155, 229);
			public static readonly Color c_LightBlue700 = Color.FromRgb(2, 136, 209);
			public static readonly Color c_LightBlue800 = Color.FromRgb(2, 119, 189);
			public static readonly Color c_LightBlue900 = Color.FromRgb(1, 87, 155);
			public static readonly Color c_Cyan050 = Color.FromRgb(224, 247, 250);
			public static readonly Color c_Cyan100 = Color.FromRgb(178, 235, 242);
			public static readonly Color c_Cyan200 = Color.FromRgb(128, 222, 234);
			public static readonly Color c_Cyan300 = Color.FromRgb(77, 208, 225);
			public static readonly Color c_Cyan400 = Color.FromRgb(38, 198, 218);
			public static readonly Color c_Cyan500 = Color.FromRgb(0, 188, 212);
			public static readonly Color c_Cyan600 = Color.FromRgb(0, 172, 193);
			public static readonly Color c_Cyan700 = Color.FromRgb(0, 151, 167);
			public static readonly Color c_Cyan800 = Color.FromRgb(0, 131, 143);
			public static readonly Color c_Cyan900 = Color.FromRgb(0, 96, 100);
			public static readonly Color c_Teal050 = Color.FromRgb(224, 242, 241);
			public static readonly Color c_Teal100 = Color.FromRgb(178, 223, 219);
			public static readonly Color c_Teal200 = Color.FromRgb(128, 203, 196);
			public static readonly Color c_Teal300 = Color.FromRgb(77, 182, 172);
			public static readonly Color c_Teal400 = Color.FromRgb(38, 166, 154);
			public static readonly Color c_Teal500 = Color.FromRgb(0, 150, 136);
			public static readonly Color c_Teal600 = Color.FromRgb(0, 137, 123);
			public static readonly Color c_Teal700 = Color.FromRgb(0, 121, 107);
			public static readonly Color c_Teal800 = Color.FromRgb(0, 105, 92);
			public static readonly Color c_Teal900 = Color.FromRgb(0, 77, 64);
			public static readonly Color c_Green050 = Color.FromRgb(232, 245, 233);
			public static readonly Color c_Green100 = Color.FromRgb(200, 230, 201);
			public static readonly Color c_Green200 = Color.FromRgb(165, 214, 167);
			public static readonly Color c_Green300 = Color.FromRgb(129, 199, 132);
			public static readonly Color c_Green400 = Color.FromRgb(102, 187, 106);
			public static readonly Color c_Green500 = Color.FromRgb(76, 175, 80);
			public static readonly Color c_Green600 = Color.FromRgb(67, 160, 71);
			public static readonly Color c_Green700 = Color.FromRgb(56, 142, 60);
			public static readonly Color c_Green800 = Color.FromRgb(46, 125, 050);
			public static readonly Color c_Green900 = Color.FromRgb(27, 94, 32);
			public static readonly Color c_LightGreen050 = Color.FromRgb(241, 248, 233);
			public static readonly Color c_LightGreen100 = Color.FromRgb(220, 237, 200);
			public static readonly Color c_LightGreen200 = Color.FromRgb(197, 225, 165);
			public static readonly Color c_LightGreen300 = Color.FromRgb(174, 213, 129);
			public static readonly Color c_LightGreen400 = Color.FromRgb(156, 204, 101);
			public static readonly Color c_LightGreen500 = Color.FromRgb(139, 195, 74);
			public static readonly Color c_LightGreen600 = Color.FromRgb(124, 179, 66);
			public static readonly Color c_LightGreen700 = Color.FromRgb(104, 159, 56);
			public static readonly Color c_LightGreen800 = Color.FromRgb(85, 139, 47);
			public static readonly Color c_LightGreen900 = Color.FromRgb(51, 105, 30);
			public static readonly Color c_Lime050 = Color.FromRgb(249, 251, 231);
			public static readonly Color c_Lime100 = Color.FromRgb(240, 244, 195);
			public static readonly Color c_Lime200 = Color.FromRgb(230, 238, 156);
			public static readonly Color c_Lime300 = Color.FromRgb(220, 231, 117);
			public static readonly Color c_Lime400 = Color.FromRgb(212, 225, 87);
			public static readonly Color c_Lime500 = Color.FromRgb(205, 220, 57);
			public static readonly Color c_Lime600 = Color.FromRgb(192, 202, 51);
			public static readonly Color c_Lime700 = Color.FromRgb(175, 180, 43);
			public static readonly Color c_Lime800 = Color.FromRgb(158, 157, 36);
			public static readonly Color c_Lime900 = Color.FromRgb(130, 119, 23);
			public static readonly Color c_Yellow050 = Color.FromRgb(255, 253, 231);
			public static readonly Color c_Yellow100 = Color.FromRgb(255, 249, 196);
			public static readonly Color c_Yellow200 = Color.FromRgb(255, 245, 157);
			public static readonly Color c_Yellow300 = Color.FromRgb(255, 241, 118);
			public static readonly Color c_Yellow400 = Color.FromRgb(255, 238, 88);
			public static readonly Color c_Yellow500 = Color.FromRgb(255, 235, 59);
			public static readonly Color c_Yellow600 = Color.FromRgb(253, 216, 53);
			public static readonly Color c_Yellow700 = Color.FromRgb(251, 192, 45);
			public static readonly Color c_Yellow800 = Color.FromRgb(249, 168, 37);
			public static readonly Color c_Yellow900 = Color.FromRgb(245, 127, 23);
			public static readonly Color c_Amber050 = Color.FromRgb(255, 248, 225);
			public static readonly Color c_Amber100 = Color.FromRgb(255, 236, 179);
			public static readonly Color c_Amber200 = Color.FromRgb(255, 224, 130);
			public static readonly Color c_Amber300 = Color.FromRgb(255, 213, 79);
			public static readonly Color c_Amber400 = Color.FromRgb(255, 202, 40);
			public static readonly Color c_Amber500 = Color.FromRgb(255, 193, 7);
			public static readonly Color c_Amber600 = Color.FromRgb(255, 179, 0);
			public static readonly Color c_Amber700 = Color.FromRgb(255, 160, 0);
			public static readonly Color c_Amber800 = Color.FromRgb(255, 143, 0);
			public static readonly Color c_Amber900 = Color.FromRgb(255, 111, 0);
			public static readonly Color c_Orange050 = Color.FromRgb(255, 243, 224);
			public static readonly Color c_Orange100 = Color.FromRgb(255, 224, 178);
			public static readonly Color c_Orange200 = Color.FromRgb(255, 204, 128);
			public static readonly Color c_Orange300 = Color.FromRgb(255, 183, 77);
			public static readonly Color c_Orange400 = Color.FromRgb(255, 167, 38);
			public static readonly Color c_Orange500 = Color.FromRgb(255, 152, 0);
			public static readonly Color c_Orange600 = Color.FromRgb(251, 140, 0);
			public static readonly Color c_Orange700 = Color.FromRgb(245, 124, 0);
			public static readonly Color c_Orange800 = Color.FromRgb(239, 108, 0);
			public static readonly Color c_Orange900 = Color.FromRgb(230, 81, 0);
			public static readonly Color c_DeepOrange050 = Color.FromRgb(251, 233, 231);
			public static readonly Color c_DeepOrange100 = Color.FromRgb(255, 204, 188);
			public static readonly Color c_DeepOrange200 = Color.FromRgb(255, 171, 145);
			public static readonly Color c_DeepOrange300 = Color.FromRgb(255, 138, 101);
			public static readonly Color c_DeepOrange400 = Color.FromRgb(255, 112, 67);
			public static readonly Color c_DeepOrange500 = Color.FromRgb(255, 87, 34);
			public static readonly Color c_DeepOrange600 = Color.FromRgb(244, 81, 30);
			public static readonly Color c_DeepOrange700 = Color.FromRgb(230, 74, 25);
			public static readonly Color c_DeepOrange800 = Color.FromRgb(216, 67, 21);
			public static readonly Color c_DeepOrange900 = Color.FromRgb(191, 54, 12);
			public static readonly Color c_Brown050 = Color.FromRgb(239, 235, 233);
			public static readonly Color c_Brown100 = Color.FromRgb(215, 204, 200);
			public static readonly Color c_Brown200 = Color.FromRgb(188, 170, 164);
			public static readonly Color c_Brown300 = Color.FromRgb(161, 136, 127);
			public static readonly Color c_Brown400 = Color.FromRgb(141, 110, 99);
			public static readonly Color c_Brown500 = Color.FromRgb(121, 85, 72);
			public static readonly Color c_Brown600 = Color.FromRgb(109, 76, 65);
			public static readonly Color c_Brown700 = Color.FromRgb(93, 64, 55);
			public static readonly Color c_Brown800 = Color.FromRgb(78, 52, 46);
			public static readonly Color c_Brown900 = Color.FromRgb(62, 39, 35);
			public static readonly Color c_Grey050 = Color.FromRgb(250, 250, 250);
			public static readonly Color c_Grey100 = Color.FromRgb(245, 245, 245);
			public static readonly Color c_Grey200 = Color.FromRgb(238, 238, 238);
			public static readonly Color c_Grey300 = Color.FromRgb(224, 224, 224);
			public static readonly Color c_Grey400 = Color.FromRgb(189, 189, 189);
			public static readonly Color c_Grey500 = Color.FromRgb(158, 158, 158);
			public static readonly Color c_Grey600 = Color.FromRgb(117, 117, 117);
			public static readonly Color c_Grey700 = Color.FromRgb(97, 97, 97);
			public static readonly Color c_Grey800 = Color.FromRgb(66, 66, 66);
			public static readonly Color c_Grey900 = Color.FromRgb(33, 33, 33);
			public static readonly Color c_BlueGrey050 = Color.FromRgb(236, 239, 241);
			public static readonly Color c_BlueGrey100 = Color.FromRgb(207, 216, 220);
			public static readonly Color c_BlueGrey200 = Color.FromRgb(176, 190, 197);
			public static readonly Color c_BlueGrey300 = Color.FromRgb(144, 164, 174);
			public static readonly Color c_BlueGrey400 = Color.FromRgb(120, 144, 156);
			public static readonly Color c_BlueGrey500 = Color.FromRgb(96, 125, 139);
			public static readonly Color c_BlueGrey600 = Color.FromRgb(84, 110, 122);
			public static readonly Color c_BlueGrey700 = Color.FromRgb(69, 90, 100);
			public static readonly Color c_BlueGrey800 = Color.FromRgb(55, 71, 79);
			public static readonly Color c_BlueGrey900 = Color.FromRgb(38, 50, 56);
			public static readonly Color c_RedA100 = Color.FromRgb(255, 138, 128);
			public static readonly Color c_RedA200 = Color.FromRgb(255, 82, 82);
			public static readonly Color c_RedA400 = Color.FromRgb(255, 23, 68);
			public static readonly Color c_RedA700 = Color.FromRgb(213, 0, 0);
			public static readonly Color c_PinkA100 = Color.FromRgb(255, 128, 171);
			public static readonly Color c_PinkA200 = Color.FromRgb(255, 64, 129);
			public static readonly Color c_PinkA400 = Color.FromRgb(245, 0, 87);
			public static readonly Color c_PinkA700 = Color.FromRgb(197, 17, 98);
			public static readonly Color c_PurpleA100 = Color.FromRgb(234, 128, 252);
			public static readonly Color c_PurpleA200 = Color.FromRgb(224, 64, 251);
			public static readonly Color c_PurpleA400 = Color.FromRgb(213, 0, 249);
			public static readonly Color c_PurpleA700 = Color.FromRgb(170, 0, 255);
			public static readonly Color c_DeepPurpleA100 = Color.FromRgb(179, 136, 255);
			public static readonly Color c_DeepPurpleA200 = Color.FromRgb(124, 77, 255);
			public static readonly Color c_DeepPurpleA400 = Color.FromRgb(101, 31, 255);
			public static readonly Color c_DeepPurpleA700 = Color.FromRgb(98, 0, 234);
			public static readonly Color c_IndigoA100 = Color.FromRgb(140, 158, 255);
			public static readonly Color c_IndigoA200 = Color.FromRgb(83, 109, 254);
			public static readonly Color c_IndigoA400 = Color.FromRgb(61, 90, 254);
			public static readonly Color c_IndigoA700 = Color.FromRgb(48, 79, 254);
			public static readonly Color c_BlueA100 = Color.FromRgb(130, 177, 255);
			public static readonly Color c_BlueA200 = Color.FromRgb(68, 138, 255);
			public static readonly Color c_BlueA400 = Color.FromRgb(41, 121, 255);
			public static readonly Color c_BlueA700 = Color.FromRgb(41, 98, 255);
			public static readonly Color c_LightBlueA100 = Color.FromRgb(128, 216, 255);
			public static readonly Color c_LightBlueA200 = Color.FromRgb(64, 196, 255);
			public static readonly Color c_LightBlueA400 = Color.FromRgb(0, 176, 255);
			public static readonly Color c_LightBlueA700 = Color.FromRgb(0, 145, 234);
			public static readonly Color c_CyanA100 = Color.FromRgb(132, 255, 255);
			public static readonly Color c_CyanA200 = Color.FromRgb(24, 255, 255);
			public static readonly Color c_CyanA400 = Color.FromRgb(0, 229, 255);
			public static readonly Color c_CyanA700 = Color.FromRgb(0, 184, 212);
			public static readonly Color c_TealA100 = Color.FromRgb(167, 255, 235);
			public static readonly Color c_TealA200 = Color.FromRgb(100, 255, 218);
			public static readonly Color c_TealA400 = Color.FromRgb(29, 233, 182);
			public static readonly Color c_TealA700 = Color.FromRgb(0, 191, 165);
			public static readonly Color c_GreenA100 = Color.FromRgb(185, 246, 202);
			public static readonly Color c_GreenA200 = Color.FromRgb(105, 240, 174);
			public static readonly Color c_GreenA400 = Color.FromRgb(0, 230, 118);
			public static readonly Color c_GreenA700 = Color.FromRgb(0, 200, 83);
			public static readonly Color c_LightGreenA100 = Color.FromRgb(204, 255, 144);
			public static readonly Color c_LightGreenA200 = Color.FromRgb(178, 255, 89);
			public static readonly Color c_LightGreenA400 = Color.FromRgb(118, 255, 3);
			public static readonly Color c_LightGreenA700 = Color.FromRgb(100, 221, 23);
			public static readonly Color c_LimeA100 = Color.FromRgb(244, 255, 129);
			public static readonly Color c_LimeA200 = Color.FromRgb(238, 255, 65);
			public static readonly Color c_LimeA400 = Color.FromRgb(198, 255, 0);
			public static readonly Color c_LimeA700 = Color.FromRgb(174, 234, 0);
			public static readonly Color c_YellowA100 = Color.FromRgb(255, 255, 141);
			public static readonly Color c_YellowA200 = Color.FromRgb(255, 255, 0);
			public static readonly Color c_YellowA400 = Color.FromRgb(255, 234, 0);
			public static readonly Color c_YellowA700 = Color.FromRgb(255, 214, 0);
			public static readonly Color c_AmberA100 = Color.FromRgb(255, 229, 127);
			public static readonly Color c_AmberA200 = Color.FromRgb(255, 215, 64);
			public static readonly Color c_AmberA400 = Color.FromRgb(255, 196, 0);
			public static readonly Color c_AmberA700 = Color.FromRgb(255, 171, 0);
			public static readonly Color c_OrangeA100 = Color.FromRgb(255, 209, 128);
			public static readonly Color c_OrangeA200 = Color.FromRgb(255, 171, 64);
			public static readonly Color c_OrangeA400 = Color.FromRgb(255, 145, 0);
			public static readonly Color c_OrangeA700 = Color.FromRgb(255, 109, 0);
			public static readonly Color c_DeepOrangeA100 = Color.FromRgb(255, 158, 128);
			public static readonly Color c_DeepOrangeA200 = Color.FromRgb(255, 110, 64);
			public static readonly Color c_DeepOrangeA400 = Color.FromRgb(255, 61, 0);
			public static readonly Color c_DeepOrangeA700 = Color.FromRgb(221, 44, 0);

		}

		public class Sets
		{
			public static readonly MaterialSetOLD RedBrushSet = new MaterialSetOLD(
				Red050, Red100, Red200, Red300, Red400, Red500, Red600, Red700, Red800, Red900, RedA100, RedA200, RedA400, RedA700);

			public static readonly MaterialSetOLD PinkBrushSet = new MaterialSetOLD(
				Pink050, Pink100, Pink200, Pink300, Pink400, Pink500, Pink600, Pink700, Pink800, Pink900, PinkA100, PinkA200, PinkA400, PinkA700);

			public static readonly MaterialSetOLD PurpleBrushSet = new MaterialSetOLD(
				Purple050, Purple100, Purple200, Purple300, Purple400, Purple500, Purple600, Purple700, Purple800, Purple900, PurpleA100, PurpleA200, PurpleA400, PurpleA700);

			public static readonly MaterialSetOLD DeepPurpleBrushSet = new MaterialSetOLD(
				DeepPurple050, DeepPurple100, DeepPurple200, DeepPurple300, DeepPurple400, DeepPurple500, DeepPurple600, DeepPurple700, DeepPurple800, DeepPurple900, DeepPurpleA100, DeepPurpleA200, DeepPurpleA400, DeepPurpleA700);

			public static readonly MaterialSetOLD IndigoBrushSet = new MaterialSetOLD(
				Indigo050, Indigo100, Indigo200, Indigo300, Indigo400, Indigo500, Indigo600, Indigo700, Indigo800, Indigo900, IndigoA100, IndigoA200, IndigoA400, IndigoA700);

			public static readonly MaterialSetOLD BlueBrushSet = new MaterialSetOLD(
				Blue050, Blue100, Blue200, Blue300, Blue400, Blue500, Blue600, Blue700, Blue800, Blue900, BlueA100, BlueA200, BlueA400, BlueA700);

			public static readonly MaterialSetOLD LightBlueBrushSet = new MaterialSetOLD(
				LightBlue050, LightBlue100, LightBlue200, LightBlue300, LightBlue400, LightBlue500, LightBlue600, LightBlue700, LightBlue800, LightBlue900, LightBlueA100, LightBlueA200, LightBlueA400, LightBlueA700);

			public static readonly MaterialSetOLD CyanBrushSet = new MaterialSetOLD(
				Cyan050, Cyan100, Cyan200, Cyan300, Cyan400, Cyan500, Cyan600, Cyan700, Cyan800, Cyan900, CyanA100, CyanA200, CyanA400, CyanA700);

			public static readonly MaterialSetOLD TealBrushSet = new MaterialSetOLD(
				Teal050, Teal100, Teal200, Teal300, Teal400, Teal500, Teal600, Teal700, Teal800, Teal900, TealA100, TealA200, TealA400, TealA700);

			public static readonly MaterialSetOLD GreenBrushSet = new MaterialSetOLD(
				Green050, Green100, Green200, Green300, Green400, Green500, Green600, Green700, Green800, Green900, GreenA100, GreenA200, GreenA400, GreenA700);

			public static readonly MaterialSetOLD LightGreenBrushSet = new MaterialSetOLD(
				LightGreen050, LightGreen100, LightGreen200, LightGreen300, LightGreen400, LightGreen500, LightGreen600, LightGreen700, LightGreen800, LightGreen900, LightGreenA100, LightGreenA200, LightGreenA400, LightGreenA700);

			public static readonly MaterialSetOLD LimeBrushSet = new MaterialSetOLD(
				Lime050, Lime100, Lime200, Lime300, Lime400, Lime500, Lime600, Lime700, Lime800, Lime900, LimeA100, LimeA200, LimeA400, LimeA700);

			public static readonly MaterialSetOLD YellowBrushSet = new MaterialSetOLD(
				Yellow050, Yellow100, Yellow200, Yellow300, Yellow400, Yellow500, Yellow600, Yellow700, Yellow800, Yellow900, RedA100, RedA200, RedA400, RedA700);

			public static readonly MaterialSetOLD AmberBrushSet = new MaterialSetOLD(
				Amber050, Amber100, Amber200, Amber300, Amber400, Amber500, Amber600, Amber700, Amber800, Amber900, AmberA100, AmberA200, AmberA400, AmberA700);

			public static readonly MaterialSetOLD OrangeBrushSet = new MaterialSetOLD(
				Orange050, Orange100, Orange200, Orange300, Orange400, Orange500, Orange600, Orange700, Orange800, Orange900, OrangeA100, OrangeA200, OrangeA400, OrangeA700);

			public static readonly MaterialSetOLD DeepOrangeBrushSet = new MaterialSetOLD(
				DeepOrange050, DeepOrange100, DeepOrange200, DeepOrange300, DeepOrange400, DeepOrange500, DeepOrange600, DeepOrange700, DeepOrange800, DeepOrange900, DeepOrangeA100, DeepOrangeA200, DeepOrangeA400, DeepOrangeA700);

			public static readonly MaterialSetOLD BrownBrushSet = new MaterialSetOLD(
				Brown050, Brown100, Brown200, Brown300, Brown400, Brown500, Brown600, Brown700, Brown800, Brown900);

			public static readonly MaterialSetOLD GreyBrushSet = new MaterialSetOLD(
				Grey050, Grey100, Grey200, Grey300, Grey400, Grey500, Grey600, Grey700, Grey800, Grey900);

			public static readonly MaterialSetOLD BlueGreyBrushSet = new MaterialSetOLD(
				BlueGrey050, BlueGrey100, BlueGrey200, BlueGrey300, BlueGrey400, BlueGrey500, BlueGrey600, BlueGrey700, BlueGrey800, BlueGrey900);

			public static readonly ReadOnlyCollection<MaterialSetOLD> AllSets = new ReadOnlyCollection<MaterialSetOLD>(new List<MaterialSetOLD>()
			{
				RedBrushSet,
				PinkBrushSet,
				PurpleBrushSet,
				DeepPurpleBrushSet,
				IndigoBrushSet,
				BlueBrushSet,
				LightBlueBrushSet,
				CyanBrushSet,
				TealBrushSet,
				GreenBrushSet,
				LightGreenBrushSet,
				LimeBrushSet,
				YellowBrushSet,
				AmberBrushSet,
				OrangeBrushSet,
				DeepOrangeBrushSet,
				BrownBrushSet,
				GreyBrushSet,
				BlueGreyBrushSet
			});
		}


		public class Shadows
		{
			public static DropShadowEffect ShadowDelta1 = new DropShadowEffect
			{
				Color = Grey900,
				Direction = 270,
				ShadowDepth = 1,
				Opacity = .6
			};
			public static DropShadowEffect ShadowDelta2 = new DropShadowEffect
			{
				Color = Grey900,
				Direction = 270,
				ShadowDepth = 2,
				Opacity = .6
			};
			public static DropShadowEffect ShadowDelta3 = new DropShadowEffect
			{
				Color = Grey900,
				Direction = 270,
				ShadowDepth = 3,
				Opacity = .6
			};
			public static DropShadowEffect ShadowDelta4 = new DropShadowEffect
			{
				Color = Grey900,
				Direction = 270,
				ShadowDepth = 4,
				Opacity = .6
			};
			public static DropShadowEffect ShadowDelta5 = new DropShadowEffect
			{
				Color = Grey900,
				Direction = 270,
				ShadowDepth = 5,
				Opacity = .4
			};
		}
		// TODO add the MD icon font
		public class Fonts
		{
			private static readonly FontFamilyConverter ffc = new FontFamilyConverter();
			internal static FontFamily TimesNewRoman => (FontFamily)ffc.ConvertFromString("Times New Roman");
			public static FontFamily Roboto => (FontFamily)ffc.ConvertFromString("Roboto");
		}
		//TODO make all this stuff FlexEnum<T>
		//TODO should be using DESKTOP font sizes in md specs instead of device?
		public class FontSizes
		{
			private static readonly FontSizeConverter fsc = new FontSizeConverter();

			public static double SP12 => fsc.ConvertFromString("12pt").RequireType<double>();
			public static double SP14 => fsc.ConvertFromString("14pt").RequireType<double>();
			public static double SP16 => fsc.ConvertFromString("16pt").RequireType<double>();
			public static double SP20 => fsc.ConvertFromString("20pt").RequireType<double>();
			public static double SP24 => fsc.ConvertFromString("24pt").RequireType<double>();
			public static double SP34 => fsc.ConvertFromString("34pt").RequireType<double>();
			public static double SP45 => fsc.ConvertFromString("45pt").RequireType<double>();
			public static double SP56 => fsc.ConvertFromString("56pt").RequireType<double>();
			public static double SP112 => fsc.ConvertFromString("112pt").RequireType<double>();
		}

		public class FontWeights
		{
			private static readonly FontWeightConverter fwc = new FontWeightConverter();
			public static FontWeight Thin => fwc.ConvertFromString("Thin").RequireType<FontWeight>();
			public static FontWeight Light => fwc.ConvertFromString("Light").RequireType<FontWeight>();
			public static FontWeight Regular => fwc.ConvertFromString("Regular").RequireType<FontWeight>();
			public static FontWeight Medium => fwc.ConvertFromString("Medium").RequireType<FontWeight>();
			public static FontWeight Bold => fwc.ConvertFromString("Bold").RequireType<FontWeight>();
			public static FontWeight Black => fwc.ConvertFromString("Black").RequireType<FontWeight>();
		}
		//TODO auto fontattr creators using [CallerMemberName]. generic T Create<T, TC>([CMN] auto) where TC:Typeconverter
		public class FontStyles
		{
			private static readonly FontStyleConverter fsc = new FontStyleConverter();

			public static FontStyle Normal = fsc.ConvertFromString("Normal").RequireType<FontStyle>();
			public static FontStyle Italic = fsc.ConvertFromString("Italic").RequireType<FontStyle>();
			// TODO does roboto have oblique?
			public static FontStyle Oblique = fsc.ConvertFromString("Oblique").RequireType<FontStyle>();
		}
		//TODO does roboto support these stretches
		public class FontStretches
		{
			private static readonly FontStretchConverter fsc = new FontStretchConverter();

			public static FontStretch ExtraCondensed = fsc.ConvertFromString("ExtraCondensed").RequireType<FontStretch>();
			public static FontStretch Condensed = fsc.ConvertFromString("Condensed").RequireType<FontStretch>();
			public static FontStretch SemiCondensed = fsc.ConvertFromString("SemiCondensed").RequireType<FontStretch>();
			public static FontStretch Normal = fsc.ConvertFromString("Normal").RequireType<FontStretch>();
			public static FontStretch Medium = fsc.ConvertFromString("Medium").RequireType<FontStretch>();
			public static FontStretch SemiExpanded = fsc.ConvertFromString("SemiExpanded").RequireType<FontStretch>();
			public static FontStretch Expanded = fsc.ConvertFromString("Expanded").RequireType<FontStretch>();
			public static FontStretch ExtraExpanded = fsc.ConvertFromString("ExtraExpanded").RequireType<FontStretch>();
			public static FontStretch UltraExpanded = fsc.ConvertFromString("UltraExpanded").RequireType<FontStretch>();
		}

		public class Typesets
		{
			public static FlexTypeface Button => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Medium, FontStretches.Normal, FontSizes.SP14);

			public static FlexTypeface Caption => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP12);

			public static FlexTypeface Body1 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP14);

			public static FlexTypeface Body2 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Medium, FontStretches.Normal, FontSizes.SP14);

			public static FlexTypeface Subhead => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP16);

			public static FlexTypeface Title => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Medium, FontStretches.Normal, FontSizes.SP20);

			public static FlexTypeface Headline => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP24);

			public static FlexTypeface Display1 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP34);

			public static FlexTypeface Display2 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP45);

			public static FlexTypeface Display3 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Regular, FontStretches.Normal, FontSizes.SP56);

			public static FlexTypeface Display4 => new FlexTypeface(Fonts.Roboto, FontStyles.Normal,
				FontWeights.Light, FontStretches.Normal, FontSizes.SP112);
		}

		public class Descriptors
		{

			public static LuminosityMaterialDescriptor P050Descriptor = new LuminosityMaterialDescriptor(Luminosity.P050);
			public static LuminosityMaterialDescriptor P100Descriptor = new LuminosityMaterialDescriptor(Luminosity.P100);
			public static LuminosityMaterialDescriptor P200Descriptor = new LuminosityMaterialDescriptor(Luminosity.P200);
			public static LuminosityMaterialDescriptor P300Descriptor = new LuminosityMaterialDescriptor(Luminosity.P300);
			public static LuminosityMaterialDescriptor P400Descriptor = new LuminosityMaterialDescriptor(Luminosity.P400);
			public static LuminosityMaterialDescriptor P500Descriptor = new LuminosityMaterialDescriptor(Luminosity.P500);
			public static LuminosityMaterialDescriptor P600Descriptor = new LuminosityMaterialDescriptor(Luminosity.P600);
			public static LuminosityMaterialDescriptor P700Descriptor = new LuminosityMaterialDescriptor(Luminosity.P700);
			public static LuminosityMaterialDescriptor P800Descriptor = new LuminosityMaterialDescriptor(Luminosity.P800);
			public static LuminosityMaterialDescriptor P900Descriptor = new LuminosityMaterialDescriptor(Luminosity.P900);

			public static LuminosityMaterialDescriptor P050O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P050, .5);
			public static LuminosityMaterialDescriptor P100O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P100, .5);
			public static LuminosityMaterialDescriptor P200O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P200, .5);
			public static LuminosityMaterialDescriptor P300O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P300, .5);
			public static LuminosityMaterialDescriptor P400O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P400, .5);
			public static LuminosityMaterialDescriptor P500O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P500, .5);
			public static LuminosityMaterialDescriptor P600O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P600, .5);
			public static LuminosityMaterialDescriptor P700O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P700, .5);
			public static LuminosityMaterialDescriptor P800O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P800, .5);
			public static LuminosityMaterialDescriptor P900O50Descriptor = new LuminosityMaterialDescriptor(Luminosity.P900, .5);

			public static LiteralMaterialDescriptor WhiteDescriptor = new LiteralMaterialDescriptor(White000);
			public static LiteralMaterialDescriptor BlackDescriptor = new LiteralMaterialDescriptor(Black000);
			public static LiteralMaterialDescriptor TransparentDescriptor = new LiteralMaterialDescriptor(Transparent000);
			public static LiteralMaterialDescriptor White000O10Descriptor = new LiteralMaterialDescriptor(White000, .1);
			public static LiteralMaterialDescriptor White000O05Descriptor = new LiteralMaterialDescriptor(White000, .05);
		}

		public class Filters
		{

		}

	}
}
