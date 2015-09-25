using Material.Controls.ScannerIO.Validation;

namespace ShippingRecord.Validators
{
	public enum UPCType
	{
		Controller,
		Steamlink,
		Unknown
	}
	public class UPCValidator : AbstractValidator<string>
	{
		public const string ControllerUPC = "814585020038";//814585020007

		public const string SteamlinkUPC = "814585020021";

		public override string FormatDescription =>	"8145850200(07/21)";
		public override ValidatorResult IsValid(string value)
		{
			if (value == ControllerUPC || value == SteamlinkUPC)
			{
				return ValidatorResult.PASSED;
			}
			return ValidatorResult.FAILEDFORMAT;
		}

		public static UPCType GetUPCType(string upc)
		{
			if (upc == ControllerUPC)
			{
				return UPCType.Controller;
			}
			if (upc == SteamlinkUPC)
			{
				return UPCType.Steamlink;
			}
			return UPCType.Unknown;
		}
	}
}
