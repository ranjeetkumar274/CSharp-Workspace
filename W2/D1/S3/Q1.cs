using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] arr = input.Split(" ");

        List<string> list = new List<string>(arr.ToList());
        List<int> odd = new List<int>();

        foreach(var i in list){
            if(int.Parse(i) % 2 != 0){
                odd.Add(int.Parse(i));
            }
        }

        odd.Sort();

        foreach(int v in odd){
            Console.Write(v+" ");
        }
    }
}
