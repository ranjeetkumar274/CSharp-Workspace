using System;


public class Car{
    public string Make{get; set;}
    public string Model{get; set;}

    public int Year {get; set;}


    public Car(string make, string model, int year){
        Make = make;
        Model = model;
        Year = year;
    }

    public void DisplayDetails(){
        Console.WriteLine("Car Details:");
        Console.WriteLine($"Make: {Make}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");

    }

    public void DisplayAge(int year){
        Console.WriteLine($"car Age: {2024-year}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
        string Make = Console.ReadLine();
        string Model = Console.ReadLine();
        int Year = int.Parse(Console.ReadLine());

        Car c = new Car(Make, Model, Year);

        c.DisplayDetails();
        c.DisplayAge(Year);
    }
}
