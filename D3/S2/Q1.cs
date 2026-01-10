using System;

public class Program
{
    public static void Main(string[] args)
    {
        int y=int.Parse(Console.ReadLine());
        if (y%4==0 && (y%100==0 && y%400==0)){
            Console.WriteLine($"{y} is a leap year.");}
        else{
            Console.WriteLine($"{y} is not a leap year.");
        }
        }
    }

