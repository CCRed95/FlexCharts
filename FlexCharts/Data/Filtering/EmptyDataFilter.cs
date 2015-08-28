namespace FlexCharts.Data.Filtering
{
	public class EmptyDataFilter<T> : AbstractDataFilter<T>
	{
		public override T Filter(T dataSet)
		{
			return dataSet;
		}
	}
}
