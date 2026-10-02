using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> _danhSachSinhVien;

        public QuanLySinhVien()
        {
            _danhSachSinhVien = new List<SinhVien>();
        }

        public bool KiemTraThongTin(string MSSV)
        {
            return _danhSachSinhVien.Any(sv => sv.MSSV == MSSV);
        }

        // 1
        public bool ThemSinhVien(SinhVien sv)
        {
            if (KiemTraThongTin(sv.MSSV)) return false; // Sinh viên đã tồn tại

            _danhSachSinhVien.Add(sv);
            return true; // Thêm thành công
        }

        // 2
        public List<SinhVien> LayDanhSach()
        {
            return _danhSachSinhVien;
        }

        // 3
        public List<SinhVien> TimKiemTheoTen(string ten)
        {
            return _danhSachSinhVien.Where(sv => sv.HoTen.IndexOf(ten, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // 4 
        public List<SinhVien> TimKiemTheoMSSV(string MSSV)
        {
            return _danhSachSinhVien.Where(sv => sv.MSSV.Equals(MSSV, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // 5
        public bool SuaDiem(string MSSV, double diemMoi)
        {
            //var sinhVien = TimKiemTheoMSSV(MSSV);

            var sinhVien = _danhSachSinhVien.FirstOrDefault(sv => sv.MSSV.Equals(MSSV, StringComparison.OrdinalIgnoreCase));
            if (sinhVien != null)
            {
                sinhVien.DiemTB = diemMoi;
                return true;
            }
            return false;
        }

        // 6
        public bool XoaSinhVien(string MSSV)
        {
            var sinhVien = _danhSachSinhVien.FirstOrDefault(sv => sv.MSSV.Equals(MSSV, StringComparison.OrdinalIgnoreCase));
            if (sinhVien != null)
            {
                _danhSachSinhVien.Remove(sinhVien);
                return true;
            }
            return false;
        }

        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return _danhSachSinhVien.OrderByDescending(sv => sv.DiemTB).ToList();
        }

        public List<SinhVien> SinhVienDat()
        {
            return _danhSachSinhVien.Where(sv => sv.DiemTB >= 5).ToList();
        }

    }
}
