using DelegateDemo;
using System;

namespace DelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new FileProcessor();

            var logger = new Logger();
            var emailNotifier = new EmailNotifier();
            var reportGenerator = new ReportGenerator();

            // Subscribe multiple methods (Multicast Delegate)
            processor.OnFileProcessed += logger.LogToConsole; // This is a method group conversion, where the method is converted to a delegate type
            processor.OnFileProcessed += emailNotifier.SendEmail;
            processor.OnFileProcessed += reportGenerator.GenerateReport;

            // Anonymous method
            processor.OnFileProcessed += delegate (string fileName, string status) // This is an anonymous method
            {
                Console.WriteLine($"[Anonymous] Noting that {fileName} finished with {status}");
            };

            // Lambda expression
            processor.OnFileProcessed += (file, status) =>
            {
                Console.WriteLine($"[Lambda] Quick log: {file} -> {status}");
            };

            // Run file processing
            processor.ProcessFile("data.csv");
            processor.ProcessFile("report.json");

            Console.WriteLine("\nProcessing complete. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

/*
 “I defined a delegate as a callback contract, the processor publishes a success notification by invoking that delegate, and multiple independent handlers subscribe. 
  When a file is processed, the multicast delegate synchronously calls each subscriber in order—demonstrating loose coupling, extensibility, and the core mechanics behind C# events.”


Q1 : What is a delegate in C#?
A1 : A delegate in C# is a type that represents references to methods with a specific parameter list and return type. 
     It allows methods to be passed as parameters, enabling callback functionality and event handling.

Q2 : How do you define a delegate in C#?
A2 : A delegate is defined using the `delegate` keyword followed by a return type and method signature. For example:
        Eg : public delegate void MyDelegate(string message);

Q3 : What is a multicast delegate?
A3 : A multicast delegate is a delegate that can hold references to multiple methods. When invoked, it calls each method in the invocation list sequentially. 
     This is useful for event handling where multiple subscribers need to be notified of an event.

Q4 : How do you subscribe to a delegate?
A4 : You subscribe to a delegate by using the `+=` operator followed by the method you want to add. For example:    
     Eg: processor.OnFileProcessed += logger.LogToConsole;
     // This adds the `LogToConsole` method of the `logger` instance to the `OnFileProcessed` delegate.

Q5 : How do you invoke a delegate?
A5 : You invoke a delegate by calling it like a method. If the delegate has subscribers, it will call each method in its invocation list. 
     For example: `OnFileProcessed?.Invoke(fileName, status);` safely invokes the delegate if it is not null.

Q6 : What is the purpose of the `?.` operator when invoking a delegate?
A6 : The `?.` operator is the null-conditional operator. It checks if the delegate is not null before invoking it, preventing a `NullReferenceException` if there are no subscribers. 
     If `OnFileProcessed` is null, the invocation is skipped safely.

Q7 : What is an anonymous method in C#?
A7 : An anonymous method is a method without a name that can be defined inline. It allows you to define a delegate's implementation directly at the point of subscription, 
     making the code more concise. For example:
     
     Eg:
        processor.OnFileProcessed += delegate (string fileName, string status) 
        {
            Console.WriteLine($"[Anonymous] Noting that {fileName} finished with {status}");
        };

Q8 : What is a lambda expression in C#?
A8 : A lambda expression is a concise way to represent an anonymous method using the `=>` syntax. It can be used to create delegates or expressions. 
     Eg:
        processor.OnFileProcessed += (file, status) =>
        {
            Console.WriteLine($"[Lambda] Quick log: {file} -> {status}");
        };


Q9 : How can you unsubscribe from a delegate?
A9 : You can unsubscribe from a delegate using the `-=` operator followed by the method you want to remove. For example:
     Eg: processor.OnFileProcessed -= logger.LogToConsole;
        // This removes the `LogToConsole` method from the `OnFileProcessed` delegate, so it will no longer be called when the delegate is invoked.

Q10 : What are some common use cases for delegates in C#?
A10 : Common use cases for delegates in C# include:
        - Event handling: Delegates are used to define event handlers that respond to events in applications.
        - Callback methods: Delegates allow methods to be passed as parameters, enabling callbacks for asynchronous operations or processing.
        - Multicast delegates: They enable multiple methods to be called in response to a single event, allowing for flexible and extensible event handling.
        - Functional programming: Delegates can be used to implement functional programming patterns, such as passing functions as arguments or returning functions from methods.
        - LINQ queries: Delegates are used in LINQ to define predicates and selectors for filtering and transforming collections.
        - Command patterns: Delegates can be used to implement command patterns, where actions are encapsulated as objects that can be executed later.


*/