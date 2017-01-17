using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class BST<Key, Value> where Key:IComparable
    {
        private bool RED = true;
        private bool BLACK = false;

        private class Node
        {
            public Key key;
            public Value val;
            public Node left, right;
            public int N;
            public bool color;

            public Node(Key key, Value val, int N, bool color)
            {
                this.key = key;
                this.val = val;
                this.N = N;
                this.color = color;
            }
        }

        private Node root;

        private bool isRed(Node x)
        {
            if (x == null)
                return false;
            return x.color == RED;
        }

        Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left) + size(h.right);
            return x;
        }

        Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left) + size(h.right);
            return x;
        }

        void flipColor(Node h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        public int size()
        {
            return size(root);
        }

        private int size(Node x)
        {
            if (x == null) 
                return 0;
            else
                return x.N;
        }

        public Value get(Key key)
        {
            return get(root, key);
        }

        private Value get(Node x, Key key)
        {
            if (x == null)
                return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return get(x.left, key);
            else if (cmp > 0)
                return get(x.right, key);
            else
                return x.val;
        }

        public void put(Key key, Value val)
        {
            root = put(root, key, val);
            root.color = BLACK;
        }

        private Node put(Node x, Key key, Value val)
        {
            if (x == null)
                return new Node(key, val, 1, RED);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.left = put(x.left, key, val);
            else if (cmp > 0)
                x.right = put(x.right, key, val);
            else
                x.val = val;

            if (isRed(x.right) && !isRed(x.left))
                x = rotateLeft(x);
            if (isRed(x.left) && isRed(x.left.left))
                x = rotateRight(x);
            if (isRed(x.right) && isRed(x.left))
                flipColor(x);

            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public Key min()
        {
            return min(root).key;
        }
        private Node min(Node x)
        {
            if (x.left == null)
                return x;
            else
                return min(x.left);
        }

        public Key max()
        {
            return max(root).key;
        }
        private Node max(Node x)
        {
            if (x.right == null)
                return x;
            else
                return max(x.right);
        }

        public Key floor(Key key)
        {
            Node x = floor(root, key);
            if (x == null)
                return default(Key);
            return x.key;
        }
        private Node floor(Node x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
                return x;
            if (cmp < 0)
                return floor(x.left, key);
            Node t = floor(x.right, key);
            if (t != null)
                return t;
            else
                return x;
        }

        public Key ceiling(Key key)
        {
            Node x = ceiling(root, key);
            if (x == null)
                return default(Key);
            return x.key;
        }
        private Node ceiling(Node x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
                return x;
            if (cmp > 0)
                return floor(x.right, key);
            Node t = floor(x.left, key);
            if (t != null)
                return t;
            else
                return x;
        }
        //选出排名为k的键
        public Key select(int k)
        {
            return select(root, k).key;
        }
        private Node select(Node x, int k)
        {
            if (x == null)
                return null;
            int t = size(x.left);
            if (t > k)
                return select(x.left, k);
            else if (t < k)
                return select(x.right, k - t - 1);
            else
                return x;

        }
        //计算键key的排名
        public int rank(Key key)
        {
            return rank(key, root);
        }
        private int rank(Key key, Node x)
        {
            if (x == null)
                return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                return rank(key, x.left);
            else if (cmp > 0)
                return size(x.left) + 1 + rank(key, x.right);
            else
                return size(x.left);
        }

        public void deleteMin()
        {
            root = deleteMin(root);
        }
        private Node deleteMin(Node x)
        {
            if (x.left == null)
                return x.right;
            x.left = deleteMin(x.left);
            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public void delete(Key key)
        {
            root = delete(root, key);
        }
        private Node delete(Node x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.left = delete(x.left, key);
            else if (cmp > 0)
                x.right = delete(x.right, key);
            else
            {
                if (x.right == null)
                    return x.left;
                if (x.left == null)
                    return x.right;
                Node t = x;
                x = min(t.right);
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public void print()
        {
            print(root);
        }

        //中序遍历
        private void print(Node x)
        {
            if (x == null)
                return;
            print(x.left);
            Console.WriteLine(x.key);
            print(x.right);
        }

        public List<Key> keys()
        {
            return keys(min(), max());
        }
        private List<Key> keys(Key lo, Key hi)
        {
            List<Key> queue = new List<Key>();
            keys(root, queue, lo, hi);
            return queue;
        }
        private void keys(Node x, List<Key> queue, Key lo, Key hi)
        {
            if (x == null)
                return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0)
                keys(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Add(x.key);
            if (cmphi > 0)
                keys(x.right, queue, lo, hi);
        }
    }
}
