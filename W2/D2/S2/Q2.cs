using System;

public class InvalidStringException: Exception{

    public InvalidStringException(){}

    public InvalidStringException(string message):base(message){}
    public InvalidStringException(string message, Exception inner):base(message, inner){}
}

public class Program
{
    public static void Main(string[] args)
    {
        int flag = 1;
        string str = Console.ReadLine();
        int vowel = 0;

        try{
        str = str.ToLower();

        for(int i = 0; i < str.Length; i++){
            if(str[i] > 'a' && str[i] <'z'){
                if(str[i] == 'a' || str[i] == 'e' ||str[i] == 'i' ||str[i] == 'o' ||str[i] == 'u'){
                    vowel++;
                }
            }else{
                flag = 0;
            }
        }

        if(flag == 0){
            throw new InvalidStringException("Error: String must contain only alphabetic characters.");
        }else{
            Console.WriteLine("Number of vowels: "+vowel);
        }
        }
        catch(InvalidStringException ise){
            Console.WriteLine(ise.Message);
        }
    }
}
