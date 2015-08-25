using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexCharts.Collections
{
	[Serializable]
	internal class FlexInvariantComparar : IComparer
	{
		private readonly CompareInfo m_compareInfo;
		internal static readonly FlexInvariantComparar Default = new FlexInvariantComparar();

		internal FlexInvariantComparar()
		{
			m_compareInfo = CultureInfo.InvariantCulture.CompareInfo;
		}

		public int Compare(object a, object b)
		{
			var sa = a as string;
			var sb = b as string;
			if (sa != null && sb != null)
				return m_compareInfo.Compare(sa, sb);
			return Comparer.Default.Compare(a, b);
		}
	}