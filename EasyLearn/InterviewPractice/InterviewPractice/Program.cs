using System;
using Oops_Practice.ClassesAndObjects;

namespace InterviewPractice
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Select an Operation");
                Console.WriteLine("1. Classes and Objects");
                Console.WriteLine("2. Static Class Operation");
                Console.WriteLine("3. Sealed Class Operation");
                Console.WriteLine("4. Abstract Class Operation");

                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice?");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                bool validChoice = true;
                switch (choice)
                {
                    case "1":
                        ClassesAndObjects classesAndObjects = new ClassesAndObjects();
                        classesAndObjects.DisplayDetails();
                        break;
                    
                    case "2":
                        Console.WriteLine("Enter two numbers for arithmetic operations:");
                        Console.Write("Enter first number: ");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        int num2 = Convert.ToInt32(Console.ReadLine());

                        //StaticClassExample staticClassExample = new StaticClassExample(); //You can't create an instance of a static class 
                        Console.WriteLine($"Addition: {StaticClassExample.Add(num1, num2)}"); // you can directly call static methods without creating an instance
                        Console.WriteLine($"Subtraction: {StaticClassExample.Subtract(num1, num2)}");
                        Console.WriteLine($"Multiplication: {StaticClassExample.Multiply(num1, num2)}");
                        Console.WriteLine($"Division: {StaticClassExample.Divide(num1, num2)}"); 
                        break;

                    case "3":
                        // Sealed class example
                        SealedClassExample sealedClassExample = new SealedClassExample(); // we can create an object of sealed class but cannot inherit it
                        break;

                    case "4":
                        AbstractClassExample abstractClassExample = new MultiplicationAbs {Number1 = 5, Number2 = 5 };
                        abstractClassExample.Calculate(); // Example of using an abstract class
                        abstractClassExample.DisplayResult(); // Displaying the result of the multiplication
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        validChoice = false;
                        break;
                }

                if (validChoice)
                {
                    Console.WriteLine("Do you want to perform another operation?");
                    string again = Console.ReadLine();
                    if (!again.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Exiting the program.");
                        break;
                    }
                    Console.Clear();
                }
            }
           
        }
    }
}