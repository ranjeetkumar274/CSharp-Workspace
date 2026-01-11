using System;

interface IStudent{
    void CalcTotal();
    void CalcAvg();
    void CalcGrade();
    void PrintMarksheet();
}

public class Student:IStudent{

    private int Rno;
    private string Name;
    private int Sub1;
    private int Sub2;
    private int Sub3;
    private int Total;
    private double Average;
    private string Grade;


    public Student(int rn, string name,int sub1, int sub2, int sub3){
        Rno = rn;
        Name = name;
        Sub1 = sub1;
        Sub2 = sub2;
        Sub3 = sub3;
    }

    public void CalcTotal(){
        Total = Sub1 + Sub2 + Sub3;
    }

    public void CalcAvg(){
        Average = Total / 3.0;
    }

    public void CalcGrade(){
        if(Average >= 80){
            Grade = "A";
        }
        else if(Average >= 60){
            Grade = "B";
        }
        else if(Average >= 40){
            Grade = "C";
        }
        else if(Average < 40){
            Grade = "F";
        }
    }

    public void PrintMarksheet(){
        Console.WriteLine($"Roll No: {Rno}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Subject 1: {Sub1}");
        Console.WriteLine($"Subject 2: {Sub2}");
        Console.WriteLine($"Subject 3: {Sub3}");
        Console.WriteLine($"Total Marks: {Total}");
        Console.WriteLine($"Average Marks: {Average}");
        Console.WriteLine($"Grade: {Grade}");
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        int s1 = int.Parse(Console.ReadLine());
        int s2 = int.Parse(Console.ReadLine());
        int s3 = int.Parse(Console.ReadLine());

        IStudent std = new Student(n,name,s1,s2,s3);
        std.CalcTotal();
        std.CalcAvg();
        std.CalcGrade();
        std.PrintMarksheet();

    }
}
