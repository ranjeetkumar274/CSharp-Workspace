using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string inp = Console.ReadLine();

        StringBuilder sb = new StringBuilder(inp);

        int i = 0;
        int j = inp.Length-1;

        while(i < j){
            char ch = sb[i];
            sb[i] = sb[j];
            sb[j] = ch;
            i++;
            j--;
        }

        Console.WriteLine(sb.ToString());
    }
}
