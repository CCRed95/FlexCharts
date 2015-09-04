using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FlexCharts.Documents
{
	public class FlexDocumentReader
	{
		public static FlexDocument ParseDocument(string configFilePath)
		{
			try
			{
				var parserContext = new ParserContext();
				var configFileStream = new FileStream(configFilePath, FileMode.Open);
				var configObject = XamlReader.Load(configFileStream, parserContext);
				var chartConfigObject = (FlexDocument)configObject;
				return chartConfigObject;
			}
			catch
			{
				throw new Exception("Parser fail");
			}
		}
	
	}
}
