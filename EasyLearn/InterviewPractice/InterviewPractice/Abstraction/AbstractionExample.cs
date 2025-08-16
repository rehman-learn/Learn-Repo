using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Abstraction
{
    public abstract class AbstractionExample
    {
        public void ConnectToGateway()
        {
            Console.WriteLine("Connecting to Payment Gateway...");
            Thread.Sleep(1000);     // simulate connection delay
            Console.WriteLine("Connected.");
        }

        public abstract void ProcessPayment(int amount); // Abstract method to be implemented by derived classes
    }

    public class CreditCardPayment : AbstractionExample
    {
        public override void ProcessPayment(int amount)
        {
            Console.WriteLine($"Initiating credit card payment of {amount}...");
            Thread.Sleep(1500);   // simulate some processing time
            Console.WriteLine($"Credit Card payment of {amount} processed successfully!");
        }
    }

    public class PayPalPayment : AbstractionExample
    {
        public override void ProcessPayment(int amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}.");
            Thread.Sleep(1800);   // simulate some processing time
            Console.WriteLine($"Processed Paypal payment of {amount} successfully. ");
        }
    }
}

/*
 
Q1 : What is abstraction in C#?
A1 : Abstraction in C# is a fundamental concept of object-oriented programming that allows you to hide the complex implementation details of a system and expose only the necessary parts to the user. 
      It helps in reducing complexity and increasing efficiency by focusing on the essential features while ignoring the irrelevant details.
Q2 : How do you achieve abstraction in C#?
A2 : In C#, abstraction can be achieved using abstract classes and interfaces. An abstract class can contain both abstract methods (without implementation) 
     and concrete methods (with implementation), while an interface can only contain method signatures without any implementation. 
     Classes that inherit from an abstract class or implement an interface must provide implementations for the abstract methods or interface methods.

Q3 : What is the difference between an abstract class and an interface in C#?
A3 : 
Abstract Class:
    - Abstract Class Can contain both abstract methods (no implementation) and concrete methods (with implementation)
    - Supports fields, constructors, and access modifiers
    - Used when you want to provide a common base functionality that derived classes can reuse
    - A class can inherit from only one abstract class (single inheritance).
Interface:
    - An interface can only contain method signatures (no implementation) and properties, events, or indexers
    - Cannot contain fields or constructors
    - Used to define a contract that classes must adhere to, allowing for multiple inheritance (a class can implement multiple interfaces)
    - A class can implement multiple interfaces.

Q4 : Can you create an instance of an abstract class in C#?
A4 : No, you cannot create an instance of an abstract class in C#. 
      Abstract classes are meant to be inherited by other classes, and they can only be instantiated through derived classes that provide implementations for the abstract methods.

Q5 : What is the purpose of using abstraction in C#?
A5 : The purpose of using abstraction in C# is to simplify complex systems by hiding unnecessary details and exposing only the essential features. 
      It allows developers to focus on high-level functionality without getting bogged down by implementation specifics, leading to cleaner, more maintainable code.

Q6 : Can you have an abstract class with no abstract methods in C#?
A6 : Yes, you can have an abstract class with no abstract methods in C#. 
      Such a class can still provide common functionality that can be reused by derived classes, and it can also define properties or fields that derived classes can use.
 */
