using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = { 's', 'o', 'r', 't', 'e', 'x', 'a', 'm', 'p', 'l', 'e' };
            //Sort.libs.SelectSort<char>.sort(s);
            //Sort.libs.InsertSort<char>.sort(s);
            Sort.libs.MergeSort<char>.sort(s);
        }
    }
}
