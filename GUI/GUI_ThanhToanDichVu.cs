using BUS;
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

        BUS_HoaDonDichVu hd = new BUS_HoaDonDichVu();
        private void GUI_ThanhToanDichVu_Load(object sender, EventArgs e)
        {
            dgvThanhToanDV.DataSource = hd.getHoaDonDichVu();
        }
    }
}
