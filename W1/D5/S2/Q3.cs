using System;

public class Program
    
{

     public static int Add(int a, int b){
        return a + b;
    }

    
    public static double Add(double c, double d){
        return c + d;
    }
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

      

        switch(n){
            case 1:
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());

             Console.WriteLine(Add(a,b));
             break;
            
            case 2:
             double c = double.Parse(Console.ReadLine());
             double d = double.Parse(Console.ReadLine());

             Console.WriteLine(Add(c,d));
             break;

            default:
            break;
        }
    
    }
}
