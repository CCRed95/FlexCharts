namespace FlexCharts.Data.Structures
{
	public class CategoricalDouble : Categorical<double>
	{
		public CategoricalDouble() { }

		public CategoricalDouble(string categoryName, double value) : 
			base(categoryName, value) { }
	}
}

