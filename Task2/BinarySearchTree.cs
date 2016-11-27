using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Fields

        private Node root;
        private Func<T, T, int> comparer;

        public int Count { get; private set; }

        #endregion


        #region .ctor

        /// <summary>
        /// Empty tree ctor.
        /// </summary>

        public BinarySearchTree()
        {
            ComparerInit();
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="comparer">Comperer type of T.</param>

        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer == null)
                ComparerInit();
            else
                this.comparer = (t1, t2) => comparer.Compare(t1, t2);
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="comparer">Delegate get first parametr type of T, second parametr type of T and give parametr type of int.</param>

        public BinarySearchTree(Func<T, T, int> comparer)
        {
            if (comparer == null)
                ComparerInit();
            else
                this.comparer = comparer;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="items">Enumerable type of T.</param>

        public BinarySearchTree(IEnumerable<T> items)
        {
            ComparerInit();
            ItemsInit(items);
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="items">Enumerable type of T.</param>
        /// <param name="comparer">Delegate get first parametr type of T, second parametr type of T and give parametr type of int.</param>

        public BinarySearchTree(IEnumerable<T> items, Func<T, T, int> comparer) : this(comparer)
        {
            ItemsInit(items);
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="items">Enumerable type of T.</param>
        /// <param name="comparer">Comperer type of T.</param>

        public BinarySearchTree(IEnumerable<T> items, IComparer<T> comparer) : this(comparer)
        {
            ItemsInit(items);
        }

        #endregion

        /// <summary>
        /// Add node.
        /// </summary>
        /// <param name="item">Element of T type.</param>

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node current = root;
            Node parent = null;
            int comparison;
            while (current != null)
            {
                comparison = comparer(item, current.Value);
                if (comparison == 0)
                    return;
                parent = current;
                current = comparison > 0 ? current.Right : current.Left;
            }
            if (parent == null)
                root = new Node(item);
            else
            {
                comparison = comparer(item, parent.Value);
                if (comparison > 0)
                    parent.Right = new Node(item);
                else
                    parent.Left = new Node(item);
            }
            ++Count;
        }

        /// <summary>
        /// Remove node.
        /// </summary>
        /// <param name="item">Item of T type.</param>
        /// <returns>New Tree without node.</returns>

        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (root == null)
                return false;

            Node current = root;
            Node parent = null;
            int comparison = comparer(item, current.Value);
            while (comparison != 0)
            {
                if (comparison < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null)
                    return false;
                comparison = comparer(item, current.Value);
            }

            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    comparison = comparer(parent.Value, current.Value);
                    if (comparison > 0)
                        parent.Left = current.Left;
                    else if (comparison < 0)
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                    root = current.Right;
                else
                {
                    comparison = comparer(parent.Value, current.Value);
                    if (comparison > 0)
                        parent.Left = current.Right;
                    else if (comparison < 0)
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node leftMin = current.Right.Left;
                Node leftMinParent = current.Right;
                while (leftMin.Left != null)
                {
                    leftMinParent = leftMin;
                    leftMin = leftMin.Left;
                }

                leftMinParent.Left = leftMin.Right;

                leftMin.Left = current.Left;
                leftMin.Right = current.Right;

                if (parent == null)
                    root = leftMin;
                else
                {
                    comparison = comparer(parent.Value, current.Value);
                    if (comparison > 0)
                        parent.Left = leftMin;
                    else if (comparison < 0)
                        parent.Right = leftMin;
                }
            }
            Count--;
            return true;
        }

        /// <summary>
        /// Contains node tree.
        /// </summary>
        /// <param name="item">Item of T type.</param>
        /// <returns>Value node. If null, then node last, otherwise return true.</returns>

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            Node current = root;
            while (current != null)
            {
                var comparison = comparer(item, current.Value);
                if (comparison == 0)
                    return true;
                current = comparison > 0 ? current.Right : current.Left;
            }
            return false;
        }

        #region Tree traversal

        /// <summary>
        /// Preorder tree traversal.
        /// </summary>
        /// <returns>Value.</returns>

        public IEnumerable<T> PreOrder()
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                if (current != null)
                {
                    stack.Push(current.Right);
                    stack.Push(current.Left);
                    yield return current.Value;
                }
            }
        }

        /// <summary>
        /// Inorder tree traversal.
        /// </summary>
        /// <returns>Value.</returns>

        public IEnumerable<T> InOrder()
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;
            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                if (stack.Count == 0)
                    break;
                current = stack.Pop();
                yield return current.Value;
                current = current.Right;
            }
        }

        /// <summary>
        /// Postorder tree traversal.
        /// </summary>
        /// <returns>Value.</returns>

        public IEnumerable<T> PostOrder()
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root, parent = null;
            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                if (stack.Count == 0)
                    break;
                current = stack.Peek();
                if (current.Right != null && current.Right != parent)
                    current = current.Right;
                else
                {
                    yield return current.Value;
                    parent = current;
                    current = null;
                    stack.Pop();
                }
            }
        }

        #endregion

        /// <summary>
        /// Get enumerator.
        /// </summary>
        /// <returns>Inorder enumerator.</returns>

        public IEnumerator<T> GetEnumerator() => InOrder().GetEnumerator();

        /// <summary>
        /// Get enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region Private

        /// <summary>
        /// Initial compere.
        /// </summary>

        private void ComparerInit()
        {
            if (!typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
                throw new ArgumentException();

            comparer = (t1, t2) => ((IComparable<T>)t1).CompareTo(t2);
        }

        /// <summary>
        /// Item initial.
        /// </summary>
        /// <param name="items">Enumerable items.</param>

        private void ItemsInit(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException();

            foreach (var item in items)
            {
                Add(item);
            }
        }
       
        /// <summary>
        /// Class node tree
        /// </summary>
        private class Node
        {
            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value) : this(value, null, null) { }

            private Node(T value, Node left, Node right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        #endregion
    }
}
