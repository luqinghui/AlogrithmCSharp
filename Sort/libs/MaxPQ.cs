using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.libs
{
    public class MaxPQ<T> where T:IComparable
    {
        private T[] pq;
        private int n;
        public MaxPQ(int initCapacity)
        {
            pq = new T[initCapacity + 1];
            n = 0;
        }
        public MaxPQ():this(1)
        {
            
        }
       
        public void insert(T v)
        {
            if (n >= pq.Length - 1) resize(2 * pq.Length);

            pq[++n] = v;
            swim(n);
        }
        public T delMax()
        {
            T max = pq[1];
            exch(1, n--);
            pq[n + 1] = default(T);
            sink(1);
            if ((n > 0) && (n == (pq.Length - 1) / 4)) resize(pq.Length / 2);
            return max;
        }

        
        private void resize(int capacity)
        {
            T[] temp = new T[capacity];
            for(int i=1;i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        private void swim(int k)
        { 
            while(k > 1 && less(k/2,k))
            {
                exch(k / 2, k);
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

        private bool less(int i, int j)
        {
            return (pq[i].CompareTo(pq[j]) < 0);
        }
        private void exch(int i, int j)
        {
            T temp;
            temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }
        public bool isEmpty()
        {
            return n == 0;
        }
        public int size()
        {
            return n;
        }
    }
}
