using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Rservation System.");
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood","Regular", 110,90));
            hotelsManager.AddHotel(new Hotel("Bridgewood","Regular", 150,50));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220,150));
            string[] dates = "10Sep2020,11Sep2020".Split(",");
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(dates);
            Console.WriteLine("Cheapest Hotel for given dates: "+cheapestHotel.hotelName);
            Console.WriteLine("Total Rate: "+cheapestHotel.weekdayRates * dates.Length);
        }
    }
}
