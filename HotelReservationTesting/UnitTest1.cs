using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;
namespace HotelReservationTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string hotelName = "Bridgewood";
            int regularRates = 150;
            HotelsManager hotelsManager = new HotelsManager();
            Hotel hotel = new Hotel(hotelName, regularRates);
            hotelsManager.AddHotel(hotel);
            Assert.AreEqual("Bridgewood", hotelsManager.hotelsList[0].hotelName);

        }
    }
}
