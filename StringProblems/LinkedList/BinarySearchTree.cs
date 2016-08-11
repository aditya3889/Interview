using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    public class BinarySearchTree<T> where T: IComparable
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>
            {
                Data = data,
                Left = null,
                Right = null
            };

            if (this.root == null)
            {
                this.root = newNode;
                return;
            }

            TreeNode<T> currentNode = this.root, prevNode = null;
            while (currentNode != null)
            {
                prevNode = currentNode;
                if (currentNode.Data.CompareTo(data) == 0)
                {
                    return;
                }
                else if (currentNode.Data.CompareTo(data) > 0)
                {
                    currentNode = currentNode.Left;    
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            if (data.CompareTo(prevNode.Data) <= 0)
            {
                prevNode.Left = newNode;
            }
            else
            {
                prevNode.Right = newNode;
            }
        }

        public void InOrder()
        {
            InOrder(this.root);
        }

        private void InOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left);
            Console.WriteLine(node.Data);
            InOrder(node.Right);
        }


        public void SumTo(int data)
        {
            Stack<TreeNode<T>> left = new Stack<TreeNode<T>>();
            Stack<TreeNode<T>> right = new Stack<TreeNode<T>>();
            TreeNode<T> current = this.root;
            while (current != null)
            {
                left.Push(current);
                current = current.Left;
            }

            current = this.root;
            while (current != null)
            {
                right.Push(current);
                current = current.Right;
            }

            while(left.Any() && right.Any())
            {

            }

        }
    }
}
