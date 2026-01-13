using System;
using System.Diagnostics;

public abstract class Laptop{
    public string Brand{get;set;}
    public string Model{get;set;}
    public double Price{get;set;}
    public string Processor{get;set;}
    public int RAM{get;set;}
    public int Storage{get;set;}

    public Laptop(string brand, string model, double price, string processor, int ram, int storage){
        Brand=brand;
        Model = model;
        Price=price;
        Processor=processor;
        RAM=ram;
        Storage = storage;
    }

    public abstract void DisplayDetails();

    public abstract void ApplyDiscount(double Percentage);
} 

public class GamingLaptop: Laptop{
    public string type{get;set;}
    public GamingLaptop(string brand, string model, double price, string processor, int ram, int storage):base(brand,model,price,processor,ram,storage){}
    public override void DisplayDetails()
    {
        Console.WriteLine($"Laptop Details: Brand - {Brand}, Model - {Model}, Price: ${Price}, Processor: {Processor}, RAM: {RAM} GB, Storage: {Storage} GB");
        Console.WriteLine("Type: Gaming");
    }

    public override void ApplyDiscount(double Percentage)
    {
        Price-=Price*(Percentage/100);
    }
}

public class BusinessLaptop:Laptop{
    public BusinessLaptop(string brand, string model, double price, string processor, int ram, int storage):base(brand,model,price,processor,ram,storage){}
    public override void DisplayDetails()
    {
        Console.WriteLine($"Laptop Details: Brand - {Brand}, Model - {Model}, Price: ${Price}, Processor: {Processor}, RAM: {RAM} GB, Storage: {Storage} GB");
        Console.WriteLine("Type: Business");
    }

    public override void ApplyDiscount(double Percentage)
    {
        Price-=Price*(Percentage/100);
    }

    }



public class Program
{
    public static void Main(string[] args)
    {
        string brand= Console.ReadLine();
        string model=Console.ReadLine();
        double price = double.Parse(Console.ReadLine());
        string processor=Console.ReadLine();
        int ram=int.Parse(Console.ReadLine());
        int storage= int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        Laptop laptop=null;

        if(type=="Gaming"){
            laptop = new GamingLaptop(brand, model, price, processor, ram, storage);
        }
        else if(type=="Business"){
            laptop=new BusinessLaptop(brand, model, price, processor, ram, storage);
        }
        else{
            Console.WriteLine("Invalid Laptop Type");
            return;
        }

        laptop.Brand=brand;
        laptop.Model=model;
        laptop.Price=price;
        laptop.Processor=processor;
        laptop.RAM=ram;
        laptop.Storage=storage;
        string discountInput = Console.ReadLine();
        if(!string.IsNullOrEmpty(discountInput)){
            double discount = double.Parse(discountInput);
            laptop.ApplyDiscount(discount);
        }
        laptop.DisplayDetails();
    }
}

