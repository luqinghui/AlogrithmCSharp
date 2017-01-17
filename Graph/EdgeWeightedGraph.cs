using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class EdgeWeightedGraph
    {
        private int v;
        private int e;
        private List<Edge>[] adjs;

        public EdgeWeightedGraph(int v)
        {
            this.v = v;
            this.e = 0;

            adjs = new List<Edge>[v];
            for(int i = 0; i<v;i++)
            {
                adjs[i] = new List<Edge>();
            }
        }

        public EdgeWeightedGraph(string filename)
        {

        }

        public int V()
        {
            return v;
        }
        public int E()
        {
            return e;
        }

        public void addEdge(Edge e)
        {
            int v = e.either();
            int w = e.other(v);

            adjs[v].Add(e);
            adjs[w].Add(e);
            this.e++;
        }

        public List<Edge> adj(int v)
        {
            return adjs[v];
        }
        public List<Edge> edges()
        {
            List<Edge> b = new List<Edge>();
            for(int v=0; v<this.v;v++)
            {
                foreach (Edge e in adjs[v])
                    if (e.other(v) > v)
                        b.Add(e);
            }
            return b;
        }

    }
}
