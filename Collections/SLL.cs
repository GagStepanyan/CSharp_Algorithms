using System;
using System.Collections;
using System.Collections.Generic;

namespace Implementations.LLImplementation;

class SLL<T> : IEnumerable<Node<T>> where T : IComparable
{
    private Node<T>? head;
    public int Size { get; private set; }

    // Parameterless Constructor

    public SLL()
    {
        head = new Node<T>();
        Size = 0;
    }

    //Parametrized Constructor to Add a Range

    public SLL(IEnumerable<T> values)
    {
        if (values == null)
        {
            Console.WriteLine("Null Argument is not permited");
            return;
        }

        head = new Node<T>();
        Size = 0;

        Node<T> tmp = head;

        foreach (T value in values)
        {
            tmp.Next = new Node<T>(value);
            tmp = tmp.Next;
            ++Size;
        }
    }

    //Push Back O(N)
    public void PushBack(T val)
    {
        Node<T> tmp = head;

        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }

        tmp.Next = new Node<T>(val);
        ++Size;
    }

    //Push Front O(1)
    public void PushFront(T val)
    {
        if (head.Next == null)
        {
            head.Next = new Node<T>(val);
            ++Size;
            return;
        }

        Node<T> tmp = head.Next;
        head.Next = new Node<T>(val);
        head.Next.Next = tmp;
    }

    // Pop Front O(1)
    public void PopFront()
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List is Empty");
            return;
        }

        head.Next = head.Next.Next;
        --Size;
    }

    // Pop Back O(N)
    public void PopBack()
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List is Empty");
            return;
        }

        if (head.Next.Next == null)
        {
            head.Next = null;
            --Size;
            return;
        }

        Node<T> tmp = head;

        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }

        tmp.Next = null;
        --Size;
    }

    // Insert Method The Wost Case is O(N) 
    public void Insert(T val, int pos)
    {
        if (pos < 0 || pos >= Size)
        {
            Console.WriteLine("The Position Is Out Of Range");
            return;
        }

        if (pos == 0)
        {
            PushFront(val);
            return;
        }

        if (pos == Size - 1)
        {
            PushBack(val);
            return;
        }

        Node<T> tmp = head;

        while ((--pos) > 0)
        {
            tmp = tmp.Next;
        }

        Node<T> toStore = tmp.Next;
        tmp.Next = new Node<T>(val);
        tmp.Next.Next = toStore;
        ++Size;

    }

    // Simple Boolean O(N) search

    public bool Contains(T val)
    {
        if (head.Next == null) return false;

        Node<T> node = head.Next;

        while (node != null)
        {
            if (node.Value.CompareTo(val) == 0) return true;
            node = node.Next;
        }

        return false;
    }

    // Searching for Concrete Node O(N)
    public Node<T> Search(T val)
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List Is Empty... null returned");
            return null;
        }

        Node<T> node = head.Next;

        while (node != null)
        {
            if (node.Value.CompareTo(val) == 0) return node;
            node = node.Next;
        }

        Console.WriteLine("Was not found");
        return null;
    }

    // Erasing in position worst case O(N)
    public void Erase(int pos)
    {
        if (pos < 0 || pos >= Size)
        {
            Console.WriteLine("The Position Is Out Of Range");
            return;
        }

        if (pos == 0)
        {
            PopFront();
            return;
        }

        if (pos == Size - 1)
        {
            PopBack();
            return;
        }

        Node<T> node = head.Next;

        while ((--pos) > 0)
        {
            node = node.Next;
        }

        node.Next = node.Next.Next;
        --Size;
    }

    // Find The Middle of Linked List O(N)
    public Node<T> GetMidElement()
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List Is Empty, null returned");
            return null;
        }

        if (Size == 1)
        {
            return head.Next;
        }

        Node<T> slow = head.Next;
        Node<T> fast = (Size % 2 == 0) ? slow.Next : slow;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    // Checks if the List has a Cycle
    public bool HasCycle()
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List Is Empty");
            return false;
        }
        Node<T> slow = head.Next;
        Node<T> fast = head.Next;

        while (fast != null && fast.Next != null)
        {
            if (slow == fast) return true;

            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return false;
    }

    // Find the First Node in Cycle
    public Node<T> DetectCycle()
    {
        if (head.Next == null)
        {
            Console.WriteLine("The List is Empty... null returned");
            return null;
        }

        Node<T> slow = head.Next;
        Node<T> fast = slow;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast)
            {
                break;
            }
        }

        if (fast == null || fast.Next == null)
        {
            Console.WriteLine("The List has no Cycle... null returned");
            return null;
        }

        Node<T> node = head.Next;

        while (node != slow)
        {
            slow = slow.Next;
            node = node.Next;
        }

        return node;
    }

    // Recursive Merge O(N) or O(M)
    public Node<T> Merge(Node<T> h1, Node<T> h2)
    {
        if (h1 == null) return h2;
        if (h2 == null) return h1;

        if (h1.Value.CompareTo(h2.Value) < 0)
        {
            h1.Next = Merge(h1.Next, h2);
            return h1;
        }
        else
        {
            h2.Next = Merge(h1, h2.Next);
            return h2;
        }
    }

    // Reversing The Linked List O(N)
    public Node<T> Reverse()
    {
        if (head.Next == null)
        {
            Console.WriteLine("the List is Empty... null returned");
            return null;
        }

        if (Size == 1)
        {
            return head.Next;
        }

        Node<T> prev = null;
        Node<T> curr = head.Next;
        Node<T> next = curr.Next;

        while (next != null)
        {
            curr.Next = prev;
            prev = curr;
            curr = next;
            next = next.Next;
        }

        curr.Next = prev;

        return curr;
    }

// Enumerator to Traverse by foreach()
    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> current = head.Next;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }

IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}