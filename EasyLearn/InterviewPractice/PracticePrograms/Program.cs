using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class StringOperations
{
    // 1. REVERSE A STRING
    public static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        // Method 1: Using Array.Reverse
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);

        // Method 2: Using StringBuilder (more efficient for large strings)
        // StringBuilder sb = new StringBuilder(input.Length);
        // for (int i = input.Length - 1; i >= 0; i--)
        //     sb.Append(input[i]);
        // return sb.ToString();
    }

    // 2. CHECK IF STRING IS PALINDROME
    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;

        string cleaned = input.ToLower().Replace(" ", "");
        int left = 0, right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    // 3. COUNT CHARACTER OCCURRENCES
    public static Dictionary<char, int> CountCharacters(string input)
    {
        var charCount = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        return charCount;
    }

    // 4. REMOVE DUPLICATES FROM STRING
    public static string RemoveDuplicates(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var seen = new HashSet<char>();
        var result = new StringBuilder();

        foreach (char c in input)
        {
            if (!seen.Contains(c))
            {
                seen.Add(c);
                result.Append(c);
            }
        }

        return result.ToString();
    }

    // 5. FIND FIRST NON-REPEATING CHARACTER
    public static char FirstNonRepeatingChar(string input)
    {
        var charCount = CountCharacters(input);

        foreach (char c in input)
        {
            if (charCount[c] == 1)
                return c;
        }

        return '\0'; // Return null character if none found
    }

    // 6. CHECK IF TWO STRINGS ARE ANAGRAMS
    public static bool AreAnagrams(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;

        str1 = str1.ToLower().Replace(" ", "");
        str2 = str2.ToLower().Replace(" ", "");

        char[] chars1 = str1.ToCharArray();
        char[] chars2 = str2.ToCharArray();

        Array.Sort(chars1);
        Array.Sort(chars2);

        return new string(chars1) == new string(chars2);
    }

    // 7. FIND LONGEST SUBSTRING WITHOUT REPEATING CHARACTERS
    public static string LongestSubstringWithoutRepeating(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        var charSet = new HashSet<char>();
        int maxLength = 0;
        int start = 0;
        string result = "";

        for (int end = 0; end < input.Length; end++)
        {
            while (charSet.Contains(input[end]))
            {
                charSet.Remove(input[start]);
                start++;
            }

            charSet.Add(input[end]);

            if (end - start + 1 > maxLength)
            {
                maxLength = end - start + 1;
                result = input.Substring(start, maxLength);
            }
        }

        return result;
    }

    // 8. COMPRESS STRING (e.g., "aabcccccaaa" -> "a2b1c5a3")
    public static string CompressString(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var result = new StringBuilder();
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                count++;
            }
            else
            {
                result.Append(input[i - 1]).Append(count);
                count = 1;
            }
        }

        result.Append(input[input.Length - 1]).Append(count);

        return result.Length < input.Length ? result.ToString() : input;
    }

    // 9. FIND ALL PERMUTATIONS OF A STRING
    public static List<string> GetPermutations(string input)
    {
        var result = new List<string>();
        GetPermutationsHelper(input.ToCharArray(), 0, result);
        return result;
    }

    private static void GetPermutationsHelper(char[] chars, int index, List<string> result)
    {
        if (index == chars.Length)
        {
            result.Add(new string(chars));
            return;
        }

        for (int i = index; i < chars.Length; i++)
        {
            Swap(chars, index, i);
            GetPermutationsHelper(chars, index + 1, result);
            Swap(chars, index, i); // backtrack
        }
    }

    private static void Swap(char[] chars, int i, int j)
    {
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;
    }

    // 10. VALIDATE EMAIL FORMAT
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    // 11. CONVERT TO TITLE CASE
    public static string ToTitleCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var words = input.Split(' ');
        var result = new StringBuilder();

        foreach (string word in words)
        {
            if (word.Length > 0)
            {
                result.Append(char.ToUpper(word[0]));
                if (word.Length > 1)
                    result.Append(word.Substring(1).ToLower());
                result.Append(" ");
            }
        }

        return result.ToString().Trim();
    }

    // 12. FIND SUBSTRING INDEX (KMP Algorithm)
    public static int FindSubstring(string text, string pattern)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern))
            return -1;

        int[] lps = ComputeLPS(pattern);
        int i = 0; // index for text
        int j = 0; // index for pattern

        while (i < text.Length)
        {
            if (pattern[j] == text[i])
            {
                i++;
                j++;
            }

            if (j == pattern.Length)
            {
                return i - j;
            }
            else if (i < text.Length && pattern[j] != text[i])
            {
                if (j != 0)
                    j = lps[j - 1];
                else
                    i++;
            }
        }

        return -1;
    }

    private static int[] ComputeLPS(string pattern)
    {
        int[] lps = new int[pattern.Length];
        int len = 0;
        int i = 1;

        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                    len = lps[len - 1];
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }

        return lps;
    }

    // 13. WORD COUNT
    public static int WordCount(string input)
    {
        if (string.IsNullOrEmpty(input)) return 0;

        return input.Split(new char[] { ' ', '\t', '\n', '\r' },
                          StringSplitOptions.RemoveEmptyEntries).Length;
    }

    // 14. LONGEST COMMON SUBSEQUENCE
    public static string LongestCommonSubsequence(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // Reconstruct the LCS
        var result = new StringBuilder();
        int x = m, y = n;

        while (x > 0 && y > 0)
        {
            if (str1[x - 1] == str2[y - 1])
            {
                result.Insert(0, str1[x - 1]);
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
                x--;
            else
                y--;
        }

        return result.ToString();
    }

    // MAIN METHOD FOR TESTING
    public static void Main()
    {
        // Test all functions
        Console.WriteLine("=== STRING OPERATIONS TESTING ===\n");

        // Test 1: Reverse String
        Console.WriteLine("1. Reverse String:");
        Console.WriteLine($"Input: 'hello' -> Output: '{ReverseString("hello")}'");

        // Test 2: Palindrome Check
        Console.WriteLine("\n2. Palindrome Check:");
        Console.WriteLine($"'racecar' is palindrome: {IsPalindrome("racecar")}");
        Console.WriteLine($"'hello' is palindrome: {IsPalindrome("hello")}");

        // Test 3: Character Count
        Console.WriteLine("\n3. Character Count:");
        var charCount = CountCharacters("hello");
        foreach (var kvp in charCount)
            Console.WriteLine($"'{kvp.Key}': {kvp.Value}");

        // Test 4: Remove Duplicates
        Console.WriteLine("\n4. Remove Duplicates:");
        Console.WriteLine($"Input: 'programming' -> Output: '{RemoveDuplicates("programming")}'");

        // Test 5: First Non-Repeating Character
        Console.WriteLine("\n5. First Non-Repeating Character:");
        Console.WriteLine($"Input: 'swiss' -> Output: '{FirstNonRepeatingChar("swiss")}'");

        // Test 6: Anagrams
        Console.WriteLine("\n6. Anagram Check:");
        Console.WriteLine($"'listen' and 'silent' are anagrams: {AreAnagrams("listen", "silent")}");

        // Test 7: Longest Substring Without Repeating
        Console.WriteLine("\n7. Longest Substring Without Repeating:");
        Console.WriteLine($"Input: 'abcabcbb' -> Output: '{LongestSubstringWithoutRepeating("abcabcbb")}'");

        // Test 8: String Compression
        Console.WriteLine("\n8. String Compression:");
        Console.WriteLine($"Input: 'aabcccccaaa' -> Output: '{CompressString("aabcccccaaa")}'");

        // Test 9: Permutations
        Console.WriteLine("\n9. Permutations of 'abc':");
        var perms = GetPermutations("abc");
        Console.WriteLine(string.Join(", ", perms));

        // Test 10: Email Validation
        Console.WriteLine("\n10. Email Validation:");
        Console.WriteLine($"'test@example.com' is valid: {IsValidEmail("test@example.com")}");
        Console.WriteLine($"'invalid-email' is valid: {IsValidEmail("invalid-email")}");

        // Test 11: Title Case
        Console.WriteLine("\n11. Title Case:");
        Console.WriteLine($"Input: 'hello world' -> Output: '{ToTitleCase("hello world")}'");

        // Test 12: Substring Search
        Console.WriteLine("\n12. Substring Search:");
        Console.WriteLine($"Find 'world' in 'hello world': Index {FindSubstring("hello world", "world")}");

        // Test 13: Word Count
        Console.WriteLine("\n13. Word Count:");
        Console.WriteLine($"Words in 'Hello world from C#': {WordCount("Hello world from C#")}");

        // Test 14: Longest Common Subsequence
        Console.WriteLine("\n14. Longest Common Subsequence:");
        Console.WriteLine($"LCS of 'ABCDGH' and 'AEDFHR': '{LongestCommonSubsequence("ABCDGH", "AEDFHR")}'");
    }
}