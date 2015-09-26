using System.Collections.Generic;
namespace Material.IO
{
	public class WMIDriveInfo
	{
		public static List<IWMIDriveInfo> GetDrives()
		{
			var drives = new List<IWMIDriveInfo>();
			drives.AddRange(LocalDriveInfo.GetDrives());
			drives.AddRange(NetworkDriveInfo.GetDrives());
			return drives;
		} 
	}
}
