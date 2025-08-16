using Oops_Practice.Abstraction;
using Oops_Practice.ClassesAndObjects;
using Oops_Practice.CovarianceContravariance;
using Oops_Practice.Encapsulation;
using Oops_Practice.ExceptionHandling;
using Oops_Practice.Inheritance;
using Oops_Practice.Inheritance.HeirarchicalInheritance;
using Oops_Practice.Inheritance.MultiLevelInheritance;
using Oops_Practice.Inheritance.Multipleinheritance;
using Oops_Practice.Inheritance.SingleInheritance;
using Oops_Practice.Polymorphism.Overloading;
using Oops_Practice.Polymorphism.Overriding;
using Oops_Practice.Utils;
using System;

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
                Console.WriteLine("5. Polymorphism - Overloading");
                Console.WriteLine("6. Polymorphism - Overriding");
                Console.WriteLine("7. Inheritance Operation");
                Console.WriteLine("8. Encapsultion Operation");
                Console.WriteLine("9. Abstraction Operation");
                Console.WriteLine("10. Covariance and Contravariance Operation");
                Console.WriteLine("11. Exception Handling");
                Console.WriteLine("12. Util Class Demo");

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
                        AbstractClassExample abstractClassExample = new MultiplicationAbs { Number1 = 5, Number2 = 5 };
                        abstractClassExample.Calculate(); // Example of using an abstract class
                        abstractClassExample.DisplayResult(); // Displaying the result of the multiplication
                        break;

                    case "5":
                        OverloadingDemo overloadingDemo = new OverloadingDemo();
                        Console.WriteLine("Enter two integers for addition:");
                        int int1 = Convert.ToInt32(Console.ReadLine());
                        int int2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Integer Addition: {overloadingDemo.Add(int1, int2)}");

                        Console.WriteLine("Enter two doubles for addition:");
                        double double1 = Convert.ToDouble(Console.ReadLine());
                        double double2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Double Addition: {overloadingDemo.Add(double1, double2)}");
                        break;

                    case "6":
                        List<OverridingDemo> notifications = new List<OverridingDemo>
                        {
                             new OverridingDemo(), // This calls the virtual method
                             new EmailNotification(), //This calls the overridden method in EmailNotification
                             
                             new SMSNotification() // This calls the overridden method in SMSNotification                       
                        };

                        foreach (var n in notifications)
                        {
                            n.Send();
                        }

                        EmailNotification email = new EmailNotification();
                        email.Send("user@test.com");
                        break;

                    case "7":
                        Console.WriteLine("Select Inheritance Type:");
                        Console.WriteLine("1. Single Inheritance");
                        Console.WriteLine("2. Multilevel Inheritance");
                        Console.WriteLine("3. Hierarchical Inheritance");
                        Console.WriteLine("4. Multiple Inheritance (Interfaces)");

                        Console.Write("Enter your choice (1-4): ");
                        string inheritanceChoice = Console.ReadLine();

                        switch (inheritanceChoice)
                        {
                            case "1":
                                Console.WriteLine("Single Inheritance Example:");
                                DerivedClassSI singleInheritanceDemo = new DerivedClassSI();
                                singleInheritanceDemo.DisplayMessage();
                                singleInheritanceDemo.DisplayDerivedMessage();
                                break;
                            case "2":
                                Console.WriteLine("Multilevel Inheritance Example:");
                                FurtherDerivedClassML furtherDerivedClassML = new FurtherDerivedClassML();
                                furtherDerivedClassML.DisplayMessage();
                                furtherDerivedClassML.DisplayDerivedMessage();
                                furtherDerivedClassML.DisplayFurtherDerivedMessage();
                                break;

                            case "3":
                                Console.WriteLine("Hierarchical Inheritance Example:");
                                DerivedClassH1 derivedClassH1 = new DerivedClassH1();
                                derivedClassH1.DisplayMessage();
                                derivedClassH1.DisplayDerivedMessage();

                                DerivedClassH2 derivedClassH2 = new DerivedClassH2();
                                derivedClassH2.DisplayMessage();
                                derivedClassH2.DisplayDerivedMessage();
                                break;

                            case "4":
                                Console.WriteLine("Multiple Inheritance Example:");
                                MultipleInheritanceDemo multipleInheritanceDemo = new MultipleInheritanceDemo();
                                multipleInheritanceDemo.MethodA();
                                multipleInheritanceDemo.MethodB();
                                break;

                            default:
                                Console.WriteLine("Invalid inheritance choice.");
                                break;

                        }
                        break;
                    case "8":
                        // Encapsulation Example
                        EncapsulationDemo encapsulationDemo = new EncapsulationDemo();
                        Console.WriteLine("Enter Amount to Deposit:");
                        int depositAmount = Convert.ToInt32(Console.ReadLine());
                        encapsulationDemo.Deposit(depositAmount); // Deposit money
                        Console.WriteLine("Account Balance: " + encapsulationDemo.GetBalance()); // Get current balance
                        break;
                    case "9":
                        Console.WriteLine("Select Payment Type");
                        Console.WriteLine("1. Credit Card");
                        Console.WriteLine("2. PayPal");

                        Console.Write("Enter choice: ");
                        string ch = Console.ReadLine();

                        Console.Write("Enter amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        AbstractionExample paymentService = null;

                        switch (ch)
                        {
                            case "1":
                                paymentService = new CreditCardPayment();
                                break;
                            case "2":
                                paymentService = new PayPalPayment();
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                return;
                        }

                        // call non-abstract method
                        paymentService.ConnectToGateway();

                        // call abstract method (runtime binding)
                        paymentService.ProcessPayment(amount);

                        break;

                    case "10":
                        // ---------- COVARIANCE ----------
                        IEnumerable<CreditCardPayments> creditPayments = new List<CreditCardPayments> //here I have a list of CreditCardPayments
                        {
                            new CreditCardPayments { Amount = 100 },
                            new CreditCardPayments { Amount = 200 }
                        };

                        // IEnumerable<out T> is covariant → derived → base
                        IEnumerable<Payment> payments = creditPayments; // Here I can assign a list of CreditCardPayments to a list of Payments

                        Console.WriteLine("Covariance:");
                        foreach (var p in payments)
                        {
                            Console.WriteLine($"Payment Amount = {p.Amount}");
                        }

                        // ---------- CONTRAVARIANCE ----------
                        IPaymentChecker<Payment> generalChecker = new GeneralPaymentChecker(); //here I have a general payment checker that checks any type of Payment

                        // IPaymentChecker<in T> is contravariant → base → derived
                        IPaymentChecker<CreditCardPayments> ccChecker = generalChecker; // Here I can assign a general payment checker to a credit card payment checker

                        Console.WriteLine("\nContravariance:");
                        ccChecker.Check(new CreditCardPayments { Amount = 500 });
                        break;
                    case "11":

                        int balance = 100;

                        try
                        {
                            Console.Write("Enter amount to withdraw: ");
                            int withdrawAmount = Convert.ToInt32(Console.ReadLine());

                            if (withdrawAmount > balance)
                            {
                                throw new InsufficientBalanceException("Withdrawal amount is greater than the available balance.");
                            }

                            balance -= withdrawAmount;
                            Console.WriteLine($"Withdrawal successful. Remaining balance = {balance}");
                        }
                        catch (InsufficientBalanceException ex)
                        {
                            Console.WriteLine($"Custom Exception Caught: {ex.Message}");
                           
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format. Please enter a valid number.");
                        }
                        finally
                        {
                            Console.WriteLine("This finally block always executes.");
                        }

                        break;

                    case "12": // <-- Add this case
                        Console.WriteLine("Util Class Demo:");
                        UtilExample utilExample = new UtilExample();
                        utilExample.RunDemo();
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