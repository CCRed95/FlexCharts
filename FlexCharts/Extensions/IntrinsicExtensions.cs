using System;
namespace FlexCharts.Extensions
{
	public static class IntrinsicExtensions
	{
		public static byte ScaleDown(this byte i, double percent)
		{
			var value = i - (i * (percent / 1));
			if (value > byte.MaxValue) value = byte.MaxValue;
			if (value < byte.MinValue) value = byte.MinValue;
			return Convert.ToByte(value);
		}
		public static byte ScaleUp(this byte i, double percent)
		{
			var value = i + (i * (percent / 1));
			if (value > byte.MaxValue) value = byte.MaxValue;
			if (value < byte.MinValue) value = byte.MinValue;
			return Convert.ToByte(value);
		}
	}
}
