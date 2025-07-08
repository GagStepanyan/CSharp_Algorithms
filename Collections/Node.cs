namespace Implementations.LLImplementation;
class Node<T> where T : IComparable
{
    public T? Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T? val = default(T), Node<T>? next = null)
    {
        Value = val;
        Next = next;
    }
}

class DoubleNode<T> where T : IComparable
{
    public T? Value { get; set; }
    public DoubleNode<T>? Next { get; set; }
    public DoubleNode<T>? Prev { get; set; }

    public DoubleNode(T? val = default(T), DoubleNode<T>? next = null, DoubleNode<T> prev = null)
    {
        Value = val;
        Next = next;
        Prev = prev;
    }
}