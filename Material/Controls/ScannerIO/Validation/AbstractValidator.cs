using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.Controls.ScannerIO.Validation
{
	public abstract class AbstractValidator<T>
	{
		public abstract string FormatDescription { get; }
		public abstract ValidatorResult IsValid(T value);
	}
}
