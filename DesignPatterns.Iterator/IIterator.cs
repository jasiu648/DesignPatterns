﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Iterator
{
    public interface IIterator
    {
        public object GetNext();
        public bool HasMore();
    }

    public interface IterableCollection<T>
    {
        public IIterator CreateIterator();
    }

    public class InOrderIterator<T> : IIterator where T : IComparable<T>
    {
        private Stack<Node<T>> stack;
        private void PushAllLeft(Node<T> node)
        {
            while(node is not null)
            {
                stack.Push(node);
                node = node.Left;
            }
        }

        public InOrderIterator (BinarySearchTree<T> binarySearchTree) 
        {
            stack = new Stack<Node<T>>();
            PushAllLeft(binarySearchTree.root);
        }
        public object GetNext()
        {
            var node = stack.Pop();
            if(node.Right is not null)
            {
                PushAllLeft(node.Right);
            }
            return node;
        }

        public bool HasMore()
        {
            return stack.Count > 0;
        }
    }

    public class PreOrderIterator : IIterator
    {
        public object GetNext()
        {
            throw new NotImplementedException();
        }

        public bool HasMore()
        {
            throw new NotImplementedException();
        }
    }
    public class PostOrderIterator : IIterator
    {
        public object GetNext()
        {
            throw new NotImplementedException();
        }

        public bool HasMore()
        {
            throw new NotImplementedException();
        }
    }

}
