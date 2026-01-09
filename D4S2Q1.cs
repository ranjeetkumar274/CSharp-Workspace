using System;

public class Program
{
    public static void Main(string[] args)
    {
       int num = int.Parse(Console.ReadLine());

       string[] words = new string[num];
       string[] wordsGroup = new string[num];


       string newWord1, newWord2;

       for(int i = 0; i < num; i++){
        words[i] = Console.ReadLine();
       }

       for(int i = 0; i < num; i++){
        if(words[i] != ""){
            Console.Write("Group: ");
            Console.Write(words[i]);


            char[] word1 = words[i].ToLower().ToCharArray();
            Array.Sort(word1);

            newWord1 = new String(word1);


            for(int j = i+1; j < num; j++){
                if(words[j] != ""){
                    char[] word2 = words[j].ToLower().ToCharArray();

                    Array.Sort(word2);

                    newWord2 = new string(word2);

                    if(newWord1 == newWord2){
                        Console.Write(", "+words[j]);
                        words[j]="";
                    }
                }
            }
            Console.WriteLine();
        }
       }
    }
}
