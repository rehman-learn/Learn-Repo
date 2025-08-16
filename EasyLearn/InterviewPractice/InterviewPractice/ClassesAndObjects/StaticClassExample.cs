using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.ClassesAndObjects
{
    public static class StaticClassExample
    {
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
        public static double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }

    }
}

/*
Q1 : What is a static class in C#?
Ans: A static class in C# is a class that cannot be instantiated and can only contain static members (methods, properties, fields). 
     -> It is used to group related utility functions or constants that do not require an instance of the class to be accessed. 
     -> Static classes are useful for organizing code and providing a clear structure for utility methods.
     -> Since static classes cannot be instantiated, they help in preventing unnecessary object creation.

Q2 : How do you define a static class in C#?
Ans: To define a static class in C#, you use the `static` keyword before the class declaration. 
     For example:
     
     public static class MyStaticClass
     {
         // Static members go here
     }
     
Q3 : Can a static class be inherited in C#?
Ans: No, a static class cannot be inherited in C#. 
     -> It is sealed by default, meaning no other class can derive from it. 
     -> This ensures that the static members remain unique to the static class and cannot be overridden or extended.
 */