using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T>
    {
        public Node<T> root;

        public LinkedList()
        {
            this.root = null;
        }

        public void Insert(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
                Next = this.root
            };

            this.root = newNode;
        }

        public void Reverse()
        {
            Node<T> prev = null, curr = this.root;
            while (curr != null)
            {
                Node<T> next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            this.root = prev;
        }

        public void Print()
        {
            Console.WriteLine();
            Node<T> node = this.root;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }        
    }
}
