using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DepthFirstOrder
    {
        private bool[] marked;

        private Queue<int> _pre;
        private Queue<int> _post;
        private Stack<int> _reversePost;

        public DepthFirstOrder(Digraph g)
        {
            _pre = new Queue<int>();
            _post = new Queue<int>();
            _reversePost = new Stack<int>();

            marked = new bool[g.V()];

            for (int v = 0; v < g.V(); v++)
                if (!marked[v])
                    dfs(g, v);
        }

        private void dfs(Digraph g, int v)
        {
            _pre.Enqueue(v);

            marked[v] = true;

            foreach(int w in g.adj(v))
            {
                if (!marked[w])
                    dfs(g, w);
            }

            _post.Enqueue(v);
            _reversePost.Push(v);
        }

        public Queue<int> pre()
        {
            return _pre;
        }

        public Queue<int> post()
        {
            return _post;
        }

        public Stack<int> reversePost()
        {
            return _reversePost;
        }
    }
}
