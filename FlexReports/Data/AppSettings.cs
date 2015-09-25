using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Material;
using Material.Controls.FileManager;
using Material.Static;

namespace FlexReports.Data
{
	[Serializable]
	public class AppSettings
	{
		private static AppSettings instance;
		private AppSettings() { }
		public static AppSettings Instance => instance ?? (instance = LoadFromBinaryStream());

		public static string fileOut = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AppSettings.bin";
		private string theme = "Cyan";
		public string Theme
		{
			get { return Instance.theme; }
			set
			{
				Instance.theme = value;
				SaveToBinaryStream();
			}
		}
		private Size windowSize = new Size(800, 600);
		public Size WindowSize
		{
			get { return Instance.windowSize; }
			set
			{
				Instance.windowSize = value;
				SaveToBinaryStream();
			}
		}
		public void SaveToBinaryStream()
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(fileOut, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
		}
		public static AppSettings LoadFromBinaryStream()
		{
			if (!File.Exists(fileOut))
				return new AppSettings();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(fileOut, FileMode.Open, FileAccess.Read, FileShare.Read);
			var obj = (AppSettings)formatter.Deserialize(stream);
			stream.Close();
			return obj;
		}
	}
}
