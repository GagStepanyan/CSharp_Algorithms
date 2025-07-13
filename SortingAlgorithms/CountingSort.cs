namespace SortingAlgorithms.CountingSort;

static class CountingSortAlgorithm
{
    public static void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        int max = arr.Max();
        int min = arr.Min();

        int range = max - min + 1;

        int[] counts = new int[range];

        foreach (int num in arr)
            ++counts[num - min];

        for (int i = 1; i < range; ++i)
            counts[i] += counts[i - 1];

        int[] result = new int[arr.Length];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int num = arr[i];
            result[--counts[num - min]] = num;
        }

        Array.Copy(result, arr, arr.Length);

        return;
    }

}
