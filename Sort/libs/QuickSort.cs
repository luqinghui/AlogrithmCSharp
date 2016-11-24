using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.libs
{
    class QuickSort<T>
    {
        public static void sort(T[] a)
        {
            show(a);
            int len = a.Length;
            sort(a, 0, len-1);
            show(a);
        }
        private static void sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = partition(a, lo, hi);
            sort(a, lo, j - 1);
            sort(a, j + 1, hi);
        }

        private static int partition(T[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            T v = a[lo];
            while(true)
            {
                while (less(a[++i], v)) if (i == hi) break;
                while (less(v, a[--j])) if (j == lo) break;
                if (i >= j) break;
                exch(a, i, j);
            }
            exch(a, lo, j);
            return j;
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
