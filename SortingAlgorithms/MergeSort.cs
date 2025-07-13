using System;
using System.Collections.Generic;

namespace SortingAlgorithms.MergeSort;

static class MergeSortAlgorithm<T> where T : IComparable
{
    
    public static void Sort(T[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        MergeSortHelper(arr, 0, arr.Length - 1);
    }

    private static void MergeSortHelper(T[] arr, int left, int right)
    {
        if (left >= right) return;
        int mid = left + (right - left) / 2;
        MergeSortHelper(arr, left, mid);
        MergeSortHelper(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    private static void Merge(T[] arr, int left, int mid, int right)
    {
        int s1 = left;
        int e1 = mid;
        int s2 = mid + 1;
        int e2 = right;

        List<T> res = new List<T>();

        while (s1 <= e1 && s2 <= e2)
        {
            if (arr[s1].CompareTo(arr[s2]) < 0)
                res.Add(arr[s1++]);
            else
                res.Add(arr[s2++]);
        }

        while (s1 <= e1)
            res.Add(arr[s1++]);

        while (s2 <= e2)
            res.Add(arr[s2++]);

        for (int i = 0; i < res.Count; i++)
            arr[left++] = res[i];
    }
}