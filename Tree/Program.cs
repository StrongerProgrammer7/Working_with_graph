using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace LB14_3
{
    public class BinaryTree<T> where T : IComparable
    {
        public class Node<TValue>
        {
            public TValue Value
            {
                get;
                set;
            }
            public Node<TValue> Left
            {
                get;
                set;
            }
            public Node<TValue> Right
            {
                get;
                set;
            }

            public int Level
            {
                get;
                set;
            }

            public Node(TValue value)
            {
                Value = value;
            }
            public Node(TValue value, int lev)
            {
                Value = value;
                Level = lev;
            }

            public Point point = new Point(); //coordinate
            

        }

        protected Node<T> root;
      // protected IComparer<T> comparer;
        public Node<T> Getroot
        {
            get
            {
                return root;
            }
        }


        public BinaryTree(T val, T lev)
        {
            addnode(val, lev);
        }

        public T maxElem
        {
            get
            {
                if (root != null)
                {
                    var curr = root;
                    while(curr.Right!=null)
                    {
                        curr = curr.Right;
                    }
                    return curr.Value;
                }
                else
                    throw new InvalidOperationException("Tree, EMPTY");
            }
        }
        public T minElem
        {
            get
            {
                if (root != null)
                {
                    var curr = root;
                    while (curr.Left != null)
                    {
                        curr = curr.Left;
                    }
                    return curr.Value;
                }
                else
                    throw new InvalidOperationException("Tree, EMPTY");
            }
        }

        public void maxLevel(Node<T> tree,ref int maxlevel)
        {

            if (tree != null)
            {
                if (tree.Level > maxlevel)
                    maxlevel = tree.Level;
                maxLevel(tree.Left, ref maxlevel);
                maxLevel(tree.Right, ref maxlevel);
            }
        }

        public int sumMaxLevel_fromRoot(Node<T> tree,int maxlevel)
        {
            if (tree != null)
            {
                if (tree.Level == maxlevel)
                    return Convert.ToInt32(tree.Value) + sumMaxLevel_fromRoot(tree.Left, maxlevel) + sumMaxLevel_fromRoot(tree.Right, maxlevel);
                else
                    return sumMaxLevel_fromRoot(tree.Left, maxlevel) + sumMaxLevel_fromRoot(tree.Right, maxlevel);
            }
            else
                return 0;

        }

        public void zeroing_of_perfect_leaves(Node<int> tree)
        {
            if(tree!=null)
            {
                int min = Convert.ToInt32(minElem);
                int max = Convert.ToInt32(maxElem);
                if (tree.Left==null && tree.Right==null && perfect_leaves(tree.Value) && tree.Value>(max-min))
                {
                    tree.Value = 0;
                }
                zeroing_of_perfect_leaves(tree.Left);
                zeroing_of_perfect_leaves(tree.Right);
            }
        }

        private bool perfect_leaves(int x)
        {
            int sum = 0;
            for(int i=1;i<x;i++)
            {
                if (x % i == 0)
                    sum += i;
            }
            if (sum == x)
                return true;
            else
                return false;
        }

        public int Count
        {
            get;
            protected set;
        }
        protected int Compare(T Value, T val)
        {
            if (Value.CompareTo(val)>0)
            {
                return -1;
            }
            else
                if (Value.CompareTo(val) < 0)
                return 1;
            else
                if (Value.CompareTo(val) == 0)
                return 0;
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public void addnode(T val,T lev)
        {
            int lev1 = Convert.ToInt32(lev);
            var node = new Node<T>(val,lev1);
            if (root == null)
                root = node;
            else
            {
                Node<T> current = root, parent_node = null;

                while(current!=null)
                {
                    parent_node = current;
                    if (Compare(current.Value, val) < 0)
                    {
                        current = current.Left;
                        lev1 = lev1 + 1;
                    }  
                    else
                    {
                        current = current.Right;
                        lev1 = lev1 + 1;
                    }
                       
                }
                node.Level = lev1;
                if (Compare(parent_node.Value,val)<0)
                    parent_node.Left = node;
                else
                    parent_node.Right = node;
            }
            ++Count;
           
        }

        //прямой обход
        public void printTree_direct(StreamWriter file, Node<int> tree)
        {
            if (tree != null)
            {
                file.WriteLine(tree.Value);
                printTree_direct(file, tree.Left);
                printTree_direct(file, tree.Right);  
            } 
        }
        //обратный обход
        public void printTree_reverse(StreamWriter file, Node<int> tree)
        {
            if (tree != null)
            {

                printTree_reverse(file, tree.Left);
                printTree_reverse(file, tree.Right);
                file.WriteLine(tree.Value);
            }
        }
        //внутренний обход
        public void printTree_internal(StreamWriter file, Node<int> tree)
        {
            if (tree != null)
            {
                printTree_internal(file, tree.Left);
                file.WriteLine(tree.Value);
                printTree_internal(file, tree.Right);
            }
        }

        public bool checkTree(Node<int> tree)
        {
            if(tree!=null)
            {
                if (isnotleav_tree(tree) && tree.Value == 0)
                    return false;
                checkTree(tree.Left);
                checkTree(tree.Right);
            }
            return true;
        }

        private bool isnotleav_tree(Node<int> node)
        {
            if ((node.Left != null && node.Right != null) || (node.Left == null && node.Right != null) || (node.Left != null && node.Right == null))
                return true;
            return false;
        }

        public void cleartree()
        {
            root = null;
        }

        /*private BinaryTree<T> _search(BinaryTree<T> tree, T val)
        {
            if (tree == null)
                return null;
            switch (val.CompareTo(tree.val))
            {
                case 1: return _search(tree.right, val);
                case 2: return _search(tree.left, val);
                case 0: return tree;
                default: return null;
            }
        }*/

        /*public BinaryTree<T> search(T val)
        {
            return _search(this, val);
        }*/

    }

    public static class Match
    {
        public static double deg_to_radian(Double deg)
        {
            return deg * Math.PI / 180;
        }

        public static double radian_to_deg(double rad)
        {
            return rad / Math.PI * 180;
        }

        public static double lengthdir_x(double len, double dir) // Расстояние по Х при передвижении по направлению
        {
            return len * Math.Cos(deg_to_radian(dir));
        }

        public static double lengthdir_y(double len,double dir)//расст по У при  передвижении по направлению
        {
            return len * Math.Sin(deg_to_radian(dir))*-1;
        }

        public static double point_direction(int x1,int y1,int x2,int y2)//угол направ между двумя точками
        {
            return 180 - radian_to_deg(Math.Atan2(y1 - y2, x1 - x2));
        }

        public static double point_distance(int x1,int y1,int x2,int y2)//Расст между двумя точками
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
