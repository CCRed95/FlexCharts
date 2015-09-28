using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FlexCharts.Extensions;
namespace Material.Controls.FileManager
{
	[Serializable]
	public class FileManagerSettings
	{
		private static FileManagerSettings instance;
		public static FileManagerSettings Instance => instance ?? (instance = LoadFromBinaryStream());
		public static DirectoryInfo DataStorageDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\FlexVIEW\UserConfig\" +
				System.Reflection.Assembly.GetEntryAssembly() .GetName().Name);

		public static FileInfo DataStorageFile = new FileInfo(DataStorageDirectory.FullName + @"\FileManagerSettings.bin");

		private FileManagerSettings() { }

		private string lastDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public string LastDirectory
		{
			get { return Instance.lastDirectory; }
			set
			{
				Instance.lastDirectory = value;
				SaveToBinaryStream();
			}
		}

		private string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public string HomeDirectory
		{
			get { return Instance.homeDirectory; }
			set
			{
				Instance.homeDirectory = value;
				SaveToBinaryStream();
			}
		}

		private bool confirmDelete = true;
		public bool ConfirmDelete
		{
			get { return Instance.confirmDelete; }
			set
			{
				Instance.confirmDelete = value;
				SaveToBinaryStream();
			}
		}

		private List<string> favorites = new List<string>
		{
			Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
			Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
		};
		public List<string> Favorites
		{
			get { return Instance.favorites; }
			set
			{
				Instance.favorites = value;
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
		private static FileManagerSettings LoadFromBinaryStream()
		{
			if (!DataStorageFile.Exists)
				return new FileManagerSettings();
			try
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				var obj = (FileManagerSettings)formatter.Deserialize(stream);
				stream.Close();
				return obj;
			}
			catch
			{
				return new FileManagerSettings();
			}
		}
	}
}
