namespace FlexCharts.Extensions
{
	public static class NumericExtensions
	{
		public static double Smallest(this double a, double b) => a < b ? a : b;
		public static int Smallest(this int a, int b) => a < b ? a : b;
		public static double Map(this double i, double initialMin, double initialMax, double targetMin, double targetMax)
		{
			var effectiveRange = initialMax - initialMin;
			var effectiveInitialValue = i - initialMin;
			var initialProgression = effectiveInitialValue / effectiveRange;

			var targetRange = targetMax - targetMin;
			var targetProgression = targetRange * initialProgression;

			var finalValue = targetProgression + targetMin;
			return finalValue;
		}
	}
}
