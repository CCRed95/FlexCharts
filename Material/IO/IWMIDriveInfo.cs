using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.IO
{
	public interface IWMIDriveInfo
	{
		DriveInfo Drive { get; }
		string Caption { get; }
		string DeviceID { get; }
		string FileSystem { get; }
		ulong FreeSpace { get; }
		ulong Size { get; }
		string Name { get; }
		string ProviderName { get; }
		string VolumeName { get; }
		string VolumeSerialNumber { get; }
	}
}
