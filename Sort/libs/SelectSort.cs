using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.libs
{
    //选择排序
    public class SelectSort<T>
    {
        public static void sort(T[] a)
        {
            show(a);
            int len = a.Length;
            for (int i = 0; i < len; i++)
            {
                int min = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (less(a[j], a[min])) min = j;
                }
                exch(a, i, min);
            }
            show(a);
        }
        private static bool less(T a, T b)
        {
            IComparable at = a as IComparable;
            IComparable bt = b as IComparable;
            return (at.CompareTo(b) < 0);
        }
        private static void exch(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
        private static void show(T[] a)
        {
            int len = a.Length;
            for(int i = 0; i < len; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
        public static bool isSort(T[] a)
        {
            int len = a.Length;
            for (int i = 1; i < len; i++)
            {
                if (less(a[i] , a[i - 1]))
                    return false;
            }
            return true;
        }
    }
}
