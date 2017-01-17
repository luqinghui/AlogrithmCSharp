using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sort;

namespace Graph
{
    public class LazyPrimMST
    {
        private bool[] marked;
        private Queue<Edge> mst;
        private MinPQ<Edge> pq;

        public LazyPrimMST(EdgeWeightedGraph g)
        {
            pq = new MinPQ<Edge>();
            marked = new bool[g.V()];
            mst = new Queue<Edge>();

            visit(g, 0);
            while(!pq.isEmpty())
            {
                Edge e = pq.delMin();

                int v = e.either();
                int w = e.other(v);
                if (marked[v] && marked[w])
                    continue;
                mst.Enqueue(e);
                if (!marked[v])
                    visit(g, v);
                if (!marked[w])
                    visit(g, w);
            }
        }

        private void visit(EdgeWeightedGraph g, int v)
        {
            marked[v] = true;
            foreach(Edge e in g.adj(v))
            {
                if (!marked[e.other(v)])
                    pq.insert(e);
            }
        }

        public Queue<Edge> edges()
        {
            return mst;
        }

        public double weight()
        {
            double w = 0;
            foreach(Edge e in mst)
            {
                w += e.weight();
            }
            return w;
        }
    }
}
