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
    public partial class GUI_DienNuoc : Form
    {
        public GUI_DienNuoc()
        {
            InitializeComponent();
        }

        BUS_DienNuoc busdn = new BUS_DienNuoc();

        
        private void GUI_DienNuoc_Load(object sender, EventArgs e)
        {
            dgvDienNuoc.DataSource = busdn.getDienNuoc();
           
            cbCanHo.DataSource = busdn.getCanHo();
            cbCanHo.ValueMember = "MaCH";
        }

        private void dgvDienNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDN.Text = dgvDienNuoc.CurrentRow.Cells[0].Value.ToString();
            txtThang.Text = dgvDienNuoc.CurrentRow.Cells[1].Value.ToString();
            txtNam.Text = dgvDienNuoc.CurrentRow.Cells[2].Value.ToString();
            txtSoDienTieuThu.Text = dgvDienNuoc.CurrentRow.Cells[3].Value.ToString();
            txtSoNuocTieuThu.Text = dgvDienNuoc.CurrentRow.Cells[4].Value.ToString();
            cbCanHo.Text = dgvDienNuoc.CurrentRow.Cells[5].Value.ToString();
        }

        void reset()
        {
            txtMaDN.Clear();
            txtThang.Clear();
            txtNam.Clear();
            txtSoDienTieuThu.Clear() ;
            txtSoNuocTieuThu.Clear();
            cbCanHo.SelectedValue = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDN = txtMaDN.Text;
                int thang = int.Parse(txtThang.Text);
                int nam = int.Parse(txtNam.Text);
                int sodien = int.Parse(txtSoDienTieuThu.Text);
                int sonuoc = int.Parse(txtSoNuocTieuThu.Text);
                string canho = cbCanHo.SelectedValue.ToString();
                DienNuoc dn = new DienNuoc(maDN, thang, nam, sodien, sonuoc, canho);
                busdn.addDienNuoc(dn);
                MessageBox.Show("Thêm thông tin điện nước thành công!");
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_DienNuoc_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDN = txtMaDN.Text;
            int thang = int.Parse(txtThang.Text);
            int nam = int.Parse(txtNam.Text);
            int sodien = int.Parse(txtSoDienTieuThu.Text);
            int sonuoc = int.Parse(txtSoNuocTieuThu.Text);
            string canho = cbCanHo.SelectedValue.ToString();
            DienNuoc dn = new DienNuoc(maDN, thang, nam, sodien, sonuoc, canho);
            busdn.editDienNuoc(dn);
            MessageBox.Show("Cập nhật thông tin điện nước thành công!");
            reset();
            GUI_DienNuoc_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string madn = txtMaDN.Text;
                busdn.deleteDienNuoc(madn);
                reset();
                GUI_DienNuoc_Load(sender, e);
            }
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin điện nước";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busdn.KetXuatWord(saveFileDialog.FileName);
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
            saveFileDialog.Title = "Lưu thông tin điện nước";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busdn.XuatExcel(saveFileDialog.FileName);
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
            dgvDienNuoc.DataSource = busdn.searchDienNuoc(keyWord);
            txtKeyword.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
            GUI_DienNuoc_Load(sender, e);
        }
    }
}
