using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using AsyncAwaitDemo.TaskDemo;
using AsyncAwaitDemo.AsyncAwait;
using AsyncAwaitDemo.ParallelDemo;

namespace AsyncAwaitDemo
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await EmailNotificationTask.Run();
            await SmsNotificationAsync.Run();
            MultipleNotificationsParallel.Run();
        }
    }
}

/*

Q1 : What is a Task in C#?
A1 : A Task in C# represents an asynchronous operation.It is part of the Task Parallel Library (TPL) and is used to run code asynchronously, 
      allowing for non-blocking operations. Tasks can be awaited, which means the calling code can continue executing while the task runs in the background.

Q2 : How do you create a Task in C#?
A2 : You can create a Task using the Task.Run method, which takes an action or function to execute asynchronously. 
        For example: `Task myTask = Task.Run(() => {  code  })

Q3 : What is the difference between Task and Thread in C#?
A3 : 
    Thread : 
             - A Thread is a lower-level construct that represents a single thread of execution in the operating system.
             - Threads are managed by the operating system and can be more resource-intensive.
    Task :
             - A Task is a higher-level abstraction that represents an asynchronous operation.
             - Tasks are managed by the Task Parallel Library (TPL) and can be more efficient in terms of resource usage.
             - Tasks can be awaited, allowing for easier handling of asynchronous code.

Q4 : How do you handle exceptions in a Task?
A4 : You can handle exceptions in a Task by using a try-catch block within the Task's action or function. 
        If the Task is awaited, any exceptions thrown will be captured and can be handled in the calling code. 
        For example:
        ```csharp
        try
        {
            await myTask;
        }
        catch (Exception ex)
        {
            // Handle exception
        }
        ```

Q5 : What is the purpose of the async and await keywords in C#?
A5 : The `async` keyword is used to define a method as asynchronous, allowing it to contain `await` expressions. 
        The `await` keyword is used to pause the execution of the method until the awaited Task completes, allowing for non-blocking operations. 
        This enables writing asynchronous code that is easier to read and maintain.

Q6 : What is the difference between Task.Run and Task.Factory.StartNew?
A6 : 
    Task.Run :
             - Task.Run is a simpler and more straightforward way to create and start a Task. 
             - It is typically used for CPU-bound operations and automatically uses the default TaskScheduler.
    Task.Factory.StartNew :
             - Task.Factory.StartNew provides more options for configuring the Task, such as specifying the TaskScheduler, 
               cancellation token, and task creation options.
             - It is more flexible but also more complex to use compared to Task.Run.

Q7. What does the async keyword do?
A7: It marks a method as asynchronous and allows the use of await inside that method. It also changes the return type to Task, Task<T> or void.

Q8. What does the await keyword do?
A8: It tells the compiler to pause the execution of the method until the awaited Task is complete without blocking the thread.
 
Q9. Can we have an async method without await inside?
A9: Yes, but it will run synchronously and the compiler will give a warning. It defeats the purpose of using async.

Q10. What is Task.Run() and when to use it?
A10: Task.Run() moves CPU-bound work to a background thread. It is often used when we want to prevent blocking the UI or main thread.

Q11. What is the return type of an async method?
A11:
    - Task → if nothing is returned
    - Task<T> → if a result is returned
    - void → only for event handlers

Q12. What is Parallel.ForEach() and how does it work?
A12: It splits a collection into multiple chunks and processes them on different threads from the thread pool concurrently.

Q13. When should you use Parallel.ForEach()?
A13: When you want to execute independent operations on multiple items and you want to use multiple cores to speed it up. 


 */