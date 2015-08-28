using System.Collections.Generic;
using FlexCharts.Data.Structures;

namespace FlexCharts.Data.Filtering
{
	public class LiteralDataFilter : AbstractDataFilter<DoubleSeries>
	{
		public Dictionary<string, string> LiteralTranslationDefinitions = new Dictionary<string, string>();

		public override DoubleSeries Filter(DoubleSeries dataSet)
		{
			var d = new DoubleSeries();
			foreach (var dataPoint in dataSet)
			{
				if (LiteralTranslationDefinitions.ContainsKey(dataPoint.CategoryName))
				{
					var category = LiteralTranslationDefinitions[dataPoint.CategoryName];
					d.Add(new CategoricalDouble(category, dataPoint.Value));
				}
				else
				{
					d.Add(new CategoricalDouble(dataPoint.CategoryName, dataPoint.Value));
				}
			}
			return d;
		}
		
		public static LiteralDataFilter DialKCategoryFilter	= new LiteralDataFilter()
		{
			LiteralTranslationDefinitions = new Dictionary<string, string>()
			{
				["CURRENT_AT_BOOT"] = "CTAB",
				["CURRENT_AT_HDMI_TEST"] = "CAHT",
				["CURRENT_DRAW"] = "CDRW",
				["HAPTIC_L"] = "HPTL",
				["HAPTIC_R"] = "HPTR",
				["JOYSTICK_POSTSCAN"] = "JPOS",
				["JOYSTICK_PRESCAN"] = "JPRE",
				["JOYSTICK_SCAN"] = "JSCN",
				["KEY_SCAN_RESULT"] = "KSRS",
				["R_GYRO_GX"] = "RGGX",
				["R_GYRO_GY"] = "RGGY",
				["R_GYRO_GZ"] = "RGGZ",
				["RF_NORDIC"] = "RFND",
				["RF_PAIR_TEST"] = "RFPT",
				["RF_WIFI_CW_ANT1"] = "RWC1",
				["RF_WIFI_CW_ANT2"] = "RWC2",
				["TP_FIRST_TOUCH_L"] = "TFTL",
				["TP_FIRST_TOUCH_R"] = "TFTR",
				["TP_SCAN"] = "TSCN",
				["USB_HUB_VERIFY_4"] = "UHV4",
				["ACC_SELF_TEST"] = "ACST",
				["HALLSENS_PRETEST_RT"] = "HPRR",
				["HALLSENS_PUSHTEST_RT"] = "HPUR",
				["HALLSENS_PUSHTEST_LT"] = "HPUL"

			}
		};
	}
}
