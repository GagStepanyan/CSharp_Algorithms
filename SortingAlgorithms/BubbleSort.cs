namespace SortingAlgorithms.BubbleSort;

static class BubbleSortAlgorithm<T> where T : IComparable
{
    public static void Sort(T[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        for (int i = 0; i < arr.Length - 1; ++i)
        {
            bool swapped = false;

            for (int j = 0; j < arr.Length - 1 - i; ++j)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }
            }

            if (!swapped) return;
        }
    }
}