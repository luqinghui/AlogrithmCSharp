using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Digraph
    {
        private int v;
        private int e;

        private List<int>[] adjs;

        public Digraph(int v)
        {
            this.v = v;
            this.e = 0;

            adjs = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adjs[i] = new List<int>();
            }
        }

        public Digraph(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            int count = lines.Length;
            e = Convert.ToInt32(lines[1]);
            for (int i = 2; i < count; i++)
            {
                string[] vs = lines[i].Split(' ');
                addEdge(Convert.ToInt32(vs[0]), Convert.ToInt32(vs[1]));
                e++;
            }
        }

        public int V()
        {
            return v;
        }
        public int E()
        {
            return e;
        }

        public void addEdge(int v, int w)
        {
            adjs[v].Add(w);
            //adjs[w].Add(v);
            e++;
        }
        public List<int> adj(int v)
        {
            return adjs[v];
        }

        public Digraph reverse()
        {
            Digraph r = new Digraph(v);
            for(int i=0;i<v;i++)
            {
                foreach(int w in adj(i) )
                {
                    r.addEdge(w, i);
                }
            }
            return r;
        }
    }
}
