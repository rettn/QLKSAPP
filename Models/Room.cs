using System;
namespace BT1460.Models
{
    public class Room
    {
        public string RoomNo { get; set; }
        public string RoomName { get; set; }
        public int Floor { get; set; }
        public int NumMax { get; set; }
        public int Price { get; set; }

        public Room()
        {
        }

        public void Input()
        {
            Console.WriteLine("Nhap ma phong: ");
            RoomNo = Console.ReadLine();

            Console.WriteLine("Nhap ten phong: ");
            RoomName = Console.ReadLine();

            Console.WriteLine("Nhap tang: ");
            Floor = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap so nguoi toi da: ");
            NumMax = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap gia: ");
            Price = int.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("Ma phong: {0}, ten phong: {1}, " +
                "tang: {2}, so nguoi toi da: {3}, " +
                "gia tien: {4}", RoomNo, RoomName, Floor, NumMax, Price);
        }
    }
}
