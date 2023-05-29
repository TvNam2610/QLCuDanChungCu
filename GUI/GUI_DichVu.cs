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
    public partial class GUI_DichVu : Form
    {
        public GUI_DichVu()
        {
            InitializeComponent();
        }

        BUS_DichVu busdv = new BUS_DichVu();
        private void btnDKDV_Click(object sender, EventArgs e)
        {
            gbDichVu.Visible = false;
            gbDKDV.Visible = true;
            gbDSDKDV.Visible = true;
            gbDSDV.Visible = false;
        }

        private void btnThongTinDV_Click(object sender, EventArgs e)
        {
            gbDichVu.Visible = true;
            gbDKDV.Visible = false;
            gbDSDKDV.Visible = false;
            gbDSDV.Visible = true;
        }

        void reset()
        {
            txtMaDichVu.Clear();
            txtMaDKDV.Clear();
            txtMaDichVu.Clear();
            txtDonGia.Clear();
            txtTenDichVu.Clear();
        } 
        private void btnThem_Click(object sender, EventArgs e)
        {  
            try
            {
                string madichvu = txtMaDichVu.Text;
                string tendichvu = txtTenDichVu.Text;
                int dongia = int.Parse(txtDonGia.Text);
                DichVu dv = new DichVu(madichvu, tendichvu, dongia);
                busdv.addDichVu(dv);
                MessageBox.Show("Thêm thông tin dịch vụ thành công!");
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_DichVu_Load(sender, e);
            }
        }
        private void btnDangKyDV_Click(object sender, EventArgs e)
        {
            try
            {
                string madkdv = txtMaDKDV.Text;
                string mach = cbMaCHDV.Text;
                string dichvuDK = cbDicVu.SelectedValue.ToString();
                DateTime ngayDK = DateTime.Parse(dtpNgayDangKiDV.Text);
                DateTime ngayHetHan = DateTime.Parse(dtpNgayhetHanDV.Text);
                DangKiDichVu dk = new DangKiDichVu(madkdv, mach, dichvuDK, ngayDK, ngayHetHan);
                
                busdv.addDangKiDichVu(dk);
                MessageBox.Show("Đăng ký dịch vụ thành công!");
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_DichVu_Load(sender, e);
            }
        }

        private void GUI_DichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.DataSource = busdv.getDichVu();
            dgvDangKyDichVu.DataSource = busdv.getDangKiDichVu();
           
            cbDicVu.DataSource = busdv.getDichVu();
            cbDicVu.ValueMember = "MaDichVu";
            cbDicVu.DisplayMember = "TenDichVu";
            cbMaCHDV.DataSource = busdv.getCanHo();
            
            cbMaCHDV.ValueMember = "MaCH";
            cbMaCHDV.DisplayMember = "MaCH";


            /*cbChucVu.DataSource = busnv.getChucVu();
            cbChucVu.ValueMember = "MaChucVu";
            cbChucVu.DisplayMember = "TenChucVu";

            cbNQL.DataSource = busnv.getQuanLy();
            cbNQL.ValueMember = "MaQL";
            cbNQL.DisplayMember = "TenQL";*/
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDichVu.Text;
            string tenDichVu = txtTenDichVu.Text;
            int dongia = int.Parse(txtDonGia.Text);
            
            DichVu dv = new DichVu(maDichVu, tenDichVu, dongia);
            busdv.editDichVu(dv);
            MessageBox.Show("Cập nhật thông tin dịch vụ thành công!");
            reset();
            GUI_DichVu_Load(sender, e);
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDichVu.Text = dgvDichVu.CurrentRow.Cells[0].Value.ToString();
            txtTenDichVu.Text = dgvDichVu.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = dgvDichVu.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string madichvu = txtMaDichVu.Text;
                busdv.deleteDichVu(madichvu);
                reset();
                GUI_DichVu_Load(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyword.Text;
            dgvDichVu.DataSource = busdv.searchDichVu(keyWord);
            txtKeyword.Text = "";
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
            GUI_DichVu_Load(sender, e);
        }
    }
}
