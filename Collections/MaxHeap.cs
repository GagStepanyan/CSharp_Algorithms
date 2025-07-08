using System;
using System.Collections.Generic;

namespace Implementations.MaxHeapImpl;

class MaxHeap<T> where T : IComparable
{
    private readonly List<T> _elements = new List<T>();

    public int Size => _elements.Count;
    public bool IsEmpty => _elements.Count == 0;

    public MaxHeap()
    {
    }
    
    public MaxHeap(IEnumerable<T> elements)
    {
        if (elements == null) 
            throw new ArgumentNullException(nameof(elements));
        
        foreach (T element in elements)
            _elements.Add(element);
        BuildMaxHeap();
    }

    public void Push(T element)
    {
        _elements.Add(element);
        HeapifyUp(_elements.Count - 1);
    }

    public T Peek()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is Empty");

        return _elements[0];
    }

    public T Pop()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is Empty");

        T max = _elements[0];
        _elements[0] = _elements[Size - 1];
        _elements.RemoveAt(Size - 1);
        Heapify(0);
       
        return max;
    }

    private void BuildMaxHeap()
    {
        for (int i = GetParentIndex(Size - 1); i >= 0; i--)
        {
            Heapify(i);
        }
    }

    private void Heapify(int index)
    {
        int left = GetLeftChildIndex(index);
        int right = GetRightChildIndex(index);
        int largest = index;

        if (left < _elements.Count && _elements[left].CompareTo(_elements[largest]) > 0)
            largest = left;
        if (right < _elements.Count && _elements[right].CompareTo(_elements[largest]) > 0)
            largest = right;

        if (largest != index)
        {
            Swap(index, largest);
            Heapify(largest);
        }
    }

    private void HeapifyUp(int index)
    {
        while (HasParent(index) && _elements[index].CompareTo(GetParent(index)) > 0)
        {
            int parentIndex = GetParentIndex(index);
            Swap(index, parentIndex);
            index = parentIndex;
           
        }
    }

    

    private void Swap(int i, int j)
    {
        (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
    }


    //helper methods

    private static int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
    private static int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
    private static int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

    private static bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;

    private T GetParent(int childIndex) => _elements[GetParentIndex(childIndex)];


}