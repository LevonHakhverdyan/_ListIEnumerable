using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ListIEnumerable
{
    public class Monts 
    {
        private string[] _items =
        new string[]
        {
            "Januar",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
             "December"
        };

        public int this[string key]
        {
            get { return GetIndexOfMont(key); }

        }
        public string this[int i]
        {
            get { return _items[i - 1]; }

        }


        private int GetIndexOfMont(string key)
        {
            int defaultmonth = 0;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == key)
                {
                    defaultmonth = i;
                }

            }
            defaultmonth++;
            return defaultmonth;

        }
        public MontsEnumerator GetEnumerator()
        {
            return new MontsEnumerator(_items.Length,_items);
        }
        public class MontsEnumerator : IEnumerator
        {
            private string [] _items;
            private int _size;
            private int count = 0;
            public MontsEnumerator(int size, string  [] items)
            {
                _items = items;
                _size = size;
            }
            
            public object Current => _items[count++];

            public bool MoveNext()
            {
                return count<_size ;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
