using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System.");
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood","Regular", 110,90,3));
            hotelsManager.AddHotel(new Hotel("Bridgewood","Regular", 150,50,4));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220,150,5));
            string[] dates = "11Sep2020,12Sep2020".Split(",");
            DateTime[] date = new DateTime[dates.Length];
            for (int index = 0; index < date.Length;index++)
            {
                date[index] = DateTime.Parse(dates[index]);
            }
            Hotel highestRatedhotel = hotelsManager.highestRatedHotel(date);
            Console.WriteLine("Cheapest Hotel for given dates: "+ highestRatedhotel.hotelName);
        }
    }
}
