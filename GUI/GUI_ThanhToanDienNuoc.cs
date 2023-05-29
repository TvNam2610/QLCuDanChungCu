using BUS;
using DTO;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace GUI
{
    public partial class GUI_ThanhToanDienNuoc : Form
    {
        public GUI_ThanhToanDienNuoc()
        {
            InitializeComponent();
        }

        BUS_HoaDonDienNuoc hddn = new BUS_HoaDonDienNuoc();
        private void GUI_ThanhToanDienNuoc_Load(object sender, EventArgs e)
        {
            dgvThanhToanDN.DataSource = hddn.getHoaDonDienNuoc();

            txtGiaDien.Text = hddn.getGia().Rows[0][0].ToString();
            txtGiaNuoc.Text = hddn.getGia().Rows[0][1].ToString();

            cbCanHo.DataSource = hddn.getCanHo();
            cbCanHo.ValueMember = "MaCH";
        }
        void reset()
        {
            txtMaTT.Clear();
            txtSoDienTieuThu.Clear();
            txtSoNuocTieuThu.ResetText();
            cbCanHo.SelectedIndex = 0;
            txtGiaDien.Clear();
            txtGiaNuoc.Clear();
            txtTongTien.Clear();
            cbTrangthai.SelectedIndex = 0;
            dtpNgayTT.Value = DateTime.Now;
        }

        private void btnAddHoaDonDN_Click(object sender, EventArgs e)
        {
            DienNuoc dn = new DienNuoc()
            {
                MaCH = cbCanHo.Text,
                //MaCH = cbCanHo.SelectedValue.ToString(),
                SoDienTieuThu = int.Parse(txtSoDienTieuThu.Text),
                SoNuocTieuThu = int.Parse(txtSoNuocTieuThu.Text)
            };
            HoaDonDienNuoc hd = new HoaDonDienNuoc()
            {
                MaTT = txtMaTT.Text,
                NgayTT = dtpNgayTT.Value,
                TongTien = float.Parse(txtTongTien.Text),
                trangthai = cbTrangthai.Text
            };


            hddn.addHoaDonDienNuoc(dn, hd);
            MessageBox.Show("Thêm hóa đơn thành công!");
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_ThanhToanDienNuoc_Load(sender, e);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin hóa đơn";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                    hddn.KetXuatWord(saveFileDialog.FileName,new List<int> () 
                    { 
                        int.Parse(txtSoDienTieuThu.Text), 
                        int.Parse(txtSoNuocTieuThu.Text),
                        int.Parse(txtTongTien.Text)
                    });
                    MessageBox.Show("Kết xuất thành công!");
                try
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
            GUI_ThanhToanDienNuoc_Load(sender, e);
        }

        private void txtTongTien_Enter(object sender, EventArgs e)
        {
            txtTongTien.Text = (float.Parse(txtSoDienTieuThu.Text) * float.Parse(txtGiaDien.Text) + float.Parse(txtSoNuocTieuThu.Text) * float.Parse(txtGiaNuoc.Text)).ToString();
        }

        private void dgvThanhToanDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTT.Text = dgvThanhToanDN.CurrentRow.Cells[0].Value.ToString();
            cbCanHo.SelectedValue = dgvThanhToanDN.CurrentRow.Cells[1].Value.ToString();
            txtSoDienTieuThu.Text = dgvThanhToanDN.CurrentRow.Cells[2].Value.ToString();
            txtGiaDien.Text = dgvThanhToanDN.CurrentRow.Cells[3].Value.ToString() ;
            txtSoNuocTieuThu.Text = dgvThanhToanDN.CurrentRow.Cells[4].Value.ToString();
            txtGiaNuoc.Text = dgvThanhToanDN.CurrentRow.Cells[5].Value.ToString();
            dtpNgayTT.Value = (DateTime)dgvThanhToanDN.CurrentRow.Cells[6].Value;
            txtTongTien.Text = dgvThanhToanDN.CurrentRow.Cells[7].Value.ToString();
            cbTrangthai.SelectedValue = dgvThanhToanDN.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
            GUI_ThanhToanDienNuoc_Load(sender, e);
        }
    }
}
