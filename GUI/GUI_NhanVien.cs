using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_NhanVien : Form
    {
        public GUI_NhanVien()
        {
            InitializeComponent();
        }

        BUS_NhanVien busnv = new BUS_NhanVien();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                string tenNV = txtTenNV.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string email = txtEmail.Text;
                string maChucVu = cbChucVu.SelectedValue.ToString();
                string maQuanLy = cbNQL.SelectedValue.ToString();
                NhanVien nv = new NhanVien(maNV, tenNV, diaChi, soDienThoai, email, maChucVu, maQuanLy);
                busnv.addNhanVien(nv);
                MessageBox.Show("Thêm thông tin nhân viên thành công!");
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_NhanVien_Load(sender, e);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busnv.getNhanVien();

            cbChucVu.DataSource = busnv.getChucVu();
            cbChucVu.ValueMember = "MaChucVu";
            cbChucVu.DisplayMember = "TenChucVu";

            cbNQL.DataSource = busnv.getQuanLy();
            cbNQL.ValueMember = "MaQL";
            cbNQL.DisplayMember = "TenQL";


        }

        void reset()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            cbChucVu.SelectedIndex = 0;
            cbNQL.SelectedIndex = 0;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSoDienThoai.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            cbChucVu.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            cbNQL.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string email = txtEmail.Text;
            string maChucVu = cbChucVu.SelectedValue.ToString();
            string maQuanLy = cbNQL.SelectedValue.ToString();
            NhanVien nv = new NhanVien(maNV, tenNV, diaChi, soDienThoai, email, maChucVu, maQuanLy);
            busnv.editNhanVien(nv);
            MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
            reset();
            GUI_NhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maNV = txtMaNV.Text;
                busnv.deleteNhanVien(maNV);
                reset();
                GUI_NhanVien_Load(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyword.Text;
            dgvNhanVien.DataSource = busnv.searchNhanVien(keyWord);
            txtKeyword.Text = "";
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin người dân";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busnv.KetXuatWord(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }

            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin nhân viên";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busnv.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }
    }
}
