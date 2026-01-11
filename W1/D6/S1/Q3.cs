using System;

public abstract class Employee{
    public abstract double CalculateSalary();
}

public class FullTimeEmployee: Employee{

    public double HourlyRate{get; set;}

    public double HoursWorked{get; set;}

    public FullTimeEmployee(double hr, double hw){
        HourlyRate = hr;
        HoursWorked = hw;
    }

    public override double CalculateSalary()
    {
         return HourlyRate * HoursWorked;
    }

}

public class PartTimeEmployee: Employee{

    public double HourlyRate{get; set;}

    public double HoursWorked{get; set;}

    public PartTimeEmployee(double hr, double hw){
        HourlyRate = hr;
        HoursWorked = hw;
    }

    public override double CalculateSalary()
    {
        double dis = (HourlyRate * HoursWorked) * 0.2;
        return (HourlyRate * HoursWorked) - dis;
    }

}

public class Intern: Employee{

    public double HourlyRate{get; set;}

    public double HoursWorked{get; set;}

    public Intern(double hr, double hw){
        HourlyRate = hr;
        HoursWorked = hw;
    }

    public override double CalculateSalary()
    {
        double dis = (HourlyRate * HoursWorked) * 0.4;
        return (HourlyRate * HoursWorked) - dis;
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        if(n <= 0){
            Console.WriteLine("Please enter a valid positive integer.");
            return;
        }

        List<Employee> emps = new();
        List<string> pos = new();


        for(int i = 0; i < n; i++){

            string s = Console.ReadLine().ToLower();

            if(s == "fulltimeemployee"){
                emps.Add(new FullTimeEmployee(
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine())
                )
                );

                pos.Add("FullTimeEmployee");
            }
            else if(s == "parttimeemployee"){
                emps.Add(new PartTimeEmployee(
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine())
                ));

                pos.Add("PartTimeEmployee");
            }

            else{
                emps.Add(new Intern(
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine())
                ));

                pos.Add("Intern");
            }
            }

            Console.WriteLine("Salaries of the employees:");

            for(int i = 0; i < emps.Count; i++){
                Console.WriteLine($"Salary of Employee {i+1} ({pos[i]}): {emps[i].CalculateSalary():0.##}");
            }
        }

    }

