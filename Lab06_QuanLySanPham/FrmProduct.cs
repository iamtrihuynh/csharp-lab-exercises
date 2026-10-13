using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab06_QuanLySanPham
{
    public partial class FrmProduct : Form
    {
        // Quản lý dữ liệu trong bộ nhớ (In-Memory)
        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource productSource = new BindingSource();

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
            CaiDatDataGridView();
            CapNhatTrangThaiNut();
            UpdateStatus("Sẵn sàng làm việc");
        }

        #region KHỞI TẠO DỮ LIỆU BAN ĐẦU

        private void KhoiTaoDuLieu()
        {
            // Danh mục loại sản phẩm cố định
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;

            // Dữ liệu mẫu ban đầu
            products.Add(new Product { MaSP = "SP01", TenSP = "Bàn phím cơ AKKO 3087", LoaiSP = "Điện tử", DonGia = 1250000m, SoLuong = 15, NgayNhap = DateTime.Now.AddDays(-10), ConKinhDoanh = true });
            products.Add(new Product { MaSP = "SP02", TenSP = "Ghế công thái học Sihoo", LoaiSP = "Văn phòng", DonGia = 3450000m, SoLuong = 5, NgayNhap = DateTime.Now.AddDays(-5), ConKinhDoanh = true });
            products.Add(new Product { MaSP = "SP03", TenSP = "Nồi chiên không dầu Philips", LoaiSP = "Gia dụng", DonGia = 2190000m, SoLuong = 20, NgayNhap = DateTime.Now.AddDays(-2), ConKinhDoanh = true });

            // Liên kết Binding 3 lớp: BindingList -> BindingSource -> DataGridView
            productSource.DataSource = products;
            dgvProducts.DataSource = productSource;

            // Theo dõi vị trí con trỏ dòng để cập nhật trạng thái nút
            productSource.CurrentChanged += (s, e) => CapNhatTrangThaiNut();
        }

        private void CaiDatDataGridView()
        {
            if (dgvProducts.Columns["DonGia"] != null)
                dgvProducts.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            if (dgvProducts.Columns["ThanhTien"] != null)
                dgvProducts.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            if (dgvProducts.Columns["NgayNhap"] != null)
                dgvProducts.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        #endregion

        #region BỐN HÀM CLEAN CODE BẮT BUỘC THEO ĐỀ BÀI

        private bool ValidateInput(bool isAddingNew = true)
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được để trống!");
                isValid = false;
            }
            else if (isAddingNew && products.Any(p => p.MaSP.Trim().Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0 VNĐ!");
                isValid = false;
            }

            if (numSoLuong.Value < 0)
            {
                errorProvider1.SetError(numSoLuong, "Số lượng không được âm!");
                isValid = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInput()
        {
            errorProvider1.Clear();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtMaSP.Enabled = true;
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
            picAnh.Image = null;
            picAnh.Tag = null;

            dgvProducts.ClearSelection();
            CapNhatTrangThaiNut();
            txtMaSP.Focus();
        }

        private void LoadProductToForm(Product p)
        {
            if (p == null) return;

            errorProvider1.Clear();
            txtMaSP.Text = p.MaSP;
            txtMaSP.Enabled = false;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.Text = p.LoaiSP;
            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;

            if (!string.IsNullOrEmpty(p.DuongDanAnh) && File.Exists(p.DuongDanAnh))
            {
                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                picAnh.Image = Image.FromFile(p.DuongDanAnh);
                picAnh.Tag = p.DuongDanAnh;
            }
            else
            {
                picAnh.Image = null;
                picAnh.Tag = null;
            }
        }

        private void UpdateStatus(string thongBao)
        {
            lblStatus.Text = thongBao;
            lblTongSo.Text = $"Tổng số: {products.Count} sản phẩm";
        }

        #endregion

        #region NGHIỆP VỤ CRUD CHÍNH (HÀM XỬ LÝ CHUNG DRY)

        private void ThemSanPham()
        {
            if (!ValidateInput(isAddingNew: true)) return;

            try
            {
                var p = new Product
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    LoaiSP = cboLoaiSP.Text,
                    DonGia = numDonGia.Value,
                    SoLuong = (int)numSoLuong.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked,
                    DuongDanAnh = picAnh.Tag?.ToString() ?? string.Empty
                };

                products.Add(p);
                ClearInput();
                UpdateStatus($"Đã thêm thành công: {p.TenSP}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaSanPham()
        {
            Product selected = LaySanPhamDangChon();
            if (selected == null) return;

            if (!ValidateInput(isAddingNew: false)) return;

            try
            {
                selected.TenSP = txtTenSP.Text.Trim();
                selected.LoaiSP = cboLoaiSP.Text;
                selected.DonGia = numDonGia.Value;
                selected.SoLuong = (int)numSoLuong.Value;
                selected.NgayNhap = dtpNgayNhap.Value;
                selected.ConKinhDoanh = chkConKinhDoanh.Checked;
                selected.DuongDanAnh = picAnh.Tag?.ToString() ?? string.Empty;

                productSource.ResetBindings(false);
                UpdateStatus($"Đã cập nhật sản phẩm [{selected.MaSP}]");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaSanPham()
        {
            Product selected = LaySanPhamDangChon();
            if (selected == null) return;

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{selected.MaSP}] - {selected.TenSP}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                products.Remove(selected);
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm thành công");
            }
        }

        private void TimKiemSanPham()
        {
            string keyword = tstxtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvProducts.DataSource = productSource;
                UpdateStatus("Đã hiển thị toàn bộ danh sách");
                return;
            }

            var ketQua = products.Where(p =>
                p.MaSP.ToLower().Contains(keyword) ||
                p.TenSP.ToLower().Contains(keyword)).ToList();

            dgvProducts.DataSource = ketQua;
            UpdateStatus($"Tìm thấy {ketQua.Count} sản phẩm khớp với từ khóa '{keyword}'");
        }

        private void LamMoiToanBo()
        {
            tstxtTimKiem.Clear();
            dgvProducts.DataSource = productSource;
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu");
        }

        private void XemChiTietSanPham()
        {
            Product p = LaySanPhamDangChon();
            if (p == null) return;

            string info = $"Mã SP: {p.MaSP}\n" +
                          $"Tên SP: {p.TenSP}\n" +
                          $"Loại: {p.LoaiSP}\n" +
                          $"Đơn giá: {p.DonGia:N0} VNĐ\n" +
                          $"Số lượng: {p.SoLuong}\n" +
                          $"Thành tiền: {p.ThanhTien:N0} VNĐ\n" +
                          $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
                          $"Trạng thái: {(p.ConKinhDoanh ? "Đang kinh doanh" : "Ngừng kinh doanh")}";

            MessageBox.Show(info, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Product LaySanPhamDangChon()
        {
            return productSource.Current as Product;
        }

        #endregion

        #region QUẢN LÝ TRẠNG THÁI NÚT BẤM & TƯƠNG TÁC LƯỚI

        private void CapNhatTrangThaiNut()
        {
            bool coChonDong = dgvProducts.CurrentRow != null && dgvProducts.SelectedRows.Count > 0;
            mnuSua.Enabled = tsbSua.Enabled = ctxSua.Enabled = btnSua.Enabled = coChonDong;
            mnuXoa.Enabled = tsbXoa.Enabled = ctxXoa.Enabled = btnXoa.Enabled = coChonDong;
            ctxChiTiet.Enabled = coChonDong;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product p = LaySanPhamDangChon();
                if (p != null)
                {
                    LoadProductToForm(p);
                    CapNhatTrangThaiNut();
                }
            }
        }

        private void dgvProducts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[e.RowIndex].Selected = true;
                productSource.Position = e.RowIndex;
                CapNhatTrangThaiNut();
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // Cú pháp using chuẩn cho C# 7.3: có ngoặc tròn () và khối { }
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh sản phẩm";
                dialog.Filter = "Ảnh sản phẩm (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    picAnh.Image = Image.FromFile(dialog.FileName);
                    picAnh.Tag = dialog.FileName;
                    UpdateStatus($"Đã chọn ảnh: {Path.GetFileName(dialog.FileName)}");
                }
            }
        }

        #endregion

        #region ĐỒNG BỘ 23 SỰ KIỆN GỌI CHUNG VỚI FILE DESIGNER

        // Nhóm Thêm
        private void btnThem_Click(object sender, EventArgs e) => ThemSanPham();
        private void mnuThem_Click(object sender, EventArgs e) => ThemSanPham();
        private void tsbThem_Click(object sender, EventArgs e) => ThemSanPham();

        // Nhóm Sửa
        private void btnSua_Click(object sender, EventArgs e) => SuaSanPham();
        private void mnuSua_Click(object sender, EventArgs e) => SuaSanPham();
        private void tsbSua_Click(object sender, EventArgs e) => SuaSanPham();
        private void ctxSua_Click(object sender, EventArgs e) => SuaSanPham();

        // Nhóm Xóa
        private void btnXoa_Click(object sender, EventArgs e) => XoaSanPham();
        private void mnuXoa_Click(object sender, EventArgs e) => XoaSanPham();
        private void tsbXoa_Click(object sender, EventArgs e) => XoaSanPham();
        private void ctxXoa_Click(object sender, EventArgs e) => XoaSanPham();

        // Nhóm Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoiToanBo();
        private void mnuFileLamMoi_Click(object sender, EventArgs e) => LamMoiToanBo();
        private void tsbLamMoi_Click(object sender, EventArgs e) => LamMoiToanBo();

        // Nhóm Tìm kiếm
        private void tsbTimKiem_Click(object sender, EventArgs e) => TimKiemSanPham();
        private void tstxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemSanPham();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Chi tiết, Giới thiệu & Thoát
        private void ctxChiTiet_Click(object sender, EventArgs e) => XemChiTietSanPham();
        private void mnuFileThoat_Click(object sender, EventArgs e) => Application.Exit();
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm Quản lý sản phẩm ProductManager v1.0\nNhóm 1 - Lập trình trên Windows COMP1019",
                            "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}