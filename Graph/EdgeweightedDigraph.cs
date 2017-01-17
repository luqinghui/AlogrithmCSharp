using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class EdgeweightedDigraph
    {
        private int v;
        private int e;
        private List<DirectedEdge>[] adjs;

        public EdgeweightedDigraph(int v)
        {
            this.v = v;
            this.e = 0;
            adjs = new List<DirectedEdge>[v];
            for(int i=0; i<v;i++)
            {
                adjs[i] = new List<DirectedEdge>();
            }
        }

        public EdgeweightedDigraph(string filename)
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

        public void addEdge(DirectedEdge e)
        {
            adjs[e.from()].Add(e);
            this.e++;
        }

        public List<DirectedEdge> adj(int v)
        {
            return adjs[v];
        }

        public List<DirectedEdge> edges()
        {
            List<DirectedEdge> b = new List<DirectedEdge>();
            for(int i =0;i<v;i++)
            {
                foreach(DirectedEdge e in adjs[i])
                    b.Add(e);
            }
            return b;
        }
    }
}
