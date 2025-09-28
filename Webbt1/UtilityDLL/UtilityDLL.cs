using System;

namespace UtilityDLL
{
    public class GiaiPhuongTrinh
    {
        // Fields ẩn (Backing fields)
        private double _a;
        private double _b;
        private double _c;

        // Properties kiểu cũ (.NET 2.0 compatible)
        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        public double C
        {
            get { return _c; }
            set { _c = value; }
        }

        // Phương thức giải bậc 1 (ax + b = 0) - dùng nội bộ
        private string GiaiBac1(double a, double b)
        {
            if (a == 0)
            {
                if (b == 0) return "Phương trình có vô số nghiệm.";
                return "Phương trình vô nghiệm.";
            }
            double x = -b / a;
            return "Nghiệm x = " + x;
        }

        // Phương thức giải bậc 2 (ax^2 + bx + c = 0)
        public string GiaiBac2()
        {
            if (_a == 0)
            {
                // Chuyển sang giải bậc 1
                return "[Dấu ấn Cá nhân: A=0, chuyển sang Bậc 1]: " + GiaiBac1(_b, _c);
            }

            double delta = _b * _b - 4 * _a * _c;
            if (delta < 0)
                return "Phương trình vô nghiệm thực.";

            if (delta == 0)
            {
                double x = -_b / (2 * _a);
                return "Nghiệm kép x = " + x;
            }

            double x1 = (-_b + Math.Sqrt(delta)) / (2 * _a);
            double x2 = (-_b - Math.Sqrt(delta)) / (2 * _a);
            return "Hai nghiệm thực: x1 = " + x1 + ", x2 = " + x2;
        }

        // Phương thức giải bậc 3 đơn giản (x^3 + bx + c = 0)
        public string GiaiBac3DonGian(double b, double c)
        {
            // Đây là giải pháp đơn giản chỉ áp dụng cho dạng x^3 + px + q = 0 (đã lược bỏ hệ số bậc 2)
            double q = b / 3.0;
            double r = -c / 2.0;
            double delta = r * r + q * q * q;

            // ... (Phần code giải thuật giải bậc 3 không thay đổi)
            if (delta > 0)
            {
                double s = Math.Pow(r + Math.Sqrt(delta), 1.0 / 3.0);
                double t = Math.Pow(r - Math.Sqrt(delta), 1.0 / 3.0);
                double x = s + t;
                return "Một nghiệm thực: x = " + x;
            }
            else if (delta == 0)
            {
                double x = 2 * Math.Pow(r, 1.0 / 3.0);
                return "Nghiệm thực bội: x = " + x;
            }
            else
            {
                double theta = Math.Acos(r / Math.Sqrt(-q * q * q));
                double x1 = 2 * Math.Sqrt(-q) * Math.Cos(theta / 3);
                double x2 = 2 * Math.Sqrt(-q) * Math.Cos((theta + 2 * Math.PI) / 3);
                double x3 = 2 * Math.Sqrt(-q) * Math.Cos((theta + 4 * Math.PI) / 3);
                return "Ba nghiệm thực: x1 = " + x1 + ", x2 = " + x2 + ", x3 = " + x3;
            }
        }
    }
}