using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace HotChocolate.Types.Descriptors.Definitions
{
    public sealed class BindableList<T>
        : IBindableList<T>
    {
        private ImmutableList<T> _list = ImmutableList<T>.Empty;

        public T this[int index]
        {
            get => _list[index];
            set => _list = _list.SetItem(index, value);
        }

        T IReadOnlyList<T>.this[int index] => _list[index];

        public BindingBehavior BindingBehavior { get; set; }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list = _list.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _list = _list.AddRange(items);
        }

        public void Clear()
        {
            _list = ImmutableList<T>.Empty;
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list = _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            ImmutableList<T> list = _list;
            _list = _list.Remove(item);
            return list.Count > _list.Count;
        }

        public void RemoveAt(int index)
        {
            _list = _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
