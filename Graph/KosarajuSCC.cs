using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class KosarajuSCC
    {
        private bool[] marked;
        private int[] _id;
        private int _count;

        public KosarajuSCC(Digraph g)
        {
            marked = new bool[g.V()];
            _id = new int[g.V()];
            DepthFirstOrder order = new DepthFirstOrder(g.reverse());
            Stack<int> reversePost = order.reversePost();
            foreach(int s in reversePost)
            {
                if(!marked[s])
                {
                    dfs(g, s);
                    _count++;
                }
            }
        }

        private void dfs(Digraph g, int v)
        {
            marked[v] = true;
            _id[v] = _count;
            foreach(int w in g.adj(v))
            {
                if (!marked[w])
                    dfs(g, w);
            }
        }

        public bool stronglyConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public int id(int v, int w)
        {
            return _id[v];
        }
        public int count()
        {
            return _count;
        }
    }
}
