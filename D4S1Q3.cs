using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] parts = input.Split(' ');

        int smallest = int.MaxValue;
        int secondSmallest = int.MaxValue;

        for(int i = 0; i < parts.Length; i++){
            int num = int.Parse(parts[i]);

            if(num < smallest){
                secondSmallest = smallest;
                smallest = num;
            }else if(num > smallest && num < secondSmallest){
                secondSmallest = num;
            }
        }

        if(secondSmallest == int.MaxValue){
            Console.WriteLine("There is no second smallest score.");
        }
        else{
            Console.WriteLine("The second smallest score is "+secondSmallest+".");
        }

    }
}
