using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Material.Controls.FileManager
{
	[Serializable]
	public class FileManagerSettings
	{
		public static string fileOut = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\FileManagerSettings.bin";

		private static FileManagerSettings instance;
		private FileManagerSettings() { }
		public static FileManagerSettings Instance => instance ?? (instance = LoadFromBinaryStream());
		
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
			Stream stream = new FileStream(fileOut, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
		}
		public static FileManagerSettings LoadFromBinaryStream()
		{
			if (!File.Exists(fileOut))
				return new FileManagerSettings();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(fileOut, FileMode.Open, FileAccess.Read, FileShare.Read);
			var obj = (FileManagerSettings)formatter.Deserialize(stream);
			stream.Close();
			return obj;
		}
	}
}
