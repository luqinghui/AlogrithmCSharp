using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MinPQ<Key> where Key:IComparable
    {
        private Key[] pq;
        private int n;


        public MinPQ(int initCapacity)
        {
            pq = new Key[initCapacity + 1];
            n = 0;
        }

        public MinPQ():this(1)
        {

        }

        public bool isEmpty()
        {
            return n == 0;
        }

        public int size()
        {
            return n;
        }

        public Key min()
        {
            if (!isEmpty())
                return pq[1];
            else
                return default(Key);
        }

        private void resize(int capacity)
        {
            Key[] temp = new Key[capacity];
            for(int i=1; i<=n;i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        public void insert(Key x)
        {
            if (n == pq.Length - 1)
                resize(2 * pq.Length);
            pq[++n] = x;
            swim(n);
        }

        public Key delMin()
        {
            if (isEmpty())
                return default(Key);
            exch(1, n);
            Key min = pq[n--];
            sink(1);
            if (n > 0 && (n == (pq.Length - 1) / 4))
                resize(pq.Length / 2);
            return min;
        }

        private bool greater(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }

        private void exch(int i, int j)
        {
            Key swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        private void sink(int k)
        {
            while(2*k <= n)
            {
                int j = 2 * k;
                if (j < n && greater(j, j + 1))
                    j++;
                if (!greater(k, j))
                    break;
                exch(k, j);
                k = j;

            }
        }

        private void swim(int k)
        {
            while(k>1 && greater(k/2, k))
            {
                exch(k, k / 2);
                k = k / 2;
            }
        }
    }
}
