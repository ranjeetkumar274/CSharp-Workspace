using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<string> fruits = new List<string>(input.Split(" ").ToList());
        fruits.Sort((s1,s2) => s2.Length.CompareTo(s1.Length));

        foreach(string fruit in fruits){
        Console.Write(fruit + " ");
        }
    }
}
