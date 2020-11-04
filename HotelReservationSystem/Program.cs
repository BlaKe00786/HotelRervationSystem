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
            string[] dates = "01Jan2019,11Dec2020".Split(",");
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(dates);
            Console.WriteLine("Cheapest Hotel for given dates: "+cheapestHotel.hotelName);
            Console.WriteLine("Total Rate: "+cheapestHotel.regularRates * dates.Length);
        }
    }
}
