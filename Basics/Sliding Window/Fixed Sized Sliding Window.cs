using System;
using System.Collections.Generic;

class Program
{
    static List<int> SlidingWindowSum(int[] arr, int k)
    {
        var result = new List<int>();
        int windowSum = 0;
        int n = arr.Length;

        if (n < k) return result;

        // Compute sum of first window
        for (int i = 0; i < k; i++)
        {
            windowSum += arr[i];
        }

        result.Add(windowSum);

        // Slide the window
        for (int i = k; i < n; i++)
        {
            windowSum += arr[i] - arr[i - k];
            result.Add(windowSum);
        }

        return result;
    }

    static void Main()
    {
        int[] arr = { 1, 3, 2, 6, -1, 4, 1, 8, 2 };
        int k = 5;

        List<int> sums = SlidingWindowSum(arr, k);
        Console.WriteLine("Window sums:");
        foreach (var sum in sums)
        {
            Console.WriteLine(sum);
        }
    }
}
