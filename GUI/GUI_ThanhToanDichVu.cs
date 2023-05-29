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
    public partial class GUI_ThanhToanDichVu : Form
    {
        public GUI_ThanhToanDichVu()
        {
            InitializeComponent();
        }

        BUS_HoaDonDichVu hddv = new BUS_HoaDonDichVu();
        private void GUI_ThanhToanDichVu_Load(object sender, EventArgs e)
        {
            dgvThanhToanDV.DataSource = hddv.getHoaDonDichVu();
            cbDKDV.DataSource = hddv.getMaDK();
            cbDKDV.ValueMember = "Madkdv";
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            string madkdv = cbDKDV.SelectedValue.ToString();
            DateTime ngayTT = dtpNgayTT.Value;
            float tongtien = float.Parse(txtTongTien.Text);
            string trangthai = cbTrangthai.Text;


            HoaDonDichVu hd = new HoaDonDichVu(madkdv, ngayTT, tongtien, trangthai);
            hddv.addHoaDonDichVu(hd);
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
                GUI_ThanhToanDichVu_Load(sender, e);
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
                try
                {
                    hddv.KetXuatWord(saveFileDialog.FileName, txtMahoadonDV.Text);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
            GUI_ThanhToanDichVu_Load(sender, e);
        }
    }
}
