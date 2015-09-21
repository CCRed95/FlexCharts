using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using FlexCharts.Documents;
using Material.Controls.TabSelector;

namespace Material.Converters
{
	public class FlexDocumentTabSelectorAdapter : MarkupExtension, IValueConverter
	{
		private static FlexDocumentTabSelectorAdapter _converter;
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _converter ?? (_converter = new FlexDocumentTabSelectorAdapter());
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;
			var document = value as FlexDocument;
			if (document == null)
				throw new ArgumentException(@"Expected type FlexDocument", nameof(value));
			var tabSelectorItems = new ObservableCollection<TabSelectorItem>();
			if (document.Tabs == null)
				throw new NullReferenceException(@"FlexDocument.Tabs is null");
			foreach (var documentTab in document.Tabs)
			{
				tabSelectorItems.Add(new TabSelectorItem(documentTab));
			}
			return tabSelectorItems;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}
