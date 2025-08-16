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
