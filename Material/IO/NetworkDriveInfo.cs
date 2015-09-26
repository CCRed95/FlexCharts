using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows;

namespace Material.IO
{
	public class NetworkDriveInfo : IWMIDriveInfo
	{
		public DriveInfo Drive { get; } = null;
		public string Caption { get; }
		public string DeviceID { get; }
		public string FileSystem { get; }
		public ulong FreeSpace { get; }
		public ulong Size { get; }
		public string Name { get; }
		public string ProviderName { get; }
		public string VolumeName { get; }
		public string VolumeSerialNumber { get; }

		protected NetworkDriveInfo(ManagementBaseObject query)
		{
			Caption = (string)query[nameof(Caption)];
			DeviceID = (string)query[nameof(DeviceID)];
			FileSystem = (string)query[nameof(FileSystem)];
			FreeSpace = (ulong)query[nameof(FreeSpace)];
			Name = (string)query[nameof(Name)];
			ProviderName = (string)query[nameof(ProviderName)];
			Size = (ulong)query[nameof(Size)];
			VolumeName = (string)query[nameof(VolumeName)];
			VolumeSerialNumber = (string)query[nameof(VolumeSerialNumber)];
		}

		public static List<NetworkDriveInfo> GetDrives()
		{
			var drives = new List<NetworkDriveInfo>();
			try
			{
				var searcher = new ManagementObjectSearcher(
					"root\\CIMV2",
					"SELECT * FROM Win32_MappedLogicalDisk");

				drives.AddRange(from ManagementBaseObject query in searcher.Get() select new NetworkDriveInfo(query));
			}
			catch (ManagementException ex)
			{
				MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
			}
			return drives;
		}
	}
}