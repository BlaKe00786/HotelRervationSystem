using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System.");
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Reward", 110,90,3,80,80));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Reward", 150,50,4,110,50));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Reward", 220,150,5,100,40));
            string[] dates = "11Sep2020,12Sep2020".Split(",");
            DateTime[] date = new DateTime[dates.Length];
            for (int index = 0; index < date.Length;index++)
            {
                date[index] = DateTime.Parse(dates[index]);
            }
            Hotel highestRatedhotel = hotelsManager.GivenWeekendAndWeekdayRateReturnBestRatedHotelForRewardCustomerWithRegexValidation(dates);
            Console.WriteLine("The Cheapest Hotel for given dates with regex validation: " + highestRatedhotel.hotelName);
        }
    }
}
