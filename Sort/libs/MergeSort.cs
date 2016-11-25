using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.libs
{
    class MergeSort<T>
    {
        private static T[] aux;
        public static void sort(T[] a)
        {
            aux = new T[a.Length];
            //sort(a, 0, a.Length - 1);
            sort_BU(a);
        }
        //归并
        public static void merge(T[] a, int lo,int mid,int hi)
        {
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];

            for(int k=lo;k<=hi;k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (less(aux[i], aux[j])) a[k] = aux[i++];
                else a[k] = aux[j++];
            }
        }
        //自上而下
        private static void sort(T[] a,int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, lo, mid);
            sort(a, mid + 1, hi);
            merge(a, lo, mid, hi);
        }
        //自下而上
        public static void sort_BU(T[] a)
        {
            int N = a.Length;
            for (int sz = 1; sz < N; sz = sz + sz)
                for (int lo = 0; lo < N - sz; lo += sz + sz)
                    merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
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
