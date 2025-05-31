using System;
using System.Collections.Generic;
using BT1460.Models;

namespace BT1460.Models
{
    public class Hotel
    {
        public string HotelNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public List<Room> RoomList { get; set; }

        public Hotel()
        {
            RoomList = new List<Room>();
        }

        public void Input()
        {
            Console.WriteLine("Nhap ma khach san: ");
            HotelNo = Console.ReadLine();

            Console.WriteLine("Nhap ten khach san: ");
            Name = Console.ReadLine();

            Console.WriteLine("Nhap dia chi: ");
            Address = Console.ReadLine();

            Console.WriteLine("Nhap loai: ");
            Type = Console.ReadLine();

            Console.WriteLine("Nhap so phong: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Room room = new Room();
                room.Input();

                RoomList.Add(room);
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("Ten KS: {0}, ma ks: {1}, dia chi: {2}, loai: {3}",
                Name, HotelNo, Address, Type);
            Console.WriteLine("Danh sach phong: ");
            foreach (Room room in RoomList)
            {
                room.Display();
            }
        }

        public void Display()
        {
            Console.WriteLine("Ten KS: {0}, ma ks: {1}, dia chi: {2}, loai: {3}",
                Name, HotelNo, Address, Type);
        }

        Room findRoom(string roomNo)
        {
            foreach (Room room in RoomList)
            {
                if (room.RoomNo == roomNo)
                {
                    return room;
                }
            }
            return null;
        }

        public int CalculateProfit(List<Booking> bookings)
        {
            int profit = 0;
            foreach (Booking booking in bookings)
            {
                if (booking.HotelNo == HotelNo)
                {
                    Room room = findRoom(booking.RoomNo);
                    if (room != null)
                    {
                        profit += room.Price;
                    }
                }
            }
            return profit;
        }

        public void ShowRoomAvailable(List<Booking> bookings)
        {
            Display();
            Console.WriteLine("Danh sach phong trong: ");
            foreach (Room room in RoomList)
            {
                if (CheckAvailable(bookings, room))
                {
                    room.Display();
                }
            }
        }

        bool CheckAvailable(List<Booking> bookings, Room room)
        {
            foreach (Booking booking in bookings)
            {
                if (booking.HotelNo == HotelNo && booking.RoomNo == room.RoomNo)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
