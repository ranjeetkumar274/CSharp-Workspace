using System;

public class Employee{
    public string Name{get; set;}
    
}

public class Intern: Employee{
    public string Department{get; set;}
    public int Iperiod{get; set;}

    public bool ValidToHire(){
        if(Iperiod >= 6) return true;
        return false;
    }
}

public class Manager: Employee{
    public string Department{get; set;}
    public double Salary{get; set;}

    public bool ValidForBonus(){
        if(Salary < 80000.00){
            return true;
        }
        return false;
    }
}

public class Tester{
    static void Main(String[] args){
        Console.WriteLine("Employee Type('I' for Intern and 'M' for Manager): ");
        string empTypeInput = Console.ReadLine();
        char empType = empTypeInput[0];  
        
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        if(empType == 'I' || empType == 'i'){
            Console.WriteLine("department: ");
            string dept = Console.ReadLine();
           

            Console.WriteLine("Internship Period: ");
            string periodInput = Console.ReadLine();
           
            int intPeriod = int.Parse(periodInput);
            
            Intern intern = new Intern{
                Name = name,
                Department = dept,
                Iperiod = intPeriod
            };
            
            // Display Intern details
            Console.WriteLine("\n--- Intern Details ---");
            Console.WriteLine($"Name: {intern.Name}");
            Console.WriteLine($"Department: {intern.Department}");
            Console.WriteLine($"Internship Period: {intern.Iperiod} months");
            Console. WriteLine($"Valid to Hire:  {intern.ValidToHire()}");
        }
        else if(empType == 'M' || empType == 'm'){
            Console.WriteLine("department: ");
            string deptt = Console.ReadLine();
           

            Console.WriteLine("Salary: ");
            string salaryInput = Console.ReadLine();
           
            double salary = double.Parse(salaryInput);
            
            // Create Manager object
            Manager manager = new Manager{
                Name = name,
                Department = deptt,
                Salary = salary
            };
            
            // Display Manager details
            Console.WriteLine("\n--- Manager Details ---");
            Console.WriteLine($"Name: {manager.Name}");
            Console.WriteLine($"Department: {manager.Department}");
            Console.WriteLine($"Salary: {manager.Salary}");
            Console.WriteLine($"Valid for Bonus: {manager. ValidForBonus()}");
        }
        else{
            Console.WriteLine("Error: Invalid employee type!  Please enter 'I' or 'M'.");
        }
    }
}
