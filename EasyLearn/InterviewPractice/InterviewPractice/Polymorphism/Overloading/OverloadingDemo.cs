using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Polymorphism.Overloading
{
    public class OverloadingDemo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

    }
}

/*

Q1 : What is Overloading in C#?
A1 : Overloading in C# allows you to define multiple methods with the same name but different parameters (type, number, or order). 
     This enables you to perform similar operations on different types of data without changing the method name.

Q2 : How does method overloading differ from method overriding?
A2 : Method overloading allows you to define multiple methods with the same name but different signatures within the same class. 
     Method overriding, on the other hand, allows a derived class to provide a specific implementation of a method that is already defined in its base class.

Q3 : Can you overload a method based on return type alone?
A3 : No, you cannot overload a method based solely on its return type. The method signatures must differ in the number or type of parameters.

Q4 : Can you overload constructors in C#?
A4 : Yes, you can overload constructors in C#. You can define multiple constructors with different parameter lists to initialize an object in different ways.

Q5 : What is the purpose of method overloading?
A5 : The purpose of method overloading is to enhance code readability and reusability by allowing the same method name to be used for different operations, depending on the input parameters. 
     This reduces the need for multiple method names and makes the code cleaner and easier to maintain.

Q6 : Can you overload methods in different classes?
A6 : Yes, you can overload methods in different classes. Each class can have its own set of overloaded methods with the same name, as long as their signatures differ. 
     This is a common practice in object-oriented programming to provide similar functionality across different classes.

Q7 : What happens if you try to overload a method with the same signature?
A7 : If you try to overload a method with the same signature (same name and same parameter types), the compiler will throw an error indicating that the method is already defined. 
     Each overloaded method must have a unique signature to avoid ambiguity.

Q8 : Can you overload methods with optional parameters?
A8 : Yes, you can overload methods with optional parameters. Optional parameters allow you to define a method with default values for some parameters, enabling you to call the method with fewer arguments than defined. 
     This can be combined with method overloading to provide multiple ways to call the same method.
    
    Example: 
    public class OverloadingDemo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public int Add(int a, int b, int c = 0) // Optional parameter
        {
            return a + b + c;
        }
    }

Q10 : Overloading is Runtime Polymorphism or Compile Time Polymorphism?
A10 : Overloading is considered Compile Time Polymorphism because the method to be called is determined at compile time based on the method signature. 
      The compiler resolves which method to invoke based on the number and type of arguments passed during the method call.
*/