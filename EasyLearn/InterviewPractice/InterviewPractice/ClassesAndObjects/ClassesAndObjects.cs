using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_Practice.ClassesAndObjects
{
    public class ClassesAndObjects
    {
        public string Name { get; set; }   // prop tab to create property
        public int Age { get; set; }
        public string City { get; set; }

        // Using 'this' keyword to refer to the instance variables
        public int phone { get; set; }

        // Constructor to initialize the properties
        public ClassesAndObjects(string name = "John Doe", int age = 30, string city = "New York", int phone = 95543432)
        {
            Name = name;
            Age = age;
            City = city; // Using 'this' to refer to the instance variable
            this.phone = phone; // Using 'this' to refer to the instance variable
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name},\nAge: {Age},\nCity: {City}, \nPhone: {phone}");
        }

    }
}

/* 

Q1 : What is a class in C#?
Ans: A class in C# is a blueprint for creating objects. It defines properties, methods, 
     and events that the objects created from the class can have. 
     it encapsulate data members and member functions. 

Q2 : What is an object in C#?
Ans: An object in C# is an instance of a class. It is created from the class blueprint and 
     can hold data and perform actions defined by the class. Objects are used to represent 
     real-world entities in a program.

Q3 : What are the different types of classes possible in C#?
Ans: In C#, there are several types of classes, including:
        1. **Static Classes**: Cannot be instantiated and can only contain static members. basically we cannot create an object of static class.
        2. **Abstract Classes**: Cannot be instantiated directly and can contain abstract methods that must be implemented by derived classes.
        3. **Sealed Classes**: Cannot be inherited from, meaning no other class can derive from it and we can create an object of sealed class.
        4. **Partial Classes**: Allow a class definition to be split across multiple files.

Q4 : What is the difference between a class and an object in C#?
Ans: A class is a blueprint or template that defines the structure and behavior of objects, while an object is an instance of a class that contains actual data and can perform actions defined by the class.
     In other words, a class is like a recipe, and an object is like a dish made from that recipe.

Q5 : Why static classes are used in C#?
Ans: Static classes in C# are used to group related methods and properties that do not require an instance of the class to be accessed. 
     They are useful for utility functions, constants, or shared data that should not change across instances. 
     Since static classes cannot be instantiated, they help in organizing code and preventing unnecessary object creation.

Q6 : What is the difference between a static class and a non-static class in C#?
Ans: A static class cannot be instantiated and can only contain static members, meaning all its members are shared across the application. 
     A non-static class can be instantiated, allowing multiple objects to be created, each with its own state and behavior. 
     Non-static classes can have instance members (non-static fields and methods) that operate on individual object data.
 */
