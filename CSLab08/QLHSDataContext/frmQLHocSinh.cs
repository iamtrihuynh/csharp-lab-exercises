using QLHSDataContext;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLHSDataContext
{
    public partial class frmQLHocSinh : Form
    {
        // Khởi tạo đối tượng Context đại diện cho toàn bộ cơ sở dữ liệu
        private QLHSDataContext db = new QLHSDataContext();

        public frmQLHocSinh()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form khởi chạy
        private void frmQLHocSinh_Load(object sender, EventArgs e)
        {
            try
            {
                // Đổ danh sách Lớp vào ComboBox
                cboLop.DataSource = db.Lops.ToList();
                cboLop.DisplayMember = "TenLop"; // Tên hiển thị người dùng nhìn thấy
                cboLop.ValueMember = "MaLop";     // Giá trị thực tế ngầm bên dưới

                // Tải danh sách học sinh theo lớp đang được chọn
                fillHocSinhByLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm lọc danh sách học sinh theo mã lớp và từ khóa tên gần đúng
        /// </summary>
        private void fillHocSinhByLop()
        {
            if (cboLop.SelectedValue == null) return;

            string maLopDuocChon = cboLop.SelectedValue.ToString();
            string tuKhoaTen = txtTenHS.Text.Trim();

            // Dùng LINQ lọc dữ liệu: Where kết hợp biểu thức Lambda
            var dsHocSinh = db.HocSinhs.Where(p =>
                p.MaLop == maLopDuocChon &&
                p.TenHS.Contains(tuKhoaTen)
            );

            // Phép chiếu Select sang đối tượng vô danh để hiển thị lên DataGridView
            dgvHocSinh.DataSource = dsHocSinh.Select(p => new
            {
                p.MaHS,
                p.TenHS,
                TenLop = p.Lop.TenLop, // Truy xuất thông qua quan hệ Foreign Key giữa 2 thực thể
                p.DTB
            }).ToList();
        }

        // Khi người dùng thay đổi lựa chọn lớp trong ComboBox
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra SelectedValue tránh việc hàm chạy trước khi ComboBox gán xong DataSource
            if (cboLop.SelectedValue != null && cboLop.SelectedValue is string)
            {
                fillHocSinhByLop();
            }
        }

        // Chức năng Tìm kiếm học sinh
        private void btnTim_Click(object sender, EventArgs e)
        {
            fillHocSinhByLop();
        }

        // Chức năng Thêm học sinh
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(txtMaHS.Text) || string.IsNullOrWhiteSpace(txtTenHS.Text))
            {
                MessageBox.Show("Mã học sinh và tên học sinh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtDiemTB.Text, out float dtb) || dtb < 0 || dtb > 10)
            {
                MessageBox.Show("Điểm trung bình phải là số thực từ 0.0 đến 10.0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng khóa chính MaHS bằng LINQ
            string ma = txtMaHS.Text.Trim();
            if (db.HocSinhs.Any(p => p.MaHS == ma))
            {
                MessageBox.Show($"Mã học sinh '{ma}' đã tồn tại!", "Cảnh báo trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. Tạo đối tượng thực thể HocSinh
                HocSinh hs = new HocSinh
                {
                    MaHS = ma,
                    TenHS = txtTenHS.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    MaLop = cboLop.SelectedValue.ToString(),
                    DTB = dtb
                };

                // 2. Đưa vào hàng đợi thêm mới của DataContext
                db.HocSinhs.InsertOnSubmit(hs);

                // 3. Thực thi lưu thay đổi về CSDL SQL Server
                db.SubmitChanges();

                MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillHocSinhByLop();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Sửa thông tin học sinh
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaHS.Text.Trim();

            // 1. Tìm đối tượng cần sửa bằng SingleOrDefault
            HocSinh hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == ma);

            if (hs != null)
            {
                if (!float.TryParse(txtDiemTB.Text, out float dtb) || dtb < 0 || dtb > 10)
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // 2. Gán các giá trị mới
                    hs.TenHS = txtTenHS.Text.Trim();
                    hs.NgaySinh = dtpNgaySinh.Value;
                    hs.DiaChi = txtDiaChi.Text.Trim();
                    hs.MaLop = cboLop.SelectedValue.ToString();
                    hs.DTB = dtb;

                    // 3. Cập nhật thay đổi vào CSDL
                    db.SubmitChanges();

                    MessageBox.Show("Cập nhật thông tin học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillHocSinhByLop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Không tìm thấy học sinh có mã '{ma}' để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Chức năng Xóa học sinh
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaHS.Text.Trim();

            // 1. Tìm đối tượng cần xóa
            HocSinh hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == ma);

            if (hs != null)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh '{hs.TenHS}' (Mã: {hs.MaHS}) không?",
                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // 2. Đánh dấu xóa đối tượng
                        db.HocSinhs.DeleteOnSubmit(hs);

                        // 3. Thực thi xóa trên SQL Server
                        db.SubmitChanges();

                        MessageBox.Show("Đã xóa học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillHocSinhByLop();
                        LamMoiForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Không tìm thấy học sinh có mã '{ma}' để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Click một dòng trên DataGridView để tự động đổ dữ liệu lên các ô TextBox
        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHocSinh.Rows.Count)
            {
                string maChon = dgvHocSinh.Rows[e.RowIndex].Cells["MaHS"].Value.ToString();

                // Truy vấn lại thông tin đầy đủ của đối tượng học sinh
                HocSinh hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == maChon);
                if (hs != null)
                {
                    txtMaHS.Text = hs.MaHS;
                    txtTenHS.Text = hs.TenHS;
                    if (hs.NgaySinh.HasValue) dtpNgaySinh.Value = hs.NgaySinh.Value;
                    txtDiaChi.Text = hs.DiaChi;
                    txtDiemTB.Text = hs.DTB.HasValue ? hs.DTB.Value.ToString("F2") : "";
                    cboLop.SelectedValue = hs.MaLop;
                }
            }
        }

        private void LamMoiForm()
        {
            txtMaHS.Clear();
            txtTenHS.Clear();
            txtDiaChi.Clear();
            txtDiemTB.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtMaHS.Focus();
        }
    }
}