using System;


public class Student{
    public event Action<int> GradeChanged;
    private int grade;

    public void UpdateGrade(int newGrade){
        grade = newGrade;
        GradeChanged?.Invoke(grade);
    }
}

public class Program
{
    
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if(!int.TryParse(input, out int newGrade)){
            Console.WriteLine("Invalid grade.");
            return;
        }

        Student student = new Student();
        student.GradeChanged+=(g)=>{
            Console.WriteLine($"Grade changed to: {g}");
        };
        student.UpdateGrade(newGrade);
    }
}
