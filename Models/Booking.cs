using System;
using BT1460.Utils;

namespace BT1460.Models
{
    public class Booking
    {
        public string HotelNo { get; set; }
        public string RoomNo { get; set; }
        public string CMTND { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Booking()
        {
        }

        public void Input()
        {
            if (DataController.getInstance().HotelList.Count == 0)
            {
                return;
            }

            bool isFind = false;

            Console.WriteLine("Nhap ma khach san: ");
            Hotel currentHotel = null;
            while (true)
            {
                HotelNo = Console.ReadLine();
                isFind = false;
                foreach (Hotel hotel in DataController.getInstance().HotelList)
                {
                    if (hotel.HotelNo == HotelNo)
                    {
                        currentHotel = hotel;
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    Console.WriteLine("Nhap lai: ");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Nhap ma phong: ");
            while (true)
            {
                RoomNo = Console.ReadLine();
                isFind = false;
                foreach (Room room in currentHotel.RoomList)
                {
                    if (room.RoomNo == RoomNo)
                    {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    Console.WriteLine("Nhap lai: ");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Nhap CMTND: ");
            CMTND = Console.ReadLine();
            isFind = false;
            foreach (Customer customer in DataController.getInstance().CustomerList)
            {
                if (customer.CMTND == CMTND)
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
            {
                Customer customer = new Customer(CMTND);
                customer.InputWithoutCMTND();

                DataController.getInstance().CustomerList.Add(customer);
            }

            Console.WriteLine("Nhap ngay nhan (yyyy-MM-dd HH:mm:ss): ");
            CheckIn = Utility.ConvertStringToDateTime(Console.ReadLine());

            Console.WriteLine("Nhap ngay tra (yyyy-MM-dd HH:mm:ss): ");
            CheckOut = Utility.ConvertStringToDateTime(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("Ma KS: {0}, ma phong: {1}, CMTND: {2}, " +
                "Ngay nhan: {3}, ngay tra: {4}", HotelNo, RoomNo, CMTND,
                Utility.ConvertDateTimeToString(CheckIn), Utility.ConvertDateTimeToString(CheckOut));
        }
    }
}
