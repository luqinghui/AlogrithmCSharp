using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> _cycle = null;
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            onStack = new bool[g.V()];
            edgeTo = new int[g.V()];
            marked = new bool[g.V()];

            for (int v = 0; v < g.V(); v++)
                if (!marked[v]) dfs(g, v);
        }

        private void dfs(Digraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;

            foreach(int i in g.adj(v))
            {
                if (this.hasCycle()) return;
                else if(!marked[i])
                {
                    edgeTo[i] = v;
                    dfs(g, i);
                }
                else if(onStack[i])
                {
                    _cycle = new Stack<int>();
                    for (int x = v; x != i; x = edgeTo[x])
                        _cycle.Push(x);
                    _cycle.Push(i);
                    _cycle.Push(v);
                }
            }
            onStack[v] = false;
        }

        public bool hasCycle()
        {
            return _cycle != null;
        }
        public Stack<int> cycle()
        {
            return _cycle;
        }
    }
}
