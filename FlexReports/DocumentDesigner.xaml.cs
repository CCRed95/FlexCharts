using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlexCharts.Documents;

namespace FlexReports
{
	/// <summary>
	/// Interaction logic for DocumentDesigner.xaml
	/// </summary>
	public partial class DocumentDesigner
	{
		readonly FileInfo fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Report2.flex");

		public DocumentDesigner()
		{
			InitializeComponent();
			Loaded += OnLoaded;
		}

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			if (fi.Exists)
			{
				var document = FlexDocumentReader.ParseDocument(fi.FullName);
				documentViewport.Document = document;
				xmlEditor.SourceFile = fi;
			}
		}
	}
}
