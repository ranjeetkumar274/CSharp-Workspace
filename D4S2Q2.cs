using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int n = input.Length;
        int c1 = 0;
        int c2 = 0;

        for(int i = 0; i < n; i++){
            if(Char.IsLetterOrDigit(input[i])){
                c1++;
            }else{
                c2++;
            }
        }

        Console.WriteLine($"Alphanumeric characters: {c1}");
        Console.WriteLine($"Non-alphanumeric characters: {c2}");
    }
}
