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

namespace FlexChartsDemo
{
	/// <summary>
	/// Interaction logic for Testing.xaml
	/// </summary>
	public partial class Testing 
	{
		public Testing()
		{
			InitializeComponent();
			Loaded += OnLoaded;
		}
		
		private static readonly DirectoryInfo rootDirectory = new DirectoryInfo(
			Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\FlexDocuments");

		private void OnLoaded(object s, RoutedEventArgs e)
		{
			//fileManager.ActiveDirectory = rootDirectory;
		}
	}
}
