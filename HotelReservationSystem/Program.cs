using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Rservation System.");
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", 110));
            hotelsManager.AddHotel(new Hotel("Bridgewood", 150));
            hotelsManager.AddHotel(new Hotel("Ridgewood", 220));
        }
    }
}
