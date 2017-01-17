using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class CC
    {
        private bool[] marked;
        private int[] _id;
        private int _count;

        public CC(Graph g)
        {
            marked = new bool[g.V()];
            _id = new int[g.V()];
            int len = g.V();
            for (int s = 0; s<len; s++)
            {
                if(!marked[s])
                {
                    dfs(g, s);
                    _count++;
                }
            }
        }

        private void dfs(Graph g, int v)
        {
            marked[v] = true;
            _id[v] = _count;
            foreach(int w in g.adj(v))
            {
                if(!marked[w])
                {
                    dfs(g, w);
                }
            }
        }
        public bool connected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public int id(int v)
        {
            return _id[v];
        }

        public int count()
        {
            return _count;
        }
    }
}
