using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.libs
{
    public class IndexMaxPQ<Key> where Key:IComparable
    {
        private int n;
        private int[] pq;
        private int[] qp;
        private Key[] keys;

        public IndexMaxPQ(int maxN)
        {
            n = 0;
            keys = new Key[maxN + 1];
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];
            for (int i = 0; i <= maxN; i++)
            {
                qp[i] = -1;
            }
        }

        public bool isEmpty()
        {
            return n == 0;
        }

        public bool contains(int i)
        {
            return qp[i] != -1;
        }
        public int size()
        {
            return n;
        }

        public void insert(int i,Key key)
        {
            n++;
            qp[i] = n;      //qp 是索引数组，下标是插入顺序（即索引），值是堆中位置
            pq[n] = i;      //pq 是堆，下标是堆中位置，值是插入顺序（即索引）
            keys[i] = key;  //keys 是对象数组，下标是插入顺序（即索引），值是对象本身
            swim(n);
        }
        public int maxIndex()
        {
            return pq[1];
        }
        public Key maxKey()
        {
            return keys[pq[1]];
        }
        public int delMax()
        {
            int min = pq[1];
            exch(1, n--);
            sink(1);

            qp[min] = -1;
            keys[min] = default(Key);
            pq[n + 1] = -1;
            return min;
        }
        public Key keyOf(int i)
        {
            return keys[i];
        }
        public void changeKey(int i,Key key)
        {
            keys[i] = key;
            swim(qp[i]);
            sink(qp[i]);
        }
        public void change(int i,Key key)
        {
            changeKey(i, key);
        }
        public void increaseKey(int i,Key key)
        {
            keys[i] = key;
            swim(qp[i]);
        }
        public void decreaseKey(int i,Key key)
        {
            keys[i] = key;
            sink(qp[i]);
        }

        public void delete(int i)
        {
            int index = qp[i];
            exch(index, n--);
            swim(index);
            sink(index);
            keys[i] = default(Key);
            qp[i] = -1;
        }

        private bool less(int i,int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) < 0;
        }
        private void exch(int i,int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;

            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
        private void swim(int k)
        {
            while(k >1 && less(k/2,k))
            {
                exch(k, k / 2);
                k = k / 2;
            }
        }
        private void sink(int k)
        {
            while(2*k <= n)
            {
                int j = 2 * k;
                if (j < n && less(j, j + 1)) j++;
                if (!less(k, j)) break;
                exch(k, j);
                k = j;
            }
        }
    }
}
