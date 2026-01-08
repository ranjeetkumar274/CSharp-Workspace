C.......#

**DAY-5 Question-1
using System;


public class Person{
    private string name;
    private int age;
    private string address;

    public string Name{
        get{return name;}
        set{name = value;}
    }

    public int Age{
        get{return age;}
        set{age = value;}
    }

    public string Address{
        get{return address;}
        set{address = value;}
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        Person p = new Person();

        p.Name = Console.ReadLine();
        p.Age = int.Parse(Console.ReadLine());
        p.Address = Console.ReadLine();


        Console.WriteLine("Person's Information:");

        Console.WriteLine($"Name: {p.Name}");
        Console.WriteLine($"Age: {p.Age}");
        Console.WriteLine($"Address: {p.Address}");
        
    }
}
