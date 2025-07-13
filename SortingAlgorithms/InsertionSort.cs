using System;
using System.Collections.Generic;

namespace SortingAlgorithms.InsertionSort;

static class InsertionSortAlgorithm<T> where T : IComparable
{
    public static void Sort(T[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        for (int i = 1; i < arr.Length; ++i)
        {
            int j = i - 1;
            T key = arr[i];

            while (j >= 0 && arr[j].CompareTo(key) > 0)
            {
                arr[j + 1] = arr[j];
                --j;
            }
            arr[j + 1] = key;
        }
    }
}
