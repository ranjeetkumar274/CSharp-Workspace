using System;

public class Program
{
    public static void Main()
    {
        char c=char.Parse(Console.ReadLine());

        switch(char.ToLower(c)){
            case 'a':
            case 'e':
            case'i':
            case'o':
            case 'u':
                Console.WriteLine($"The character '{c}' is a vowel.");
                break;
            default:
                Console.WriteLine($"The character '{c}' is not a vowel.");
                break;
        }
    }
}
