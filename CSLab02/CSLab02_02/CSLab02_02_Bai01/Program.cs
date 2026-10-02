using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_02_Bai01
{
    internal class Program
    {
        // Hàm xuất các phần tử trong danh sách ra màn hình
        static void XuatMang(List<string> mang)
        {
            if (mang.Count == 0)
            {
                Console.WriteLine("(Danh sách đang trống)");
                return;
            }
            Console.WriteLine(string.Join(", ", mang));
        }

        // Hàm tìm kiếm trả về kiểu bool theo yêu cầu đề bài
        static bool TimKiemHangHoa(List<string> mang, string tenCanTim)
        {
            return mang.Contains(tenCanTim);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<string> dsHangHoa = new List<string>();

            // 1. Nhập hàng hóa cho đến khi nhập chuỗi "STOP"
            Console.WriteLine("--- 1. NHẬP DANH SÁCH HÀNG HÓA (Gõ 'STOP' để dừng) ---");
            while (true)
            {
                Console.Write("Nhập tên hàng hóa: ");
                string input = Console.ReadLine().Trim();

                if (input.ToUpper() == "STOP")
                {
                    break;
                }

                if (!string.IsNullOrWhiteSpace(input))
                {
                    dsHangHoa.Add(input);
                    Console.WriteLine("-> Đã thêm! Số lượng hiện tại (Count) = {0}", dsHangHoa.Count);
                }
            }

            // 2. Xuất danh sách hàng hóa
            Console.WriteLine("\n--- 2. DANH SÁCH HÀNG HÓA VỪA NHẬP ---");
            XuatMang(dsHangHoa);

            // 3. Tìm kiếm theo tên
            Console.WriteLine("\n--- 3. TÌM KIẾM HÀNG HÓA ---");
            Console.Write("Nhập tên hàng hóa cần tìm: ");
            string tenTim = Console.ReadLine().Trim();

            bool ketQuaTim = TimKiemHangHoa(dsHangHoa, tenTim);
            Console.WriteLine("Kết quả tìm kiếm: {0}", ketQuaTim);

            if (ketQuaTim)
            {
                int viTri = dsHangHoa.IndexOf(tenTim);
                Console.WriteLine(">> Tìm thấy '{0}' tại vị trí chỉ số index = {1}", tenTim, viTri);
            }
            else
            {
                Console.WriteLine(">> Không tìm thấy hàng hóa '{0}' trong danh sách!", tenTim);
            }

            // 4. Xóa một hàng hóa
            Console.WriteLine("\n--- 4. XÓA MỘT HÀNG HÓA ---");
            Console.Write("Nhập tên hàng hóa muốn xóa: ");
            string tenXoa = Console.ReadLine().Trim();

            if (dsHangHoa.Remove(tenXoa))
            {
                Console.WriteLine(">> Đã xóa thành công '{0}'.", tenXoa);
                Console.WriteLine("Danh sách sau khi xóa:");
                XuatMang(dsHangHoa);
            }
            else
            {
                Console.WriteLine(">> Không tìm thấy '{0}' để xóa!", tenXoa);
            }

            // 5. Thêm hàng hóa vào vị trí index bất kỳ
            Console.WriteLine("\n--- 5. CHÈN HÀNG HÓA VÀO VỊ TRÍ BẤT KỲ ---");
            Console.Write("Nhập tên hàng hóa mới cần chèn: ");
            string hangHoaMoi = Console.ReadLine().Trim();

            int viTriChen = -1;
            while (true)
            {
                Console.Write("Nhập vị trí index cần chèn (từ 0 đến {0}): ", dsHangHoa.Count);
                if (int.TryParse(Console.ReadLine(), out viTriChen) && viTriChen >= 0 && viTriChen <= dsHangHoa.Count)
                {
                    break;
                }
                Console.WriteLine(">> Vị trí index không hợp lệ. Vui lòng nhập lại!");
            }

            // Sử dụng phương thức Insert
            dsHangHoa.Insert(viTriChen, hangHoaMoi);
            Console.WriteLine(">> Đã chèn '{0}' vào vị trí {1} thành công!", hangHoaMoi, viTriChen);

            Console.WriteLine("\nDanh sách cuối cùng:");
            XuatMang(dsHangHoa);

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}
