using System;


public class Student{

    public int Id{get; set;}
    public string Name{get; set;}
    public string Grade{get; set;}

    public Student(){}

    public Student(int id, string name, string grade){
        Id = id;
        Name = name;
        Grade = grade;
    }
}

public class StudentManager{

    public Dictionary<int,Student> Students{get; set;} = new Dictionary<int, Student>();

    public void AddStudent(Student studentt){
        if(Students.ContainsKey(studentt.Id)){

            Console.WriteLine($"Student with ID {studentt.Id} already exists in the collection.");
        }else{
            Students.Add(studentt.Id, studentt);
        }
    }


    public void DisplayStudents(){
        Console.WriteLine("Student Information:");
        foreach(var studenttt in Students.Values){
            Console.WriteLine($"ID: {studenttt.Id}, Name: {studenttt.Name}, Grade: {studenttt.Grade}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StudentManager sm = new StudentManager();

        int totStudents = int.Parse(Console.ReadLine());

        for(int i = 0; i < totStudents; i++){

            int id = int.Parse(Console.ReadLine());

            string name = Console.ReadLine();

            string grade = Console.ReadLine();

            Student std = new Student( id, name, grade);
            sm.AddStudent(std);

        }
        sm.DisplayStudents();
    }
}
