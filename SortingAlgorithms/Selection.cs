using System;

namespace SortingAlgorithms.SelectionSort;

static class SelectionSortAlgorithm<T> where T : IComparable
{
    public static void Sort(T[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        for (int i = 0; i < arr.Length - 1; ++i)
        {
            int minIndex = i;

            for (int j = i + 1; j < arr.Length; ++j)
            {
                if (arr[j].CompareTo(arr[minIndex]) < 0)
                    minIndex = j;
            }

            if (minIndex != i)
            {
                T tmp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}