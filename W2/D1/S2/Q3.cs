using System;

public class Program
{

    public static void Create(HashSet<string> hs){
        Console.Write("Enter the string to add: ");
        string input = Console.ReadLine();

        if(hs.Add(input)){
            Console.WriteLine($"{input} added to the set.");
        }else{
            Console.WriteLine($"{input} added to the set.");
        }
    }

    public static void Read(HashSet<string> hs){
        if(hs.Count == 0){
            Console.WriteLine("No strings in the set.");
            return;
        }

        Console.WriteLine("Strings in the set:");
        foreach(var str in hs){
            Console.WriteLine(str);
        }
    }


    public static void Update(HashSet<string> hs){
        Console.Write("Enter the string to update: ");
        string old = Console.ReadLine();

        if(hs.Contains(old)){
            Console.Write("Enter the new string: ");
            string newStr = Console.ReadLine();

            if(hs.Contains(newStr)){
                Console.WriteLine("The new string already exists in the set.");
            }else{
                hs.Remove(old);
                hs.Add(newStr);
                Console.WriteLine($"'{old}' updated to '{newStr}'.");
            }
        }else{
            Console.WriteLine($"'{old}' does not exists in the set.");
        }
    }


    public static void Delete(HashSet<string> hs){
        Console.Write("Enter the string to delete: ");
        string input = Console.ReadLine();

        if(hs.Remove(input)){
            Console.WriteLine($"'{input}' has been removed.");
        }
        else{
            Console.WriteLine($"'{input}' does not exist in the set.");
        }
    }
    public static void Main(string[] args)
    {
        HashSet<string> hs = new HashSet<string>();
        bool running = true;

        while(running){

            Console.WriteLine("HashSet Operations:");
            Console.WriteLine("1. Create (Add a New String)");
            Console.WriteLine("2. Read (Display All Strings)");
            Console.WriteLine("3. Update (Update an Existing String)");
            Console.WriteLine("4. Delete (Remove a String)");
            Console.WriteLine("5. Exit)");
            Console.WriteLine("Enter your choice (1-5): ");


            switch(Console.ReadLine()){

                case "1":
                 Create(hs);
                 break;
                
                case "2":
                 Read(hs);
                 break;

                case "3":
                 Update(hs);
                 break;

                case "4":
                 Delete(hs);
                 break;

                case "5":
                 running = false;
                 break;
                
                default:
                 Console.WriteLine("Invalid option. Please try again.");
                 break;
            }
        }
    }
}
