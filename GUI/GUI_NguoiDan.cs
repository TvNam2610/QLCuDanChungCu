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
    public partial class GUI_NguoiDan : Form
    {
        public GUI_NguoiDan()
        {
            InitializeComponent();
        }
        BUS_NguoiDan busnd = new BUS_NguoiDan();
        public event EventHandler ExitForm;
        private void GUI_NguoiDan_Load(object sender, EventArgs e)
        {
            dgvNguoiDan.DataSource = busnd.getNguoiDan();
            dgvDangKyCanHo.DataSource = busnd.getCanHo_NguoiDan();

            cbMaCH.DataSource = busnd.getCanHo();
            cbMaCH.ValueMember = "MaCH";
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maND = txtMaND.Text;
                string hoTen = txtHoten.Text;
                DateTime ngaySinh = DateTime.Parse(dtpNgaySinh.Text);
                string gioiTinh = cboGioitinh.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string diaChi = txtDiaChi.Text;
                NguoiDan nd = new NguoiDan(maND, hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi);
                busnd.addNguoiDan(nd);
                MessageBox.Show("Thêm thông tin người dân thành công!");
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_NguoiDan_Load(sender, e);
            }
        }
        void reset()
        {
            txtMaND.Clear();
            txtHoten.Clear();
            dtpNgaySinh.ResetText();
            cboGioitinh.SelectedIndex = 0;
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtMaNDDK.Clear();
            cbMaCH.SelectedIndex = 0;
            dtpNgayDangKy.ResetText();
        }

        private void dgvNguoiDan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaND.Text = dgvNguoiDan.CurrentRow.Cells[0].Value.ToString();
            txtHoten.Text = dgvNguoiDan.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvNguoiDan.CurrentRow.Cells[2].Value;
            cboGioitinh.SelectedIndex = dgvNguoiDan.CurrentRow.Cells[3].Value.ToString() == "Nam" ? 0 : 1;
            txtSoDienThoai.Text = dgvNguoiDan.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNguoiDan.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maND = txtMaND.Text;
            string hoTen = txtHoten.Text;
            DateTime ngaySinh = DateTime.Parse(dtpNgaySinh.Text);
            string gioiTinh = cboGioitinh.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            NguoiDan nd = new NguoiDan(maND, hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi);
            busnd.editNguoiDan(nd);
            MessageBox.Show("Cập nhật thông tin người dân thành công!");
            reset();
            GUI_NguoiDan_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maND = txtMaND.Text;
                busnd.deleteNguoiDan(maND);
                reset();
                GUI_NguoiDan_Load(sender, e);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GUI_NguoiDan_Load(sender, e);
            reset();
        }

        private void btnDangKyCH_Click(object sender, EventArgs e)
        {
            pnlTTND.Visible = false;
            pnlDKCH.Visible = true;
        }

        private void btnThongTinND_Click(object sender, EventArgs e)
        {
            pnlTTND.Visible = true;
            pnlDKCH.Visible=false;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DKCanHo dKCanHo = new DKCanHo()
            {
                MaND = txtMaNDDK.Text,
                MaCH = cbMaCH.Text,
                NgayDangKi = dtpNgayDangKy.Value
            };
            if (txtMaNDDK.Text != "")
            {
                MessageBox.Show("Đăng ký người dân vào căn hộ thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chưa nhập mã người dân");
            }
            reset();
            busnd.addNguoiDan_CanHo(dKCanHo);
            GUI_NguoiDan_Load(sender, e);
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
                    busnd.KetXuatWord(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }

            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyword.Text;
            dgvNguoiDan.DataSource = busnd.searchNguoiDan(keyWord);
            txtKeyword.Text = "";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin người dân";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busnd.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void dgvNguoiDan_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaND.Text = dgvNguoiDan.CurrentRow.Cells[0].Value.ToString();
            txtHoten.Text = dgvNguoiDan.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvNguoiDan.CurrentRow.Cells[2].Value;
            cboGioitinh.SelectedIndex = dgvNguoiDan.CurrentRow.Cells[3].Value.ToString() == "Nam" ? 0 : 1;
            txtSoDienThoai.Text = dgvNguoiDan.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNguoiDan.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
