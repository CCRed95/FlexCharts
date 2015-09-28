using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
namespace FlexReports.Data
{
	[Serializable]
	public class AppSettings
	{
		private static AppSettings instance;
		public static AppSettings Instance => instance ?? (instance = LoadFromBinaryStream());
		public static DirectoryInfo DataStorageDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\FlexVIEW\UserConfig\" + 
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name);

		public static FileInfo DataStorageFile = new FileInfo(DataStorageDirectory.FullName + @"\AppSettings.bin");

		private AppSettings() {}

		private string theme = "Teal";
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
			if (!DataStorageDirectory.Exists) DataStorageDirectory.Create();
			Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
		}
		private static AppSettings LoadFromBinaryStream()
		{

			if (!DataStorageFile.Exists)
				return new AppSettings();
			try
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				var obj = (AppSettings) formatter.Deserialize(stream);
				stream.Close();
				return obj;
			}
			catch
			{
				return new AppSettings();
			}
		}
	}
}
