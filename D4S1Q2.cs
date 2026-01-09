using System;

public class Program
{
    public static void Main(string[] args)
    {
        
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        for(int i = 0; i < n; i++){
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Element Frequency");

        Array.Sort(arr);

        int ele = arr[0];
        int j = 0;
        while(j < n){
               ele = arr[j];
            int count = 0;
            while( j < n && ele == arr[j]){
                count++;
                j++;
            }
            Console.WriteLine($"{ele} {count}");
         
        }
          }
}
