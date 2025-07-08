using System;
using System.Collections.Generic;

namespace  Implementations.MinHeapImpl;

class MinHeap<T> where T : IComparable
{
    private readonly List<T> _elements = new();

    public int Size => _elements.Count;
    public bool IsEmpty => _elements.Count == 0;

    public MinHeap()
    {
    }

    public MinHeap(IEnumerable<T> elements)
    {
        foreach (T element in elements)
            _elements.Add(element);

        BuildMinHeap();
    }

    public void Push(T element)
    {
        _elements.Add(element);
        HeapifyUp(Size - 1);
    }

    public T Peek()
    {
        return _elements[0];
    }

    public T Pop()
    {
        T min = _elements[0];
        _elements[0] = _elements[Size - 1];
        _elements.RemoveAt(Size - 1);
        Heapify(0);

        return min;
    }

    private void BuildMinHeap()
    {
        for (int i = GetParentIndex(Size - 1); i >= 0; --i)
        {
            Heapify(i);
        }
    }

    private void Heapify(int index)
    {
        int left = GetLeftChildIndex(index);
        int right = GetRightChildIndex(index);
        int smallest = index;

        if (left < Size && _elements[left].CompareTo(_elements[smallest]) < 0)
            smallest = left;
        if (right < Size && _elements[right].CompareTo(_elements[smallest]) < 0)
            smallest = right;

        if (smallest != index)
        {
            Swap(index, smallest);
            Heapify(smallest);
        }
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = GetParentIndex(index);

        while (HasParent(index) && _elements[index].CompareTo(GetParent(index)) < 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;
        }

    }

    private void Swap(int i, int j)
    {
        T tmp = _elements[i];
        _elements[i] = _elements[j];
        _elements[j] = tmp;
    }

    //Helper Methods

    private int GetLeftChildIndex(int index) => 2 * index + 1;
    private int GetRightChildIndex(int index) => 2 * index + 2;
    private int GetParentIndex(int index) => (index - 1) / 2;

    private bool HasParent(int index) => GetParentIndex(index) >= 0;

    private T GetParent(int index) => _elements[GetParentIndex(index)];
}