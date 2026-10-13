using System;

namespace Lab06_QuanLySanPham
{
    public class Product
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public string LoaiSP { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; } = DateTime.Now;
        public bool ConKinhDoanh { get; set; } = true;
        public string DuongDanAnh { get; set; } = string.Empty;

        // Cột thành tiền tự động tính toán trên DataGridView[cite: 23]
        public decimal ThanhTien => DonGia * SoLuong;
    }
}