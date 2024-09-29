using DesignPatterns.Iterator;
using System;

public class Node<T> where T : IComparable<T>
{
    public T Value;
    public Node<T> Left;
    public Node<T> Right;

    public Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree<T> : IterableCollection<T> where T : IComparable<T>
{
    public Node<T> root { private set; get; }

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(T value)
    {
        root = InsertRecursively(root, value);
    }

    private Node<T> InsertRecursively(Node<T> node, T value)
    {
        if (node == null)
        {
            node = new Node<T>(value);
            return node;
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = InsertRecursively(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = InsertRecursively(node.Right, value);
        }

        return node;
    }

    public bool Search(T value)
    {
        return SearchRecursively(root, value);
    }

    private bool SearchRecursively(Node<T> node, T value)
    {
        if (node == null)
        {
            return false;
        }

        if (value.CompareTo(node.Value) == 0)
        {
            return true;
        }
        else if (value.CompareTo(node.Value) < 0)
        {
            return SearchRecursively(node.Left, value);
        }
        else
        {
            return SearchRecursively(node.Right, value);
        }
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRecursively(root);
        Console.WriteLine();
    }

    private void InOrderTraversalRecursively(Node<T> node)
    {
        if (node != null)
        {
            InOrderTraversalRecursively(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversalRecursively(node.Right);
        }
    }

    public void Delete(T value)
    {
        root = DeleteRecursively(root, value);
    }

    private Node<T> DeleteRecursively(Node<T> node, T value)
    {
        if (node == null)
        {
            return null;
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = DeleteRecursively(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = DeleteRecursively(node.Right, value);
        }
        else
        {
            // Node with one child or no child
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            node.Value = MinValue(node.Right);

            // Delete the inorder successor
            node.Right = DeleteRecursively(node.Right, node.Value);
        }

        return node;
    }

    private T MinValue(Node<T> node)
    {
        T minv = node.Value;
        while (node.Left != null)
        {
            minv = node.Left.Value;
            node = node.Left;
        }
        return minv;
    }

    public Iterator CreateIterator()
    {
        return new InOrderIterator<T>(this);
    }
}
