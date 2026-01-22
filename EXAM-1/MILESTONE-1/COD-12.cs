using System;
using System.Collections.Generic;
using System.Linq;


public class Actor{
    public int ActorId{get; set;}
    public string Name{get; set;}
    public int Age{get; set;}
    public string Nationality {get; set;}

    public Actor(){}

    public Actor(int id, string n, int a, string na){
        ActorId = id;
        Name = n;
        Age = a;
        Nationality = na;
    }

    public void DisplayActorDetails(){
        Console.WriteLine($"Actor ID: {ActorId}, Name: {Name}, Age: {Age}, Nationality: {Nationality}");
    }
}

public class ActorManager{
    public HashSet<Actor> actors = new HashSet<Actor>();

    public void AddActor(HashSet<Actor> hs,Actor ac){
        var res = hs.FirstOrDefault(a => a.ActorId == ac.ActorId);
        if(res != null){
            Console.WriteLine("This Actor is Already Exists.");
            return;
        }
        hs.Add(ac);
        Console.WriteLine("Actor Added successfully.");
    }

    public void ShowActors(HashSet<Actor> hs){
        if(hs.Count == 0){
            Console.WriteLine("The List is empty.");
            return;
        }

        foreach(var a in hs){
            a.DisplayActorDetails();
        }
    }

    public void SearchActorById(HashSet<Actor> hs, int id){
        var res = hs.FirstOrDefault(x => x.ActorId == id);
        if(res == null){
            Console.WriteLine("Actor not found.");
            return;
        }
        res.DisplayActorDetails();
    }

    public void DeleteActorById(HashSet<Actor> hs, int id){
        var res = hs.FirstOrDefault(x => x.ActorId == id);
        if(res == null){
            Console.WriteLine("Actor not found.");
            return;
        }
        hs.Remove(res);
        Console.WriteLine("Deleted Successfully.");

    }
}

public class Program{

    public static ActorManager am = new ActorManager();
    public static void Main(string[] args){

        while(true){
            Console.WriteLine("1. Add Actor");
            Console.WriteLine("2. Show All Actors");
            Console.WriteLine("3. Search Actor");
            Console.WriteLine("4. Delete Actor");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 Console.Write("Enter ActorID: ");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Actor Name: ");
                 string name = Console.ReadLine();

                 Console.Write("Enter Actor Age: ");
                 int age = int.Parse(Console.ReadLine());

                 Console.Write("Actor Nationality: ");
                 string na = Console.ReadLine();

                 Actor a = new Actor(id,name,age,na);
                 am.AddActor(am.actors,a);
                 break;

                case 2:
                 am.ShowActors(am.actors);
                 break;

                case 3:
                 Console.Write("Enter ActorID: ");
                 int idd = int.Parse(Console.ReadLine());

                 am.SearchActorById(am.actors,idd);
                 break;

                case 4:
                 Console.Write("Enter ActorID: ");
                 int iddd = int.Parse(Console.ReadLine());

                 am.DeleteActorById(am.actors,iddd);
                 break;
                 break;

                case 5:
                 Console.WriteLine("Exiting...");
                 return;
                 break;

                default:
                 Console.WriteLine("Invalid choice");
                 return;
            }
        }
    }
}
