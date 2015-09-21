using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Material.Static
{
	public static class ResourceProvider
	{
		private const string resourceUriString = "pack://application:,,,/Material;component/themes/generic.xaml";
		private static readonly ResourceDictionary palette;

		static ResourceProvider()
		{
			palette = new ResourceDictionary
			{
				Source = new Uri(resourceUriString, UriKind.RelativeOrAbsolute)
			};
		}

		public static T Extract<T>([CallerMemberName] string key = null) where T : class
		{
			if (key == null)
				throw new NullReferenceException("resource not found with null key");
			
			if (!palette.Contains(key))
				throw new ResourceReferenceKeyNotFoundException("resource not found in material set.", key);

			var resource = palette[key] as T;
			if (resource == null)
				throw new KeyNotFoundException($"resource not found with key {key} as type {typeof(T).FullName}");
			
			return resource;
		}
	}
}
