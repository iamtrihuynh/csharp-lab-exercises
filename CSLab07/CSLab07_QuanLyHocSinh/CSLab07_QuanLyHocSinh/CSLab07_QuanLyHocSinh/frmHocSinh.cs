using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSLab07_QuanLyHocSinh
{
    public partial class frmHocSinh : Form
    {
        private string chuoiketnoi = @"Server=.\SQLEXPRESS; Database=DBHocSinh; Integrated Security=True;";

        public frmHocSinh()
        {
            InitializeComponent();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            lvHocSinh.View = View.Details;
            lvHocSinh.FullRowSelect = true;
            lvHocSinh.GridLines = true;

            LoadComboBoxLop();
            LoadDanhSachHocSinh();
        }

        // Tải danh sách lớp vào ComboBox để người dùng chọn
        private void LoadComboBoxLop()
        {
            cboLop.Items.Clear();
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                con.Open();
                string sql = "SELECT MaLop FROM Lop";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cboLop.Items.Add(dr.GetString(0));
                    }
                }
            }
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
        }

        // Tải danh sách học sinh lên ListView
        private void LoadDanhSachHocSinh()
        {
            lvHocSinh.Items.Clear();
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT MaHS, TenHS, NgaySinh, DiaChi, DTB, MaLop FROM HocSinh";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string mahs = dr.GetString(0);
                            string tenhs = dr.GetString(1);
                            DateTime ngaysinh = dr.IsDBNull(2) ? DateTime.MinValue : dr.GetDateTime(2);
                            string diachi = dr.IsDBNull(3) ? "" : dr.GetString(3);
                            float dtb = dr.IsDBNull(4) ? 0 : dr.GetFloat(4);
                            string malop = dr.IsDBNull(5) ? "" : dr.GetString(5);

                            ListViewItem item = new ListViewItem(mahs);
                            item.Tag = mahs;
                            item.SubItems.Add(tenhs);
                            item.SubItems.Add(ngaysinh == DateTime.MinValue ? "" : ngaysinh.ToString("dd/MM/yyyy"));
                            item.SubItems.Add(diachi);
                            item.SubItems.Add(dtb.ToString("F1"));
                            item.SubItems.Add(malop);

                            lvHocSinh.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
                }
            }
        }

        // Đổ thông tin khi click chọn dòng
        private void lvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count > 0)
            {
                ListViewItem it = lvHocSinh.SelectedItems[0];
                txtMaHS.Text = it.Text;
                txtTenHS.Text = it.SubItems[1].Text;
                if (DateTime.TryParseExact(it.SubItems[2].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
                {
                    dtpNgaySinh.Value = ns;
                }
                txtDiaChi.Text = it.SubItems[3].Text;
                txtDTB.Text = it.SubItems[4].Text;
                cboLop.SelectedItem = it.SubItems[5].Text;
            }
        }

        // Thêm học sinh
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHS.Text) || string.IsNullOrWhiteSpace(txtTenHS.Text))
            {
                MessageBox.Show("Mã học sinh và tên không được để trống!");
                return;
            }

            if (!float.TryParse(txtDTB.Text, out float dtb) || dtb < 0 || dtb > 10)
            {
                MessageBox.Show("Điểm trung bình phải nằm trong đoạn [0, 10]!");
                return;
            }

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = @"INSERT INTO HocSinh (MaHS, TenHS, NgaySinh, DiaChi, DTB, MaLop) 
                                   VALUES (@MaHS, @TenHS, @NgaySinh, @DiaChi, @DTB, @MaLop)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@MaHS", txtMaHS.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenHS", txtTenHS.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@DTB", dtb);
                        cmd.Parameters.AddWithValue("@MaLop", cboLop.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm học sinh thành công!");
                    LoadDanhSachHocSinh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Sửa học sinh
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học sinh cần sửa!");
                return;
            }

            string maHS = lvHocSinh.SelectedItems[0].Tag.ToString();
            float.TryParse(txtDTB.Text, out float dtb);

            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = @"UPDATE HocSinh 
                                   SET TenHS = @TenHS, NgaySinh = @NgaySinh, DiaChi = @DiaChi, DTB = @DTB, MaLop = @MaLop 
                                   WHERE MaHS = @MaHS";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@TenHS", txtTenHS.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@DTB", dtb);
                        cmd.Parameters.AddWithValue("@MaLop", cboLop.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@MaHS", maHS);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật học sinh thành công!");
                    LoadDanhSachHocSinh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Xóa học sinh
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học sinh cần xóa!");
                return;
            }

            string maHS = lvHocSinh.SelectedItems[0].Tag.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh '{maHS}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        con.Open();
                        string sql = "DELETE FROM HocSinh WHERE MaHS = @MaHS";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@MaHS", maHS);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đã xóa học sinh!");
                        LoadDanhSachHocSinh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}