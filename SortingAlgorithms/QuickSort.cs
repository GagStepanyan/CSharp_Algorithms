using System;
using System.Collections.Generic;

namespace SortingAlgorithms.QuickSort;

static class QuickSortAlgorithm<T> where T : IComparable
{
    public static void Sort(T[] arr)
    {
        QuickSortHelper(arr, 0, arr.Length - 1);
    }

    private static void QuickSortHelper(T[] arr, int left, int right)
    {
        if (right <= left) return;
        int pivotIndex = PartitionRandomizedIndex(arr, left, right);
        QuickSortHelper(arr, left, pivotIndex - 1);
        QuickSortHelper(arr, pivotIndex + 1, right);
    }

    private static int PartitionLastIndex(T[] arr, int left, int right)
    {
        
        int i = left;
        int j = right - 1;
        T pivot = arr[right];

        while (i <= j)
        {
            while (i <= j && arr[i].CompareTo(pivot) <= 0)
                ++i;
            while (j >= i && arr[j].CompareTo(pivot) > 0)
                --j;

            if (i < j)
                Swap(arr, i, j);
        }

        Swap(arr, i, right);

        return i;
    }

    private static int PartitionFirstIndex(T[] arr, int left, int right)
    {
        int i = left + 1;
        int j = right;
        T pivot = arr[left];
        
        while (i <= j)
        {
            while (i <= j && arr[i].CompareTo(pivot) < 0) 
                ++i;
            while (j >= i && arr[j].CompareTo(pivot) >= 0)
                --j;

            if (i < j) Swap(arr, i, j);
        }

        Swap(arr, j, left);

        return j;
    }

    private static int PartitionRandomizedIndex(T[] arr, int left, int right)
    {
        Random r = new Random();
        int randomIndex = r.Next(left, right);

        Swap(arr, right, randomIndex);

        int i = left;
        int j = right - 1;
        T pivot = arr[right];

        while (i <= j)
        {
            while (i <= j && arr[i].CompareTo(pivot) <= 0)
                ++i;
            while (j >= i && arr[j].CompareTo(pivot) > 0)
                --j;
            if (i < j) Swap(arr, i, j);
        }

        Swap(arr, i, right);

        return i;
    }

    private static int PartitionMedianOfThree(T[] arr, int left, int right)
    {
        return 0;
    }

    private static void Swap(T[] arr, int i, int j)
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
