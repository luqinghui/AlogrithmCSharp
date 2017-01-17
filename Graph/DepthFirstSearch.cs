using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DepthFirstSearch
    {
        private bool[] _marked;
        private int _count;

        public DepthFirstSearch(Graph g, int s)
        {
            _marked = new bool[g.V()];
            dfs(g, s);
        }

        private void dfs(Graph g, int v)
        {
            _marked[v] = true;
            _count++;
            foreach(int w in g.adj(v))
            {
                if (!_marked[w])
                    dfs(g, w);
            }
        }
        
        public bool marked(int w)
        {
            return _marked[w];
        }
        public int count()
        {
            return _count;
        }

    }
}
