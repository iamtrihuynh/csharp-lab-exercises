using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai03
{
    public class DaThuc
    {
        // Mảng chứa các hệ số: a[k] tương ứng với hệ số của x^k
        private double[] a;

        // 1. Property cho biết bậc n của đa thức
        public int Bac
        {
            get { return a.Length - 1; }
        }

        // 2. Hàm khởi tạo 1 tham số truyền vào là bậc của đa thức
        // Tạo ra đa thức mà tất cả các hệ số đều bằng 0
        public DaThuc(int bac)
        {
            if (bac < 0) bac = 0;
            a = new double[bac + 1]; // Đa thức bậc n cần (n + 1) hệ số: từ a0 đến an
            for (int i = 0; i <= bac; i++)
            {
                a[i] = 0;
            }
        }

        // 3. Indexer với tham số k cho biết giá trị a_k và có thể gán giá trị vào a_k
        public double this[int k]
        {
            get
            {
                if (k >= 0 && k <= Bac)
                    return a[k];
                return 0; // Nếu vượt quá bậc của đa thức thì hệ số bằng 0
            }
            set
            {
                if (k >= 0 && k <= Bac)
                {
                    a[k] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException($"Chỉ số bậc {k} không hợp lệ (Bậc đa thức là {Bac})!");
                }
            }
        }

        // 4. Phương thức tính giá trị của đa thức khi x = b: P(b)
        public double TinhGiaTri(double b)
        {
            double tong = 0;
            for (int k = 0; k <= Bac; k++)
            {
                tong += a[k] * Math.Pow(b, k);
            }
            return tong;
        }

        // 5. Phép toán Cộng hai đa thức (operator +)
        public static DaThuc operator +(DaThuc d1, DaThuc d2)
        {
            int maxBac = Math.Max(d1.Bac, d2.Bac);
            DaThuc kq = new DaThuc(maxBac);

            for (int i = 0; i <= maxBac; i++)
            {
                kq[i] = d1[i] + d2[i]; // Tận dụng get của indexer: vượt bậc trả về 0
            }
            return kq;
        }

        // 6. Phép toán Trừ hai đa thức (operator -)
        public static DaThuc operator -(DaThuc d1, DaThuc d2)
        {
            int maxBac = Math.Max(d1.Bac, d2.Bac);
            DaThuc kq = new DaThuc(maxBac);

            for (int i = 0; i <= maxBac; i++)
            {
                kq[i] = d1[i] - d2[i];
            }
            return kq;
        }

        // 7. Nhập hệ số cho đa thức từ bàn phím
        public void Nhap()
        {
            Console.WriteLine($"Nhập các hệ số cho đa thức bậc {Bac}:");
            for (int i = Bac; i >= 0; i--)
            {
                while (true)
                {
                    Console.Write($"  Hệ số của x^{i} (a_{i}): ");
                    if (double.TryParse(Console.ReadLine(), out double heSo))
                    {
                        a[i] = heSo;
                        break;
                    }
                    Console.WriteLine("  >> Lỗi: Vui lòng nhập số thực hợp lệ!");
                }
            }
        }

        // 8. Định dạng chuỗi hiển thị đa thức chuẩn toán học: a_n*x^n + ... + a_1*x + a_0
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool laSoDauTien = true;

            for (int i = Bac; i >= 0; i--)
            {
                double heSo = a[i];
                if (Math.Abs(heSo) < 1e-9) continue; // Bỏ qua hệ số 0

                // Xử lý dấu (+ hoặc -)
                if (laSoDauTien)
                {
                    if (heSo < 0) sb.Append("-");
                    laSoDauTien = false;
                }
                else
                {
                    sb.Append(heSo > 0 ? " + " : " - ");
                }

                // Xử lý độ lớn hệ số và biến x^i
                double absHeSo = Math.Abs(heSo);
                if (i == 0) // Hệ số tự do
                {
                    sb.Append(absHeSo);
                }
                else if (i == 1) // Bậc 1
                {
                    if (Math.Abs(absHeSo - 1.0) < 1e-9) sb.Append("x");
                    else sb.Append($"{absHeSo}x");
                }
                else // Bậc >= 2
                {
                    if (Math.Abs(absHeSo - 1.0) < 1e-9) sb.Append($"x^{i}");
                    else sb.Append($"{absHeSo}x^{i}");
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
