using System;
using System.Collections.Generic;

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

    public Dictionary<int,Booking> bookings {get; set;}

    public BookingManager(){
        bookings = new Dictionary<int, Booking>();
    }


    public void AddBooking(Booking b){
        if(bookings.ContainsKey(b.BookingId)){
            Console.WriteLine($"Booing with Id {b.BookingId} is already exists.");
            return;
        }

        bookings.Add(b.BookingId,b);
        Console.WriteLine("Booking Added Succesfully.");
    }

    public void UpdateBookingDestination(int id, string dest){
        if(!bookings.ContainsKey(id)){
            Console.WriteLine("Booking is not available.");
            return;
        }

        Booking b = bookings[id];
        b.Destination = dest;
        Console.WriteLine("Booking Destination Updated Successfully.");
    }


    public void DeleteBookingById(int id){
        if(!bookings.ContainsKey(id)){
            Console.WriteLine("Booking is not available.");
            return;
        }
        bookings.Remove(id);
        Console.WriteLine("Booking Destination Updated Successfully.");
    }

    public void SearchBookingById(int id){
        
        Booking b = bookings[id];
        b.DispplayBooking();
    }



    public void DisplayAllBookings(){
        foreach(var v in bookings.Values){
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
            Console.WriteLine("2. List All Bookingss");
            Console.WriteLine("3. Update Destination");
            Console.WriteLine("4. Search Booking By Id");
            Console.WriteLine("5. Exit");
            Console.Write("Select your option: ");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                 Console.Write("Booking ID:");
                 int id = int.Parse(Console.ReadLine());

                 Console.Write("Passenger Name:");
                 string pn = Console.ReadLine();

                 Console.Write("Flight Number:");
                 string fn = Console.ReadLine();

                 Console.Write("Seat Number:");
                 string sn = Console.ReadLine();

                 Console.Write("Price:");
                 string dest = Console.ReadLine();

                 Booking b = new Booking(id,pn,fn,sn,dest);
                 bm.AddBooking(b);
                 break;
                
                case 2:
                bm.DisplayAllBookings();
                break;

                case 3:
                Console.Write("Booking ID:");
                int idd = int.Parse(Console.ReadLine());

                Console.Write("Enter Destination: ");
                string destt = Console.ReadLine();
                bm.UpdateBookingDestination(idd,destt);
                break;

                case 4:
                Console.Write("Booking ID:");
                int iddd = int.Parse(Console.ReadLine());
                bm.SearchBookingById(iddd);
                break;

                 case 5:
                 Console.WriteLine("Exiting the program...");
                 return;

                 default:
                 Console.WriteLine("Invalid choice.");
                 break;
            }
        }
    }
}
