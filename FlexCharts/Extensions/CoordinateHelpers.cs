using System;

namespace FlexCharts.Extensions
{
	public static class CoordinateHelpers
	{
		public static double ToRadian(double degree) => degree * (Math.PI / 180);

		public static double ToDegree(double radian) => radian * (180 / Math.PI);
	}
}
