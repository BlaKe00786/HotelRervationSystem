using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelsManager
    {
        public List<Hotel> hotelsList;
        public HotelsManager()
        {
            hotelsList = new List<Hotel>();
        }
        public void AddHotel(Hotel hotel)
        {
            hotelsList.Add(hotel);
        }
        public Hotel FindCheapestHotel(string[] dates)
        {
            DateTime[] validatedDates =getDates(dates);
            hotelsList.Sort((hotel1, hotel2) => hotel1.weekdayRates.CompareTo(hotel2.weekdayRates));
            return hotelsList[0];
        }
        public Hotel FindCheapestHotel(DateTime[] dates)
        {
            int totalPrice = 0;
            int weekendCount = 0;
            int weekdayCount = 0;
            int minimumRate = 99999;
            List<Hotel> cheapestHotel = new List<Hotel>();
            foreach (var date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekendCount++;
                }
                else
                {
                    weekdayCount++;
                }
            }
            foreach (var hotel in hotelsList)
            {
                totalPrice = hotel.weekdayRates * weekdayCount + hotel.weekendRates * weekendCount;
                if (totalPrice <= minimumRate)
                {
                    minimumRate = totalPrice;
                    cheapestHotel.Add(hotel);
                }
            }
            Console.WriteLine("Total Rate: " + minimumRate);
            List<Hotel> sortedCheapestHotelsAsPerRating = cheapestHotel.OrderByDescending(x => x.hotelRating).ToList();
            Console.WriteLine("Rating: " + sortedCheapestHotelsAsPerRating[0].hotelRating);
            return sortedCheapestHotelsAsPerRating[0];
        }
        public DateTime[] getDates(string[] dates)
        {
            DateTime[] datesValidated = new DateTime[dates.Length];
            for (int i = 0; i < dates.Length; i++)
            {
                datesValidated[i] = ConvertToDate(dates[i]);
            }
            return datesValidated;
        }
        public DateTime ConvertToDate(string enteredDate)
        {
                return DateTime.Parse(enteredDate);
        }
    }
}
