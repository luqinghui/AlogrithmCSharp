using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class QuickSort<T>
    {
        private static int INSERTION_SORT_CUTOFF = 8;
        private static int MEDIAN_OF_3_CUTOFF = 40;
        public static void sort(T[] a)
        {
            int len = a.Length;

            //随机排列数组

            sort(a, 0, len-1);
        }

        //普通快速排序（使用插入排序替换）
        private static void sort(T[] a, int lo, int hi)
        {
            //if (hi <= lo) return;
            //小数组时，切换为插入排序
            if (hi <= lo + INSERTION_SORT_CUTOFF)
            {
                InsertSort<T>.sort(a,lo,hi);
                return;
            }
            int j = partition(a, lo, hi);
            sort(a, lo, j - 1);
            sort(a, j + 1, hi);
        }
        private static int partition(T[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            T v = a[lo];
            while (true)
            {
                //设置哨兵
                //去掉内循环while的边界检查
                //由于切分元素本身就是一个哨兵（v不可能小于a[lo]），左侧边界的检查是多余的
                //去掉右侧的边界检查，可以在打乱数组后将数组的最大元素放在a[length-1]，该元素永远不会移动（除非和相等的元素交换）
                while (less(a[++i], v)) if (i == hi) break;
                while (less(v, a[--j])) if (j == lo) break;
                if (i >= j) break;
                exch(a, i, j);
            }
            exch(a, lo, j);
            return j;
        }

        //三取样，任取一部分元素，求其中位数，以此切分数组
        private static int median3(T[] a, int i,int j,int k)
        {
            return (less(a[i],a[j]))?
                (less(a[j],a[k])?j:less(a[i],a[k])?k:i):
                (less(a[k],a[j])?j:less(a[k],a[i])?k:i);
        }

        //五取样

        //三向切分快速排序
        private static void sort3Way(T[] a,int lo,int hi)
        {
            if (hi <= lo) return;
            int lt = lo, i = lo + 1, gt = hi;
            T v = a[lo];
            while (i <= gt)
            {
                int cmp = (a[i] as IComparable).CompareTo(v);
                if (cmp < 0) exch(a, lt++, i++);
                else if (cmp > 0) exch(a, i, gt--);
                else i++;
            }
            sort3Way(a, lo, lt - 1);
            sort3Way(a, gt + 1, hi);
        }

        //快速三向切分快速排序
        private static void sortQuick3Way(T[] a,int lo,int hi)
        {
            int n = hi - lo + 1;
            if(n <= INSERTION_SORT_CUTOFF)
            {
                InsertSort<T>.sort(a);
                return;
            }
            else if(n <=MEDIAN_OF_3_CUTOFF)
            {
                int m = median3(a, lo, lo + n / 2, hi);
                exch(a, m, lo);
            }
            else
            {
                int eps = n / 8;
                int mid = lo + n / 2;
                int m1 = median3(a, lo, lo + eps, lo + eps + eps);
                int m2 = median3(a, mid - eps, mid, mid + eps);
                int m3 = median3(a, hi - eps - eps, hi - eps, hi);
                int ninther = median3(a, m1, m2, m3);
                exch(a, ninther, lo);
            }

            int i = lo, j = hi + 1;
            int p = lo, q = hi + 1;
            T v = a[lo];
            while(true)
            {
                while (less(a[++i], v))
                    if (i == hi) break;
                while (less(v, a[--j]))
                    if (j == lo) break;

                if (i == j && eq(a[i], v))
                    exch(a, ++p, i);
                if (i >= j) break;

                exch(a, i, j);
                if (eq(a[i], v)) exch(a, ++p, i);
                if (eq(a[j], v)) exch(a, --q, j);
            }

            i = j + 1;
            for (int k = lo; k <= p; k++)
                exch(a, k, j--);
            for (int k = hi; k >= q; k--)
                exch(a, k, i++);

            sortQuick3Way(a, lo, j);
            sortQuick3Way(a, i, hi);
        }

        //判断a<b
        private static bool less(T a, T b)
        {
            IComparable at = a as IComparable;
            IComparable bt = b as IComparable;
            return (at.CompareTo(b) < 0);
        }
        //判断a==b
        private static bool eq(T a, T b)
        {
            return (a as IComparable).CompareTo(b) == 0;
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
