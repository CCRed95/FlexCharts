using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using FlexCharts.Collections;
using FlexCharts.Require;

namespace FlexCharts.Data.Collections
{
	public class Series<T> : IList, IList<T>
	{
		protected IList<T> _innerArray = new List<T>();

		public virtual IEnumerator<T> GetEnumerator() => _innerArray.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}
		public virtual void CopyTo(T[] array, int index)
		{
			_innerArray.CopyTo(array, index);
		}

		public int Count => _innerArray.Count;

		public object SyncRoot => (_innerArray as IList)?.SyncRoot ?? new object();

		public bool IsSynchronized => false;

		int IList.Add(object value)
		{
			Add(value.RequireType<T>());
			return Count - 1;
		}
		public virtual void Add(T value) => CollectionHelpers.TryAdd(value, ref _innerArray);

		bool IList.Contains(object value) => Contains(value.RequireType<T>());
		public virtual bool Contains(T value) => _innerArray.Contains(value);

		public void Clear() => _innerArray.Clear();

		int IList.IndexOf(object value) => IndexOf(value.RequireType<T>());
		public virtual int IndexOf(T value) => _innerArray.IndexOf(value);

		void IList.Insert(int index, object value) => Insert(index, value.RequireType<T>());
		public virtual void Insert(int index, T value) => CollectionHelpers.TryInsert(index, value, ref _innerArray);

		void IList.Remove(object value) => Remove(value.RequireType<T>());
		public virtual bool Remove(T value) => CollectionHelpers.TryRemove(value, ref _innerArray);

		public virtual void RemoveAt(int index) => CollectionHelpers.TryRemoveAt(index, ref _innerArray);

		object IList.this[int index]
		{
			get { return this[index]; }
			set { this[index] = value.RequireType<T>(); }
		}
		public virtual T this[int index]
		{
			get { return _innerArray[index]; }
			set { _innerArray[index] = value; }
		}

 		public virtual bool IsReadOnly => _innerArray.IsReadOnly;

		public virtual bool IsFixedSize => (_innerArray as IList)?.IsFixedSize ?? IsReadOnly;
		//public void RaiseCollectionChangedEvent(EventArgs e)
		//{
		//	if (CollectionChanged != null) { CollectionChanged(this, new NotifyCollectionChangedEventArgs()); }
		//}
		//public event NotifyCollectionChangedEventHandler CollectionChanged;
	}
}
