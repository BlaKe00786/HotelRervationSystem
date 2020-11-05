using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;
using System;

namespace HotelReservationTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenHotelCheckNameAndRate()
        {
            string hotelName = "Bridgewood";
            int weekdayRates = 150;
            int weekendRates = 50;
            HotelsManager hotelsManager = new HotelsManager();
            Hotel hotel = new Hotel(hotelName,"Regular", weekdayRates,weekendRates);
            hotelsManager.AddHotel(hotel);
            Assert.AreEqual(hotelName, hotelsManager.hotelsList[0].hotelName);
            Assert.AreEqual(weekdayRates, hotelsManager.hotelsList[0].weekdayRates);
        }
        [TestMethod]
        public void GivenDatesReturnsCheapestHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150));
            string[] dates = "10Sep2020,11Sep2020".Split(",");
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(dates);
            Assert.AreEqual("Lakewood", cheapestHotel.hotelName);
            Assert.AreEqual(220, cheapestHotel.weekdayRates*dates.Length);
        }
        [TestMethod]
        public void GivenWeekendRatesReturnWeekendRate()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150));
            Assert.AreEqual(90, hotelsManager.hotelsList[0].weekendRates);
        }
        [TestMethod]
        public void GivenDatesReturnCheapestHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150));
            string[] dates = "11Sep2020,12Sep2020".Split(",");
            DateTime[] date = new DateTime[dates.Length];
            for (int index = 0; index < date.Length; index++)
            {
                date[index] = DateTime.Parse(dates[index]);
            }
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(date);
            Assert.AreEqual("Lakewood", cheapestHotel.hotelName);
        }
    }
}
