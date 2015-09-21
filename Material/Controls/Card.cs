using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Controls.Core;

namespace Material.Controls
{
	public class Card : FlexContentControl
	{
		static Card()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (Card), new FrameworkPropertyMetadata(typeof (Card)));
		}
		public Card() { }
	}
}
