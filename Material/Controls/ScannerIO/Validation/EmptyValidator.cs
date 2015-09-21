using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.Controls.ScannerIO.Validation
{
	public class EmptyValidator<T> : AbstractValidator<T>
	{
		public override string FormatDescription => "Scan Barcode";

		public override ValidatorResult IsValid(T value)
		{
			return ValidatorResult.PASSED;
		}
	}
}
