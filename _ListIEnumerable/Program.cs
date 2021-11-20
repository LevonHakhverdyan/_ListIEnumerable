using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ListIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Monts monts = new Monts();
            foreach (string item in monts )
            {
                Console.WriteLine($"{item}");
            }

            _List list = new _List();
            list.Add(12);
            list.Add(123);
            list.Add(124);
            list.Add(125);
            list.Add(126);
            list.Add(127);
            list.Add(128);
            list.Add(129);
            list.Add(120);
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
