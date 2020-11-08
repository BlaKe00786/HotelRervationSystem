using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                totalPrice = hotel.specialWeekdayRates * weekdayCount + hotel.specialWeekendRates * weekendCount;
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
        public Hotel highestRatedHotel(DateTime[] dates)
        {
            Hotel bestRatedHotel = hotelsList[0];
            foreach(Hotel hotel in hotelsList)
            {
                if(bestRatedHotel.hotelRating<hotel.hotelRating)
                {
                    bestRatedHotel = hotel; 
                }
            }
            int totalPrice = 0;
            int weekendCount = 0;
            int weekdayCount = 0;
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
            totalPrice = bestRatedHotel.weekdayRates * weekdayCount + bestRatedHotel.weekendRates * weekendCount;
            Console.WriteLine("Total Rate: " + totalPrice);
            return bestRatedHotel;
        }
        public Hotel GivenWeekendAndWeekdayRateReturnBestRatedHotelForRewardCustomerWithRegexValidation(string[] dates)
        {
            string regexDateValid = "^[0-9]{1,2}[A-Z]{1}[a-z]{2}[2]{1}[0]{1}[2-9]{1}[0-9]{1}";
            bool regexValidation = false;
            foreach (string dateValid in dates)
            {
                regexValidation = Regex.IsMatch(dateValid, regexDateValid);
                if (!regexValidation)
                    throw new HotelCustomException(HotelCustomException.ExceptionType.INVALID_DATE, "Date is Invalid.Regex Validation Failed");
            }
            DateTime[] date = new DateTime[2];
            date[0] = DateTime.Parse(dates[0]);
            date[1] = DateTime.Parse(dates[1]);
            return FindCheapestHotel(date);
        }
    }
}
