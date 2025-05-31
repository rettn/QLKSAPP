using System;
using BT1460.Models;
using BT1460.Utils;
using System.Collections.Generic;

namespace BT1460
{
    class Program
    {
        //1. Quan ly khach hang
        //2. Quan ly dc KS
        //3. Quan ly dc booking
        static void Main(string[] args)
        {
            int choose;

            do
            {
                ShowMenu();
                choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        InputHotel();
                        break;
                    case 2:
                        DisplayHotel();
                        break;
                    case 3:
                        InputBooking();
                        break;
                    case 4:
                        FindRoomAvailable();
                        break;
                    case 5:
                        CalculateProfit();
                        break;
                    case 6:
                        SearchCustomerByCMNTD();
                        break;
                    case 7:
                        Console.WriteLine("Thoat!!!");
                        break;
                    default:
                        Console.WriteLine("Nhap sai!!!");
                        break;
                }
            } while (choose != 7);
        }

        private static void FindRoomAvailable()
        {
            Console.WriteLine("Nhap ngay nhan (yyyy-MM-dd HH:mm:ss): ");
            DateTime checkIn = Utility.ConvertStringToDateTime(Console.ReadLine());

            Console.WriteLine("Nhap ngay tra (yyyy-MM-dd HH:mm:ss): ");
            DateTime checkOut = Utility.ConvertStringToDateTime(Console.ReadLine());

            //Book -> CheckIn (checkIn & checkOut) || CheckOut (checkIn & checkOut)
            List<Booking> bookList = new List<Booking>();
            foreach (Booking booking in DataController.getInstance().BookingList)
            {
                if (booking.CheckIn >= checkIn && booking.CheckIn <= checkOut)
                {
                    bookList.Add(booking);
                }
                else if (booking.CheckOut >= checkIn && booking.CheckOut <= checkOut)
                {
                    bookList.Add(booking);
                }
            }

            //Hien thi danh sach phong con trong:
            foreach (Hotel hotel in DataController.getInstance().HotelList)
            {
                hotel.ShowRoomAvailable(bookList);
            }
        }

        private static void SearchCustomerByCMNTD()
        {
            Console.WriteLine("Nhap CMTND can tim: ");
            string cmntd = Console.ReadLine();

            List<Hotel> list = new List<Hotel>();

            foreach (Booking booking in DataController.getInstance().BookingList)
            {
                if (booking.CMTND == cmntd)
                {
                    Hotel hotel = DataController.getInstance().FindHotel(booking.HotelNo);
                    if (hotel != null && !list.Contains(hotel))
                    {
                        list.Add(hotel);
                    }
                }
            }

            Console.WriteLine("Danh sach KS ma KH toi: ");
            foreach (Hotel hotel in list)
            {
                hotel.Display();
            }
        }

        private static void CalculateProfit()
        {
            foreach (Hotel hotel in DataController.getInstance().HotelList)
            {
                int profit = hotel.CalculateProfit(DataController.getInstance().BookingList);
                Console.WriteLine("KS: {0}, ma ks: {1}, doanh thu: {2}", hotel.Name, hotel.HotelNo, profit);
            }
        }

        private static void InputBooking()
        {
            Console.WriteLine("Nhap thong tin dat phong: ");
            Booking booking = new Booking();
            booking.Input();

            DataController.getInstance().BookingList.Add(booking);
        }

        private static void DisplayHotel()
        {
            Console.WriteLine("Thong tin KS:");
            foreach (Hotel hotel in DataController.getInstance().HotelList)
            {
                hotel.Display();
            }
        }

        private static void InputHotel()
        {
            Console.WriteLine("Nhap so khach san can them: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Hotel hotel = new Hotel();
                hotel.Input();

                DataController.getInstance().HotelList.Add(hotel);
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Nhap thong tin khach san");
            Console.WriteLine("2. Hien thi thong tin KS");
            Console.WriteLine("3. Dat phong");
            Console.WriteLine("4. Tim phong trong");
            Console.WriteLine("5. Thong ke doanh thu");
            Console.WriteLine("6. Tim kiem KH");
            Console.WriteLine("7. Thoat");
            Console.WriteLine("Chon: ");
        }
    }
}
