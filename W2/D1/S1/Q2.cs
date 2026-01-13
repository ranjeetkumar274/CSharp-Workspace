using System;
using System.Collections;


public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine().ToLower();
        ArrayList lst = new ArrayList();


        while(input != "exit"){
            int flag = 0;
            switch(input){
                case "add":
                 try{
                    int NumInp = int.Parse(Console.ReadLine());
                    lst.Add(NumInp);
                    Console.WriteLine(NumInp+" added to the number list.");
                 }
                 catch{
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                 }
                 break;

                case "remove":
                 int RemoveNum = int.Parse(Console.ReadLine());
                 if(!lst.Contains(RemoveNum)){
                 Console.WriteLine(RemoveNum+" not found in the number list.");
                 }else{
                    lst.Remove(RemoveNum);
                    Console.WriteLine(RemoveNum+" removed from the number list.");
                 }
                 break;
                
                case "display":
                 Console.WriteLine("Current numbers in the list:");
                   foreach(var num in lst){
                    Console.WriteLine(num);
                   }
                 break;

                case "exit":
                 input = "exit";
                 break;
                
                default:
                 flag = 1;
                 Console.WriteLine("Invalid command");
                 break;
            }
             if(flag == 1){
                break;
             }else{
                input = Console.ReadLine().ToLower();
             }
        }
    }
}
