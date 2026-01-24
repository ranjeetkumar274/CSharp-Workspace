using System;
using System.Collections;

public class Booking{
    public int BookingId{get; set;}
    public string PassengerName{get; set;}
    public string FlightNumber{get; set;}
    public string SeatNumber{get; set;}
    public string Destination{get; set;}

    public Booking(){}

    public Booking(int id, string pname, string flightnum, string seatnum, string dest){
        BookingId = id;
        PassengerName = pname;
        FlightNumber = flightnum;
        SeatNumber = seatnum;
        Destination = dest;
    }

    public void DispplayBooking(){
        Console.WriteLine($"Booking ID: {BookingId}, Passenger Name: {PassengerName}, FlightNumber: {FlightNumber}, Seat Number: {SeatNumber}, Destination: {Destination}");
    }
}

public class BookingManager{

    public ArrayList list = new ArrayList();

    public void AddBooking(Booking b){
        foreach (Booking a in list)
        {
            if (a.BookingId == b.BookingId)
            {
                Console.WriteLine("Booking already exists.");
                return;
            }
        }

        list.Add(b);
        Console.WriteLine("Booking added successfully.");
    }

    public void UpdateBookingDestination(int id, string dest){
        foreach (Booking res in list)
        {
            if (res.BookingId == id)
            {
                res.Destination = dest;
                Console.WriteLine("Booking destination updated successfully.");
                return;
            }
        }
        Console.WriteLine("Booking is not available.");
    }

    public void DeleteBookingById(int id){
        for (int i = 0; i < list.Count; i++)
        {
            Booking res = (Booking)list[i];
            if (res.BookingId == id)
            {
                list.RemoveAt(i);
                Console.WriteLine("Booking deleted successfully.");
                return;
            }
        }
        Console.WriteLine("Booking is not available.");
    }

    public void SearchBookingById(int id){
        foreach (Booking res in list)
        {
            if (res.BookingId == id)
            {
                res.DispplayBooking();
                return;
            }
        }
        Console.WriteLine("Booking is not available.");
    }

    public void DisplayAllBookings(){
        foreach (Booking v in list)
        {
            v.DispplayBooking();
        }
    }
}

public class Program{
    public static BookingManager bm = new BookingManager();
    public static void Main(string[] args){

        while(true){
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. List All Bookings");
            Console.WriteLine("3. Update Destination");
            Console.WriteLine("4. Search Booking By Id");
            Console.WriteLine("5. Delete Booking");
            Console.WriteLine("6. Exit");
            Console.Write("Select your option: ");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 Console.Write("Booking ID: ");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Passenger Name: ");
                 string pn = Console.ReadLine();

                 Console.Write("Flight Number: ");
                 string fn = Console.ReadLine();

                 Console.Write("Seat Number: ");
                 string sn = Console.ReadLine();

                 Console.Write("Destination: ");
                 string dest = Console.ReadLine();

                 Booking b = new Booking(id,pn,fn,sn,dest);
                 bm.AddBooking(b);
                 break;
                
                case 2:
                bm.DisplayAllBookings();
                break;

                case 3:
                Console.Write("Booking ID: ");
                int idd = int.Parse(Console.ReadLine());

                Console.Write("Enter Destination: ");
                string destt = Console.ReadLine();
                bm.UpdateBookingDestination(idd,destt);
                break;

                case 4:
                Console.Write("Booking ID: ");
                int iddd = int.Parse(Console.ReadLine());
                bm.SearchBookingById(iddd);
                break;

                case 5:
                Console.Write("Booking ID: ");
                int idddd = int.Parse(Console.ReadLine());
                bm.DeleteBookingById(idddd);
                break;

                case 6:
                 Console.WriteLine("Exiting the program...");
                 return;

                default:
                Console.WriteLine("Invalid choice.");
                break;
            }
        }
    }
}
