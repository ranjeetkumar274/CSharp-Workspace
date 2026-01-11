using System;
using System.Security.Cryptography.X509Certificates;

public abstract class Ticket{

    public int TicketId {get; set;}

    public string TicketType {get; set;}

    public abstract (double , string) CalculatePrice();

}


public class ChildTicket : Ticket{

    public override (double, string) CalculatePrice()
    {
        return (20, "Free ice cream included");
    }
}

public class AdultTicket : Ticket{

    public override (double, string) CalculatePrice()
    {
        return (50, "Free park map included");
    }
}

public class SeniorTicket : Ticket{

    public override (double, string) CalculatePrice()
    {
        return (30, "Free wheelchair service included");
    }
}

public class TicketManager{

    public void PrintTicketPrice(Ticket ticket){
        var(price, service) = ticket.CalculatePrice();
        Console.WriteLine($"Price: {price}, Included Service: {service}");


    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int ticks = int.Parse(Console.ReadLine());

        double totalCost = 0;

        for(int i = 0; i < ticks; i++){
            string tType = Console.ReadLine();

            Ticket t = null;

            switch(tType){

                case "Child":
                 t = new ChildTicket();
                 break;

                case "Adult":
                t = new AdultTicket();
                break;

                case "Senior":
                t = new SeniorTicket();
                break;
                
                default:
                 Console.WriteLine("Invalid ticket type");
                 continue;
            }

            if(t != null){
                TicketManager tm = new TicketManager();
                tm.PrintTicketPrice(t);
                totalCost += t.CalculatePrice().Item1;
            }
        }

        Console.WriteLine($"Total cost: {totalCost}");
    }
}
