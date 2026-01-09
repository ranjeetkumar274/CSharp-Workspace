using System;


public class Student{
    public string Name{get; set;}
    public int Age {get; set;}
    public string Grade {get; set;}

    public Student(){
        Name = "Hellen Doe";
        Age = 21;
        Grade = "A";
    }

    public Student(string name, int age, string grade){
        Name = name;
        Age = age;
        Grade = grade;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student s1 = new Student();

        Student s2 = new Student();

        s2.Name = Console.ReadLine();
        s2.Age = int.Parse(Console.ReadLine());
        s2.Grade = Console.ReadLine();

        Console.WriteLine("Default Student:");
        Console.WriteLine($"Name: {s1.Name}");
        Console.WriteLine($"Age: {s1.Age}");
        Console.WriteLine($"Grade: {s1.Grade}");
        Console.WriteLine($"New Student:");
        Console.WriteLine($"Name: {s2.Name}");
        Console.WriteLine($"Age: {s2.Age}");
        Console.WriteLine($"Grade: {s2.Grade}");

    }
}
