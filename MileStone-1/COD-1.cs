using System;
using System. Collections.Generic;


// Also add DeleteEmployeeById and SortEmployees , these methods as well.

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int Salary { get; set; }

    public Employee() { }

    public Employee(int id, string name, int salary)
    {
        EmployeeId = id;
        EmployeeName = name;
        Salary = salary;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"EmployeeID:  {EmployeeId}, EmployeeName: {EmployeeName}, Salary: {Salary}");
    }
}

public class EmployeeManager
{
    public List<Employee> lst = new List<Employee>();

    public void AddEmployee(Employee emp)
    {
        lst.Add(emp);
        Console.WriteLine("Record Added Successfully.");
    }

    public void ShowAll()
    {
        if (lst.Count == 0)
        {
            Console.WriteLine("List is Empty.");
        }
        else
        {
            Console.WriteLine("\n--- All Employees ---");
            foreach (Employee emp in lst)
            {
                emp.DisplayDetails();
            }
        }
    }

    public void ShowEmployeeById(int id)
    {
        bool found = false;
        foreach (Employee item in lst)
        {
            if (item.EmployeeId == id)
            {
                item.DisplayDetails();
                found = true;
                return;
            }
        }
        if (! found)
        {
            Console.WriteLine($"Employee with ID {id} not found.");
        }
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        EmployeeManager em = new EmployeeManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===========================");
            Console.WriteLine("Employee Management System");
            Console.WriteLine("===========================");
            Console. WriteLine("1. Add Employee");
            Console.WriteLine("2. Show All Employees");
            Console. WriteLine("3. Show Employee By ID");
            Console.WriteLine("4. Exit");
            Console.WriteLine("===========================");
            Console. Write("Enter option: ");

            int n = int.Parse(Console. ReadLine());

            switch (n)
            {
                case 1:
                    Console.Write("Enter Employee ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Salary: ");
                    int salary = int. Parse(Console.ReadLine());

                    Employee e = new Employee(id, name, salary);
                    em.AddEmployee(e);
                    break;

                case 2:
                    em. ShowAll();
                    break;

                case 3:
                    Console.Write("Enter Employee ID to search: ");
                    int iid = int.Parse(Console.ReadLine());
                    em.ShowEmployeeById(iid);
                    break;

                case 4:
                    Console. WriteLine("Exiting the Program.  Goodbye!");
                    running = false;
                    break;

                default:
                    Console. WriteLine("Invalid option! Please enter 1-4.");
                    break;
            }
        }
    }
}
