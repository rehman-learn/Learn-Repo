using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Services;
using DependencyInjectionDemo.Managers;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hi Welcome to Notification Service using Dependency Injection");
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Please Select the Notification Type");
Console.WriteLine("1. Email");
Console.WriteLine("2. SMS");

var choice = Console.ReadLine();
var services = new ServiceCollection();

switch (choice)
{
    case "1":
        Console.WriteLine("You have selected Email Notification");
        services.AddTransient<INotificationService, EmailNotificationService>();
    break;
    
    case "2":
        Console.WriteLine("You have selected SMS Notification");
        services.AddTransient<INotificationService, SmsNotificationService>();
    break;
    
    default:
        Console.WriteLine("Invalid choice. Exiting...");
        
    return;
}



services.AddTransient<NotificationManager>();
var serviceProvider = services.BuildServiceProvider();
var manager = serviceProvider.GetRequiredService<NotificationManager>();
manager.Notify();

/*

┌─────────┐       ┌───────────┐       ┌────────────-────┐        ┌───────────────────────-──┐         ┌-─────────────────────┐
│ Program │  -->  │  switch   │  -->  │  DI Container   │  -->   │  NotificationManager     │  -->    │  NotificationService │
│ (.NET6) │       │(email/sms)│       │ (registers one) │        │ (depends on INotification│         │  (email or sms)      │
└─────────┘       └───────────┘       └─────────────-───┘        └─-────────────────────────┘         └-─────────────────────┘


Q1. What is Dependency Injection in .NET?
A. Dependency Injection (DI) is a design pattern used to achieve Inversion of Control. 
   It allows us to remove hard-coded dependencies and make our code more flexible, 
   testable and maintainable by injecting required objects from the outside, instead of creating them directly.

Q2. What are the benefits of using Dependency Injection?
A. DI makes code loosely-coupled, easier to test, improves maintainability, and follows SOLID principles (especially the Dependency Inversion Principle).

Q3. What are the different types of Dependency Injection?
A. Constructor Injection (dependencies are passed via the constructor), Property Injection (dependencies are assigned via a property), and Method Injection (dependencies are passed as method parameters).

Q4. Which type of DI is most commonly used in .NET?
A. Constructor Injection is the most commonly used and the recommended pattern in .NET because it ensures dependencies are available when the object is created and makes the object immutable.

Q5. What is a Service Container?
A. A Service Container (or DI Container) is a registry that holds all the dependencies and their mappings so that it can resolve and instantiate them when needed.

Q6. What is the difference between AddTransient, AddScoped and AddSingleton?
A.
    - AddTransient creates a new instance every time it is requested.
    - AddScoped creates one instance per request (per scope).
    - AddSingleton creates one single instance for the entire lifetime of the application.

Q7. How do you register an interface and concrete implementation in .NET Core DI container?
A. services.AddTransient<INotificationService, EmailNotificationService>();

Q8. What happens if you try to resolve a service which is not registered?
A. GetService<T>() returns null, while GetRequiredService<T>() throws an exception indicating that the service is not registered.

Q9. Can we register multiple implementations of the same interface?
A. Yes. When multiple implementations are registered, you can inject IEnumerable<InterfaceName> to access all of them.

Q10. Is Dependency Injection the same as Inversion of Control?
A. No. Inversion of Control is a broader principle. Dependency Injection is one of the ways to achieve Inversion of Control.
*/

