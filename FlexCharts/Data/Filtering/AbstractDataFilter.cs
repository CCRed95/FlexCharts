namespace FlexCharts.Data.Filtering
{
	public abstract class AbstractDataFilter<T>
	{
		public abstract T Filter(T dataSet);
	}
}
