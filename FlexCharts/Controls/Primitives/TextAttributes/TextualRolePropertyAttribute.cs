using System;

namespace FlexCharts.Controls.Primitives.TextAttributes
{
	public class TextualRolePropertyAttribute : Attribute
	{
		public TextualRole Role { get; }
		public TextualRolePropertyAttribute(TextualRole role)
		{
			Role = role;
		}
	}
}
