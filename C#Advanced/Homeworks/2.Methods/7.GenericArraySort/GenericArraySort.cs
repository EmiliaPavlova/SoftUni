using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.GenericArraySort
{
    class GenericArraySort
    {
        private static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
            string[] strings = { "zaz", "cba", "baa", "azis" };
            DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

            Console.WriteLine(SortedArray(numbers));
            Console.WriteLine(SortedArray(strings));
            Console.WriteLine(SortedArray(dates));
        }

        private static string SortedArray <T> (IEnumerable<T> array)
            {
                List<T> tempList = array.ToList();
                List<T> sortedList = new List<T>();

                while (tempList.Count != 0)
                {
                    var x = tempList.Min();
                    sortedList.Add(x);
                    tempList.Remove(x);
                }
                return string.Join(", ", sortedList);

            }
        }
    }

