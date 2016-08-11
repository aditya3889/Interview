using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestLinkedList();
            TestBst();
        }

        private static void TestBst()
        {
            BinarySearchTree<int> list = new BinarySearchTree<int>();
            Random r = new Random();
            for (int i = 100; i > 0; i--)
            {
                list.Insert(r.Next()%1000);
            }

            list.InOrder();
        }

        private static void TestLinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 10; i > 0; i--)
            {
                list.Insert(i);
            }

            list.Print();
            list.Reverse();
            list.Print();
        }
    }
}
