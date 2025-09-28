using System;
using UtilityDLL; // Sử dụng DLL mới

namespace ConsoleApp
{
    class Program
    {
        static void Main() // Xóa 'string[] args' để loại bỏ cảnh báo
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Console App Giai Phuong Trinh - [Dấu ấn Cá nhân]";

            GiaiPhuongTrinh pt = new GiaiPhuongTrinh();

            // Giai phuong trinh bac 2
            Console.WriteLine("\n==== GIAI PHUONG TRINH BAC 2 (ax^2 + bx + c = 0) ====");
            try
            {
                Console.Write("Nhap A: "); pt.A = double.Parse(Console.ReadLine());
                Console.Write("Nhap B: "); pt.B = double.Parse(Console.ReadLine());
                Console.Write("Nhap C: "); pt.C = double.Parse(Console.ReadLine());

                string ketQua = pt.GiaiBac2();
                Console.WriteLine("Ket qua: " + ketQua);
            }
            catch { Console.WriteLine("[Loi] Nhap lieu khong hop le."); }

            // Giai phuong trinh bac 3 don gian
            Console.WriteLine("\n==== GIAI PHUONG TRINH BAC 3 (x^3 + bx + c = 0) ====");
            try
            {
                Console.Write("Nhap B: "); double b3 = double.Parse(Console.ReadLine());
                Console.Write("Nhap C: "); double c3 = double.Parse(Console.ReadLine());

                string ketQua = pt.GiaiBac3DonGian(b3, c3);
                Console.WriteLine("Ket qua: " + ketQua);
            }
            catch { Console.WriteLine("[Loi] Nhap lieu khong hop le."); }

            Console.WriteLine("\nNhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}