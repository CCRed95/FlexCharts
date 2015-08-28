using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCharts.Exceptions;

namespace FlexCharts.Collections
{
	internal static class CollectionHelpers
	{
		internal static int TryAdd<T>(T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotAddToReadOnly(value));
			collection.Add(value);
			return collection.Count;
		}

		internal static void TryInsert<T>(int index, T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotInsertIntoReadOnly(value));
			collection.Insert(index, value);
		}

		internal static bool TryRemove<T>(T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotRemoveFromReadOnly(value));
			if (!collection.Contains(value))
				return false;
			collection.Remove(value);
			return true;
		}

		internal static void TryRemoveAt<T>(int index, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotRemoveAtFromReadOnly(index));
			if (collection.Count >= index)
				throw new IndexOutOfRangeException(FSR.Collections.IndexOutOfRange(index));
			collection.RemoveAt(index);
		}
	}
}