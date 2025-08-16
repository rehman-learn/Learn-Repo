using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---- Sample Data ----
            List<Department> departments = new List<Department>
            {
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Finance" }
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Salary = 50000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Mike", Salary = 60000, DepartmentId = 1 },
                new Employee { Id = 3, Name = "Sara", Salary = 45000, DepartmentId = 2 },
                new Employee { Id = 4, Name = "Anna", Salary = 55000, DepartmentId = 2 },
                new Employee { Id = 5, Name = "Paul", Salary = 70000, DepartmentId = 3 }
            };

            // ---- Basic Query ----
            var highSalaryEmployees = employees
                .Where(e => e.Salary > 50000)
                .OrderByDescending(e => e.Salary)
                .Select(e => new { e.Name, e.Salary });

            Console.WriteLine("=== Employees with Salary > 50k ===");
            foreach (var emp in highSalaryEmployees)
                Console.WriteLine($"{emp.Name} - {emp.Salary}");

            // ---- Join ----
            var empWithDept = from e in employees
                              join d in departments
                              on e.DepartmentId equals d.Id
                              select new { e.Name, Department = d.Name };

            Console.WriteLine("\n=== Employees with Department ===");
            foreach (var item in empWithDept)
                Console.WriteLine($"{item.Name} - {item.Department}");

            // ---- Left Join (GroupJoin + DefaultIfEmpty) ----
            var leftJoin = from d in departments
                           join e in employees
                           on d.Id equals e.DepartmentId into empGroup
                           from e in empGroup.DefaultIfEmpty()
                           select new { Department = d.Name, Employee = e?.Name ?? "No Employee" };

            Console.WriteLine("\n=== Left Join Example ===");
            foreach (var item in leftJoin)
                Console.WriteLine($"{item.Department} - {item.Employee}");

            // ---- Grouping ----
            var groupByDept = employees
                .GroupBy(e => e.DepartmentId)
                .Select(g => new
                {
                    DepartmentId = g.Key,
                    Count = g.Count(),
                    TotalSalary = g.Sum(x => x.Salary),
                    AvgSalary = g.Average(x => x.Salary),
                    MaxSalary = g.Max(x => x.Salary),
                    MinSalary = g.Min(x => x.Salary)
                });

            Console.WriteLine("\n=== Grouping & Aggregations ===");
            foreach (var grp in groupByDept)
                Console.WriteLine($"DeptId: {grp.DepartmentId}, Count: {grp.Count}, Total: {grp.TotalSalary}, Avg: {grp.AvgSalary}, Max: {grp.MaxSalary}, Min: {grp.MinSalary}");

            // ---- ToLookup ----
            var lookup = employees.ToLookup(e => e.DepartmentId);
            Console.WriteLine("\n=== ToLookup Example ===");
            foreach (var grp in lookup)
            {
                Console.WriteLine($"DepartmentId: {grp.Key}");
                foreach (var emp in grp)
                    Console.WriteLine($"  {emp.Name} - {emp.Salary}");
            }

            // ---- Set Operators ----
            var listA = new List<int> { 1, 2, 3, 4 };
            var listB = new List<int> { 3, 4, 5, 6 };

            Console.WriteLine("\n=== Set Operators ===");
            Console.WriteLine("Union: " + string.Join(",", listA.Union(listB)));
            Console.WriteLine("Intersect: " + string.Join(",", listA.Intersect(listB)));
            Console.WriteLine("Except: " + string.Join(",", listA.Except(listB)));
            Console.WriteLine("Distinct: " + string.Join(",", listA.Concat(listB).Distinct()));

            Console.ReadKey();
        }
    }
}

/*
Q1 : What is Linq?
A1 : LINQ (Language Integrated Query) is a feature in .NET that allows developers to write queries directly in C# or VB.NET to retrieve and manipulate data 
     from various data sources like collections, databases, XML, etc. It provides a consistent way to query data using a syntax similar to SQL.

Q2 : What are the main benefits of using Linq?
A2 : The main benefits of using LINQ include:
- Simplified syntax for querying data.
- Strongly typed queries that provide compile-time checking.
- Integration with C# language features, making it easier to read and write queries.
- Ability to work with various data sources in a consistent manner.

Q3 : What are the different types of Linq?
A3 : The different types of LINQ include:
        - LINQ to Objects: Queries against in-memory collections like arrays, lists, etc.
        - LINQ to SQL: Queries against SQL databases using a strongly typed data model.
        - LINQ to Entities: Queries against Entity Framework models.
        - LINQ to XML: Queries against XML documents.

Q4 : What is the difference between Linq and Sql?
A4 : The main differences between LINQ and SQL are:
    - LINQ is a .NET feature that allows querying data in a strongly typed manner using C# or VB.NET, 
    - while SQL is a language specifically designed for querying relational databases.

Q5 : What is the difference between Linq and Lambda?
A5 : LINQ is a query syntax that can be used with various data sources, while Lambda expressions are a way to define inline functions that can be used within LINQ queries. 
     Lambda expressions provide a concise way to write functions and are often used in LINQ methods like `Where`, `Select`, etc.

Q6 : What is the difference between Linq and Linq to Sql?
A6 : LINQ is a general querying framework in .NET, while LINQ to SQL is a specific implementation of LINQ that allows querying SQL databases using a strongly typed data model. 
     LINQ to SQL translates LINQ queries into SQL queries that can be executed against a database.

Q7 : What is the difference between Linq and Entity Framework?
A7 : - LINQ is a querying framework that can be used with various data sources, while Entity Framework (EF) is an Object-Relational Mapping (ORM) framework that provides 
       a way to interact with databases using .NET objects. 

     - Entity Framework uses LINQ to query data from the database, but it also provides additional features like change tracking, lazy loading, and migrations.

Q8 : What is the difference between Linq and Dapper?
A8 : LINQ is a querying framework that allows developers to write queries in C# or VB.NET, while Dapper is a micro ORM that provides a way to map database results to .NET objects. 
     Dapper is designed for performance and simplicity, allowing developers to execute SQL queries and map results without the overhead of a full ORM like Entity Framework.

Q9 : What is the difference between Linq and Ado.Net?
A9 : LINQ is a querying framework that allows developers to write queries in C# or VB.NET, while ADO.NET is a set of classes for accessing data from databases. 
     ADO.NET provides low-level access to databases using SQL commands and connections, while LINQ provides a higher-level, strongly typed way to query data using C# syntax. 
     LINQ can be used with ADO.NET to simplify data access and manipulation.

Q10 : What is the difference between Linq and SqlCommand?
A10 : 
      - LINQ is a querying framework that allows developers to write queries in C# or VB.NET, while SqlCommand is a class in ADO.NET used to execute SQL commands 
        against a SQL Server database. 
     
      - LINQ provides a strongly typed, object-oriented way to query data, while SqlCommand requires writing raw SQL queries. LINQ queries are translated into SQL by the .NET runtime, 
        while SqlCommand executes the SQL directly against the database.



 */