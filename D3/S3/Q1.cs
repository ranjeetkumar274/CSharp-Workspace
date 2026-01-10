using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

public class Program
{
    public static void Main(string[] args)
    {
        string input;
        do{
            Console.Write("Enter a number or q to quit");
            input=Console.ReadLine() ?? "";
            if(input =="q"){
                break;
            }
            if(int.TryParse(input, out int num) && num>=0){
                Console.WriteLine($"The factorial of {num} is {Factorial(num)}.");
            }
            else{
                Console.WriteLine("Invalid input! Please enter a non-negative integer.");
            }
        } while(true);
    }
        static int Factorial(int n)
        {
            int result = 1;
            for(int i=2;i<=n;i++)
            {
                result = result*i;
            }
            return result;
        }
}
