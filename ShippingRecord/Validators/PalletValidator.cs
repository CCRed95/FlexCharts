using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Material.Controls.ScannerIO.Validation;

namespace ShippingRecord.Validators
{
	public class PalletValidator : AbstractValidator<string>
	{
		public override string FormatDescription => "B########";

		public override ValidatorResult IsValid(string value)
		{
			if (value.StartsWith("B"))
			{
				return ValidatorResult.PASSED;
			}
			return ValidatorResult.FAILEDFORMAT;
		}
	}
}