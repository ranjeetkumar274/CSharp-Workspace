using System;
using System. Linq;

public class SumCalculator{
    public void GetSum(int[] arr){
        int sum1 = 0;
        
        for(int i = 0; i < arr.Length; i++){
            sum1 += arr[i];
        }



        Console.WriteLine($"Sum of integers: {sum1}");
        
    }

    public void GetSum(double[] drr){

        double sum2 = 0;

        
        for(int i = 0; i < drr.Length; i++){
            sum2 += drr[i];
        }

        Console.WriteLine($"Sum of doubles: {sum2}");
    }
}
public class Program
{
    public static void Main(string[] args)
    {

        int[] arr = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

        double[] drr = Console.ReadLine()
                       .Split(' ')
                       .Select(double.Parse)
                       .ToArray();

        SumCalculator sc = new SumCalculator();

        sc.GetSum(arr);
        sc.GetSum(drr);
    }
}
