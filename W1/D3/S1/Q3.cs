using System;

public class Program
{
    public static void Main(string[] args)
    {
        decimal c= decimal.Parse(Console.ReadLine());
        decimal f=0;
        f=(c*9/5)+32;
        Console.WriteLine($"Temperature in Celsius: {c}");
        Console.WriteLine($"Temperature in Fahrenheit: {f}");
    }
}
