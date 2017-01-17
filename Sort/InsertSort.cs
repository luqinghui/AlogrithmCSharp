using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class InsertSort<T>
    {
        public static void sort(T[] a)
        {
            int len = a.Length;
            for(int i = 1; i < len; i++)
            {
                for(int j = i; j > 0 && less(a[j],a[j-1]); j--)
                {
                    exch(a, j,j-1);
                }
            }
        }
        public static void sort(T[] a, int lo, int hi)
        {
            for(int i = lo+1;i<=hi;i++)
            {
                for(int j=1;j>lo&&less(a[j],a[j-1]);j--)
                {
                    exch(a, j, j - 1);
                }
            }
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
            for (int i = 0; i < len; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
