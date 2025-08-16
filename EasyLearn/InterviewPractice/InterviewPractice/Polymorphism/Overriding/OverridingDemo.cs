using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.Polymorphism.Overriding
{
    public class OverridingDemo
    {
        public virtual void Send()
        {
            Console.WriteLine("This is a Generic Notification.");
        }
    }

    public class EmailNotification : OverridingDemo
    {
        public override void Send()
        {
            base.Send(); // Calls the base class method
            Console.WriteLine("This is an Email Notification.");
        }

        public void Send(string email)
        {
            Console.WriteLine($"Email sent to {email}");
        }

    }

    public class SMSNotification : OverridingDemo
    {
        public override void Send()
        {
            Console.WriteLine("This is an SMS Notification.");
        }
    }
}

/*
 Q1 : What is method overriding in C#?
A1 : Method overriding in C# allows a derived class to provide a specific implementation of a method that is already defined in its base class. 
      This is done by using the `override` keyword in the derived class method, which must match the signature of the base class method marked with the `virtual` keyword.

Q2 : How do you override a method in C#?
A2 : To override a method in C#, you define a method in the derived class with the same name, return type, and parameters as the base class method, and
     use the `override` keyword before the method definition. The base class method must be marked with the `virtual` or `abstract` keyword.

Q3 : What is the purpose of method overriding?
A3 : The purpose of method overriding is to allow a derived class to provide a specific implementation of a method that is more appropriate for the derived class's context. 
      This enables polymorphism, where the method that gets executed is determined at runtime based on the actual object type, not the reference type.

Q4 : Can you override a method that is not marked as virtual or abstract?
A4 : No, you cannot override a method that is not marked as `virtual` or `abstract`. 
      Only methods defined in the base class with these keywords can be overridden in derived classes.

Q5 : What is the difference between method overriding and method overloading?
A5 : Method overriding allows a derived class to provide a specific implementation of a method defined in its base class, while method overloading allows multiple methods 
     with the same name but different parameters within the same class. 
     Overriding is about changing behavior in derived classes, while overloading is about defining multiple methods with the same name but different signatures.

Q6 : Can you override a method in a sealed class?
A6 : No, you cannot override a method in a sealed class because a sealed class cannot be inherited. 
      Sealed classes are used to prevent further inheritance, and thus, no method in a sealed class can be overridden.

Q7 : What happens if you try to override a method that does not exist in the base class?
A7 : If you try to override a method that does not exist in the base class, the compiler will throw an error indicating that the method cannot be found in the base class. 
      The method signature must match an existing virtual or abstract method in the base class for overriding to be valid.

Q8 : Can you call the base class method from an overridden method?
A8 : Yes, you can call the base class method from an overridden method using the `base` keyword. 
      This allows you to execute the base class implementation before or after executing the derived class implementation, providing a way to extend the base functionality.
Example: 
        public override void Send()
            {
                base.Send(); // Calls the base class method
                Console.WriteLine("This is an Email Notification.");
            }
Q9 : What is polymorphism in the context of method overriding?
A9 : Polymorphism in the context of method overriding refers to the ability of a derived class to provide a specific implementation of a method that is defined in its base class. 
      This allows methods to be called on objects of the base class type, but the actual method that gets executed is determined by the actual object type at runtime, enabling dynamic behavior.

Q10 : Is method overriding an example of compile-time or runtime polymorphism?
A10 : Method overriding is an example of runtime polymorphism because the method that gets executed is determined at runtime based on the actual object type, not the reference type. 
      This allows for more flexible and dynamic behavior in object-oriented programming.


 */