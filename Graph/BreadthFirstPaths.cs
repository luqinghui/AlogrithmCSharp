using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class BreadthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public BreadthFirstPaths(Graph g, int s)
        {
            marked = new bool[g.V()];
            edgeTo = new int[g.V()];
            this.s = s;
            bfs(g, s);
        }

        private void bfs(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while(queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach(int w in g.adj(v))
                {
                    if(!marked[w])
                    {
                        marked[w] = true;
                        edgeTo[w] = v;
                        queue.Enqueue(w);
                    }
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
            for (int i = v; i != s; i = edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(s);
            return path;
        }
    }
}
