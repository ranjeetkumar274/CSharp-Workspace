using System;

public class Program
{
    public static void Main(string[] args)
    {
        int score= int.Parse(Console.ReadLine());
        if (score>=90){
            Console.WriteLine("Grade: A");
        }
        else if (score>=80 && score<90){
            Console.WriteLine("Grade: B");
        }
        else if (score >=70 && score <80){
            Console.WriteLine("Grade: C");
        }
        else if (score >=60 && score <70){
            Console.WriteLine("Grade: D");
        }
        else{
            Console.WriteLine("Grade: F");
        }
    }
}
