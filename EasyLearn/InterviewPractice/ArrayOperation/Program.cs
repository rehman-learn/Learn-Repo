using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayOperations
{
    // A1: Largest element in array
    public static int FindLargest(int[] arr)
    {
        return arr.Max();
    }

    // A2: Smallest element in array
    public static int FindSmallest(int[] arr)
    {
        return arr.Min();
    }

    // A3: Sort array (ascending)
    public static int[] SortAscending(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        return sorted;
    }

    // A3: Sort array (descending)
    public static int[] SortDescending(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        Array.Reverse(sorted);
        return sorted;
    }

    // A4: Reverse array
    public static int[] ReverseArray(int[] arr)
    {
        int[] reversed = (int[])arr.Clone();
        Array.Reverse(reversed);
        return reversed;
    }

    // A5: Sum of array elements
    public static int Sum(int[] arr)
    {
        int total = 0;
        foreach (var num in arr) total += num;
        return total;
    }

    // A6: Average of array
    public static double Average(int[] arr)
    {
        return arr.Average();
    }

    // A7: Find duplicate elements
    public static List<int> FindDuplicates(int[] arr)
    {
        return arr.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(g => g.Key)
                  .ToList();
    }

    // A8: Search an element
    public static bool Search(int[] arr, int value)
    {
        return arr.Contains(value);
    }

    // MAIN METHOD FOR TESTING
    public static void Main()
    {
        int[] numbers = { 5, 1, 9, 5, 3, 7, 3 };

        Console.WriteLine("=== ARRAY OPERATIONS TESTING ===\n");

        Console.WriteLine("The Initial Array Contents are: " + string.Join(", ", numbers));

        Console.WriteLine("\n1. Largest element = " + FindLargest(numbers));
        Console.WriteLine("\n2. Smallest element = " + FindSmallest(numbers));

        Console.WriteLine("\n3. Sorted Ascending:  " + string.Join(", ", SortAscending(numbers)));
        Console.WriteLine("   Sorted Descending: " + string.Join(", ", SortDescending(numbers)));

        Console.WriteLine("\n4. Reversed Array: " + string.Join(", ", ReverseArray(numbers)));

        Console.WriteLine("\n5. Sum of elements = " + Sum(numbers));
        Console.WriteLine("\n6. Average of elements = " + Average(numbers));

        Console.WriteLine("\n7. Duplicate elements: " + string.Join(", ", FindDuplicates(numbers)));

        Console.WriteLine("\n8. Search for value 7 => " + Search(numbers, 7));
        Console.WriteLine(" Search for value 10 => " + Search(numbers, 10));
    }
}
