using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n= int.Parse(Console.ReadLine());
        Console.WriteLine($"First {n} even numbers:");
        for(int i=2;i<=n*2;i+=2){
                Console.WriteLine(i);
        }
    }
}
