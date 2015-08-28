using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlexCharts.Extensions
{
	public class StyleExtensions
	{
		static public string FindNameFromResource(object resourceItem)
		{
			foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
			{
				foreach (var key in dictionary.Keys)
				{
					if (dictionary[key] == resourceItem)
					{
						return key.ToString();
					}
				}
			}
			return null;
		}
	}
}
