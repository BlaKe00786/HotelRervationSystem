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
            int rating = 4;
            HotelsManager hotelsManager = new HotelsManager();
            Hotel hotel = new Hotel(hotelName,"Regular", weekdayRates,weekendRates,rating, 0, 0);
            hotelsManager.AddHotel(hotel);
            Assert.AreEqual(hotelName, hotelsManager.hotelsList[0].hotelName);
            Assert.AreEqual(weekdayRates, hotelsManager.hotelsList[0].weekdayRates);
        }
        [TestMethod]
        public void GivenDatesReturnsCheapestHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90, 3, 0, 0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150, 5, 0, 0));
            string[] dates = "10Sep2020,11Sep2020".Split(",");
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(dates);
            Assert.AreEqual("Lakewood", cheapestHotel.hotelName);
            Assert.AreEqual(220, cheapestHotel.weekdayRates*dates.Length);
        }
        [TestMethod]
        public void GivenWeekendRatesReturnWeekendRate()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90, 3, 0, 0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150, 5, 0, 0));
            Assert.AreEqual(90, hotelsManager.hotelsList[0].weekendRates);
        }
        [TestMethod]
        public void GivenDatesReturnCheapestHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90, 3, 0, 0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150, 5, 0, 0));
            string[] dates = "11Sep2020,12Sep2020".Split(",");
            DateTime[] date = new DateTime[dates.Length];
            for (int index = 0; index < date.Length; index++)
            {
                date[index] = DateTime.Parse(dates[index]);
            }
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(date);
            Assert.AreEqual("Bridgewood", cheapestHotel.hotelName);
        }
        [TestMethod]
        public void GivenRatingsReturnRatings()
        {
            HotelsManager hotelsManager = new HotelsManager();
            int expectedRatings = 3;
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90, 3, 0, 0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150, 5, 0, 0));
            Assert.AreEqual(expectedRatings, hotelsManager.hotelsList[0].hotelRating);
        }
        [TestMethod]
        public void GivenDatesReturnBestRatedHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            int expectedRatings = 5;
            hotelsManager.AddHotel(new Hotel("Lakewood", "Regular", 110, 90, 3,0,0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Regular", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Regular", 220, 150, 5, 0, 0));
            string[] dates = "11Sep2020,12Sep2020".Split(",");
            DateTime[] date = new DateTime[dates.Length];
            for (int index = 0; index < date.Length; index++)
            {
                date[index] = DateTime.Parse(dates[index]);
            }
            Assert.AreEqual(expectedRatings, hotelsManager.highestRatedHotel(date).hotelRating);
        }
        [TestMethod]
        public void GivenSpecialrateReturnRate()
        {
            HotelsManager hotelsManager = new HotelsManager();
            int expectedRate = 80;
            hotelsManager.AddHotel(new Hotel("Lakewood", "Reward", 110, 90, 3, 80, 0));
            hotelsManager.AddHotel(new Hotel("Bridgewood", "Reward", 150, 50, 4, 0, 0));
            hotelsManager.AddHotel(new Hotel("Ridgewood", "Reward", 220, 150, 5, 0, 0));
            Assert.AreEqual(expectedRate, hotelsManager.hotelsList[0].specialWeekdayRates);
        }
    }
}
