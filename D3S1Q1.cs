using System;

public class Program
{
    public static void Main(string[] args)
    {
        int a=int.Parse(Console.ReadLine());
        int b=int.Parse(Console.ReadLine());
        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        a=a*b;
        b=a/b;
        a=a/b;
        Console.WriteLine($"After swap: a = {a}, b = {b}");
    }
}
