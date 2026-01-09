using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string inp = Console.ReadLine();

        int n = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder(inp);

        switch(n){
            case 1:
            Console.WriteLine(inp.ToUpper());
            break;

            case 2:
            Console.WriteLine(inp.ToLower());
            break;

            case 3:
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
            break;

            default:
            Console.WriteLine("Invalid choice! Please enter a number between 1 and 3.");
            break;
            
        }
    }
}
