using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSLab07_QuanLyHocSinh
{
    public partial class frmLop : Form
    {
        private string chuoiketnoi = @"Server=.\SQLEXPRESS; Database=DBHocSinh; Integrated Security=True;";

        public frmLop()
        {
            InitializeComponent();
        }
        // 2. Hàm tải danh sách lớp từ CSDL lên ListView
        private void loadDanhSach()
        {
            // Xóa sạch các dòng cũ trên ListView trước khi nạp mới
            lvLop.Items.Clear();

            // Khởi tạo kết nối trong khối using để tự động giải phóng tài nguyên
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT MaLop, TenLop, SiSo FROM Lop";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string malop = dr.GetString(0);
                            string tenlop = dr.GetString(1);
                            short siso = dr.GetInt16(2);

                            // Tạo một dòng mới trên ListView
                            ListViewItem lvi = new ListViewItem(malop); // Cột đầu tiên (Text)
                            lvi.Tag = malop; // Lưu mã lớp vào Tag để tiện truy vấn
                            lvi.SubItems.Add(tenlop); // Cột thứ hai
                            lvi.SubItems.Add(siso.ToString()); // Cột thứ ba

                            lvLop.Items.Add(lvi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmLop_Load(object sender, EventArgs e)
        {
            loadDanhSach();
            cboListType.SelectedIndex = 1;
        }

        private void cboListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboListType.SelectedIndex)
            {
                case 0: lvLop.View = View.LargeIcon; break;
                case 1: lvLop.View = View.Details; break;
                case 2: lvLop.View = View.SmallIcon; break;
                case 3: lvLop.View = View.List; break;
                case 4: lvLop.View = View.Tile; break;
            }
        }

        private void lvLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra có ít nhất 1 dòng được chọn
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem item = lvLop.SelectedItems[0];
                txtMaLop.Text = item.Text;
                txtTenLop.Text = item.SubItems[1].Text;
                txtSiSo.Text = item.SubItems[2].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã lớp và tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!short.TryParse(txtSiSo.Text, out short siso) || siso < 0)
            {
                MessageBox.Show("Sĩ số phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Lop (MaLop, TenLop, SiSo) VALUES (@MaLop, @TenLop, @SiSo)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text.Trim());
                        cmd.Parameters.AddWithValue("@SiSo", siso);

                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh Insert
                    }

                    MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDanhSach();
                    XoaTrangForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                        MessageBox.Show("Mã lớp này đã tồn tại trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!short.TryParse(txtSiSo.Text, out short siso) || siso < 0)
            {
                MessageBox.Show("Sĩ số không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = lvLop.SelectedItems[0].Tag.ToString();

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Lop SET TenLop = @TenLop, SiSo = @SiSo WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text.Trim());
                        cmd.Parameters.AddWithValue("@SiSo", siso);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDanhSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = lvLop.SelectedItems[0].Tag.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{maLop}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        con.Open();
                        string sql = "DELETE FROM Lop WHERE MaLop = @MaLop";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@MaLop", maLop);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDanhSach();
                        XoaTrangForm();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Lỗi vi phạm khóa ngoại (foreign key)
                            MessageBox.Show("Không thể xóa lớp này vì đang có học sinh thuộc lớp!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XoaTrangForm()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSiSo.Clear();
            txtMaLop.Focus();
        }
    }
}
