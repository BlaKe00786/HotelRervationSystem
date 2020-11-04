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
    }
}
