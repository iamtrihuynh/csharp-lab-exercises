using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        // Khởi tạo đối tượng quản lý dùng chung
        private static QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            // Thiết lập bảng mã UTF-8 để hiển thị và gõ tiếng Việt có dấu
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Nạp dữ liệu mẫu ban đầu để kiểm thử
            NapDuLieuMau();

            int luaChon = -1;
            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chọn chức năng: ");
                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        ChucNangThemSinhVien();
                        break;
                    case 2:
                        ChucNangXuatDanhSach();
                        break;
                    case 3:
                        ChucNangTimTheoMSSV();
                        break;
                    case 4:
                        ChucNangTimTheoTen();
                        break;
                    case 5:
                        ChucNangSuaDiem();
                        break;
                    case 6:
                        ChucNangXoaSinhVien();
                        break;
                    case 7:
                        ChucNangSapXep();
                        break;
                    case 8:
                        ChucNangLocSinhVienDat();
                        break;
                    case 0:
                        Console.WriteLine(">> Đang thoát chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine(">> Lỗi: Lựa chọn không hợp lệ, vui lòng chọn lại từ 0 đến 8!");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                }

            } while (luaChon != 0);
        }

        // ==========================================
        // GIAO DIỆN MENU CHÍNH
        // ==========================================
        static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("===== QUẢN LÝ SINH VIÊN =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm sinh viên theo tên");
            Console.WriteLine("5. Sửa điểm trung bình");
            Console.WriteLine("6. Xóa sinh viên");
            Console.WriteLine("7. Sắp xếp theo điểm giảm dần");
            Console.WriteLine("8. Lọc sinh viên đạt");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("=============================");
        }

        // ==========================================
        // CÁC HÀM XỬ LÝ CHỨC NĂNG
        // ==========================================
        static void ChucNangThemSinhVien()
        {
            Console.WriteLine("--- THÊM SINH VIÊN ---");
            string mssv;
            while (true)
            {
                mssv = NhapChuoi("Nhập mã số sinh viên (MSSV): ");
                if (qlsv.KiemTraThongTin(mssv))
                {
                    Console.WriteLine(">> Mã '" + mssv + "' đã tồn tại! Vui lòng nhập mã khác.");
                }
                else
                {
                    break;
                }
            }

            string hoTen = NhapChuoi("Nhập họ tên: ");
            DateTime ngaySinh = NhapNgayThang("Nhập ngày sinh (dd/MM/yyyy): ");
            string maLop = NhapChuoi("Nhập mã lớp: ");
            double diemTB = NhapDiemHopLe("Nhập điểm trung bình (0 - 10): ");

            SinhVien sv = new SinhVien(mssv, hoTen, ngaySinh, maLop, diemTB);
            if (qlsv.ThemSinhVien(sv))
            {
                Console.WriteLine(">> Thêm sinh viên thành công!");
            }
            else
            {
                Console.WriteLine(">> Thêm thất bại!");
            }
        }

        static void ChucNangXuatDanhSach()
        {
            Console.WriteLine("--- DANH SÁCH TẤT CẢ SINH VIÊN ---");
            // Truyền trực tiếp List vào hàm
            InDanhSach(qlsv.LayDanhSach());
        }

        static void ChucNangTimTheoMSSV()
        {
            Console.WriteLine("--- TÌM SINH VIÊN THEO MÃ ---");
            string mssv = NhapChuoi("Nhập MSSV cần tìm: ");

            // Dùng var hoặc List tường minh
            List<SinhVien> ketQua = qlsv.TimKiemTheoMSSV(mssv);

            if (ketQua.Count > 0)
            {
                Console.WriteLine(">> Đã tìm thấy sinh viên:");
                Console.WriteLine(ketQua[0].LayThongTin());
            }
            else
            {
                Console.WriteLine(">> Không tìm thấy sinh viên có mã '" + mssv + "'!");
            }
        }

        static void ChucNangTimTheoTen()
        {
            Console.WriteLine("--- TÌM SINH VIÊN THEO TÊN ---");
            string ten = NhapChuoi("Nhập từ khóa họ tên cần tìm: ");

            // Dùng List tường minh
            List<SinhVien> ketQua = qlsv.TimKiemTheoTen(ten);

            if (ketQua.Count > 0)
            {
                Console.WriteLine(">> Tìm thấy " + ketQua.Count + " kết quả phù hợp:");
                InDanhSach(ketQua);
            }
            else
            {
                Console.WriteLine(">> Không tìm thấy sinh viên nào chứa tên '" + ten + "'!");
            }
        }

        static void ChucNangSuaDiem()
        {
            Console.WriteLine("--- SỬA ĐIỂM TRUNG BÌNH ---");
            string mssv = NhapChuoi("Nhập MSSV cần cập nhật điểm: ");

            if (!qlsv.KiemTraThongTin(mssv))
            {
                Console.WriteLine(">> Không tìm thấy sinh viên có MSSV '" + mssv + "'!");
                return;
            }

            double diemMoi = NhapDiemHopLe("Nhập điểm trung bình mới (0 - 10): ");
            if (qlsv.SuaDiem(mssv, diemMoi))
            {
                Console.WriteLine(">> Cập nhật điểm thành công!");
            }
            else
            {
                Console.WriteLine(">> Cập nhật điểm thất bại!");
            }
        }

        static void ChucNangXoaSinhVien()
        {
            Console.WriteLine("--- XÓA SINH VIÊN ---");
            string mssv = NhapChuoi("Nhập MSSV cần xóa: ");

            if (qlsv.XoaSinhVien(mssv))
            {
                Console.WriteLine(">> Đã xóa thành công sinh viên có MSSV '" + mssv + "'!");
            }
            else
            {
                Console.WriteLine(">> Không tìm thấy sinh viên có MSSV '" + mssv + "' để xóa!");
            }
        }

        static void ChucNangSapXep()
        {
            Console.WriteLine("--- DANH SÁCH SẮP XẾP THEO ĐIỂM GIẢM DẦN ---");
            // Dùng List tường minh
            List<SinhVien> dsSapXep = qlsv.SapXepTheoDiemGiamDan();
            InDanhSach(dsSapXep);
        }

        static void ChucNangLocSinhVienDat()
        {
            Console.WriteLine("--- DANH SÁCH SINH VIÊN ĐẠT (ĐIỂM >= 5.0) ---");
            // Dùng List tường minh
            List<SinhVien> dsDat = qlsv.SinhVienDat();
            InDanhSach(dsDat);
        }

        // ==========================================
        // CÁC HÀM VALIDATION VÀ TIỆN ÍCH IN ẤN
        // ==========================================

        // Khai báo chuẩn: List ds thay vì List ds
        static void InDanhSach(List<SinhVien> ds)
        {
            if (ds == null || ds.Count == 0)
            {
                Console.WriteLine("(Danh sách trống)");
                return;
            }

            Console.WriteLine(new string('-', 95));
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine(string.Format("{0,2}. {1}", i + 1, ds[i].LayThongTin()));
            }
            Console.WriteLine(new string('-', 95));
        }

        static string NhapChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine(">> Dữ liệu không được để trống. Vui lòng nhập lại!");
            }
        }

        static int NhapSoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                int result;
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine(">> Lỗi: Vui lòng nhập số nguyên hợp lệ!");
            }
        }

        static double NhapDiemHopLe(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                double diem;
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out diem) ||
                    double.TryParse(input, out diem))
                {
                    if (diem >= 0.0 && diem <= 10.0)
                    {
                        return diem;
                    }
                    Console.WriteLine(">> Điểm phải nằm trong đoạn [0, 10]!");
                }
                else
                {
                    Console.WriteLine(">> Lỗi: Vui lòng nhập số thực hợp lệ (VD: 8.5 hoặc 8,5)!");
                }
            }
        }

        static DateTime NhapNgayThang(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                DateTime dt;
                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    return dt;
                }
                Console.WriteLine(">> Định dạng ngày không hợp lệ! Hãy nhập dạng dd/MM/yyyy (VD: 15/01/2005).");
            }
        }

        static void NapDuLieuMau()
        {
            qlsv.ThemSinhVien(new SinhVien("SV001", "Nguyễn Văn An", new DateTime(2005, 3, 15), "CNTT01", 8.5));
            qlsv.ThemSinhVien(new SinhVien("SV002", "Trần Thị Bình", new DateTime(2005, 7, 22), "CNTT01", 4.2));
            qlsv.ThemSinhVien(new SinhVien("SV003", "Lê Hoàng Cường", new DateTime(2004, 11, 5), "CNTT02", 9.0));
            qlsv.ThemSinhVien(new SinhVien("SV004", "Phạm Minh Đức", new DateTime(2005, 1, 30), "CNTT02", 6.5));
        }
    }
}