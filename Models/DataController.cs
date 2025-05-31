using System;
using System.Collections.Generic;

namespace BT1460.Models
{
    public class DataController
    {
        public List<Customer> CustomerList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<Booking> BookingList { get; set; }

        public static DataController instance = null;

        private DataController()
        {
            CustomerList = new List<Customer>();
            HotelList = new List<Hotel>();
            BookingList = new List<Booking>();
        }

        public static DataController getInstance()
        {
            if (instance == null)
            {
                instance = new DataController();
            }
            return instance;
        }

        public Hotel FindHotel(string hotelNo)
        {
            foreach (Hotel hotel in HotelList)
            {
                if (hotel.HotelNo == hotelNo)
                {
                    return hotel;
                }
            }
            return null;
        }
    }
}
