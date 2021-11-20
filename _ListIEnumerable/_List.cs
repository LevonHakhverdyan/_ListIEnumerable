using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ListIEnumerable
{
    public class _List
    {
        private int[] _items;
        private int _size;
        private int _version;
        private const int _defaultCapacity = 4;
        readonly int[] _emptyArray = new int[0];

        public _List()
        {
            _items = _emptyArray;
        }

        public _List(int capacity)
        {
            if (capacity < 0)
                throw new Exception();

            if (capacity == 0)
                _items = _emptyArray;

            else
                _items = new int[capacity];
        }

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new Exception();
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        int[] newItems = new int[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public int this[int index]
        {
            get
            {

                if ((uint)index >= (uint)_size)
                {
                    throw new Exception();
                }

                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new Exception();
                }

                _items[index] = value;
                _version++;
            }
        }
        public void Add(int item)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = item;
            _version++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
            _version++;
        }
        public bool Contains(int item)
        {
            if ((Object)item == null)
            {
                for (int i = 0; i < _size; i++)
                    if ((Object)_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<int> c = EqualityComparer<int>.Default;
                for (int i = 0; i < _size; i++)
                {
                    if (c.Equals(_items[i], item)) return true;
                }
                return false;
            }
        }
        public void CopyTo(int[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }
        public void CopyTo(int[] array)
        {
            CopyTo(array, 0);
        }
        public void CopyTo(int index, int[] array, int arrayIndex, int count)
        {
            if (_size - index < count)
            {
                throw new Exception();
            }

            Array.Copy(_items, index, array, arrayIndex, count);
        }
        public int IndexOf(int item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public int IndexOf(int item, int index)
        {
            if (index > _size)
                throw new Exception();
            return Array.IndexOf(_items, item, index, _size - index);
        }
        public int IndexOf(int item, int index, int count)
        {
            if (index > _size)
                throw new Exception();
            if (count < 0 || index > _size - count) throw new Exception();

            return Array.IndexOf(_items, item, index, count);
        }
        public void Insert(int index, int item)
        {

            if ((uint)index > (uint)_size)
            {
                throw new Exception();
            }

            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;

        }
        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new Exception();
            }
        }
        public void RemoveRange(int index, int count)
        {
            if (index < 0)
            {
                throw new Exception();
            }

            if (count < 0)
            {
                throw new Exception();

            }

            if (_size - index < count)
                throw new Exception();

            if (count > 0)
            {
                int i = _size;
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
            }
        }
        public override string ToString()
        {
            return $"Count= {Count}";
        }
        public _ListEnumerator GetEnumerator()
        {
            return new _ListEnumerator(_version,_items);
        }
        public class _ListEnumerator : IEnumerator
        {
            private int[] _items;
            private int _size;
            private int count = 0;
            public _ListEnumerator(int size, int [] items)
            {
                _items = items;
                _size = size;
            }
            public object Current => _items[count++];

            public bool MoveNext()
            {
                return count < _size;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
