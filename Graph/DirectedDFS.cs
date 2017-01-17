using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DirectedDFS
    {
        private bool[] _marked;
        public DirectedDFS(Graph g, int s)
        {
            _marked = new bool[g.V()];
            dfs(g, s);
        }

        public DirectedDFS(Graph g, List<int> sources)
        {
            _marked = new bool[g.V()];
            foreach (int s in sources)
                if (!_marked[s]) dfs(g, s);
        }

        private void dfs(Graph g, int v)
        {
            _marked[v] = true;
            foreach(int w in g.adj(v))
            {
                if (!_marked[w])
                    dfs(g, w);
            }
        }

        public bool marked(int v)
        {
            return _marked[v];
        }
    }
}
