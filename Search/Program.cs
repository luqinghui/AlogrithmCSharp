using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<string, int> bst = new BST<string, int>();
            bst.put("lu", 1);
            bst.put("li", 2);
            bst.put("wang", 3);
            bst.put("chen", 4);

            bst.print();

            Console.WriteLine(bst.select(2));
        }
    }
}
