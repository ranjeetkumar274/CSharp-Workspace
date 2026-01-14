using System;
using System.ComponentModel.Design;

public class Program
{
    static Action<string> printReversedString;
    static Func<string, bool> isPalindrome;

    static void ReverseString(string str){
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        Console.WriteLine($"Reversed string: {new string(arr)}");
    }

    static bool CheckPalindrome(string str){
        string lower = str.ToLower();
        int i = 0, j = str.Length -1;
        while(i < j){
            if(lower[i] != lower[j]){
                return false;
            }
            i++;
            j--;
        }
        return true;

    }

    public static void Main(string[] args)
    {
        printReversedString = ReverseString;
        isPalindrome = CheckPalindrome;

        string operation = Console.ReadLine()?.ToLower();
        string input = Console.ReadLine();

        if(operation == "reverse"){
            printReversedString(input);
        }
        else if(operation == "palindrome"){
            bool result = isPalindrome(input);
            Console.WriteLine($"Is palindrome: {result}");
        }
        else{
            Console.WriteLine($"Invalid operation.");
        }
    }

    
}
