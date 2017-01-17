using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class SymbolGraph
    {
        private Dictionary<string, int> st;
        private string[] keys;
        private Graph g;

        public SymbolGraph(string filename, char sp)
        {
            st = new Dictionary<string,int>();
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach(string line in lines)
            {
                string[] a = line.Split(sp);

                for(int i=0;i<a.Length;i++)
                {
                    if(!st.ContainsKey(a[i]))
                    {
                        st.Add(a[i], st.Count);
                    }
                }
            }

            keys = new string[st.Count];
            foreach(string name in st.Keys)
            {
                keys[st[name]] = name;
            }

            g = new Graph(st.Count);

            foreach(string line in lines)
            {
                string[] a = line.Split(sp);
                int v = st[a[0]];

                for(int i =1;i<a.Length;i++)
                {
                    g.addEdge(v, st[a[i]]);
                }
            }
        }

        public bool contains(string s)
        {
            return st.ContainsKey(s);
        }
        public int index(string s)
        {
            return st[s];
        }
        public string name(int v)
        {
            return keys[v];
        }
        public Graph G()
        {
            return g;
        }
    }
}
