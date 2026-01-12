using System;


public class Cloth{
    public int ID{get; set;}

    public Cloth(){}

    public Cloth(int id){
        ID = id;
    }
}

public class Women: Cloth{
    public int size{get; set;}

    public string materialType{get; set;}


    public void DisplayInfo(){
        Console.WriteLine($"Women Cloth ID: {ID}");
        Console.WriteLine($"Size: {size}");
        Console.WriteLine($"Material Type: {materialType}");
        Console.WriteLine($"Return Option within a Week: YES");
    }

}

public class Men: Cloth{

    public int size{get; set;}
 
    public void DisplayInfo(){
        Console.WriteLine($"MEN ID: {ID}");
        Console.WriteLine($"Size: {size}");
        Console.WriteLine($"Return Option within a Week: YES");
    }
}

public class Kids: Cloth{
    public int size{get; set;}

    public void DisplayInfo(){
        Console.WriteLine($"KID Cloth ID: {ID}");
        Console.WriteLine($"Size: {size}");
        Console.WriteLine($"Return Option: NO");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Men m = new Men();
        m.ID = int.Parse(Console.ReadLine());
        m.size = int.Parse(Console.ReadLine());

        Women w = new Women();
        w.ID = int.Parse(Console.ReadLine());
        w.size = int.Parse(Console.ReadLine());
        w.materialType = Console.ReadLine();

        Kids k = new Kids();
        k.ID = int.Parse(Console.ReadLine());
        k.size = int.Parse(Console.ReadLine());

        
        

         m.DisplayInfo();
         w.DisplayInfo();
         k.DisplayInfo();
        
    }
}
