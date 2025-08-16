using GenericsAndCollectionDemo.Models;
using System;
using System.Collections.Generic;

namespace GenericsAndCollectionDemo
{
    class Program
    {
        static void Main()
        {
            // Generic Method demo
            DisplayMessage("Hello from Generics!");
            DisplayMessage(12345);

            // Collection demo: List<T>
            List<SMSNotification> smsList = new List<SMSNotification>()
            {
                new SMSNotification(),
                new SMSNotification()
            };

            foreach (var sms in smsList)
            {
                sms.Send("Hello via SMS");
            }

            // Collection demo: Dictionary<TKey, TValue>
            Dictionary<string, EmailNotification> emailDict = new Dictionary<string, EmailNotification>();
            emailDict["first"] = new EmailNotification();
            emailDict["second"] = new EmailNotification();

            foreach (var item in emailDict)
            {
                item.Value.Send($"Hello via Email - Key: {item.Key}");
            }
        }

        // Generic Method
        public static void DisplayMessage<T>(T message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }
}

/*
Q1: What are Generics in C#?
A1: Generics in C# allow you to define classes, methods, and data structures with a placeholder for the data type. This enables code reusability and type safety without sacrificing performance.

Q2: How do you define a generic method in C#?
A2: A generic method is defined by specifying a type parameter in angle brackets before the method's return type. For example:

    public static void DisplayMessage<T>(T message) 
    {
        Console.WriteLine($"Message: {message}");
    }
Q3: What are Collections in C#?
A3: Collections in C# are data structures that hold multiple items. They can be generic or non-generic and include types like List<T>, Dictionary<TKey, TValue>, HashSet<T>, etc. 
    Collections provide methods for adding, removing, and accessing items.

Q4: What is the difference between List<T> and Dictionary<TKey, TValue>?
A4: List<T> is a collection that holds items in a sequential order and allows duplicate entries. 
    -> It is indexed by an integer.
     
    
    Dictionary<TKey, TValue> is a collection that holds key-value pairs, 
    where each key is unique, and it allows fast lookups based on the key.
 */