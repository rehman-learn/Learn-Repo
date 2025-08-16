using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Utils
{
    // Sample Util class with static utility methods
    public static class Util
    {
        // Returns the maximum of two integers
        public static int Max(int a, int b) => a > b ? a : b;

        // Returns true if the string is a palindrome
        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var reversed = new string(input.Reverse().ToArray());
            return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        // Returns the factorial of a number
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers not allowed.");
            return n <= 1 ? 1 : n * Factorial(n - 1);
        }
    }

    public class UtilExample
    {
        public void RunDemo()
        {
            int a = 10, b = 20;
            Console.WriteLine($"Max of {a} and {b} is: {Util.Max(a, b)}");

            string word = "Level";
            Console.WriteLine($"Is '{word}' a palindrome? {Util.IsPalindrome(word)}");

            int num = 5;
            Console.WriteLine($"Factorial of {num} is: {Util.Factorial(num)}");
        }
    }
}

/*
1. What is a static class in C# and when would you use it?
Ans: A static class is a class that cannot be instantiated and can only contain static members. It is used when we want to group related utility/helper methods and data that are not tied to any specific object.

2. Can a static class implement an interface or inherit from another class?
Ans: No. A static class cannot inherit from another class or implement an interface. It implicitly inherits from System.Object.

3. Why can’t we create an instance of a static class?
Ans: Because static classes are meant to provide functionality that is not tied to any particular object. The .NET runtime prevents you from creating instances of static classes.

4. Can a static class contain non-static members? Why or why not?
Ans: No — all members of a static class must also be static. Otherwise, you would need an object to access them, which goes against the purpose of a static class.

5. What is the difference between a static and a non-static method?
Ans: A static method belongs to the class itself and is called using the class name. A non-static method belongs to an instance of the class and requires an object to be called.

6. How do you access a static method from another class?
Ans: By using the class name, for example: Math.Abs(5) or UtilityHelper.DoSomething().

7. Can a static class have constructors? If yes—what kind?
Ans: Yes — a static class can have a static constructor (but not an instance constructor).

8. When does the static constructor of a class get called?
Ans: It is called automatically by the CLR before the class is accessed for the first time (either a field or a method).

9. Can you overload a static method?
Ans: Yes — static methods can be overloaded just like instance methods as long as the parameter list is different.

10. Are static constructors inherited by derived classes?
Ans: Static classes cannot be inherited at all. For non-static classes, static constructors are not inherited — each class has its own.

11. What is the difference between a static field and a constant (const) field?
Ans: const values are compile-time constants and cannot change. A static field can be changed at runtime and can also be used with reference types.

12. Is it possible to use this keyword inside a static method? Why / why not?
Ans: No. The this keyword refers to the current object instance, and there is no instance in a static method.

13. Can a static class contain nested non-static classes?
Ans: Yes. A static class can contain a nested non-static class, and the nested class can be instantiated normally.

14. Are static members shared across all instances of a class? Explain.
Ans: Yes. A static field belongs to the class itself — so all instances of the class share the same copy of that field.

15. What happens if two threads try to modify a static field at the same time?
Ans: It can lead to race conditions and inconsistent data. Static fields need proper synchronization (for example using a lock) when accessed in multithreaded scenarios.
*/
