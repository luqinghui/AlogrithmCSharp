using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge:IComparable
    {
        private int v;
        private int w;
        private double _weight;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this._weight = weight;
        }

        public double weight()
        {
            return _weight;
        }

        public int either()
        {
            return v;
        }
        public int other(int vertex)
        {
            if (vertex == v)
                return w;
            else
                return v;
        }

        public int CompareTo(Edge other)
        {
            if (this.weight() < other.weight())
                return -1;
            else if (this.weight() > other.weight())
                return 1;
            else
                return 0;
        }
    }
}
