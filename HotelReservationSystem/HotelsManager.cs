using System;
using System.Collections.Generic;
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
            hotelsList.Sort((hotel1, hotel2) => hotel1.regularRates.CompareTo(hotel2.regularRates));
            return hotelsList[0];
        }
        public DateTime[] getDates(string[] dates)
        {
            DateTime[] datesValidated = new DateTime[dates.Length];
            for (int i = 0; i < dates.Length; i++)
            {
                DateTime date = ConvertToDate(dates[i]);
                datesValidated[i] = date;
            }
            return datesValidated;
        }
        public DateTime ConvertToDate(string enteredDate)
        {
                DateTime date = DateTime.Parse(enteredDate);
                return date;
        }
    }
}
