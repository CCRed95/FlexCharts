using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Material.IO
{
	[DebuggerDisplay("{Name}")]
	public class LocalDriveInfo : IWMIDriveInfo
	{
		[DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern int WNetGetConnection(
				[MarshalAs(UnmanagedType.LPTStr)] string localName,
				[MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName,
				ref int length);

		public static string GetUNCPath(DriveInfo drive)
		{
			var sb = new StringBuilder(512);
			var size = sb.Capacity;
			var error = WNetGetConnection(drive.Name.Substring(0, 2), sb, ref size);
			return sb.ToString().TrimEnd();
		}

		private const string spacer = "    ";
		public static string GetProviderName(DriveInfo drive)
		{
			if (drive.DriveType == DriveType.CDRom)
				return $"{spacer}CD Drive";
			if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
				return spacer + drive.VolumeLabel;
			if (drive.DriveType == DriveType.Network)
				return GetUNCPath(drive);
			return spacer + drive.DriveType;
		}

		public DriveInfo Drive { get; }
		private LocalDriveInfo(DriveInfo drive)
		{
			Drive = drive;
		}

		public static List<LocalDriveInfo> GetDrives()
		{
			return DriveInfo.GetDrives().Select(d => new LocalDriveInfo(d)).ToList();
		}
		public string Caption => "Caption";
		public string DeviceID => "DeviceId";
		public string FileSystem => Drive.DriveFormat;
		public ulong FreeSpace => (ulong)Drive.AvailableFreeSpace;
		public ulong Size => (ulong)Drive.TotalSize;
		public string Name => Drive.Name;
		public string ProviderName => GetProviderName(Drive);
		public string VolumeName => Drive.VolumeLabel;
		public string VolumeSerialNumber => "Serial";
	}
}
