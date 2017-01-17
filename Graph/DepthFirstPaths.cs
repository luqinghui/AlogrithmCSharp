using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DepthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public DepthFirstPaths(Graph g, int s)
        {
            marked = new bool[g.V()];
            edgeTo = new int[g.V()];
            this.s = s;
            dfs(g, s);
        }

        private void dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach(int i in g.adj(v))
            {
                if(!marked[i])
                {
                    edgeTo[i] = v;
                    dfs(g,i);
                }
            }
        }
        public bool hasPathTo(int v)
        {
            return marked[v];
        }
        public Stack<int> pathTo(int v)
        {
            if (!hasPathTo(v))
                return null;
            Stack<int> path = new Stack<int>();
            for(int i = v; i != s; i = edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(s);
            return path;
        }
    }
}
