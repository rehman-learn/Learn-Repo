using System;

public class NumberOperations
{
    // N1: PRIME NUMBER CHECK
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // N2: FACTORIAL
    public static long Factorial(int number)
    {
        if (number < 0) return -1; // invalid input
        long result = 1;
        for (int i = 1; i <= number; i++)
            result *= i;
        return result;
    }

    // N3: FIBONACCI SERIES
    public static void PrintFibonacci(int terms)
    {
        int a = 0, b = 1;
        Console.Write($"{a} {b} ");
        for (int i = 2; i < terms; i++)
        {
            int c = a + b;
            Console.Write($"{c} ");
            a = b;
            b = c;
        }
        Console.WriteLine();
    }

    // N4: PALINDROME NUMBER
    public static bool IsPalindromeNumber(int number)
    {
        int original = number;
        int reverse = 0;
        while (number > 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }
        return original == reverse;
    }

    // N5: REVERSE NUMBER
    public static int ReverseNumber(int number)
    {
        int reverse = 0;
        while (number > 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }
        return reverse;
    }

    // N6: ARMSTRONG NUMBER (e.g., 153 => 1^3 + 5^3 + 3^3 = 153)
    public static bool IsArmstrong(int number)
    {
        int temp = number;
        int sum = 0;
        int digits = number.ToString().Length;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, digits);
            temp /= 10;
        }
        return sum == number;
    }

    // N7: SUM OF DIGITS
    public static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    // N8: EVEN / ODD CHECK
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // MAIN METHOD FOR TESTING
    public static void Main()
    {
        Console.WriteLine("=== NUMBER OPERATIONS TESTING ===\n");

        Console.WriteLine("1. Prime Check: Is 11 prime? " + IsPrime(11));
        Console.WriteLine("2. Factorial of 5 = " + Factorial(5));

        Console.Write("\n3. Fibonacci Series (first 8 terms): ");
        PrintFibonacci(8);

        Console.WriteLine("\n4. Palindrome Number: Is 121 palindrome? " + IsPalindromeNumber(121));
        Console.WriteLine("5. Reverse of 12345 = " + ReverseNumber(12345));

        Console.WriteLine("\n6. Armstrong Number: Is 153 Armstrong? " + IsArmstrong(153));
        Console.WriteLine("7. Sum of digits (1234) = " + SumOfDigits(1234));

        Console.WriteLine("\n8. Even / Odd: 8 is even? " + IsEven(8));
        Console.WriteLine("   Even / Odd: 7 is even? " + IsEven(7));
    }
}
