using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine());
        int su=0;
        for (int i=0;i<=n;i++){
            su+=i;
        }
        Console.WriteLine($"Sum of the first {n} natural numbers: {su}");
    }
}
