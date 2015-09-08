using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlexCharts.Extensions
{
	public static class FileSystemExtensions
	{
		public static bool IsAccessible(this DirectoryInfo i)
		{
			try
			{
				var readAllow = false;
				var readDeny = false;
				var accessControlList = i.GetAccessControl();
				var accessRules = accessControlList?.GetAccessRules(true, true,
					typeof (System.Security.Principal.SecurityIdentifier));
				if (accessRules == null)
					return false;

				foreach (FileSystemAccessRule rule in accessRules)
				{
					if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

					if (rule.AccessControlType == AccessControlType.Allow)
						readAllow = true;
					else if (rule.AccessControlType == AccessControlType.Deny)
						readDeny = true;
				}

				return readAllow && !readDeny;
			}
			catch
			{
				return false;
			}

		}
		public static bool IsAccessible(this FileInfo i)
		{
			var readAllow = false;
			var readDeny = false;
			var accessControlList = i.GetAccessControl();
			var accessRules = accessControlList?.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
			if (accessRules == null)
				return false;

			foreach (FileSystemAccessRule rule in accessRules)
			{
				if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

				if (rule.AccessControlType == AccessControlType.Allow)
					readAllow = true;
				else if (rule.AccessControlType == AccessControlType.Deny)
					readDeny = true;
			}

			return readAllow && !readDeny;
		}
	}
}
