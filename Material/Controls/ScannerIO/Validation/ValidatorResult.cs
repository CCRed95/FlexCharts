using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.Controls.ScannerIO.Validation
{
	public enum ValidatorResult : uint
	{
		FAILEDFORMAT = 0,
		FAILEDDUPLICATE = 1,
		FAILEDFILEIO = 2,
		PASSED = 3
	}
}
