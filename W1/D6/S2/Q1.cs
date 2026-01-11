using System;
using System.Security.Principal;

public abstract class Property{

    public int PropertyId;
    public string Location;
    public double Area;
    public string PropertyType;

    public abstract double CalculatePropertyTax();
}

public class Apartment : Property{
    public Apartment(string pt) => PropertyType = pt;
    public override double CalculatePropertyTax() => Area * 0.01;
}


public class House : Property{
    public House(string pt) => PropertyType = pt;
    public override double CalculatePropertyTax() => Area * 0.02;
}


public class CommercialBuilding: Property{

    public CommercialBuilding(string pt) => PropertyType = pt;
    public override double CalculatePropertyTax() => Area * 0.03;
}


public class PropertyManager{

    public void PrintPropertyTax(int id, string loc, double area, string type, double tax){
        Console.WriteLine($"Property Tax for {type} (ID: {id}, Location: {loc}, Area: {area}): {tax:F2}");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        
        int n = int.Parse(Console.ReadLine());

        PropertyManager pm = new PropertyManager();

        for(int i = 0; i < n; i++){
            int id = int.Parse(Console.ReadLine());
            string loc = Console.ReadLine();
            double area = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            Property prop = type switch
            {
                "Apartment" =>  new Apartment(type),
                "House" => new House(type),
                "CommercialBuilding" => new CommercialBuilding(type),
                _=> null
            };

            if(prop == null){
                Console.WriteLine("Invalid property type.");
                continue;
            }

            prop.PropertyId = id;
            prop.Location = loc;
            prop.Area = area;

            double tax = prop.CalculatePropertyTax();
            pm.PrintPropertyTax(id, loc ,area ,type, tax);
        }
    }
}
