using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.ExceptionHandling
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
            
        }
    }
}

/*

Q1 : What is an exception?
A1 : An exception is an event that occurs during the execution of a program that disrupts the normal flow of the program's instructions. 
     It can be caused by various issues such as invalid input, resource unavailability, or logical errors.

Q2 : What is the purpose of exception handling in C#?
A2 : The purpose of exception handling in C# is to provide a structured way to handle runtime errors, allowing the program to continue running or gracefully terminate without crashing. 
     It helps in maintaining the stability and reliability of the application by catching exceptions and taking appropriate actions.

Q3 : How do you create a custom exception in C#?
A3 : To create a custom exception in C#, you can derive a new class from the `Exception` class. 
     You can add constructors to pass custom messages or additional data. For example:

Q4: What is the difference between checked and unchecked exceptions in C#?
A4: In C#, checked exceptions are exceptions that are checked at compile-time, meaning the compiler requires you to handle them using try-catch blocks or declare them in the method signature. 
     Unchecked exceptions, on the other hand, are not checked at compile-time and can occur at runtime without being explicitly handled. 
     Examples of unchecked exceptions include `NullReferenceException` and `IndexOutOfRangeException`.


 */