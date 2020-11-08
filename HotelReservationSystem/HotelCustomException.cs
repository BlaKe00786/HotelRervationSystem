using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelCustomException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DATE,
            NULL_DATES,
            INVALID_DATE_FORMAT,
        }
        public ExceptionType type;
        public HotelCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
