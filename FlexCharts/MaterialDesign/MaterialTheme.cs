using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Require;

namespace FlexCharts.MaterialDesign
{
	public class MaterialTheme : Freezable
	{
		public static readonly DependencyProperty P050Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink050));
		public SolidColorBrush P050
		{
			get { return (SolidColorBrush)GetValue(P050Property); }
			set { SetValue(P050Property, value); }
		}
		public static readonly DependencyProperty P100Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink100));
		public SolidColorBrush P100
		{
			get { return (SolidColorBrush)GetValue(P100Property); }
			set { SetValue(P100Property, value); }
		}
		public static readonly DependencyProperty P200Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink200));
		public SolidColorBrush P200
		{
			get { return (SolidColorBrush)GetValue(P200Property); }
			set { SetValue(P200Property, value); }
		}
		public static readonly DependencyProperty P300Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink300));
		public SolidColorBrush P300
		{
			get { return (SolidColorBrush)GetValue(P300Property); }
			set { SetValue(P300Property, value); }
		}
		public static readonly DependencyProperty P400Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink400));
		public SolidColorBrush P400
		{
			get { return (SolidColorBrush)GetValue(P400Property); }
			set { SetValue(P400Property, value); }
		}
		public static readonly DependencyProperty P500Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink500));
		public SolidColorBrush P500
		{
			get { return (SolidColorBrush)GetValue(P500Property); }
			set { SetValue(P500Property, value); }
		}
		public static readonly DependencyProperty P600Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink600));
		public SolidColorBrush P600
		{
			get { return (SolidColorBrush)GetValue(P600Property); }
			set { SetValue(P600Property, value); }
		}
		public static readonly DependencyProperty P700Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink700));
		public SolidColorBrush P700
		{
			get { return (SolidColorBrush)GetValue(P700Property); }
			set { SetValue(P700Property, value); }
		}
		public static readonly DependencyProperty P800Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink800));
		public SolidColorBrush P800
		{
			get { return (SolidColorBrush)GetValue(P800Property); }
			set { SetValue(P800Property, value); }
		}
		public static readonly DependencyProperty P900Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>(MaterialPalette.Pink900));
		public SolidColorBrush P900
		{
			get { return (SolidColorBrush)GetValue(P900Property); }
			set { SetValue(P900Property, value); }
		}
		public static readonly DependencyProperty A100Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>());
		public SolidColorBrush A100
		{
			get { return (SolidColorBrush)GetValue(A100Property); }
			set { SetValue(A100Property, value); }
		}
		public static readonly DependencyProperty A200Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>());
		public SolidColorBrush A200
		{
			get { return (SolidColorBrush)GetValue(A200Property); }
			set { SetValue(A200Property, value); }
		}
		public static readonly DependencyProperty A400Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>());
		public SolidColorBrush A400
		{
			get { return (SolidColorBrush)GetValue(A400Property); }
			set { SetValue(A400Property, value); }
		}
		public static readonly DependencyProperty A700Property = DP.Register(
			new Meta<MaterialTheme, SolidColorBrush>());
		public SolidColorBrush A700
		{
			get { return (SolidColorBrush)GetValue(A700Property); }
			set { SetValue(A700Property, value); }
		}
		public Dictionary<Luminosity, DependencyProperty> LuminosityPairs = 
			new Dictionary<Luminosity, DependencyProperty>
			{
				[Luminosity.P050] = P050Property,
				[Luminosity.P100] = P100Property,
				[Luminosity.P200] = P200Property,
				[Luminosity.P300] = P300Property,
				[Luminosity.P400] = P400Property,
				[Luminosity.P500] = P500Property,
				[Luminosity.P600] = P600Property,
				[Luminosity.P700] = P700Property,
				[Luminosity.P800] = P800Property,
				[Luminosity.P900] = P900Property,
				[Luminosity.A100] = A100Property,
				[Luminosity.A200] = A200Property,
				[Luminosity.A400] = A400Property,
				[Luminosity.A700] = A700Property,
			}; 
		public SolidColorBrush FromLuminosity(Luminosity luminosity)
		{
			if (LuminosityPairs.ContainsKey(luminosity))
			{
				return GetValue(LuminosityPairs[luminosity]).RequireType<SolidColorBrush>();
			}
			return MaterialPalette.Red500;
		}
		//public MaterialTheme(MaterialSet set)
		//{
		//	sourceSet = set;
		//	P050 = set.GetMaterial(Luminosity.P050);
		//	P100 = set.GetMaterial(Luminosity.P100);
		//	P200 = set.GetMaterial(Luminosity.P200);
		//	P300 = set.GetMaterial(Luminosity.P300);
		//	P400 = set.GetMaterial(Luminosity.P400);
		//	P500 = set.GetMaterial(Luminosity.P500);
		//	P600 = set.GetMaterial(Luminosity.P600);
		//	P700 = set.GetMaterial(Luminosity.P700);
		//	P800 = set.GetMaterial(Luminosity.P800);
		//	P900 = set.GetMaterial(Luminosity.P900);
		//}
		protected MaterialTheme() { }

		public MaterialTheme(Material p050, Material p100, Material p200, Material p300, Material p400, Material p500,
			Material p600, Material p700, Material p800, Material p900)
		{
			P050 = p050;
			P100 = p100;
			P200 = p200;
			P300 = p300;
			P400 = p400;
			P500 = p500;
			P600 = p600;
			P700 = p700;
			P800 = p800;
			P900 = p900;
		}
		public MaterialTheme(Material p050, Material p100, Material p200, Material p300, Material p400, Material p500,
			Material p600, Material p700, Material p800, Material p900, Material a100, Material a200, Material a400, Material a700)
		{
			P050 = p050;
			P100 = p100;
			P200 = p200;
			P300 = p300;
			P400 = p400;
			P500 = p500;
			P600 = p600;
			P700 = p700;
			P800 = p800;
			P900 = p900;
			A100 = a100;
			A200 = a200;
			A400 = a400;
			A700 = a700;
		}
		protected override Freezable CreateInstanceCore()
		{
			return new MaterialTheme();
		}
	}
	public static class MaterialThemes
	{
		public static readonly MaterialTheme RedTheme = new MaterialTheme(
			MaterialPalette.Red050, MaterialPalette.Red100, MaterialPalette.Red200, MaterialPalette.Red300, MaterialPalette.Red400, MaterialPalette.Red500, MaterialPalette.Red600, MaterialPalette.Red700, MaterialPalette.Red800, MaterialPalette.Red900, MaterialPalette.RedA100, MaterialPalette.RedA200, MaterialPalette.RedA400, MaterialPalette.RedA700);

		public static readonly MaterialTheme PinkTheme = new MaterialTheme(
			MaterialPalette.Pink050, MaterialPalette.Pink100, MaterialPalette.Pink200, MaterialPalette.Pink300, MaterialPalette.Pink400, MaterialPalette.Pink500, MaterialPalette.Pink600, MaterialPalette.Pink700, MaterialPalette.Pink800, MaterialPalette.Pink900, MaterialPalette.PinkA100, MaterialPalette.PinkA200, MaterialPalette.PinkA400, MaterialPalette.PinkA700);

		public static readonly MaterialTheme PurpleTheme = new MaterialTheme(
			MaterialPalette.Purple050, MaterialPalette.Purple100, MaterialPalette.Purple200, MaterialPalette.Purple300, MaterialPalette.Purple400, MaterialPalette.Purple500, MaterialPalette.Purple600, MaterialPalette.Purple700, MaterialPalette.Purple800, MaterialPalette.Purple900, MaterialPalette.PurpleA100, MaterialPalette.PurpleA200, MaterialPalette.PurpleA400, MaterialPalette.PurpleA700);

		public static readonly MaterialTheme DeepPurpleTheme = new MaterialTheme(
			MaterialPalette.DeepPurple050, MaterialPalette.DeepPurple100, MaterialPalette.DeepPurple200, MaterialPalette.DeepPurple300, MaterialPalette.DeepPurple400, MaterialPalette.DeepPurple500, MaterialPalette.DeepPurple600, MaterialPalette.DeepPurple700, MaterialPalette.DeepPurple800, MaterialPalette.DeepPurple900, MaterialPalette.DeepPurpleA100, MaterialPalette.DeepPurpleA200, MaterialPalette.DeepPurpleA400, MaterialPalette.DeepPurpleA700);

		public static readonly MaterialTheme IndigoTheme = new MaterialTheme(
			MaterialPalette.Indigo050, MaterialPalette.Indigo100, MaterialPalette.Indigo200, MaterialPalette.Indigo300, MaterialPalette.Indigo400, MaterialPalette.Indigo500, MaterialPalette.Indigo600, MaterialPalette.Indigo700, MaterialPalette.Indigo800, MaterialPalette.Indigo900, MaterialPalette.IndigoA100, MaterialPalette.IndigoA200, MaterialPalette.IndigoA400, MaterialPalette.IndigoA700);

		public static readonly MaterialTheme BlueTheme = new MaterialTheme(
			MaterialPalette.Blue050, MaterialPalette.Blue100, MaterialPalette.Blue200, MaterialPalette.Blue300, MaterialPalette.Blue400, MaterialPalette.Blue500, MaterialPalette.Blue600, MaterialPalette.Blue700, MaterialPalette.Blue800, MaterialPalette.Blue900, MaterialPalette.BlueA100, MaterialPalette.BlueA200, MaterialPalette.BlueA400, MaterialPalette.BlueA700);

		public static readonly MaterialTheme LightBlueTheme = new MaterialTheme(
			MaterialPalette.LightBlue050, MaterialPalette.LightBlue100, MaterialPalette.LightBlue200, MaterialPalette.LightBlue300, MaterialPalette.LightBlue400, MaterialPalette.LightBlue500, MaterialPalette.LightBlue600, MaterialPalette.LightBlue700, MaterialPalette.LightBlue800, MaterialPalette.LightBlue900, MaterialPalette.LightBlueA100, MaterialPalette.LightBlueA200, MaterialPalette.LightBlueA400, MaterialPalette.LightBlueA700);

		public static readonly MaterialTheme CyanTheme = new MaterialTheme(
			MaterialPalette.Cyan050, MaterialPalette.Cyan100, MaterialPalette.Cyan200, MaterialPalette.Cyan300, MaterialPalette.Cyan400, MaterialPalette.Cyan500, MaterialPalette.Cyan600, MaterialPalette.Cyan700, MaterialPalette.Cyan800, MaterialPalette.Cyan900, MaterialPalette.CyanA100, MaterialPalette.CyanA200, MaterialPalette.CyanA400, MaterialPalette.CyanA700);

		public static readonly MaterialTheme TealTheme = new MaterialTheme(
			MaterialPalette.Teal050, MaterialPalette.Teal100, MaterialPalette.Teal200, MaterialPalette.Teal300, MaterialPalette.Teal400, MaterialPalette.Teal500, MaterialPalette.Teal600, MaterialPalette.Teal700, MaterialPalette.Teal800, MaterialPalette.Teal900, MaterialPalette.TealA100, MaterialPalette.TealA200, MaterialPalette.TealA400, MaterialPalette.TealA700);

		public static readonly MaterialTheme GreenTheme = new MaterialTheme(
			MaterialPalette.Green050, MaterialPalette.Green100, MaterialPalette.Green200, MaterialPalette.Green300, MaterialPalette.Green400, MaterialPalette.Green500, MaterialPalette.Green600, MaterialPalette.Green700, MaterialPalette.Green800, MaterialPalette.Green900, MaterialPalette.GreenA100, MaterialPalette.GreenA200, MaterialPalette.GreenA400, MaterialPalette.GreenA700);

		public static readonly MaterialTheme LightGreenTheme = new MaterialTheme(
			MaterialPalette.LightGreen050, MaterialPalette.LightGreen100, MaterialPalette.LightGreen200, MaterialPalette.LightGreen300, MaterialPalette.LightGreen400, MaterialPalette.LightGreen500, MaterialPalette.LightGreen600, MaterialPalette.LightGreen700, MaterialPalette.LightGreen800, MaterialPalette.LightGreen900, MaterialPalette.LightGreenA100, MaterialPalette.LightGreenA200, MaterialPalette.LightGreenA400, MaterialPalette.LightGreenA700);

		public static readonly MaterialTheme LimeTheme = new MaterialTheme(
			MaterialPalette.Lime050, MaterialPalette.Lime100, MaterialPalette.Lime200, MaterialPalette.Lime300, MaterialPalette.Lime400, MaterialPalette.Lime500, MaterialPalette.Lime600, MaterialPalette.Lime700, MaterialPalette.Lime800, MaterialPalette.Lime900, MaterialPalette.LimeA100, MaterialPalette.LimeA200, MaterialPalette.LimeA400, MaterialPalette.LimeA700);

		public static readonly MaterialTheme YellowTheme = new MaterialTheme(
			MaterialPalette.Yellow050, MaterialPalette.Yellow100, MaterialPalette.Yellow200, MaterialPalette.Yellow300, MaterialPalette.Yellow400, MaterialPalette.Yellow500, MaterialPalette.Yellow600, MaterialPalette.Yellow700, MaterialPalette.Yellow800, MaterialPalette.Yellow900, MaterialPalette.RedA100, MaterialPalette.RedA200, MaterialPalette.RedA400, MaterialPalette.RedA700);

		public static readonly MaterialTheme AmberTheme = new MaterialTheme(
			MaterialPalette.Amber050, MaterialPalette.Amber100, MaterialPalette.Amber200, MaterialPalette.Amber300, MaterialPalette.Amber400, MaterialPalette.Amber500, MaterialPalette.Amber600, MaterialPalette.Amber700, MaterialPalette.Amber800, MaterialPalette.Amber900, MaterialPalette.AmberA100, MaterialPalette.AmberA200, MaterialPalette.AmberA400, MaterialPalette.AmberA700);

		public static readonly MaterialTheme OrangeTheme = new MaterialTheme(
			MaterialPalette.Orange050, MaterialPalette.Orange100, MaterialPalette.Orange200, MaterialPalette.Orange300, MaterialPalette.Orange400, MaterialPalette.Orange500, MaterialPalette.Orange600, MaterialPalette.Orange700, MaterialPalette.Orange800, MaterialPalette.Orange900, MaterialPalette.OrangeA100, MaterialPalette.OrangeA200, MaterialPalette.OrangeA400, MaterialPalette.OrangeA700);

		public static readonly MaterialTheme DeepOrangeTheme = new MaterialTheme(
			MaterialPalette.DeepOrange050, MaterialPalette.DeepOrange100, MaterialPalette.DeepOrange200, MaterialPalette.DeepOrange300, MaterialPalette.DeepOrange400, MaterialPalette.DeepOrange500, MaterialPalette.DeepOrange600, MaterialPalette.DeepOrange700, MaterialPalette.DeepOrange800, MaterialPalette.DeepOrange900, MaterialPalette.DeepOrangeA100, MaterialPalette.DeepOrangeA200, MaterialPalette.DeepOrangeA400, MaterialPalette.DeepOrangeA700);

		public static readonly MaterialTheme BrownTheme = new MaterialTheme(
			MaterialPalette.Brown050, MaterialPalette.Brown100, MaterialPalette.Brown200, MaterialPalette.Brown300, MaterialPalette.Brown400, MaterialPalette.Brown500, MaterialPalette.Brown600, MaterialPalette.Brown700, MaterialPalette.Brown800, MaterialPalette.Brown900);

		public static readonly MaterialTheme GreyTheme = new MaterialTheme(
			MaterialPalette.Grey050, MaterialPalette.Grey100, MaterialPalette.Grey200, MaterialPalette.Grey300, MaterialPalette.Grey400, MaterialPalette.Grey500, MaterialPalette.Grey600, MaterialPalette.Grey700, MaterialPalette.Grey800, MaterialPalette.Grey900);

		public static readonly MaterialTheme BlueGreyTheme = new MaterialTheme(
			MaterialPalette.BlueGrey050, MaterialPalette.BlueGrey100, MaterialPalette.BlueGrey200, MaterialPalette.BlueGrey300, MaterialPalette.BlueGrey400, MaterialPalette.BlueGrey500, MaterialPalette.BlueGrey600, MaterialPalette.BlueGrey700, MaterialPalette.BlueGrey800, MaterialPalette.BlueGrey900);

		public static ReadOnlyCollection<MaterialTheme> AllThemes = new ReadOnlyCollection<MaterialTheme>(new List<MaterialTheme>()
		{
			RedTheme, PinkTheme, PurpleTheme, DeepPurpleTheme, IndigoTheme, BlueTheme, LightBlueTheme, CyanTheme, TealTheme, GreenTheme, LightGreenTheme, LimeTheme, YellowTheme, AmberTheme, OrangeTheme, DeepOrangeTheme, BrownTheme, GreyTheme, BlueTheme
		});
	}
}
