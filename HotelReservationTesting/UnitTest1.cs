using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;
namespace HotelReservationTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenHotelCheckNameAndRate()
        {
            string hotelName = "Bridgewood";
            int regularRates = 150;
            HotelsManager hotelsManager = new HotelsManager();
            Hotel hotel = new Hotel(hotelName, regularRates);
            hotelsManager.AddHotel(hotel);
            Assert.AreEqual(hotelName, hotelsManager.hotelsList[0].hotelName);
            Assert.AreEqual(regularRates, hotelsManager.hotelsList[0].regularRates);
        }
        [TestMethod]
        public void GivenDatesReturnsCheapestHotel()
        {
            HotelsManager hotelsManager = new HotelsManager();
            hotelsManager.AddHotel(new Hotel("Lakewood", 110));
            hotelsManager.AddHotel(new Hotel("Bridgewood", 150));
            hotelsManager.AddHotel(new Hotel("Ridgewood", 220));
            string[] dates = "01Jan2019,11Dec2020".Split(",");
            Hotel cheapestHotel = hotelsManager.FindCheapestHotel(dates);
            Assert.AreEqual("Lakewood", cheapestHotel.hotelName);
            Assert.AreEqual(220, cheapestHotel.regularRates*dates.Length);
        }
    }
}
