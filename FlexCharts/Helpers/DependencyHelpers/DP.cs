using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FlexCharts.Extensions;
using System.Windows;
using FlexCharts.Exceptions;
using FlexCharts.Require;

namespace FlexCharts.Helpers.DependencyHelpers
{
	public static class DP
	{
		public static T Get<T>(this DependencyObject i, DependencyProperty dp)
		{
			return (T)i.RequireNotNull().GetValue(dp);
		}
		public static void Set<T>(this DependencyObject i, DependencyProperty dp, T value)
		{
			i.RequireNotNull().SetValue(dp, value);
		}
		/// <summary>
		/// Registers a DependencyProperty using the generic dependency property system
		/// </summary>
		/// <typeparam name="D">
		/// The parent DependencyObject type
		/// </typeparam>
		/// <typeparam name="T">
		/// The type of the property being registered
		/// </typeparam>
		/// <param name="meta">
		/// Generic property metadata for default values, callbacks, and flags
		/// </param>
		/// <param name="validation">
		/// Property validation callback
		/// </param>
		/// <param name="autoFieldName">
		/// The name of the DependencyProperty field being assigned to passed by the compiler
		/// </param>
		/// A registered DependencyProperty for the parent class
		/// <returns>
		/// </returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Register<D, T>(Meta<D, T> meta, PropertyValidate<T> validation = null, [CallerMemberName] string autoFieldName = null) where D : DependencyObject
			=> DependencyProperty.Register(GetPropertyName(autoFieldName), typeof(T), typeof(D),
				new FrameworkPropertyMetadata(meta.DefaultValue, meta.Flags, meta.ChangedCallback.TryInvoke,
					meta.CoerceCallback.TryInvoke), validation.TryInvoke);
		/// <summary>
		/// Registers an Attached DependencyProperty using the generic dependency property system
		/// </summary>
		/// <typeparam name="D">
		/// The parent DependencyObject type
		/// </typeparam>
		/// <typeparam name="T">
		/// The type of the property being registered
		/// </typeparam>
		/// <param name="meta">
		/// Generic property metadata for default values, callbacks, and flags
		/// </param>
		/// <param name="validation">
		/// Property validation callback
		/// </param>
		/// <param name="autoFieldName">
		/// The name of the DependencyProperty field being assigned to passed by the compiler
		/// </param>
		/// <returns>
		/// A registered attached DependencyProperty for the parent class
		/// </returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Attach<D, T>(Meta<DependencyObject, T> meta, PropertyValidate<T> validation = null, [CallerMemberName] string autoFieldName = null)
			=> DependencyProperty.RegisterAttached(GetPropertyName(autoFieldName), typeof(T), typeof(D),
				new FrameworkPropertyMetadata(meta.DefaultValue, meta.Flags, meta.ChangedCallback.TryInvoke,
					meta.CoerceCallback.TryInvoke), validation.TryInvoke);

		/// <summary>
		/// Adds a DependencyProperty owner to a DependencyObject class using the generic dependency property system
		/// </summary>
		/// <typeparam name="D">
		/// The parent DependencyObject type
		/// </typeparam>
		/// <typeparam name="T">
		/// The type of the property being registered
		/// </typeparam>
		/// <param name="property">
		/// DependencyProperty to Add
		/// </param>
		/// <param name="meta">
		/// Generic property metadata for default values, callbacks, and flags
		/// </param>
		/// <param name="options">
		/// 
		/// </param>
		/// <returns>
		/// An added DependencyProperty for the parent class
		/// </returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Add<D, T>(DependencyProperty property, Meta<D, T> meta, DPExtOptions options = DPExtOptions.None) where D : DependencyObject
		 => property.AddOwner(typeof(D), new FrameworkPropertyMetadata(options == DPExtOptions.ForceManualInherit ? property.DefaultMetadata.DefaultValue : meta.DefaultValue, meta.Flags,
				meta.ChangedCallback.TryInvoke, meta.CoerceCallback.TryInvoke));


		[MethodImpl(MethodImplOptions.NoInlining)]
		public static DependencyProperty Attach<T>(Type owner, FrameworkPropertyMetadata meta, PropertyValidate<T> validation = null, [CallerMemberName] string autoFieldName = null)
			=> DependencyProperty.RegisterAttached(GetPropertyName(autoFieldName), typeof(T), owner, meta, validation.TryInvoke);

		/// <summary>
		/// Gets the formatted dependency property name
		/// </summary>
		/// <param name="autoFieldName">
		/// The dependency property field name
		/// </param>
		/// <returns>
		/// Formatted string indicating the dependency property name
		/// </returns>
		internal static string GetPropertyName(string autoFieldName)
		{
			if (autoFieldName == null)
				throw new Exception(FSR.DP.AutoCallerNameNotAssigned());
			if (!autoFieldName.EndsWith("Property"))
				throw new Exception(FSR.DP.AutoCallerNameNotValid(autoFieldName));
			return autoFieldName.Replace("Property", string.Empty);
		}

	}
}
