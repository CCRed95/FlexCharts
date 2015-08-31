using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlexCharts.Exceptions;

namespace FlexCharts.Helpers.EventHelpers
{
	public static class EM
	{
		public static RoutedEvent Register<D, H>(RoutingStrategy rs = RoutingStrategy.Bubble, [CallerMemberName] string afn = null)
			where H : class where D : UIElement
		{
			if (!typeof(H).IsSubclassOf(typeof(Delegate)))
				throw new InvalidOperationException($"{typeof(H).Name} is not a delegate type.");
			return EventManager.RegisterRoutedEvent(GetEventName(afn), rs, typeof(H), typeof(D));
		}

		internal static string GetEventName(string autoFieldName)
		{
			if (autoFieldName == null)
				throw new Exception(FSR.DP.AutoCallerNameNotAssigned());
			if (!autoFieldName.EndsWith("Event"))
				throw new Exception(FSR.DP.AutoCallerNameNotValid(autoFieldName));
			return autoFieldName.Replace("Event", string.Empty);
		}
	}
}
