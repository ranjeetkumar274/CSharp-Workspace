using System;

public class Program
{
    public static void Main(string[] args)
    {
        string inp = Console.ReadLine();
        List<int> arr = ReadIntegerList(inp);

        if(arr.Count == 0 || string.IsNullOrWhiteSpace(inp)){
        Console.WriteLine("Invalid input");
        return;
        }

    List<int> Squared = SquareValues(arr);
    ManualSort(Squared);
    Console.WriteLine(string.Join(" ",Squared));
    }

    private static List<int>ReadIntegerList(string inp){
    List<int> list = new List<int>();
    if(string.IsNullOrWhiteSpace(inp)){
    return list;
    }

    string []parts = inp.Split(' ');
    foreach(string s in parts){
    int value;
    if(!int.TryParse(s, out value)){
      return new List<int>();
    }
    list.Add(value);
    }
    return list;
    }


    private static List<int>SquareValues(List<int> numbers){
      List<int> result = new List<int>();
      foreach(int num in numbers){
      result.Add(num*num);
      }
      return result;
    }


    private static void ManualSort(List<int> List){
    List.Sort();
    }
}
