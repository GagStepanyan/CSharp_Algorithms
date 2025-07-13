using System;
using System.Collections.Generic;

namespace SortingAlgorithms.HeapSort;

static class HeapSortAlgorithm<T> where T : IComparable
{
    private static void BuildMaxHeap(T[] arr)
    {
        for (int i = (arr.Length - 1) / 2; i >= 0; i--)
        {
            Heapify(arr, i, arr.Length);
        }
    }

    private static void Heapify(T[] arr, int index, int size)
    {
        int left = 2 * index + 1;
        int right = 2 * index + 2;
        int largest = index;

        if (left < size && arr[left].CompareTo(arr[largest]) > 0)
            largest = left;
        if (right < size && arr[right].CompareTo(arr[largest]) > 0)
            largest = right;

        if (largest != index)
        {
            (arr[largest], arr[index]) = (arr[index], arr[largest]);
            Heapify(arr, largest, size);
        }
    }

    public static void Sort(T[] arr)
    {
        BuildMaxHeap(arr);
        
        for (int i = arr.Length - 1; i >= 0; --i)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            Heapify(arr, 0, i);
        }
         
    }

}

